using aspnetzabota.Data.Models;
using System.Collections.Generic;

namespace aspnetzabota.Data.Interfaces
{
    public interface IDoctorSchedule
    {
        IEnumerable<DoctorScheduleModel> AllSchedules { get; }
        IEnumerable<DoctorScheduleModel> RandomSchedules { get; }
        IEnumerable<DoctorScheduleModel> DoctorsSchedule(int cat_id);
        DoctorScheduleModel SingleSchedule(int id);
        List<string> PostsArray { get; }
    }
}
