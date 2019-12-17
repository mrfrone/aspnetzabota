using aspnetzabota.Data.Interfaces;
using System.Collections.Generic;
using aspnetzabota.Content.Database.Entities;

namespace aspnetzabota.Data.Repository
{
    public class DepartmentRepository : IDepartment
    {
        private readonly ContentContext appDBContext;

        public DepartmentRepository(ContentContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public IEnumerable<Department> Take => appDBContext.Departments;
    }
}
