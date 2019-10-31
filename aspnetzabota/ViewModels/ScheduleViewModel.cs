using System.Collections.Generic;
using aspnetzabota.Data.Models;

namespace aspnetzabota.ViewModels
{
    public class ScheduleViewModel
    {
        public IEnumerable<DoctorScheduleModel> Schedule { get; set; }
        public List<string> Posts { get; set; }
        public DoctorScheduleModel SingleSchedule { get; set; }

    }
}
