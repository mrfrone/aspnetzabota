using System.Collections.Generic;
using aspnetzabota.Data.Models;
using X.PagedList.Mvc.Common;

namespace aspnetzabota.ViewModels
{
    public class NewsViewModel
    {
        public IEnumerable<News> News { get; set; }
        public IEnumerable<Category> Category { get; set; }
        public PagedListRenderOptionsBase PaginationOptions { get; set; }
    }
}
