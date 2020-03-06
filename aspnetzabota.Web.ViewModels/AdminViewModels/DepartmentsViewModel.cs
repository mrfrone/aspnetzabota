using System.Collections.Generic;
using aspnetzabota.Content.Datamodel.Department;
using aspnetzabota.Content.Datamodel.Articles;
using aspnetzabota.Content.Datamodel.Price;

namespace aspnetzabota.Web.ViewModels
{
    public class DepartmentSettingsViewModel
    {
        public IEnumerable<ZabotaDepartment> Departments { get; set; }
        public IEnumerable<ZabotaPriceGroupsAndDepartments> PriceGroupsAndDepartments { get; set; }

    }
}
