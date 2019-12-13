using Microsoft.AspNetCore.Mvc;
using aspnetzabota.Data.Interfaces;
using aspnetzabota.ViewModels;
using aspnetzabota.ComponentStyles;
using System.Collections.Generic;

namespace aspnetzabota.Controllers
{
    public class NewsController : Controller
    {
        private readonly INews _News;
        private readonly INewsCategory _Category;

        public NewsController(INews iNews, INewsCategory iServiceCat)
        {
            _News = iNews;
            _Category = iServiceCat;
        }
        public ViewResult All()
        {
            var result = new NewsViewModel
            {
                News = _News.GetPagedList(1, 3),
                Category = _Category.Take,
                PaginationOptions = PaginationStyle.PagedListOptions,
                PagingMethod = nameof(GetAllPaged)
            };
            return View(result);
        }
        public ActionResult GetByCategoryPaged(int? id, int? page)
        {
            var pageNumber = page ?? 1;
            var result = new NewsViewModel
            {
                News = _News.TakeFromCategory(id, pageNumber, 3),
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
                News = _News.GetPagedList(pageNumber, 3),
                PaginationOptions = PaginationStyle.PagedListOptionsAjax,
                PagingMethod = nameof(GetAllPaged)
            };
            return PartialView("PagingNews", result);
        }
    }
}
