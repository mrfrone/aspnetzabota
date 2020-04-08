﻿using aspnetzabota.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using aspnetzabota.Web.Common;
using Microsoft.AspNetCore.Authorization;
using aspnetzabota.Content.Services.Slider;
using Microsoft.AspNetCore.Http;
using aspnetzabota.Content.Datamodel.Slider;
using aspnetzabota.Common.Upload;

namespace aspnetzabota.Controllers
{
    [Route("admin/[controller]/[action]")]
    [Authorize]
    public class SliderSettingsController : BaseController
    {
        private readonly ISlider _slider;
        private readonly IUpload _upload;

        public SliderSettingsController(ISlider slider, IUpload upload)
        {
            _slider = slider;
            _upload = upload;
        }
        public async Task<ViewResult> List()
        {
            var result = new SliderSettingsViewModel
            {
                Slider = await _slider.GetSliders()
            };
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddImage()
        {
            IFormFile image = Request.Form.Files["fileInput"];
            var result = await _upload.UploadImage(image, "images/Slider");

            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddSlider([FromBody] ZabotaSlider model)
        {
            var result = await _slider.AddSliderPhoto(model);

            return Json(result);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteSlider(int id)
        {
            await _slider.DeleteSliderPhoto(id);

            return Redirect("/admin/SliderSettings/" + nameof(List));
        }
    }
}