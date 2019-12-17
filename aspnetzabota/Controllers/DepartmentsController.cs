using aspnetzabota.Content.Database.Repository.Department;
using aspnetzabota.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace aspnetzabota.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartment _departments;
        private readonly Data.Interfaces.IPriceService _price;

        public DepartmentsController(IDepartment departments, Data.Interfaces.IPriceService price)
        {
            _departments = departments;
            _price = price;
        }
        public ViewResult Main()
        {
            var result = new DepartmentsViewModel
            {
                Departments = _departments.Take,
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