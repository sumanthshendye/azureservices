#pragma checksum "D:\Sample Projects\DotNet-Core\AzureServices\Views\Queue\PeekQueue.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ffe0ca82f12b6f18aab4ad40c2f37368b42f66f3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Queue_PeekQueue), @"mvc.1.0.view", @"/Views/Queue/PeekQueue.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Queue/PeekQueue.cshtml", typeof(AspNetCore.Views_Queue_PeekQueue))]
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
#line 1 "D:\Sample Projects\DotNet-Core\AzureServices\Views\_ViewImports.cshtml"
using AzureServices;

#line default
#line hidden
#line 2 "D:\Sample Projects\DotNet-Core\AzureServices\Views\_ViewImports.cshtml"
using AzureServices.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ffe0ca82f12b6f18aab4ad40c2f37368b42f66f3", @"/Views/Queue/PeekQueue.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"005f57ae4ae3406581e0ebfa07144571735cb5c8", @"/Views/_ViewImports.cshtml")]
    public class Views_Queue_PeekQueue : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\Sample Projects\DotNet-Core\AzureServices\Views\Queue\PeekQueue.cshtml"
  
    ViewData["Title"] = "PeekQueue";

#line default
#line hidden
            BeginContext(47, 22, true);
            WriteLiteral("\r\n<h1>Dequeue</h1>\r\n\r\n");
            EndContext();
#line 8 "D:\Sample Projects\DotNet-Core\AzureServices\Views\Queue\PeekQueue.cshtml"
 foreach(var item in ViewBag.CloudQueueMessages)
{

#line default
#line hidden
            BeginContext(122, 19, true);
            WriteLiteral("    <div>\r\n        ");
            EndContext();
            BeginContext(142, 4, false);
#line 11 "D:\Sample Projects\DotNet-Core\AzureServices\Views\Queue\PeekQueue.cshtml"
   Write(item);

#line default
#line hidden
            EndContext();
            BeginContext(146, 14, true);
            WriteLiteral("\r\n    </div>\r\n");
            EndContext();
#line 13 "D:\Sample Projects\DotNet-Core\AzureServices\Views\Queue\PeekQueue.cshtml"
}

#line default
#line hidden
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
