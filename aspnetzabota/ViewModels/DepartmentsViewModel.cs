using System.Collections.Generic;
using aspnetzabota.Content.Database.Entities;
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
