using aspnetzabota.Common.EFCore.Extensions;
using aspnetzabota.Common.Upload.UploadPath;
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
        private readonly IUploadPath _uploadPath;

        public LicensesRepository(ContentContext appDBContext, IUploadPath uploadPath)
        {
            _appDBContext = appDBContext;
            _uploadPath = uploadPath;
        }
        public async Task<Entities.Licenses[]> Get(bool trackChanges = false) 
        { 
            return await _appDBContext
                .Licenses
                .HasTracking(trackChanges)
                .Include(u => u.Photo)
                .ToArrayAsync(); 
        }
        public async Task<Entities.Licenses> GetSingleLicense(int id, bool trackChanges = false)
        {
            return await _appDBContext
                .Licenses
                .HasTracking(trackChanges)
                .Include(u =>u.Photo)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Entities.LicensesPhoto> GetSinglePhoto(int id, bool trackChanges = false)
        {
            return await _appDBContext
                .LicensesPhoto
                .HasTracking(trackChanges)
                .FirstOrDefaultAsync(x => x.Id == id);
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
            var path = _uploadPath.GetPath();

            _appDBContext.LicensesPhoto.Add(new Entities.LicensesPhoto
            {
                Path = "~/" + path.BaseImagePath + "/" + path.Licenses + "/" + model.Path,
                LicensesId = model.LicensesId
            });
            return _appDBContext.SaveChangesAsync();
        }
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

