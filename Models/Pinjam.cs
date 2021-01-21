using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Perpustakaan.Models
{
    public partial class Pinjam
    {
        public int Id { get; set; }
        public DateTime TglPinjam { get; set; }
        public DateTime? TglKembali { get; set; }
        public string Kembali { get; set; }
        public string KodeBuku1 { get; set; }
        public string Nip1 { get; set; }
        public string NoKtp1 { get; set; }

        public virtual Buku KodeBuku1Navigation { get; set; }
        public virtual Pegawai Nip1Navigation { get; set; }
        public virtual Anggota NoKtp1Navigation { get; set; }
    }
}
