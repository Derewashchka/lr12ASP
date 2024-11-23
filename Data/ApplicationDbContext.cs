using Microsoft.EntityFrameworkCore;
using ConsoleApp12.Models;

namespace ConsoleApp12.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = "users.db";
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}