﻿using aspnetzabota.Content.Database.Entities;
using System.Collections.Generic;

namespace aspnetzabota.Web.ViewModels
{
    public class PriceServiceViewModel
    {
        public IEnumerable<Price> PriceService { get; set; }
        public IEnumerable<PriceGroupsAndDepartmentsModel> PriceServiceDep { get; set; }
    }
}