using System;
using System.Collections.Generic;

#nullable disable

namespace Perpustakaan.Models
{
    public partial class Buku
    {
        public Buku()
        {
        }

        public string KodeBuku { get; set; }
        public string JudulBuku { get; set; }
        public string Penerbit { get; set; }
        public string Pengarang { get; set; }
        public short ThnTerbit { get; set; }
    }
}
