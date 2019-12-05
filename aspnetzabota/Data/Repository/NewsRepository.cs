using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using aspnetzabota.Data.Interfaces;
using aspnetzabota.Data.Models;

namespace aspnetzabota.Data.Repository
{
    public class NewsRepository : INews
    {
        private readonly AppDBContext appDBContext;

        public NewsRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public IEnumerable<News> Take => appDBContext.News;
        public IEnumerable<News> Last(int Count) => Enumerable.TakeLast(appDBContext.News, Count);
        public IEnumerable<News> TakeFromCategory(int id) => appDBContext.News.Where(c => c.categoryID == id);
        public News Single(int id) => appDBContext.News.FirstOrDefault(p => p.ID == id);
    }
}
