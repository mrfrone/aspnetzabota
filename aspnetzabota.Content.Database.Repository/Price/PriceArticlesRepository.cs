using aspnetzabota.Common.EFCore.Extensions;
using aspnetzabota.Content.Database.Context;
using aspnetzabota.Content.Datamodel.Price;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace aspnetzabota.Content.Database.Repository.PriceArticles
{
    internal class PriceArticlesRepository : IPriceArticlesRepository
    {
        private readonly ContentContext _appDBContext;

        public PriceArticlesRepository(ContentContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        public async Task<Entities.PriceArticles[]> Get(bool trackChanges = false) 
        {
            return await _appDBContext
                .PriceArticles
                .HasTracking(trackChanges)
                .Include(c => c.Article)
                .ToArrayAsync();
        }
        public Task Add(ZabotaPriceArticles model)
        {
            _appDBContext.PriceArticles
                .Add(new Entities.PriceArticles
            {
                Id = model.Id,
                PriceId = model.PriceId,
                ArticleId = model.ArticleId
            });
            return _appDBContext.SaveChangesAsync();
        }
        public Task Delete(int id)
        {
            _appDBContext.PriceArticles
                .AsQueryable()
                .Where(x => x.Id == id)
                .Delete();
            return _appDBContext.SaveChangesAsync();
        }
    }
}

