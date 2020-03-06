using aspnetzabota.Content.Datamodel.Articles;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspnetzabota.Content.Database.Repository.Articles
{
    public interface IArticlesRepository
    {
        Task<Entities.Articles[]> GetLast(int Count, bool trackChanges = false);
        Task<Entities.Articles> GetSingle(int id, bool trackChanges = false);
        Task<Entities.Articles[]> GetFromCategory(int id, bool trackChanges = false);
        Task<Entities.Articles[]> GetList(bool trackChanges = false);
        Task Add(ZabotaArticles model);
        Task Delete(int id);
    }
}
