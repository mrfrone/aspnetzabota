using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace aspnetzabota.Common.Upload
{
    internal class Upload : IUpload
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public Upload(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task UploadImage(IFormFile image, string path)
        {
                using (var fileStream = new FileStream(Path.Combine(_hostingEnvironment.WebRootPath, path, image.FileName), FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
        }
        public void DeleteImage(string path)
        {
            var fullpath = _hostingEnvironment.WebRootPath + PathConvert(path);
            if (File.Exists(fullpath))
                File.Delete(fullpath);
        }
        private string PathConvert(string path)
        {
            path = path.Remove(0, 1);
            path = path.Replace("/","\\");

            return path;
        }
    }
}
