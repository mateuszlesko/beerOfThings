#pragma checksum "C:\Users\mateusz\source\repos\beerOfThings\Views\Process\Current.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9c019cff5f595d7dfa10b0554f7e3a2807b72d36"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Process_Current), @"mvc.1.0.view", @"/Views/Process/Current.cshtml")]
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
#line 1 "C:\Users\mateusz\source\repos\beerOfThings\Views\_ViewImports.cshtml"
using beerOfThings;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\mateusz\source\repos\beerOfThings\Views\_ViewImports.cshtml"
using beerOfThings.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c019cff5f595d7dfa10b0554f7e3a2807b72d36", @"/Views/Process/Current.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30a58a283901eabfb701c67cb55a17f6ca2219db", @"/Views/_ViewImports.cshtml")]
    public class Views_Process_Current : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<beerOfThings.ViewModels.ProcessDetails>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\mateusz\source\repos\beerOfThings\Views\Process\Current.cshtml"
   int current = System.Convert.ToInt32(Context.Request.Cookies["currentState"]); 

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\mateusz\source\repos\beerOfThings\Views\Process\Current.cshtml"
   int end = System.Convert.ToInt32(Context.Request.Cookies["endState"]); 

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h1>");
#nullable restore
#line 10 "C:\Users\mateusz\source\repos\beerOfThings\Views\Process\Current.cshtml"
   Write(Model.recipe.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n");
#nullable restore
#line 12 "C:\Users\mateusz\source\repos\beerOfThings\Views\Process\Current.cshtml"
     if (current < end)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p>\r\n            <span>Obecny etap : ");
#nullable restore
#line 15 "C:\Users\mateusz\source\repos\beerOfThings\Views\Process\Current.cshtml"
                           Write(Model.brewing[current].Stage.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n        </p>\r\n        <p>\r\n            <span>Temperatura: ");
#nullable restore
#line 18 "C:\Users\mateusz\source\repos\beerOfThings\Views\Process\Current.cshtml"
                          Write(Model.brewing[current].Stage.OptimalTemperature);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span>\r\n        </p>\r\n        <p>\r\n            <span>Czas : ");
#nullable restore
#line 21 "C:\Users\mateusz\source\repos\beerOfThings\Views\Process\Current.cshtml"
                    Write(Model.brewing[current].Stage.Minutes);

#line default
#line hidden
#nullable disable
            WriteLiteral(" minut</span>\r\n        </p>\r\n        <a href=\"/Process/Next\"> Dalej </a>\r\n        <a href=\"/Process/Previous\">Poprzedni</a>\r\n");
#nullable restore
#line 25 "C:\Users\mateusz\source\repos\beerOfThings\Views\Process\Current.cshtml"
    }
    else if (current >= end)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h2>Skończono proces</h2>\r\n");
#nullable restore
#line 29 "C:\Users\mateusz\source\repos\beerOfThings\Views\Process\Current.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h2>BłĄD</h2>\r\n");
#nullable restore
#line 33 "C:\Users\mateusz\source\repos\beerOfThings\Views\Process\Current.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<canvas id=""myChart"" width=""400"" height=""400""></canvas>
<script>
    var ctx = document.getElementById('myChart').getContext('2d');
    var myChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: ['Red', 'Blue', 'Yellow', 'Green', 'Purple', 'Orange'],
            datasets: [
                {
                    label: 'Dataset 1',
                    data: Utils.numbers(NUMBER_CFG),
                    borderColor: Utils.CHART_COLORS.red,
                    backgroundColor: Utils.transparentize(Utils.CHART_COLORS.red, 0.5),
                },
                {
                    label: 'Dataset 2',
                    data: Utils.numbers(NUMBER_CFG),
                    borderColor: Utils.CHART_COLORS.blue,
                    backgroundColor: Utils.transparentize(Utils.CHART_COLORS.blue, 0.5),
                }
            ],
        },
        options: {
            scales: {
                y: {
                    beginAtZero: true
              ");
            WriteLiteral("  }\r\n            }\r\n        }\r\n    });\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<beerOfThings.ViewModels.ProcessDetails> Html { get; private set; }
    }
}
#pragma warning restore 1591