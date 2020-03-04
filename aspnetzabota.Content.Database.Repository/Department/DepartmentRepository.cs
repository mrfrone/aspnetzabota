using System.Threading.Tasks;
using aspnetzabota.Common.EFCore.Extensions;
using aspnetzabota.Content.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace aspnetzabota.Content.Database.Repository.Department
{
    internal class DepartmentRepository : IDepartmentRepository
    {
        private readonly ContentContext appDBContext;

        public DepartmentRepository(ContentContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public async Task<Entities.Department[]> Get(bool trackChanges = false)
        { 
            return await appDBContext
                .Departments
                .HasTracking(trackChanges)
                .Include(u => u.Articles)
                .ToArrayAsync(); 
        }
    }
}
