#pragma checksum "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\SchoolMentor\Student.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3136112b64e6cf24ea08a820e2d47b2367ddc2ee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SchoolMentor_Student), @"mvc.1.0.view", @"/Views/SchoolMentor/Student.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/SchoolMentor/Student.cshtml", typeof(AspNetCore.Views_SchoolMentor_Student))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3136112b64e6cf24ea08a820e2d47b2367ddc2ee", @"/Views/SchoolMentor/Student.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2e2c6e62d89213ead4ebbf0e81e2309d0bd9bf99", @"/Views/_ViewImports.cshtml")]
    public class Views_SchoolMentor_Student : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Apprenticeship.Models.Intermediate.IntermediateStudent>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\SchoolMentor\Student.cshtml"
  
    ViewData["Title"] = Model.FirstName + Model.LastName;

#line default
#line hidden
            BeginContext(131, 4, true);
            WriteLiteral("<h1>");
            EndContext();
            BeginContext(136, 17, false);
#line 6 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\SchoolMentor\Student.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(153, 39, true);
            WriteLiteral("</h1>\r\n\r\n<div class=\"form-group\">\r\n    ");
            EndContext();
            BeginContext(193, 25, false);
#line 9 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\SchoolMentor\Student.cshtml"
Write(Html.HiddenFor(x => x.Id));

#line default
#line hidden
            EndContext();
            BeginContext(218, 69, true);
            WriteLiteral("\r\n    <div class=\"row\">\r\n        <div class=\"col-md-2\">\r\n            ");
            EndContext();
            BeginContext(288, 83, false);
#line 12 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\SchoolMentor\Student.cshtml"
       Write(Html.LabelFor(x => x.FirstName, new { @class = "form-control font-weight-bolder" }));

#line default
#line hidden
            EndContext();
            BeginContext(371, 62, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-md-8\">\r\n            ");
            EndContext();
            BeginContext(434, 119, false);
#line 15 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\SchoolMentor\Student.cshtml"
       Write(Html.TextBoxFor(x => x.FirstName, new { placeholder = "Enter Title", @class = "form-control", @readonly = "readonly" }));

#line default
#line hidden
            EndContext();
            BeginContext(553, 97, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-md-2\">\r\n            ");
            EndContext();
            BeginContext(651, 82, false);
#line 20 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\SchoolMentor\Student.cshtml"
       Write(Html.LabelFor(x => x.LastName, new { @class = "form-control font-weight-bolder" }));

#line default
#line hidden
            EndContext();
            BeginContext(733, 62, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-md-8\">\r\n            ");
            EndContext();
            BeginContext(796, 119, false);
#line 23 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\SchoolMentor\Student.cshtml"
       Write(Html.TextAreaFor(x => x.LastName, new { placeholder = "Enter Title", @class = "form-control", @readonly = "readonly" }));

#line default
#line hidden
            EndContext();
            BeginContext(915, 117, true);
            WriteLiteral("\r\n            <hr />\r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-md-2\">\r\n            ");
            EndContext();
            BeginContext(1033, 85, false);
#line 29 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\SchoolMentor\Student.cshtml"
       Write(Html.LabelFor(x => x.PhoneNumber, new { @class = "form-control font-weight-bolder" }));

#line default
#line hidden
            EndContext();
            BeginContext(1118, 62, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-md-8\">\r\n            ");
            EndContext();
            BeginContext(1181, 93, false);
#line 32 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\SchoolMentor\Student.cshtml"
       Write(Html.TextAreaFor(x => x.PhoneNumber, new { @class = "form-control", @readonly = "readonly" }));

#line default
#line hidden
            EndContext();
            BeginContext(1274, 117, true);
            WriteLiteral("\r\n            <hr />\r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-md-2\">\r\n            ");
            EndContext();
            BeginContext(1392, 79, false);
#line 38 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\SchoolMentor\Student.cshtml"
       Write(Html.LabelFor(x => x.Email, new { @class = "form-control font-weight-bolder" }));

#line default
#line hidden
            EndContext();
            BeginContext(1471, 62, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-md-8\">\r\n            ");
            EndContext();
            BeginContext(1534, 87, false);
#line 41 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\SchoolMentor\Student.cshtml"
       Write(Html.TextAreaFor(x => x.Email, new { @class = "form-control", @readonly = "readonly" }));

#line default
#line hidden
            EndContext();
            BeginContext(1621, 117, true);
            WriteLiteral("\r\n            <hr />\r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-md-2\">\r\n            ");
            EndContext();
            BeginContext(1739, 100, false);
#line 47 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\SchoolMentor\Student.cshtml"
       Write(Html.Label("University name", "University name", new { @class = "form-control font-weight-bolder" }));

#line default
#line hidden
            EndContext();
            BeginContext(1839, 62, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-md-8\">\r\n            ");
            EndContext();
            BeginContext(1902, 93, false);
#line 50 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\SchoolMentor\Student.cshtml"
       Write(Html.TextAreaFor(x => x.CompanyName, new { @class = "form-control", @readonly = "readonly" }));

#line default
#line hidden
            EndContext();
            BeginContext(1995, 117, true);
            WriteLiteral("\r\n            <hr />\r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-md-2\">\r\n            ");
            EndContext();
            BeginContext(2113, 83, false);
#line 56 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\SchoolMentor\Student.cshtml"
       Write(Html.LabelFor(x => x.MajorName, new { @class = "form-control font-weight-bolder" }));

#line default
#line hidden
            EndContext();
            BeginContext(2196, 62, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-md-8\">\r\n            ");
            EndContext();
            BeginContext(2259, 120, false);
#line 59 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\SchoolMentor\Student.cshtml"
       Write(Html.TextAreaFor(x => x.MajorName, new { placeholder = "Enter Title", @class = "form-control", @readonly = "readonly" }));

#line default
#line hidden
            EndContext();
            BeginContext(2379, 117, true);
            WriteLiteral("\r\n            <hr />\r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-md-2\">\r\n            ");
            EndContext();
            BeginContext(2497, 84, false);
#line 65 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\SchoolMentor\Student.cshtml"
       Write(Html.LabelFor(x => x.DegreeName, new { @class = "form-control font-weight-bolder" }));

#line default
#line hidden
            EndContext();
            BeginContext(2581, 62, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-md-8\">\r\n            ");
            EndContext();
            BeginContext(2644, 121, false);
#line 68 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\SchoolMentor\Student.cshtml"
       Write(Html.TextAreaFor(x => x.DegreeName, new { placeholder = "Enter Title", @class = "form-control", @readonly = "readonly" }));

#line default
#line hidden
            EndContext();
            BeginContext(2765, 119, true);
            WriteLiteral("\r\n            <hr />\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"row\">\r\n        <div class=\"col-md-2\">\r\n            ");
            EndContext();
            BeginContext(2885, 82, false);
#line 75 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\SchoolMentor\Student.cshtml"
       Write(Html.Label("Skills", "Skills", new { @class = "form-control font-weight-bolder" }));

#line default
#line hidden
            EndContext();
            BeginContext(2967, 118, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-md-8\">\r\n            <ul class=\"form-control\" style=\"list-style-type:none\">\r\n");
            EndContext();
#line 79 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\SchoolMentor\Student.cshtml"
                 foreach (var skill in ViewBag.skills)
                {

#line default
#line hidden
            BeginContext(3160, 24, true);
            WriteLiteral("                    <li>");
            EndContext();
            BeginContext(3185, 5, false);
#line 81 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\SchoolMentor\Student.cshtml"
                   Write(skill);

#line default
#line hidden
            EndContext();
            BeginContext(3190, 7, true);
            WriteLiteral("</li>\r\n");
            EndContext();
#line 82 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\SchoolMentor\Student.cshtml"
                }

#line default
#line hidden
            BeginContext(3216, 53, true);
            WriteLiteral("            </ul>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Apprenticeship.Models.Intermediate.IntermediateStudent> Html { get; private set; }
    }
}
#pragma warning restore 1591