using aspnetzabota.Web.Common;
using Microsoft.AspNetCore.Mvc;

namespace aspnetzabota.Controllers
{
    public class ErrorsController : BaseController
    {
        public ViewResult PageNotFound()
        {
            return View();
        }
        public ViewResult InternalServerError()
        {
            return View();
        }
    }
}