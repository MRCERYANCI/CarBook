using CarBook.DtoLayer.Dtos.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.RentACarFilterComponents
{
    public class _RentACarListFilterComponentPartial : ViewComponent
    {    
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
