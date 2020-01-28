using aspnetzabota.Content.Datamodel.Slider;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspnetzabota.Content.Services.Slider
{
    public interface ISlider
    {
        Task<IEnumerable<ZabotaSlider>> GetSliders();
    }
}
