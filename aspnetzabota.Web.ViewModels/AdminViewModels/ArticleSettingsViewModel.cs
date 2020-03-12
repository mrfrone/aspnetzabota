using System.Collections.Generic;
using aspnetzabota.Content.Datamodel.Articles;
using aspnetzabota.Content.Datamodel.Department;
using aspnetzabota.Content.Datamodel.Price;
using X.PagedList.Mvc.Core.Common;

namespace aspnetzabota.Web.ViewModels
{
    public class ArticleSettingsViewModel
    {
        public IEnumerable<ZabotaCategory> Category { get; set; }
        public IEnumerable<ZabotaArticles> Articles { get; set; }
        public IEnumerable<ZabotaDepartment> Department { get; set; }
        public IEnumerable<ZabotaPrice> Price { get; set; }
        public IEnumerable<ZabotaPriceArticles> PriceArticles { get; set; }
        public PagedListRenderOptions PaginationOptions { get; set; }
        public string PagingMethod { get; set; }

    }
}
