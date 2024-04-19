using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.MainCover = "ARABALARIMIZ";
            return View();
        }
    }
}
