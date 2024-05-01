using CarBook.DtoLayer.Dtos.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.MainCover = "ARAÇ KİRALAMA ";
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:7125/api/Location");
            if (responsemessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();//Bu veri json trü
                var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır

                List<SelectListItem> LocationItems = (from x in values
                                                      select new SelectListItem
                                                      {
                                                          Text = x.Name,
                                                          Value = x.LocationId.ToString()
                                                      }).ToList();

                ViewBag.LocationItems = LocationItems;

            }
            return View();
        }
    }
}
