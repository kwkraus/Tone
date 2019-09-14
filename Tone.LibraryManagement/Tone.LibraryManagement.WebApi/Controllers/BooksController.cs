using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult<Book> Get(int id)
        {
            return _context.Books.Find(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Book value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}