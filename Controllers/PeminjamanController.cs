using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Collections.Generic;
using Perpustakaan.ViewModels;
using Perpustakaan.Models;

namespace Perpustakaan.Controllers
{
    public class PeminjamanController : Controller
    {
        List<Pinjam> pinjam = new List<Pinjam>();
        List<Anggota> anggota = new List<Anggota>();
        List<Pegawai> pegawai = new List<Pegawai>();
        List<Buku> buku = new List<Buku>();
        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("UserId") == null){
                return RedirectToAction("Index", "Login");
            }

            var peminjamanViewModel = from p in pinjam
                                    join a in anggota on p.NoKtp1 equals a.NoKtp
                                    join pe in pegawai on p.Nip1 equals pe.Nip
                                    join b in buku on p.KodeBuku1 equals b.KodeBuku
                                    select new PeminjamanVM { pinjamVm = p, anggotaVm = a, pegawaiVm = pe, bukuVm = b };

            return View(peminjamanViewModel);
        }
    }
}