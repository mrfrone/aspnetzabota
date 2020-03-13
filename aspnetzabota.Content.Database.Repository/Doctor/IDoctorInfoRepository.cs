using aspnetzabota.Content.Database.Entities;
using System.Threading.Tasks;

namespace aspnetzabota.Content.Database.Repository.DoctorInfo
{
    public interface IDoctorInfoRepository
    {
        Task<Entities.DoctorInfo[]> Get(bool trackChanges = false);
        Task<Entities.DoctorInfo> GetSingle(int id, bool trackChanges = false);
        Task Add(ZabotaDoctorInfo model);
        Task Update(ZabotaDoctorInfo model);
        Task Delete(int id);
    }
}
