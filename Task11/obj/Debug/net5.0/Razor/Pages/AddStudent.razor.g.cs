#pragma checksum "C:\Users\Dom\OneDrive\PJATK\APBD\APBD\cwiczenia11\Pages\AddStudent.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "44d1f9ac3f303ca563d333596cb17f968bc46588"
// <auto-generated/>
#pragma warning disable 1591
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
#line 2 "C:\Users\Dom\OneDrive\PJATK\APBD\APBD\cwiczenia11\Pages\AddStudent.razor"
using Task11.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Components.RouteAttribute("/add")]
    public partial class AddStudent : global::Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3 style=\"text-decoration: underline\">Student\'s details</h3>\r\n\r\n");
            __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.EditForm>(1);
            __builder.AddAttribute(2, "Model", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.Object>(
#nullable restore
#line 5 "C:\Users\Dom\OneDrive\PJATK\APBD\APBD\cwiczenia11\Pages\AddStudent.razor"
                 Student

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(3, "ChildContent", (global::Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenElement(4, "div");
                __builder2.AddAttribute(5, "class", "form-group");
                __builder2.AddMarkupContent(6, "<label>First name:</label>\r\n        ");
                __builder2.OpenElement(7, "div");
                __builder2.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputText>(8);
                __builder2.AddAttribute(9, "class", "form-control");
                __builder2.AddAttribute(10, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.String>(
#nullable restore
#line 10 "C:\Users\Dom\OneDrive\PJATK\APBD\APBD\cwiczenia11\Pages\AddStudent.razor"
                                                          Student.FirstName

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(11, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::Microsoft.AspNetCore.Components.EventCallback<global::System.String>>(global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<global::System.String>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Student.FirstName = __value, Student.FirstName))));
                __builder2.AddAttribute(12, "ValueExpression", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.Linq.Expressions.Expression<System.Func<System.String>>>(() => Student.FirstName));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(13, "\r\n    ");
                __builder2.OpenElement(14, "div");
                __builder2.AddAttribute(15, "class", "form-group");
                __builder2.AddMarkupContent(16, "<label>Last name:</label>\r\n        ");
                __builder2.OpenElement(17, "div");
                __builder2.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputText>(18);
                __builder2.AddAttribute(19, "class", "form-control");
                __builder2.AddAttribute(20, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.String>(
#nullable restore
#line 16 "C:\Users\Dom\OneDrive\PJATK\APBD\APBD\cwiczenia11\Pages\AddStudent.razor"
                                                          Student.LastName

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(21, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::Microsoft.AspNetCore.Components.EventCallback<global::System.String>>(global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<global::System.String>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Student.LastName = __value, Student.LastName))));
                __builder2.AddAttribute(22, "ValueExpression", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.Linq.Expressions.Expression<System.Func<System.String>>>(() => Student.LastName));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(23, "\r\n    \r\n    ");
                __builder2.OpenElement(24, "div");
                __builder2.AddAttribute(25, "class", "form-group");
                __builder2.AddMarkupContent(26, "<label>Birtdate:</label>\r\n        ");
                __builder2.OpenElement(27, "div");
                __builder2.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputText>(28);
                __builder2.AddAttribute(29, "class", "form-control");
                __builder2.AddAttribute(30, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.String>(
#nullable restore
#line 23 "C:\Users\Dom\OneDrive\PJATK\APBD\APBD\cwiczenia11\Pages\AddStudent.razor"
                                                          Student.Birthdate

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(31, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::Microsoft.AspNetCore.Components.EventCallback<global::System.String>>(global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<global::System.String>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Student.Birthdate = __value, Student.Birthdate))));
                __builder2.AddAttribute(32, "ValueExpression", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.Linq.Expressions.Expression<System.Func<System.String>>>(() => Student.Birthdate));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(33, "\r\n    ");
                __builder2.OpenElement(34, "div");
                __builder2.AddAttribute(35, "class", "form-group");
                __builder2.AddMarkupContent(36, "<label>Studies:</label>\r\n        ");
                __builder2.OpenElement(37, "div");
                __builder2.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputText>(38);
                __builder2.AddAttribute(39, "class", "form-control");
                __builder2.AddAttribute(40, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.String>(
#nullable restore
#line 29 "C:\Users\Dom\OneDrive\PJATK\APBD\APBD\cwiczenia11\Pages\AddStudent.razor"
                                                          Student.Studies

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(41, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::Microsoft.AspNetCore.Components.EventCallback<global::System.String>>(global::Microsoft.AspNetCore.Components.EventCallback.Factory.Create<global::System.String>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Student.Studies = __value, Student.Studies))));
                __builder2.AddAttribute(42, "ValueExpression", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.Linq.Expressions.Expression<System.Func<System.String>>>(() => Student.Studies));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(43, "\r\n    ");
#nullable restore
#line 32 "C:\Users\Dom\OneDrive\PJATK\APBD\APBD\cwiczenia11\Pages\AddStudent.razor"
__builder2.AddContent(44, Student.FirstName);

#line default
#line hidden
#nullable disable
                __builder2.AddContent(45, ", ");
#nullable restore
#line 32 "C:\Users\Dom\OneDrive\PJATK\APBD\APBD\cwiczenia11\Pages\AddStudent.razor"
__builder2.AddContent(46, Student.LastName);

#line default
#line hidden
#nullable disable
                __builder2.AddContent(47, ", ");
#nullable restore
#line 32 "C:\Users\Dom\OneDrive\PJATK\APBD\APBD\cwiczenia11\Pages\AddStudent.razor"
__builder2.AddContent(48, Student.Birthdate);

#line default
#line hidden
#nullable disable
                __builder2.AddContent(49, ", ");
#nullable restore
#line 32 "C:\Users\Dom\OneDrive\PJATK\APBD\APBD\cwiczenia11\Pages\AddStudent.razor"
__builder2.AddContent(50, Student.Studies);

#line default
#line hidden
#nullable disable
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 43 "C:\Users\Dom\OneDrive\PJATK\APBD\APBD\cwiczenia11\Pages\AddStudent.razor"
       
    public Student Student { get; set; }
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 48 "C:\Users\Dom\OneDrive\PJATK\APBD\APBD\cwiczenia11\Pages\AddStudent.razor"
       
    protected override void OnInitialized ()
    {
        Student = new Student();
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
