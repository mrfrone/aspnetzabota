using aspnetzabota.Content.Datamodel.License;
using System.Threading.Tasks;

namespace aspnetzabota.Content.Database.Repository.Licenses
{
    public interface ILicensesRepository
    {
        Task<Entities.Licenses[]> Get(bool trackChanges = false);
        Task Add(ZabotaLicenses license);
        Task AddPhoto(ZabotaLicensesPhoto photo);
        Task Delete(int id);
        Task DeletePhoto(int id);
    }
}
