using System.Collections.Generic;
using aspnetzabota.Data.Interfaces;
using aspnetzabota.Data.Models;

namespace aspnetzabota.Data.Repository
{
    public class SliderRepository : ISlider
    {
        private readonly AppDBContent appDBContext;

        public SliderRepository(AppDBContent appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public IEnumerable<Slider> Take => appDBContext.Sliders;
    }
}
