using CarBook.DtoLayer.Dtos.CarPricingDtos;
using CarBook.DtoLayer.Dtos.RentACarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class CarPricingController : Controller
    {
		private readonly IHttpClientFactory _httpClientFactory;

		public CarPricingController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
        {
            ViewBag.MainCover = "ARAÇ FİYATLARI ";

			var client = _httpClientFactory.CreateClient();//İstemciyi Oluştruduk          
			var responseMessage = await client.GetAsync("https://localhost:7125/api/CarPricing/GetCarPricingWithTimePeriod");
			if (responseMessage.IsSuccessStatusCode)//Eğer istek attığımız apiden(responsemessage) 200-299 arası durum kodu dönerse
			{
				var jsondata = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCarPricingListWithModelDto>>(jsondata);
				return View(values);
			}

			return View();
        }
    }
}
