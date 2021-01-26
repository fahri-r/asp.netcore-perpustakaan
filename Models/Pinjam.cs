using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Perpustakaan.Models
{
    public partial class Pinjam
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime TglPinjam { get; set; }
        [DataType(DataType.Date)]
        public DateTime? TglKembali { get; set; }
        public string Kembali { get; set; }
        public string KodeBuku1 { get; set; }
        public string Nip1 { get; set; }
        public string NoKtp1 { get; set; }

        [NotMapped]
        public List<Anggota> anggotaCollection {get; set;}
        [NotMapped]
        public List<Buku> bukuCollection {get; set;}
        [NotMapped]
        public List<Pegawai> pegawaiCollection {get; set;}

        public virtual Buku KodeBuku1Navigation { get; set; }
        public virtual Pegawai Nip1Navigation { get; set; }
        public virtual Anggota NoKtp1Navigation { get; set; }
    }
}
