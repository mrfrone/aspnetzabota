using Microsoft.AspNetCore.Mvc;
using aspnetzabota.Web.Common;
using Microsoft.AspNetCore.Authorization;
using aspnetzabota.Web.ViewModels;
using aspnetzabota.Content.Services.Category;
using System.Threading.Tasks;
using aspnetzabota.Content.Datamodel.News;
using Microsoft.AspNetCore.Http;
using aspnetzabota.Content.Services.Upload;
using aspnetzabota.Content.Services.News;
using aspnetzabota.Web.Style;

namespace aspnetzabota.Controllers
{
    [Route("admin/[controller]/[action]")]
    [Authorize]
    public class ArticlesController : BaseController
    {
        private readonly IUpload _upload;
        private readonly ICategory _category;
        private readonly INews _news;
        public ArticlesController(ICategory category, IUpload upload, INews news)
        {
            _category = category;
            _upload = upload;
            _news = news;
        }

        #region Views
        public ViewResult List()
        {
            var result = new ArticlesListViewModel 
            {
                Articles = _news.GetPagedNewsList(1, 6).Result,
                Category = _category.GetCategory().Result,
                PaginationOptions = PaginationStyle.PagedListOptions,
                PagingMethod = nameof(GetAllPaged)
            };

            return View(result);
        }
        public IActionResult GetByCategoryPaged(int id, int? page)
        {
            var pageNumber = page ?? 1;
            var result = new ArticlesListViewModel
            {
                Articles = _news.GetFromNewsCategory(id, pageNumber, 6).Result,
                PaginationOptions = PaginationStyle.PagedListOptionsAjax,
                PagingMethod = nameof(GetByCategoryPaged)
            };
            return PartialView("PagedList", result);
        }
        public IActionResult GetAllPaged(int? page)
        {
            var pageNumber = page ?? 1;
            var result = new ArticlesListViewModel
            {
                Articles = _news.GetPagedNewsList(pageNumber, 6).Result,
                PaginationOptions = PaginationStyle.PagedListOptionsAjax,
                PagingMethod = nameof(GetAllPaged)
            };
            return PartialView("PagedList", result);
        }
        public ViewResult AddArticles()
        {
            var result = new AddArticleViewModel 
            {
                Category = _category.GetCategory().Result
            };

            return View(result);
        }
        #endregion

        #region Methods
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ZabotaNews data)
        {
            var result = await _news.AddNews(data);

            return ZabotaResult(result.IsCorrect);
        }
        [HttpPost]
        public async Task<IActionResult> AddImage()
        {
            IFormFile image = Request.Form.Files["fileInput"];
            var result = await _upload.UploadImage(image, "images/Articles");

            return ZabotaResult(result.IsCorrect);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            var result = await _news.DeleteByID(id);

            return Redirect("/admin/articles/list");
        }
        #endregion
    }
}