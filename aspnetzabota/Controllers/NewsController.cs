using aspnetzabota.Content.Database.Repository.News;
using aspnetzabota.Content.Database.Repository.Category;
using Microsoft.AspNetCore.Mvc;
using aspnetzabota.Web.ViewModels;
using aspnetzabota.Web.Style;
using aspnetzabota.Content.Services.News;

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
                News = _News.GetPagedNewsList(1, 3).Result,
                Category = _Category.Take,
                PaginationOptions = PaginationStyle.PagedListOptions,
                PagingMethod = nameof(GetAllPaged)
            };
            return View(result);
        }
        public ActionResult GetByCategoryPaged(int id, int? page)
        {
            var pageNumber = page ?? 1;
            var result = new NewsViewModel
            {
                News = _News.GetFromNewsCategory(id, pageNumber, 3).Result,
                PaginationOptions = PaginationStyle.PagedListOptionsAjax,
                PagingMethod = nameof(GetByCategoryPaged)
            };
            return PartialView("PagingNews", result);
        }
        public ActionResult GetAllPaged(int? page)
        {
            var pageNumber = page ?? 1;
            var result = new NewsViewModel
            {
                News = _News.GetPagedNewsList(pageNumber, 3).Result,
                PaginationOptions = PaginationStyle.PagedListOptionsAjax,
                PagingMethod = nameof(GetAllPaged)
            };
            return PartialView("PagingNews", result);
        }
    }
}
