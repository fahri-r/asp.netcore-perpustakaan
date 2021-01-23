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
        public async Task<IActionResult> Index(AnggotaUsersVM obj)
        {
             if (ModelState.IsValid)
             {
                Users u = new Users();
                u.Email = obj.Email;
                u.Password = obj.Password;
                u.IdTypeId = 1;
                _context.Users.Add(u);
                _context.SaveChanges();

                Anggota a = new Anggota();
                a.Alamat = obj.Alamat;
                a.NoHp = obj.NoHp;
                a.NoKtp = obj.NoKtp;
                a.NamaLengkap = obj.NamaLengkap;
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