using aspnetzabota.Data.Interfaces;
using aspnetzabota.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
                PriceService = _priceService.All,
                PriceServiceDep = _priceService.PriceGroupsAndDepartments
            };
            return View(result);

        }
        public ActionResult GetItems(int id)
        {
            var result = new PriceServiceViewModel
            {
                PriceService = _priceService.All.Where(c => c.grcode == id),
                PriceServiceDep = _priceService.PriceGroupsAndDepartments.Where(c => c.grcode == id)
            };
            return PartialView(result);
        }
    }
}
