using CarBook.DtoLayer.Dtos.AuthorDtos;
using CarBook.DtoLayer.Dtos.CarDtos;
using CarBook.DtoLayer.Dtos.CarFeatures;
using CarBook.DtoLayer.Dtos.CarFeaturesDtos;
using CarBook.DtoLayer.Dtos.CategoryDtos;
using CarBook.DtoLayer.Dtos.FeatureDtos;
using CarBook.DtoLayer.Dtos.ReviewDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.CarBookAdmin.Controllers
{
    [Area("CarBookAdmin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class CarDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> CarFeatureDetail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync($"https://localhost:7125/api/CarFeatures/{id}");
            if (responsemessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();//Bu veri json trü
                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureDto>>(jsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CarFeatureDetail(List<ResultCarFeatureDto> resultCarFeatureDto)
        {

            foreach(var item in resultCarFeatureDto)
            {
                if (item.Available)
                {
                    var client = _httpClientFactory.CreateClient();//İstemciyi Oluştruduk             
                    var responseMessage = await client.GetAsync($"https://localhost:7125/api/CarFeatures/CarFeatureChangeAvaliableTrue/{item.CarFeatureId}");
                    if (responseMessage.IsSuccessStatusCode)//Eğer istek attığımız apiden(responsemessage) 200-299 arası durum kodu dönerse
                    {
                        continue;
                    }
                }
                else
                {
                    var client = _httpClientFactory.CreateClient();//İstemciyi Oluştruduk             
                    var responseMessage = await client.GetAsync($"https://localhost:7125/api/CarFeatures/CarFeatureChangeAvaliableFalse/{item.CarFeatureId}");
                    if (responseMessage.IsSuccessStatusCode)//Eğer istek attığımız apiden(responsemessage) 200-299 arası durum kodu dönerse
                    {
                        continue;
                    }
                }
            }
            return RedirectToAction("Index", "AdminCar");
        }

        [HttpGet]
        public async Task<IActionResult> CreateFeatureByCar(int id)
        {
            ViewBag.CarId = id;

            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync($"https://localhost:7125/api/Feature");
            if (responsemessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();//Bu veri json trü
                var values = JsonConvert.DeserializeObject<List<ResultFeatureAvaliable>>(jsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeatureByCar(List<ResultFeatureAvaliable> resultFeatureAvaliables)
        {
            if (resultFeatureAvaliables.Count > 0)
            {
                foreach(var item in resultFeatureAvaliables)
                {
                    CreateCarFeatureDto createCarFeatureDto = new CreateCarFeatureDto()
                    {
                        FeatureId = item.FeatureId,
                        Available = item.Available,
                        CarId = item.CarId
                    };
                    if (item.Available)
                    {
                        var client = _httpClientFactory.CreateClient();//İstemciyi Oluştruduk
                        var jsonData = JsonConvert.SerializeObject(createCarFeatureDto);//Modelden gelen veriyi Json Türüne Çevirdik, Normal Veriyi Json Türüne Çevirmek için SerializeObject Kullanılır
                        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//İçeriğin dönüşümü için kullancaz(content,encoding,mediaType)
                        var responseMessage = await client.PostAsync("https://localhost:7125/api/CarFeatures", stringContent);
                        if (responseMessage.IsSuccessStatusCode)//Eğer istek attığımız apiden(responsemessage) 200-299 arası durum kodu dönerse
                        {
                            continue;
                        }
                    }
                }
            }

            return RedirectToAction("Index", "AdminCar");
        }

        [HttpGet]
        public async Task<IActionResult> CarDetailComment(int id)
        {
            ViewBag.CarId = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CarDetailComment(CreateReviewDto createReviewDto)
        {
            var client = _httpClientFactory.CreateClient();//İstemciyi Oluştruduk
            var jsonData = JsonConvert.SerializeObject(createReviewDto);//Modelden gelen veriyi Json Türüne Çevirdik, Normal Veriyi Json Türüne Çevirmek için SerializeObject Kullanılır
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//İçeriğin dönüşümü için kullancaz(content,encoding,mediaType)
            var responseMessage = await client.PostAsync("https://localhost:7125/api/Reviews", stringContent);
            if (responseMessage.IsSuccessStatusCode)//Eğer istek attığımız apiden(responsemessage) 200-299 arası durum kodu dönerse
            {
                return RedirectToAction("CarDetailComment", new { id = createReviewDto.CarId });
            }

            return View();
        }

    }
}
