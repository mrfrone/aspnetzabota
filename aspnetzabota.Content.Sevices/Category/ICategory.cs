using System.Collections.Generic;
using System.Threading.Tasks;
using aspnetzabota.Content.Datamodel.Articles;

namespace aspnetzabota.Content.Services.Category
{
    public interface ICategory
    {
        Task<IEnumerable<ZabotaCategory>> GetCategory();
    }
}
