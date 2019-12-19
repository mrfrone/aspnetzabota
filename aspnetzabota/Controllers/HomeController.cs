using aspnetzabota.Content.Database.Repository.News;
using aspnetzabota.Content.Database.Repository.Slider;
using aspnetzabota.Content.Database.Repository.Review;
using aspnetzabota.Content.Services.Schedule;
using aspnetzabota.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace aspnetzabota.Controllers
{
    public class HomeController : Controller
    {
        private readonly INews _news;
        private readonly ISlider _slider;
        private readonly IReview _Reviews;
        private readonly ISchedule _doctorSchedule;

        public HomeController(INews iNews, ISlider slider, IReview review, ISchedule doctorSchedule)
        {
            _news = iNews;
            _slider = slider;
            _Reviews = review;
            _doctorSchedule = doctorSchedule;
        }
        public ViewResult Index()
        {
            var result = new HomeViewModel
            {
                LastNews = _news.Last(3),
                Slider = _slider.Take,
                LastReviews = _Reviews.Random(6),
                Doctors = _doctorSchedule.Random(4)
            };
            return View(result);
        }
    }
}
