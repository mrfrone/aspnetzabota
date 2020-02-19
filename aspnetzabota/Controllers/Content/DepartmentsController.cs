using aspnetzabota.Content.Services.Department;
using aspnetzabota.Content.Services.News;
using aspnetzabota.Content.Services.Price;
using aspnetzabota.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace aspnetzabota.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartment _departments;
        private readonly IPrice _price;
        private readonly INews _news;

        public DepartmentsController(IDepartment departments, IPrice price, INews news)
        {
            _departments = departments;
            _price = price;
            _news = news;
        }
        public ViewResult Main()
        {
            var result = new DepartmentsViewModel
            {
                Departments = _departments.GetDepartments().Result,
                Price = _price.Take,
                PriceGroupsAndDepartments = _price.GroupsAndDepartments
            };
            return View(result);
        }
        public IActionResult PriceFromDepartment(string name, string tableid)
        {
            var result = new DepartmentsViewModel
            {
                Price = _price.FromDepartment(name),
                DepartmentTableID = tableid
            };
            return PartialView(result);
        }
    }
}