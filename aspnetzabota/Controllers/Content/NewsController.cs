using Microsoft.AspNetCore.Mvc;
using aspnetzabota.Web.ViewModels;
using aspnetzabota.Web.Style;
using aspnetzabota.Content.Services.News;
using aspnetzabota.Content.Services.Category;

namespace aspnetzabota.Controllers
{
    public class NewsController : Controller
    {
        private readonly INews _News;
        private readonly ICategory _Category;

        public NewsController(INews iNews, ICategory iServiceCat)
        {
            _News = iNews;
            _Category = iServiceCat;
        }
        public ViewResult All()
        {
            var result = new NewsViewModel
            {
                News = _News.GetPagedNewsList(1, 6).Result,
                Category = _Category.GetCategory().Result,
                PaginationOptions = PaginationStyle.PagedListOptions,
                PagingMethod = nameof(GetAllPaged)
            };
            return View(result);
        }
        public IActionResult GetByCategoryPaged(int id, int? page)
        {
            var pageNumber = page ?? 1;
            var result = new NewsViewModel
            {
                News = _News.GetFromNewsCategory(id, pageNumber, 6).Result,
                PaginationOptions = PaginationStyle.PagedListOptionsAjax,
                PagingMethod = nameof(GetByCategoryPaged)
            };
            return PartialView("PagingNews", result);
        }
        public IActionResult GetAllPaged(int? page)
        {
            var pageNumber = page ?? 1;
            var result = new NewsViewModel
            {
                News = _News.GetPagedNewsList(pageNumber, 6).Result,
                PaginationOptions = PaginationStyle.PagedListOptionsAjax,
                PagingMethod = nameof(GetAllPaged)
            };
            return PartialView("PagingNews", result);
        }
        public ViewResult Single(int id)
        {
            var result = new NewsViewModel 
            {
                SingleNews = _News.GetSingleNews(id).Result
            };
            return View(result);
        }
    }
}
