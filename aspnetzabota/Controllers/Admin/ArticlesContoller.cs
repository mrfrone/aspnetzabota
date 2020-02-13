using aspnetzabota.Admin.Forms.Login;
using aspnetzabota.Admin.Services.Login;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using aspnetzabota.Web.Common;
using aspnetzabota.Web.Common.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace aspnetzabota.Controllers
{
    [Route("admin/[controller]/[action]")]
    [Authorize]
    public class ArticlesController : BaseController
    {
        public ArticlesController()
        {
            
        }
        public ViewResult List()
        {
            return View();
        }
        public ViewResult AddArticles()
        {
            return View();
        }
    }
}