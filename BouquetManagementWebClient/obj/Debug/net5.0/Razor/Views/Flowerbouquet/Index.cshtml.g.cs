#pragma checksum "C:\Users\hoang\Documents\GitHub\HoangAPI_defined\BouquetManagementWebClient\Views\Flowerbouquet\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "259cee34618b0f4c3a36838701d04f5763556504"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Flowerbouquet_Index), @"mvc.1.0.view", @"/Views/Flowerbouquet/Index.cshtml")]
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
#nullable restore
#line 1 "C:\Users\hoang\Documents\GitHub\HoangAPI_defined\BouquetManagementWebClient\Views\_ViewImports.cshtml"
using BouquetManagementWebClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\hoang\Documents\GitHub\HoangAPI_defined\BouquetManagementWebClient\Views\_ViewImports.cshtml"
using BouquetManagementWebClient.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\hoang\Documents\GitHub\HoangAPI_defined\BouquetManagementWebClient\Views\Flowerbouquet\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"259cee34618b0f4c3a36838701d04f5763556504", @"/Views/Flowerbouquet/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"032f034db68caeba99d3ecf80f29acbb31624f66", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Flowerbouquet_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable< BusinessObject.FlowerBouquet >>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Logout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 3 "C:\Users\hoang\Documents\GitHub\HoangAPI_defined\BouquetManagementWebClient\Views\Flowerbouquet\Index.cshtml"
  
    ViewData["Title"] = "Index";


#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\hoang\Documents\GitHub\HoangAPI_defined\BouquetManagementWebClient\Views\Flowerbouquet\Index.cshtml"
  
    // Lấy giá trị Session
    string customerName = Context.Session.GetString("CustomerName");
    string email = Context.Session.GetString("Email");

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>Index</h1>\r\n<h1>Welcome, ");
#nullable restore
#line 13 "C:\Users\hoang\Documents\GitHub\HoangAPI_defined\BouquetManagementWebClient\Views\Flowerbouquet\Index.cshtml"
        Write(customerName);

#line default
#line hidden
#nullable disable
            WriteLiteral("!</h1>\r\n<p>Email: ");
#nullable restore
#line 14 "C:\Users\hoang\Documents\GitHub\HoangAPI_defined\BouquetManagementWebClient\Views\Flowerbouquet\Index.cshtml"
     Write(email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<div class=\"logout-container\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "259cee34618b0f4c3a36838701d04f57635565045629", async() => {
                WriteLiteral("Log out");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "259cee34618b0f4c3a36838701d04f57635565046897", async() => {
                WriteLiteral("Create New");
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
            WriteLiteral("\r\n</p>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>");
#nullable restore
#line 27 "C:\Users\hoang\Documents\GitHub\HoangAPI_defined\BouquetManagementWebClient\Views\Flowerbouquet\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.FlowerBouquetID));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th>");
#nullable restore
#line 28 "C:\Users\hoang\Documents\GitHub\HoangAPI_defined\BouquetManagementWebClient\Views\Flowerbouquet\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.CategoryID));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th>");
#nullable restore
#line 29 "C:\Users\hoang\Documents\GitHub\HoangAPI_defined\BouquetManagementWebClient\Views\Flowerbouquet\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.FlowerBouquetName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th>");
#nullable restore
#line 30 "C:\Users\hoang\Documents\GitHub\HoangAPI_defined\BouquetManagementWebClient\Views\Flowerbouquet\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th>");
#nullable restore
#line 31 "C:\Users\hoang\Documents\GitHub\HoangAPI_defined\BouquetManagementWebClient\Views\Flowerbouquet\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.UnitPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th>");
#nullable restore
#line 32 "C:\Users\hoang\Documents\GitHub\HoangAPI_defined\BouquetManagementWebClient\Views\Flowerbouquet\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.UnitInStock));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th>");
#nullable restore
#line 33 "C:\Users\hoang\Documents\GitHub\HoangAPI_defined\BouquetManagementWebClient\Views\Flowerbouquet\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.FlowerBouquetStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th>");
#nullable restore
#line 34 "C:\Users\hoang\Documents\GitHub\HoangAPI_defined\BouquetManagementWebClient\Views\Flowerbouquet\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.SupplierID));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 39 "C:\Users\hoang\Documents\GitHub\HoangAPI_defined\BouquetManagementWebClient\Views\Flowerbouquet\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 42 "C:\Users\hoang\Documents\GitHub\HoangAPI_defined\BouquetManagementWebClient\Views\Flowerbouquet\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.FlowerBouquetID));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 43 "C:\Users\hoang\Documents\GitHub\HoangAPI_defined\BouquetManagementWebClient\Views\Flowerbouquet\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.CategoryID));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 44 "C:\Users\hoang\Documents\GitHub\HoangAPI_defined\BouquetManagementWebClient\Views\Flowerbouquet\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.FlowerBouquetName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 45 "C:\Users\hoang\Documents\GitHub\HoangAPI_defined\BouquetManagementWebClient\Views\Flowerbouquet\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 46 "C:\Users\hoang\Documents\GitHub\HoangAPI_defined\BouquetManagementWebClient\Views\Flowerbouquet\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.UnitPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 47 "C:\Users\hoang\Documents\GitHub\HoangAPI_defined\BouquetManagementWebClient\Views\Flowerbouquet\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.UnitInStock));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 48 "C:\Users\hoang\Documents\GitHub\HoangAPI_defined\BouquetManagementWebClient\Views\Flowerbouquet\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.FlowerBouquetStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 49 "C:\Users\hoang\Documents\GitHub\HoangAPI_defined\BouquetManagementWebClient\Views\Flowerbouquet\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.SupplierID));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>\r\n                    ");
#nullable restore
#line 51 "C:\Users\hoang\Documents\GitHub\HoangAPI_defined\BouquetManagementWebClient\Views\Flowerbouquet\Index.cshtml"
               Write(Html.ActionLink("Details", "Details", new { id = item.FlowerBouquetID }, new { @class = "btn btn-primary" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 52 "C:\Users\hoang\Documents\GitHub\HoangAPI_defined\BouquetManagementWebClient\Views\Flowerbouquet\Index.cshtml"
               Write(Html.ActionLink("Delete", "Delete", new { id = item.FlowerBouquetID }, new { @class = "btn btn-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 55 "C:\Users\hoang\Documents\GitHub\HoangAPI_defined\BouquetManagementWebClient\Views\Flowerbouquet\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </tbody>
</table>

<style>
    h1 {
        font-size: 24px;
        margin-bottom: 10px;
    }

    table {
        width: 100%;
        border-collapse: collapse;
    }

    th, td {
        padding: 8px;
        text-align: left;
        border-bottom: 1px solid #ddd;
    }

    th {
        background-color: #f2f2f2;
    }

    .btn {
        display: inline-block;
        padding: 6px 12px;
        margin-bottom: 0;
        font-size: 14px;
        font-weight: normal;
        line-height: 1.42857143;
        text-align: center;
        white-space: nowrap;
        vertical-align: middle;
        cursor: pointer;
        user-select: none;
        background-image: none;
        border: 1px solid transparent;
        border-radius: 4px;
    }

    .btn-primary {
        color: #fff;
        background-color: #007bff;
        border-color: #007bff;
    }

    .logout-container {
        display: flex;
        justify-content: flex-end;
    }

    .bt");
            WriteLiteral("n-danger {\r\n        color: #fff;\r\n        background-color: #dc3545;\r\n        border-color: #dc3545;\r\n    }\r\n</style>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable< BusinessObject.FlowerBouquet >> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591