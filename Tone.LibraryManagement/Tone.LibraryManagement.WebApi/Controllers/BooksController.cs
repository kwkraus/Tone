using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tone.LibraryManagement.Data.Entities;
using Tone.LibraryManagement.Data.Repositories;

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

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<List<Book>>> Get()
        {
            _logger.LogInformation("Get all books was called within WebApi");
            return await _repo.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            return await _repo.Get(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Book value)
        {
            //the Book passed in will be automatically validated and 400 (BadRequest) returned.
            //if successful, return 204 (NoContent)
            await _repo.Insert(value);
            return NoContent();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Book value)
        {
            await _repo.Update(value);
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            //must find the book to delete before deleting it from db
            var bookToDelete = await _repo.Get(id);
            await _repo.Delete(bookToDelete);
            return NoContent();
        }
    }
}