using CarBook.DtoLayer.Dtos.BrandDtos;
using CarBook.DtoLayer.Dtos.RegisterDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RegisterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]

        public IActionResult CreateRegister()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRegister(CreateRegisterDto createRegisterDto)
        {
            var client = _httpClientFactory.CreateClient();//İstemciyi Oluştruduk
            var jsonData = JsonConvert.SerializeObject(createRegisterDto);//Modelden gelen veriyi Json Türüne Çevirdik, Normal Veriyi Json Türüne Çevirmek için SerializeObject Kullanılır
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//İçeriğin dönüşümü için kullancaz(content,encoding,mediaType)
            var responseMessage = await client.PostAsync("https://localhost:7125/api/SignUps", stringContent);
            if (responseMessage.IsSuccessStatusCode)//Eğer istek attığımız apiden(responsemessage) 200-299 arası durum kodu dönerse
            {
                return RedirectToAction("Index","Login");
            }
            return View();
        }
    }
}
