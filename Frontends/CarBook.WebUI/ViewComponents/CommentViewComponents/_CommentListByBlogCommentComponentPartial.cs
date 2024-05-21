using CarBook.DtoLayer.Dtos.CommentDtos;
using CarBook.DtoLayer.Dtos.TagCloudDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.CommentViewComponents
{
    public class _CommentListByBlogCommentComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CommentListByBlogCommentComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int BlogId)
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync($"https://localhost:7125/api/Comment/BlogListByBlogId?BlogId={BlogId}");
            var responseCommentCountMessage = await client.GetAsync($"https://localhost:7125/api/Comment/GetCountCommentBlog?BlogId={BlogId}");
            if (responsemessage.IsSuccessStatusCode && responseCommentCountMessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var commentCountJson = await responseCommentCountMessage.Content.ReadAsStringAsync();
                ViewBag.CommentCount = JsonConvert.DeserializeObject<int>(commentCountJson);

                var jsondata = await responsemessage.Content.ReadAsStringAsync();//Bu veri json trü
                var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
                return View(values);
            }
            return View();
        }
    }
}
