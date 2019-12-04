using System.Collections.Generic;
using aspnetzabota.Data.Models;
using X.PagedList.Mvc.Common;

namespace aspnetzabota.ViewModels
{
    public class ReviewsViewModel
    {
        public IEnumerable<Review> Reviews { get; set; }
        public PagedListRenderOptionsBase PaginationOptions { get; set; }
    }
}
