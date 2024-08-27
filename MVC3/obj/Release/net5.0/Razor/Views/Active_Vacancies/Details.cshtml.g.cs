#pragma checksum "D:\RS-project\MVC3\Views\Active_Vacancies\Details.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "27e85aa73d3826c57b8be1f925992126c6032cc3eb312d7162cf84b62a4e2d04"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Active_Vacancies_Details), @"mvc.1.0.view", @"/Views/Active_Vacancies/Details.cshtml")]
namespace AspNetCore
{
    #line default
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\RS-project\MVC3\Views\_ViewImports.cshtml"
using MVC3

#nullable disable
    ;
#nullable restore
#line 2 "D:\RS-project\MVC3\Views\_ViewImports.cshtml"
using MVC3.Models

#nullable disable
    ;
#nullable restore
#line 3 "D:\RS-project\MVC3\Views\_ViewImports.cshtml"
using MVC3.Areas.Access.Models

#nullable disable
    ;
#nullable restore
#line 4 "D:\RS-project\MVC3\Views\_ViewImports.cshtml"
using MVC3.ViewModels

#line default
#line hidden
#nullable disable
    ;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"27e85aa73d3826c57b8be1f925992126c6032cc3eb312d7162cf84b62a4e2d04", @"/Views/Active_Vacancies/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"d259f7c13c13f7ee8d95791ff1b9d9fde0f838b88391073e1611469cd461365e", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Active_Vacancies_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<activeVacanciesViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "New_Applicants", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\RS-project\MVC3\Views\Active_Vacancies\Details.cshtml"
  
    ViewData["Title"] = "Details";
    var vacancyId = Model.vacancyid;

#line default
#line hidden
#nullable disable

            WriteLiteral("\r\n<h1>Details for Vacancy ");
            Write(
#nullable restore
#line 8 "D:\RS-project\MVC3\Views\Active_Vacancies\Details.cshtml"
                         vacancyId

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</h1>\r\n\r\n\r\n<div>\r\n    <h4>Vacancy</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            Vacancy Name\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            Write(
#nullable restore
#line 19 "D:\RS-project\MVC3\Views\Active_Vacancies\Details.cshtml"
             Html.DisplayFor(model => model.vacancyname)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Total Vacancy Count\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            Write(
#nullable restore
#line 25 "D:\RS-project\MVC3\Views\Active_Vacancies\Details.cshtml"
             Html.DisplayFor(model => model.TotalVacancyCount)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Title Name\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            Write(
#nullable restore
#line 31 "D:\RS-project\MVC3\Views\Active_Vacancies\Details.cshtml"
             Html.DisplayFor(model => model.TitleName)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Active\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            Write(
#nullable restore
#line 37 "D:\RS-project\MVC3\Views\Active_Vacancies\Details.cshtml"
             Html.DisplayFor(model => model.Active)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Locations:\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n");
#nullable restore
#line 43 "D:\RS-project\MVC3\Views\Active_Vacancies\Details.cshtml"
             foreach (var location in Model.locations.Distinct())
            {

#line default
#line hidden
#nullable disable

            WriteLiteral("                <p>");
            Write(
#nullable restore
#line 45 "D:\RS-project\MVC3\Views\Active_Vacancies\Details.cshtml"
                    location.LocationName

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</p>\r\n");
#nullable restore
#line 46 "D:\RS-project\MVC3\Views\Active_Vacancies\Details.cshtml"
            }

#line default
#line hidden
#nullable disable

            WriteLiteral("        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "27e85aa73d3826c57b8be1f925992126c6032cc3eb312d7162cf84b62a4e2d047501", async() => {
                WriteLiteral("Apply");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-vacancyId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
            WriteLiteral(
#nullable restore
#line 51 "D:\RS-project\MVC3\Views\Active_Vacancies\Details.cshtml"
                                                                                 Model.vacancyid

#line default
#line hidden
#nullable disable
            );
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["vacancyId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-vacancyId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["vacancyId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "27e85aa73d3826c57b8be1f925992126c6032cc3eb312d7162cf84b62a4e2d049966", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<activeVacanciesViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591