using System;
using System.Collections.Generic;

#nullable disable

namespace Perpustakaan.Models
{
    public partial class Mahasiswa
    {
        public Mahasiswa()
        {
        }

        public string Npm { get; set; }
        public string NamaMahasiswa { get; set; }
        public string Jurusan { get; set; }
        public string Kelas { get; set; }
        public virtual User IdUser { get; set; }
    }
}
