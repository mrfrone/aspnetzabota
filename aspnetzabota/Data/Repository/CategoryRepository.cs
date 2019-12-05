using aspnetzabota.Data.Interfaces;
using aspnetzabota.Data.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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
