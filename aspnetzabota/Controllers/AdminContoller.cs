using aspnetzabota.Content.Database.Repository.Department;
using aspnetzabota.Content.Services.Price;
using aspnetzabota.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace aspnetzabota.Controllers
{
    public class AdminController : Controller
    {

        public AdminController()
        {

        }
        public ViewResult Login()
        {
            return View();
        }
    }
}