using aspnetzabota.Data.Interfaces;
using aspnetzabota.Data.Models;
using System.Collections.Generic;
namespace aspnetzabota.Data.Repository
{
    public class DepartmentRepository : IDepartment
    {
        private readonly AppDBContent appDBContent;

        public DepartmentRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Department> Take => appDBContent.Departments;
    }
}
