using System.Linq;
using System.Threading.Tasks;
using aspnetzabota.Common.EFCore.Extensions;
using aspnetzabota.Content.Database.Context;
using aspnetzabota.Content.Datamodel.Department;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace aspnetzabota.Content.Database.Repository.Department
{
    internal class DepartmentRepository : IDepartmentRepository
    {
        private readonly ContentContext _appDBContext;

        public DepartmentRepository(ContentContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        public async Task<Entities.Department[]> Get(bool trackChanges = false)
        { 
            return await _appDBContext
                .Departments
                .HasTracking(trackChanges)
                .Include(u => u.Articles)
                .ToArrayAsync(); 
        }
        public Task Add(ZabotaDepartment model)
        {
            _appDBContext.Departments
                .Add(new Entities.Department 
            {
                Id = model.Id,
                ShortName = model.ShortName,
                Description = model.Description,
                DepartmentPriceID = model.DepartmentPriceID
            });

            return _appDBContext.SaveChangesAsync();
        }
        public Task Delete(int id)
        {
            _appDBContext.Departments
                .AsQueryable()
                .Where(d => d.Id == id)
                .Delete();

            return _appDBContext.SaveChangesAsync();
        }
    }
}
