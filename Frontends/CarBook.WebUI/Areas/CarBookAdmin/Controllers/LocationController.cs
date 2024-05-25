using CarBook.DtoLayer.Dtos.LocationDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Common;
using System.Net.Http.Headers;
using System.Text;

namespace CarBook.WebUI.Areas.CarBookAdmin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("CarBookAdmin")]
    [Route("CarBookAdmin/Location")]
    public class LocationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LocationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        [HttpGet]

        public async Task<IActionResult> Index()
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken").Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var responsemessage = await client.GetAsync("https://localhost:7125/api/Location");
                if (responsemessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
                {
                    var jsondata = await responsemessage.Content.ReadAsStringAsync();//Bu veri json trü
                    var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
                    return View(values);
                }
            }

            return View();
        }

        [Route("CreateLocation")]
        [HttpGet]

        public IActionResult CreateLocation()
        {
            return View();
        }

        [Route("CreateLocation")]
        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLocationDto createLocationDto)
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken").Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();//İstemciyi Oluştruduk
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var jsonData = JsonConvert.SerializeObject(createLocationDto);//Modelden gelen veriyi Json Türüne Çevirdik, Normal Veriyi Json Türüne Çevirmek için SerializeObject Kullanılır
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//İçeriğin dönüşümü için kullancaz(content,encoding,mediaType)
                var responseMessage = await client.PostAsync("https://localhost:7125/api/Location", stringContent);
                if (responseMessage.IsSuccessStatusCode)//Eğer istek attığımız apiden(responsemessage) 200-299 arası durum kodu dönerse
                {
                    return RedirectToAction("Index", "Location", new { area = "CarBookAdmin" });
                }
            }
            return View();
        }

        [Route("DeleteLocation")]
        public async Task<IActionResult> DeleteLocation(int LocationId)
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken").Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();//İstemciyi Oluşturduk
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var responseMessage = await client.DeleteAsync($"https://localhost:7125/api/Location?LocationId={LocationId}");
                if (responseMessage.IsSuccessStatusCode)//Eğer istek attığımız apiden(responsemessage) 200-299 arası durum kodu dönerse
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        [Route("GetLocation")]
        [HttpGet]
        public async Task<IActionResult> GetLocation(int LocationId)
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken").Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var responsemessage = await client.GetAsync($"https://localhost:7125/api/Location/{LocationId}");
                if (responsemessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
                {
                    var jsondata = await responsemessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<UpdateLocationDto>(jsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
                    return View(values);
                }
            }
            return View();
        }

        [Route("GetLocation")]
        [HttpPost]
        public async Task<IActionResult> GetLocation(UpdateLocationDto updateLocationDto)
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken").Value;
            if(token != null)
            {
                var client = _httpClientFactory.CreateClient();//İstemciyi Oluştruduk
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var jsonData = JsonConvert.SerializeObject(updateLocationDto);//Modelden gelen veriyi Json Türüne Çevirdik
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//İçeriğin dönüşümü için kullancaz(content,encoding,mediaType)
                var responseMessage = await client.PutAsync("https://localhost:7125/api/Location", stringContent);
                if (responseMessage.IsSuccessStatusCode)//Eğer istek attığımız apiden(responsemessage) 200-299 arası durum kodu dönerse
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }
    }
}
