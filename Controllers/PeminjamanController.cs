using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Collections.Generic;
using Perpustakaan.ViewModels;
using Perpustakaan.Models;
using Perpustakaan.Data;

namespace Perpustakaan.Controllers
{
    public class PeminjamanController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PeminjamanController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {   
            if(HttpContext.Session.GetString("UserId") == null){
                return RedirectToAction("Index", "Login");
            }

                List<Pinjam> pinjam = _context.Pinjam.ToList();  
                List<Anggota> anggota = _context.Anggota.ToList();  
                List<Buku> buku = _context.Buku.ToList();    
                List<Pegawai> pegawai = _context.Pegawai.ToList();  
  
                var peminjamanVm = from p in pinjam
                                        join a in anggota on p.NoKtp1 equals a.NoKtp
                                        join pe in pegawai on p.Nip1 equals pe.Nip
                                        join b in buku on p.KodeBuku1 equals b.KodeBuku
                                        select new PeminjamanVM { pinjamVm = p, anggotaVm = a, pegawaiVm = pe, bukuVm = b };

                return View(peminjamanVm);  
        }
    }
}