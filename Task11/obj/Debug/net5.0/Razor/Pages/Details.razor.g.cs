#pragma checksum "C:\Users\artur.walczak\OneDrive\PJATK\APBD\GIT czesiek2000\apbd\zadanie11\cwiczenia11\Pages\Details.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5b9398cbb1a272725f7818e99fd053c59520599e"
// <auto-generated/>
#pragma warning disable 1591
namespace cwiczenia11.Pages
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
    [global::Microsoft.AspNetCore.Components.RouteAttribute("/details/{Id:int}")]
    public partial class Details : global::Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3 style=\"text-decoration: underline\">Student\'s details</h3>\r\n");
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "row");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "col");
            __builder.AddMarkupContent(5, "<span>FirstName: </span>\r\n        ");
            __builder.OpenElement(6, "span");
#nullable restore
#line 7 "C:\Users\artur.walczak\OneDrive\PJATK\APBD\GIT czesiek2000\apbd\zadanie11\cwiczenia11\Pages\Details.razor"
__builder.AddContent(7, student.FirstName);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(8, "\r\n    \r\n    ");
            __builder.OpenElement(9, "div");
            __builder.AddAttribute(10, "class", "mt-3");
            __builder.AddMarkupContent(11, "<span>LastName: </span>\r\n        ");
            __builder.OpenElement(12, "span");
#nullable restore
#line 11 "C:\Users\artur.walczak\OneDrive\PJATK\APBD\GIT czesiek2000\apbd\zadanie11\cwiczenia11\Pages\Details.razor"
__builder.AddContent(13, student.LastName);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(14, "\r\n\r\n    ");
            __builder.OpenElement(15, "div");
            __builder.AddAttribute(16, "class", "mt-3");
            __builder.AddMarkupContent(17, "<span>Birtdate: </span>\r\n        ");
            __builder.OpenElement(18, "span");
#nullable restore
#line 16 "C:\Users\artur.walczak\OneDrive\PJATK\APBD\GIT czesiek2000\apbd\zadanie11\cwiczenia11\Pages\Details.razor"
__builder.AddContent(19, student.Birthdate);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\r\n\r\n    ");
            __builder.OpenElement(21, "div");
            __builder.AddAttribute(22, "class", "mt-3");
            __builder.AddMarkupContent(23, "<span>Studies: </span>\r\n        ");
            __builder.OpenElement(24, "span");
#nullable restore
#line 21 "C:\Users\artur.walczak\OneDrive\PJATK\APBD\GIT czesiek2000\apbd\zadanie11\cwiczenia11\Pages\Details.razor"
__builder.AddContent(25, student.Studies);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(26, "\r\n    ");
            __builder.AddMarkupContent(27, "<div class=\"col\"><span>Avatar</span>\r\n        <br>\r\n        <img src alt=\"image preview\"></div>");
            __builder.CloseElement();
            __builder.AddMarkupContent(28, "\r\n    ");
            __builder.AddMarkupContent(29, "<a class=\"btn btn-rounded bg-primary\" href=\"/students\">Return</a>");
        }
        #pragma warning restore 1998
#nullable restore
#line 33 "C:\Users\artur.walczak\OneDrive\PJATK\APBD\GIT czesiek2000\apbd\zadanie11\cwiczenia11\Pages\Details.razor"
       
    [Parameter]
    public int Id { get; set; }
    private List<Student> students;

    Student student;
    string avatar = "";

protected override void OnInitialized ()
{
        students = new List<Student>();
        students.Add( new Student
        {
            Id = 1,
            FirstName = "Jan",
            LastName = "Kowalski",
            Birthdate = "5/24/2021",
            Studies = "Informatyka"
        } );

        students.Add( new Student
        {
            Id = 2,
            FirstName = "Anna",
            LastName = "Kowalska",
            Birthdate = "5/25/2021",
            Studies = "Informatyka"
        } );

        student = new Student();
        student = students.Where( s => s.Id == Id ).FirstOrDefault();
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
