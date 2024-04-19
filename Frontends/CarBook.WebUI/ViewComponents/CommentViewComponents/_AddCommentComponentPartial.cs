using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.CommentViewComponents
{
    public class _AddCommentComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke(int BlogId)
        {
            ViewBag.BlogId = BlogId;
            return View();
        }
    }
}
