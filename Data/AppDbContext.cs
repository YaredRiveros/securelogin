using Microsoft.EntityFrameworkCore;
using SqlInjectionDemo.Models;

namespace SqlInjectionDemo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Datos de ejemplo
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", Password = "admin123", Email = "admin@demo.com", Role = "Admin" },
                new User { Id = 2, Username = "user1", Password = "password1", Email = "user1@demo.com", Role = "User" },
                new User { Id = 3, Username = "user2", Password = "password2", Email = "user2@demo.com", Role = "User" },
                new User { Id = 4, Username = "juan", Password = "secreto", Email = "juan@demo.com", Role = "User" }
            );
        }
    }
}
