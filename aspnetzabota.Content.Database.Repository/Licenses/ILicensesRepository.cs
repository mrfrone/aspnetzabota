using System.Threading.Tasks;

namespace aspnetzabota.Content.Database.Repository.Licenses
{
    public interface ILicensesRepository
    {
        Task<Entities.Licenses[]> Get();
    }
}
