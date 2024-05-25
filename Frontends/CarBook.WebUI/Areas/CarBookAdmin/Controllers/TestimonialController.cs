using CarBook.DtoLayer.Dtos.TesrimonialDtos;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.CarBookAdmin.Controllers
{
    [Area("CarBookAdmin")]
    [Route("CarBookAdmin/Testimonial")]
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string credentialsPath = "";
        private readonly string folderid = "";
        string[] filesToUPload = new string[1];

        public TestimonialController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private static void UploadsFilesToGoogleDrive(string credentialsPath, string folderid, string[] filesToUPload)
        {
            GoogleCredential credential;
            using (var stream = new FileStream(credentialsPath, FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream).CreateScoped(new[]
                {
                    DriveService.ScopeConstants.DriveFile
                });

                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Google Drive Upload Console App"
                });

                foreach (var filePath in filesToUPload)
                {
                    var fileMetaData = new Google.Apis.Drive.v3.Data.File()
                    {
                        Name = Path.GetFileName(filePath),
                        Parents = new List<string> { folderid }
                    };

                    FilesResource.CreateMediaUpload request;
                    using (var streamm = new FileStream(filePath, FileMode.Open))
                    {
                        request = service.Files.Create(fileMetaData, streamm, "");
                        request.Fields = "id";
                        request.Upload();
                    }

                    var uploadFile = request.ResponseBody;
                    //Console.WriteLine($"File '{fileMetaData.Name}' uploaded with ID: {uploadFile.Id}");
                }
            }
        }

        [Route("Index")]
        [HttpGet]

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:7125/api/Testimonial");
            if (responsemessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();//Bu veri json trü
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
                return View(values);
            }
            return View();
        }

        [Route("CreateTestimonial")]
        [HttpGet]

        public IActionResult CreateTestimonial()
        {
            return View();
        }

        [Route("CreateTestimonial")]
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            if (createTestimonialDto.ImageUrl1 != null)
            {
                var extension = Path.GetFullPath(createTestimonialDto.ImageUrl1.FileName);
                filesToUPload[0] = extension;

                UploadsFilesToGoogleDrive(credentialsPath, folderid, filesToUPload);

                createTestimonialDto.ImageUrl = "deneme";
                var client = _httpClientFactory.CreateClient();//İstemciyi Oluştruduk
                var jsonData = JsonConvert.SerializeObject(createTestimonialDto);//Modelden gelen veriyi Json Türüne Çevirdik, Normal Veriyi Json Türüne Çevirmek için SerializeObject Kullanılır
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//İçeriğin dönüşümü için kullancaz(content,encoding,mediaType)
                var responseMessage = await client.PostAsync("https://localhost:7125/api/Testimonial", stringContent);
                if (responseMessage.IsSuccessStatusCode)//Eğer istek attığımız apiden(responsemessage) 200-299 arası durum kodu dönerse
                {
                    return RedirectToAction("Index", "Testimonial", new { area = "CarBookAdmin" });
                }
            }

            return View();
        }

        [Route("DeleteTestimonial")]
        public async Task<IActionResult> DeleteTestimonial(int TestimonialId)
        {
            var client = _httpClientFactory.CreateClient();//İstemciyi Oluşturduk
            var responseMessage = await client.DeleteAsync($"https://localhost:7125/api/Testimonial?TestimonialId={TestimonialId}");
            if (responseMessage.IsSuccessStatusCode)//Eğer istek attığımız apiden(responsemessage) 200-299 arası durum kodu dönerse
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [Route("GetTestimonial")]
        [HttpGet]
        public async Task<IActionResult> GetTestimonial(int TestimonialId)
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync($"https://localhost:7125/api/Testimonial/{TestimonialId}");
            if (responsemessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateTestimonialDto>(jsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır
                return View(values);
            }
            return View();
        }

        [Route("GetTestimonial")]
        [HttpPost]
        public async Task<IActionResult> GetTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            var client = _httpClientFactory.CreateClient();//İstemciyi Oluştruduk
            var jsonData = JsonConvert.SerializeObject(updateTestimonialDto);//Modelden gelen veriyi Json Türüne Çevirdik
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//İçeriğin dönüşümü için kullancaz(content,encoding,mediaType)
            var responseMessage = await client.PutAsync("https://localhost:7125/api/Testimonial", stringContent);
            if (responseMessage.IsSuccessStatusCode)//Eğer istek attığımız apiden(responsemessage) 200-299 arası durum kodu dönerse
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
