using Microsoft.AspNetCore.Mvc;
using aspnetzabota.Web.Common;
using Microsoft.AspNetCore.Authorization;
using aspnetzabota.Web.ViewModels;
using aspnetzabota.Content.Services.Category;
using System.Threading.Tasks;
using aspnetzabota.Content.Datamodel.Articles;
using Microsoft.AspNetCore.Http;
using aspnetzabota.Content.Services.Upload;
using aspnetzabota.Content.Services.Articles;
using aspnetzabota.Web.Style;
using aspnetzabota.Content.Services.Department;
using aspnetzabota.Content.Datamodel.Price;
using aspnetzabota.Content.Services.Price;
using aspnetzabota.Content.Services.Licenses;
using aspnetzabota.Content.Datamodel.License;

namespace aspnetzabota.Controllers
{
    [Route("admin/[controller]/[action]")]
    [Authorize]
    public class LicenseSettingsController : BaseController
    {
        private readonly IUpload _upload;
        private readonly ILicenses _licenses;
        public LicenseSettingsController(IUpload upload, ILicenses licenses)
        {
            _upload = upload;
            _licenses = licenses;
        }
        #region Views
        public async Task<ViewResult> List()
        {
            var result = new LicenseSettingsViewModel 
            {
                Licenses = await _licenses.GetLicenses()
            };
            return View(result);
        }
        public async Task<ViewResult> AddLicense()
        {
            var result = new LicenseSettingsViewModel
            {
                Licenses = await _licenses.GetLicenses()
            };
            return View(result);
        }
        #endregion

        #region Methods
        [HttpPost]
        public async Task<IActionResult> AddLicense([FromBody] ZabotaLicenses data)
        {
            var result = await _licenses.AddLicense(data);
            return ZabotaResult(result.IsCorrect);
        }
        [HttpPost]
        public async Task<IActionResult> AddPhoto([FromBody] ZabotaLicensesPhoto data)
        {
            var result = await _licenses.AddPhoto(data);
            return ZabotaResult(result.IsCorrect);
        }
        [HttpPost]
        public async Task<IActionResult> AddImage()
        {
            IFormFile image = Request.Form.Files["fileInput"];
            var result = await _upload.UploadImage(image, "images/Licenses");

            return ZabotaResult(result.IsCorrect);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteLicense(int id)
        {
            await _licenses.DeleteLicense(id);
            return Redirect("/admin/LicenseSettings/List");
        }
        [HttpGet]
        public async Task<IActionResult> DeletePhoto(int id) 
        {
            await _licenses.DeletePhoto(id);
            return Redirect("/admin/LicenseSettings/List");
        }
        #endregion
    }
}