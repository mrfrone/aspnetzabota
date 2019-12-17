using aspnetzabota.Data.Interfaces;
using aspnetzabota.Content.Database.Entities;
using System.Collections.Generic;

namespace aspnetzabota.Data.Repository
{
    public class CategoryRepository : INewsCategory
    {
        private readonly ContentContext appDBContext;

        public CategoryRepository(ContentContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        
        public IEnumerable<Category> Take => appDBContext.Category;
    }
}
