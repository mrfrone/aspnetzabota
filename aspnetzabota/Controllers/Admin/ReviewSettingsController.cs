using aspnetzabota.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using aspnetzabota.Web.Style;
using System.Threading.Tasks;
using aspnetzabota.Content.Services.Review;
using aspnetzabota.Web.Common;
using Microsoft.AspNetCore.Authorization;

namespace aspnetzabota.Controllers
{
    [Route("admin/[controller]/[action]")]
    [Authorize]
    public class ReviewSettingsController : BaseController
    {
        private readonly IReview _reviews;

        public ReviewSettingsController(IReview reviews)
        {
            _reviews = reviews;
        }
        public async Task<ViewResult> List()
        {
            var result = new ReviewsViewModel
            {
                Reviews = await _reviews.GetPagedReviewsList(1, 10),
                PaginationOptions = PaginationStyle.PagedListOptions
            };
            return View(result);
        }
        public async Task<IActionResult> PagedReviews(int? page)
        {
            var pageNumber = page ?? 1;
            var result = new ReviewsViewModel
            {
                Reviews = await _reviews.GetPagedReviewsList(pageNumber, 10),
                PaginationOptions = PaginationStyle.PagedListOptionsAjax
            };
            return PartialView(result);
        }

        [HttpGet]
        public async Task<IActionResult> ModerateReview(int id)
        {
            await _reviews.ModerateReview(id);

            return Redirect("/admin/ReviewSettings/"+nameof(List));
        }
        [HttpGet]
        public async Task<IActionResult> DeleteReview(int id)
        {
            await _reviews.DeleteReview(id);

            return Redirect("/admin/ReviewSettings/" + nameof(List));
        }
    }
}