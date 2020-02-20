using System.Collections.Generic;
using aspnetzabota.Content.Datamodel.Doctors;
using X.PagedList.Mvc.Common;

namespace aspnetzabota.Web.ViewModels
{
    public class ScheduleViewModel
    {
        public IEnumerable<DoctorScheduleModel> Schedule { get; set; }
        public IEnumerable<string> Posts { get; set; }
        public DoctorScheduleModel SingleSchedule { get; set; }
        public PagedListRenderOptionsBase PaginationOptions { get; set; }

    }
}
