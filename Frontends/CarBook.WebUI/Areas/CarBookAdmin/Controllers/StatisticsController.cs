using CarBook.DtoLayer.Dtos.AuthorDtos;
using CarBook.DtoLayer.Dtos.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.CarBookAdmin.Controllers
{
    [Area("CarBookAdmin")]
    [Route("CarBookAdmin/Statistics")]
    public class StatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
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

            #region GetAuthorCount
            var responseGetAuthorCountMessage = await client.GetAsync("https://localhost:7125/api/Statistics/GetAuthorCount");
            if (responseGetAuthorCountMessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var GetAuthorCountjsondata = await responseGetAuthorCountMessage.Content.ReadAsStringAsync();//Bu veri json trü
                var GetAuthorCountvalues = JsonConvert.DeserializeObject<ResultStatisticsDto>(GetAuthorCountjsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
                ViewBag.AuthorCount = GetAuthorCountvalues.authorCount;
            }
            #endregion

            #region GetBlogCount
            var responseGetBlogCountMessage = await client.GetAsync("https://localhost:7125/api/Statistics/GetBlogCount");
            if (responseGetBlogCountMessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var GetBlogCountjsondata = await responseGetBlogCountMessage.Content.ReadAsStringAsync();//Bu veri json trü
                var GetBlogCountvalues = JsonConvert.DeserializeObject<ResultStatisticsDto>(GetBlogCountjsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
                ViewBag.BlogCount = GetBlogCountvalues.blogCount;
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
