using System;
using System.Collections.Generic;

#nullable disable

namespace Perpustakaan.Models
{
    public partial class Pinjam
    {
        public int Id{ get; set; }
        public DateTime TglPinjam { get; set; }
        public DateTime? TglKembali { get; set; }
        public string Kembali { get; set; }

        public virtual Buku KodeBuku { get; set; }
        public virtual Pegawai Nip { get; set; }
        public virtual Anggota NoKTP { get; set; }
    }
}
