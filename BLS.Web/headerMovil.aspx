<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="headerMovil.aspx.cs" Inherits=" BLS.Web.headerMovil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="user-scalable=0, width=device-width, initial-scale=1.0, maximum-scale=1.0" />
    <link rel="stylesheet" href="Content/bootstrap.min.css" crossorigin="anonymous" />
    <link rel="stylesheet" href="Content/all.css" crossorigin="anonymous" />
    <link rel="stylesheet" type="text/css" href="Content/headerMovil.css" />

    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
      <script src="Scripts/sweetalert.min.js"></script>
    <script src="Scripts/mensajes.js"></script>
</head>
<body>
    <form id="frmCabecero" runat="server" class="frmclass">
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
        <header>
            <div class="wrapper">
                <%--<div class="columnHeader" style="width: 10%; display: flex;">
                    <div style="width: 100%; height: 100%;">
                        <img class="imagenGG" src="imagenes/header/logo_gallardo_big.jpg" alt="Grupo Gallardo" />
                    </div>
                </div>--%>
                <div class="columnHeader" style="width: 15%; display: flex;">
                    <div style="width: 100%; height: 100%;text-align:center">
                        <img class="imagenCL" src="imagenes/logo-cl.png" alt="CL Grupo Industrial" />
                    </div>
                </div>

                <div class="columnHeader" style="width: 75%;">
                    <div id="bienvenida" class="menuitem">
                        <dx:ASPxLabel ID="lblBienvenido" runat="server" Text="Usuario: " Font-Bold="true" CssClass="lblheader1"></dx:ASPxLabel>
                        <br />
                        <dx:ASPxLabel ID="lblNomUsuario" runat="server" Text="NombreUsuario" Font-Bold="true" CssClass="lblheader2"></dx:ASPxLabel>
                    </div>
                </div>
            </div>
        </header>
    </form>
</body>
</html>
