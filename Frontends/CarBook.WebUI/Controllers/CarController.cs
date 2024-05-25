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

        public async Task<IActionResult> CarDetail(int id)
        {
            ViewBag.MainCover = "ARAÇ DETAYLARI ";
            ViewBag.CarId = id;
            return View();
        }

    }
}
