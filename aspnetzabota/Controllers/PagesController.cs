using aspnetzabota.Data.Interfaces;
using aspnetzabota.ViewModels;
using Microsoft.AspNetCore.Mvc;
using aspnetzabota.Data.Models;
using aspnetzabota.Data.Mapping;
using X.PagedList;

namespace aspnetzabota.Controllers
{
    public class PagesController : Controller
    {
        private readonly IReview _reviews;

        public PagesController(IReview reviews)
        {
            _reviews = reviews;
        }
        public ViewResult ContactUs()
        {
            return View();
        }
        public ViewResult Reviews(int? page)
        {
            var pageNumber = page ?? 1;
            var result = new ReviewsViewModel
            {
                Reviews = ReviewMapping.Reverse(_reviews.Take).ToPagedList(pageNumber, 10),
                PaginationOptions = PaginationViewModel.PagedListOptions
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