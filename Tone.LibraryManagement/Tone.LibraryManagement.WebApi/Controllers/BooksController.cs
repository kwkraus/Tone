using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tone.LibraryManagement.Data.Contexts;
using Tone.LibraryManagement.Data.Entities;

namespace Tone.LibraryManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly LibraryMgmtContext _context;

        public BooksController(LibraryMgmtContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<List<Book>> Get()
        {
            return _context.Books.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Book value)
        {
            //the Book passed in will be automatically validated and 400 (BadRequest) returned.
            //if successful, return 204 (NoContent)
            await _context.Books.AddAsync(value);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Book value)
        {
            _context.Entry(await _context.Books.FirstOrDefaultAsync(x => x.BookId == id)).CurrentValues.SetValues(value);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            //must find the book to delete before deleting it from db
            var bookToDelete = await _context.Books.FindAsync(id);
            _context.Remove(bookToDelete);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}