using Perpustakaan.Models;

namespace Perpustakaan.ViewModels
{
    public class PeminjamanVM
    {
        public Pinjam pinjamVm { get; set; }
        public Buku bukuVm { get; set; }
        public Anggota anggotaVm { get; set; }
        public Pegawai pegawaiVm { get; set; }
    }
}