<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reporteFormConociendoCliente.aspx.cs" Inherits="BLS.Web.Reportes.reporteFormConociendoCliente" %>

<%@ Register Assembly="DevExpress.XtraReports.v25.2.Web.WebForms, Version=25.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<%@ Register TagPrefix="cc1" Namespace="DevExpress.XtraReports.Web.ClientControls" Assembly="DevExpress.XtraReports.v25.2.Web.WebForms, Version=25.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../Content/all.css" />
    <link rel="stylesheet" href="../Content/generic/pageMinimalStyle.css" />
    <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/mensajes.js"></script>
    <title>SGN</title>
</head>
<body>
 <form id="frmPage" runat="server" class="Principal">
     
     <section class="CLPageContent" id="maindiv">
         <dx:ASPxWebDocumentViewer runat="server" ID="reportePrinsipalView2">

         </dx:ASPxWebDocumentViewer>
     </section>
     
 </form>
</body>
</html>
