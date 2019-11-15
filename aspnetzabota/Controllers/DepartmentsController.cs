using aspnetzabota.Data.Interfaces;
using aspnetzabota.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace aspnetzabota.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartment _departments;

        public DepartmentsController(IDepartment departments)
        {
            _departments = departments;
        }
        public ViewResult Depart()
        {
            var result = new DepartmentsViewModel
            {
                Departments = _departments.Take
            };
            return View(result);
        }
    }
}