using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Perpustakaan.Data;
using Microsoft.AspNetCore.Http;
using Perpustakaan.ViewModels;
using Perpustakaan.Models;
using System.Linq;

namespace Perpustakaan.Controllers
{
    public class PegawaiController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PegawaiController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            if(HttpContext.Session.GetString("UserId") == null){
                return RedirectToAction("Index", "Login");
            }
            return View(await _context.Pegawai.ToListAsync());
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
        public async Task<IActionResult> Create(PegawaiUsersVM obj)
        {
             if (ModelState.IsValid)
             {
                Users u = new Users();
                u.Email = obj.usersVm.Email;
                u.Password = obj.usersVm.Password;
                u.IdTypeId = 2;
                _context.Users.Add(u);
                _context.SaveChanges();

                Pegawai p = new Pegawai();
                p.Alamat = obj.pegawaiVm.Alamat;
                p.NoHp = obj.pegawaiVm.NoHp;
                p.Nip = obj.pegawaiVm.Nip;
                p.NamaPegawai = obj.pegawaiVm.NamaPegawai;
                p.IdUserId = u.Id;
                _context.Pegawai.Add(p);
                _context.SaveChanges();
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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

            var pegawai = await _context.Pegawai
                .FirstOrDefaultAsync(m => m.Nip == id);
            
            if (pegawai == null)
            {
                return NotFound();
            }

            return View(pegawai);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var idUsers= _context.Pegawai.Where(u => u.Nip == id).Select(u => u.IdUserId).FirstOrDefault();
            var users = await _context.Users.FindAsync(idUsers);
            _context.Users.Remove(users);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Pegawai");
        }

        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pegawai = await _context.Pegawai.FindAsync(id);
            if (pegawai == null)
            {
                return NotFound();
            }
            return View(pegawai);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Pegawai pegawai)
        {
            if (id != pegawai.Nip)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pegawai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PegawaiExists(pegawai.Nip))
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
            return View(pegawai);
        }
        private bool PegawaiExists(string id)
        {
            return _context.Pegawai.Any(e => e.Nip == id);
        }
    }
}