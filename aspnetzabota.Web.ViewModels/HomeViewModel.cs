using aspnetzabota.Content.Database.Entities;
using System.Collections.Generic;

namespace aspnetzabota.Web.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<News> LastNews { get; set; }
        public IEnumerable<Slider> Slider { get; set; }
        public IEnumerable<Review> LastReviews { get; set; }
        public IEnumerable<DoctorSchedule> Doctors { get; set; }

    }
}
