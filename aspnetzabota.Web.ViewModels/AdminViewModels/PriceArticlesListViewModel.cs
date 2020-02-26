using System.Collections.Generic;
using aspnetzabota.Content.Datamodel.Price;

namespace aspnetzabota.Web.ViewModels
{
    public class PriceArticlesListViewModel
    {
        public IEnumerable<ZabotaPriceArticles> PriceArticles { get; set; }
    }
}
