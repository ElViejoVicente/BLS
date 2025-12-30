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

                // Si hay redirect, usa el swal con contador y redirige al finalizar
                if (s.cp_RedirectUrl) {
                    var url = s.cp_RedirectUrl;

                    // limpia para evitar que se dispare otra vez
                    s.cp_RedirectUrl = null;

                    // muestra mensaje con cuenta regresiva de 10 segundos
                    mostrarMensajeSweetCount(
                        s.cp_swType,
                        s.cp_swMsg,
                        10,
                        function () { window.location.href = url; },
                        { confirmButtonText: "Ir al login" }
                    );

                } else {
                    // si no hay redirect, usa tu swal normal
                    mostrarMensajeSweet(s.cp_swType, s.cp_swMsg);
                }

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



        function validarPasswordVisual(s, e) {

            var password = s.GetText();

            validarRegla("length", password.length >= 8);
            validarRegla("upper", /[A-Z]/.test(password));
            validarRegla("lower", /[a-z]/.test(password));
            validarRegla("number", /\d/.test(password));
            validarRegla("symbol", /[\W_]/.test(password));
        }

        // ---------------------------
        // Validación completa (reglas + coincidencia) + feedback visual
        // y seteo de Session["ssContraseñaValida"] vía callback
        // ---------------------------
        var _ultimoEstadoPwdOk = null;

        function passwordCumpleReglas(pwd) {
            if (!pwd) return false;
            if (pwd.length < 8) return false;
            if (!/[A-Z]/.test(pwd)) return false;
            if (!/[a-z]/.test(pwd)) return false;
            if (!/\d/.test(pwd)) return false;
            if (!/[\W_]/.test(pwd)) return false;
            if (/\s/.test(pwd)) return false; // sin espacios
            return true;
        }

        function setEstadoVisualPassword(ok, msg) {
            var el = document.getElementById("passwordMatch");
            if (!el) return;

            if (ok) {
                el.classList.remove("text-danger");
                el.classList.add("text-success");
                el.innerHTML = "✔ " + (msg || "Contraseña válida");
            } else {
                el.classList.remove("text-success");
                el.classList.add("text-danger");
                el.innerHTML = "❌ " + (msg || "Revisa la contraseña");
            }
        }

        function setSessionPasswordOk(ok) {
            // Evitar callbacks repetidos
            if (_ultimoEstadoPwdOk === ok) return;
            _ultimoEstadoPwdOk = ok;

            // Guardar también en hidden field por si lo quieres leer en servidor
            if (typeof hfPasswordOk !== "undefined" && hfPasswordOk) {
                hfPasswordOk.Set("ok", ok ? "1" : "0");
            }

            // Setear Session en servidor
            if (typeof cbPwdSession !== "undefined" && cbPwdSession) {
                cbPwdSession.PerformCallback(ok ? "1" : "0");
            }
        }

        function validarPasswordYConfirmacion() {
            // Nota: Requiere ClientInstanceName="txtPassword" y "txtConfirPassword"
            var pwd = (typeof txtPassword !== "undefined" && txtPassword) ? txtPassword.GetText() : "";
            var conf = (typeof txtConfirPassword !== "undefined" && txtConfirPassword) ? txtConfirPassword.GetText() : "";

            var reglasOk = passwordCumpleReglas(pwd);
            var coinciden = pwd.length > 0 && (pwd === conf);

            if (!reglasOk) {
                setEstadoVisualPassword(false, "La contraseña no cumple los requisitos");
                setSessionPasswordOk(false);
                return false;
            }

            if (!coinciden) {
                setEstadoVisualPassword(false, "Las contraseñas no coinciden");
                setSessionPasswordOk(false);
                return false;
            }

            setEstadoVisualPassword(true, "Contraseña OK y coincide");
            setSessionPasswordOk(true);
            return true;
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
                                                                            <ValidationSettings ValidationGroup="TodosLosCampos">
                                                                                <RequiredField IsRequired="true" ErrorText="El nombre es obligatorio" />
                                                                            </ValidationSettings>
                                                                        </dx:BootstrapTextBox>

                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>

                                                            <dx:BootstrapLayoutItem Caption="Segundo Nombre" ColSpanMd="12">
                                                                <ContentCollection>
                                                                    <dx:ContentControl>
                                                                        <dx:BootstrapTextBox runat="server" Width="100%" ID="txtSegundoNombre" NullText="">
                                                                            <ClientSideEvents KeyPress="SoloLetras" />
                                                                        </dx:BootstrapTextBox>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>

                                                            <dx:BootstrapLayoutItem Caption="Apellido Paterno" ColSpanMd="12">
                                                                <ContentCollection>
                                                                    <dx:ContentControl>
                                                                        <dx:BootstrapTextBox runat="server" Width="100%" ID="txtAppPaterno">
                                                                            <ClientSideEvents KeyPress="SoloLetras" />
                                                                            <ValidationSettings ValidationGroup="TodosLosCampos">
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
                                                                            <ValidationSettings ValidationGroup="TodosLosCampos">
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
                                                                            <ValidationSettings ValidationGroup="TodosLosCampos">
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
                                                                            <ValidationSettings ValidationGroup="TodosLosCampos">
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
                                                                            <ValidationSettings ValidationGroup="TodosLosCampos">
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
                                                                            <ValidationSettings ValidationGroup="TodosLosCampos">
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
                                                                            <ValidationSettings ValidationGroup="TodosLosCampos">
                                                                                <RequiredField IsRequired="true" ErrorText="El campo es oligatorio." />
                                                                            </ValidationSettings>
                                                                        </dx:BootstrapTextBox>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>

                                                            <dx:BootstrapLayoutItem Caption="N° Exterior" ColSpanMd="6">
                                                                <ContentCollection>
                                                                    <dx:ContentControl>
                                                                        <dx:BootstrapTextBox runat="server" ID="txtNumeroExterior" NullText="NA">
                                                                            <ValidationSettings ValidationGroup="TodosLosCampos">
                                                                                <RequiredField IsRequired="false" ErrorText="" />
                                                                            </ValidationSettings>
                                                                        </dx:BootstrapTextBox>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>

                                                            <dx:BootstrapLayoutItem Caption="Estado" ColSpanMd="6">
                                                                <ContentCollection>
                                                                    <dx:ContentControl>
                                                                        <dx:BootstrapComboBox runat="server" ID="cmbEstado" ClientInstanceName="cmbEstado" OnDataBinding="cmbEstado_DataBinding">   
                                                                            <ClientSideEvents SelectedIndexChanged=" function(s, e) { cmbCiudad.PerformCallback( cmbEstado.GetValue() ); } " />
                                                                            <ValidationSettings ValidationGroup="TodosLosCampos">
                                                                                <RequiredField IsRequired="true" ErrorText="El Estado es obligatorio" />
                                                                            </ValidationSettings>
                                                                        </dx:BootstrapComboBox>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>

                                                            <dx:BootstrapLayoutItem Caption="Ciudad/Asentamiento" ColSpanMd="6">
                                                                <ContentCollection>
                                                                    <dx:ContentControl>
                                                                        <dx:BootstrapComboBox runat="server" ID="cmbCiudad" ClientInstanceName="cmbCiudad" OnCallback="cmbCiudad_Callback">    
                                                                           <ClientSideEvents SelectedIndexChanged="function(s, e) { cmbCodigoPostal.PerformCallback( cmbCiudad.GetText() ); }" />
                                                                            <ValidationSettings ValidationGroup="TodosLosCampos">
                                                                                <RequiredField IsRequired="true" ErrorText="La ciudad o asentamiento es obligatoria" />
                                                                            </ValidationSettings>
                                                                        </dx:BootstrapComboBox>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>

                                                            <dx:BootstrapLayoutItem Caption="Codigo Postal" ColSpanMd="6">
                                                                <ContentCollection>
                                                                    <dx:ContentControl>
                                                                        <dx:BootstrapComboBox runat="server" ID="cmbCodigoPostal"  ClientInstanceName="cmbCodigoPostal" OnCallback="cmbCodigoPostal_Callback1">
                                                                      
                                                                            <ValidationSettings ValidationGroup="TodosLosCampos">
                                                                                <RequiredField IsRequired="true" ErrorText="El Codigo Postal es obligatorio" />
                                                                            </ValidationSettings>
                                                                        </dx:BootstrapComboBox>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>


                                                            <dx:BootstrapLayoutItem Caption="Teléfono de contacto" ColSpanMd="6">
                                                                <ContentCollection>
                                                                    <dx:ContentControl>
                                                                        <dx:BootstrapTextBox runat="server" MaxLength="15" ID="txtTelefono">
                                                                            <ValidationSettings ValidationGroup="TodosLosCampos">
                                                                                <RequiredField IsRequired="true" ErrorText="El teléfono es obligatorio" />
                                                                            </ValidationSettings>
                                                                        </dx:BootstrapTextBox>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>


                                                            <dx:BootstrapLayoutItem Caption="Terminos y condiciones">
                                                                <ContentCollection>
                                                                    <dx:ContentControl runat="server">
                                                                        <dx:BootstrapCheckBox runat="server" CheckState="Unchecked" ID="frmAltaCliente_E3">
                                                                            <ValidationSettings ValidationGroup="TodosLosCampos" ErrorText="Debe aceptar los terminos y condiciones"></ValidationSettings>
                                                                        </dx:BootstrapCheckBox>


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
                                                                        <dx:BootstrapTextBox runat="server" ID="txtCorreoCliente">
                                                                            <ValidationSettings ValidationGroup="TodosLosCampos" ErrorText="Campos oblogatorio">
                                                                                <RequiredField IsRequired="true" />
                                                                            </ValidationSettings>
                                                                        </dx:BootstrapTextBox>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>

                                                            <dx:BootstrapLayoutItem ShowCaption="False" ColSpanMd="3" FieldName="EnviarCodVerificiacionEmail">
                                                                <ContentCollection>
                                                                    <dx:ContentControl>
                                                                        <dx:BootstrapButton runat="server" AutoPostBack="false" SettingsBootstrap-RenderOption="Secondary" Text="Enviar Codigo:" ID="btnEnviarCodVerificiacionEmail">
                                                                            <ClientSideEvents Click=" function(s, e) { plnPrincipal.PerformCallback('EnviarCodigoValidacionEmail') }" />
                                                                        </dx:BootstrapButton>

                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>

                                                            <dx:BootstrapLayoutItem Caption="Codigo de verificacion" ColSpanMd="9" FieldName="CodVerificacionEmail" ClientVisible="true">
                                                                <ContentCollection>
                                                                    <dx:ContentControl>
                                                                        <dx:BootstrapTextBox ID="txtCodVerificacionEmail" AutoPostBack="false" runat="server">
                                                                            <ValidationSettings ValidationGroup="TodosLosCampos" ErrorText="el campo es oblogatorio , este te llegara por correo">
                                                                                <RequiredField IsRequired="true" />
                                                                            </ValidationSettings>
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
                                                                            <dx:BootstrapTextBox runat="server" Password="True" ID="txtPassword" ClientInstanceName="txtPassword" AutoPostBack="false">
                                                                                <ValidationSettings ValidationGroup="TodosLosCampos" ErrorText="Campo obligatorio">
                                                                                    <RequiredField IsRequired="true" />
                                                                                </ValidationSettings>
                                                                                <ClientSideEvents KeyUp="function(s,e){ validarPasswordVisual(s,e); validarPasswordYConfirmacion(); }" />
                                                                            </dx:BootstrapTextBox>
                                                                            <div id="passwordRules" class="mt-2">
                                                                                <small id="length" class="text-danger d-block">❌ Mínimo 8 caracteres</small>
                                                                                <small id="upper" class="text-danger d-block">❌ Al menos una mayúscula</small>
                                                                                <small id="lower" class="text-danger d-block">❌ Al menos una minúscula</small>
                                                                                <small id="number" class="text-danger d-block">❌ Al menos un número</small>
                                                                                <small id="symbol" class="text-danger d-block">❌ Al menos un símbolo</small>
                                                                            </div>
                                                                        </div>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>

                                                            <dx:BootstrapLayoutItem Caption="Confirmar Contrase&#241;a">
                                                                <ContentCollection>
                                                                    <dx:ContentControl runat="server">
                                                                        <div class="password-container">
                                                                            <dx:BootstrapTextBox runat="server" AutoPostBack="false" Password="True" ID="txtConfirPassword" ClientInstanceName="txtConfirPassword">
                                                                                <ValidationSettings ValidationGroup="TodosLosCampos" ErrorText="Campo obligatorio">
                                                                                    <RequiredField IsRequired="true" />
                                                                                </ValidationSettings>
                                                                                <ClientSideEvents KeyUp="validarPasswordYConfirmacion" />
                                                                            </dx:BootstrapTextBox>
                                                                            <div id="passwordRules2" class="mt-2">
                                                                                <small id="passwordMatch" class="text-danger d-block mt-2">❌ Las contraseñas no coinciden</small>
                                                                            </div>
                                                                        </div>
                                                                    </dx:ContentControl>
                                                                </ContentCollection>
                                                            </dx:BootstrapLayoutItem>
                                                        </Items>
                                                    </dx:BootstrapLayoutGroup>



                                                    <dx:BootstrapLayoutItem HorizontalAlign="Right" ShowCaption="False" ColSpanMd="12">
                                                        <ContentCollection>
                                                            <dx:ContentControl>
                                                                <dx:BootstrapButton ID="btnConfirmar" runat="server" Text="Confirmar" SettingsBootstrap-RenderOption="Primary" AutoPostBack="false">
                                                                    <ClientSideEvents Click="function(s, e) { 
                                                                             if (ASPxClientEdit.ValidateGroup('TodosLosCampos'))
                                                                            {
                                                                                 plnPrincipal.PerformCallback('GuardarDatosIniciales'); 
                                                                            }                                                                         
                                                                                                            }" />
                                                                </dx:BootstrapButton>



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











                    </dx:PanelContent>
                </PanelCollection>
            </dx:ASPxCallbackPanel>

        </div>


        <!-- Validación de contraseña (cliente -> servidor) -->
        <dx:ASPxHiddenField ID="hfPasswordOk" runat="server" ClientInstanceName="hfPasswordOk" />
        <dx:ASPxCallback ID="cbPwdSession" runat="server" ClientInstanceName="cbPwdSession" OnCallback="cbPwdSession_Callback" />

    </form>
</body>
</html>
