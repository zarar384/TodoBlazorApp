using Microsoft.EntityFrameworkCore;
using TodoMiniAPI.Models;

namespace TodoMiniAPI.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }

        public DbSet<Todo> Todos{ get; set; }
    }
}
