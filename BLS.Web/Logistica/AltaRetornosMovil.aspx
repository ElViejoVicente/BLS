<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaRetornosMovil.aspx.cs" Inherits="GPB.Web.AltaRetornosMovil" %>

<%@ Register Src="~/Controles/Usuario/InfoMsgBoxMovil.ascx" TagPrefix="uc1" TagName="cuInfoMsgboxMovil" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v25.2, Version=25.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="user-scalable=0, width=device-width, initial-scale=1.0, maximum-scale=1.0" />
    <%--<link rel="stylesheet" href="Content/bootstrap.min.css" crossorigin="anonymous" />--%>
    <link rel="stylesheet" href="../SwitcherResources/Content/Simplex/bootstrap.min.css" crossorigin="anonymous" />
    <link rel="stylesheet" href="Content/all.css" crossorigin="anonymous" />
    <link rel="stylesheet" href="Content/generic/StylesMovil.css" crossorigin="anonymous" />
    <link rel="stylesheet" type="text/css" href="Content/ContentMovil.css" />

    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>

    <script>
        $(document).ready(function () {

        });

        function iconMaxMin() {
            var i = $('#iconCollapse');
            i.attr('class', i.hasClass('fas fa-angle-double-down') ? 'fas fa-angle-double-up' : i.attr('data-original'));
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
                Aqui va el contenido de cada pagina móvil no repetir las secciones.
            </div>
        </section>

        <footer class="CLPageFooter">
            © Derechos Reservados 2020-2021 CL Grupo Industrial Todos los Derechos Reservados.
        </footer>
    </form>

</body>
</html>
