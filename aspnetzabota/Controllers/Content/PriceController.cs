using aspnetzabota.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using aspnetzabota.Content.Services.Price;
using System.Threading.Tasks;

namespace aspnetzabota.Controllers
{
    public class PriceController : Controller
    {
        private readonly IPrice _price;

        public PriceController(IPrice price)
        {
            _price = price;
        }
        public async Task<ViewResult> List()
        {
            var result = new PriceServiceViewModel
            {
                PriceService = await _price.Get(),
                PriceServiceDep = await _price.GroupsAndDepartments()
            };
            return View(result);

        }
        [HttpGet]
        public async Task<IActionResult> GetDepartments(int id)
        {
            var result = new PriceServiceViewModel
            {
                PriceServiceDep = await _price.PriceDepartments(id)
            };
            return PartialView(result);
        }
        [HttpGet]
        public async Task<IActionResult> PriceTable(int id)
        {
            var result = new PriceServiceViewModel
            {
                PriceService = await _price.FromGroup(id)
            };
            return PartialView(result);
        }
        [HttpGet]
        public async Task<IActionResult> PriceTableAtDepartment(string id)
        {
            var result = new PriceServiceViewModel
            {
                PriceService =  await _price.FromDepartment(id)
            };
            return PartialView("PriceTable", result);
        }
        [HttpGet]
        public async Task<IActionResult> PriceTableAtText(string id)
        {
            var result = new PriceServiceViewModel
            {
                PriceService = await _price.FromSearch(id)
            };
            return PartialView("PriceTable", result);
        }

    }
}
