#pragma checksum "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\Skill\EditView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a95c1842627acfbe1eb462dbb69c163a5ca72df9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Skill_EditView), @"mvc.1.0.view", @"/Views/Skill/EditView.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Skill/EditView.cshtml", typeof(AspNetCore.Views_Skill_EditView))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a95c1842627acfbe1eb462dbb69c163a5ca72df9", @"/Views/Skill/EditView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2e2c6e62d89213ead4ebbf0e81e2309d0bd9bf99", @"/Views/_ViewImports.cshtml")]
    public class Views_Skill_EditView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Apprenticeship.Models.Skill>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\Skill\EditView.cshtml"
  
    ViewData["Title"] = "Skills";

#line default
#line hidden
            BeginContext(80, 4, true);
            WriteLiteral("<h1>");
            EndContext();
            BeginContext(85, 17, false);
#line 6 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\Skill\EditView.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(102, 11, true);
            WriteLiteral("</h1>\r\n\r\n\r\n");
            EndContext();
#line 9 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\Skill\EditView.cshtml"
 using (@Html.BeginForm("Edit", "Skill", FormMethod.Post))
{
    

#line default
#line hidden
            BeginContext(181, 23, false);
#line 11 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\Skill\EditView.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(206, 38, true);
            WriteLiteral("    <div class=\"form-group\">\r\n        ");
            EndContext();
            BeginContext(245, 25, false);
#line 13 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\Skill\EditView.cshtml"
   Write(Html.HiddenFor(x => x.Id));

#line default
#line hidden
            EndContext();
            BeginContext(270, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(281, 90, false);
#line 14 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\Skill\EditView.cshtml"
   Write(Html.TextBoxFor(x => x.Name, new { placeholder = "Enter skill", @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(371, 81, true);
            WriteLiteral("\r\n    </div>\r\n    <button type=\"submit\" class=\"btn btn-primary\">Submit</button>\r\n");
            EndContext();
#line 17 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\Skill\EditView.cshtml"
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
