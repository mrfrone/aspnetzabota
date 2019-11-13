using aspnetzabota.Data.Models;
using System.Collections.Generic;
using System.Linq;
using aspnetzabota.Data.Interfaces;

namespace aspnetzabota.Data.Mapping
{
    public static class NewsMapping
    {
        public static IEnumerable<News> TakeFromCategory(int catid, IEnumerable<News> Model) => Model.Where(c => c.categoryID == catid);
        public static News Single(int id, IEnumerable<News> Model) => Model.FirstOrDefault(p => p.ID == id);

    }
}
