using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace asp.netcore_perpustakaan.Controllers
{
    public class PeminjamanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}