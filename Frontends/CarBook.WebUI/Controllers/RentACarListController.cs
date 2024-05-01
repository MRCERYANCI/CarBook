using CarBook.DtoLayer.Dtos.AboutDtos;
using CarBook.DtoLayer.Dtos.LocationDtos;
using CarBook.DtoLayer.Dtos.RentACarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RentACarListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.MainCover = "ARAÇ LİSTESİ ";

            var book_pick_date = TempData["book_pick_date"];
            var book_off_date = TempData["book_off_date"];
            var time_pick = TempData["time_pick"];
            var time_off = TempData["time_off"];
            var LocationId = (int)TempData["locationID"];


            var client = _httpClientFactory.CreateClient();//İstemciyi Oluştruduk          
            var responseMessage = await client.GetAsync($"https://localhost:7125/api/RentACars?LocationId={LocationId}&Available=true");
            if (responseMessage.IsSuccessStatusCode)//Eğer istek attığımız apiden(responsemessage) 200-299 arası durum kodu dönerse
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultRentACarDto>>(jsondata);
                return View(values);
            }

            return View();
        }
    }
}
