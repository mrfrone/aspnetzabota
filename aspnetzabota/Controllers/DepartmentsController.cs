using aspnetzabota.Content.Services.Department;
using aspnetzabota.Content.Services.Price;
using aspnetzabota.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace aspnetzabota.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartment _departments;
        private readonly IPrice _price;

        public DepartmentsController(IDepartment departments, IPrice price)
        {
            _departments = departments;
            _price = price;
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
        public ActionResult PriceFromDepartment(string name, string tableid)
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