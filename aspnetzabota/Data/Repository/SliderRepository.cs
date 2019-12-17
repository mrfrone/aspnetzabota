using System.Collections.Generic;
using aspnetzabota.Data.Interfaces;
using aspnetzabota.Content.Database.Entities;

namespace aspnetzabota.Data.Repository
{
    public class SliderRepository : ISlider
    {
        private readonly ContentContext appDBContext;

        public SliderRepository(ContentContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public IEnumerable<Slider> Take => appDBContext.Sliders;
    }
}
