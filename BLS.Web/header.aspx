<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="header.aspx.cs" Inherits="BLS.Web.header" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  <title>Header</title>

  <!-- Iconos (Font Awesome / tu all.css) -->
  <link rel="stylesheet" href="Content/all.css" crossorigin="anonymous" />
  <!-- Estilos del header -->
  <link rel="stylesheet" href="Content/NuevoMenu/header.css" />

    <script>
        (function () {
            var STORAGE_KEY = 'sgn_nav_collapsed';

            function setMenuCollapsedClass(collapsed) {
                try {
                    var ifrMenu = parent && parent.document.getElementById('menu');
                    if (!ifrMenu) return;

                    var set = function () {
                        try {
                            var doc = ifrMenu.contentDocument || ifrMenu.contentWindow.document;
                            var wrap = doc && doc.querySelector('.menu-wrap'); // contenedor raíz del menú
                            if (wrap) wrap.classList.toggle('is-collapsed', collapsed);
                        } catch (e) { }
                    };
                    // Si el iframe ya cargó, aplicamos de inmediato; si no, esperamos load.
                    if (ifrMenu.contentDocument && ifrMenu.contentDocument.readyState === 'complete') set();
                    else ifrMenu.addEventListener('load', set, { once: true });
                } catch (e) { }
            }

            function applyNavState(collapsed) {
                try {
                    var pDoc = parent && parent.document;
                    var ifrMenu = pDoc && pDoc.getElementById('menu');
                    var ifrContent = pDoc && pDoc.getElementById('basefrm');
                    if (!ifrMenu || !ifrContent) return;

                    if (collapsed) {
                        // Ocultar menú al 100%
                        ifrMenu.style.width = '0px';
                        ifrMenu.style.borderRight = '0';     // evita línea visible
                        ifrMenu.style.borderBottom = '0';
                        ifrContent.style.marginLeft = '0';
                        ifrContent.style.width = '100%';
                    } else {
                        // Mostrar menú (13%) – ajusta si usas otro ancho
                        ifrMenu.style.width = '13%';
                        ifrMenu.style.borderRight = '4px solid #2A385D';   // coincide con tu index.aspx
                        ifrMenu.style.borderBottom = '2px solid #2A385D';
                        ifrContent.style.marginLeft = '13%';
                        ifrContent.style.width = '87%';
                    }

                    setMenuCollapsedClass(collapsed); // oculta/mostrar contenido interno del menú
                    // Persistir estado
                    try { localStorage.setItem(STORAGE_KEY, collapsed ? '1' : '0'); } catch (e) { }
                } catch (e) { }
            }

            function toggleNav() {
                try {
                    var collapsed = localStorage.getItem(STORAGE_KEY) === '1';
                    applyNavState(!collapsed);
                } catch (e) {
                    // fallback simple
                    applyNavState(false);
                }
            }

            // Eventos
            document.addEventListener('DOMContentLoaded', function () {
                var btn = document.getElementById('btnToggleMenu');
                if (btn) btn.addEventListener('click', toggleNav);

                // Aplica el estado guardado al cargar
                var collapsed = false;
                try { collapsed = localStorage.getItem('sgn_nav_collapsed') === '1'; } catch (e) { }
                applyNavState(collapsed);
            });
        })();
    </script>
</head>
<body>
<form id="frmCabecero" runat="server" class="clsCabecero">
  <asp:ScriptManager ID="ScriptManager2" runat="server" />

  <header class="app-header" role="banner">
    <div class="header-grid">
      <!-- IZQUIERDA: botón toggle + logo + marca -->
      <div class="header-left">
        <button type="button" id="btnToggleMenu" class="h-toggle" title="Mostrar/Ocultar menú" aria-label="Mostrar/Ocultar menú">
          <i class="fas fa-bars"></i>
        </button>

        <img class="brand-logo" src="imagenes/header/logoTiSimple.png" alt="Logo" />
        <span class="brand-badge"> SGN </span>
      </div>

      <!-- CENTRO: título de página -->
      <div class="header-left">
        <dx:ASPxLabel ID="lblNombrePagina" runat="server" CssClass="page-title" Text=""></dx:ASPxLabel>
      </div>

      <!-- DERECHA: salir -->
      <div class="header-right">
        <asp:HiddenField ID="HidUsuario" runat="server" ClientIDMode="Static" />
        <dx:ASPxButton ID="btnCerrarSesion"
                       runat="server"
                       EncodeHtml="false"
                       CssClass="btn-logout"
                       ToolTip="Salir SGN"
                       Text="<i class='fas fa-power-off'></i>"
                       OnClick="btnCerrarSesion_Click" />
      </div>
    </div>
  </header>
</form>


</body>
</html>
