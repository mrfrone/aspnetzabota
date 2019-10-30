using Microsoft.AspNetCore.Mvc;
using aspnetzabota.Data.Interfaces;
using aspnetzabota.ViewModels;

namespace aspnetzabota.Controllers
{
    public class NewsController : Controller
    {
        private readonly INews _allNews;
        private readonly INewsCategory _allserviceCategory;

        public NewsController(INews iAllNews, INewsCategory iServiceCat)
        {
            _allNews = iAllNews;
            _allserviceCategory = iServiceCat;
        }
        public ViewResult List()
        {
            var result = new NewsViewModel
            {
                AllNews = _allNews.AllNews,
                CurrentCategory = "Новости вот такие вот"
            };
            return View(result);
        }
    }
}
