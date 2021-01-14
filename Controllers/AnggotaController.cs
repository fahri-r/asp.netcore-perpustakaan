using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace asp.netcore_perpustakaan.Controllers
{
    public class AnggotaController : Controller
    {
        public string Index()
        {
            return "This is my default action...";
        }

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}