using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Perpustakaan.Models;
using Pomelo.EntityFrameworkCore.MySql;

namespace Perpustakaan.Data
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Student> Students {get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseMySql("server = 127.0.0.1; port=3306; user=root; password=''; database=perpus")
            .UseLoggerFactory(LoggerFactory.Create(b => b
            .AddConsole()
            .AddFilter(level => level >= LogLevel.Information)))
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
        }
    }
}