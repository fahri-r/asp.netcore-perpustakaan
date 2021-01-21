using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Perpustakaan.Models
{
    public partial class Anggota
    {
        public Anggota()
        {
            Pinjam = new HashSet<Pinjam>();
        }

        public string NoKtp { get; set; }
        public string NamaLengkap { get; set; }
        public string Alamat { get; set; }
        public string NoHp { get; set; }
        public int? IdUserId { get; set; }

        public virtual Users IdUser { get; set; }
        public virtual ICollection<Pinjam> Pinjam { get; set; }
    }
}
