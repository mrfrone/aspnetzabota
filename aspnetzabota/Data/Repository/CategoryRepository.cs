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
        
        //TODO: use AsNoTracking if you dont want change database entity
        public IEnumerable<Category> AllCategories => appDBContent.Category.AsNoTracking();
    }
}
