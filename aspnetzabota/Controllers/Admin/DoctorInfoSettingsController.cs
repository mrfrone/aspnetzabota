using aspnetzabota.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using aspnetzabota.Web.Common;
using Microsoft.AspNetCore.Authorization;
using aspnetzabota.Content.Services.Schedule;
using aspnetzabota.Content.Database.Entities;
using Microsoft.AspNetCore.Http;
using aspnetzabota.Common.Upload;

namespace aspnetzabota.Controllers
{
    [Route("admin/[controller]/[action]")]
    [Authorize]
    public class DoctorInfoSettingsController : BaseController
    {
        private readonly ISchedule _schedule;
        private readonly IUpload _upload;

        public DoctorInfoSettingsController(ISchedule schedule, IUpload upload)
        {
            _schedule = schedule;
            _upload = upload;
        }
        #region Views
        public async Task<ViewResult> List()
        {
            var result = new DoctorInfoSettingsViewModel
            {
                Doctor = await _schedule.Get(true)
            };
            return View(result);
        }
        public async Task<ViewResult> AddDoctorInfo()
        {
            var result = new DoctorInfoSettingsViewModel
            {
                Doctor = await _schedule.Get()
            };
            return View(result);
        }
        public async Task<ViewResult> UpdateDoctorInfo(int id)
        {
            var result = new DoctorInfoSettingsViewModel
            {
                SingleDoctor = await _schedule.Single(id)
            };
            return View(result);
        }
        #endregion

        #region Methods
        [HttpPost]
        public async Task<IActionResult> AddImage()
        {

            IFormFile image = Request.Form.Files["fileInput"];
            await _upload.UploadImage(image, "images/staff");

            return ZabotaResult("");
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ZabotaDoctorInfo model)
        {
            var result = await _schedule.AddDoctorInfo(model);

            return ZabotaResult(result.IsCorrect);
        }
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] ZabotaDoctorInfo model)
        {
            var result = await _schedule.UpdateDoctorInfo(model);

            return ZabotaResult(result.IsCorrect);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteDoctorInfo(int id)
        {
            await _schedule.DeleteDoctorInfo(id);

            return Redirect("/admin/DoctorInfoSettings/" + nameof(List));
        }
        #endregion
    }
}