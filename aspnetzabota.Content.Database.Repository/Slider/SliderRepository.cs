using System.Threading.Tasks;
using aspnetzabota.Content.Database.Context;
using aspnetzabota.Common.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace aspnetzabota.Content.Database.Repository.Slider
{
    internal class SliderRepository : ISliderRepository
    {
        private readonly ContentContext _appDBContext;

        public SliderRepository(ContentContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public async Task<Entities.Slider[]> Get(bool trackChanges = false) 
        {
            return await _appDBContext.Sliders
                .HasTracking(trackChanges)
                .ToArrayAsync();
        }
    }
}
