using aspnetzabota.Common.Result;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using aspnetzabota.Common.Result.ErrorCodes;

namespace aspnetzabota.Content.Services.Upload
{
    internal class Upload : IUpload
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public Upload(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task<ZabotaResult> UploadImage(IFormFile image, string path)
        {
            if (image != null)
            {
                using (var fileStream = new FileStream(Path.Combine(_hostingEnvironment.WebRootPath, path, image.FileName), FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
                return new ZabotaResult();
            }
            return ZabotaErrorCodes.FileIsEmpty;
        }
    }
}
