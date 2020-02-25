using System.Collections.Generic;
using aspnetzabota.Content.Datamodel.Articles;

namespace aspnetzabota.Web.ViewModels
{
    public class PriceArticlesViewModel
    {
        public IEnumerable<ZabotaArticles> Articles { get; set; }
    }
}
