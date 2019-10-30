using aspnetzabota.Data.Interfaces;
using aspnetzabota.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace aspnetzabota.Controllers
{
    public class HomeController : Controller
    {
        //if field is private name should be like "_name", lower case
        private readonly INews _lastNews;
        private readonly ISlider _slider;
        private readonly IReview _lastReview;
        private readonly IDoctorSchedule _doctorSchedule;

        public HomeController(INews iAllNews, ISlider slider, IReview review, IDoctorSchedule doctorSchedule)
        {
            _lastNews = iAllNews;
            _slider = slider;
            _lastReview = review;
            _doctorSchedule = doctorSchedule;
        }
        public ViewResult Index()
        {
            //its more useful
            var result = new HomeViewModel
            {
                LastNews = _lastNews.LastNews,
                Slider = _slider.AllSliders,
                LastReviews = _lastReview.LastReviews,
                Doctors = _doctorSchedule.RandomSchedules
            };
            return View(result);
        }
    }
}
