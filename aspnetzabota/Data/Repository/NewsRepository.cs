using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using aspnetzabota.Data.Interfaces;
using aspnetzabota.Data.Models;

namespace aspnetzabota.Data.Repository
{
    public class NewsRepository : INews
    {
        private readonly AppDBContext appDBContent;

        public NewsRepository(AppDBContext appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<News> AllNews => appDBContent.News;

        public IEnumerable<News> AllNewsFromCategory => appDBContent.News.Include(c => c.Category);
        
        public IEnumerable<News> LastNews => appDBContent.News.AsNoTracking().TakeLast(3); //todo: if you want to EF generate SQL query, use LINQ like this, not Enumerable

        public News getObjectNews(int newsID) => appDBContent.News.FirstOrDefault(p => p.ID == newsID);
    }
}
