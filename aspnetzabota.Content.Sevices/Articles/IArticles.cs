using aspnetzabota.Common.Result;
using aspnetzabota.Content.Datamodel.Articles;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspnetzabota.Content.Services.Articles
{
    public interface IArticles
    {
        Task<IEnumerable<ZabotaArticles>> GetLastNews(int Count);
        Task<ZabotaArticles> GetSingleArticle(int id);
        Task<IEnumerable<ZabotaArticles>> GetFromArticleCategory(int id, int pageNumber, int pageSize);
        Task<IEnumerable<ZabotaArticles>> GetPagedArticlesList(int pageNumber, int pageSize);
        Task<ZabotaResult> AddArticle(ZabotaArticles news);
        Task<ZabotaResult> DeleteArticleByID(int id);
    }
}
