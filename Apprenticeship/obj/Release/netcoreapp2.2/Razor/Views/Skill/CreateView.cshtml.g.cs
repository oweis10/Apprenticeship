#pragma checksum "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\Skill\CreateView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "49bce1fcfef61304183e425e686f667425259220"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Skill_CreateView), @"mvc.1.0.view", @"/Views/Skill/CreateView.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Skill/CreateView.cshtml", typeof(AspNetCore.Views_Skill_CreateView))]
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
#line 1 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\_ViewImports.cshtml"
using Apprenticeship;

#line default
#line hidden
#line 2 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\_ViewImports.cshtml"
using Apprenticeship.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"49bce1fcfef61304183e425e686f667425259220", @"/Views/Skill/CreateView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2e2c6e62d89213ead4ebbf0e81e2309d0bd9bf99", @"/Views/_ViewImports.cshtml")]
    public class Views_Skill_CreateView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Apprenticeship.Models.Skill>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\Skill\CreateView.cshtml"
  
    ViewData["Title"] = "Create Skill";

#line default
#line hidden
            BeginContext(84, 4, true);
            WriteLiteral("<h1>");
            EndContext();
            BeginContext(89, 17, false);
#line 5 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\Skill\CreateView.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(106, 11, true);
            WriteLiteral("</h1>\r\n\r\n\r\n");
            EndContext();
#line 8 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\Skill\CreateView.cshtml"
 using (@Html.BeginForm("Create", "Skill", FormMethod.Post))
{
    

#line default
#line hidden
            BeginContext(187, 23, false);
#line 10 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\Skill\CreateView.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(212, 38, true);
            WriteLiteral("    <div class=\"form-group\">\r\n        ");
            EndContext();
            BeginContext(251, 90, false);
#line 12 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\Skill\CreateView.cshtml"
   Write(Html.TextBoxFor(x => x.Name, new { placeholder = "Enter skill", @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(341, 81, true);
            WriteLiteral("\r\n    </div>\r\n    <button type=\"submit\" class=\"btn btn-primary\">Submit</button>\r\n");
            EndContext();
#line 15 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\Skill\CreateView.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Apprenticeship.Models.Skill> Html { get; private set; }
    }
}
#pragma warning restore 1591