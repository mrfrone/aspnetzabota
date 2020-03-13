using aspnetzabota.Common.Result;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace aspnetzabota.Content.Services.Upload
{
    public interface IUpload
    {
        Task UploadImage(IFormFile image, string path);
        void DeleteImage(string path);
    }
}
