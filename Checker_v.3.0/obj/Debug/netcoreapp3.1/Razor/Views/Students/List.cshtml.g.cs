#pragma checksum "C:\Users\artem\Desktop\Checker\Checker_v.3.0\Views\Students\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bf2bdfe062d2d7b040b375254a0394a94a24e4f9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Students_List), @"mvc.1.0.view", @"/Views/Students/List.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bf2bdfe062d2d7b040b375254a0394a94a24e4f9", @"/Views/Students/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e5216894ffc3f2ee193a0d81c5a118e23cbf7a5", @"/Views/_ViewImports.cshtml")]
    public class Views_Students_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<StudentDto>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""container"">
    <div class=""row"">
            <div class=""col-1 justify-content-center"">
                <label class=""taskId head"">Id</label>
            </div>
            <div class=""col-2 justify-content-center"">
                <label class=""taskTitle head"">FullName</label>
            </div>
            <div class=""col-2 justify-content-center"">
                <label class=""taskGroupTitle head"">Email</label>
            </div>
            <div class=""col-2 justify-content-center"">
                <label class=""taskMaxResult head"">Groups</label>
            </div>
        </div>

");
#nullable restore
#line 19 "C:\Users\artem\Desktop\Checker\Checker_v.3.0\Views\Students\List.cshtml"
     foreach(var student in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"row\">\r\n            <div class=\"col-1 justify-content-center\">\r\n                <label class=\"taskId\">");
#nullable restore
#line 23 "C:\Users\artem\Desktop\Checker\Checker_v.3.0\Views\Students\List.cshtml"
                                 Write(student.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n            </div>\r\n            <div class=\"col-2 justify-content-center\">\r\n                <label class=\"taskTitle\">");
#nullable restore
#line 26 "C:\Users\artem\Desktop\Checker\Checker_v.3.0\Views\Students\List.cshtml"
                                    Write(student.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n            </div>\r\n            <div class=\"col-2 justify-content-center\">\r\n                <label class=\"taskGroupTitle\">");
#nullable restore
#line 29 "C:\Users\artem\Desktop\Checker\Checker_v.3.0\Views\Students\List.cshtml"
                                         Write(student.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n            </div>\r\n            <div class=\"col-2 justify-content-center\">\r\n                <label class=\"taskMaxResult\">");
#nullable restore
#line 32 "C:\Users\artem\Desktop\Checker\Checker_v.3.0\Views\Students\List.cshtml"
                                        Write(String.Join(", ", student.GroupsTitles));

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 35 "C:\Users\artem\Desktop\Checker\Checker_v.3.0\Views\Students\List.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<StudentDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591