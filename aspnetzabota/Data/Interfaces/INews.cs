using System.Collections.Generic;
using aspnetzabota.Data;
namespace aspnetzabota.Data.Interfaces
{
    public interface INews
    {
        IEnumerable<News> Last(int Count);
        IEnumerable<News> TakeFromCategory(int id, int pageNumber, int pageSize);
        News Single(int id);
        IEnumerable<News> GetPagedList(int pageNumber, int pageSize);
    }
}
