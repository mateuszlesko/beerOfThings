#pragma checksum "C:\Users\mateusz\source\repos\LeśkoMateuszBazaDanychProjekt\LeśkoMateuszBazaDanychProjekt\beerOfThings\Views\Recipe\MoveToRecipeStage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4902a91455b3a942861993c47850e94ccbb7a818"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Recipe_MoveToRecipeStage), @"mvc.1.0.view", @"/Views/Recipe/MoveToRecipeStage.cshtml")]
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
#line 1 "C:\Users\mateusz\source\repos\LeśkoMateuszBazaDanychProjekt\LeśkoMateuszBazaDanychProjekt\beerOfThings\Views\_ViewImports.cshtml"
using beerOfThings;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\mateusz\source\repos\LeśkoMateuszBazaDanychProjekt\LeśkoMateuszBazaDanychProjekt\beerOfThings\Views\_ViewImports.cshtml"
using beerOfThings.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4902a91455b3a942861993c47850e94ccbb7a818", @"/Views/Recipe/MoveToRecipeStage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30a58a283901eabfb701c67cb55a17f6ca2219db", @"/Views/_ViewImports.cshtml")]
    public class Views_Recipe_MoveToRecipeStage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<beerOfThings.Models.Recipe>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 4 "C:\Users\mateusz\source\repos\LeśkoMateuszBazaDanychProjekt\LeśkoMateuszBazaDanychProjekt\beerOfThings\Views\Recipe\MoveToRecipeStage.cshtml"
Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n<div class=\"flex\">\r\n    <div class=\"flex-initial\">\r\n        <a href=\"/Recipe/Index\">Wszystkie receptury</a>\r\n    </div>\r\n    <div class=\"flex-initial\">\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 226, "\"", 261, 2);
            WriteAttributeValue("", 233, "/Recipe/Details?Id=", 233, 19, true);
#nullable restore
#line 11 "C:\Users\mateusz\source\repos\LeśkoMateuszBazaDanychProjekt\LeśkoMateuszBazaDanychProjekt\beerOfThings\Views\Recipe\MoveToRecipeStage.cshtml"
WriteAttributeValue("", 252, Model.Id, 252, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Szczegóły</a>\r\n    </div>\r\n    <div class=\"flex-initial\">\r\n        <a href=\"/Recipe/AddIngredientToRecipe\">Dodaj składnik</a>\r\n    </div>\r\n    <div class=\"flex-initial\">\r\n        <a href=\"/Stage/Create\">Dodaj etap</a>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<beerOfThings.Models.Recipe> Html { get; private set; }
    }
}
#pragma warning restore 1591