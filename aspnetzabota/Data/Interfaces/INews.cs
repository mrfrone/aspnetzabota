using System.Collections.Generic;
using aspnetzabota.Data.Models;

namespace aspnetzabota.Data.Interfaces
{
    public interface INews
    {
        IEnumerable<News> AllNews { get; }
        IEnumerable<News> AllNewsFromCategory { get; }
        IEnumerable<News> LastNews { get; }
        News getObjectNews(int id); 
    }
}
