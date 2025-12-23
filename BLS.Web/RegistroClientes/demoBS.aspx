<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="demoBS.aspx.cs" Inherits="BLS.Web.RegistroClientes.demoBS" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v25.2, Version=25.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <link rel="stylesheet" href="../SwitcherResources/Content/Yeti/bootstrap.min.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div class="mb-4 text-center">
            <h2 class="fw-bold text-danger">Crea tu cuenta</h2>
            <p class="text-danger">
                Completa el siguiente formulario para registrar tus datos y tener acceso al sistema.
            </p>
        </div>


        <asp:Panel ID="pnlResgistro" runat="server">


            <div style="width:70%; margin:0 auto;">
                <div>
                    

            <dx:BootstrapFormLayout runat="server" ID="frmAltaCliente" AlignItemCaptionsInAllGroups="True" >

                <Items>
                    <dx:BootstrapLayoutGroup Caption="Datos Personales">
                        <Items>
                            <dx:BootstrapLayoutItem Caption="Nombre" HelpText="Introduce tu primer nombre" ColSpanLg="4" ColSpanMd="12">
                                <ContentCollection>
                                    <dx:ContentControl>
                                        <dx:BootstrapTextBox runat="server">
                                            <ValidationSettings>
                                                <RequiredField IsRequired="true" ErrorText="First Name is required" />
                                            </ValidationSettings>
                                        </dx:BootstrapTextBox>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:BootstrapLayoutItem>

                            <dx:BootstrapLayoutItem Caption="Segundo nombre: (opcional)" HelpText="Introduce tu segundo nombre en caso de tener" ColSpanLg="4" ColSpanMd="12">
                                <ContentCollection>
                                    <dx:ContentControl>
                                        <dx:BootstrapTextBox runat="server" />
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:BootstrapLayoutItem>

                            <dx:BootstrapLayoutItem Caption="Apellidos" HelpText="Introduce tus apellidos" ColSpanLg="4" ColSpanMd="12">
                                <ContentCollection>
                                    <dx:ContentControl>
                                        <dx:BootstrapTextBox runat="server">
                                            <ValidationSettings>
                                                <RequiredField IsRequired="true" ErrorText="Last Name is required" />
                                            </ValidationSettings>
                                        </dx:BootstrapTextBox>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:BootstrapLayoutItem>

                            <dx:BootstrapLayoutItem Caption="Fecha de Nacimiento" HelpText="Ingresa tu fecha de nacimiento">
                                <ContentCollection>
                                    <dx:ContentControl>
                                        <dx:BootstrapDateEdit runat="server" ID="frmAltaCliente_E2"></dx:BootstrapDateEdit>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:BootstrapLayoutItem>

                            <dx:BootstrapLayoutItem Caption="Sexo" BeginRow="true">
                                <ContentCollection>
                                    <dx:ContentControl>
                                        <div class="form-control-plaintext">
                                            <dx:BootstrapRadioButton runat="server" Text="Hombre" GroupName="AddressTypeGroup">
                                                <SettingsBootstrap InlineMode="true" />
                                            </dx:BootstrapRadioButton>
                                            <dx:BootstrapRadioButton runat="server" Text="Mujer" GroupName="AddressTypeGroup" Checked="true">
                                                <SettingsBootstrap InlineMode="true" />
                                            </dx:BootstrapRadioButton>
                                        </div>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:BootstrapLayoutItem>

                            <dx:BootstrapLayoutItem BeginRow="True" Caption="Tengo mas de 18 a&#241;os">
                                <ContentCollection>
                                    <dx:ContentControl runat="server">
                                        <div class="form-control-plaintext">
                                            <dx:BootstrapRadioButton runat="server" GroupName="AddressTypeGroup" Text="Si">
                                                <SettingsBootstrap InlineMode="True"></SettingsBootstrap>
                                            </dx:BootstrapRadioButton>

                                            <dx:BootstrapRadioButton runat="server" GroupName="AddressTypeGroup" Checked="True" Text="No">
                                                <SettingsBootstrap InlineMode="True"></SettingsBootstrap>
                                            </dx:BootstrapRadioButton>

                                        </div>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:BootstrapLayoutItem>

                        </Items>
                    </dx:BootstrapLayoutGroup>

                    <dx:BootstrapLayoutGroup Caption="Datos de Acceso">
                        <Items>
                            <dx:BootstrapLayoutItem Caption="email" ColSpanMd="12" HelpText="Ingresa tu correco electronico">
                                <ContentCollection>
                                    <dx:ContentControl>
                                        <dx:BootstrapTextBox runat="server" Text="correco electronico" />
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:BootstrapLayoutItem>

                            <dx:BootstrapLayoutItem Caption="Contrase&#241;a" HelpText="Ingresa tu contrase&#241;a">
                                <ContentCollection>
                                    <dx:ContentControl>
                                        <dx:BootstrapTextBox ID="txtPassword" runat="server" Password="true" />
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:BootstrapLayoutItem>

                            <dx:BootstrapLayoutItem Caption="Confirmar Contrase&#241;a (requerido)" HelpText="Por favor confirma tu contrase&#241;a">
                                <ContentCollection>
                                    <dx:ContentControl>
                                        <dx:BootstrapTextBox ID="txtConfirPassword" runat="server" Password="true" />
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:BootstrapLayoutItem>

                            <dx:BootstrapLayoutItem Caption="Terminos y condiciones" HelpText="Declaro que le&#237; y consult&#233; los T&#233;rminos y condiciones, y acepto expresamente su contenido.">
                                <ContentCollection>
                                    <dx:ContentControl>
                                        <dx:BootstrapCheckBox runat="server" CheckState="Unchecked" ID="frmAltaCliente_E3"></dx:BootstrapCheckBox>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:BootstrapLayoutItem>

                            <dx:BootstrapLayoutItem Caption="Politica de privacidad" HelpText="Autorizo a BLS a procesar mis datos personales para la prestaci&#243;n de sus servicios y otros prop&#243;sitos indicados en su Pol&#237;tica de privacidad.">
                                <ContentCollection>
                                    <dx:ContentControl runat="server">
                                        <dx:BootstrapCheckBox runat="server" CheckState="Unchecked" ID="frmAltaCliente_E4"></dx:BootstrapCheckBox>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:BootstrapLayoutItem>

                        </Items>
                    </dx:BootstrapLayoutGroup>



                    <dx:BootstrapLayoutItem HorizontalAlign="Right" ShowCaption="False" ColSpanMd="12">
                        <ContentCollection>
                            <dx:ContentControl>
                                <dx:BootstrapButton ID="btnConfirmar" runat="server" Text="Confirmar" SettingsBootstrap-RenderOption="Primary" AutoPostBack="true" OnClick="btnConfirmar_Click" />
                                <dx:BootstrapButton runat="server" Text="Cancelar" SettingsBootstrap-RenderOption="Link" AutoPostBack="true">
                                    <ClientSideEvents Click="function(s, e) { document.location.reload();}" />
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


        </asp:Panel>



        <asp:Panel ID="pnlPaquetes" runat="server" Visible="false">

            <div class="container mt-5">
                <h2 class="text-center text-danger fw-bold">Elige tu paquete</h2>
                <p class="text-center text-muted">Selecciona el plan que mejor se adapte a ti</p>

                <div class="row mt-4">

                    <!-- Paquete Gratis -->
                    <div class="col-md-3">
                        <div class="card shadow">
                            <div class="card-body text-center">
                                <h5 class="card-title">Pruebas Gratis</h5>
                                <p class="card-text">$0</p>
                                <p>4 pruebas incluidas</p>
                                <dx:BootstrapButton ID="btnGratis" runat="server" Text="Seleccionar" SettingsBootstrap-RenderOption="Secondary" AutoPostBack="true" OnClick="btnGratis_Click" />
                            </div>
                        </div>
                    </div>

                    <!-- Paquete 20 Créditos -->
                    <div class="col-md-3">
                        <div class="card shadow">
                            <div class="card-body text-center">
                                <h5 class="card-title">20 Créditos</h5>
                                <p class="card-text">$100</p>
                                <p>Ideal para comenzar</p>
                                <dx:BootstrapButton ID="btn20" runat="server" Text="Seleccionar" SettingsBootstrap-RenderOption="Secondary" AutoPostBack="true" OnClick="btn20_Click" />
                            </div>
                        </div>
                    </div>

                    <!-- Paquete 50 Créditos -->
                    <div class="col-md-3">
                        <div class="card shadow border-danger">
                            <div class="card-body text-center">
                                <h5 class="card-title text-danger">50 Créditos</h5>
                                <p class="card-text">$200</p>
                                <p>Mejor relación costo</p>
                                <dx:BootstrapButton ID="btn50" runat="server" Text="Seleccionar" SettingsBootstrap-RenderOption="Primary" AutoPostBack="true" OnClick="btn50_Click" />
                            </div>
                        </div>
                    </div>

                    <!-- Paquete 100 Créditos -->
                    <div class="col-md-3">
                        <div class="card shadow">
                            <div class="card-body text-center">
                                <h5 class="card-title">100 Créditos</h5>
                                <p class="card-text">$400</p>
                                <p>Para uso intensivo</p>
                                <dx:BootstrapButton ID="btn100" runat="server" Text="Seleccionar" SettingsBootstrap-RenderOption="Secondary" AutoPostBack="true" OnClick="btn100_Click" />
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="pnlResumen" runat="server" Visible="false">

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

        </asp:Panel>




    </form>
</body>
</html>
