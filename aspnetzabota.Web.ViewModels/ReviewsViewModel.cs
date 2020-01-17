using System.Collections.Generic;
using aspnetzabota.Content.Datamodel.Review;
using X.PagedList.Mvc.Core.Common;

namespace aspnetzabota.Web.ViewModels
{
    public class ReviewsViewModel
    {
        public IEnumerable<ZabotaReview> Reviews { get; set; }
        public PagedListRenderOptions PaginationOptions { get; set; }
    }
}
