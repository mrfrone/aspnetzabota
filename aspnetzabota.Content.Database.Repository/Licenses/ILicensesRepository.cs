using System.Threading.Tasks;

namespace aspnetzabota.Content.Database.Repository.Licenses
{
    public interface ILicensesRepository
    {
        Task<Entities.Licenses[]> Get(bool trackChanges = false);
        Task Add(Entities.Licenses license);
        Task AddPhoto(Entities.LicensesPhoto photo);
        Task Delete(int id);
        Task DeletePhoto(int id);
    }
}
