using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Perpustakaan.Data;
using Perpustakaan.ViewModels;
using Perpustakaan.Models;

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
                return RedirectToAction("Index", "Anggota");
            }   
            return RedirectToAction("Index");
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
            var anggota = await _context.Anggota.FindAsync(id);
            _context.Anggota.Remove(anggota);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Anggota");
        }
    }
}