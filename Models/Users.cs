using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Perpustakaan.Models
{
    public partial class Users
    {
        public Users()
        {
            Anggota = new HashSet<Anggota>();
            Pegawai = new HashSet<Pegawai>();
        }

        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        [NotMapped]
        [Display(Name = "Konfirmasi Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public int? IdTypeId { get; set; }

        public virtual Usertype IdType { get; set; }
        public virtual ICollection<Anggota> Anggota { get; set; }
        public virtual ICollection<Pegawai> Pegawai { get; set; }
    }
}
