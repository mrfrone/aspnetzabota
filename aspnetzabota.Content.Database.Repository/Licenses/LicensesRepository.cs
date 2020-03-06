using aspnetzabota.Common.EFCore.Extensions;
using aspnetzabota.Content.Database.Context;
using aspnetzabota.Content.Datamodel.License;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace aspnetzabota.Content.Database.Repository.Licenses
{
    internal class LicensesRepository : ILicensesRepository
    {
        private readonly ContentContext _appDBContext;

        public LicensesRepository(ContentContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        public async Task<Entities.Licenses[]> Get(bool trackChanges = false) 
        { 
            return await _appDBContext
                .Licenses
                .HasTracking(trackChanges)
                .Include(u => u.Photo)
                .ToArrayAsync(); 
        }
        public Task Add(ZabotaLicenses model)
        {
            _appDBContext.Licenses.Add(new Entities.Licenses
            {
                Id = model.Id,
                Name = model.Name
            });
            return _appDBContext.SaveChangesAsync();
        }
        public Task AddPhoto(ZabotaLicensesPhoto model)
        {
            _appDBContext.LicensesPhoto.Add(new Entities.LicensesPhoto
            {
                Path = "~/images/Licenses/" + model.Path,
                LicensesId = model.LicensesId
            });
            return _appDBContext.SaveChangesAsync();
        }
        // todo: take this delete method to all repositories
        public Task Delete(int id)
        {
            _appDBContext.LicensesPhoto
                 .AsQueryable()
                 .Where(p => p.LicensesId == id)
                 .Delete();

            _appDBContext.Licenses
                 .AsQueryable()
                 .Where(p => p.Id == id)
                 .Delete();
            return _appDBContext.SaveChangesAsync();
        }
        public Task DeletePhoto(int id)
        {
            _appDBContext.LicensesPhoto
                 .AsQueryable()
                 .Where(p => p.Id == id)
                 .Delete();
            return _appDBContext.SaveChangesAsync();
        }
    }
}

