using System.Collections.Generic;
using aspnetzabota.Data.Models;

namespace aspnetzabota.Data.Interfaces
{
    public interface INews
    {
        IEnumerable<News> Take { get; }
        IEnumerable<News> Last(int Count);
        IEnumerable<News> TakeFromCategory(int id);
        News Single(int id);
        IEnumerable<News> GetPagedList(int pageNumber, int pageSize);
    }
}
