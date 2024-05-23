using CarBook.DtoLayer.Dtos.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DashboardComponents
{
    public class AdminDashboardStatisticChart2ComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminDashboardStatisticChart2ComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            #region GetCarCount
            var responseGetCarCountMessage = await client.GetAsync("https://localhost:7125/api/Statistics/GetCarCount");
            if (responseGetCarCountMessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var GetCarCountjsondata = await responseGetCarCountMessage.Content.ReadAsStringAsync();//Bu veri json trü
                var GetCarCountvalues = JsonConvert.DeserializeObject<ResultStatisticsDto>(GetCarCountjsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
                ViewBag.CarCount = GetCarCountvalues.carCount;
            }
            #endregion

            #region GetBrandCount
            var responseGetBrandCountMessage = await client.GetAsync("https://localhost:7125/api/Statistics/GetBrandCount");
            if (responseGetBrandCountMessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var GetBrandCountjsondata = await responseGetBrandCountMessage.Content.ReadAsStringAsync();//Bu veri json trü
                var GetBrandCountvalues = JsonConvert.DeserializeObject<ResultStatisticsDto>(GetBrandCountjsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
                ViewBag.BrandCount = GetBrandCountvalues.brandCount;
            }
            #endregion

            return View();
        }
    }
}
