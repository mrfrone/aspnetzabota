using System.Threading.Tasks;
using aspnetzabota.Content.Database.Context;
using aspnetzabota.Common.EFCore.Extensions;
using Z.EntityFramework.Plus;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using aspnetzabota.Content.Datamodel.Slider;
using aspnetzabota.Common.Upload.UploadPath;

namespace aspnetzabota.Content.Database.Repository.Slider
{
    internal class SliderRepository : ISliderRepository
    {
        private readonly ContentContext _appDBContext;
        private readonly IUploadPath _uploadPath;
        public SliderRepository(ContentContext appDBContext, IUploadPath uploadPath)
        {
            _appDBContext = appDBContext;
            _uploadPath = uploadPath;
        }

        public async Task<Entities.Slider[]> Get(bool trackChanges = false) 
        {
            return await _appDBContext.Sliders
                .HasTracking(trackChanges)
                .OrderByDescending(x => x.Id)
                .ToArrayAsync();
        }
        public async Task Add(ZabotaSlider model)
        {
            var path = _uploadPath.GetPath();

            await _appDBContext.Sliders
                .AddAsync(new Entities.Slider 
            {
                Image = "~/" + path.BaseImagePath + "/" + path.Slider + "/" + model.Image
            });
            _appDBContext.SaveChanges();
        }
        public Task Delete(int id) 
        {
            _appDBContext.Sliders
                .AsQueryable()
                .Where(x => x.Id == id)
                .Delete();
            return _appDBContext.SaveChangesAsync();
        }
    }
}
