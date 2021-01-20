using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            return View(await _context.Buku.ToListAsync());
        }
    }
}