using aspnetzabota.Content.Database.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace aspnetzabota.Content.Database.Repository.Licenses
{
    internal class LicensesRepository : ILicensesRepository
    {
        private readonly ContentContext appDBContext;

        public LicensesRepository(ContentContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public async Task<Entities.Licenses[]> Get() 
        { 
            return await appDBContext
                .Licenses
                .Include(u => u.Photo)
                .ToArrayAsync(); 
        }
    }
}

