using System.Collections.Generic;
using aspnetzabota.Content.Datamodel.Articles;

namespace aspnetzabota.Web.ViewModels
{
    public class AddArticleViewModel
    {
        public IEnumerable<ZabotaCategory> Category { get; set; }

    }
}
