#pragma checksum "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\EntityObjects\_CreateForm.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "583c83bbb2383b4046199bf28d07e7eafe5bac14"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_EntityObjects__CreateForm), @"mvc.1.0.view", @"/Views/EntityObjects/_CreateForm.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"583c83bbb2383b4046199bf28d07e7eafe5bac14", @"/Views/EntityObjects/_CreateForm.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e5216894ffc3f2ee193a0d81c5a118e23cbf7a5", @"/Views/_ViewImports.cshtml")]
    public class Views_EntityObjects__CreateForm : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EntityObjectEditDto>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-select"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\EntityObjects\_CreateForm.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "583c83bbb2383b4046199bf28d07e7eafe5bac144163", async() => {
                WriteLiteral("\r\n    <h2 style=\"text-align:center\" id=\"title\">Создать - ");
#nullable restore
#line 8 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\EntityObjects\_CreateForm.cshtml"
                                                  Write(Model.EntityName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h2>\r\n\r\n");
#nullable restore
#line 10 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\EntityObjects\_CreateForm.cshtml"
     foreach (var field in Model.Fields)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <div class=\"row col-12\">\r\n\r\n            <div class=\"col-5 justify-content-end\">\r\n                <label style=\"font-weight:bold\"");
                BeginWriteAttribute("for", " for=", 333, "", 349, 1);
#nullable restore
#line 15 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\EntityObjects\_CreateForm.cshtml"
WriteAttributeValue("", 338, field.Name, 338, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 15 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\EntityObjects\_CreateForm.cshtml"
                                                           Write(field.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral(":</label>\r\n            </div>\r\n\r\n");
#nullable restore
#line 18 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\EntityObjects\_CreateForm.cshtml"
             if (field.InputType == "select")
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <div class=\"col-7 justify-content-start\">\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "583c83bbb2383b4046199bf28d07e7eafe5bac146188", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "id", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 21 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\EntityObjects\_CreateForm.cshtml"
AddHtmlAttributeValue("", 547, field.Name, 547, 11, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 21 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\EntityObjects\_CreateForm.cshtml"
                                     WriteLiteral(field.Name);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("name", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
#nullable restore
#line 21 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\EntityObjects\_CreateForm.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = field.Values;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                </div>\r\n");
#nullable restore
#line 23 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\EntityObjects\_CreateForm.cshtml"
            }
            else if(field.InputType == "textarea")
            { 

#line default
#line hidden
#nullable disable
                WriteLiteral("                <div class=\"col-7 justify-content-start\">\r\n                    <textarea");
                BeginWriteAttribute("id", " id=", 830, "", 845, 1);
#nullable restore
#line 27 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\EntityObjects\_CreateForm.cshtml"
WriteAttributeValue("", 834, field.Name, 834, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("name", " name=\"", 845, "\"", 863, 1);
#nullable restore
#line 27 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\EntityObjects\_CreateForm.cshtml"
WriteAttributeValue("", 852, field.Name, 852, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 27 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\EntityObjects\_CreateForm.cshtml"
                                                            Write(field.Value);

#line default
#line hidden
#nullable disable
                WriteLiteral("</textarea>\r\n                </div>\r\n");
#nullable restore
#line 29 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\EntityObjects\_CreateForm.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <div class=\"col-7 justify-content-start\">\r\n                    <input");
                BeginWriteAttribute("type", " type=", 1049, "", 1071, 1);
#nullable restore
#line 33 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\EntityObjects\_CreateForm.cshtml"
WriteAttributeValue("", 1055, field.InputType, 1055, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("id", " id=", 1071, "", 1086, 1);
#nullable restore
#line 33 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\EntityObjects\_CreateForm.cshtml"
WriteAttributeValue("", 1075, field.Name, 1075, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("name", " name=\"", 1086, "\"", 1104, 1);
#nullable restore
#line 33 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\EntityObjects\_CreateForm.cshtml"
WriteAttributeValue("", 1093, field.Name, 1093, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 1105, "\"", 1127, 1);
#nullable restore
#line 33 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\EntityObjects\_CreateForm.cshtml"
WriteAttributeValue("", 1113, field.Value, 1113, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("/>\r\n                </div>\r\n");
#nullable restore
#line 35 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\EntityObjects\_CreateForm.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </div>\r\n");
#nullable restore
#line 37 "G:\Files\Projects\C#\Checker\Checker_v.3.0\Views\EntityObjects\_CreateForm.cshtml"
    }

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<div class=\"col-12 justify-content-center\">\r\n    <button style=\"text-align:center;\" id=\"createEntity\">Создать</button>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EntityObjectEditDto> Html { get; private set; }
    }
}
#pragma warning restore 1591
