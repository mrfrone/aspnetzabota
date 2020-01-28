using System.Collections.Generic;
using aspnetzabota.Content.Datamodel.Department;

namespace aspnetzabota.Web.ViewModels
{
    public class MenuViewModel
    {
        public IEnumerable<ZabotaDepartment> Departments { get; set; }
    }
}
