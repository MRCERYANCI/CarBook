using CarBook.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class KargoTakip : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2()
        {
            return View();
        }

        public IActionResult Index3()
        {
            return View();
        }
        public IActionResult Index4()
        {
            return View();
        }

        public IActionResult Index5()
        {
            return View();
        }
        public IActionResult Index6()
        {
            return View();
        }
        public IActionResult KayseriUlasimKart()
        {
            return View();
        }

        public IActionResult KartTanimlama()
        {
            return View();
        }

        public IActionResult Kartlarim()
        {
            return View();
        }

        [HttpGet]
        public IActionResult KartimaBakiyeYukle(int CardType, int CardNumber)
        {
            TempData["CardType"] = CardType;
            TempData["CardNumber"] = CardNumber;

            return View();
        }

        public IActionResult ZiraatDekont()
        {
            return View();
        }

        public IActionResult Mavi()
        {
            return View();
        }

        public IActionResult KayseriUlasimLogin()
        {
            return View();
        }

        public IActionResult Kart38Login()
        {
            return View();
        }

        public IActionResult ParaYukleme()
        {
            return View();
        }

        public IActionResult bilgiguncelleme()
        {
            return View();
        }
        public IActionResult SifreYenileme()
        {
            return View();
        }

        public IActionResult KitapKartTarifeleri()
        {
            return View();
        }

        public IActionResult KitapKartNedir()
        {
            return View();
        }

        public IActionResult KitapKartMailSistemi()
        {
            return View();
        }

        public IActionResult KartBakiyeYukleme()
        {
            return View();
        }

        public IActionResult BakiyeTutar()
        {
            return View();
        }

        public IActionResult KartBakiyeSorgulama()
        {
            return View();
        }

        public IActionResult bakiyeodeme()
        {           
            return View();
        }


        [HttpPost]
        public IActionResult karthareketajax(string kartno)
        {
            if (kartno == "0009451996")
            {
                var jsonWriters = JsonConvert.SerializeObject(hareketlers1.OrderByDescending(x=>x.Tarih).Take(10).ToList());
                return Json(jsonWriters);
            }
            else if (kartno == "3466894509")
            {
                var jsonWriter2 = JsonConvert.SerializeObject(hareketlers2);
                return Json(jsonWriter2);
            }

            return Json("");
        }

        public static List<Hareketler> hareketlers1 = new List<Hareketler>()
        {
            new Hareketler
            {
                Tarih = "20/02/2024 17:10:45 PM" ,
                Protype = "E-Topup Yükleme Emri",
                BusNo = "Yükleme Emri Bekleniyor",
                Amount = 50,
                Balance = 215.25
            },
             new Hareketler
            {
                Tarih = "14/02/2024 11:13:45 PM" ,
                Protype = "Giriş İşlemi",
                BusNo = "*** Nolu Kütüphane",
                Amount = 11.5,
                Balance = 165.25
            },
            new Hareketler
            {
                Tarih = "13/02/2024 15:08:45 PM" ,
                Protype = "Giriş İşlemi",
                BusNo = "*** Nolu Kütüphane",
                Amount = 11.5,
                Balance = 176.75
            },
            new Hareketler
            {
                Tarih = "13/02/2024 13:34:25 PM" ,
                Protype = "Giriş İşlemi",
                BusNo = "*** Nolu Kütüphane",
                Amount = 11.5,
                Balance = 188.25
            },
            new Hareketler
            {
                Tarih = "13/02/2024 13:34:20 PM" ,
                Protype = "Yükleme",
                BusNo = "Para Yükleme Gerçekleşti",
                Amount = 50,
                Balance = 199.75
            },
            new Hareketler
            {
                Tarih = "12/02/2024 13:18:20 PM" ,
                Protype = "E-Topup Yükleme Emri",
                BusNo = "Yükleme Emri Bekleniyor",
                Amount = 50,
                Balance = 149.75
            },
            new Hareketler
            {
                Tarih = "12/02/2024 13:16:20 PM" ,
                Protype = "Giriş İşlemi",
                BusNo = "*** Nolu Kütüphane",
                Amount = 15.75,
                Balance = 149.75
            },
            new Hareketler
            {
                Tarih = "12/02/2024 13:16:20 PM" ,
                Protype = "Giriş İşlemi",
                BusNo = "*** Nolu Kütüphane",
                Amount = 11.5,
                Balance = 165.5
            },
            
            new Hareketler
            {
                Tarih = "10/02/2024 19:54:20 PM" ,
                Protype = "Giriş İşlemi",
                BusNo = "*** Nolu Kütüphane",
                Amount = 11.50,
                Balance = 177
            },
            new Hareketler
            {
                Tarih = "10/02/2024 19:08:20 PM" ,
                Protype = "Aktarma",
                BusNo = "*** Nolu Kütüphane",
                Amount = 0,
                Balance = 188.5
            },
            new Hareketler
            {
                Tarih = "10/02/2024 19:05:30 PM" ,
                Protype = "E-Topup Yükleme Emri",
                BusNo = "Yükleme Emri Bekleniyor",
                Amount = 200,
                Balance = 0
            },
            new Hareketler
            {
                Tarih = "10/02/2024 19:00:20 PM" ,
                Protype = "Giriş İşlemi",
                BusNo = "*** Nolu Kütüphane",
                Amount = 11.50,
                Balance = 188.5
            }
        };

        public static List<Hareketler> hareketlers2 = new List<Hareketler>()
        {
            new Hareketler
            {
                Tarih = "10/02/2024 19:00:20 PM" ,
                Protype = "Çıkış İşlemi",
                BusNo = "*** Nolu Kütüphane",
                Amount = 0,
                Balance = 188.5
            },
              new Hareketler
            {
                Tarih = "10/02/2024 19:05:30 PM" ,
                Protype = "E-Topup Yükleme Emri",
                BusNo = "Yükleme Emri Bekleniyor",
                Amount = 200,
                Balance = 0
            }
        };
    }
}
