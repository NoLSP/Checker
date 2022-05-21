#pragma checksum "C:\Projects\C#\Checker\TaskChecker\Views\Teachers\StudentsGroupDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4602e73ae1a0564db50f323270200cf4beeb7359"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Teachers_StudentsGroupDetail), @"mvc.1.0.view", @"/Views/Teachers/StudentsGroupDetail.cshtml")]
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
#line 1 "C:\Projects\C#\Checker\TaskChecker\Views\_ViewImports.cshtml"
using TaskChecker;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Projects\C#\Checker\TaskChecker\Views\_ViewImports.cshtml"
using TaskChecker.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Projects\C#\Checker\TaskChecker\Views\_ViewImports.cshtml"
using TaskChecker.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4602e73ae1a0564db50f323270200cf4beeb7359", @"/Views/Teachers/StudentsGroupDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f3afaa9a842b73457390b8041a9be99d128a3874", @"/Views/_ViewImports.cshtml")]
    public class Views_Teachers_StudentsGroupDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<StudentsGroupDto>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/teacher.studentgroupdetail.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n<h3>");
#nullable restore
#line 3 "C:\Projects\C#\Checker\TaskChecker\Views\Teachers\StudentsGroupDetail.cshtml"
Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n<button id=\"addStudentToGroup\">Получить ссылку на добавление</button>\r\n<button id=\"addCourseToStudentsGroup\" data-id=\"");
#nullable restore
#line 5 "C:\Projects\C#\Checker\TaskChecker\Views\Teachers\StudentsGroupDetail.cshtml"
                                          Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">Добавить курс</button>\r\n\r\n<div class=\"tabs\">\r\n    <div class=\"tabs__nav\">\r\n");
#nullable restore
#line 9 "C:\Projects\C#\Checker\TaskChecker\Views\Teachers\StudentsGroupDetail.cshtml"
          
            var first = true;
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Projects\C#\Checker\TaskChecker\Views\Teachers\StudentsGroupDetail.cshtml"
         foreach (var course in Model.Courses)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <a");
            BeginWriteAttribute("class", " class=\"", 381, "\"", 435, 2);
            WriteAttributeValue("", 389, "tabs__link", 389, 10, true);
#nullable restore
#line 14 "C:\Projects\C#\Checker\TaskChecker\Views\Teachers\StudentsGroupDetail.cshtml"
WriteAttributeValue(" ", 399, first ? "tabs__link_active" : "", 400, 35, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 436, "\"", 456, 2);
            WriteAttributeValue("", 443, "#", 443, 1, true);
#nullable restore
#line 14 "C:\Projects\C#\Checker\TaskChecker\Views\Teachers\StudentsGroupDetail.cshtml"
WriteAttributeValue("", 444, course.Name, 444, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 14 "C:\Projects\C#\Checker\TaskChecker\Views\Teachers\StudentsGroupDetail.cshtml"
                                                                                      Write(course.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 15 "C:\Projects\C#\Checker\TaskChecker\Views\Teachers\StudentsGroupDetail.cshtml"
            first = false;
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n\r\n    <div class=\"tabs__content\" data-id=");
#nullable restore
#line 19 "C:\Projects\C#\Checker\TaskChecker\Views\Teachers\StudentsGroupDetail.cshtml"
                                  Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(">\r\n");
#nullable restore
#line 20 "C:\Projects\C#\Checker\TaskChecker\Views\Teachers\StudentsGroupDetail.cshtml"
          
            first = true;
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Projects\C#\Checker\TaskChecker\Views\Teachers\StudentsGroupDetail.cshtml"
         foreach (var course in Model.Courses)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div");
            BeginWriteAttribute("class", " class=\"", 706, "\"", 768, 1);
#nullable restore
#line 25 "C:\Projects\C#\Checker\TaskChecker\Views\Teachers\StudentsGroupDetail.cshtml"
WriteAttributeValue("", 714, first ? "tabs__pane tabs__pane_show" : "tabs__pane", 714, 54, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 769, "\"", 786, 1);
#nullable restore
#line 25 "C:\Projects\C#\Checker\TaskChecker\Views\Teachers\StudentsGroupDetail.cshtml"
WriteAttributeValue("", 774, course.Name, 774, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                <table border=""1"" style=""border-color:aliceblue"" width=""100%"">
                    <tr>
                        <th style=""background-color:lightgray"">
                            <strong style=""text-align:left;margin-left:10px"">Студенты</strong>
                        </th>

");
#nullable restore
#line 32 "C:\Projects\C#\Checker\TaskChecker\Views\Teachers\StudentsGroupDetail.cshtml"
                         foreach (var task in course.Tasks)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <th style=\"background-color:lightgray\">\r\n                                <strong style=\"text-align:left;margin-left:10px\">");
#nullable restore
#line 35 "C:\Projects\C#\Checker\TaskChecker\Views\Teachers\StudentsGroupDetail.cshtml"
                                                                            Write(task.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n                            </th>\r\n");
#nullable restore
#line 37 "C:\Projects\C#\Checker\TaskChecker\Views\Teachers\StudentsGroupDetail.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tr>\r\n\r\n");
#nullable restore
#line 40 "C:\Projects\C#\Checker\TaskChecker\Views\Teachers\StudentsGroupDetail.cshtml"
                     foreach (var student in Model.Students)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td style=\"background-color:antiquewhite\">\r\n                                <strong>");
#nullable restore
#line 44 "C:\Projects\C#\Checker\TaskChecker\Views\Teachers\StudentsGroupDetail.cshtml"
                                   Write(student.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n                            </td>\r\n\r\n");
#nullable restore
#line 47 "C:\Projects\C#\Checker\TaskChecker\Views\Teachers\StudentsGroupDetail.cshtml"
                             foreach (var task in course.Tasks)
                            {
                                var taskResult = course.TasksResults
                                    .FirstOrDefault(x => x.StudentId == student.Id && x.TaskId == task.Id);
                                var result = taskResult == null ? "-" : $"{taskResult.TeacherResult}/{task.MaxResult}";


#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td style=\"background-color:antiquewhite\">\r\n\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 2244, "\"", 2272, 1);
#nullable restore
#line 55 "C:\Projects\C#\Checker\TaskChecker\Views\Teachers\StudentsGroupDetail.cshtml"
WriteAttributeValue("", 2251, taskResult.DetailUrl, 2251, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"text-align:center;margin-left:10px\">");
#nullable restore
#line 55 "C:\Projects\C#\Checker\TaskChecker\Views\Teachers\StudentsGroupDetail.cshtml"
                                                                                                          Write(result);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n\r\n                                </td>\r\n");
#nullable restore
#line 58 "C:\Projects\C#\Checker\TaskChecker\Views\Teachers\StudentsGroupDetail.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tr>\r\n");
#nullable restore
#line 60 "C:\Projects\C#\Checker\TaskChecker\Views\Teachers\StudentsGroupDetail.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </table>\r\n            </div>\r\n");
#nullable restore
#line 63 "C:\Projects\C#\Checker\TaskChecker\Views\Teachers\StudentsGroupDetail.cshtml"
            first = false;
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n\r\n<div id=\"popupWin\" class=\"formWindow\">\r\n\r\n</div>\r\n\r\n<script>\r\n    var StudentGroupId = ");
#nullable restore
#line 73 "C:\Projects\C#\Checker\TaskChecker\Views\Teachers\StudentsGroupDetail.cshtml"
                    Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n</script>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4602e73ae1a0564db50f323270200cf4beeb735912359", async() => {
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<StudentsGroupDto> Html { get; private set; }
    }
}
#pragma warning restore 1591
