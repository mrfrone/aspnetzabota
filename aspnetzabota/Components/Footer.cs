using Microsoft.AspNetCore.Mvc;
using aspnetzabota.ViewModels;
using aspnetzabota.Data.Interfaces;

namespace aspnetzabota.Components
{
    public class Footer : ViewComponent
    {
        private readonly IDepartment _departments;
        private readonly INews _news;

        public Footer(IDepartment departments, INews news)
        {
            _departments = departments;
            _news = news;
        }
        public IViewComponentResult Invoke()
        {
            var result = new FooterViewModel
            {
                Departments = _departments.Take,
                News = _news.Last(2)
            };
            return View(result);
        }
    }
}
