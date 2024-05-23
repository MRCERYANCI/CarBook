using CarBook.DtoLayer.Dtos.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardStatisticChart3ComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardStatisticChart3ComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            #region GetBlogCount
            var responseGetBlogCountMessage = await client.GetAsync("https://localhost:7125/api/Statistics/GetBlogCount");
            if (responseGetBlogCountMessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var GetBlogCountjsondata = await responseGetBlogCountMessage.Content.ReadAsStringAsync();//Bu veri json trü
                var GetBlogCountvalues = JsonConvert.DeserializeObject<ResultStatisticsDto>(GetBlogCountjsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
                ViewBag.BlogCount = GetBlogCountvalues.blogCount;
            }
            #endregion

            #region GetLocationCount
            var responseGetLocationCountMessage = await client.GetAsync("https://localhost:7125/api/Statistics/GetLocationCount");
            if (responseGetLocationCountMessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var GetLocationCountjsondata = await responseGetLocationCountMessage.Content.ReadAsStringAsync();//Bu veri json trü
                var GetLocationCountvalues = JsonConvert.DeserializeObject<ResultStatisticsDto>(GetLocationCountjsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
                ViewBag.LocationCount = GetLocationCountvalues.locationCount;
            }
            #endregion

            return View();
        }
    }
}
