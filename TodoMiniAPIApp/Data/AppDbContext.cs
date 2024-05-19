using Microsoft.EntityFrameworkCore;
using TodoMiniAPIApp.Modules;

namespace TodoMiniAPIApp.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }

        public DbSet<Todo> Todos{ get; set; }
    }
}
