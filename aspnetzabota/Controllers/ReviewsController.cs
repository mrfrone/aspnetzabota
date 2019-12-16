using aspnetzabota.Data.Interfaces;
using aspnetzabota.ViewModels;
using Microsoft.AspNetCore.Mvc;
using aspnetzabota.Data;
using aspnetzabota.ComponentStyles;

namespace aspnetzabota.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly IReview _reviews;

        public ReviewsController(IReview reviews)
        {
            _reviews = reviews;
        }
        public ViewResult Main()
        {
            var result = new ReviewsViewModel
            {
                Reviews = _reviews.GetPagedList(1, 5),
                PaginationOptions = PaginationStyle.PagedListOptions
            };
            return View(result);
        }
        public ActionResult PagedReviews(int? page)
        {
            var pageNumber = page ?? 1;
            var result = new ReviewsViewModel
            {
                Reviews = _reviews.GetPagedList(pageNumber, 5),
                PaginationOptions = PaginationStyle.PagedListOptionsAjax
            };
            return PartialView(result);
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