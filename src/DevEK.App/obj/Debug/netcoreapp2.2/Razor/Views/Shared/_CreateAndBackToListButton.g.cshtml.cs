#pragma checksum "/Users/ekluczkovski/Projects/Vendor_3Tier/src/DevEK.App/Views/Shared/_CreateAndBackToListButton.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ba596d3ad79e22614fdff536968e16f61b49400e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__CreateAndBackToListButton), @"mvc.1.0.view", @"/Views/Shared/_CreateAndBackToListButton.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_CreateAndBackToListButton.cshtml", typeof(AspNetCore.Views_Shared__CreateAndBackToListButton))]
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
#line 1 "/Users/ekluczkovski/Projects/Vendor_3Tier/src/DevEK.App/Views/_ViewImports.cshtml"
using DevEK.App;

#line default
#line hidden
#line 2 "/Users/ekluczkovski/Projects/Vendor_3Tier/src/DevEK.App/Views/_ViewImports.cshtml"
using DevEK.App.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba596d3ad79e22614fdff536968e16f61b49400e", @"/Views/Shared/_CreateAndBackToListButton.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce257de22bb77474e2ce3b4c4a9f1804d3dc4fcf", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__CreateAndBackToListButton : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 292, true);
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-md-6 col-12"">
        <button class=""btn btn-primary form-control"">Create</button>
    </div>

    <div class=""col-md-6 col-12"">
        <a class=""btn btn-info form-control"" href=""javascript:window.history.back()"">Back to List</a>
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
