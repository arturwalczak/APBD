#pragma checksum "C:\Users\artur.walczak\OneDrive\PJATK\APBD\GIT czesiek2000\apbd\zadanie11\cwiczenia11\Shared\MainLayout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5c2fe76d451b95f97f01353fd9a18ae937f404be"
// <auto-generated/>
#pragma warning disable 1591
namespace cwiczenia11.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\artur.walczak\OneDrive\PJATK\APBD\GIT czesiek2000\apbd\zadanie11\cwiczenia11\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\artur.walczak\OneDrive\PJATK\APBD\GIT czesiek2000\apbd\zadanie11\cwiczenia11\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\artur.walczak\OneDrive\PJATK\APBD\GIT czesiek2000\apbd\zadanie11\cwiczenia11\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\artur.walczak\OneDrive\PJATK\APBD\GIT czesiek2000\apbd\zadanie11\cwiczenia11\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\artur.walczak\OneDrive\PJATK\APBD\GIT czesiek2000\apbd\zadanie11\cwiczenia11\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\artur.walczak\OneDrive\PJATK\APBD\GIT czesiek2000\apbd\zadanie11\cwiczenia11\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\artur.walczak\OneDrive\PJATK\APBD\GIT czesiek2000\apbd\zadanie11\cwiczenia11\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\artur.walczak\OneDrive\PJATK\APBD\GIT czesiek2000\apbd\zadanie11\cwiczenia11\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\artur.walczak\OneDrive\PJATK\APBD\GIT czesiek2000\apbd\zadanie11\cwiczenia11\_Imports.razor"
using cwiczenia11;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\artur.walczak\OneDrive\PJATK\APBD\GIT czesiek2000\apbd\zadanie11\cwiczenia11\_Imports.razor"
using cwiczenia11.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\artur.walczak\OneDrive\PJATK\APBD\GIT czesiek2000\apbd\zadanie11\cwiczenia11\_Imports.razor"
using cwiczenia11.Models;

#line default
#line hidden
#nullable disable
    public partial class MainLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "page");
            __builder.AddAttribute(2, "b-wfjrd4oe14");
            __builder.AddMarkupContent(3, @"<div class=""sidebar pt-3"" style=""        text-align: center;
        color: white;
        background-color: #0b057a;
        background-image: none"" b-wfjrd4oe14>
        Blazor - client side
        <br b-wfjrd4oe14>
        <div class=""pt-4"" b-wfjrd4oe14>Studenci</div></div>

    ");
            __builder.OpenElement(4, "div");
            __builder.AddAttribute(5, "class", "main");
            __builder.AddAttribute(6, "b-wfjrd4oe14");
            __builder.AddMarkupContent(7, "<div class=\"top-row px-4\" b-wfjrd4oe14><a href=\"https://docs.microsoft.com/aspnet/\" target=\"_blank\" b-wfjrd4oe14>About</a></div>\r\n\r\n        ");
            __builder.OpenElement(8, "div");
            __builder.AddAttribute(9, "class", "content px-4");
            __builder.AddAttribute(10, "b-wfjrd4oe14");
#nullable restore
#line 19 "C:\Users\artur.walczak\OneDrive\PJATK\APBD\GIT czesiek2000\apbd\zadanie11\cwiczenia11\Shared\MainLayout.razor"
__builder.AddContent(11, Body);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
