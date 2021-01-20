using Microsoft.EntityFrameworkCore;
using Perpustakaan.Models;

namespace Perpustakaan.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }
        public virtual DbSet<Buku> Buku {get; set;}
        public virtual DbSet<Anggota> Anggota {get; set;}
        public virtual DbSet<Pegawai> Pegawai {get; set;}
        public virtual DbSet<User> Users {get; set;}
        public virtual DbSet<Pinjam> Pinjam {get; set;}
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buku>(entity =>
            {
                entity.HasKey(e => e.KodeBuku)
                    .HasName("PRIMARY");
            });
            
            modelBuilder.Entity<Anggota>(entity =>
            {
                entity.HasKey(e => e.NoKTP)
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