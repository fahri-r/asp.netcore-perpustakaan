using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Perpustakaan.Data;
using Microsoft.AspNetCore.Http;

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
    }
}