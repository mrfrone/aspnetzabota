using X.PagedList.Mvc.Core;
using X.PagedList.Mvc.Common;
using System.Collections.Generic;

namespace aspnetzabota.ViewModels
{
    public static class PaginationViewModel
    {
        public static PagedListRenderOptionsBase PagedListOptions => new PagedListRenderOptionsBase() {
                LiElementClasses = new List<string> { "page-item" },
                PageClasses = new string[] { "page-link" },
                UlElementClasses = new List<string> { "pagination" },
                ContainerDivClasses = new List<string> { "nav text-xs-center", "justify-content-center" },
                LinkToPreviousPageFormat = "Назад",
                LinkToNextPageFormat = "Вперед",
                DisplayLinkToPreviousPage = PagedListDisplayMode.Always,
                DisplayLinkToNextPage = PagedListDisplayMode.Always
            };
    }
}

