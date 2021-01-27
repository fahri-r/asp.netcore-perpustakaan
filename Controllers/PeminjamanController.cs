using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Perpustakaan.ViewModels;
using Perpustakaan.Models;
using Perpustakaan.Data;
using System.Threading.Tasks;
using System.Linq;

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
        
        public IActionResult Create()
        {
            

            Pinjam pinjamModel = new Pinjam();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                pinjamModel.anggotaCollection = db.Anggota.ToList<Anggota>();
                pinjamModel.bukuCollection = db.Buku.ToList<Buku>();
                pinjamModel.pegawaiCollection = db.Pegawai.ToList<Pegawai>();
            }
            
            return View(pinjamModel);
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pinjam obj)
        {
             if (ModelState.IsValid)
             {
                 Pinjam p = new Pinjam();
                 p.TglPinjam = obj.TglPinjam;
                 p.TglKembali = obj.TglKembali;
                 p.Kembali = "0";
                 p.KodeBuku1 = obj.KodeBuku1;
                 p.Nip1 = obj.Nip1;
                 p.NoKtp1 = obj.NoKtp1;
                _context.Pinjam.Add(p);
                _context.SaveChanges();
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Peminjaman");
            }   
            return View("Create");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if(HttpContext.Session.GetString("UserId") == null){
                return RedirectToAction("Index", "Login");
            }
            if (id == null)
            {
                return NotFound();
            }
            
            var pinjam = _context.Pinjam
                .FirstOrDefault(m => m.Id == id);

            if (pinjam == null)
            {
                return NotFound();
            }
            return View(pinjam);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pinjam = await _context.Pinjam.FindAsync(id);
            _context.Pinjam.Remove(pinjam);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Peminjaman");
        }
    }
}