using Bilet1.Models;
using Microsoft.EntityFrameworkCore;

namespace Bilet1.DAL
{
    public class AppDbContext : DbContext
    {
       public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected AppDbContext()
        {
        }

        public DbSet<Member>Members { get; set; }
    }
}
