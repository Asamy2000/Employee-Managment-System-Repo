#pragma checksum "D:\web\backend\39\05 ASP.NET Core MVC\MVCAPP01\MVCAPPPL\Views\UserManger\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5a2c8ca5d752b646c84df38bf5481511e11c49f8017e0bab5070b566b76558b1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UserManger_Index), @"mvc.1.0.view", @"/Views/UserManger/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\web\backend\39\05 ASP.NET Core MVC\MVCAPP01\MVCAPPPL\Views\_ViewImports.cshtml"
using EFG_MVCAPP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\web\backend\39\05 ASP.NET Core MVC\MVCAPP01\MVCAPPPL\Views\_ViewImports.cshtml"
using MVCPL.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\web\backend\39\05 ASP.NET Core MVC\MVCAPP01\MVCAPPPL\Views\_ViewImports.cshtml"
using EFG_MVCAPP.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\web\backend\39\05 ASP.NET Core MVC\MVCAPP01\MVCAPPPL\Views\_ViewImports.cshtml"
using MVCAPPDAL.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"5a2c8ca5d752b646c84df38bf5481511e11c49f8017e0bab5070b566b76558b1", @"/Views/UserManger/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"4479abcc9dc89008dc81954c4126f7395975e7bf0fb1c2115f14068786c38d45", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_UserManger_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<UserVM>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("row col-8 offset-1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_ButtonsPartialView", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\web\backend\39\05 ASP.NET Core MVC\MVCAPP01\MVCAPPPL\Views\UserManger\Index.cshtml"
  
    ViewData["Title"] = "All Users";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>All Users</h1>\r\n<br />\r\n<br />\r\n\r\n");
#nullable restore
#line 10 "D:\web\backend\39\05 ASP.NET Core MVC\MVCAPP01\MVCAPPPL\Views\UserManger\Index.cshtml"
 if (TempData["Message"] is not null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-primary\">\r\n        ");
#nullable restore
#line 13 "D:\web\backend\39\05 ASP.NET Core MVC\MVCAPP01\MVCAPPPL\Views\UserManger\Index.cshtml"
   Write(TempData["Message"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 15 "D:\web\backend\39\05 ASP.NET Core MVC\MVCAPP01\MVCAPPPL\Views\UserManger\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"row justify-content-center align-content-center mt-3\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5a2c8ca5d752b646c84df38bf5481511e11c49f8017e0bab5070b566b76558b15677", async() => {
                WriteLiteral("\r\n        <div class=\"col-8\">\r\n            <input placeholder=\"Search by Email\" id=\"searchBar\" type=\"text\" name=\"email\" class=\"form-control\" />\r\n        </div>\r\n");
                WriteLiteral("    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
#nullable restore
#line 27 "D:\web\backend\39\05 ASP.NET Core MVC\MVCAPP01\MVCAPPPL\Views\UserManger\Index.cshtml"
 if (Model.Count() > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table class=\"table table-striped table-hover mt-3\">\r\n        <thead>\r\n            <tr>\r\n\r\n                <td>");
#nullable restore
#line 33 "D:\web\backend\39\05 ASP.NET Core MVC\MVCAPP01\MVCAPPPL\Views\UserManger\Index.cshtml"
               Write(Html.DisplayNameFor(U => U.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 34 "D:\web\backend\39\05 ASP.NET Core MVC\MVCAPP01\MVCAPPPL\Views\UserManger\Index.cshtml"
               Write(Html.DisplayNameFor(U => U.FName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 35 "D:\web\backend\39\05 ASP.NET Core MVC\MVCAPP01\MVCAPPPL\Views\UserManger\Index.cshtml"
               Write(Html.DisplayNameFor(U => U.LName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 36 "D:\web\backend\39\05 ASP.NET Core MVC\MVCAPP01\MVCAPPPL\Views\UserManger\Index.cshtml"
               Write(Html.DisplayNameFor(U => U.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 37 "D:\web\backend\39\05 ASP.NET Core MVC\MVCAPP01\MVCAPPPL\Views\UserManger\Index.cshtml"
               Write(Html.DisplayNameFor(U => U.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 38 "D:\web\backend\39\05 ASP.NET Core MVC\MVCAPP01\MVCAPPPL\Views\UserManger\Index.cshtml"
               Write(Html.DisplayNameFor(U => U.Roles));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n               \r\n                <td>Details</td>\r\n                <td>Update</td>\r\n                <td>Delete</td>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 46 "D:\web\backend\39\05 ASP.NET Core MVC\MVCAPP01\MVCAPPPL\Views\UserManger\Index.cshtml"
             foreach (var User in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 49 "D:\web\backend\39\05 ASP.NET Core MVC\MVCAPP01\MVCAPPPL\Views\UserManger\Index.cshtml"
                   Write(Html.DisplayFor(U=> User.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 50 "D:\web\backend\39\05 ASP.NET Core MVC\MVCAPP01\MVCAPPPL\Views\UserManger\Index.cshtml"
                   Write(Html.DisplayFor(U=> User.FName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 51 "D:\web\backend\39\05 ASP.NET Core MVC\MVCAPP01\MVCAPPPL\Views\UserManger\Index.cshtml"
                   Write(Html.DisplayFor(U=> User.LName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 52 "D:\web\backend\39\05 ASP.NET Core MVC\MVCAPP01\MVCAPPPL\Views\UserManger\Index.cshtml"
                   Write(Html.DisplayFor(U=> User.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 53 "D:\web\backend\39\05 ASP.NET Core MVC\MVCAPP01\MVCAPPPL\Views\UserManger\Index.cshtml"
                   Write(Html.DisplayFor(U=> User.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 54 "D:\web\backend\39\05 ASP.NET Core MVC\MVCAPP01\MVCAPPPL\Views\UserManger\Index.cshtml"
                   Write(string.Join("  ",User.Roles));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5a2c8ca5d752b646c84df38bf5481511e11c49f8017e0bab5070b566b76558b111515", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 55 "D:\web\backend\39\05 ASP.NET Core MVC\MVCAPP01\MVCAPPPL\Views\UserManger\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = User.Id;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </tr>\r\n");
#nullable restore
#line 57 "D:\web\backend\39\05 ASP.NET Core MVC\MVCAPP01\MVCAPPPL\Views\UserManger\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 60 "D:\web\backend\39\05 ASP.NET Core MVC\MVCAPP01\MVCAPPPL\Views\UserManger\Index.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"mt-4 alert alert-warning\">\r\n        <h3>there is no Users!!</h3>\r\n    </div>\r\n");
#nullable restore
#line 66 "D:\web\backend\39\05 ASP.NET Core MVC\MVCAPP01\MVCAPPPL\Views\UserManger\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<UserVM>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
