using System.ComponentModel.DataAnnotations;

namespace Perpustakaan.ViewModels
{
    public  class AnggotaUsersVM
    {
        [MinLength(16)]
        public string NoKtp { get; set; }
        public string NamaLengkap { get; set; }
        [MinLength(20)]
        public string Alamat { get; set; }
        public string NoHp { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
