#pragma checksum "C:\Users\khaled.owais\source\repos\Apprenticeship\Apprenticeship\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c6a0e77cfdae6e5a7e40c9895fdc9e782efee085"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c6a0e77cfdae6e5a7e40c9895fdc9e782efee085", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2e2c6e62d89213ead4ebbf0e81e2309d0bd9bf99", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("masthead-avatar mb-5"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/logo.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 178, true);
            WriteLiteral("<header class=\"masthead bg-primary text-white text-center\">\r\n    <div class=\"container d-flex align-items-center flex-column\">\r\n\r\n        <!-- Masthead Avatar Image -->\r\n        ");
            EndContext();
            BeginContext(178, 62, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "c6a0e77cfdae6e5a7e40c9895fdc9e782efee0854471", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(240, 4618, true);
            WriteLiteral(@"

        <!-- Masthead Heading -->
        <h1 class=""masthead-heading text-uppercase mb-0"">Apprenticeship</h1>   

        <!-- Icon Divider -->
        <div class=""divider-custom divider-light"">
            <div class=""divider-custom-line""></div>
            <div class=""divider-custom-icon"">
                <i class=""fas fa-star""></i>
            </div>
            <div class=""divider-custom-line""></div>
        </div>

        <!-- Masthead Subheading -->
        <p class=""masthead-subheading font-weight-light mb-0"">Training Program</p>

    </div>
</header>
<section class=""bg-light page-section"" id=""team"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-12 text-center"">
                <h2 class=""section-heading text-uppercase"">Our Amazing Team</h2>
                <h3 class=""section-subheading text-muted"">Lorem ipsum dolor sit amet consectetur.</h3>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-sm-");
            WriteLiteral(@"4"">
                <div class=""team-member"">
                    <img class=""mx-auto rounded-circle"" src=""img/team/1.jpg"" alt="""">
                    <h4>Kay Garland</h4>
                    <p class=""text-muted"">Lead Designer</p>
                    <ul class=""list-inline social-buttons"">
                        <li class=""list-inline-item"">
                            <a href=""#"">
                                <i class=""fab fa-twitter""></i>
                            </a>
                        </li>
                        <li class=""list-inline-item"">
                            <a href=""#"">
                                <i class=""fab fa-facebook-f""></i>
                            </a>
                        </li>
                        <li class=""list-inline-item"">
                            <a href=""#"">
                                <i class=""fab fa-linkedin-in""></i>
                            </a>
                        </li>
                    </ul>
              ");
            WriteLiteral(@"  </div>
            </div>
            <div class=""col-sm-4"">
                <div class=""team-member"">
                    <img class=""mx-auto rounded-circle"" src=""img/team/2.jpg"" alt="""">
                    <h4>Larry Parker</h4>
                    <p class=""text-muted"">Lead Marketer</p>
                    <ul class=""list-inline social-buttons"">
                        <li class=""list-inline-item"">
                            <a href=""#"">
                                <i class=""fab fa-twitter""></i>
                            </a>
                        </li>
                        <li class=""list-inline-item"">
                            <a href=""#"">
                                <i class=""fab fa-facebook-f""></i>
                            </a>
                        </li>
                        <li class=""list-inline-item"">
                            <a href=""#"">
                                <i class=""fab fa-linkedin-in""></i>
                            </a>
          ");
            WriteLiteral(@"              </li>
                    </ul>
                </div>
            </div>
            <div class=""col-sm-4"">
                <div class=""team-member"">
                    <img class=""mx-auto rounded-circle"" src=""img/team/3.jpg"" alt="""">
                    <h4>Diana Pertersen</h4>
                    <p class=""text-muted"">Lead Developer</p>
                    <ul class=""list-inline social-buttons"">
                        <li class=""list-inline-item"">
                            <a href=""#"">
                                <i class=""fab fa-twitter""></i>
                            </a>
                        </li>
                        <li class=""list-inline-item"">
                            <a href=""#"">
                                <i class=""fab fa-facebook-f""></i>
                            </a>
                        </li>
                        <li class=""list-inline-item"">
                            <a href=""#"">
                                <i class=""fab ");
            WriteLiteral(@"fa-linkedin-in""></i>
                            </a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-lg-8 mx-auto text-center"">
                <p class=""large text-muted"">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Aut eaque, laboriosam veritatis, quos non quis ad perspiciatis, totam corporis ea, alias ut unde.</p>
            </div>
        </div>
    </div>
</section>
");
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
