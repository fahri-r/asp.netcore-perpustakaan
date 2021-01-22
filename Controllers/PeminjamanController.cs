using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Http;

namespace Perpustakaan.Controllers
{
    public class PeminjamanController : Controller
    {
        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("UserId") == null){
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}