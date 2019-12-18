using System.Collections.Generic;

namespace aspnetzabota.Content.Database.Repository.News
{
    public interface INews
    {
        IEnumerable<Entities.News> Last(int Count, bool trackChanges = false);
        IEnumerable<Entities.News> TakeFromCategory(int id, int pageNumber, int pageSize, bool trackChanges = false);
        Entities.News Single(int id, bool trackChanges = false);
        IEnumerable<Entities.News> GetPagedList(int pageNumber, int pageSize, bool trackChanges = false);
    }
}
