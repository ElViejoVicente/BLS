
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menuMovil.aspx.cs" Inherits=" SGN.Web.menuMovil" %>


<%@ Register Src="~/Controles/Usuario/InfoMsgBox.ascx" TagPrefix="uc1" TagName="cuInfoMsgbox" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v25.1, Version=25.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <title>GPB</title>

    <link rel="stylesheet" href="../Content/bootstrap.min.css" crossorigin="anonymous" />
    <link rel="stylesheet" href="../Content/font-awesome.min.css" crossorigin="anonymous"/>
    <link rel="stylesheet" href="../Content/all.css" crossorigin="anonymous" />
    <link rel="stylesheet" type="text/css" href="../Content/menuMovil.css" />
    <%--<link rel="stylesheet" type="text/css" href="Content/headers.css" />--%>

    <script src="../Scripts/jquery-latest.js"></script>
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <script src="../Scripts/umd/popper.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
      <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/mensajes.js"></script>
    <style>
    </style>
    <script>
        $(document).ready(function(){
            $('.collapse').collapse("show");
        });

        function colapsarmenu(url){
           console.log("url por parametro:"+ url);
           $('.collapse').collapse("hide");
           
            parent.document.getElementById('content').src = url;
            parent.document.getElementById('dvMenu').classList.remove('clsMenu2');
            parent.document.getElementById('dvMenu').classList.add('clsMenu');
        }

        function resizeContent() {

            if (!$("#contentPrincipal").hasClass('show')) {

                parent.document.getElementById('dvMenu').classList.remove('clsMenu');
                parent.document.getElementById('dvMenu').classList.add('clsMenu2');
            }
            else {
                parent.document.getElementById('dvMenu').classList.remove('clsMenu2');
                parent.document.getElementById('dvMenu').classList.add('clsMenu');
            }
        }

    </script>
</head>
<body>
    <form id="frmMenu" runat="server" class="">
      <dx:ContentControl ID="TpPerfil" runat="server">
            
        <div>
            <nav class="navbar navbar-light navbar-1 white">
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#contentPrincipal"  onclick="resizeContent()"
                    aria-controls="contentPrincipal" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
            </nav>
        </div>
          
     
        
        <div id="contentPrincipal" class="collapse container-fluid h-100 mt-3">
            <div id="filaParent" class="row h-100">
                <div class="col-xl-12">
                    <div  id="accordionMenu" runat="server"  class="accordion h-100 mb-2">
                    </div>
                </div>
            </div>
        </div>
           <div id="EndSession" class="close">
                        <dx:ASPxButton runat="server" ID="btnCerrarSesion" Text="" OnClick="btnCerrarSesion_Click" CssClass="btn float-right login_btn" ToolTip="Salir">
                            <HoverStyle BackgroundImage-ImageUrl="imagenes/header/cerrarSessionMinHover.png"></HoverStyle>
                        </dx:ASPxButton>
                    </div>
      </dx:ContentControl>
     </form>
</body>
</html>
