using EFCoreOperation.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCoreOperation.Data
{
    public class AppDbContext:DbContext
    {
        // appdbcontext pass their own method to Dbcontext like connection or etc.
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public DbSet<Book> Books { get; set; }
       public  DbSet<Language> Language { get; set; }
        public DbSet<BookPrice> BookPrice { get; set; }
        public DbSet<CurrencyType> CurrencyTypes { get; set; }
    }
}
