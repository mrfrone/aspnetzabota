using aspnetzabota.Data.Interfaces;
using aspnetzabota.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace aspnetzabota.Controllers
{
    public class HomeController : Controller
    {
        private readonly INews _LastNews;
        private readonly ISlider _Slider;
        private readonly IReview _LastReview;
        private readonly IDoctorSchedule _DoctorSchedule;

        public HomeController(INews iAllNews, ISlider slider, IReview Review, IDoctorSchedule doctorSchedule)
        {
            _LastNews = iAllNews;
            _Slider = slider;
            _LastReview = Review;
            _DoctorSchedule = doctorSchedule;
        }
        public ViewResult Index()
        {
            HomeViewModel obj = new HomeViewModel();
            obj.LastNews = _LastNews.LastNews;
            obj.Slider = _Slider.AllSliders;
            obj.LastReviews = _LastReview.LastReviews;
            obj.Doctors = _DoctorSchedule.RandomSchedules;
            return View(obj);
        }
    }
}
