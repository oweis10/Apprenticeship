#pragma checksum "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\User\WorkMentorEditView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cd6b0c43c7c9832f12c382146b5929133f67398c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_WorkMentorEditView), @"mvc.1.0.view", @"/Views/User/WorkMentorEditView.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/User/WorkMentorEditView.cshtml", typeof(AspNetCore.Views_User_WorkMentorEditView))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd6b0c43c7c9832f12c382146b5929133f67398c", @"/Views/User/WorkMentorEditView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2e2c6e62d89213ead4ebbf0e81e2309d0bd9bf99", @"/Views/_ViewImports.cshtml")]
    public class Views_User_WorkMentorEditView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Apprenticeship.Models.Intermediate.IntermediateMentor>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\User\WorkMentorEditView.cshtml"
  
    ViewData["Title"] = "Edit Work Mentor";

#line default
#line hidden
            BeginContext(114, 4, true);
            WriteLiteral("<h1>");
            EndContext();
            BeginContext(119, 17, false);
#line 5 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\User\WorkMentorEditView.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(136, 11, true);
            WriteLiteral("</h1>\r\n\r\n\r\n");
            EndContext();
#line 8 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\User\WorkMentorEditView.cshtml"
 using (@Html.BeginForm("EditWorkMentor", "User", FormMethod.Post))
{
    

#line default
#line hidden
            BeginContext(224, 23, false);
#line 10 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\User\WorkMentorEditView.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(249, 30, true);
            WriteLiteral("<div class=\"form-group\">\r\n    ");
            EndContext();
            BeginContext(280, 25, false);
#line 12 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\User\WorkMentorEditView.cshtml"
Write(Html.HiddenFor(x => x.Id));

#line default
#line hidden
            EndContext();
            BeginContext(305, 6, true);
            WriteLiteral("\r\n    ");
            EndContext();
            BeginContext(312, 100, false);
#line 13 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\User\WorkMentorEditView.cshtml"
Write(Html.TextBoxFor(x => x.FirstName, new { placeholder = "Enter first name", @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(412, 6, true);
            WriteLiteral("\r\n    ");
            EndContext();
            BeginContext(419, 102, false);
#line 14 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\User\WorkMentorEditView.cshtml"
Write(Html.TextBoxFor(x => x.SecondName, new { placeholder = "Enter second name", @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(521, 6, true);
            WriteLiteral("\r\n    ");
            EndContext();
            BeginContext(528, 98, false);
#line 15 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\User\WorkMentorEditView.cshtml"
Write(Html.TextBoxFor(x => x.LastName, new { placeholder = "Enter last name", @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(626, 6, true);
            WriteLiteral("\r\n    ");
            EndContext();
            BeginContext(633, 104, false);
#line 16 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\User\WorkMentorEditView.cshtml"
Write(Html.TextBoxFor(x => x.CompanyName, new { placeholder = "Enter Company Name", @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(737, 6, true);
            WriteLiteral("\r\n    ");
            EndContext();
            BeginContext(744, 95, false);
#line 17 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\User\WorkMentorEditView.cshtml"
Write(Html.TextBoxFor(x => x.Address, new { placeholder = "Enter address", @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(839, 6, true);
            WriteLiteral("\r\n    ");
            EndContext();
            BeginContext(846, 104, false);
#line 18 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\User\WorkMentorEditView.cshtml"
Write(Html.TextBoxFor(x => x.PhoneNumber, new { placeholder = "Enter phone number", @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(950, 10, true);
            WriteLiteral("\r\n</div>\r\n");
            EndContext();
            BeginContext(962, 67, true);
            WriteLiteral("    <button type=\"submit\" class=\"btn btn-primary\">Submit</button>\r\n");
            EndContext();
#line 22 "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\User\WorkMentorEditView.cshtml"
}

#line default
#line hidden
            BeginContext(1032, 110, true);
            WriteLiteral("<script>\r\n    $(document).ready(function () {\r\n        $(\'.selectpicker\').selectpicker();\r\n    })\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Apprenticeship.Models.Intermediate.IntermediateMentor> Html { get; private set; }
    }
}
#pragma warning restore 1591
