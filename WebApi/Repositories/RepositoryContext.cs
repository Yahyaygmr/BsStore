using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
           

        public DbSet<Book> Books { get; set; }
    }
}
