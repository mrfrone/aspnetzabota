using aspnetzabota.Common.EFCore.Extensions;
using aspnetzabota.Content.Database.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace aspnetzabota.Content.Database.Repository.Category
{
    internal class CategoryRepository : ICategoryRepository
    {
        private readonly ContentContext appDBContext;

        public CategoryRepository(ContentContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<Entities.Category[]> Get(bool trackChanges = false) 
        { 
            return await appDBContext
                .Category
                .HasTracking(trackChanges)
                .ToArrayAsync();
        }
    }
}
