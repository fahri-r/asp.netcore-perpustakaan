using System;
using System.Collections.Generic;

#nullable disable

namespace Perpustakaan.Models
{
    public partial class Pegawai
    {
        public Pegawai()
        {
        }

        public string Nip { get; set; }
        public string NamaPegawai { get; set; }
        public virtual User IdUser { get; set; }
    }
}
