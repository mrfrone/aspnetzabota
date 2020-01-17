using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspnetzabota.Content.Database.Repository.Slider
{
    public interface ISliderRepository
    {
        Task<Entities.Slider[]> Get(bool trackChanges = false);
    }
}
