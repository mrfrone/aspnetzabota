using System.Collections.Generic;
using aspnetzabota.Content.Datamodel.Doctors;
using X.PagedList.Mvc.Common;

namespace aspnetzabota.Web.ViewModels
{
    public class ScheduleViewModel
    {
        public IEnumerable<DoctorSchedule> Schedule { get; set; }
        public IEnumerable<string> Posts { get; set; }
        public DoctorSchedule SingleSchedule { get; set; }
        public PagedListRenderOptionsBase PaginationOptions { get; set; }

    }
}
