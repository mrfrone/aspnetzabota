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
        [HttpGet]
        public ActionResult GetItems(int id)
        {
            var result = new PriceServiceViewModel
            {
                PriceServiceDep = _priceService.PriceGroupsAndDepartments.Where(c => c.grcode == id)
            };
            return PartialView(result);
        }
        [HttpGet]
        public ActionResult PriceTable(int id)
        {
            var result = new PriceServiceViewModel
            {
                PriceService = _priceService.All.Where(c => c.grcode == id)
            };
            return PartialView(result);
        }
        [HttpGet]
        public ActionResult PriceTableAtDepartment(string id)
        {
            var result = new PriceServiceViewModel
            {
                PriceService = _priceService.All.Where(c => c.depart_name == id)
            };
            return PartialView("PriceTable", result);
        }
        [HttpGet]
        public ActionResult PriceTableAtText(string id)
        {
            var result = new PriceServiceViewModel
            {
                PriceService = _priceService.All.Where(c => c.depart_name.Contains(id))
            };
            return PartialView("PriceTable", result);
        }

    }
}
