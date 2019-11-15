using Microsoft.AspNetCore.Mvc;
using aspnetzabota.ViewModels;
using aspnetzabota.Data.Interfaces;

namespace aspnetzabota.Components
{
    public class MenuComponent : ViewComponent
    {
        private readonly IDepartment _departments;

        public MenuComponent(IDepartment departments)
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
