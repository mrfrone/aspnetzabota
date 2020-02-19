using Microsoft.AspNetCore.Mvc;
using aspnetzabota.Web.ViewModels;
using aspnetzabota.Web.Style;
using aspnetzabota.Content.Services.Articles;
using aspnetzabota.Content.Services.Category;

namespace aspnetzabota.Controllers
{
    public class NewsController : Controller
    {
        private readonly IArticles _articles;
        private readonly ICategory _category;

        public NewsController(IArticles articles, ICategory category)
        {
            _articles = articles;
            _category = category;
        }
        public ViewResult All()
        {
            var result = new NewsViewModel
            {
                News = _articles.GetPagedArticlesList(1, 6).Result,
                Category = _category.GetCategory().Result,
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
                News = _articles.GetFromArticleCategory(id, pageNumber, 6).Result,
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
                News = _articles.GetPagedArticlesList(pageNumber, 6).Result,
                PaginationOptions = PaginationStyle.PagedListOptionsAjax,
                PagingMethod = nameof(GetAllPaged)
            };
            return PartialView("PagingNews", result);
        }
        public ViewResult Single(int id)
        {
            var result = new NewsViewModel 
            {
                SingleNews = _articles.GetSingleArticle(id).Result
            };
            return View(result);
        }
    }
}
