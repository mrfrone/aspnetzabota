using Microsoft.AspNetCore.Mvc;
using aspnetzabota.Web.Common;
using Microsoft.AspNetCore.Authorization;
using aspnetzabota.Web.ViewModels;
using aspnetzabota.Content.Services.Category;
using System.Threading.Tasks;
using aspnetzabota.Content.Datamodel.News;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace aspnetzabota.Controllers
{
    [Route("admin/[controller]/[action]")]
    [Authorize]
    public class ArticlesController : BaseController
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ICategory _category;
        public ArticlesController(ICategory category, IHostingEnvironment hostingEnvironment)
        {
            _category = category;
            _hostingEnvironment = hostingEnvironment;
        }
        public ViewResult List()
        {
            return View();
        }
        public ViewResult AddArticles()
        {
            var result = new AddArticleViewModel {
                Category = _category.GetCategory().Result
            };

            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ZabotaNews data)
        {
            
            return ZabotaResult(true);
        }
        public async Task<IActionResult> AddImage()
        {
            IFormFile image = Request.Form.Files["fileInput"];
            if (image != null)
            {
                using (var fileStream = new FileStream(Path.Combine(_hostingEnvironment.WebRootPath, "images", "Articles", image.FileName), FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
            } 

            return ZabotaResult(true);
        }
    }
}