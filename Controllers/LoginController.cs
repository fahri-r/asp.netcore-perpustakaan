using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace Perpustakaan.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}