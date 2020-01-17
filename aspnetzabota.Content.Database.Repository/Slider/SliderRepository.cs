using System.Threading.Tasks;
using aspnetzabota.Content.Database.Context;
using aspnetzabota.Common.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace aspnetzabota.Content.Database.Repository.Slider
{
    public class SliderRepository : ISliderRepository
    {
        private readonly ContentContext appDBContext;

        public SliderRepository(ContentContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public Task<Entities.Slider[]> Get(bool trackChanges = false) 
        {
            return appDBContext.Sliders
                .HasTracking(trackChanges)
                .ToArrayAsync();
        }
    }
}
