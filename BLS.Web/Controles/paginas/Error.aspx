<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="BLS.Web.Controles.paginas.Error" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v25.2, Version=25.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Src="~/Controles/Usuario/InfoMsgBox.ascx" TagPrefix="uc1" TagName="cuInfoMsgbox" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="user-scalable=0, width=device-width, initial-scale=1.0, maximum-scale=1.0" />

    <link rel="stylesheet" href="../../Content/all.css" crossorigin="anonymous" />
    <link rel="stylesheet" href="../../Content/generic/pageMinimalStyle.css" crossorigin="anonymous" />
    <script src="../../Scripts/jquery-3.3.1.min.js"></script>


    <script src="../../Scripts/sweetalert.min.js"></script>
    <script src="../../Scripts/mensajes.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:cuInfoMsgbox runat="server" ID="cuInfoMsgbox1" />
        <section class="CLPageContent">
            <div class="">
                <asp:Panel id="PanelError" Visible="False" Runat="server" CssClass="row rowSinMargin mb6 pt15">
							        <asp:Label runat="server" Text="Ha ocurrido un error:"></asp:Label><br /> 
								    <asp:Label ID="LblMensajeError" Font-Bold="True" Runat="server"></asp:Label><br />
								    <asp:LinkButton ID="LnkMostrarDetallesError" Runat="server" onclick="LnkMostrarDetallesError_Click">Mostrar detalle de error</asp:LinkButton><br />
								    <asp:Label ID="LblMensajeErrorDetallado" Font-Italic="True" ForeColor="#666666" Visible="False" Runat="server"></asp:Label><br />
								    <asp:Label ID="Label1" runat="server">Disculpe las molestias</asp:Label><br />
								    <asp:Label ID="Label2" runat="server">Pulse <a href="/login.aspx">Aqui</a> Para volver a la pagina de inicio</asp:Label> <br />
							</asp:Panel>
						    <asp:Panel id="PanelMensaje" Visible="False" Runat="server" CssClass="row rowSinMargin mb6 pt15">
							        <asp:Label ID="LblMensaje" Runat="server"></asp:Label>
								    <div class="spacer10"></div>
								    <asp:Label runat="server"> <a href="/login.aspx">Aqui</a> volver a la pagina de inicio> </asp:Label>
							</asp:Panel>
            </div>
        </section>
    </form>
</body>
</html>
