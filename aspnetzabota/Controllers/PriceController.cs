using aspnetzabota.Data.Interfaces;
using aspnetzabota.Data.Mapping;
using aspnetzabota.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
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
                PriceService = _priceService.Take,
                PriceServiceDep = PriceMapping.PriceGroupsAndDepartments(_priceService.Take)
            };
            return View(result);

        }
        [HttpGet]
        public ActionResult GetDepartments(int id)
        {
            var result = new PriceServiceViewModel
            {
                PriceServiceDep = PriceMapping.PriceDepartments(id, PriceMapping.PriceGroupsAndDepartments(_priceService.Take))
            };
            return PartialView(result);
        }
        [HttpGet]
        public ActionResult PriceTable(int id)
        {
            var result = new PriceServiceViewModel
            {
                PriceService = PriceMapping.PriceFromGroup(id, _priceService.Take)
            };
            return PartialView(result);
        }
        [HttpGet]
        public ActionResult PriceTableAtDepartment(string id)
        {
            var result = new PriceServiceViewModel
            {
                PriceService = PriceMapping.PriceFromDepartment(id, _priceService.Take)
            };
            return PartialView("PriceTable", result);
        }
        [HttpGet]
        public ActionResult PriceTableAtText(string id)
        {
            var result = new PriceServiceViewModel
            {
                PriceService = PriceMapping.PriceFromSearch(id, _priceService.Take)
            };
            return PartialView("PriceTable", result);
        }

    }
}
