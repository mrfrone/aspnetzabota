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
                LastNews = GenericMapping<News>.Last(_news.Take, 3),
                Slider = _slider.Take,
                LastReviews = GenericMapping<Review>.Random(_lastReview.Take, 6),
                Doctors = GenericMapping<DoctorScheduleModel>.Random(_doctorSchedule.Take, 4)
            };
            return View(result);
        }
    }
}
