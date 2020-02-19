using System.Collections.Generic;
using aspnetzabota.Content.Datamodel.Department;
using aspnetzabota.Content.Datamodel.Articles;

namespace aspnetzabota.Web.ViewModels
{
    public class FooterViewModel
    {
        public IEnumerable<ZabotaDepartment> Departments { get; set; }
        public IEnumerable<ZabotaArticles> News { get; set; }
    }
}
