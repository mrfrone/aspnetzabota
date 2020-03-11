﻿using System.Threading.Tasks;
using aspnetzabota.Content.Database.Context;
using aspnetzabota.Common.EFCore.Extensions;
using Z.EntityFramework.Plus;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using aspnetzabota.Content.Datamodel.Slider;

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
                .OrderByDescending(x => x.Id)
                .ToArrayAsync();
        }
        public async Task Add(ZabotaSlider model)
        {
            await _appDBContext.Sliders.AddAsync(new Entities.Slider 
            {
                Image = "~/images/Slider/" + model.Image
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
