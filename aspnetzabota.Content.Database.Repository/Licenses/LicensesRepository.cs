using aspnetzabota.Content.Database.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace aspnetzabota.Content.Database.Repository.Licenses
{
    public class LicensesRepository : ILicenses
    {
        private readonly ContentContext appDBContext;

        public LicensesRepository(ContentContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public IEnumerable<Entities.Licenses> Take => appDBContext.Licenses.Include(u => u.photo);
    }
}

