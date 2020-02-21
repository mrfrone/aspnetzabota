using aspnetzabota.Content.Database.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace aspnetzabota.Content.Database.Repository.PriceArticles
{
    internal class PriceArticlesRepository : IPriceArticlesRepository
    {
        private readonly ContentContext _appDBContext;

        public PriceArticlesRepository(ContentContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        public async Task<Entities.PriceArticles[]> Get() 
        {
            return await _appDBContext
                .PriceArticles
                .Include(c => c.Article)
                .ToArrayAsync();
        }
    }
}

