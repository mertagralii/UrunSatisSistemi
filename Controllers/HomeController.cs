using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UrunSatisSistemi.Models;

namespace UrunSatisSistemi.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }

      

        
    }
}
