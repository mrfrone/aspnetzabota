using aspnetzabota.Data.Interfaces;
using aspnetzabota.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace aspnetzabota.Controllers
{
    public class PriceController : Controller
    {
        private readonly IPriceService _priceService;

        public PriceController(IPriceService ipriceService)
        {
            _priceService = ipriceService;
        }
        public ViewResult All()
        {
            var result = new PriceServiceViewModel
            {
                PriceService = _priceService.All
            };
            return View(result);

        }
    }
}
