using Microsoft.EntityFrameworkCore;

namespace EFCoreOperation.Data
{
    public class AppDbContext:DbContext
    {
        // appdbcontext pass their own method to Dbcontext like connection or etc.
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
    }
}
