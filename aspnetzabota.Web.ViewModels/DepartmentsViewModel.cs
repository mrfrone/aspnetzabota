using System.Collections.Generic;
using aspnetzabota.Content.Database.Entities;
using aspnetzabota.Content.Datamodel.Department;

namespace aspnetzabota.Web.ViewModels
{
    public class DepartmentsViewModel
    {
        public IEnumerable<ZabotaDepartment> Departments { get; set; }
        public IEnumerable<Price> Price { get; set; }
        public IEnumerable<PriceGroupsAndDepartmentsModel> PriceGroupsAndDepartments { get; set; }
        public string DepartmentTableID { get; set; }

    }
}
