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

            #region GetAvgRentPriceForDaily
            var responseGetAvgRentPriceForDailyMessage = await client.GetAsync("https://localhost:7125/api/Statistics/GetAvgRentPriceForDaily");
            if (responseGetAvgRentPriceForDailyMessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var GetAvgRentPriceForDailyjsondata = await responseGetAvgRentPriceForDailyMessage.Content.ReadAsStringAsync();//Bu veri json trü
                var GetAvgRentPriceForDailyvalues = JsonConvert.DeserializeObject<ResultStatisticsDto>(GetAvgRentPriceForDailyjsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
                ViewBag.AvgRentPriceForDailyCount = GetAvgRentPriceForDailyvalues.getAvgPriceForDaily.ToString("C");
            }
            #endregion

            #region GetAvgRentPriceForWeekly
            var responseGetAvgRentPriceForWeeklyMessage = await client.GetAsync("https://localhost:7125/api/Statistics/GetAvgRentPriceForWeekly");
            if (responseGetAvgRentPriceForWeeklyMessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var GetAvgRentPriceForWeeklyjsondata = await responseGetAvgRentPriceForWeeklyMessage.Content.ReadAsStringAsync();//Bu veri json trü
                var GetAvgRentPriceForWeeklyvalues = JsonConvert.DeserializeObject<ResultStatisticsDto>(GetAvgRentPriceForWeeklyjsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
                ViewBag.AvgRentPriceForWeekly = GetAvgRentPriceForWeeklyvalues.avgRentPriceForWeekly.ToString("C");
            }
            #endregion

            #region GetAvgRentPriceForMonthly
            var responseGetAvgRentPriceForMonthlyMessage = await client.GetAsync("https://localhost:7125/api/Statistics/GetAvgRentPriceForMonthly");
            if (responseGetAvgRentPriceForMonthlyMessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var GetAvgRentPriceForMonthlyjsondata = await responseGetAvgRentPriceForMonthlyMessage.Content.ReadAsStringAsync();//Bu veri json trü
                var GetAvgRentPriceForMonthlyvalues = JsonConvert.DeserializeObject<ResultStatisticsDto>(GetAvgRentPriceForMonthlyjsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
                ViewBag.AvgRentPriceForMonthly = GetAvgRentPriceForMonthlyvalues.avgRentPriceForMonthly.ToString("C");
            }
            #endregion

            #region GetCarCountByTranmissionIsAuto
            var responseGetCarCountByTranmissionIsAutoMessage = await client.GetAsync("https://localhost:7125/api/Statistics/GetCarCountByTranmissionIsAuto");
            if (responseGetCarCountByTranmissionIsAutoMessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var GetCarCountByTranmissionIsAutojsondata = await responseGetCarCountByTranmissionIsAutoMessage.Content.ReadAsStringAsync();//Bu veri json trü
                var GetCarCountByTranmissionIsAutovalues = JsonConvert.DeserializeObject<ResultStatisticsDto>(GetCarCountByTranmissionIsAutojsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
                ViewBag.CarCountByTranmissionIsAuto = GetCarCountByTranmissionIsAutovalues.carCountByTranmissionIsAuto;
            }
            #endregion

            #region GetCarCountByKmSmallerThen1000
            var responseGetCarCountByKmSmallerThen1000Message = await client.GetAsync("https://localhost:7125/api/Statistics/GetCarCountByKmSmallerThen1000");
            if (responseGetCarCountByKmSmallerThen1000Message.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var GetCarCountByKmSmallerThen1000jsondata = await responseGetCarCountByKmSmallerThen1000Message.Content.ReadAsStringAsync();//Bu veri json trü
                var GetCarCountByKmSmallerThen1000values = JsonConvert.DeserializeObject<ResultStatisticsDto>(GetCarCountByKmSmallerThen1000jsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
                ViewBag.CarCountByKmSmallerThen1000 = GetCarCountByKmSmallerThen1000values.carCountByKmSmallerThen1000;
            }
            #endregion

            #region GetCarCountByFuelGasolineOrDiesel
            var responseGetCarCountByFuelGasolineOrDieselMessage = await client.GetAsync("https://localhost:7125/api/Statistics/GetCarCountByFuelGasolineOrDiesel");
            if (responseGetCarCountByFuelGasolineOrDieselMessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var GetCarCountByFuelGasolineOrDieseljsondata = await responseGetCarCountByFuelGasolineOrDieselMessage.Content.ReadAsStringAsync();//Bu veri json trü
                var GetCarCountByFuelGasolineOrDieselvalues = JsonConvert.DeserializeObject<ResultStatisticsDto>(GetCarCountByFuelGasolineOrDieseljsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
                ViewBag.CarCountByFuelGasolineOrDieselvalues = GetCarCountByFuelGasolineOrDieselvalues.carCountByFuelGasolineOrDiesel;
            }
            #endregion

            #region GetCarCountByFuelElectric
            var responseGetCarCountByFuelElectricMessage = await client.GetAsync("https://localhost:7125/api/Statistics/GetCarCountByFuelElectric");
            if (responseGetCarCountByFuelElectricMessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var GetCarCountByFuelElectricjsondata = await responseGetCarCountByFuelElectricMessage.Content.ReadAsStringAsync();//Bu veri json trü
                var GetCarCountByFuelElectricvalues = JsonConvert.DeserializeObject<ResultStatisticsDto>(GetCarCountByFuelElectricjsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
                ViewBag.CarCountByFuelElectricvalues = GetCarCountByFuelElectricvalues.carCountByFuelElectric;
            }
            #endregion

            #region GetCarBrandAndModelByRentPriceDailyMax
            var responseGetCarBrandAndModelByRentPriceDailyMaxMessage = await client.GetAsync("https://localhost:7125/api/Statistics/GetCarBrandAndModelByRentPriceDailyMax");
            if (responseGetCarBrandAndModelByRentPriceDailyMaxMessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var GetCarBrandAndModelByRentPriceDailyMaxjsondata = await responseGetCarBrandAndModelByRentPriceDailyMaxMessage.Content.ReadAsStringAsync();//Bu veri json trü
                var GetCarBrandAndModelByRentPriceDailyMaxvalues = JsonConvert.DeserializeObject<ResultStatisticsDto>(GetCarBrandAndModelByRentPriceDailyMaxjsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
                ViewBag.GetCarBrandAndModelByRentPriceDailyMax = GetCarBrandAndModelByRentPriceDailyMaxvalues.carBrandAndModelByRentPriceDailyMax;
            }
            #endregion

            #region GetCarBrandAndModelByRentPriceDailyMin
            var responseGetCarBrandAndModelByRentPriceDailyMinMessage = await client.GetAsync("https://localhost:7125/api/Statistics/GetCarBrandAndModelByRentPriceDailyMin");
            if (responseGetCarBrandAndModelByRentPriceDailyMinMessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var GetCarBrandAndModelByRentPriceDailyMinjsondata = await responseGetCarBrandAndModelByRentPriceDailyMinMessage.Content.ReadAsStringAsync();//Bu veri json trü
                var GetCarBrandAndModelByRentPriceDailyMinvalues = JsonConvert.DeserializeObject<ResultStatisticsDto>(GetCarBrandAndModelByRentPriceDailyMinjsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
                ViewBag.GetCarBrandAndModelByRentPriceDailyMin = GetCarBrandAndModelByRentPriceDailyMinvalues.carBrandAndModelByRentPriceDailyMin;
            }
            #endregion

            #region GetBrandNameByMaxCar
            var responseGetBrandNameByMaxCarMessage = await client.GetAsync("https://localhost:7125/api/Statistics/GetBrandNameByMaxCar");
            if (responseGetBrandNameByMaxCarMessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var GetBrandNameByMaxCarjsondata = await responseGetBrandNameByMaxCarMessage.Content.ReadAsStringAsync();//Bu veri json trü
                var GetBrandNameByMaxCarvalues = JsonConvert.DeserializeObject<ResultStatisticsDto>(GetBrandNameByMaxCarjsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
                ViewBag.GetBrandNameByMaxCarvalues = GetBrandNameByMaxCarvalues.brandNameByMaxCar;
            }
            #endregion

            #region GetBlogTitleByMaxBlogComment
            var responseGetBlogTitleByMaxBlogCommentMessage = await client.GetAsync("https://localhost:7125/api/Statistics/GetBlogTitleByMaxBlogComment");
            if (responseGetBlogTitleByMaxBlogCommentMessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var GetBlogTitleByMaxBlogCommentjsondata = await responseGetBlogTitleByMaxBlogCommentMessage.Content.ReadAsStringAsync();//Bu veri json trü
                var GetBlogTitleByMaxBlogCommentvalues = JsonConvert.DeserializeObject<ResultStatisticsDto>(GetBlogTitleByMaxBlogCommentjsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
                if (GetBlogTitleByMaxBlogCommentvalues.blogTitleByMaxBlogComment.Length > 20)
                {
                    ViewBag.GetBlogTitleByMaxBlogCommentvalues = GetBlogTitleByMaxBlogCommentvalues.blogTitleByMaxBlogComment.Substring(0, 20) + "...";
                    ViewBag.GetBlogTitleByMaxBlogCommentvalues1 = GetBlogTitleByMaxBlogCommentvalues.blogTitleByMaxBlogComment;
                }
                else
                    ViewBag.GetBlogTitleByMaxBlogCommentvalues = GetBlogTitleByMaxBlogCommentvalues.blogTitleByMaxBlogComment;


            }
            #endregion
            return View();
        }
    }
}
