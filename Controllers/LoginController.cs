using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace asp.netcore_perpustakaan.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}