using System.Collections.Generic;
using aspnetzabota.Content.Database.Entities;
using X.PagedList.Mvc.Common;

namespace aspnetzabota.ViewModels
{
    public class NewsViewModel
    {
        public IEnumerable<News> News { get; set; }
        public IEnumerable<Category> Category { get; set; }
        public PagedListRenderOptions PaginationOptions { get; set; }
        public string PagingMethod { get; set; }
    }
}
