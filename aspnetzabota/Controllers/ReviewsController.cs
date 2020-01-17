﻿using aspnetzabota.Content.Database.Repository.Review;
using aspnetzabota.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using aspnetzabota.Content.Database.Entities;
using aspnetzabota.Web.Style;
using System.Threading.Tasks;

namespace aspnetzabota.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly IReviewRepository _reviews;

        public ReviewsController(IReviewRepository reviews)
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
        public async Task<IActionResult> AddReview([FromBody] Review data)
        {
            //вообще json(false/ true), какая-то хуйня, лучше http ошику возвращай если что-то не случилось и try catch тут не надо
            if (data == null)
                return Json(false);

            await _reviews.Add(data);

            return Json(true);
            
        }
    }
}