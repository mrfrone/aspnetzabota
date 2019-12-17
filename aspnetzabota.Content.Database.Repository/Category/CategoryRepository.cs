using aspnetzabota.Content.Database.Context;
using System.Collections.Generic;

namespace aspnetzabota.Content.Database.Repository.Category
{
    public class CategoryRepository : ICategory
    {
        private readonly ContentContext appDBContext;

        public CategoryRepository(ContentContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        
        public IEnumerable<Entities.Category> Take => appDBContext.Category;
    }
}
