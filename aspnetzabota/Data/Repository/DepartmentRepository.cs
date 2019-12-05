using aspnetzabota.Data.Interfaces;
using aspnetzabota.Data.Models;
using System.Collections.Generic;
namespace aspnetzabota.Data.Repository
{
    public class DepartmentRepository : IDepartment
    {
        private readonly AppDBContext appDBContext;

        public DepartmentRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public IEnumerable<Department> Take => appDBContext.Departments;
    }
}
