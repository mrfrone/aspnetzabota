using System.Collections.Generic;
using aspnetzabota.Content.Datamodel.Articles;
using aspnetzabota.Content.Datamodel.Department;

namespace aspnetzabota.Web.ViewModels
{
    public class AddArticleViewModel
    {
        public IEnumerable<ZabotaCategory> Category { get; set; }
        public IEnumerable<ZabotaDepartment> Department { get; set; }

    }
}
