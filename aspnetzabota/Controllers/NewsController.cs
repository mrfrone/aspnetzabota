using Microsoft.AspNetCore.Mvc;
using aspnetzabota.Data.Interfaces;
using aspnetzabota.ViewModels;
using aspnetzabota.ComponentStyles;

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
        public ViewResult All(int? page)
        {
            var pageNumber = page ?? 1;
            var result = new NewsViewModel
            {
                News = _News.GetPagedList(pageNumber, 6),
                Category = _Category.Take,
                PaginationOptions = PaginationStyle.PagedListOptions
            };
            return View(result);
        }
        private int CurrentID = 1;
        public ActionResult GetByCategory(int? id, int? page)
        {
            var ID = id ?? CurrentID;
            var pageNumber = page ?? 1;
            var result = new NewsViewModel
            {
                News = _News.TakeFromCategory(ID, pageNumber, 6),
                PaginationOptions = PaginationStyle.PagedListOptions
            };
            CurrentID = ID;
            return PartialView(result);
        }
    }
}
