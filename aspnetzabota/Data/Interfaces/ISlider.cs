﻿using aspnetzabota.Data;
using System.Collections.Generic;

namespace aspnetzabota.Data.Interfaces
{
    public interface ISlider
    {
        IEnumerable<Slider> Take { get; }
    }
}
