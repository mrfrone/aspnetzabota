using aspnetzabota.Data.Models;
using System.Collections.Generic;

namespace aspnetzabota.Data.Interfaces
{
    public interface ISlider
    {
        IEnumerable<Slider> AllSliders { get; }
    }
}
