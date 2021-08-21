#pragma checksum "C:\Users\mateusz\source\repos\LeśkoMateuszBazaDanychProjekt\LeśkoMateuszBazaDanychProjekt\beerOfThings\Views\Process\Current.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "54d30f875277408c4b7b30c600ea92deef5de936"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"54d30f875277408c4b7b30c600ea92deef5de936", @"/Views/Process/Current.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30a58a283901eabfb701c67cb55a17f6ca2219db", @"/Views/_ViewImports.cshtml")]
    public class Views_Process_Current : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<beerOfThings.ViewModels.ProcessDetails>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
            WriteLiteral("\n");
#nullable restore
#line 7 "C:\Users\mateusz\source\repos\LeśkoMateuszBazaDanychProjekt\LeśkoMateuszBazaDanychProjekt\beerOfThings\Views\Process\Current.cshtml"
   int current = System.Convert.ToInt32(Context.Request.Cookies["currentState"]); 

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\mateusz\source\repos\LeśkoMateuszBazaDanychProjekt\LeśkoMateuszBazaDanychProjekt\beerOfThings\Views\Process\Current.cshtml"
   int end = System.Convert.ToInt32(Context.Request.Cookies["endState"]); 

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h1>");
#nullable restore
#line 10 "C:\Users\mateusz\source\repos\LeśkoMateuszBazaDanychProjekt\LeśkoMateuszBazaDanychProjekt\beerOfThings\Views\Process\Current.cshtml"
   Write(Model.recipe.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\n");
#nullable restore
#line 12 "C:\Users\mateusz\source\repos\LeśkoMateuszBazaDanychProjekt\LeśkoMateuszBazaDanychProjekt\beerOfThings\Views\Process\Current.cshtml"
     if (current < end)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p>\n            <span>Obecny etap : ");
#nullable restore
#line 15 "C:\Users\mateusz\source\repos\LeśkoMateuszBazaDanychProjekt\LeśkoMateuszBazaDanychProjekt\beerOfThings\Views\Process\Current.cshtml"
                           Write(Model.brewing[current].Stage.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n        </p>\n        <p>\n            <span>Temperatura: ");
#nullable restore
#line 18 "C:\Users\mateusz\source\repos\LeśkoMateuszBazaDanychProjekt\LeśkoMateuszBazaDanychProjekt\beerOfThings\Views\Process\Current.cshtml"
                          Write(Model.brewing[current].Stage.OptimalTemperature);

#line default
#line hidden
#nullable disable
            WriteLiteral(" °C</span>\n        </p>\n        <p>\n            <span>Czas : ");
#nullable restore
#line 21 "C:\Users\mateusz\source\repos\LeśkoMateuszBazaDanychProjekt\LeśkoMateuszBazaDanychProjekt\beerOfThings\Views\Process\Current.cshtml"
                    Write(Model.brewing[current].Stage.Minutes);

#line default
#line hidden
#nullable disable
            WriteLiteral(" minut</span>\n        </p>\n");
            WriteLiteral("        <div>\n            <h4>Proces zakończy się za:</h4>\n            <p id=\"countdown\"></p>\n\n        </div>\n");
            WriteLiteral("        <a class=\"bg-yellow-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded\" href=\"/Process/Previous\">Poprzedni</a>\n        <a class=\"bg-green-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded\"href=\"/Process/Next\"> Dalej </a>\n");
#nullable restore
#line 33 "C:\Users\mateusz\source\repos\LeśkoMateuszBazaDanychProjekt\LeśkoMateuszBazaDanychProjekt\beerOfThings\Views\Process\Current.cshtml"
    }
    else if (current >= end)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h2>Skończono proces</h2>\n");
#nullable restore
#line 37 "C:\Users\mateusz\source\repos\LeśkoMateuszBazaDanychProjekt\LeśkoMateuszBazaDanychProjekt\beerOfThings\Views\Process\Current.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h2>BłĄD</h2>\n");
#nullable restore
#line 41 "C:\Users\mateusz\source\repos\LeśkoMateuszBazaDanychProjekt\LeśkoMateuszBazaDanychProjekt\beerOfThings\Views\Process\Current.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<canvas id=\"line-chart\" width=\"800\" height=\"450\"></canvas>\n<script src=\"https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.5.0/Chart.min.js\"></script>\n<script>\n    let end = ");
#nullable restore
#line 47 "C:\Users\mateusz\source\repos\LeśkoMateuszBazaDanychProjekt\LeśkoMateuszBazaDanychProjekt\beerOfThings\Views\Process\Current.cshtml"
         Write(Model.brewing[current].Stage.Minutes);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" * 60000;
    let now = new Date().getTime();
    let breakPoint = new Date(now + end).getTime();
    var countdown = setInterval(function () {
        now = new Date().getTime();
        let distance = breakPoint - now;
        console.log(distance);
        let minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
        let seconds = Math.floor((distance % (1000 * 60)) / 1000);

        document.getElementById(""countdown"").innerHTML = minutes + "" min "" + seconds+"" s""

        if (distance < 0) {
            clearInterval(countdown);
            document.getElementById(""countdown"").innerHTML = ""Skończony, przejdź do następnego etapu"";
        }
    }, 1000);


    losowo = new Array();
    for (var i = 0; i < 10; i++) {
        losowo.push(Math.round(Math.random() * 80));
    }

    new Chart(document.getElementById(""line-chart""), {
        type: 'line',
        data: {
            labels: [20, 30, 40, 50, 60, 70, 18, 90, 110, 120],
            datasets: [{
                data: [66, 66, 66, 6");
            WriteLiteral(@"8, 70, 71, 73, 73, 78, 78],
                label: ""Optymalna temperatura"",
                borderColor: ""#3e95cd"",
                fill: false
            }, {
                data: losowo,
                label: ""Temperatura z czujnika"",
                borderColor: ""#8e5ea2"",
                fill: false
            }
            ]
        },
        options: {
            title: {
                display: true,
                text: 'Proces grzania'
            }
        }
    });
</script>
");
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
