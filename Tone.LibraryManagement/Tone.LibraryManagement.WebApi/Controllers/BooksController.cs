using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Tone.LibraryManagement.Core.Repositories;
using Tone.LibraryManagement.Data.Entities;

namespace Tone.LibraryManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IRepository<Book> _repo;
        private readonly ILogger _logger;

        //logging reference https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-2.2
        public BooksController(IRepository<Book> repo, ILogger<BooksController> logger)
        {
            _repo = repo;
            _logger = logger;

        }

        // GET api/books
        [HttpGet]
        public ActionResult<List<Book>> Get()
        {
            _logger.LogInformation("Get all books was called within WebApi");
            return _repo.GetAll();
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            var book = _repo.Get(id);

            if (book == null)
                return NotFound();

            return book;
        }

        // POST api/books
        [HttpPost]
        public ActionResult Post([FromBody] Book value)
        {
            //the Book passed in will be automatically validated and 400 (BadRequest) returned.
            //if successful, return 204 (NoContent)
            _repo.Insert(value);
            return NoContent();
        }

        // PUT api/books/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Book value)
        {
            _repo.Update(value);
            return NoContent();
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            //must find the book to delete before deleting it from db
            var bookToDelete = _repo.Get(id);
            _repo.Delete(bookToDelete);
            return NoContent();
        }
    }
}