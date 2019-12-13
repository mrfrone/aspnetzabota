using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using aspnetzabota.Data.Interfaces;
using aspnetzabota.Data.Models;
using X.PagedList;

namespace aspnetzabota.Data.Repository
{
    public class NewsRepository : INews
    {
        private readonly AppDBContext appDBContext;

        public NewsRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public IEnumerable<News> Last(int Count) => appDBContext.News.OrderByDescending(x => x.Date).Take(Count);   
        public News Single(int id) => appDBContext.News.FirstOrDefault(p => p.ID == id);
        public IEnumerable<News> TakeFromCategory(int? id, int pageNumber, int pageSize) => appDBContext.News.Where(c => c.categoryID == id).
            OrderByDescending(x => x.Date).ToPagedList(pageNumber, pageSize);
        public IEnumerable<News> GetPagedList(int pageNumber, int pageSize) => appDBContext.News.Include(p => p.Category).
            OrderByDescending(x => x.Date).ToPagedList(pageNumber, pageSize);

    }
}
