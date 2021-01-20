using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Perpustakaan.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buku",
                columns: table => new
                {
                    KodeBuku = table.Column<string>(nullable: false),
                    JudulBuku = table.Column<string>(nullable: true),
                    Penerbit = table.Column<string>(nullable: true),
                    Pengarang = table.Column<string>(nullable: true),
                    ThnTerbit = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.KodeBuku);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    IdTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserType_IdTypeId",
                        column: x => x.IdTypeId,
                        principalTable: "UserType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Anggota",
                columns: table => new
                {
                    NoKTP = table.Column<string>(nullable: false),
                    NamaLengkap = table.Column<string>(nullable: true),
                    Alamat = table.Column<string>(nullable: true),
                    NoHP = table.Column<string>(nullable: true),
                    IdUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.NoKTP);
                    table.ForeignKey(
                        name: "FK_Anggota_Users_IdUserId",
                        column: x => x.IdUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pegawai",
                columns: table => new
                {
                    Nip = table.Column<string>(nullable: false),
                    NamaPegawai = table.Column<string>(nullable: true),
                    Alamat = table.Column<string>(nullable: true),
                    NoHP = table.Column<string>(nullable: true),
                    IdUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Nip);
                    table.ForeignKey(
                        name: "FK_Pegawai_Users_IdUserId",
                        column: x => x.IdUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pinjam",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TglPinjam = table.Column<DateTime>(nullable: false),
                    TglKembali = table.Column<DateTime>(nullable: true),
                    Kembali = table.Column<string>(nullable: true),
                    KodeBuku1 = table.Column<string>(nullable: true),
                    Nip1 = table.Column<string>(nullable: true),
                    NoKTP1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pinjam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pinjam_Buku_KodeBuku1",
                        column: x => x.KodeBuku1,
                        principalTable: "Buku",
                        principalColumn: "KodeBuku",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pinjam_Pegawai_Nip1",
                        column: x => x.Nip1,
                        principalTable: "Pegawai",
                        principalColumn: "Nip",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pinjam_Anggota_NoKTP1",
                        column: x => x.NoKTP1,
                        principalTable: "Anggota",
                        principalColumn: "NoKTP",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anggota_IdUserId",
                table: "Anggota",
                column: "IdUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pegawai_IdUserId",
                table: "Pegawai",
                column: "IdUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pinjam_KodeBuku1",
                table: "Pinjam",
                column: "KodeBuku1");

            migrationBuilder.CreateIndex(
                name: "IX_Pinjam_Nip1",
                table: "Pinjam",
                column: "Nip1");

            migrationBuilder.CreateIndex(
                name: "IX_Pinjam_NoKTP1",
                table: "Pinjam",
                column: "NoKTP1");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdTypeId",
                table: "Users",
                column: "IdTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pinjam");

            migrationBuilder.DropTable(
                name: "Buku");

            migrationBuilder.DropTable(
                name: "Pegawai");

            migrationBuilder.DropTable(
                name: "Anggota");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserType");
        }
    }
}
