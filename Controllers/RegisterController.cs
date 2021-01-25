using Microsoft.AspNetCore.Mvc;
using Perpustakaan.ViewModels;
using Perpustakaan.Models;
using Perpustakaan.Data;
using System.Threading.Tasks;

namespace Perpustakaan.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegisterController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(AnggotaUsersVM obj)
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
                return RedirectToAction("Index", "Login");
            }   
            return View("Index");
        }
    }
}