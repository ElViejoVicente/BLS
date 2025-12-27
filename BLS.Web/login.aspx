<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="BLS.Web.Login" %>

<%@ Register Assembly="DevExpress.Web.v25.2, Version=25.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v25.2, Version=25.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Src="~/Controles/Usuario/InfoMsgBox.ascx" TagPrefix="uc1" TagName="cuInfoMsgbox" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>SGN</title>
    <link rel="icon" href="imagenes/favicon.ico" />
    <link rel="stylesheet" type="text/css" href="Content/NuevoMenu/login.css" />
    <link rel="stylesheet" href="../SwitcherResources/Content/Yeti/bootstrap.min.css" />
    <script src="Scripts/sweetalert2.all.min.js"></script>
    <link rel="stylesheet" href="Scripts/sweetalert2.min.css" />
    <script src="../Scripts/mensajes.js"></script>

</head>
<body>
    <form id="frmLogin" runat="server">
        <!-- Estructura página: header (opcional) / main centrado / footer sticky -->
        <div class="page">
            <main class="main">
                <section class="card animate-slide-up">
                    <header class="card-header">
                        <img src="imagenes/header/logoTi.png" alt="Logo Sistema" class="logo-animated" />
                        <h1 class="title">Bienvenido</h1>
                        <h4 class="subtitle">BlackList Sentinel v1.0</h4>
                    </header>

                    <div class="card-body">
                        <uc1:cuInfoMsgbox runat="server" ID="cuInfoMsgbox1" OnRespuestaClick="cuInfoMsgbox1_RespuestaClicked" />

                        <div class="form-row">

                            <dx:BootstrapTextBox runat="server"  ID="txtUsername" Width="100%" NullText="Correo electronico">
                                <ValidationSettings
                                    SetFocusOnError="true" ValidateOnLeave="false">
                                   <RegularExpression ErrorText="Correo no válido" ValidationExpression="^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$" />
                                    <RequiredField IsRequired="True" ErrorText="El campo Correo es obligatorio" />
                                </ValidationSettings>
                            </dx:BootstrapTextBox>


                        </div>

                        <div class="form-row">

                            
                            <dx:BootstrapTextBox runat="server"  ID="txtPassword" Width="100%" NullText="Contraseña" Password="true" >
                                <ValidationSettings
                                    SetFocusOnError="true" ValidateOnLeave="false">                                   
                                    <RequiredField IsRequired="True" ErrorText="El campo contraseña es obligatorio" />
                                </ValidationSettings>
                            </dx:BootstrapTextBox>

                                           

                        </div>

                        <div class="form-actions">

                            <dx:ASPxButton ID="BT_ok" runat="server" OnClick="BT_ok_Click" Text="Ingresar" CssClass="btn-primary glow-on-hover"></dx:ASPxButton>
                            <dx:ASPxButton ID="btnRecuperarContreseña" runat="server" OnClick="BT_ok_Click" Text="Recuperar Contraseña" CssClass="btn-secondary glow-on-hover"></dx:ASPxButton>

                        </div>

                    </div>
                </section>
            </main>

            <footer class="footer">
                © 2026 Derechos Reservados |
            <a href="http://www.consultoria-it.com" target="_blank">Consultoria IT | 56 3731 8762 | Francisco I. Madero 3A Humantla, Tlax | Sistema Orgullosamente Tlaxcalteca
            </a>
            </footer>
        </div>
    </form>
</body>
</html>
