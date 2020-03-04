using aspnetzabota.Content.Services.Licenses;
using aspnetzabota.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<ViewResult> License()
        {
            var result = new LicensesViewModel
            {
                Licenses = await _licenses.GetLicenses()
            };
            return View(result);
        }
    }
}