// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Task11.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Dom\OneDrive\PJATK\APBD\APBD\cwiczenia11\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Dom\OneDrive\PJATK\APBD\APBD\cwiczenia11\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Dom\OneDrive\PJATK\APBD\APBD\cwiczenia11\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Dom\OneDrive\PJATK\APBD\APBD\cwiczenia11\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Dom\OneDrive\PJATK\APBD\APBD\cwiczenia11\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Dom\OneDrive\PJATK\APBD\APBD\cwiczenia11\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Dom\OneDrive\PJATK\APBD\APBD\cwiczenia11\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Dom\OneDrive\PJATK\APBD\APBD\cwiczenia11\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Dom\OneDrive\PJATK\APBD\APBD\cwiczenia11\_Imports.razor"
using Task11;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Dom\OneDrive\PJATK\APBD\APBD\cwiczenia11\_Imports.razor"
using Task11.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Dom\OneDrive\PJATK\APBD\APBD\cwiczenia11\_Imports.razor"
using Task11.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Components.RouteAttribute("/details/{Id:int}")]
    public partial class Details : global::Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 33 "C:\Users\Dom\OneDrive\PJATK\APBD\APBD\cwiczenia11\Pages\Details.razor"
       
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