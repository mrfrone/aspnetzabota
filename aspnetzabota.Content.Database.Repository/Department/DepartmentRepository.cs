using System.Collections.Generic;
using aspnetzabota.Content.Database.Context;

namespace aspnetzabota.Content.Database.Repository.Department
{
    public class DepartmentRepository : IDepartment
    {
        private readonly ContentContext appDBContext;

        public DepartmentRepository(ContentContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public IEnumerable<Entities.Department> Take => appDBContext.Departments;
    }
}
