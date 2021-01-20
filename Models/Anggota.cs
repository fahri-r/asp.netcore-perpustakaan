using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Perpustakaan.Models
{
    public class Anggota
    {
        public Anggota()
        {
        }

        [Display(Name = "No. KTP")]
        public string NoKTP { get; set; }

        [Display(Name = "Nama Lengkap")]
        public string NamaLengkap { get; set; }

        [Display(Name = "Alamat")]
        public string Alamat { get; set; }

        [Display(Name = "No. Handphone")]
        public string NoHP { get; set; }
        public virtual User IdUser { get; set; }
    }
}
