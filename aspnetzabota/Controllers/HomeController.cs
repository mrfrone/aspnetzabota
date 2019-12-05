using aspnetzabota.Data.Interfaces;
using aspnetzabota.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace aspnetzabota.Controllers
{
    public class HomeController : Controller
    {
        private readonly INews _news;
        private readonly ISlider _slider;
        private readonly IReview _Reviews;
        private readonly IDoctorSchedule _doctorSchedule;

        public HomeController(INews iNews, ISlider slider, IReview review, IDoctorSchedule doctorSchedule)
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
