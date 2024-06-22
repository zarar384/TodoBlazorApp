using Microsoft.EntityFrameworkCore;
using TodoMiniAPI.Models;

namespace TodoMiniAPI.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Category> Categories { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Todo>()
                .HasMany(t => t.Categories)
                .WithMany();
        }
    }
}
