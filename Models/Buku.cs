using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Perpustakaan.Models
{
    public partial class Buku
    {
        public Buku()
        {
            Pinjam = new HashSet<Pinjam>();
        }

        public string KodeBuku { get; set; }
        public string JudulBuku { get; set; }
        public string Penerbit { get; set; }
        public string Pengarang { get; set; }
        public short ThnTerbit { get; set; }

        public virtual ICollection<Pinjam> Pinjam { get; set; }
    }
}
