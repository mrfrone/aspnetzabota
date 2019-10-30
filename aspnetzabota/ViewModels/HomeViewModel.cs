using aspnetzabota.Data.Models;
using System.Collections.Generic;

namespace aspnetzabota.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<News> LastNews { get; set; }
        public IEnumerable<Slider> Slider { get; set; }
        public IEnumerable<Review> LastReviews { get; set; }
        public IEnumerable<DoctorScheduleModel> Doctors { get; set; }

    }
}
