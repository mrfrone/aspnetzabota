using aspnetzabota.Data.Interfaces;
using aspnetzabota.ViewModels;
using Microsoft.AspNetCore.Mvc;
using aspnetzabota.ComponentStyles;
using aspnetzabota.Content.Database.Entities;

namespace aspnetzabota.Controllers
{
    public class PagesController : Controller
    {
        private readonly ILicenses _licenses;

        public PagesController(ILicenses licenses)
        {
            _licenses = licenses;
        }
        public ViewResult ContactUs()
        {
            return View();
        }
        public ViewResult RegulatoryOrg()
        {
            return View();
        }
        public ViewResult OMS()
        {
            return View();
        }
        public ViewResult License()
        {
            var result = new LicensesViewModel
            {
                Licenses = _licenses.Take
            };
            return View(result);
        }
    }
}