using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Perpustakaan.Models
{
    public partial class Pegawai
    {
        public Pegawai()
        {
            Pinjam = new HashSet<Pinjam>();
        }

        [Display(Name = "NIP")]
        [MinLength(16)]
        public string Nip { get; set; }
        [Display(Name = "Nama Pegawai")]
        public string NamaPegawai { get; set; }
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
