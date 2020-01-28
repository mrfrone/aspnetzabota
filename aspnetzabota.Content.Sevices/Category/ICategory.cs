using System.Collections.Generic;
using System.Threading.Tasks;
using aspnetzabota.Content.Datamodel.News;

namespace aspnetzabota.Content.Services.Category
{
    public interface ICategory
    {
        Task<IEnumerable<ZabotaCategory>> GetCategory();
    }
}
