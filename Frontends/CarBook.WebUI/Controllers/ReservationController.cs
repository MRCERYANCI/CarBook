using CarBook.DtoLayer.Dtos.CarDtos;
using CarBook.DtoLayer.Dtos.LocationDtos;
using CarBook.DtoLayer.Dtos.ReservationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int CarId)
        {
            ViewBag.MainCover = "ARAÇ KİRALAMA ";
            ViewBag.CarId = CarId;

            var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken").Value;

            if(token != null)
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
        public async Task<IActionResult> Index(CreateReservationDto createReservationDto)
        {

            DateTime bugunTarih = DateTime.Today;
            int yas = bugunTarih.Year - createReservationDto.BirthdayDate.Year;

            if(bugunTarih < createReservationDto.BirthdayDate.AddYears(yas))
            {
                yas--;
            }

            createReservationDto.Status = "Rezervasyon Onay Bekliyor";
            createReservationDto.Age = yas;
            createReservationDto.CreatedDate = DateTime.Now;
            var client = _httpClientFactory.CreateClient();//İstemciyi Oluştruduk
            var jsonData = JsonConvert.SerializeObject(createReservationDto);//Modelden gelen veriyi Json Türüne Çevirdik, Normal Veriyi Json Türüne Çevirmek için SerializeObject Kullanılır
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//İçeriğin dönüşümü için kullancaz(content,encoding,mediaType)
            var responseMessage = await client.PostAsync("https://localhost:7125/api/Rezervations", stringContent);
            if (responseMessage.IsSuccessStatusCode)//Eğer istek attığımız apiden(responsemessage) 200-299 arası durum kodu dönerse
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
