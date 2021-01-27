using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Perpustakaan.Data;
using Perpustakaan.ViewModels;
using Perpustakaan.Models;
using System.Linq;

namespace Perpustakaan.Controllers
{
    public class AnggotaController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AnggotaController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            if(HttpContext.Session.GetString("UserId") == null){
                return RedirectToAction("Index", "Login");
            }
            return View(await _context.Anggota.ToListAsync());
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
        public async Task<IActionResult> Create(AnggotaUsersVM obj)
        {
             if (ModelState.IsValid)
             {
                Users u = new Users();
                u.Email = obj.usersVm.Email;
                u.Password = obj.usersVm.Password;
                u.IdTypeId = 1;
                _context.Users.Add(u);
                _context.SaveChanges();

                Anggota a = new Anggota();
                a.Alamat = obj.anggotaVm.Alamat;
                a.NoHp = obj.anggotaVm.NoHp;
                a.NoKtp = obj.anggotaVm.NoKtp;
                a.NamaLengkap = obj.anggotaVm.NamaLengkap;
                a.IdUserId = u.Id;
                _context.Anggota.Add(a);
                _context.SaveChanges();
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }   
            return View("Create");
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

            var anggota = await _context.Anggota
                .FirstOrDefaultAsync(m => m.NoKtp == id);
            
            if (anggota == null)
            {
                return NotFound();
            }

            return View(anggota);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var idUsers= _context.Anggota.Where(u => u.NoKtp == id).Select(u => u.IdUserId).FirstOrDefault();
            var users = await _context.Users.FindAsync(idUsers);
            _context.Users.Remove(users);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Anggota");
        }

        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anggota = await _context.Anggota.FindAsync(id);
            if (anggota == null)
            {
                return NotFound();
            }
            return View(anggota);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Anggota anggota)
        {
            if (id != anggota.NoKtp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anggota);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnggotaExists(anggota.NoKtp))
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
            return View(anggota);
        }
        private bool AnggotaExists(string id)
        {
            return _context.Anggota.Any(e => e.NoKtp == id);
        }
    }
}