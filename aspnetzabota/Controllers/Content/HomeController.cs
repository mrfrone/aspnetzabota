using aspnetzabota.Content.Services.Schedule;
using aspnetzabota.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using aspnetzabota.Content.Services.Articles;
using aspnetzabota.Content.Services.Review;
using aspnetzabota.Content.Services.Slider;
using System.Threading.Tasks;

namespace aspnetzabota.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticles _articles;
        private readonly ISlider _slider;
        private readonly IReview _Reviews;
        private readonly ISchedule _doctorSchedule;

        public HomeController(IArticles articles, ISlider slider, IReview review, ISchedule doctorSchedule)
        {
            _articles = articles;
            _slider = slider;
            _Reviews = review;
            _doctorSchedule = doctorSchedule;
        }
        [Route("/")]
        public async Task<ViewResult> Index()
        {
            var result = new HomeViewModel
            {
                Slider = await _slider.GetSliders(),
                LastNews = await _articles.GetLastNews(3),
                LastReviews = await _Reviews.RandomReviews(6),
                Doctors = await _doctorSchedule.Random(4)
            };

            return View(result);
        }
    }
}
