using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace asp.netcore_perpustakaan.Controllers
{
    public class BukuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}