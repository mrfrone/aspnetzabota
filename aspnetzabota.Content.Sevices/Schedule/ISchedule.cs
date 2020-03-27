using aspnetzabota.Content.Database.Entities;
using aspnetzabota.Content.Datamodel.Doctors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspnetzabota.Content.Services.Schedule
{
    public interface ISchedule
    {
        Task<IEnumerable<DoctorSchedule>> Get(bool OnlyComplete = false);
        Task<IEnumerable<string>> Posts();
        Task<DoctorSchedule>Single(int id);
        Task<IEnumerable<DoctorSchedule>> ScheduleFromSinglePost(int cat_id);
        Task<IEnumerable<DoctorSchedule>> Random(int Count);
        Task<IEnumerable<DoctorSchedule>> GetPagedList(int pageNumber, int pageSize);
        Task<IEnumerable<ZabotaDoctorInfo>> GetDoctorsInfo();
        Task<bool> AddDoctorInfo(ZabotaDoctorInfo model);
        Task<bool> UpdateDoctorInfo(ZabotaDoctorInfo model);
        Task<bool> DeleteDoctorInfo(int id);
    }
}
