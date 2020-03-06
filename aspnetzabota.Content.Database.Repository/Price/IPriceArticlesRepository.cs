using aspnetzabota.Content.Datamodel.Price;
using System.Threading.Tasks;

namespace aspnetzabota.Content.Database.Repository.PriceArticles
{
    public interface IPriceArticlesRepository
    {
        Task<Entities.PriceArticles[]> Get(bool trackChanges = false);
        Task Add(ZabotaPriceArticles price);
        Task Delete(int id);
    }
}
