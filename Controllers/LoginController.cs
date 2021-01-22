using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Perpustakaan.Data;
using Microsoft.AspNetCore.Http;

namespace Perpustakaan.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Authorize(Perpustakaan.Models.Users userModel)
        {
            using(ApplicationDbContext db = new ApplicationDbContext()){
                var userDetails = db.Users.Where(x => x.Email == userModel.Email && x.Password == userModel.Password).FirstOrDefault();
                if(userDetails == null)
                {
                    return View("Index");
                }
                else{
                    HttpContext.Session.SetString("UserId", userDetails.Email);
                    return RedirectToAction("Index", "Peminjaman");
                }
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserId");
            return RedirectToAction("Index", "Login");
        }
    }
}