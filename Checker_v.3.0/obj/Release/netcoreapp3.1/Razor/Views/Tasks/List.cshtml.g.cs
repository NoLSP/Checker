#pragma checksum "C:\Users\artem\Desktop\Checker\Checker_v.3.0\Views\Tasks\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a9d9205dbb0bb08ad474033fa806e1ff800aa5da"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tasks_List), @"mvc.1.0.view", @"/Views/Tasks/List.cshtml")]
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
#line 1 "C:\Users\artem\Desktop\Checker\Checker_v.3.0\Views\_ViewImports.cshtml"
using Checker_v._3._0;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\artem\Desktop\Checker\Checker_v.3.0\Views\_ViewImports.cshtml"
using Checker_v._3._0.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\artem\Desktop\Checker\Checker_v.3.0\Views\_ViewImports.cshtml"
using Checker_v._3._0.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9d9205dbb0bb08ad474033fa806e1ff800aa5da", @"/Views/Tasks/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e5216894ffc3f2ee193a0d81c5a118e23cbf7a5", @"/Views/_ViewImports.cshtml")]
    public class Views_Tasks_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TaskDto>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/tasklist.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<style>
    label{
        margin-top: 6px;
        margin-bottom: 6px;
    }

    .head{
        font-size: 16px;
    }

    .formWindow {
        height: 400px;
        width: 400px;
        background-color: white;
        top: 20%; /* отступ сверху */
        right: 0;
        left: 0;
        margin: 0 auto;
        z-index: 2; /* поверх всех */
        display: none; /* сначала невидим */
        position: fixed; /* фиксированное позиционирование, окно стабильно при прокрутке */
        padding: 15px;
    }

    #shadow {
        position: fixed;
        width: 100%;
        height: 100%;
        z-index: 1; /* поверх всех  кроме окна*/
        background: #000;
        opacity: 0.5; /*прозрачность*/
        left: 0;
        top: 0;
    }
</style>

<div class=""buttonsContainer"">
    <div class=""col-2 justify-content-center"">
        <button id=""createButton"">Create</button>
    </div>
</div>

<div class=""container"">
    <div class=""row"">
            <div cla");
            WriteLiteral(@"ss=""col-1 justify-content-center"">
                <label class=""taskId head"">Id</label>
            </div>
            <div class=""col-2 justify-content-center"">
                <label class=""taskTitle head"">Title</label>
            </div>
            <div class=""col-2 justify-content-center"">
                <label class=""taskGroupTitle head"">GroupTitle</label>
            </div>
            <div class=""col-2 justify-content-center"">
                <label class=""taskMaxResult head"">MaxResult</label>
            </div>
        </div>

");
#nullable restore
#line 61 "C:\Users\artem\Desktop\Checker\Checker_v.3.0\Views\Tasks\List.cshtml"
     foreach(var task in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"row\">\r\n            <div class=\"col-1 justify-content-center\">\r\n                <label class=\"taskId\">");
#nullable restore
#line 65 "C:\Users\artem\Desktop\Checker\Checker_v.3.0\Views\Tasks\List.cshtml"
                                 Write(task.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n            </div>\r\n            <div class=\"col-2 justify-content-center\">\r\n                <label class=\"taskTitle\">");
#nullable restore
#line 68 "C:\Users\artem\Desktop\Checker\Checker_v.3.0\Views\Tasks\List.cshtml"
                                    Write(task.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n            </div>\r\n            <div class=\"col-2 justify-content-center\">\r\n                <label class=\"taskGroupTitle\">");
#nullable restore
#line 71 "C:\Users\artem\Desktop\Checker\Checker_v.3.0\Views\Tasks\List.cshtml"
                                         Write(task.TaskGroupTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n            </div>\r\n            <div class=\"col-2 justify-content-center\">\r\n                <label class=\"taskMaxResult\">");
#nullable restore
#line 74 "C:\Users\artem\Desktop\Checker\Checker_v.3.0\Views\Tasks\List.cshtml"
                                        Write(task.MaxResult);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 77 "C:\Users\artem\Desktop\Checker\Checker_v.3.0\Views\Tasks\List.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n<div id=\"popupWin\" class=\"formWindow\">\r\n    \r\n</div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a9d9205dbb0bb08ad474033fa806e1ff800aa5da7318", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TaskDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591