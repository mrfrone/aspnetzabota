﻿using aspnetzabota.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using aspnetzabota.Web.Common;
using Microsoft.AspNetCore.Authorization;
using aspnetzabota.Content.Services.Schedule;
using aspnetzabota.Content.Database.Entities;
using Microsoft.AspNetCore.Http;
using aspnetzabota.Common.Upload;
using aspnetzabota.Common.Upload.UploadPath;

namespace aspnetzabota.Controllers
{
    [Route("admin/[controller]/[action]")]
    [Authorize]
    public class DoctorInfoSettingsController : BaseController
    {
        private readonly ISchedule _schedule;
        private readonly IUpload _upload;
        private readonly IUploadPath _uploadPath;

        public DoctorInfoSettingsController(ISchedule schedule, IUpload upload, IUploadPath uploadPath)
        {
            _schedule = schedule;
            _upload = upload;
            _uploadPath = uploadPath;
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
            var path = _uploadPath.GetPath();

            IFormFile image = Request.Form.Files["fileInput"];
            var result = await _upload.UploadImage(image, path.BaseImagePath + "/" + path.Staff);

            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ZabotaDoctorInfo model)
        {
            var result = await _schedule.AddDoctorInfo(model);

            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] ZabotaDoctorInfo model)
        {
            var result = await _schedule.UpdateDoctorInfo(model);

            return Json(result);
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