﻿using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace aspnetzabota.Common.Upload
{
    public interface IUpload
    {
        Task<string> UploadImage(IFormFile image, string path);
        void DeleteImage(string path);
    }
}
