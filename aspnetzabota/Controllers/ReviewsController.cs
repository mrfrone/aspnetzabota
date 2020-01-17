using aspnetzabota.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using aspnetzabota.Content.Database.Entities;
using aspnetzabota.Web.Style;
using System.Threading.Tasks;
using aspnetzabota.Content.Services.Review;
using aspnetzabota.Content.Datamodel.Review;

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
                Reviews = _reviews.GetPagedReviewsList(1, 5).Result,
                PaginationOptions = PaginationStyle.PagedListOptions
            };
            return View(result);
        }
        public ActionResult PagedReviews(int? page)
        {
            var pageNumber = page ?? 1;
            var result = new ReviewsViewModel
            {
                Reviews = _reviews.GetPagedReviewsList(pageNumber, 5).Result,
                PaginationOptions = PaginationStyle.PagedListOptionsAjax
            };
            return PartialView(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddReview([FromBody] ZabotaReview data)
        {
            //вообще json(false/ true), какая-то хуйня, лучше http ошику возвращай если что-то не случилось и try catch тут не надо
            if (data == null)
                return Json(false);

            await _reviews.Add(data);

            return Json(true);
            
        }
    }
}