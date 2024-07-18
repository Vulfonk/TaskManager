using Microsoft.EntityFrameworkCore;
using TaskManager.Data.Models;

namespace TaskManager.Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Priority>().HasKey(p => p.Level);
            modelBuilder.Entity<User>().HasKey(u => u.Id);

            modelBuilder.Entity<Priority>()
                .HasMany(p => p.ToDoItems)
                .WithOne(t => t.Priority)
                .HasForeignKey(t => t.PriorityId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.ToDoItems)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);
        }
    }

}
