#pragma checksum "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\VistaReservas\ReservaRealizadaView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fe46f825729d531728f265a0474a69f784cb66c6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_VistaReservas_ReservaRealizadaView), @"mvc.1.0.view", @"/Views/VistaReservas/ReservaRealizadaView.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe46f825729d531728f265a0474a69f784cb66c6", @"/Views/VistaReservas/ReservaRealizadaView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ecd6c48b401fdca329ed2a3e5e99f3678329fdf8", @"/Views/_ViewImports.cshtml")]
    public class Views_VistaReservas_ReservaRealizadaView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<InformacionClienteModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/scriptReserva.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Reservacion", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "InformacionClienteReservaView", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Bootstrap/assets/vendor/jquery/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Bootstrap/assets/vendor/bootstrap/js/bootstrap.bundle.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Bootstrap/assets/vendor/jquery.easing/jquery.easing.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Bootstrap/assets/vendor/php-email-form/validate.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Bootstrap/assets/vendor/owl.carousel/owl.carousel.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Bootstrap/assets/vendor/isotope-layout/isotope.pkgd.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Bootstrap/assets/vendor/venobox/venobox.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_13 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Bootstrap/assets/vendor/aos/aos.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_14 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Bootstrap/assets/js/main.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\VistaReservas\ReservaRealizadaView.cshtml"
  
    ViewData["Title"] = "BuscarDisponibilidad";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "fe46f825729d531728f265a0474a69f784cb66c69475", async() => {
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
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<script>\r\n\r\n\r\n    $(\'.dateselect1\').datepicker({\r\n        format: \'mm/dd/yyyy\'\r\n        // startDate: \'-3d\'\r\n    });\r\n\r\n</script>\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fe46f825729d531728f265a0474a69f784cb66c610787", async() => {
                WriteLiteral(@"


    <main id=""main"">
        <section id=""about"" class=""about"">
            <section id=""book-a-table"" class=""book-a-table"">
                <div class=""row"">

                    <div style=""margin-top:10px;"" class=""col-12 col-md-2 order-2 order-lg-1"" data-aos=""fade-up"">

                        <br>
                        <br>
                        <br>
                        <br>

                        <!-- ======= Inicio Publicidad Div ======= -->
                        <div class=""section-title"">
                            <h2>Publicidad</h2>
                        </div>

                        <div class=""owl-carousel events-carousel"" data-aos=""fade-up"" data-aos-delay=""100"">
                            <!--Se genera en base a la lista completa de publicidad registradas una serie de div que permitan ver todas las imagenes-->
");
#nullable restore
#line 41 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\VistaReservas\ReservaRealizadaView.cshtml"
                             if (ViewBag.ListaPublicidad != null)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\VistaReservas\ReservaRealizadaView.cshtml"
                                 foreach (PublicidadModel temp in ViewBag.ListaPublicidad)
                                {



#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <div class=\"row event-item\">\r\n                                        <div class=\"col-lg-10\">\r\n                                            <a");
                BeginWriteAttribute("href", " href=\"", 1598, "\"", 1628, 1);
#nullable restore
#line 49 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\VistaReservas\ReservaRealizadaView.cshtml"
WriteAttributeValue("", 1605, temp.TC_LinkPublicidad, 1605, 23, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" target=\"_blank\">\r\n                                                <img");
                BeginWriteAttribute("src", " src=\"", 1700, "\"", 1722, 1);
#nullable restore
#line 50 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\VistaReservas\ReservaRealizadaView.cshtml"
WriteAttributeValue("", 1706, temp.TC_URL_IMG, 1706, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"img-fluid\"");
                BeginWriteAttribute("alt", " alt=\"", 1741, "\"", 1747, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                                            </a>\r\n\r\n                                        </div>\r\n                                    </div>\r\n");
#nullable restore
#line 55 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\VistaReservas\ReservaRealizadaView.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\VistaReservas\ReservaRealizadaView.cshtml"
                                 
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                        </div>
                        <br>
                        <!-- ======= Inicio Oferta Div ======= -->
                        <div class=""section-title"">
                            <h2>Ofertas</h2>
                        </div>

                        <div class=""owl-carousel events-carousel"" data-aos=""fade-up"" data-aos-delay=""100"">
                            <!--Se genera en base a la lista completa de oferta registradas una serie de div que permitan ver todas las imagenes-->
");
#nullable restore
#line 66 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\VistaReservas\ReservaRealizadaView.cshtml"
                             if (ViewBag.ListaOferta != null)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 68 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\VistaReservas\ReservaRealizadaView.cshtml"
                                 foreach (OfertaModel temp in ViewBag.ListaOferta)
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <div class=\"row event-item\">\r\n                                        <div class=\"col-lg-10\">\r\n                                            <img");
                BeginWriteAttribute("src", " src=\"", 2873, "\"", 2895, 1);
#nullable restore
#line 72 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\VistaReservas\ReservaRealizadaView.cshtml"
WriteAttributeValue("", 2879, temp.TC_URL_IMG, 2879, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"img-fluid\"");
                BeginWriteAttribute("alt", " alt=\"", 2914, "\"", 2920, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                                        </div>\r\n                                    </div>\r\n");
#nullable restore
#line 75 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\VistaReservas\ReservaRealizadaView.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\VistaReservas\ReservaRealizadaView.cshtml"
                                 
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        </div>\r\n                    </div>\r\n\r\n\r\n\r\n                    <div class=\"container col-12 col-md-10 order-1 order-lg-2\" data-aos=\"fade-up\">\r\n\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fe46f825729d531728f265a0474a69f784cb66c617550", async() => {
                    WriteLiteral(@"

                            <div class=""content"">

                                <div class=""row"">
                                    <div class=""col-lg-2 col-md-4 col-sm-5 col-xs-12""></div>

                                    <div class=""col-lg-8 col-md-6 col-sm-7 col-xs-12"">
                                        <div class=""box"">
                                            <h3 class=""box-title"">Reservaci??n Realizada</h3>

");
#nullable restore
#line 95 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\VistaReservas\ReservaRealizadaView.cshtml"
                                             if (@Model.TN_ClienteNuevo == 1)
                                            {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                                <label class=\"font-italic\" style=\"color:white; text-align: justify\" for=\"question1\">Bienvenido ");
#nullable restore
#line 97 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\VistaReservas\ReservaRealizadaView.cshtml"
                                                                                                                                          Write(Model.TC_Nombre_Cliente);

#line default
#line hidden
#nullable disable
                    WriteLiteral("!</label>\r\n");
#nullable restore
#line 98 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\VistaReservas\ReservaRealizadaView.cshtml"
                                            }
                                            else
                                            {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                                <label class=\"font-italic\" style=\"color:white; text-align: justify\" for=\"question1\">Bienvenido de nuevo ");
#nullable restore
#line 101 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\VistaReservas\ReservaRealizadaView.cshtml"
                                                                                                                                                   Write(Model.TC_Nombre_Cliente);

#line default
#line hidden
#nullable disable
                    WriteLiteral("!</label>\r\n");
#nullable restore
#line 102 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\VistaReservas\ReservaRealizadaView.cshtml"
                                            }

#line default
#line hidden
#nullable disable
                    WriteLiteral(@"

                                            <br>


                                            <ul>
                                                <li style=""color:white""><i class=""icofont-check-circled""></i> Su reservaci??n en Legendary Hotel Elegance & Comfort fue realizada exitosamente</li>

                                            </ul>


                                            <label style=""color:white"" for=""question1"">N??mero de reservaci??n:  ");
#nullable restore
#line 114 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\VistaReservas\ReservaRealizadaView.cshtml"
                                                                                                          Write(Model.TC_Lista_Transaccion);

#line default
#line hidden
#nullable disable
                    WriteLiteral(" </label> <br>\r\n\r\n                                            <label style=\"color:white\" for=\"question1\">Acabamos de enviar esta informaci??n a la direcci??n ");
#nullable restore
#line 116 "C:\Users\XPC\source\repos\JassonRomero\GestorHotelJJCliente\GestorHotelJJCliente\Views\VistaReservas\ReservaRealizadaView.cshtml"
                                                                                                                                     Write(Model.TC_Email);

#line default
#line hidden
#nullable disable
                    WriteLiteral(@", para mayor facilidad</label> <br>


                                            <p class=""font-italic plan-text"" style=""color:white"">
                                                Gracias por preferirnos!
                                            </p>

                                        </div>


                                    </div>

                                    <div class=""col-lg-2 col-md-4 col-sm-5 col-xs-12""></div>

                                </div>

                            </div>
                        ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </section>\r\n        </section>\r\n\r\n\r\n    </main>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<!-- Vendor JS Files -->\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fe46f825729d531728f265a0474a69f784cb66c625145", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fe46f825729d531728f265a0474a69f784cb66c626185", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fe46f825729d531728f265a0474a69f784cb66c627225", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fe46f825729d531728f265a0474a69f784cb66c628265", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fe46f825729d531728f265a0474a69f784cb66c629305", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fe46f825729d531728f265a0474a69f784cb66c630346", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fe46f825729d531728f265a0474a69f784cb66c631387", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fe46f825729d531728f265a0474a69f784cb66c632428", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_13);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<!-- Template Main JS File -->\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fe46f825729d531728f265a0474a69f784cb66c633507", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_14);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<InformacionClienteModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
