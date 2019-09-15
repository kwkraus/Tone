using Microsoft.EntityFrameworkCore;
using Tone.LibraryManagement.Data.Entities;

namespace Tone.LibraryManagement.Data.Contexts
{
    public class LibraryMgmtContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<BookLibraryAssociation> BookLibraryAssociations { get; set; }
        public DbSet<UserBookAssociation> UserBookAssociation { get; set; }

        public LibraryMgmtContext() { }

        public LibraryMgmtContext(DbContextOptions<LibraryMgmtContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LibraryManagementDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Book>()
                .Property(p => p.Price)
                .HasColumnType("decimal(6, 2)");
        }
    }
}
