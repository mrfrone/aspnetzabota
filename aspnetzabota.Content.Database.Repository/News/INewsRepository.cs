using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspnetzabota.Content.Database.Repository.News
{
    public interface INewsRepository
    {
        Task<Entities.Articles[]> GetLast(int Count, bool trackChanges = false);
        Task<Entities.Articles> GetSingle(int id, bool trackChanges = false);
        Task<Entities.Articles[]> GetFromCategory(int id, bool trackChanges = false);
        Task<Entities.Articles[]> GetList(bool trackChanges = false);
        Task Add(Entities.Articles news);
        Task Delete(int id);
    }
}
