using System.Collections.Generic;
using aspnetzabota.Content.Database.Entities;
using aspnetzabota.Content.Datamodel.News;

namespace aspnetzabota.Web.ViewModels
{
    public class FooterViewModel
    {
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<ZabotaNews> News { get; set; }
    }
}
