using System.Collections.Generic;
using aspnetzabota.Data;
using X.PagedList.Mvc.Common;

namespace aspnetzabota.ViewModels
{
    public class ReviewsViewModel
    {
        public IEnumerable<Review> Reviews { get; set; }
        public PagedListRenderOptions PaginationOptions { get; set; }
    }
}
