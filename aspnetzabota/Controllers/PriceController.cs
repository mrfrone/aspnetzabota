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
                PriceService = _priceService.Take,
                PriceServiceDep = _priceService.GroupsAndDepartments
            };
            return View(result);

        }
        [HttpGet]
        public ActionResult GetDepartments(int id)
        {
            var result = new PriceServiceViewModel
            {
                PriceServiceDep = _priceService.PriceDepartments(id)
            };
            return PartialView(result);
        }
        [HttpGet]
        public ActionResult PriceTable(int id)
        {
            var result = new PriceServiceViewModel
            {
                PriceService = _priceService.FromGroup(id)
            };
            return PartialView(result);
        }
        [HttpGet]
        public ActionResult PriceTableAtDepartment(string id)
        {
            var result = new PriceServiceViewModel
            {
                PriceService = _priceService.FromDepartment(id)
            };
            return PartialView("PriceTable", result);
        }
        [HttpGet]
        public ActionResult PriceTableAtText(string id)
        {
            var result = new PriceServiceViewModel
            {
                PriceService = _priceService.FromSearch(id)
            };
            return PartialView("PriceTable", result);
        }

    }
}
