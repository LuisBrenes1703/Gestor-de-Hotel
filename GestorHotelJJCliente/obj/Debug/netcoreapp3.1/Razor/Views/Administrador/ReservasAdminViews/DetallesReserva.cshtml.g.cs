#pragma checksum "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\Administrador\ReservasAdminViews\DetallesReserva.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cf9b86b31d4e7b59e44272a955843351404f8c95"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Administrador_ReservasAdminViews_DetallesReserva), @"mvc.1.0.view", @"/Views/Administrador/ReservasAdminViews/DetallesReserva.cshtml")]
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
#line 1 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\_ViewImports.cshtml"
using GestorHotelJJCliente;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\_ViewImports.cshtml"
using GestorHotelJJCliente.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf9b86b31d4e7b59e44272a955843351404f8c95", @"/Views/Administrador/ReservasAdminViews/DetallesReserva.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ecd6c48b401fdca329ed2a3e5e99f3678329fdf8", @"/Views/_ViewImports.cshtml")]
    public class Views_Administrador_ReservasAdminViews_DetallesReserva : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/scriptReserva.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "ReservaAdmin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ReporteReservaView", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\Administrador\ReservasAdminViews\DetallesReserva.cshtml"
  
    ViewData["Title"] = "DetallesReserva";

    if (ViewBag.PermisoUsuario == "1")
    {
        Layout = "/Views/Administrador/Shared/_LayoutAdministrador.cshtml";


    }
    else if (ViewBag.PermisoUsuario == null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <script>\r\n\r\n            redireccion(\'/Usuario/MuestraLoginUsuario\');\r\n\r\n            function redireccion(direccion) {\r\n                document.location.href = direccion;\r\n            }\r\n\r\n\r\n        </script>\r\n");
#nullable restore
#line 22 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\Administrador\ReservasAdminViews\DetallesReserva.cshtml"
    }
    else if (ViewBag.PermisoUsuario == "")
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <script>\r\n            redireccion(\'/Usuario/MuestraLoginUsuario\');\r\n\r\n            function redireccion(direccion) {\r\n                document.location.href = direccion;\r\n            }\r\n\r\n\r\n        </script>\r\n");
#nullable restore
#line 34 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\Administrador\ReservasAdminViews\DetallesReserva.cshtml"
    }


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "cf9b86b31d4e7b59e44272a955843351404f8c956869", async() => {
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

<section id=""about"" class=""about"">
    <section id=""contenidoBT"" style=""margin-top:80px"">
        <section id=""principalBT"">
            <CENTER>
                <div content=""width=device-widt"" class=""row"">
                    <div class=""col-sm-2""></div>
                    <div class=""col-sm-8"">

                        <div class=""box"" >
                            <h1>Detalles de la reservación</h1>
                            <br>


");
#nullable restore
#line 53 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\Administrador\ReservasAdminViews\DetallesReserva.cshtml"
                             if (ViewBag.ListaReservaciones != null)
                            {

                                ReservasAdminModel listaReservasHabitaciones = ViewBag.ListaReservaciones;


#line default
#line hidden
#nullable disable
            WriteLiteral("                                <h5 style=\"text-align: justify;\"> Fecha: ");
#nullable restore
#line 58 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\Administrador\ReservasAdminViews\DetallesReserva.cshtml"
                                                                    Write(listaReservasHabitaciones.TC_Fecha);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                <h5 style=\"text-align: justify;\"> ID Reserva: ");
#nullable restore
#line 59 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\Administrador\ReservasAdminViews\DetallesReserva.cshtml"
                                                                         Write(listaReservasHabitaciones.TN_Id_Reserva);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                <h5 style=\"text-align: justify;\"> ID Cliente: ");
#nullable restore
#line 60 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\Administrador\ReservasAdminViews\DetallesReserva.cshtml"
                                                                         Write(listaReservasHabitaciones.TC_Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 60 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\Administrador\ReservasAdminViews\DetallesReserva.cshtml"
                                                                                                              Write(listaReservasHabitaciones.TC_Apellidos);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                <h5 style=\"text-align: justify;\"> Email: ");
#nullable restore
#line 61 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\Administrador\ReservasAdminViews\DetallesReserva.cshtml"
                                                                    Write(listaReservasHabitaciones.TC_Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                <h5 style=\"text-align: justify;\"> Tarjeta: ");
#nullable restore
#line 62 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\Administrador\ReservasAdminViews\DetallesReserva.cshtml"
                                                                      Write(listaReservasHabitaciones.TC_Tarjeta);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                <h5 style=\"text-align: justify;\"> Transacción: ");
#nullable restore
#line 63 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\Administrador\ReservasAdminViews\DetallesReserva.cshtml"
                                                                          Write(listaReservasHabitaciones.TC_Transaccion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                <h5 style=\"text-align: justify;\"> Fecha llegada: ");
#nullable restore
#line 64 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\Administrador\ReservasAdminViews\DetallesReserva.cshtml"
                                                                            Write(listaReservasHabitaciones.TC_Fecha_Inicio);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                <h5 style=\"text-align: justify;\"> Fecha Salida: ");
#nullable restore
#line 65 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\Administrador\ReservasAdminViews\DetallesReserva.cshtml"
                                                                           Write(listaReservasHabitaciones.TC_Fecha_Final);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                <h5 style=\"text-align: justify;\"> Tipo habitación: ");
#nullable restore
#line 66 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\Administrador\ReservasAdminViews\DetallesReserva.cshtml"
                                                                              Write(listaReservasHabitaciones.TC_TipoHabitacion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n");
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cf9b86b31d4e7b59e44272a955843351404f8c9513582", async() => {
                WriteLiteral(@"
                                <input type=""hidden"" class=""form-control"" id=""idReunion"" name=""idReunion"" value=""temp2.TN_Id_Reunion"" />
                                <div class=""form-group"">

                                    <br>
                                    <div class=""form-group"">
                                        <button type=""submit"" class=""btn btn-outline-warning"">


                                            <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""currentColor"" class=""bi bi-printer-fill"" viewBox=""0 0 16 16"">
                                                <path d=""M5 1a2 2 0 0 0-2 2v1h10V3a2 2 0 0 0-2-2H5zm6 8H5a1 1 0 0 0-1 1v3a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1v-3a1 1 0 0 0-1-1z"" />
                                                <path d=""M0 7a2 2 0 0 1 2-2h12a2 2 0 0 1 2 2v3a2 2 0 0 1-2 2h-1v-2a2 2 0 0 0-2-2H5a2 2 0 0 0-2 2v2H2a2 2 0 0 1-2-2V7zm2.5 1a.5.5 0 1 0 0-1 .5.5 0 0 0 0 1z"" />
                                            </svg>
         ");
                WriteLiteral("                                   Descargar reporte\r\n                                        </button>\r\n\r\n                                        <input type=\"text\" name=\"TN_Id_Reserva\" id=\"TN_Id_Reserva\" class=\"dateselect1\"");
                BeginWriteAttribute("value", " value=\"", 4035, "\"", 4083, 1);
#nullable restore
#line 87 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\Administrador\ReservasAdminViews\DetallesReserva.cshtml"
WriteAttributeValue("", 4043, listaReservasHabitaciones.TN_Id_Reserva, 4043, 40, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" hidden />\r\n\r\n                                    </div>\r\n                                </div>\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 92 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\Administrador\ReservasAdminViews\DetallesReserva.cshtml"

                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                    </div>\r\n                    </div>\r\n            </CENTER>\r\n        </section>\r\n    </section>\r\n</section>\r\n");
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