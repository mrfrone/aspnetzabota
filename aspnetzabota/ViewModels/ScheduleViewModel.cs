using System.Collections.Generic;
using aspnetzabota.Content.Database.Entities;
using X.PagedList.Mvc.Common;

namespace aspnetzabota.ViewModels
{
    public class ScheduleViewModel
    {
        public IEnumerable<DoctorSchedule> Schedule { get; set; }
        public IEnumerable<string> Posts { get; set; }
        public DoctorSchedule SingleSchedule { get; set; }
        public PagedListRenderOptionsBase PaginationOptions { get; set; }

    }
}
