using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
