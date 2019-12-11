using aspnetzabota.Data.Interfaces;
using aspnetzabota.ViewModels;
using Microsoft.AspNetCore.Mvc;
using aspnetzabota.Data.Models;
using aspnetzabota.ComponentStyles;

namespace aspnetzabota.Controllers
{
    public class PagesController : Controller
    {
        private readonly IReview _reviews;
        private readonly ILicenses _licenses;

        public PagesController(IReview reviews, ILicenses licenses)
        {
            _reviews = reviews;
            _licenses = licenses;
        }
        public ViewResult ContactUs()
        {
            return View();
        }
        public ViewResult RegulatoryOrg()
        {
            return View();
        }
        public ViewResult OMS()
        {
            return View();
        }
        public ViewResult License()
        {
            var result = new LicensesViewModel
            {
                Licenses = _licenses.Take
            };
            return View(result);
        }
        public ViewResult Reviews(int? page)
        {
            var pageNumber = page ?? 1;
            var result = new ReviewsViewModel
            {
                Reviews = _reviews.GetPagedList(pageNumber, 10),
                PaginationOptions = PaginationStyle.PagedListOptions
            };
            return View(result);
        }

        [HttpPost]
        public IActionResult AddReview([FromBody] Review data)
        {
            //вообще json(false/ true), какая-то хуйня, лучше http ошику возвращай если что-то не случилось и try catch тут не надо
            if (data == null)
                return Json(false);

            _reviews.Add(data);

            return Json(true);
            
        }
    }
}