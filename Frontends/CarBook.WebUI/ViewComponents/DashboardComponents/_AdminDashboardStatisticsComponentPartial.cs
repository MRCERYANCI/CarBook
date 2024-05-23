using CarBook.DtoLayer.Dtos.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
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

            #region GetLocationCount
            var responseGetLocationCountMessage = await client.GetAsync("https://localhost:7125/api/Statistics/GetLocationCount");
            if (responseGetLocationCountMessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var GetLocationCountjsondata = await responseGetLocationCountMessage.Content.ReadAsStringAsync();//Bu veri json trü
                var GetLocationCountvalues = JsonConvert.DeserializeObject<ResultStatisticsDto>(GetLocationCountjsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
                ViewBag.LocationCount = GetLocationCountvalues.locationCount;
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

            #region GetAvgRentPriceForDaily
            var responseGetAvgRentPriceForDailyMessage = await client.GetAsync("https://localhost:7125/api/Statistics/GetAvgRentPriceForDaily");
            if (responseGetAvgRentPriceForDailyMessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var GetAvgRentPriceForDailyjsondata = await responseGetAvgRentPriceForDailyMessage.Content.ReadAsStringAsync();//Bu veri json trü
                var GetAvgRentPriceForDailyvalues = JsonConvert.DeserializeObject<ResultStatisticsDto>(GetAvgRentPriceForDailyjsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
                ViewBag.AvgRentPriceForDailyCount = GetAvgRentPriceForDailyvalues.getAvgPriceForDaily.ToString("C");
            }
            #endregion

          
            return View();
        }
    }
}
