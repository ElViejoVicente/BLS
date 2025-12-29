<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResumenCreditos.aspx.cs" Inherits="BLS.Web.RegistroClientes.ResumenCreditos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />


    <link rel="stylesheet" href="../Content/all.css" />
    <link rel="stylesheet" href="../Content/generic/pageMinimalStyle.css" />
    <script src="../Scripts/sweetalert2.all.min.js"></script>
    <link rel="stylesheet" href="../Scripts/sweetalert2.min.css" />
    <script src="../Scripts/mensajes.js"></script>



    <title>BLS</title>
</head>
<body>
    <form id="frmPage" runat="server" class="Principal">

        <section class="CLPageContent" id="maindiv">



            <dx:ASPxPanel ID="pnlClienteNuevo" runat="server" ClientVisible="false"  >


            </dx:ASPxPanel>


            <dx:ASPxPanel ID="pnlResumenCliente" runat="server" ClientVisible="false">


            </dx:ASPxPanel>



        </section>

    </form>
</body>
</html>
