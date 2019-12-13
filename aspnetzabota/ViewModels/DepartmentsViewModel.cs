using System.Collections.Generic;
using aspnetzabota.Data.Models;

namespace aspnetzabota.ViewModels
{
    public class DepartmentsViewModel
    {
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Price> Price { get; set; }
        public IEnumerable<PriceGroupsAndDepartmentsModel> PriceGroupsAndDepartments { get; set; }
        public string DepartmentTableID { get; set; }

    }
}
