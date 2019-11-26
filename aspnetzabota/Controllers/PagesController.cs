using aspnetzabota.Data.Interfaces;
using aspnetzabota.ViewModels;
using Microsoft.AspNetCore.Mvc;
using aspnetzabota.Data.Models;

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
        public ViewResult Reviews()
        {
            var result = new ReviewsViewModel
            {
                Reviews = _reviews.Take
            };
            return View(result);
        }

        [HttpPost]
        public IActionResult AddReview([FromBody] Review data)
        {
            return Json(Ok());
        }
    }
}