using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Perpustakaan.Data;

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
            return View();
        }
    }
}