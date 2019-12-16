using System.Collections.Generic;
using aspnetzabota.Data.Interfaces;
using aspnetzabota.Data;

namespace aspnetzabota.Data.Repository
{
    public class SliderRepository : ISlider
    {
        private readonly AppDBContext appDBContext;

        public SliderRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public IEnumerable<Slider> Take => appDBContext.Sliders;
    }
}
