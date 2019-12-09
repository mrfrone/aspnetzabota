using Microsoft.AspNetCore.Mvc;
using aspnetzabota.Data.Interfaces;
using aspnetzabota.ViewModels;
using aspnetzabota.ComponentStyles;

namespace aspnetzabota.Controllers
{
    public class NewsController : Controller
    {
        private readonly INews _News;
        private readonly INewsCategory _allserviceCategory;

        public NewsController(INews iNews, INewsCategory iServiceCat)
        {
            _News = iNews;
            _allserviceCategory = iServiceCat;
        }
        public ViewResult All(int? page)
        {
            var pageNumber = page ?? 1;
            var result = new NewsViewModel
            {
                News = _News.GetPagedList(pageNumber, 6),
                PaginationOptions = PaginationStyle.PagedListOptions
            };
            return View(result);
        }
    }
}
