using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Perpustakaan.Data;

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
            return View(await _context.Anggota.ToListAsync());
        }
    }
}