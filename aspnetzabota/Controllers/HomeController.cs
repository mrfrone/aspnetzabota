using aspnetzabota.Data.Interfaces;
using aspnetzabota.Data.Mapping;
using aspnetzabota.Data.Models;
using aspnetzabota.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace aspnetzabota.Controllers
{
    public class HomeController : Controller
    {
        private readonly INews _news;
        private readonly ISlider _slider;
        private readonly IReview _lastReview;
        private readonly IDoctorSchedule _doctorSchedule;

        public HomeController(INews iNews, ISlider slider, IReview review, IDoctorSchedule doctorSchedule)
        {
            _news = iNews;
            _slider = slider;
            _lastReview = review;
            _doctorSchedule = doctorSchedule;
        }
        public ViewResult Index()
        {
            var result = new HomeViewModel
            {
                LastNews = GenericMapping<News>.Last(3, _news.Take),
                Slider = _slider.Take,
                LastReviews = GenericMapping<Review>.Last(6, _lastReview.Take),
                Doctors = DoctorsMapping.Random(_doctorSchedule.Take)
            };
            return View(result);
        }
    }
}
