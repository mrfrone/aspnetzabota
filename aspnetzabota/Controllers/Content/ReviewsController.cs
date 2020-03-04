using aspnetzabota.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using aspnetzabota.Web.Style;
using System.Threading.Tasks;
using aspnetzabota.Content.Services.Review;
using aspnetzabota.Content.Datamodel.Review;
using aspnetzabota.Web.Common;

namespace aspnetzabota.Controllers
{
    public class ReviewsController : BaseController
    {
        private readonly IReview _reviews;

        public ReviewsController(IReview reviews)
        {
            _reviews = reviews;
        }
        public async Task<ViewResult> Main()
        {
            var result = new ReviewsViewModel
            {
                Reviews = await _reviews.GetPagedReviewsList(1, 5),
                PaginationOptions = PaginationStyle.PagedListOptions
            };
            return View(result);
        }
        public async Task<IActionResult> PagedReviews(int? page)
        {
            var pageNumber = page ?? 1;
            var result = new ReviewsViewModel
            {
                Reviews = await _reviews.GetPagedReviewsList(pageNumber, 5),
                PaginationOptions = PaginationStyle.PagedListOptionsAjax
            };
            return PartialView(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddReview([FromBody] ZabotaReview data)
        {
            await _reviews.Add(data);
            return ZabotaResult(true);
        }
    }
}