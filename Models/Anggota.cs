using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Perpustakaan.Models
{
    public partial class Anggota
    {
        public Anggota()
        {
            Pinjam = new HashSet<Pinjam>();
        }

        [Display(Name = "No. KTP")]
        [MinLength(16)]
        public string NoKtp { get; set; }
        [Display(Name = "Nama Anggota")]
        public string NamaLengkap { get; set; }
        [MinLength(20)]
        public string Alamat { get; set; }
        [Display(Name = "No. Handphone")]
        [Required]
        public string NoHp { get; set; }
        public int? IdUserId { get; set; }

        public virtual Users IdUser { get; set; }
        public virtual ICollection<Pinjam> Pinjam { get; set; }
    }
}
