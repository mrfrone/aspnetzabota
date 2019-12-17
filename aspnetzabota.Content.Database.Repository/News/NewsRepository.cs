using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using aspnetzabota.Content.Database.Context;
using X.PagedList;

namespace aspnetzabota.Content.Database.Repository.News
{
    internal class NewsRepository : INews
    {
        private readonly ContentContext appDBContext;

        public NewsRepository(ContentContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public IEnumerable<Entities.News> Last(int Count) => appDBContext.News.OrderByDescending(x => x.Date).Take(Count);   
        public Entities.News Single(int id) => appDBContext.News.FirstOrDefault(p => p.ID == id);
        public IEnumerable<Entities.News> TakeFromCategory(int id, int pageNumber, int pageSize) => 
            appDBContext.News.
            Where(c => c.categoryID == id).
            OrderByDescending(x => x.Date).
            ToPagedList(pageNumber, pageSize);
        public IEnumerable<Entities.News> GetPagedList(int pageNumber, int pageSize) => 
            appDBContext.News.
            Include(p => p.Category).
            OrderByDescending(x => x.Date).
            ToPagedList(pageNumber, pageSize);

    }
}
