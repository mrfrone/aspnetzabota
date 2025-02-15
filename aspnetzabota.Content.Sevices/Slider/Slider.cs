﻿using aspnetzabota.Common.Upload;
using aspnetzabota.Content.Database.Repository.Slider;
using aspnetzabota.Content.Datamodel.Slider;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetzabota.Content.Services.Slider
{
    internal class Slider : ISlider
    {
        private readonly IMapper _mapper;
        private readonly ISliderRepository _sliderRepository;
        private readonly IUpload _upload;

        public Slider(IMapper mapper, ISliderRepository slider, IUpload upload)
        {
            _mapper = mapper;
            _sliderRepository = slider;
            _upload = upload;
        }
        public async Task<IEnumerable<ZabotaSlider>> GetSliders()
        {
            var sliders = await _sliderRepository.Get();
            return _mapper.Map<IEnumerable<ZabotaSlider>>(sliders);
        }
        public async Task<bool> AddSliderPhoto(ZabotaSlider model)
        {
            await _sliderRepository.Add(model);

            return true;
        }
        public async Task<bool> DeleteSliderPhoto(int id)
        {
            var result = await _sliderRepository.Get();
            _upload.DeleteImage(result
                .FirstOrDefault(x => x.Id == id)
                .Image);

            await _sliderRepository.Delete(id);

            return true;
        }
    }
}
