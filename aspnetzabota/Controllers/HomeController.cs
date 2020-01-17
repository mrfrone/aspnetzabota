using aspnetzabota.Content.Database.Repository.News;
using aspnetzabota.Content.Database.Repository.Slider;
using aspnetzabota.Content.Database.Repository.Review;
using aspnetzabota.Content.Services.Schedule;
using aspnetzabota.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using aspnetzabota.Content.Services.Sliders;

namespace aspnetzabota.Controllers
{
    public class HomeController : Controller
    {
        private readonly INewsRepository _news;
        private readonly ISlider _slider;
        private readonly IReview _Reviews;
        private readonly ISchedule _doctorSchedule;

        public HomeController(INewsRepository iNews, ISlider slider, IReview review, ISchedule doctorSchedule)
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
                Slider = _slider.GetSliders().Result,
                LastReviews = _Reviews.Random(6),
                Doctors = _doctorSchedule.Random(4)
            };

            return View(result);
        }
    }
}
