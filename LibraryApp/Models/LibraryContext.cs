using LibraryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MyBlog.Web.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() { }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options) { }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<MainPage> MainPages { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
            "Server=ARMYDEV\\SQLEXPRESS;Database=LibraryApp;" +
            "TrustServerCertificate=True;Trusted_Connection=True;Encrypt=False"
               );
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
