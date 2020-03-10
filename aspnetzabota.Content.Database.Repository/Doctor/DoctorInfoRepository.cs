using aspnetzabota.Common.EFCore.Extensions;
using aspnetzabota.Content.Database.Context;
using aspnetzabota.Content.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace aspnetzabota.Content.Database.Repository.DoctorInfo
{
    internal class DoctorInfoRepository : IDoctorInfoRepository
    {
        private readonly ContentContext _appDBContext;

        public DoctorInfoRepository(ContentContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        public async Task<Entities.DoctorInfo[]> Get(bool trackChanges = false) 
        {
            return await _appDBContext
                .Doctor
                .HasTracking(trackChanges)
                .ToArrayAsync();
        }
        public Task Add(ZabotaDoctorInfo model)
        {
            _appDBContext.Add(new Entities.DoctorInfo
            {
                Id = model.Id,
                Photo = "~/images/staff/" + model.Photo,
                Description = model.Description,
                DoctorId = model.DoctorId
            });
            return _appDBContext.SaveChangesAsync();
        }
        public Task Delete(int id)
        {
            _appDBContext.Doctor
                .AsQueryable()
                .Where(x => x.Id == id)
                .Delete();
            return _appDBContext.SaveChangesAsync();
        }
    }
}

