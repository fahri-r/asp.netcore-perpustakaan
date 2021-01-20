using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Perpustakaan.Models
{
    public class Buku
    {
        public Buku()
        {
        }
        
        [Display(Name = "Kode Buku")]
        public string KodeBuku { get; set; }

        [Display(Name = "Judul Buku")]
        public string JudulBuku { get; set; }

        [Display(Name = "Penerbit")]
        public string Penerbit { get; set; }

        [Display(Name = "Pengarang")]
        public string Pengarang { get; set; }

        [Display(Name = "Tahun Terbit")]
        public short ThnTerbit { get; set; }
    }
}
