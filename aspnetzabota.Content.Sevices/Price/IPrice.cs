using aspnetzabota.Common.Result;
using aspnetzabota.Content.Datamodel.Price;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspnetzabota.Content.Services.Price
{
     public interface IPrice
     {
        IEnumerable<ZabotaPrice> Get { get; }
        IEnumerable<ZabotaPriceGroupsAndDepartments> GroupsAndDepartments { get; }
        IEnumerable<ZabotaPriceGroupsAndDepartments> PriceDepartments(int id);
        IEnumerable<ZabotaPrice> FromGroup(int id);
        IEnumerable<ZabotaPrice> FromDepartment(string id);
        IEnumerable<ZabotaPrice> FromSearch(string id);
        Task<ZabotaResult> AddPriceArticle(ZabotaPriceArticles article);
        Task<IEnumerable<ZabotaPriceArticles>> GetPriceArticles();
        Task DeletePriceArticle(int id);
     }
}
