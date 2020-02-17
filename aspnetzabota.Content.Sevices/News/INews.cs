using aspnetzabota.Common.Result;
using aspnetzabota.Content.Datamodel.News;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspnetzabota.Content.Services.News
{
    public interface INews
    {
        Task<IEnumerable<ZabotaNews>> GetLastNews(int Count);
        Task<ZabotaNews> GetSingleNews(int id);
        Task<IEnumerable<ZabotaNews>> GetFromNewsCategory(int id, int pageNumber, int pageSize);
        Task<IEnumerable<ZabotaNews>> GetPagedNewsList(int pageNumber, int pageSize);
        Task<ZabotaResult> AddNews(ZabotaNews news);
    }
}
