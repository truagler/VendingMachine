#pragma checksum "C:\Users\vopro\Documents\test\VendingMachine\Views\Home\Privacy.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1f09ba72bff34eb63bdbf069cab61b6ffbfcf85c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Privacy), @"mvc.1.0.view", @"/Views/Home/Privacy.cshtml")]
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
#line 1 "C:\Users\vopro\Documents\test\VendingMachine\Views\_ViewImports.cshtml"
using VendingMachine;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\vopro\Documents\test\VendingMachine\Views\Home\Privacy.cshtml"
using VendingMachine.Models.Domain;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1f09ba72bff34eb63bdbf069cab61b6ffbfcf85c", @"/Views/Home/Privacy.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b9d018e429f6cf27c34d12a129469bf4b4d8cffe", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Privacy : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<VendingMachine.Models.ViewModel.DrinkAndCodeViewModel>
    #nullable disable
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\vopro\Documents\test\VendingMachine\Views\Home\Privacy.cshtml"
Write(await Html.PartialAsync("PopupAdd"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\vopro\Documents\test\VendingMachine\Views\Home\Privacy.cshtml"
Write(await Html.PartialAsync("PopupEdit"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\vopro\Documents\test\VendingMachine\Views\Home\Privacy.cshtml"
  
    ViewData["Title"] = "Administrator panel";

#line default
#line hidden
#nullable disable
            WriteLiteral("<header>\r\n    <h1>Панель администратора<button class=\"btn btn-success\" onclick=\"showModalAdd()\">Добавить</button></h1>\r\n</header>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1f09ba72bff34eb63bdbf069cab61b6ffbfcf85c3962", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 12 "C:\Users\vopro\Documents\test\VendingMachine\Views\Home\Privacy.cshtml"
 foreach (DrinksAndEats product in Model.Products)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <div class=\"product-wrap\">\r\n            <div class=\"product-item\">\r\n                <img");
                BeginWriteAttribute("src", " src=\"", 525, "\"", 543, 1);
#nullable restore
#line 16 "C:\Users\vopro\Documents\test\VendingMachine\Views\Home\Privacy.cshtml"
WriteAttributeValue("", 531, product.Img, 531, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                <div class=\"product-buttons\">\r\n                    <a type=\"button\" class=\"button\"");
                BeginWriteAttribute("onclick", " onclick=\"", 645, "\"", 681, 3);
                WriteAttributeValue("", 655, "showModalEdit(", 655, 14, true);
#nullable restore
#line 18 "C:\Users\vopro\Documents\test\VendingMachine\Views\Home\Privacy.cshtml"
WriteAttributeValue("", 669, product.Id, 669, 11, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 680, ")", 680, 1, true);
                EndWriteAttribute();
                WriteLiteral(">Купить</a>\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 22 "C:\Users\vopro\Documents\test\VendingMachine\Views\Home\Privacy.cshtml"
    }

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<VendingMachine.Models.ViewModel.DrinkAndCodeViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
