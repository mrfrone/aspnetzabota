﻿using Microsoft.AspNetCore.Mvc;
using aspnetzabota.Web.ViewModels;
using aspnetzabota.Content.Services.Articles;
using aspnetzabota.Content.Services.Department;

namespace aspnetzabota.Components
{
    public class Footer : ViewComponent
    {
        private readonly IDepartment _departments;
        private readonly IArticles _news;

        public Footer(IDepartment departments, IArticles news)
        {
            _departments = departments;
            _news = news;
        }
        public IViewComponentResult Invoke()
        {
            var result = new FooterViewModel
            {
                Departments = _departments.GetDepartments().Result,
                News = _news.GetLastNews(2).Result
            };
            return View(result);
        }
    }
}
