using System.Threading.Tasks;

namespace aspnetzabota.Content.Database.Repository.Category
{
    public interface ICategoryRepository
    {
        Task<Entities.Category[]> Get();
    }
}
