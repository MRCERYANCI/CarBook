using CarBook.DtoLayer.Dtos.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CarBook.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

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

                    List<SelectListItem> LocationItems = (from x in values
                                                          select new SelectListItem
                                                          {
                                                              Text = x.Name,
                                                              Value = x.LocationId.ToString()
                                                          }).ToList();

                    ViewBag.LocationItems = LocationItems;

                }
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string book_pick_date,string book_off_date,string time_pick,string time_off,int locationID)
        {
            TempData["book_pick_date"] = book_pick_date;
            TempData["book_off_date"] = book_off_date;
            TempData["time_pick"] = time_pick;
            TempData["time_off"] = time_off;
            TempData["locationID"] = locationID;

            return RedirectToAction("Index", "RentACarList");
        }
    }
}
