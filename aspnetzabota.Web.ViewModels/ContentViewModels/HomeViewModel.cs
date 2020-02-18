using aspnetzabota.Content.Database.Entities;
using aspnetzabota.Content.Datamodel.News;
using aspnetzabota.Content.Datamodel.Review;
using aspnetzabota.Content.Datamodel.Slider;
using System.Collections.Generic;

namespace aspnetzabota.Web.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<ZabotaNews> LastNews { get; set; }
        public IEnumerable<ZabotaSlider> Slider { get; set; }
        public IEnumerable<ZabotaReview> LastReviews { get; set; }
        public IEnumerable<DoctorScheduleModel> Doctors { get; set; }

    }
}
