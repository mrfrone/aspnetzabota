using Microsoft.AspNetCore.Mvc;
using aspnetzabota.Web.ViewModels;
using aspnetzabota.Content.Database.Repository.Department;

namespace aspnetzabota.Components
{
    public class Menu : ViewComponent
    {
        private readonly IDepartment _departments;

        public Menu(IDepartment departments)
        {
            _departments = departments;
        }
        public IViewComponentResult Invoke()
        {
            var result = new MenuViewModel
            {
                Departments = _departments.Take
            };
            return View(result);
        }
    }
}
