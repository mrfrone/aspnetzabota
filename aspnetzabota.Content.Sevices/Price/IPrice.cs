using aspnetzabota.Content.Datamodel.Price;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspnetzabota.Content.Services.Price
{
    public interface IPrice
     {
        Task<IEnumerable<ZabotaPrice>> Get();
        Task<IEnumerable<ZabotaPriceGroupsAndDepartments>> GroupsAndDepartments();
        Task<IEnumerable<ZabotaPriceGroupsAndDepartments>> PriceDepartments(int id);
        Task<IEnumerable<ZabotaPrice>> FromGroup(int id);
        Task<IEnumerable<ZabotaPrice>> FromDepartment(string id);
        Task<IEnumerable<ZabotaPrice>> FromSearch(string id);
        Task<bool> AddPriceArticle(ZabotaPriceArticles article);
        Task<IEnumerable<ZabotaPriceArticles>> GetPriceArticles();
        Task DeletePriceArticle(int id);
     }
}
