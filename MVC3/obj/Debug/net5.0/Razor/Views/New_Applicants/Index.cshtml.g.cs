#pragma checksum "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "eefd4924ac1486202d3c9ab04b0c70eb94ea78b9921e5ec0f25e36dbf03fdbd9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_New_Applicants_Index), @"mvc.1.0.view", @"/Views/New_Applicants/Index.cshtml")]
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

#line default
#line hidden
#nullable disable
    ;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"eefd4924ac1486202d3c9ab04b0c70eb94ea78b9921e5ec0f25e36dbf03fdbd9", @"/Views/New_Applicants/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"63e920a3a356c4a0cd52ac24d1b964a5f477644bebc145bc44551f48121c5841", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_New_Applicants_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MVC3.Models.Applicant>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable

            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eefd4924ac1486202d3c9ab04b0c70eb94ea78b9921e5ec0f25e36dbf03fdbd94627", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            Write(
#nullable restore
#line 16 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayNameFor(model => model.ApplicantFirstName)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            Write(
#nullable restore
#line 19 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayNameFor(model => model.ApplicantMiddleName)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            Write(
#nullable restore
#line 22 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayNameFor(model => model.ApplicantLastName)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            Write(
#nullable restore
#line 25 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayNameFor(model => model.DateOfBirth)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            Write(
#nullable restore
#line 28 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayNameFor(model => model.EmailAddress)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            Write(
#nullable restore
#line 31 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayNameFor(model => model.ContactNumber)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            Write(
#nullable restore
#line 34 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayNameFor(model => model.HomeAddress1)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            Write(
#nullable restore
#line 37 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayNameFor(model => model.Address2)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            Write(
#nullable restore
#line 40 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayNameFor(model => model.Nationality)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            Write(
#nullable restore
#line 43 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayNameFor(model => model.Gender)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            Write(
#nullable restore
#line 46 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayNameFor(model => model.MilitaryStatus)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            Write(
#nullable restore
#line 49 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayNameFor(model => model.MaritalStatus)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            Write(
#nullable restore
#line 52 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayNameFor(model => model.CertificateName)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            Write(
#nullable restore
#line 55 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayNameFor(model => model.GraduationYear)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            Write(
#nullable restore
#line 58 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayNameFor(model => model.Major)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            Write(
#nullable restore
#line 61 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayNameFor(model => model.University)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            Write(
#nullable restore
#line 64 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayNameFor(model => model.CurrentEmployer)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            Write(
#nullable restore
#line 67 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayNameFor(model => model.CurrentPosition)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            Write(
#nullable restore
#line 70 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayNameFor(model => model.CurrentSalary)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            Write(
#nullable restore
#line 73 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayNameFor(model => model.YearsOfExperience)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            Write(
#nullable restore
#line 76 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayNameFor(model => model.NoticePeriod)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            Write(
#nullable restore
#line 79 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayNameFor(model => model.ExtraCertificates)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 85 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable

            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            Write(
#nullable restore
#line 88 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayFor(modelItem => item.ApplicantFirstName)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            Write(
#nullable restore
#line 91 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayFor(modelItem => item.ApplicantMiddleName)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            Write(
#nullable restore
#line 94 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayFor(modelItem => item.ApplicantLastName)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            Write(
#nullable restore
#line 97 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayFor(modelItem => item.DateOfBirth)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            Write(
#nullable restore
#line 100 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayFor(modelItem => item.EmailAddress)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            Write(
#nullable restore
#line 103 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayFor(modelItem => item.ContactNumber)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            Write(
#nullable restore
#line 106 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayFor(modelItem => item.HomeAddress1)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            Write(
#nullable restore
#line 109 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayFor(modelItem => item.Address2)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            Write(
#nullable restore
#line 112 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayFor(modelItem => item.Nationality)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            Write(
#nullable restore
#line 115 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayFor(modelItem => item.Gender)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            Write(
#nullable restore
#line 118 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayFor(modelItem => item.MilitaryStatus)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            Write(
#nullable restore
#line 121 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayFor(modelItem => item.MaritalStatus)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            Write(
#nullable restore
#line 124 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayFor(modelItem => item.CertificateName)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            Write(
#nullable restore
#line 127 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayFor(modelItem => item.GraduationYear)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            Write(
#nullable restore
#line 130 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayFor(modelItem => item.Major)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            Write(
#nullable restore
#line 133 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayFor(modelItem => item.University)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            Write(
#nullable restore
#line 136 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayFor(modelItem => item.CurrentEmployer)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            Write(
#nullable restore
#line 139 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayFor(modelItem => item.CurrentPosition)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            Write(
#nullable restore
#line 142 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayFor(modelItem => item.CurrentSalary)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            Write(
#nullable restore
#line 145 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayFor(modelItem => item.YearsOfExperience)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            Write(
#nullable restore
#line 148 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayFor(modelItem => item.NoticePeriod)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            Write(
#nullable restore
#line 151 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                 Html.DisplayFor(modelItem => item.ExtraCertificates)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eefd4924ac1486202d3c9ab04b0c70eb94ea78b9921e5ec0f25e36dbf03fdbd920718", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
            WriteLiteral(
#nullable restore
#line 154 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                                                    item.ApplicantId

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
            WriteLiteral(" |\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eefd4924ac1486202d3c9ab04b0c70eb94ea78b9921e5ec0f25e36dbf03fdbd922932", async() => {
                WriteLiteral("Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
            WriteLiteral(
#nullable restore
#line 155 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                                                       item.ApplicantId

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
            WriteLiteral(" |\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eefd4924ac1486202d3c9ab04b0c70eb94ea78b9921e5ec0f25e36dbf03fdbd925152", async() => {
                WriteLiteral("Delete");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
            WriteLiteral(
#nullable restore
#line 156 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
                                                      item.ApplicantId

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
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 159 "D:\RS-project\MVC3\Views\New_Applicants\Index.cshtml"
}

#line default
#line hidden
#nullable disable

            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MVC3.Models.Applicant>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
