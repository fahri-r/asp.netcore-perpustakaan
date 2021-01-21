using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Perpustakaan.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Perpustakaan.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Anggota> Anggota { get; set; }
        public virtual DbSet<Buku> Buku { get; set; }
        public virtual DbSet<Efmigrationshistory> Efmigrationshistory { get; set; }
        public virtual DbSet<Pegawai> Pegawai { get; set; }
        public virtual DbSet<Pinjam> Pinjam { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Usertype> Usertype { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;database=perpus;user=root;treattinyasboolean=true", x => x.ServerVersion("10.4.16-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anggota>(entity =>
            {
                entity.HasKey(e => e.NoKtp)
                    .HasName("PRIMARY");

                entity.ToTable("anggota");

                entity.HasIndex(e => e.IdUserId)
                    .HasName("IX_Anggota_IdUserId");

                entity.Property(e => e.NoKtp)
                    .HasColumnName("NoKTP")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Alamat)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.IdUserId).HasColumnType("int(11)");

                entity.Property(e => e.NamaLengkap)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.NoHp)
                    .HasColumnName("NoHP")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.IdUser)
                    .WithMany(p => p.Anggota)
                    .HasForeignKey(d => d.IdUserId)
                    .HasConstraintName("FK_Anggota_Users_IdUserId");
            });

            modelBuilder.Entity<Buku>(entity =>
            {
                entity.HasKey(e => e.KodeBuku)
                    .HasName("PRIMARY");

                entity.ToTable("buku");

                entity.Property(e => e.KodeBuku)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.JudulBuku)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Penerbit)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Pengarang)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ThnTerbit).HasColumnType("smallint(6)");
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId)
                    .HasColumnType("varchar(95)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Pegawai>(entity =>
            {
                entity.HasKey(e => e.Nip)
                    .HasName("PRIMARY");

                entity.ToTable("pegawai");

                entity.HasIndex(e => e.IdUserId)
                    .HasName("IX_Pegawai_IdUserId");

                entity.Property(e => e.Nip)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Alamat)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.IdUserId).HasColumnType("int(11)");

                entity.Property(e => e.NamaPegawai)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.NoHp)
                    .HasColumnName("NoHP")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.IdUser)
                    .WithMany(p => p.Pegawai)
                    .HasForeignKey(d => d.IdUserId)
                    .HasConstraintName("FK_Pegawai_Users_IdUserId");
            });

            modelBuilder.Entity<Pinjam>(entity =>
            {
                entity.ToTable("pinjam");

                entity.HasIndex(e => e.KodeBuku1)
                    .HasName("IX_Pinjam_KodeBuku1");

                entity.HasIndex(e => e.Nip1)
                    .HasName("IX_Pinjam_Nip1");

                entity.HasIndex(e => e.NoKtp1)
                    .HasName("IX_Pinjam_NoKTP1");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Kembali)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.KodeBuku1)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Nip1)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.NoKtp1)
                    .HasColumnName("NoKTP1")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.KodeBuku1Navigation)
                    .WithMany(p => p.Pinjam)
                    .HasForeignKey(d => d.KodeBuku1)
                    .HasConstraintName("FK_Pinjam_Buku_KodeBuku1");

                entity.HasOne(d => d.Nip1Navigation)
                    .WithMany(p => p.Pinjam)
                    .HasForeignKey(d => d.Nip1)
                    .HasConstraintName("FK_Pinjam_Pegawai_Nip1");

                entity.HasOne(d => d.NoKtp1Navigation)
                    .WithMany(p => p.Pinjam)
                    .HasForeignKey(d => d.NoKtp1)
                    .HasConstraintName("FK_Pinjam_Anggota_NoKTP1");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.IdTypeId)
                    .HasName("IX_Users_IdTypeId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.IdTypeId).HasColumnType("int(11)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.IdType)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdTypeId)
                    .HasConstraintName("FK_Users_UserType_IdTypeId");
            });

            modelBuilder.Entity<Usertype>(entity =>
            {
                entity.ToTable("usertype");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
