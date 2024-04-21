using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.CarBookAdmin.Controllers
{
    [Area("CarBookAdmin")]
    [Route("CarBookAdmin/Statistics")]
    public class StatisticsController : Controller
    {

        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
