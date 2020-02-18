using System.Collections.Generic;
using aspnetzabota.Content.Datamodel.News;

namespace aspnetzabota.Web.ViewModels
{
    public class AddArticleViewModel
    {
        public IEnumerable<ZabotaCategory> Category { get; set; }

    }
}
