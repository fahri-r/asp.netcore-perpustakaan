using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

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
        public string Password { get; set; }
        public int? IdTypeId { get; set; }

        public virtual Usertype IdType { get; set; }
        public virtual ICollection<Anggota> Anggota { get; set; }
        public virtual ICollection<Pegawai> Pegawai { get; set; }
    }
}
