using System.Collections.Generic;
using aspnetzabota.Data.Models;
using X.PagedList.Mvc.Common;

namespace aspnetzabota.ViewModels
{
    public class ScheduleViewModel
    {
        public IEnumerable<DoctorScheduleModel> Schedule { get; set; }
        public IEnumerable<string> Posts { get; set; }
        public DoctorScheduleModel SingleSchedule { get; set; }
        public PagedListRenderOptionsBase PaginationOptions { get; set; }

    }
}
