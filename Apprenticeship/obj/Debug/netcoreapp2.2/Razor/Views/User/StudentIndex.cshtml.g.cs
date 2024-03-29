#pragma checksum "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\User\StudentIndex.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6f1b288492bfd62881ea575ff8d4080bff7970a3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_StudentIndex), @"mvc.1.0.view", @"/Views/User/StudentIndex.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/User/StudentIndex.cshtml", typeof(AspNetCore.Views_User_StudentIndex))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6f1b288492bfd62881ea575ff8d4080bff7970a3", @"/Views/User/StudentIndex.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2e2c6e62d89213ead4ebbf0e81e2309d0bd9bf99", @"/Views/_ViewImports.cshtml")]
    public class Views_User_StudentIndex : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\User\StudentIndex.cshtml"
  
    ViewData["Title"] = "Students";

#line default
#line hidden
            BeginContext(60, 4, true);
            WriteLiteral("<h1>");
            EndContext();
            BeginContext(65, 17, false);
#line 5 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\User\StudentIndex.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(82, 37, true);
            WriteLiteral("</h1>\r\n<div class=\"text-right\">\r\n    ");
            EndContext();
            BeginContext(120, 100, false);
#line 7 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\User\StudentIndex.cshtml"
Write(Html.ActionLink("Create Student", "CreateStudent", "User", null, new { @class = "btn btn-primary" }));

#line default
#line hidden
            EndContext();
            BeginContext(220, 238, true);
            WriteLiteral("\r\n</div>\r\n<div class=\"bd-example table-responsive\">\r\n    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th class=\"text-left\" scope=\"col\">Student name</th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
            EndContext();
#line 17 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\User\StudentIndex.cshtml"
             foreach (var s in Model.students)
            {

#line default
#line hidden
            BeginContext(521, 76, true);
            WriteLiteral("                <tr>\r\n                    <td class=\"text-left\" scope=\"col\">");
            EndContext();
            BeginContext(598, 11, false);
#line 20 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\User\StudentIndex.cshtml"
                                                 Write(s.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(609, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(611, 10, false);
#line 20 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\User\StudentIndex.cshtml"
                                                              Write(s.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(621, 88, true);
            WriteLiteral("</td>\r\n                    <td class=\"text-right\" scope=\"col\">\r\n                        ");
            EndContext();
            BeginContext(710, 110, false);
#line 22 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\User\StudentIndex.cshtml"
                   Write(Html.ActionLink("Tasks", "TimeLine", "Student", new { studentId = @s.Id }, new { @class = "btn btn-primary" }));

#line default
#line hidden
            EndContext();
            BeginContext(820, 26, true);
            WriteLiteral("\r\n                        ");
            EndContext();
            BeginContext(847, 113, false);
#line 23 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\User\StudentIndex.cshtml"
                   Write(Html.ActionLink("Edit", "StudentEditView", "User", new { studentId = @s.Id }, new { @class = "btn btn-primary" }));

#line default
#line hidden
            EndContext();
            BeginContext(960, 26, true);
            WriteLiteral("\r\n                        ");
            EndContext();
            BeginContext(987, 158, false);
#line 24 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\User\StudentIndex.cshtml"
                   Write(Html.ActionLink("Delete", "DeleteStudent", "User", new { studentId = s.Id }, new { @class = "btn btn-danger", @onclick = "return confirm('Are you sure?');" }));

#line default
#line hidden
            EndContext();
            BeginContext(1145, 52, true);
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 27 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\User\StudentIndex.cshtml"
            }

#line default
#line hidden
            BeginContext(1212, 62, true);
            WriteLiteral("            \r\n        </tbody>\r\n    </table>\r\n</div>\r\n\r\n\r\n\r\n\r\n");
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
