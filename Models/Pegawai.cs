﻿using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Perpustakaan.Models
{
    public class Pegawai
    {
        public Pegawai()
        {
        }

        [Display(Name = "NIP")]
        public string Nip { get; set; }

        [Display(Name = "Nama Lengkap")]
        public string NamaPegawai { get; set; }
        
        [Display(Name = "Alamat")]
        public string Alamat { get; set; }

        [Display(Name = "No. Handphone")]
        public string NoHP { get; set; }
        public virtual User IdUser { get; set; }
    }
}