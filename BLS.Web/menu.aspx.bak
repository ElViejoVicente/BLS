<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menu.aspx.cs" Inherits="SGN.Web.menu" %>
<%@ Register Assembly="DevExpress.Web.v25.1, Version=25.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Menú</title>

    <!-- Estilos del menú -->
    <link rel="stylesheet" href="Content/NuevoMenu/menu.css" />
    <script type="text/javascript">
        // Ajusta alturas para que el árbol use el máximo espacio
        function AdjustSize() {
            try {
                var wrap = document.querySelector('.menu-wrap');
                if (wrap && wrap.classList.contains('is-collapsed')) return; // si está colapsado, no hace falta calcular

                var vh = window.innerHeight || document.documentElement.clientHeight;
                var body = document.getElementById('menudiv');
                var card = document.querySelector('.user-card');
                var sep = document.querySelector('.menu-sep');

                var bodyPaddingV = 24; // padding vertical de .menu-body (10 top + 14 bottom)

                // Altura del body = 100% del iframe
                if (body) body.style.height = vh + 'px';

                var cardH = card ? card.offsetHeight : 0;
                var sepH = sep ? sep.offsetHeight : 0;

                var panelH = Math.max(0, vh - (cardH + sepH + bodyPaddingV));
                var panel = document.getElementById('menuPanel');
                if (panel) panel.style.height = panelH + 'px';

                // Ajustar control DevExpress si existe
                try { if (rtvMenu && rtvMenu.SetHeight) rtvMenu.SetHeight(panelH - 8); } catch (e) { }
            } catch (e) { }
        }

        document.addEventListener('DOMContentLoaded', function () {
            AdjustSize();
        });
        window.addEventListener('resize', AdjustSize);
    </script>
</head>
<body>
<form id="frmMenu" runat="server" class="menu-form-root">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <!-- Puedes usar estos HiddenFields si tu lógica de servidor los necesita -->
    <dx:ASPxHiddenField ID="Hidden_usuario" runat="server" ClientIDMode="Static"></dx:ASPxHiddenField>
    <dx:ASPxHiddenField ID="hBandera"       runat="server" ClientIDMode="Static"></dx:ASPxHiddenField>

    <!-- Contenedor raíz del menú (el header agrega/quita la clase .is-collapsed aquí) -->
    <div class="menu-wrap">
        <!-- Cuerpo del menú -->
        <div id="menudiv" class="menu-body">
            <!-- Credenciales compactas (sin avatar) -->
            <div id="credenciales" class="user-card compact">
                <dx:ASPxLabel ID="lblPerfil"     runat="server" CssClass="user-role"  />
                <dx:ASPxLabel ID="lblNomUsuario" runat="server" CssClass="user-name"  />
                <dx:ASPxLabel ID="lblMail"       runat="server" CssClass="user-mail"  />
            </div>

            <hr class="menu-sep" />

            <!-- Panel con el árbol -->
            <div id="menuPanel" class="menu-panel">
                <dx:ASPxTreeView ID="rtvMenu" AllowSelectNode="true" EnableNodeTextWrapping="true" 
                                 runat="server"
                                 
                                 CssClass="treMenu"
                                 OnNodeClick="rtvMenu_NodeClick"
                                 OnExpandedChanging="rtvMenu_ExpandedChanging">
                    <ClientSideEvents Init="AdjustSize" />
                </dx:ASPxTreeView>
            </div>
        </div>
    </div>
</form>


</body>
</html>
