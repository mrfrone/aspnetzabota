using aspnetzabota.Common.Result;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace aspnetzabota.Content.Services.Upload
{
    public interface IUpload
    {
        Task<ZabotaResult> UploadImage(IFormFile image, string path);
    }
}
