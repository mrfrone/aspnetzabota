using aspnetzabota.Data.Interfaces;
using aspnetzabota.Data;
using System.Collections.Generic;

namespace aspnetzabota.Data.Repository
{
    public class CategoryRepository : INewsCategory
    {
        private readonly AppDBContext appDBContext;

        public CategoryRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        
        public IEnumerable<Category> Take => appDBContext.Category;
    }
}
