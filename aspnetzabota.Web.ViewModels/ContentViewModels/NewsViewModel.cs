using System.Collections.Generic;
using aspnetzabota.Content.Datamodel.Articles;
using X.PagedList.Mvc.Core.Common;

namespace aspnetzabota.Web.ViewModels
{
    public class NewsViewModel
    {
        public IEnumerable<ZabotaArticles> News { get; set; }
        public IEnumerable<ZabotaCategory> Category { get; set; }
        public PagedListRenderOptions PaginationOptions { get; set; }
        public string PagingMethod { get; set; }
        public ZabotaArticles SingleNews { get; set; }
}
}
