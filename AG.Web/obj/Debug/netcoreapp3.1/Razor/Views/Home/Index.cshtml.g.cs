#pragma checksum "D:\UCS\2020-01 - Inteligencia computacional\ExemploAlgoritimoGenetico\ExemploAlgoritimoGenetico\AG.Web\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c28c17f2f08c1ff37a08ee2ad542dcccf3c74ca7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "D:\UCS\2020-01 - Inteligencia computacional\ExemploAlgoritimoGenetico\ExemploAlgoritimoGenetico\AG.Web\Views\_ViewImports.cshtml"
using AG.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\UCS\2020-01 - Inteligencia computacional\ExemploAlgoritimoGenetico\ExemploAlgoritimoGenetico\AG.Web\Views\_ViewImports.cshtml"
using AG.Web.Domain;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c28c17f2f08c1ff37a08ee2ad542dcccf3c74ca7", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7cbee0e94ad6bd0220fa17354b662762d35e25a1", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/labirinto.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 1 "D:\UCS\2020-01 - Inteligencia computacional\ExemploAlgoritimoGenetico\ExemploAlgoritimoGenetico\AG.Web\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c28c17f2f08c1ff37a08ee2ad542dcccf3c74ca74181", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<div class=""row"">
    <div class=""col-md-6 text-center"">
        <h4>Busca de caminho via Algoritmo Genético</h4>
    </div>
    <div class=""col-md-6 text-center"">
        <h4>Detalhes</h4>
    </div>
</div>

<div class=""row""> 
    <div class=""col-md-6"">
        <table id=""labirinto"" cellspadding=""0"" cellspacing=""0"" border=""0"">
            <tr>
                <td class=""borda-topo borda-left "" data-x=""0"" data-y=""3""></td>
                <td class=""borda-topo"" data-x=""1"" data-y=""3""></td>
                <td class=""borda-topo"" data-x=""2"" data-y=""3""></td>
                <td class=""borda-topo"" data-x=""3"" data-y=""3""></td>
            </tr>
            <tr>
                <td class=""borda-left"" data-x=""0"" data-y=""2""></td>
                <td data-x=""1"" data-y=""2"" class=""parede1""></td>
                <td data-x=""2"" data-y=""2""></td>
                <td data-x=""3"" data-y=""2""></td>
            </tr>
            <tr>
                <td class=""borda-left"" data-x=""0"" data-y=""1""></td>
   ");
            WriteLiteral(@"             <td data-x=""1"" data-y=""1"" class=""parede2""></td>
                <td data-x=""2"" data-y=""1""></td>
                <td data-x=""3"" data-y=""1"" class=""parede3""></td>
            </tr>
            <tr>
                <td class=""borda-bottom"" data-x=""0"" data-y=""0""></td>
                <td class=""borda-bottom"" data-x=""1"" data-y=""0""></td>
                <td class=""borda-bottom"" data-x=""2"" data-y=""0""></td>
                <td class=""borda-bottom"" data-x=""3"" data-y=""0""></td>
            </tr>
        </table>
        
        <button class=""btn btn-block btn-dark mt-2 "" type=""button"" 
                id=""btn-iniciar"">Iniciar</button>
    </div>
    <div class=""col-md-6"">
        <div class=""detalhes""></div>
    </div>
</div>");
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
