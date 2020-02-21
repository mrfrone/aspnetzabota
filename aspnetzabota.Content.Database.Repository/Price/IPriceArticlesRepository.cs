using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspnetzabota.Content.Database.Repository.PriceArticles
{
    public interface IPriceArticlesRepository
    {
        Task<Entities.PriceArticles[]> Get();
    }
}
