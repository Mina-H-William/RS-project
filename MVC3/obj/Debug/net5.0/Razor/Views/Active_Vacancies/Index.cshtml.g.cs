#pragma checksum "D:\RS-project\MVC3\Views\Active_Vacancies\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "d3f817fcef9879745fcf7a9ca7ac075d7efdee63f1452d46263ab5f4c8ed8003"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Active_Vacancies_Index), @"mvc.1.0.view", @"/Views/Active_Vacancies/Index.cshtml")]
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

#line default
#line hidden
#nullable disable
    ;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"d3f817fcef9879745fcf7a9ca7ac075d7efdee63f1452d46263ab5f4c8ed8003", @"/Views/Active_Vacancies/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"1ca9289295aa086821cf8d97c5cbdcf559c071f59b200cf8efd6bb0c8d3b1308", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Active_Vacancies_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Vacancy>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\RS-project\MVC3\Views\Active_Vacancies\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable

            WriteLiteral("\r\n<h1>Active Vacancies</h1>\r\n\r\n");
#nullable restore
#line 9 "D:\RS-project\MVC3\Views\Active_Vacancies\Index.cshtml"
 if (Model == null || !Model.Any())
{

#line default
#line hidden
#nullable disable

            WriteLiteral("    <div class=\"no-vacancies-message\">\r\n        <h2>No current active vacancies</h2>\r\n    </div>\r\n");
#nullable restore
#line 14 "D:\RS-project\MVC3\Views\Active_Vacancies\Index.cshtml"
}
else
{

#line default
#line hidden
#nullable disable

            WriteLiteral("<div class=\"vacancies-list\">\r\n");
#nullable restore
#line 18 "D:\RS-project\MVC3\Views\Active_Vacancies\Index.cshtml"
     foreach (var vacancy in Model)
    {

#line default
#line hidden
#nullable disable

            WriteLiteral("        <div class=\"vacancy-card\">\r\n            <h2>");
            Write(
#nullable restore
#line 21 "D:\RS-project\MVC3\Views\Active_Vacancies\Index.cshtml"
                 vacancy.VacancyName

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</h2>\r\n            <p>");
            Write(
#nullable restore
#line 22 "D:\RS-project\MVC3\Views\Active_Vacancies\Index.cshtml"
                vacancy.TotalVacancyCount

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(" vacancies available</p>\r\n            <p><strong>Title:</strong> ");
            Write(
#nullable restore
#line 23 "D:\RS-project\MVC3\Views\Active_Vacancies\Index.cshtml"
                                        vacancy.Title.TitleName

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</p>\r\n            <p>\r\n                <strong>Projects:</strong>\r\n");
#nullable restore
#line 26 "D:\RS-project\MVC3\Views\Active_Vacancies\Index.cshtml"
                 foreach (var project in vacancy.VacancyProjects)
                {
                    

#line default
#line hidden
#nullable disable

            Write(
#nullable restore
#line 28 "D:\RS-project\MVC3\Views\Active_Vacancies\Index.cshtml"
                     project.Project.ProjectName

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("                    <br />\r\n");
#nullable restore
#line 31 "D:\RS-project\MVC3\Views\Active_Vacancies\Index.cshtml"
                }

#line default
#line hidden
#nullable disable

            WriteLiteral("            </p>\r\n            <p><strong>Status:</strong> ");
            Write(
#nullable restore
#line 33 "D:\RS-project\MVC3\Views\Active_Vacancies\Index.cshtml"
                                          vacancy.Active ? "Active" : "Inactive"

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</p>\r\n            <p>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d3f817fcef9879745fcf7a9ca7ac075d7efdee63f1452d46263ab5f4c8ed80036681", async() => {
                WriteLiteral("Apply");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
            WriteLiteral(
#nullable restore
#line 35 "D:\RS-project\MVC3\Views\Active_Vacancies\Index.cshtml"
                                                       vacancy.VacancyId

#line default
#line hidden
#nullable disable
            );
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </p>\r\n        </div>\r\n");
#nullable restore
#line 38 "D:\RS-project\MVC3\Views\Active_Vacancies\Index.cshtml"
    }

#line default
#line hidden
#nullable disable

            WriteLiteral("</div>\r\n");
#nullable restore
#line 40 "D:\RS-project\MVC3\Views\Active_Vacancies\Index.cshtml"
}

#line default
#line hidden
#nullable disable

            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <style>
        .vacancies-list {
            display: flex;
            flex-wrap: wrap;
        }

        .vacancy-card {
            border: 1px solid #ddd;
            padding: 16px;
            margin: 16px;
            width: 300px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }

            .vacancy-card h2 {
                font-size: 1.5em;
                margin-bottom: 8px;
            }

            .vacancy-card p {
                margin: 4px 0;
            }
    </style>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Vacancy>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
