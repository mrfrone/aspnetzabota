using aspnetzabota.Content.Datamodel.Articles;
using aspnetzabota.Content.Datamodel.Doctors;
using aspnetzabota.Content.Datamodel.Review;
using aspnetzabota.Content.Datamodel.Slider;
using System.Collections.Generic;

namespace aspnetzabota.Web.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<ZabotaArticles> LastNews { get; set; }
        public IEnumerable<ZabotaSlider> Slider { get; set; }
        public IEnumerable<ZabotaReview> LastReviews { get; set; }
        public IEnumerable<DoctorSchedule> Doctors { get; set; }

    }
}
