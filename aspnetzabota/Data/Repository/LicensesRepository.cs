using aspnetzabota.Data.Interfaces;
using aspnetzabota.Data.Models;
using System;
using System.Collections.Generic;

namespace aspnetzabota.Data.Repository
{
    public class LicensesRepository : ILicenses
    {
        private static readonly Random random = new Random();
        private readonly AppDBContext appDBContext;

        public LicensesRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public IEnumerable<Licenses> Take => appDBContext.Licenses;
    }
}

