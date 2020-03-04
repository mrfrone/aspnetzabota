using aspnetzabota.Content.Services.Department;
using aspnetzabota.Content.Services.Price;
using aspnetzabota.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<ViewResult> Main()
        {
            var result = new DepartmentsViewModel
            {
                Departments = await _departments.GetDepartments(),
                Price = _price.Get,
                PriceGroupsAndDepartments = _price.GroupsAndDepartments
            };
            return View(result);
        }
        //do this async
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