using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Perpustakaan.Models
{
    public partial class Pegawai
    {
        public Pegawai()
        {
            Pinjam = new HashSet<Pinjam>();
        }

        public string Nip { get; set; }
        public string NamaPegawai { get; set; }
        public string Alamat { get; set; }
        public string NoHp { get; set; }
        public int? IdUserId { get; set; }

        public virtual Users IdUser { get; set; }
        public virtual ICollection<Pinjam> Pinjam { get; set; }
    }
}
