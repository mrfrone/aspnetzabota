using System.Collections.Generic;
using aspnetzabota.Content.Database.Entities;
using X.PagedList.Mvc.Core.Common;

namespace aspnetzabota.Web.ViewModels
{
    public class ReviewsViewModel
    {
        public IEnumerable<Review> Reviews { get; set; }
        public PagedListRenderOptions PaginationOptions { get; set; }
    }
}
