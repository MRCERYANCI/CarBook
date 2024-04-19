using CarBook.DtoLayer.Dtos.AuthorDtos;
using CarBook.DtoLayer.Dtos.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsParagraphComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailsParagraphComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int BlogId)
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync($"https://localhost:7125/api/Blog/{BlogId}");
            if (responsemessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();//Bu veri json trü
                var values = JsonConvert.DeserializeObject<ResultBlogDto>(jsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır

                if (values != null)
                {
                    var AuthorResponseMessage = await client.GetAsync($"https://localhost:7125/api/Author/{values.AuthorId}");
                    if (AuthorResponseMessage.IsSuccessStatusCode)
                    {
                        var jsondata1 = await AuthorResponseMessage.Content.ReadAsStringAsync();//Bu veri json trü
                        var values1 = JsonConvert.DeserializeObject<ResultAuthorDto>(jsondata1); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
                        return View(values1);
                    }
                }

            }
            return View();
        }
    }
}
