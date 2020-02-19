using System.Collections.Generic;
using aspnetzabota.Content.Datamodel.Articles;
using X.PagedList.Mvc.Core.Common;

namespace aspnetzabota.Web.ViewModels
{
    public class ArticlesListViewModel
    {
        public IEnumerable<ZabotaCategory> Category { get; set; }

        public IEnumerable<ZabotaArticles> Articles { get; set; }
        public PagedListRenderOptions PaginationOptions { get; set; }
        public string PagingMethod { get; set; }

    }
}
