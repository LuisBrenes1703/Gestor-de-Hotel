#pragma checksum "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\Administrador\ConsultarDisponibilidadHabitaciones\ConsultarDisponibilidadHabitaciones.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "888291522c4891e00a284846d137971eae384605"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Administrador_ConsultarDisponibilidadHabitaciones_ConsultarDisponibilidadHabitaciones), @"mvc.1.0.view", @"/Views/Administrador/ConsultarDisponibilidadHabitaciones/ConsultarDisponibilidadHabitaciones.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"888291522c4891e00a284846d137971eae384605", @"/Views/Administrador/ConsultarDisponibilidadHabitaciones/ConsultarDisponibilidadHabitaciones.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ecd6c48b401fdca329ed2a3e5e99f3678329fdf8", @"/Views/_ViewImports.cshtml")]
    public class Views_Administrador_ConsultarDisponibilidadHabitaciones_ConsultarDisponibilidadHabitaciones : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("SelectOption"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "HotelAdministrador", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ConsultarDisponbilidadHabitaciones", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\Administrador\ConsultarDisponibilidadHabitaciones\ConsultarDisponibilidadHabitaciones.cshtml"
  
    ViewData["Title"] = "ConsultarDisponibilidadHabitaciones";

    if (ViewBag.PermisoUsuario == "1")
    {
        Layout = "/Views/Administrador/Shared/_LayoutAdministrador.cshtml";

    }
    else if (ViewBag.PermisoUsuario == null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <script>\r\n            \r\n            redireccion(\'/Usuario/MuestraLoginUsuario\');\r\n\r\n            function redireccion(direccion) {\r\n                document.location.href = direccion;\r\n            }\r\n\r\n\r\n        </script>\r\n");
#nullable restore
#line 22 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\Administrador\ConsultarDisponibilidadHabitaciones\ConsultarDisponibilidadHabitaciones.cshtml"
    }
    else if (ViewBag.PermisoUsuario == "")
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <script>            \r\n            redireccion(\'/Usuario/MuestraLoginUsuario\');\r\n\r\n            function redireccion(direccion) {\r\n                document.location.href = direccion;\r\n            }\r\n\r\n\r\n        </script>\r\n");
#nullable restore
#line 34 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\Administrador\ConsultarDisponibilidadHabitaciones\ConsultarDisponibilidadHabitaciones.cshtml"
    }


#line default
#line hidden
#nullable disable
            WriteLiteral(@"


<section id=""about"" class=""about"">
    <section id=""contenidoBT"" style=""margin-top:80px"">
        <section id=""book-a-table"" class=""book-a-table"">
            <section id=""principalBT"">
                <CENTER>

                    <div class=""col-lg-8 pt-4 pt-lg-0  order-2 order-lg-2 content text-center php-email-form"">
");
            WriteLiteral("                        <h1>Consultar Disponibilidad de Habitaciones - Resultado</h1>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "888291522c4891e00a284846d137971eae3846057647", async() => {
                WriteLiteral(@"
                            <div class=""widget"" style=""padding-top: -30px;"">
                                <div class=""summary-block"">
                                    <div class=""row"">
                                        <div class=""col-lg-4  order-1 order-lg-1"">
                                            <div class=""summary-head"">
                                                <h5 style=""color:white"" class=""summary-title"">
                                                    Fecha Llegada
                                                </h5>
                                            </div>
                                            <label>
                                                <input type=""date"" name=""TC_FechaInicio"" id=""TC_FechaInicio"" class=""dateselect1"" required=""required"" />
                                            </label>
                                        </div>
                                        <div class=""col-lg-4  order-1 order-lg-1"">
          ");
                WriteLiteral(@"                                  <div class=""summary-head"">
                                                <h5 style=""color:white"" class=""summary-title"">
                                                    Fecha Salida
                                                </h5>
                                            </div>
                                            <label>
                                                <input type=""date"" name=""TC_FechaFin"" id=""TC_FechaFin"" class=""dateselect1"" required=""required"" />
                                            </label>
                                        </div>

                                        <div class=""col-lg-4  order-1 order-lg-1"">

");
#nullable restore
#line 76 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\Administrador\ConsultarDisponibilidadHabitaciones\ConsultarDisponibilidadHabitaciones.cshtml"
                                             if (ViewBag.ListaTipoHabitacion != null)
                                            {


#line default
#line hidden
#nullable disable
                WriteLiteral("                                                <select class=\"SelectOption\" name=\"TN_Id_TipoHabitacion\" id=\"TN_Id_TipoHabitacion\" style=\"margin-top: 28px; height: 48px;\"");
                BeginWriteAttribute("aria-label", " aria-label=\"", 3477, "\"", 3490, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "888291522c4891e00a284846d137971eae38460510560", async() => {
                    WriteLiteral("Tipo de habitaci??n");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 81 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\Administrador\ConsultarDisponibilidadHabitaciones\ConsultarDisponibilidadHabitaciones.cshtml"
                                                     foreach (TipoHabitacionModel temp in ViewBag.ListaTipoHabitacion)
                                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "888291522c4891e00a284846d137971eae38460512437", async() => {
#nullable restore
#line 83 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\Administrador\ConsultarDisponibilidadHabitaciones\ConsultarDisponibilidadHabitaciones.cshtml"
                                                                                                                   Write(temp.TC_TipoHabitacion);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 83 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\Administrador\ConsultarDisponibilidadHabitaciones\ConsultarDisponibilidadHabitaciones.cshtml"
                                                           WriteLiteral(temp.TN_Id_TipoHabitacion);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 84 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\Administrador\ConsultarDisponibilidadHabitaciones\ConsultarDisponibilidadHabitaciones.cshtml"

                                                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                </select>\r\n");
#nullable restore
#line 88 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\Administrador\ConsultarDisponibilidadHabitaciones\ConsultarDisponibilidadHabitaciones.cshtml"
                                            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                        </div>

                                    </div>
                                    <br>
                                    <br>


                                    <div class=""row"">

                                        <div class=""col-lg-7  order-1 order-lg-1"">
                                            <button class=""btn btn-warning btn-lg mb30"" type=""submit"" name=""TN_TipoOperacion"" id=""TN_TipoOperacion"" value=""0"">Consultar</button>
                                        </div>


                                        <div class=""col-lg-4  order-1 order-lg-1"">
                                            <button class=""btn btn-warning btn-lg mb30"" type=""submit"" name=""TN_TipoOperacion"" id=""TN_TipoOperacion"" value=""1"">
                                                <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""currentColor"" class=""bi bi-printer-fill"" viewBox=""0 0 16 16"">
                                             ");
                WriteLiteral(@"       <path d=""M5 1a2 2 0 0 0-2 2v1h10V3a2 2 0 0 0-2-2H5zm6 8H5a1 1 0 0 0-1 1v3a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1v-3a1 1 0 0 0-1-1z"" />
                                                    <path d=""M0 7a2 2 0 0 1 2-2h12a2 2 0 0 1 2 2v3a2 2 0 0 1-2 2h-1v-2a2 2 0 0 0-2-2H5a2 2 0 0 0-2 2v2H2a2 2 0 0 1-2-2V7zm2.5 1a.5.5 0 1 0 0-1 .5.5 0 0 0 0 1z"" />
                                                </svg> Imprimir</button>
                                        </div>


                                    </div>

");
#nullable restore
#line 115 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\Administrador\ConsultarDisponibilidadHabitaciones\ConsultarDisponibilidadHabitaciones.cshtml"
                                     if (ViewBag.fechas != null)
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        <div class=\"alert alert-warning mt-3\" id=\"al1\" role=\"alert\" style=\"display: block; text-align:center\">\r\n                                            ");
#nullable restore
#line 118 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\Administrador\ConsultarDisponibilidadHabitaciones\ConsultarDisponibilidadHabitaciones.cshtml"
                                       Write(Model);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                            <h6 style=\"color:black;\"> ");
#nullable restore
#line 119 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\Administrador\ConsultarDisponibilidadHabitaciones\ConsultarDisponibilidadHabitaciones.cshtml"
                                                                 Write(ViewBag.fechas);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h6>\r\n                                        </div>\r\n                                        <br>\r\n");
#nullable restore
#line 122 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\Administrador\ConsultarDisponibilidadHabitaciones\ConsultarDisponibilidadHabitaciones.cshtml"
                                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n\r\n\r\n                                </div>\r\n                            </div>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </div>

                    <br>
                    <br>



                    <div content=""width=device-widt"" class=""row"">
                        <div class=""col-sm-2""></div>
                        <div class=""col-sm-8"">
");
#nullable restore
#line 140 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\Administrador\ConsultarDisponibilidadHabitaciones\ConsultarDisponibilidadHabitaciones.cshtml"
                             if (ViewBag.ListaHabitacionesDisponibles != null)
                            {



#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <table id=""buscarT"" class=""table-estadoHabitacion responsive nowrap"" style=""width:100%"">
                                    <thead class=""thead-dark"">

                                        <tr>
                                            <th>N??mero de habitaci??n</th>
                                            <th>Tipo</th>
                                            <th>Estado</th>

                                        </tr>


                                    </thead>
                                    <tbody>


");
#nullable restore
#line 159 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\Administrador\ConsultarDisponibilidadHabitaciones\ConsultarDisponibilidadHabitaciones.cshtml"
                                         foreach (EstadoHotelModel temp in ViewBag.ListaHabitacionesDisponibles)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr>\r\n\r\n                                                <td>");
#nullable restore
#line 163 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\Administrador\ConsultarDisponibilidadHabitaciones\ConsultarDisponibilidadHabitaciones.cshtml"
                                               Write(temp.TN_Id_Habitacion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 164 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\Administrador\ConsultarDisponibilidadHabitaciones\ConsultarDisponibilidadHabitaciones.cshtml"
                                               Write(temp.TC_TipoHabitacion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 165 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\Administrador\ConsultarDisponibilidadHabitaciones\ConsultarDisponibilidadHabitaciones.cshtml"
                                               Write(temp.TC_Estado);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                                            </tr>\r\n");
#nullable restore
#line 168 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\Administrador\ConsultarDisponibilidadHabitaciones\ConsultarDisponibilidadHabitaciones.cshtml"


                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n                                    </tbody>\r\n                                </table>\r\n");
#nullable restore
#line 176 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\Administrador\ConsultarDisponibilidadHabitaciones\ConsultarDisponibilidadHabitaciones.cshtml"

                                

                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                        <div class=\"col-sm-2\"></div>\r\n                    </div>\r\n                </CENTER>\r\n            </section>\r\n        </section>\r\n    </section>\r\n</section>\r\n\r\n\r\n");
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
