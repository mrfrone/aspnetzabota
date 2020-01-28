using aspnetzabota.Content.Database.Repository.Slider;
using aspnetzabota.Content.Datamodel.Slider;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspnetzabota.Content.Services.Slider
{
    internal class Slider : ISlider
    {
        private readonly IMapper _mapper;
        private readonly ISliderRepository _sliderRepository;

        public Slider(IMapper mapper, ISliderRepository slider)
        {
            _mapper = mapper;
            _sliderRepository = slider;
        }
        public async Task<IEnumerable<ZabotaSlider>> GetSliders()
        {
            var sliders = await _sliderRepository.Get();
            return _mapper.Map<IEnumerable<ZabotaSlider>>(sliders);
        }
    }
}
