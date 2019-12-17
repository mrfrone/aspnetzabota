using aspnetzabota.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace aspnetzabota.Data.Repository
{
    public class LicensesRepository : ILicenses
    {
        private readonly ContentContext appDBContext;

        public LicensesRepository(ContentContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public IEnumerable<Licenses> Take => appDBContext.Licenses.Include(u => u.photo);
    }
}

