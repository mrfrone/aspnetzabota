using aspnetzabota.Content.Datamodel.Slider;
using System.Threading.Tasks;

namespace aspnetzabota.Content.Database.Repository.Slider
{
    public interface ISliderRepository
    {
        Task<Entities.Slider[]> Get(bool trackChanges = false);
        Task Add(ZabotaSlider model);
        Task Delete(int id);
    }
}
