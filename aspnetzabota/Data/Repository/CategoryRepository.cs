using aspnetzabota.Data.Interfaces;
using aspnetzabota.Data.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace aspnetzabota.Data.Repository
{
    public class CategoryRepository : INewsCategory
    {
        private readonly AppDBContext appDBContent;

        public CategoryRepository(AppDBContext appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        
        public IEnumerable<Category> Take => appDBContent.Category;
    }
}
