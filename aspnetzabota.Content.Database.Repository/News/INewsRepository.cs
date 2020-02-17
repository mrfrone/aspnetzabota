using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspnetzabota.Content.Database.Repository.News
{
    public interface INewsRepository
    {
        Task<Entities.News[]> GetLast(int Count, bool trackChanges = false);
        Task<Entities.News> GetSingle(int id, bool trackChanges = false);
        Task<Entities.News[]> GetFromCategory(int id, bool trackChanges = false);
        Task<Entities.News[]> GetList(bool trackChanges = false);
        Task Add(Entities.News news);
    }
}
