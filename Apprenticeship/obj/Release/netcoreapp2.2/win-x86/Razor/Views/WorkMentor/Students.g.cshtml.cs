#pragma checksum "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\WorkMentor\Students.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "86d854f835f35f1b712c654961131cbb787794cc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_WorkMentor_Students), @"mvc.1.0.view", @"/Views/WorkMentor/Students.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/WorkMentor/Students.cshtml", typeof(AspNetCore.Views_WorkMentor_Students))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86d854f835f35f1b712c654961131cbb787794cc", @"/Views/WorkMentor/Students.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2e2c6e62d89213ead4ebbf0e81e2309d0bd9bf99", @"/Views/_ViewImports.cshtml")]
    public class Views_WorkMentor_Students : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\WorkMentor\Students.cshtml"
  
    ViewData["Title"] = "Students";

#line default
#line hidden
            BeginContext(60, 4, true);
            WriteLiteral("<h1>");
            EndContext();
            BeginContext(65, 17, false);
#line 5 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\WorkMentor\Students.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(82, 301, true);
            WriteLiteral(@"</h1>
<div class=""bd-example table-responsive"">
    <table class=""table"">
        <thead>
            <tr>
                <th class=""text-left"" scope=""col"">Student name</th>
                <th class=""text-left"" scope=""col"">Portfolio</th>
            </tr>
        </thead>
        <tbody>
");
            EndContext();
#line 15 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\WorkMentor\Students.cshtml"
             foreach (var s in Model.students)
            {

#line default
#line hidden
            BeginContext(446, 76, true);
            WriteLiteral("                <tr>\r\n                    <td class=\"text-left\" scope=\"col\">");
            EndContext();
            BeginContext(523, 11, false);
#line 18 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\WorkMentor\Students.cshtml"
                                                 Write(s.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(534, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(536, 10, false);
#line 18 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\WorkMentor\Students.cshtml"
                                                              Write(s.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(546, 79, true);
            WriteLiteral("</td>\r\n                    <td class=\"text-left\" scope=\"col\"><a target=\"_blank\"");
            EndContext();
            BeginWriteAttribute("href", " href=", 625, "", 704, 1);
#line 19 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\WorkMentor\Students.cshtml"
WriteAttributeValue("", 631, Url.Action("GetStudentPortfolio", "WorkMentor", new {studentId = @s.Id}), 631, 73, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 704, "\"", 714, 1);
#line 19 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\WorkMentor\Students.cshtml"
WriteAttributeValue("", 709, s.Id, 709, 5, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(715, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(717, 20, false);
#line 19 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\WorkMentor\Students.cshtml"
                                                                                                                                                              Write(s.portFolioFile.Name);

#line default
#line hidden
            EndContext();
            BeginContext(737, 92, true);
            WriteLiteral("</a></td>\r\n                    <td class=\"text-right\" scope=\"col\">\r\n                        ");
            EndContext();
            BeginContext(830, 112, false);
#line 21 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\WorkMentor\Students.cshtml"
                   Write(Html.ActionLink("Tasks", "StudentTasks", "Tasks", new { studentId = @s.Id }, new { @class = "btn btn-primary" }));

#line default
#line hidden
            EndContext();
            BeginContext(942, 26, true);
            WriteLiteral("\r\n                        ");
            EndContext();
            BeginContext(969, 114, false);
#line 22 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\WorkMentor\Students.cshtml"
                   Write(Html.ActionLink("Profile", "Student", "WorkMentor", new { studentId = @s.Id }, new { @class = "btn btn-primary" }));

#line default
#line hidden
            EndContext();
            BeginContext(1083, 52, true);
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 25 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\WorkMentor\Students.cshtml"
            }

#line default
#line hidden
            BeginContext(1150, 48, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n\r\n\r\n\r\n\r\n");
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
