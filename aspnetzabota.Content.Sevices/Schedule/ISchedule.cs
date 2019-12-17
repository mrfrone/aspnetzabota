using aspnetzabota.Content.Database.Entities;
using System.Collections.Generic;

namespace aspnetzabota.Content.Services.Schedule
{
    public interface ISchedule
    {
        IEnumerable<DoctorScheduleModel> Take { get; }
        IEnumerable<string> Posts { get; }
        DoctorScheduleModel Single(int id);
        IEnumerable<DoctorScheduleModel> ScheduleFromSinglePost(int cat_id);
        IEnumerable<DoctorScheduleModel> Random(int Count);
        IEnumerable<DoctorScheduleModel> GetPagedList(int pageNumber, int pageSize);
    }
}
