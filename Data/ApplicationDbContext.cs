using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Perpustakaan.Models;
using Pomelo.EntityFrameworkCore.MySql;

namespace Perpustakaan.Data
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Student> Students {get; set;}
        public virtual DbSet<Buku> Buku {get; set;}
        public virtual DbSet<Mahasiswa> Mahasiswa {get; set;}
        public virtual DbSet<Pegawai> Pegawai {get; set;}
        public virtual DbSet<User> Users {get; set;}
        public virtual DbSet<Pinjam> Pinjam {get; set;}
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
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buku>(entity =>
            {
                entity.HasKey(e => e.KodeBuku)
                    .HasName("PRIMARY");
            });
            
            modelBuilder.Entity<Mahasiswa>(entity =>
            {
                entity.HasKey(e => e.Npm)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<Pegawai>(entity =>
            {
                entity.HasKey(e => e.Nip)
                    .HasName("PRIMARY");
            });
        }

    }
}