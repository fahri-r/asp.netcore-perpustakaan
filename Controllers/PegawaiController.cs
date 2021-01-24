using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Perpustakaan.Data;
using Microsoft.AspNetCore.Http;
using Perpustakaan.ViewModels;
using Perpustakaan.Models;

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
                return RedirectToAction("Index", "Pegawai");
            }   
            return View("Index");
        }
    }
}