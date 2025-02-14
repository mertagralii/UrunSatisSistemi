using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace UrunSatisSistemi.Controllers
{
    public class EditorController : Controller
    {
        private readonly IDbConnection _connection;

        public EditorController(IDbConnection connection)
        {
            _connection = connection;
        }

        public IActionResult Editor()
        {
            return View();
        }
    }
}
