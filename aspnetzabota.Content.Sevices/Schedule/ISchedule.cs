using aspnetzabota.Content.Database.Entities;
using System.Collections.Generic;

namespace aspnetzabota.Content.Services.Schedule
{
    public interface ISchedule
    {
        IEnumerable<DoctorSchedule> Take { get; }
        IEnumerable<string> Posts { get; }
        DoctorSchedule Single(int id);
        IEnumerable<DoctorSchedule> ScheduleFromSinglePost(int cat_id);
        IEnumerable<DoctorSchedule> Random(int Count);
        IEnumerable<DoctorSchedule> GetPagedList(int pageNumber, int pageSize);
    }
}
