using aspnetzabota.Common.Result;
using aspnetzabota.Content.Datamodel.Price;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspnetzabota.Content.Services.Price
{
    public interface IPriceArticles
     {
        Task<ZabotaResult> AddPriceArticle(ZabotaPriceArticles article);
        Task<IEnumerable<ZabotaPriceArticles>> GetPriceArticles();
     }
}
