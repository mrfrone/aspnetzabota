using aspnetzabota.Data.Models;
using System.Collections.Generic;

namespace aspnetzabota.Data.Interfaces
{
    public interface IDoctorSchedule
    {
        IEnumerable<DoctorScheduleModel> Take { get; }
        IEnumerable<string> Posts { get; }
        DoctorScheduleModel Single(int id);
        IEnumerable<DoctorScheduleModel> ScheduleFromSinglePost(int cat_id);
        IEnumerable<DoctorScheduleModel> Random(int Count);
        IEnumerable<DoctorScheduleModel> GetPagedList(int pageNumber, int pageSize);
    }
}
