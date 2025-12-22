<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="indexMovil.aspx.cs" Inherits=" BLS.Web.indexMovil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <meta name="viewport" content="user-scalable=0, width=device-width, initial-scale=1.0, maximum-scale=1.0" />
    <link rel="stylesheet" href="Content/bootstrap.min.css" crossorigin="anonymous" />
    <link rel="stylesheet" href="Content/all.css" crossorigin="anonymous" />
    <link rel="stylesheet" type="text/css" href="Content/indexMovil.css" />

    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
      <script src="Scripts/sweetalert.min.js"></script>
    <script src="Scripts/mensajes.js"></script>
    <style>
    </style>
    <script>
        $(document).ready(function () {
            //launchFullScreen(document.documentElement);
            dvMenu.classList.remove('clsMenu');
            dvMenu.classList.add('clsMenu2');

            $('#dvMenu').show();
            $('#dvCabecera').show();
            $('#dvContent').show();
        });


         function launchFullScreen(element) {
            if (element.requestFullScreen) {
                element.requestFullScreen();
            } else if (element.mozRequestFullScreen) {
                element.mozRequestFullScreen();
            } else if (element.webkitRequestFullScreen) {
                element.webkitRequestFullScreen();
            }
        }
    </script>
</head>


<div class="container">
    <div id="dvMenu" class="collapse clsMenu">
        <iframe name="menu" id="menu" class="responsive-iframe-menu"  src="menuMovil.aspx"></iframe>
    </div>
    <div  id="dvCabecera" class="collapse clsHeader">
        <iframe name="Cabecera" id="Cabecera" class="responsive-iframe"   src="headerMovil.aspx"></iframe>
    </div>
    <div  id="dvContent" class="collapse clsContent">
        <iframe name="content" id="content" class="responsive-iframe-menu"   src="PlantillaMovil.aspx?initCod=13"></iframe>
    </div>
</div>


</html>
