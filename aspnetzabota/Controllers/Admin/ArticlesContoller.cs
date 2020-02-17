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
        public ViewResult List()
        {
            return View();
        }
        public ViewResult AddArticles()
        {
            var result = new AddArticleViewModel 
            {
                Category = _category.GetCategory().Result
            };

            return View(result);
        }
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
    }
}