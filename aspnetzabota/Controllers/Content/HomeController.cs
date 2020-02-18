using aspnetzabota.Content.Services.Schedule;
using aspnetzabota.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using aspnetzabota.Content.Services.News;
using aspnetzabota.Content.Services.Review;
using aspnetzabota.Content.Services.Slider;

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
                Slider = _slider.GetSliders().Result,
                LastNews = _news.GetLastNews(3).Result,
                LastReviews = _Reviews.RandomReviews(6).Result,
                Doctors = _doctorSchedule.Random(4)
            };

            return View(result);
        }
    }
}
