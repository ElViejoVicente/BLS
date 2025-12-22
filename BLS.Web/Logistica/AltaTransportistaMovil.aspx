<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaTransportistaMovil.aspx.cs" Inherits="GPB.Web.Logistica.AltaTransportistaMovil" %>

<%@ Register Src="~/Controles/Usuario/InfoMsgBoxMovil.ascx" TagPrefix="uc1" TagName="cuInfoMsgboxMovil" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v25.2, Version=25.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

     <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="user-scalable=0, width=device-width, initial-scale=1.0, maximum-scale=1.0" />
    <%--<link rel="stylesheet" href="../Content/bootstrap.min.css" crossorigin="anonymous" />--%>
    <link rel="stylesheet" href="../SwitcherResources/Content/Simplex/bootstrap.min.css" crossorigin="anonymous" />
    <link rel="stylesheet" href="../Content/all.css" crossorigin="anonymous" />
    <link rel="stylesheet" href="../Content/generic/StylesMovil.css" crossorigin="anonymous" />
    <link rel="stylesheet" type="text/css" href="../Content/ContentMovil.css" />

    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script>
        $(document).ready(function () {

        });

        function iconMaxMin() {
            var i = $('#iconCollapse');
            i.attr('class', i.hasClass('fas fa-angle-double-down') ? 'fas fa-angle-double-up' : i.attr('data-original'));
        }
         function regresarExpedicion() {
            parent.document.getElementById('content').src = "Logistica/DetalleExpedicion.aspx?actualizatrans=1";
        }
        
    </script>

</head>
<body>
   
    <form id="frmPageMovil" runat="server" class="Principal">
      <uc1:cuInfoMsgboxMovil runat="server" ID="cuInfoMsgboxMovil" />
        
        <header class="CLPageHeader">
            <dx:ASPxImage runat="server" ID="imgLogo" CssClass="imagenLogo" ImageUrl="imagenes/menu/usuarioLarge.ico" ToolTip="Grupo Gallardo">
            </dx:ASPxImage>
            <dx:ASPxLabel ID="lblNombrePagina" CssClass="titleHeader" runat="server" Text="Página Inicial" Font-Bold="true"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblVersion" CssClass="titleHeader version" runat="server" Text="Versión: 1.0 Beta" Font-Bold="true"></dx:ASPxLabel>
        </header>
        
        <section class="CLPageContent">
            <div class="">
                <dx:BootstrapFormLayout ID="BootstrapFormLayout1" runat="server" LayoutType="Vertical" >

                     <Items >
                        <dx:BootstrapLayoutItem Caption="Nombre" ColSpanLg="4" ColSpanMd="6" >
                            <ContentCollection>
                                <dx:ContentControl>
                                
                                    <dx:BootstrapTextBox ID="Txt_nombre" runat="server" NullText="Nombre completo" Enabled="true" >
                                       <ValidationSettings>
                                                 <RequiredField IsRequired="true" ErrorText="Nombre es obligatorio" />
                                        </ValidationSettings>
                                        </dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                        <dx:BootstrapLayoutItem Caption="NIF/CIF" ColSpanLg="4" ColSpanMd="6">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                 
                                    <dx:BootstrapTextBox ID="Txt_nifcif" runat="server" NullText="Nif" Enabled="true">
                                         <ValidationSettings>
                                                 <RequiredField IsRequired="true" ErrorText="Nif/CIF es obligatorio" />
                                        </ValidationSettings>
                                         </dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                         <dx:BootstrapLayoutItem Caption="Dirección" ColSpanLg="4" ColSpanMd="6">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                 
                                    <dx:BootstrapTextBox ID="txt_Calle" runat="server" NullText="Dirección" Enabled="true" >
                                        <ValidationSettings>
                                                 <RequiredField IsRequired="true" ErrorText="Direccion es obligatorio" />
                                        </ValidationSettings>
                                         </dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                         <dx:BootstrapLayoutItem Caption="Cod. Postal" ColSpanLg="4" ColSpanMd="6">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                 
                                    <dx:BootstrapTextBox ID="txt_codpostal" runat="server" NullText="Código Postal" Enabled="true" >
                                        <ValidationSettings>
                                                 <RequiredField IsRequired="true" ErrorText="Codigo Postal es obligatorio" />
                                        </ValidationSettings>
                                         </dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                         <dx:BootstrapLayoutItem Caption="Población" ColSpanLg="4" ColSpanMd="6">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                 
                                    <dx:BootstrapTextBox ID="txt_poblacion" runat="server" NullText="Población" Enabled="true" >
                                         <ValidationSettings>
                                                 <RequiredField IsRequired="true" ErrorText="Población es obligatorio" />
                                        </ValidationSettings>
                                         </dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                         <dx:BootstrapLayoutItem Caption="Teléfono" ColSpanLg="4" ColSpanMd="6">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                 
                                    <dx:BootstrapTextBox ID="txt_telefono" runat="server" NullText="Teléfono" Enabled="true" >
                                         <ValidationSettings>
                                                 <RequiredField IsRequired="true" ErrorText="Teléfono es obligatorio" />
                                        </ValidationSettings>
                                         </dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                           <dx:BootstrapLayoutItem ShowCaption="False" HorizontalAlign="Right">
                            <ContentCollection>
                                <dx:ContentControl>
                                      <dx:BootstrapButton ID="btnCancel" Text="Cancelar" AutoPostBack="true" CausesValidation="false" runat="server" OnClick="btnCancel_Click">
                                        <SettingsBootstrap RenderOption="Secondary" />
                                    </dx:BootstrapButton>
                                    <dx:BootstrapButton ID="btnGuardar" Text="Guardar" AutoPostBack="true" CausesValidation="false" runat="server" OnClick="btnGuardar_Click">
                                        <SettingsBootstrap RenderOption="Primary" />
                                    </dx:BootstrapButton>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                         </Items>
                </dx:BootstrapFormLayout>
            </div>
        </section>

        <footer class="CLPageFooter">
            © Derechos Reservados 2020-2021 CL Grupo Industrial Todos los Derechos Reservados.
        </footer>
    </form>

</body>
</html>
