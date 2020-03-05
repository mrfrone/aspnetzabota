using aspnetzabota.Content.Datamodel.Doctors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspnetzabota.Content.Services.Schedule
{
    public interface ISchedule
    {
        Task<IEnumerable<DoctorScheduleModel>> Get();
        Task<IEnumerable<string>> Posts();
        Task<DoctorScheduleModel>Single(int id);
        Task<IEnumerable<DoctorScheduleModel>> ScheduleFromSinglePost(int cat_id);
        Task<IEnumerable<DoctorScheduleModel>> Random(int Count);
        Task<IEnumerable<DoctorScheduleModel>> GetPagedList(int pageNumber, int pageSize);
    }
}
