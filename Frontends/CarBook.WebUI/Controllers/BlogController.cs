using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.MainCover = "BLOGLAR";
            return View();
        }

        public IActionResult BlogDetail(int BlogId)
        {
            ViewBag.MainCover = "Blog Detayları";
            ViewBag.BlogId = BlogId;
            return View();
        }
    }
}
