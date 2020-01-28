﻿using System.Collections.Generic;
using aspnetzabota.Content.Database.Entities;
using aspnetzabota.Content.Datamodel.News;
using X.PagedList.Mvc.Core.Common;

namespace aspnetzabota.Web.ViewModels
{
    public class NewsViewModel
    {
        public IEnumerable<ZabotaNews> News { get; set; }
        public IEnumerable<ZabotaCategory> Category { get; set; }
        public PagedListRenderOptions PaginationOptions { get; set; }
        public string PagingMethod { get; set; }
    }
}
