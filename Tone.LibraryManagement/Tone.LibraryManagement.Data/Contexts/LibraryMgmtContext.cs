using Microsoft.EntityFrameworkCore;
using Tone.LibraryManagement.Data.Entities;

namespace Tone.LibraryManagement.Data.Contexts
{
    public class LibraryMgmtContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
    }
}
