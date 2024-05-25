using Microsoft.AspNetCore.SignalR;

namespace CarBook.WebApi.Hubs
{
    public class CarHub:Hub
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task SendCarCount()
        {
            var client = _httpClientFactory.CreateClient();

            var responseGetCarCountMessage = await client.GetAsync("https://localhost:7125/api/Statistics/GetCarCount");
            if (responseGetCarCountMessage.IsSuccessStatusCode)//200 ile 299 arasında bir sayı dönerse true döneceğinden başarılı false dönerse başarısız
            {
                var GetCarCountjsondata = await responseGetCarCountMessage.Content.ReadAsStringAsync();//Bu veri json trü
                await Clients.All.SendAsync("ReceiverCarCount", GetCarCountjsondata);
            }
        }
    }
}
