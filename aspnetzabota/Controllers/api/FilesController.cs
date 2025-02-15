﻿using Microsoft.AspNetCore.Mvc;
using aspnetzabota.Web.Common;
using Microsoft.AspNetCore.Authorization;
using aspnetzabota.Common.Upload;

namespace aspnetzabota.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class FilesController : BaseController
    {
        private readonly IUpload _upload;
        public FilesController(IUpload upload)
        {
            _upload = upload;
        }
        [HttpPost]
        public IActionResult DeleteImage([FromBody] string path)
        {
            _upload.DeleteImage(path);

            return Json("");
        }
    }
}