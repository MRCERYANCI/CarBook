using CarBook.DtoLayer.Dtos.AuthorDtos;
using CarBook.DtoLayer.Dtos.CarFeatures;
using CarBook.DtoLayer.Dtos.CategoryDtos;
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
    }
}
