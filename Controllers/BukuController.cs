using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Perpustakaan.Data;
using Perpustakaan.Models;
using System.Linq;

namespace Perpustakaan.Controllers
{
    public class BukuController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BukuController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            if(HttpContext.Session.GetString("UserId") == null){
                return RedirectToAction("Index", "Login");
            }
            return View(await _context.Buku.ToListAsync());
        }

        public IActionResult Create()
        {
            if(HttpContext.Session.GetString("UserId") == null){
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Buku obj)
        {
             if (ModelState.IsValid)
             {
                 Buku b = new Buku();
                 b.KodeBuku = obj.KodeBuku;
                 b.JudulBuku = obj.JudulBuku;
                 b.Penerbit = obj.Penerbit;
                 b.Pengarang = obj.Pengarang;
                 b.ThnTerbit = obj.ThnTerbit;
                _context.Buku.Add(b);
                _context.SaveChanges();
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Buku");
            }   
            return View("Index");
        }

        public async Task<IActionResult> Delete(string? id)
        {
            if(HttpContext.Session.GetString("UserId") == null){
                return RedirectToAction("Index", "Login");
            }
            
            if (id == null)
            {
                return NotFound();
            }

            var buku = await _context.Buku
                .FirstOrDefaultAsync(m => m.KodeBuku == id);
            if (buku == null)
            {
                return NotFound();
            }

            return View(buku);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var buku = await _context.Buku.FindAsync(id);
            _context.Buku.Remove(buku);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Buku");
        }

        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buku = await _context.Buku.FindAsync(id);
            if (buku == null)
            {
                return NotFound();
            }
            return View(buku);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Buku buku)
        {
            if (id != buku.KodeBuku)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buku);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BukuExists(buku.KodeBuku))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(buku);
        }
        private bool BukuExists(string id)
        {
            return _context.Buku.Any(e => e.KodeBuku == id);
        }
    }
}