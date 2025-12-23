<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="demoBS.aspx.cs" Inherits="BLS.Web.RegistroClientes.demoBS" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v25.2, Version=25.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <link rel="stylesheet" href="../SwitcherResources/Content/Cyborg/bootstrap.min.css" />
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


        <div>

            <dx:BootstrapFormLayout runat="server" ID="frmAltaCliente" AlignItemCaptionsInAllGroups="True">

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
                                        <dx:BootstrapTextBox runat="server" Text="********" />
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:BootstrapLayoutItem>
                            <dx:BootstrapLayoutItem Caption="Confirmar Contrase&#241;a (requerido)" HelpText="Por favor confirma tu contrase&#241;a">
                                <ContentCollection>
                                    <dx:ContentControl>
                                        <dx:BootstrapTextBox runat="server" Text="********" MaxLength="10" />
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
                                <dx:BootstrapButton runat="server" Text="Confirmar" SettingsBootstrap-RenderOption="Primary" AutoPostBack="true" />
                                <dx:BootstrapButton runat="server" Text="Cancel" SettingsBootstrap-RenderOption="Link" AutoPostBack="false">
                                    <ClientSideEvents Click="function(s, e) { document.location.reload(); }" />
                                </dx:BootstrapButton>
                            </dx:ContentControl>
                        </ContentCollection>
                    </dx:BootstrapLayoutItem>
                </Items>
            </dx:BootstrapFormLayout>




        </div>
    </form>
</body>
</html>
