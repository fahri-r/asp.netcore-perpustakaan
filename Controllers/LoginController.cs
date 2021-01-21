using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Perpustakaan.Data;

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
                    return Redirect("/peminjaman");
                }
            }
        }
    }
}