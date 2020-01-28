using System.Collections.Generic;
using aspnetzabota.Content.Datamodel.Department;
using aspnetzabota.Content.Datamodel.News;

namespace aspnetzabota.Web.ViewModels
{
    public class FooterViewModel
    {
        public IEnumerable<ZabotaDepartment> Departments { get; set; }
        public IEnumerable<ZabotaNews> News { get; set; }
    }
}
