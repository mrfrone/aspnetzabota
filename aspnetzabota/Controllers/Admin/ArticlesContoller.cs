using Microsoft.AspNetCore.Mvc;
using aspnetzabota.Web.Common;
using Microsoft.AspNetCore.Authorization;
using aspnetzabota.Web.ViewModels;
using aspnetzabota.Content.Services.Category;
using System.Threading.Tasks;
using aspnetzabota.Content.Datamodel.Articles;
using Microsoft.AspNetCore.Http;
using aspnetzabota.Content.Services.Upload;
using aspnetzabota.Content.Services.Articles;
using aspnetzabota.Web.Style;
using aspnetzabota.Content.Services.Department;
using aspnetzabota.Content.Datamodel.Price;
using aspnetzabota.Content.Services.Price;

namespace aspnetzabota.Controllers
{
    [Route("admin/[controller]/[action]")]
    [Authorize]
    public class ArticlesController : BaseController
    {
        private readonly IUpload _upload;
        private readonly ICategory _category;
        private readonly IArticles _articles;
        private readonly IDepartment _department;
        private readonly IPrice _price;
        public ArticlesController(ICategory category, IUpload upload, IArticles articles, IDepartment department, IPrice price)
        {
            _category = category;
            _upload = upload;
            _articles = articles;
            _department = department;
            _price = price;
        }

        #region Views
        public async Task<ViewResult> List()
        {
            var result = new ArticlesListViewModel 
            {
                Articles = await _articles.GetPagedArticlesList(1, 6),
                Category = await _category.GetCategory(),
                PaginationOptions = PaginationStyle.PagedListOptions,
                PagingMethod = nameof(GetAllPaged)
            };

            return View(result);
        }
        public async Task<IActionResult> GetByCategoryPaged(int id, int? page)
        {
            var pageNumber = page ?? 1;
            var result = new ArticlesListViewModel
            {
                Articles = await _articles.GetFromArticleCategory(id, pageNumber, 6),
                PaginationOptions = PaginationStyle.PagedListOptionsAjax,
                PagingMethod = nameof(GetByCategoryPaged)
            };
            return PartialView("PagedList", result);
        }
        public async Task<IActionResult> GetAllPaged(int? page)
        {
            var pageNumber = page ?? 1;
            var result = new ArticlesListViewModel
            {
                Articles = await _articles.GetPagedArticlesList(pageNumber, 6),
                PaginationOptions = PaginationStyle.PagedListOptionsAjax,
                PagingMethod = nameof(GetAllPaged)
            };
            return PartialView("PagedList", result);
        }
        public async Task<ViewResult> AddArticles()
        {
            var result = new AddArticleViewModel 
            {
                Category = await _category.GetCategory(),
                Department = await _department.GetDepartments()
            };

            return View(result);
        }
        public async Task<ViewResult> AddPrice()
        {
            var result = new AddPriceArticlesViewModel
            {
                Articles = await _articles.GetAllArticlesList()
            };
            return View(result);
        }
        // do this async
        public ViewResult PriceHelp()
        {
            var result = new PriceHelpViewModel
            {
                Price = _price.Get
            };
            return View(result);
        }
        public async Task<ViewResult> PriceList()
        {
            var result = new PriceArticlesListViewModel
            {
                PriceArticles =  await _price.GetPriceArticles()
            };
            return View(result);
        }
        #endregion

        #region Methods
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ZabotaArticles data)
        {
            var result = await _articles.AddArticle(data);

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
            await _articles.DeleteArticleByID(id);
            return Redirect("/admin/articles/"+nameof(List));

        }
        [HttpGet]
        public async Task<IActionResult> DeletePriceArticle(int id)
        {
            await _price.DeletePriceArticle(id);
            return Redirect("/admin/articles/" + nameof(PriceList));
        }
        [HttpPost]
        public async Task<IActionResult> AddLink([FromBody] ZabotaPriceArticles data)
        {
            var result = await _price.AddPriceArticle(data);
            return ZabotaResult(result.IsCorrect);
        }
        #endregion
    }
}