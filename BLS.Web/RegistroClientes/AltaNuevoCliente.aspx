<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaNuevoCliente.aspx.cs" Inherits="BLS.Web.RegistroClientes.AltaNuevoCliente" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v25.2, Version=25.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v25.2, Version=25.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <link rel="stylesheet" href="../SwitcherResources/Content/Yeti/bootstrap.min.css" />
    <script src="../Scripts/sweetalert2.all.min.js"></script>
    <link rel="stylesheet" href="../Scripts/sweetalert2.min.css" />
    <script src="../Scripts/mensajes.js"></script>

    <title></title>


    <script>

        function VerAlertasCondicional(s, e) {


            if (s.cp_swType != null) {


                if (s.cp_swClose != '') {

                }

                if (s.cp_Reload != '') {

                }

                mostrarMensajeSweet(s.cp_swType, s.cp_swMsg);
                s.cp_swType = null;
                s.cp_swMsg = null;

            }
        }

        function SoloLetras(s, e) {
            var key = e.htmlEvent.key;

            // Permitir letras y espacios
            var regex = /^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]$/;

            if (!regex.test(key)) {
                e.htmlEvent.preventDefault();
            }
        }

        function SoloNumeros(s, e) {
            var key = e.htmlEvent.key;

            // Permitir solo números
            if (!/^\d$/.test(key)) {
                e.htmlEvent.preventDefault();
            }
        }

        function seleccionarPaqueteVisual(idCard) {

            document.querySelectorAll('.card').forEach(function (card) {
                card.classList.remove('paquete-seleccionado');
                card.classList.add('paquete-no-seleccionado');
            });

            var seleccionada = document.getElementById(idCard);
            seleccionada.classList.remove('paquete-no-seleccionado');
            seleccionada.classList.add('paquete-seleccionado');
        }

        function validarPasswordVisual(s, e) {

            var password = s.GetText();

            validarRegla("rule-length", password.length >= 8);
            validarRegla("rule-upper", /[A-Z]/.test(password));
            validarRegla("rule-lower", /[a-z]/.test(password));
            validarRegla("rule-number", /\d/.test(password));
            validarRegla("rule-symbol", /[\W_]/.test(password));
        }

        function validarRegla(id, cumple) {
            var el = document.getElementById(id);

            if (cumple) {
                el.classList.remove("text-danger");
                el.classList.add("text-success");
                el.innerHTML = "✔ " + el.innerText.replace("❌", "").replace("✔", "").trim();
            } else {
                el.classList.remove("text-success");
                el.classList.add("text-danger");
                el.innerHTML = "❌ " + el.innerText.replace("❌", "").replace("✔", "").trim();
            }
        }



    </script>


    <style>
        .paquete-seleccionado {
            border: 3px solid #dc3545 !important;
            background-color: #fff5f5;
            box-shadow: 0 10px 25px rgba(220,53,69,0.35);
            transform: scale(1.05);
            transition: all 0.35s ease;
            position: relative;
        }

            .paquete-seleccionado::after {
                content: "✔ Paquete seleccionado";
                position: absolute;
                top: 10px;
                right: 10px;
                background: #dc3545;
                color: white;
                font-size: 0.8rem;
                padding: 4px 8px;
                border-radius: 6px;
                font-weight: 600;
            }

        .paquete-no-seleccionado {
            opacity: 0.6;
            transition: opacity 0.3s ease;
        }
    </style>



</head>
<body>
    <form id="form1" runat="server">

        <div id="headerFijo" style="position: fixed; top: 0; left: 0; width: 100%; background: white; z-index: 1000; padding-bottom: 10px;">


            <div class="position-absolute top-0 start-0 p-3" style="margin-left: 310px;">
                <asp:Image
                    ID="imgLogo"
                    runat="server"
                    ImageUrl="~/imagenes/header/logoTi.png"
                    Height="90px"
                    AlternateText="Logo" />
            </div>


            <div class="mb-4 text-center">
                <h2 class="text-primary fw-bolder"
                    style="letter-spacing: 0.8px; font-size: 2rem;">Crea tu cuenta
                </h2>

                <p class="text-muted fw-semibold"
                    style="max-width: 520px; margin: 0 auto;">
                    Completa el siguiente formulario para registrar tus datos y tener acceso al sistema.
                </p>
            </div>

        </div>


        <div style="margin-top: 110px;">


            <dx:ASPxCallbackPanel runat="server" ID="plnPrincipal" ClientInstanceName="plnPrincipal" OnCallback="plnPrincipal_Callback">
                <ClientSideEvents EndCallback="VerAlertasCondicional" />
                <PanelCollection>
                    <dx:PanelContent>



                        <dx:ASPxPanel ID="pnlRegistro" runat="server">
                            <PanelCollection>
                                <dx:PanelContent>
                                    <div style="width: 60%; margin: 0 auto;">
                                        <div>


                                            <dx:BootstrapFormLayout runat="server" ID="frmAltaCliente" AlignItemCaptionsInAllGroups="True">

                                                <Items>
                                                    <dx:BootstrapLayoutGroup Caption="Datos Personales o del Responsable" ColSpanMd="12">
                                                        <Items>
                                                            <dx:BootstrapLayoutItem Caption="Primer Nombre" ColSpanMd="12">
                                                                <ContentCollection>
                                                                    <dx:ContentControl>
                                                                        <dx:BootstrapTextBox runat="server" Width="100%" ID="txtPrimerNombre">
                                                                            <ClientSideEvents KeyPress="SoloLetras" />
                                                                            <ValidationSettings>
                                                                                <RequiredField IsRequired="true" ErrorText="El nombre es obligatorio" />
                                                                            </ValidationSettings>
                                                                        </dx:BootstrapTextBox>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>

                                                            <dx:BootstrapLayoutItem Caption="Segundo Nombre" ColSpanMd="12">
                                                                <ContentCollection>
                                                                    <dx:ContentControl>
                                                                        <dx:BootstrapTextBox runat="server" Width="100%" ID="txtSegundoNombre">
                                                                            <ClientSideEvents KeyPress="SoloLetras" />
                                                                            <ValidationSettings>
                                                                                <RequiredField IsRequired="true" ErrorText="El nombre es obligatorio" />
                                                                            </ValidationSettings>
                                                                        </dx:BootstrapTextBox>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>

                                                            <dx:BootstrapLayoutItem Caption="Apellido Paterno" ColSpanMd="12">
                                                                <ContentCollection>
                                                                    <dx:ContentControl>
                                                                        <dx:BootstrapTextBox runat="server" Width="100%" ID="txtAppPaterno">
                                                                            <ClientSideEvents KeyPress="SoloLetras" />
                                                                            <ValidationSettings>
                                                                                <RequiredField IsRequired="true" ErrorText="El apellido paterno es obligatorio" />
                                                                            </ValidationSettings>
                                                                        </dx:BootstrapTextBox>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>

                                                            <dx:BootstrapLayoutItem Caption="Apellido Materno" ColSpanMd="12">
                                                                <ContentCollection>
                                                                    <dx:ContentControl>
                                                                        <dx:BootstrapTextBox runat="server" Width="100%" ID="txtAppMaterno">
                                                                            <ClientSideEvents KeyPress="SoloLetras" />
                                                                            <ValidationSettings>
                                                                                <RequiredField IsRequired="true" ErrorText="El apellido materno es obligatorio" />
                                                                            </ValidationSettings>
                                                                        </dx:BootstrapTextBox>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>

                                                            <dx:BootstrapLayoutItem Caption="Fecha de nacimiento" ColSpanMd="6">
                                                                <ContentCollection>
                                                                    <dx:ContentControl>
                                                                        <dx:BootstrapDateEdit runat="server">
                                                                            <ValidationSettings>
                                                                                <RequiredField IsRequired="true" ErrorText="La fecha de nacimiento es obligatoria" />
                                                                            </ValidationSettings>
                                                                        </dx:BootstrapDateEdit>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>

                                                            <dx:BootstrapLayoutItem Caption="Despacho/consultor&#237;a" ColSpanMd="12">
                                                                <ContentCollection>
                                                                    <dx:ContentControl>
                                                                        <dx:BootstrapTextBox runat="server" ID="txtDespachoConsultoria">
                                                                            <ValidationSettings>
                                                                                <RequiredField IsRequired="true" ErrorText="Este campo es obligatorio" />
                                                                            </ValidationSettings>
                                                                        </dx:BootstrapTextBox>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>

                                                            <dx:BootstrapLayoutItem Caption="RFC" ColSpanMd="12">
                                                                <ContentCollection>
                                                                    <dx:ContentControl>
                                                                        <dx:BootstrapTextBox runat="server" MaxLength="13" ID="txtRFC">
                                                                            <ValidationSettings>
                                                                                <RequiredField IsRequired="true" ErrorText="El RFC es obligatorio" />
                                                                            </ValidationSettings>
                                                                        </dx:BootstrapTextBox>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>

                                                            <dx:BootstrapLayoutItem Caption="Domicilio" ColSpanMd="12">
                                                                <ContentCollection>
                                                                    <dx:ContentControl>
                                                                        <dx:BootstrapTextBox runat="server" ID="txtDomicilio">
                                                                            <ValidationSettings>
                                                                                <RequiredField IsRequired="true" ErrorText="El domicilio es obligatorio" />
                                                                            </ValidationSettings>
                                                                        </dx:BootstrapTextBox>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>

                                                            <dx:BootstrapLayoutItem Caption="N° Interior" ColSpanMd="6">
                                                                <ContentCollection>
                                                                    <dx:ContentControl>
                                                                        <dx:BootstrapTextBox runat="server" ID="txtNumeroInterior">
                                                                            <ValidationSettings>
                                                                                <RequiredField IsRequired="true" ErrorText="" />
                                                                            </ValidationSettings>
                                                                        </dx:BootstrapTextBox>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>
                                                            <dx:BootstrapLayoutItem Caption="N° Exterior" ColSpanMd="6">
                                                                <ContentCollection>
                                                                    <dx:ContentControl>
                                                                        <dx:BootstrapTextBox runat="server" ID="txtNumDomcilio">
                                                                            <ValidationSettings>
                                                                                <RequiredField IsRequired="false" ErrorText="" />
                                                                            </ValidationSettings>
                                                                        </dx:BootstrapTextBox>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>

                                                            <dx:BootstrapLayoutItem Caption="Ciudad" ColSpanMd="6">
                                                                <ContentCollection>
                                                                    <dx:ContentControl>
                                                                        <dx:BootstrapTextBox runat="server" ID="txtDomCiudad">
                                                                            <ValidationSettings>
                                                                                <RequiredField IsRequired="true" ErrorText="La ciudad es obligatoria" />
                                                                            </ValidationSettings>
                                                                        </dx:BootstrapTextBox>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>

                                                            <dx:BootstrapLayoutItem Caption="Estado" ColSpanMd="6">
                                                                <ContentCollection>
                                                                    <dx:ContentControl>
                                                                        <dx:BootstrapTextBox runat="server" ID="txtDomEstado">
                                                                            <ValidationSettings>
                                                                                <RequiredField IsRequired="true" ErrorText="El estado es obligatorio" />
                                                                            </ValidationSettings>
                                                                        </dx:BootstrapTextBox>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>

                                                            <dx:BootstrapLayoutItem Caption="Código Postal" ColSpanMd="6">
                                                                <ContentCollection>
                                                                    <dx:ContentControl>
                                                                        <dx:BootstrapTextBox runat="server" MaxLength="5" ID="txtDomCP">
                                                                            <ClientSideEvents KeyPress="SoloNumeros" />
                                                                            <ValidationSettings>
                                                                                <RequiredField IsRequired="true" ErrorText="El código postal es obligatorio" />
                                                                            </ValidationSettings>
                                                                        </dx:BootstrapTextBox>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>

                                                            <dx:BootstrapLayoutItem Caption="Teléfono de contacto" ColSpanMd="6">
                                                                <ContentCollection>
                                                                    <dx:ContentControl>
                                                                        <dx:BootstrapTextBox runat="server" MaxLength="15" ID="txtTelefono">
                                                                            <ValidationSettings>
                                                                                <RequiredField IsRequired="true" ErrorText="El teléfono es obligatorio" />
                                                                            </ValidationSettings>
                                                                        </dx:BootstrapTextBox>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>


                                                            <dx:BootstrapLayoutItem Caption="Terminos y condiciones">
                                                                <ContentCollection>
                                                                    <dx:ContentControl runat="server">
                                                                        <dx:BootstrapCheckBox runat="server" CheckState="Unchecked" ID="frmAltaCliente_E3"></dx:BootstrapCheckBox>


                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>
                                                        </Items>
                                                    </dx:BootstrapLayoutGroup>

                                                    <dx:BootstrapLayoutGroup Caption="Datos de Acceso">
                                                        <Items>
                                                            <dx:BootstrapLayoutItem Caption="email" ColSpanMd="9">
                                                                <ContentCollection>
                                                                    <dx:ContentControl>
                                                                        <dx:BootstrapTextBox runat="server" ID="txtCorreoCliente" />
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>

                                                            <dx:BootstrapLayoutItem Caption="Validar Correo" ShowCaption="False" ColSpanMd="3" FieldName="EnviarCodVerificiacionEmail">
                                                                <ContentCollection>
                                                                    <dx:ContentControl>
                                                                        <dx:BootstrapButton runat="server" AutoPostBack="false" SettingsBootstrap-RenderOption="Secondary" Text="Enviar Correo:" ID="btnEnviarCodVerificiacionEmail">
                                                                            <ClientSideEvents Click=" function(s, e) { plnPrincipal.PerformCallback('EnviarCodigoValidacionEmail') }" />
                                                                        </dx:BootstrapButton>

                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>

                                                            <dx:BootstrapLayoutItem Caption="Codigo de verificacion" ColSpanMd="9" FieldName="CodVerificacionEmail" ClientVisible="true">
                                                                <ContentCollection>
                                                                    <dx:ContentControl>
                                                                        <dx:BootstrapTextBox ID="txtCodVerificacionEmail" AutoPostBack="false" runat="server">
                                                                        </dx:BootstrapTextBox>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>

                                                            <dx:BootstrapLayoutItem ColSpanMd="3" ShowCaption="False" ClientVisible="true" FieldName="ValidarCodVerificiacionEmail">
                                                                <ContentCollection>
                                                                    <dx:ContentControl>
                                                                        <dx:BootstrapButton runat="server" AutoPostBack="false" SettingsBootstrap-RenderOption="Secondary" Text="Validar codigo:" ID="btnValidarCodigoNewCliente">
                                                                            <ClientSideEvents Click=" function(s, e) { plnPrincipal.PerformCallback('ValidarCodigoNewCliente') }" />
                                                                        </dx:BootstrapButton>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>

                                                            <dx:BootstrapLayoutItem Caption="Contrase&#241;a">
                                                                <ContentCollection>
                                                                    <dx:ContentControl runat="server">
                                                                        <div class="password-container">
                                                                            <dx:BootstrapTextBox runat="server" Password="True" ID="txtPassword" AutoPostBack="false">
                                                                                <ClientSideEvents KeyUp="validarPasswordVisual" />
                                                                            </dx:BootstrapTextBox>
                                                                            <div id="passwordRules" class="mt-2">
                                                                                <small id="rule-length" class="text-danger d-block">❌ Mínimo 8 caracteres</small>
                                                                                <small id="rule-upper" class="text-danger d-block">❌ Al menos una mayúscula</small>
                                                                                <small id="rule-lower" class="text-danger d-block">❌ Al menos una minúscula</small>
                                                                                <small id="rule-number" class="text-danger d-block">❌ Al menos un número</small>
                                                                                <small id="rule-symbol" class="text-danger d-block">❌ Al menos un símbolo</small>
                                                                                <asp:Label
                                                                                    ID="lblErrorPassword"
                                                                                    runat="server"
                                                                                    CssClass="text-danger fw-semibold d-block mt-2"
                                                                                    Visible="false">
                                                                                </asp:Label>
                                                                            </div>
                                                                        </div>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>

                                                            <dx:BootstrapLayoutItem Caption="Confirmar Contrase&#241;a (requerido)">
                                                                <ContentCollection>
                                                                    <dx:ContentControl runat="server">
                                                                        <dx:BootstrapTextBox runat="server" AutoPostBack="false" Password="True" ID="txtConfirPassword">
                                                                            <ClientSideEvents TextChanged="function(s, e) { plnPrincipal.PerformCallback(&#39;ValidadContrase&#241;a&#39;) }"></ClientSideEvents>
                                                                        </dx:BootstrapTextBox>





                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>
                                                        </Items>
                                                    </dx:BootstrapLayoutGroup>



                                                    <dx:BootstrapLayoutItem HorizontalAlign="Right" ShowCaption="False" ColSpanMd="12">
                                                        <ContentCollection>
                                                            <dx:ContentControl>
                                                                <dx:BootstrapButton ID="btnConfirmar" runat="server" Text="Confirmar" SettingsBootstrap-RenderOption="Primary" AutoPostBack="false">
                                                                    <ClientSideEvents Click="function(s, e) { plnPrincipal.PerformCallback('GuardarDatosIniciales')   }" />
                                                                </dx:BootstrapButton>



                                                            </dx:ContentControl>
                                                        </ContentCollection>
                                                    </dx:BootstrapLayoutItem>

                                                    <dx:BootstrapLayoutItem ShowCaption="False" ColSpanMd="12">
                                                        <ContentCollection>
                                                            <dx:ContentControl>
                                                                <asp:Label ID="lblErrorTerminos" runat="server" CssClass="text-danger fw-bold" Visible="false">
                                                                </asp:Label>
                                                            </dx:ContentControl>
                                                        </ContentCollection>
                                                    </dx:BootstrapLayoutItem>

                                                </Items>
                                            </dx:BootstrapFormLayout>
                                        </div>
                                    </div>
                                </dx:PanelContent>
                            </PanelCollection>



                        </dx:ASPxPanel>






                        <dx:ASPxPanel ID="pnlResumen" runat="server" ClientVisible="false">
                            <PanelCollection>
                                <dx:PanelContent>

                                    <div class="container mt-5 text-center">
                                        <h2 class="fw-bold text-danger">Resumen de tu compra</h2>

                                        <p class="mt-4 fs-5">
                                            Elegiste el plan
            <strong>
                <asp:Label ID="lblPlan" runat="server"></asp:Label>
            </strong>
                                            por
            <strong>$<asp:Label ID="lblPrecio" runat="server"></asp:Label>
            </strong>
                                        </p>

                                        <dx:BootstrapButton
                                            runat="server"
                                            Text="Continuar al pago"
                                            SettingsBootstrap-RenderOption="Primary" />

                                        <br />
                                        <br />

                                        <dx:BootstrapButton runat="server" Text="Regresar a paquetes" SettingsBootstrap-RenderOption="Link" AutoPostBack="true" OnClick="Unnamed_Click1" />

                                    </div>

                                </dx:PanelContent>
                            </PanelCollection>
                        </dx:ASPxPanel>




                    </dx:PanelContent>
                </PanelCollection>
            </dx:ASPxCallbackPanel>

        </div>

    </form>
</body>
</html>
