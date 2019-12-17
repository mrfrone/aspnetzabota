using System.Collections.Generic;

namespace aspnetzabota.Content.Database.Repository.Slider
{
    public interface ISlider
    {
        IEnumerable<Entities.Slider> Take { get; }
    }
}
