using Microsoft.AspNetCore.Mvc;
using aspnetzabota.Web.ViewModels;
using aspnetzabota.Web.Style;
using aspnetzabota.Content.Services.Articles;
using aspnetzabota.Content.Services.Category;
using System.Threading.Tasks;

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
        public async Task<ViewResult> All()
        {
            var result = new NewsViewModel
            {
                News = await _articles.GetPagedArticlesList(1, 6),
                Category = await _category.GetCategory(),
                PaginationOptions = PaginationStyle.PagedListOptions,
                PagingMethod = nameof(GetAllPaged)
            };
            return View(result);
        }
        public async Task<IActionResult> GetByCategoryPaged(int id, int? page)
        {
            var pageNumber = page ?? 1;
            var result = new NewsViewModel
            {
                News = await _articles.GetFromArticleCategory(id, pageNumber, 6),
                PaginationOptions = PaginationStyle.PagedListOptionsAjax,
                PagingMethod = nameof(GetByCategoryPaged)
            };
            return PartialView("PagingNews", result);
        }
        public async Task<IActionResult> GetAllPaged(int? page)
        {
            var pageNumber = page ?? 1;
            var result = new NewsViewModel
            {
                News = await _articles.GetPagedArticlesList(pageNumber, 6),
                PaginationOptions = PaginationStyle.PagedListOptionsAjax,
                PagingMethod = nameof(GetAllPaged)
            };
            return PartialView("PagingNews", result);
        }
        public async Task<ViewResult> Single(int id)
        {
            var result = new NewsViewModel 
            {
                SingleNews = await _articles.GetSingleArticle(id)
            };
            return View(result);
        }
    }
}
