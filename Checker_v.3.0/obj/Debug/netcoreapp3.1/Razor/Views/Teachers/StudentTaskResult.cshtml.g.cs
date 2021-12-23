#pragma checksum "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\Teachers\StudentTaskResult.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ffc8eece15e05a443c1b07b6c4129fc45628dbd0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Teachers_StudentTaskResult), @"mvc.1.0.view", @"/Views/Teachers/StudentTaskResult.cshtml")]
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
#line 1 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\_ViewImports.cshtml"
using Checker_v._3._0;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\_ViewImports.cshtml"
using Checker_v._3._0.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\_ViewImports.cshtml"
using Checker_v._3._0.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ffc8eece15e05a443c1b07b6c4129fc45628dbd0", @"/Views/Teachers/StudentTaskResult.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e5216894ffc3f2ee193a0d81c5a118e23cbf7a5", @"/Views/_ViewImports.cshtml")]
    public class Views_Teachers_StudentTaskResult : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<StudentTaskDto>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<strong>");
#nullable restore
#line 3 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\Teachers\StudentTaskResult.cshtml"
   Write(Model.TeacherResult.Student.GroupTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 3 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\Teachers\StudentTaskResult.cshtml"
                                             Write(Model.TeacherResult.Student.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 3 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\Teachers\StudentTaskResult.cshtml"
                                                                                   Write(Model.TeacherResult.Student.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n<br />\r\n<label>Постановка задачи: ");
#nullable restore
#line 5 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\Teachers\StudentTaskResult.cshtml"
                     Write(Model.Task.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n<br />\r\n<strong>Решение:</strong>\r\n<br />\r\n");
#nullable restore
#line 9 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\Teachers\StudentTaskResult.cshtml"
  
    var solutionDateTime = Model.TeacherResult.SolutionLoadDateTime.HasValue ?
        Model.TeacherResult.SolutionLoadDateTime.Value.ToString("HH.mm") + " " + Model.TeacherResult.SolutionLoadDateTime.Value.ToString("dd.MM.yy") :
        "";

#line default
#line hidden
#nullable disable
            WriteLiteral("<label>Дата последней загрузки........</label><label id=\"solutionLoadedDateTime\">");
#nullable restore
#line 14 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\Teachers\StudentTaskResult.cshtml"
                                                                            Write(solutionDateTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n<br />\r\n<label>Прошло тестов     </label><label id=\"passedTestsCountLabel\">");
#nullable restore
#line 16 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\Teachers\StudentTaskResult.cshtml"
                                                              Write(Model.TeacherResult.SuccessTestsCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label><label>/");
#nullable restore
#line 16 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\Teachers\StudentTaskResult.cshtml"
                                                                                                                    Write(Model.Task.Tests.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n<br />\r\n<label>Итоговая оценка     </label><label id=\"editTeacherResultLabel\">");
#nullable restore
#line 18 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\Teachers\StudentTaskResult.cshtml"
                                                                 Write(Model.TeacherResult.TeacherResult);

#line default
#line hidden
#nullable disable
            WriteLiteral("/");
#nullable restore
#line 18 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\Teachers\StudentTaskResult.cshtml"
                                                                                                    Write(Model.Task.MaxResult);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n<br />\r\n<strong>Тесты(</strong><strong id=\"fileNoteText\">");
#nullable restore
#line 20 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\Teachers\StudentTaskResult.cshtml"
                                             Write(Model.TeacherResult.SolutionLoadDateTime.HasValue ? "Решение загружено" : "Решение не загружено");

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong><strong>):</strong>\r\n<br />\r\n");
#nullable restore
#line 22 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\Teachers\StudentTaskResult.cshtml"
 foreach (var testResult in Model.TestsResults)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <label class=\"testLabel\" data-id=\"");
#nullable restore
#line 24 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\Teachers\StudentTaskResult.cshtml"
                                 Write(testResult.Test.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 24 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\Teachers\StudentTaskResult.cshtml"
                                                      Write(testResult.Test.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ................ ");
#nullable restore
#line 24 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\Teachers\StudentTaskResult.cshtml"
                                                                                              Write(testResult.State.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n    <br />\r\n");
#nullable restore
#line 26 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\Teachers\StudentTaskResult.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<a id=\"downloadSolutionButton\" name=\"downloadSolutionButton\" data-id=\"");
#nullable restore
#line 28 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\Teachers\StudentTaskResult.cshtml"
                                                                 Write(Model.TeacherResult.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"");
            BeginWriteAttribute("href", " href=\"", 1429, "\"", 1483, 1);
#nullable restore
#line 28 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\Teachers\StudentTaskResult.cshtml"
WriteAttributeValue("", 1436, Model.TeacherResult.DownloadStudentSolutionUrl, 1436, 47, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Скачать решение</a>\r\n\r\n<script>\r\n    var StudentTaskResultId = \"");
#nullable restore
#line 31 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\Teachers\StudentTaskResult.cshtml"
                          Write(Model.TeacherResult.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\";\r\n</script>\r\n\r\n<script src=\"/js/teacher.studenttaskresult.js\"></script>\r\n\r\n<div id=\"popupWin\" class=\"formWindow\">\r\n\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<StudentTaskDto> Html { get; private set; }
    }
}
#pragma warning restore 1591
