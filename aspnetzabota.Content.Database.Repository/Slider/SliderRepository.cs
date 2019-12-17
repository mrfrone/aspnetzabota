using System.Collections.Generic;
using aspnetzabota.Content.Database.Context;

namespace aspnetzabota.Content.Database.Repository.Slider
{
    public class SliderRepository : ISlider
    {
        private readonly ContentContext appDBContext;

        public SliderRepository(ContentContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public IEnumerable<Entities.Slider> Take => appDBContext.Sliders;
    }
}
