using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using aspnetzabota.Content.Database.Context;
using X.PagedList;
using aspnetzabota.Common.EFCore.Extensions;

namespace aspnetzabota.Content.Database.Repository.News
{
    public class News
    {
        private readonly ContentContext appDBContext;

        public News(ContentContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public IEnumerable<Entities.News> Last(int Count, bool trackChanges = false) => appDBContext.News.HasTracking(trackChanges).
                OrderByDescending(x => x.Date).
                Take(Count);
        public Entities.News Single(int id, bool trackChanges = false) => appDBContext.News.FirstOrDefault(p => p.ID == id);
        public IEnumerable<Entities.News> TakeFromCategory(int id, int pageNumber, int pageSize, bool trackChanges = false) =>
            appDBContext.News.
            HasTracking(trackChanges).
            Where(c => c.categoryID == id).
            OrderByDescending(x => x.Date).
            ToPagedList(pageNumber, pageSize);
        public IEnumerable<Entities.News> GetPagedList(int pageNumber, int pageSize, bool trackChanges = false) => 
            appDBContext.News.
            HasTracking(trackChanges).
            Include(p => p.Category).
            OrderByDescending(x => x.Date).
            ToPagedList(pageNumber, pageSize);

    }
}
