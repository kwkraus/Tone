using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Tone.LibraryManagement.Core.Services;
using Tone.LibraryManagement.Data.Contexts;
using Tone.LibraryManagement.Data.Entities;
using Tone.LibraryManagement.MVC.Models.Books;

namespace Tone.LibraryManagement.MVC.Controllers
{
    public class BooksController : Controller
    {
        private readonly IStorageService _storage;
        private readonly LibraryMgmtContext _context;

        public BooksController(IStorageService storageSvc, LibraryMgmtContext context)
        {
            _storage = storageSvc;
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Books.ToList());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(NewBookViewModel model)
        {
            //https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-3.0
            if (!ModelState.IsValid)
                return BadRequest();

            //Book class is an entity in Data project, here we map the ViewModel to the Book entity
            //for saving into db using EF Core
            var newBook = new Book
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                Author = model.Author,
                Genre = model.Genre,
                Price = model.Price
            };

            //here we are pulling the file that was uploaded with the ViewModel book data
            //the file is part of the ViewModel and needs to be added to a new MemoryStream
            //we use the MemoryStream by sending it to the _storage service for saving to Azure Storage
            using (var memoryStream = new MemoryStream())
            {
                await model.CoverPictureImage.CopyToAsync(memoryStream);

                var picLocation = await _storage.UploadFileStreamAsync(
                    memoryStream,  //image data
                    "CoverPhotos".ToLower(),  //name of container in Azure Storage to put image file
                    $"{newBook.Id.ToString()}{Path.GetExtension(model.CoverPictureImage.FileName)}");  //name of image file to store in defined container.  this will match Book.Id for easy correlation

                //make sure to save the URI location of the image in Azure Storage to the Book Entity
                newBook.CoverPicture = picLocation;
            }

            //save the book to the database using EF Core
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            //when done, just redirect to Index action
            return RedirectToAction("Index");
        }
    }
}