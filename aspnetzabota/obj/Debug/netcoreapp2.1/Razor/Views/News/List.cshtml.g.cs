#pragma checksum "D:\workspace\aspnetzabota\aspnetzabota\aspnetzabota\Views\News\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4cc03cc042978604107683793d3f6729fd3801c8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_News_List), @"mvc.1.0.view", @"/Views/News/List.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/News/List.cshtml", typeof(AspNetCore.Views_News_List))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\workspace\aspnetzabota\aspnetzabota\aspnetzabota\Views\_ViewImports.cshtml"
using aspnetzabota.ViewModels;

#line default
#line hidden
#line 2 "D:\workspace\aspnetzabota\aspnetzabota\aspnetzabota\Views\_ViewImports.cshtml"
using aspnetzabota.Data.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4cc03cc042978604107683793d3f6729fd3801c8", @"/Views/News/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"05f14701c77cb7bf37ae2f831d1db046adad8959", @"/Views/_ViewImports.cshtml")]
    public class Views_News_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NewsListViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(26, 525, true);
            WriteLiteral(@"
<section class=""ftco-section bg-light"">
    <div class=""container"">
        <div class=""row justify-content-center mb-5 pb-2"">
            <div class=""col-md-8 text-center heading-section ftco-animate"">
                <span class=""subheading"">Новости</span>
                <h2 class=""mb-4"">Все новости</h2>
                <p>Separated they live in. A small river named Duden flows by their place and supplies it with the necessary regelialia. It is a paradisematic country</p>
            </div>
        </div>
");
            EndContext();
            BeginContext(593, 27, true);
            WriteLiteral("        <div class=\"row\">\r\n");
            EndContext();
#line 14 "D:\workspace\aspnetzabota\aspnetzabota\aspnetzabota\Views\News\List.cshtml"
              
                foreach (var news in Model.AllNews)
                {


#line default
#line hidden
            BeginContext(710, 163, true);
            WriteLiteral("                    <div class=\"col-md-4 ftco-animate\">\r\n                        <div class=\"blog-entry\">\r\n                            <a href=\"#\" class=\"block-20\"");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 873, "\"", 943, 4);
            WriteAttributeValue("", 881, "background-image:", 881, 17, true);
            WriteAttributeValue(" ", 898, "url(\'", 899, 6, true);
#line 20 "D:\workspace\aspnetzabota\aspnetzabota\aspnetzabota\Views\News\List.cshtml"
WriteAttributeValue("", 904, Url.Content("~/images/image_1.jpg"), 904, 36, false);

#line default
#line hidden
            WriteAttributeValue("", 940, "\');", 940, 3, true);
            EndWriteAttribute();
            BeginContext(944, 130, true);
            WriteLiteral(">\r\n                                <div class=\"meta-date text-center p-2\">\r\n                                    <span class=\"day\">");
            EndContext();
            BeginContext(1075, 28, false);
#line 22 "D:\workspace\aspnetzabota\aspnetzabota\aspnetzabota\Views\News\List.cshtml"
                                                 Write(news.newsDate.ToString("dd"));

#line default
#line hidden
            EndContext();
            BeginContext(1103, 63, true);
            WriteLiteral("</span>\r\n                                    <span class=\"mos\">");
            EndContext();
            BeginContext(1167, 30, false);
#line 23 "D:\workspace\aspnetzabota\aspnetzabota\aspnetzabota\Views\News\List.cshtml"
                                                 Write(news.newsDate.ToString("MMMM"));

#line default
#line hidden
            EndContext();
            BeginContext(1197, 62, true);
            WriteLiteral("</span>\r\n                                    <span class=\"yr\">");
            EndContext();
            BeginContext(1260, 30, false);
#line 24 "D:\workspace\aspnetzabota\aspnetzabota\aspnetzabota\Views\News\List.cshtml"
                                                Write(news.newsDate.ToString("yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(1290, 208, true);
            WriteLiteral("</span>\r\n                                </div>\r\n                            </a>\r\n                            <div class=\"text bg-white p-4\">\r\n                                <h3 class=\"heading\"><a href=\"#\">");
            EndContext();
            BeginContext(1499, 13, false);
#line 28 "D:\workspace\aspnetzabota\aspnetzabota\aspnetzabota\Views\News\List.cshtml"
                                                           Write(news.newsName);

#line default
#line hidden
            EndContext();
            BeginContext(1512, 46, true);
            WriteLiteral("</a></h3>\r\n                                <p>");
            EndContext();
            BeginContext(1559, 19, false);
#line 29 "D:\workspace\aspnetzabota\aspnetzabota\aspnetzabota\Views\News\List.cshtml"
                              Write(news.newsDecription);

#line default
#line hidden
            EndContext();
            BeginContext(1578, 443, true);
            WriteLiteral(@"</p>
                                <div class=""d-flex align-items-center mt-4"">
                                    <p class=""mb-0""><a href=""#"" class=""btn btn-primary"">Подробнее <span class=""ion-ios-arrow-round-forward""></span></a></p>
                                    <p class=""ml-auto mb-0""></p>
                                </div>
                            </div>
                        </div>
                    </div>
");
            EndContext();
#line 37 "D:\workspace\aspnetzabota\aspnetzabota\aspnetzabota\Views\News\List.cshtml"
                }
            

#line default
#line hidden
            BeginContext(2055, 44, true);
            WriteLiteral("        </div>\r\n    </div>\r\n</section>\r\n\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NewsListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
