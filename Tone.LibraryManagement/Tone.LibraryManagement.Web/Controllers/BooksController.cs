using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using Tone.LibraryManagement.Core.Services;
using Tone.LibraryManagement.Data.Contexts;
using Tone.LibraryManagement.Data.Entities;
using Tone.LibraryManagement.Web.Models.Books;

namespace Tone.LibraryManagement.Web.Controllers
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
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(NewBookViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var newBook = new Book
            {
                Title = model.Title,
                Author = model.Author,
                Genre = model.Genre,
                Price = model.Price
            };

            using (var memoryStream = new MemoryStream())
            {
                await model.CoverPictureImage.CopyToAsync(memoryStream);

                var picLocation = await _storage.UploadFileStreamAsync(
                    memoryStream, 
                    "CoverPhotos".ToLower(),
                    model.CoverPictureImage.FileName);

                newBook.CoverPicture = picLocation;
            }

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");

        }
    }
}