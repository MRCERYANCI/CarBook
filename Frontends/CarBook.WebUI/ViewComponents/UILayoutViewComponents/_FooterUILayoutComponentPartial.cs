using CarBook.Domain.Entities;
using CarBook.DtoLayer.Dtos.BrandDtos;
using CarBook.DtoLayer.Dtos.CarDtos;
using CarBook.DtoLayer.Dtos.FooterAddressDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _FooterUILayoutComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _FooterUILayoutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var FooterAddressMessage = await client.GetAsync("https://localhost:7125/api/FooterAddress/4");
            if (FooterAddressMessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var jsondata = await FooterAddressMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCarDto>(jsondata); //Json Türünü Normale Çevirmek için DeserializeObject Kullanılır

                var FooterAddressjsondata = await FooterAddressMessage.Content.ReadAsStringAsync();
                var FooterAddressvalues = JsonConvert.DeserializeObject<ResultFooterAddressDto>(FooterAddressjsondata);
                
                return View(FooterAddressvalues);
            }
            return View();
        }
    }
}
