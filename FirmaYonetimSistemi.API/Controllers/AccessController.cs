using Microsoft.AspNetCore.Mvc;

namespace FirmaYonetimSistemi.API.Views
{
    public class AccessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
