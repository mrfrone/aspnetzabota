using System.Linq;
using Microsoft.EntityFrameworkCore;
using aspnetzabota.Content.Database.Context;
using aspnetzabota.Common.EFCore.Extensions;
using System.Threading.Tasks;

namespace aspnetzabota.Content.Database.Repository.News
{
    internal class NewsRepository : INewsRepository
    {
        private readonly ContentContext _appDBContext;

        public NewsRepository(ContentContext appDBContext)
        {
            this._appDBContext = appDBContext;
        }
        public Task<Entities.News[]> GetLast(int Count, bool trackChanges = false)
        {
            return _appDBContext.News
                .HasTracking(trackChanges)
                .OrderByDescending(x => x.Date)
                .Take(Count).ToArrayAsync();
        }
        public Task<Entities.News> GetSingle(int id, bool trackChanges = false) 
        { 
            return _appDBContext.News
                .HasTracking(trackChanges)
                .FirstOrDefaultAsync(p => p.ID == id); 
        }
        public Task<Entities.News[]> GetFromCategory(int id, bool trackChanges = false)
        {
            return _appDBContext.News
                .HasTracking(trackChanges)
                .Where(c => c.categoryID == id)
                .OrderByDescending(x => x.Date)
                .ToArrayAsync();
        }
        public Task<Entities.News[]> GetList(bool trackChanges = false)
        {
            return _appDBContext.News
            .HasTracking(trackChanges)
            .Include(p => p.Category)
            .OrderByDescending(x => x.Date)
            .ToArrayAsync();
        }

    }
}
