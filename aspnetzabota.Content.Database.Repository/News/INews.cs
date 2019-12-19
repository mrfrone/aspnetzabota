using System.Collections.Generic;

namespace aspnetzabota.Content.Database.Repository.News
{
    public interface INews
    {
        IEnumerable<Entities.News> Last(int Count);
        IEnumerable<Entities.News> TakeFromCategory(int id, int pageNumber, int pageSize);
        Entities.News Single(int id);
        IEnumerable<Entities.News> GetPagedList(int pageNumber, int pageSize);
    }
}
