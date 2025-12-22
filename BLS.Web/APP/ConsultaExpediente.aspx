<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultaExpediente.aspx.cs" Inherits="BLS.Web.APP.ConsultaExpediente" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Sistema de Gestión Notarial v1.5 - Consulta de Folio</title>
    <style>
        /* Reset básico */
        *, *::before, *::after { box-sizing: border-box; }
        html, body { height: 100%; margin: 0; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; -webkit-font-smoothing:antialiased; }
        body {
            background: linear-gradient(180deg, #f4f6f8 0%, #eef2f6 100%);
            color: #243240;
            display: flex;
            align-items: stretch;
            justify-content: center;
            padding: 20px;
        }

        /* Contenedor principal centrado */
        .page {
            width: 100%;
            max-width: 920px;
            background: #fff;
            box-shadow: 0 6px 24px rgba(20,30,40,0.08);
            border-radius: 6px;
            overflow: hidden;
            display: flex;
            flex-direction: column;
        }

        /* Logo */
        .logo-container {
            text-align: center;
            padding: 15px 0 0 0;
            background: #0f2b3d;
        }
        .logo {
            max-width: 120px;
            max-height: 80px;
            height: auto;
        }

        /* Header */
        .page-header {
            background: #0f2b3d; /* azul oscuro similar al mockup */
            color: #fff;
            padding: 18px 24px;
            text-align: center;
        }
        .page-header h1 { margin: 0; font-weight: 600; font-size: 20px; }
        .page-header p { margin: 4px 0 0; opacity: 0.9; font-size: 14px; }

        /* Content */
        .page-body {
            padding: 28px 30px;
            display: flex;
            flex-direction: column;
            gap: 22px;
        }

        /* Form area centered */
        .form-card {
            width: 100%;
            display: grid;
            grid-template-columns: 1fr;
            gap: 18px;
            align-items: start;
        }

        .field-row {
            display: flex;
            align-items: center;
            gap: 18px;
            justify-content: center;
            flex-wrap: wrap;
        }

        .label { width: 100%; max-width: 100px; text-align: left; color: #243240; font-weight: 600; }

        /* Estilo del textbox DevExpress (mantener compatibilidad) */
        .folio-box {
            width: 100%;
            max-width: 360px;
            margin: 0 auto;
            padding: 14px 18px;
            border: 2px solid #cbd6df;
            border-radius: 4px;
            background: #fff;
            text-align: center;
            font-size: 22px;
            color: #111827;
            font-weight: 600;
            letter-spacing: 1px;
        }

        .input-error {
            border-color: #c0392b !important;
            box-shadow: 0 0 0 2px #c0392b22;
        }

        .field-error {
            color: #c0392b;
            font-size: 14px;
            margin-top: 6px;
            min-height: 18px;
        }

        /* Captcha y botón lado a lado en desktop, apilados en móvil */
        .captcha-area {
            display: grid;
            grid-template-columns: 1fr 140px;
            gap: 18px;
            align-items: center;
            justify-items: center;
            width: 100%;
            max-width: 720px;
            margin: 0 auto;
        }

        .captcha-box {
            width: 100%;
            display: flex;
            flex-direction: column;
            align-items: center;
            padding: 14px;
            background: linear-gradient(180deg,#fafcff,#f3f7fb);
            border: 1px solid #d6e0ea;
            border-radius: 6px;
        }

        .captcha-canvas {
            margin-bottom: 10px;
            background: #fff;
            border: 1px solid #cbd6df;
            border-radius: 4px;
            display: block;
        }

        .captcha-input {
            width: 100%;
            max-width: 320px;
            margin-top: 12px;
            padding: 14px 16px;
            border: 1px solid #cbd6df;
            border-radius: 4px;
            font-size: 20px;
            text-align: center;
            background: #fff;
            font-weight: 600;
            letter-spacing: 1px;
        }

        .captcha-refresh {
            margin-top: 8px;
            background: none;
            border: none;
            color: #0f5a85;
            font-size: 14px;
            cursor: pointer;
            text-decoration: underline;
        }

        .captcha-error {
            color: #c0392b;
            font-size: 14px;
            margin-top: 8px;
            min-height: 18px;
        }

        .btn-consultar {
            width: 140px;
            background: #0f5a85;
            color: #fff;
            border: none;
            padding: 10px 12px;
            border-radius: 6px;
            cursor: pointer;
            font-weight: 600;
        }
        .btn-consultar:active { transform: translateY(1px); }

        /* Panel estatus grande */
        .status-panel {
            width: 100%;
            max-width: 820px;
            margin: 0 auto;
            background: #fbfdff;
            border: 1px solid #e2e9ef;
            padding: 14px;
            border-radius: 6px;
            position: relative;
            transition: all 0.3s;
        }
        .status-panel.maximized {
            position: fixed;
            top: 0; left: 0; right: 0; bottom: 0;
            z-index: 9999;
            max-width: none;
            width: 100vw;
            height: 100vh;
            margin: 0;
            border-radius: 0;
            background: #fff;
            box-shadow: 0 0 0 9999px rgba(36,50,64,0.12);
            display: flex;
            flex-direction: column;
            justify-content: flex-start;
            align-items: stretch;
        }
        .status-panel .maximize-btn {
            position: absolute;
            top: 10px;
            right: 14px;
            background: #0f5a85;
            color: #fff;
            border: none;
            border-radius: 4px;
            padding: 6px 14px;
            font-size: 15px;
            cursor: pointer;
            z-index: 2;
        }
        .status-panel.maximized .maximize-btn {
            right: 18px;
            top: 18px;
            background: #c0392b;
        }
        .status-panel.maximized .status-memo {
            height: calc(100vh - 80px);
            font-size: 22px;
        }
        .status-panel.maximized h3 {
            font-size: 22px;
            margin-bottom: 18px;
        }
        .status-panel.maximized ~ * { display: none !important; }

        /* Footer */
        .page-footer {
            background: #0f2b3d;
            color: #fff;
            padding: 12px 18px;
            text-align: center;
            font-size: 13px;
        }

        /* Responsive */
        @media (max-width: 780px) {
            .captcha-area { grid-template-columns: 1fr; }
            .btn-consultar { width: 100%; max-width: 320px; }
            .status-memo { height: 200px; }
        }
        @media (max-width: 420px) {
            .page-body { padding: 18px; }
            .folio-box { max-width: 100%; padding: 12px; }
            .status-memo { height: 160px; }
        }
    </style>

    <script type="text/javascript">
        var captchaCode = '';
        function randomChar() {
            var chars = 'ABCDEFGHJKLMNPQRSTUVWXYZ23456789';
            return chars.charAt(Math.floor(Math.random() * chars.length));
        }
        function drawCaptcha() {
            var canvas = document.getElementById('captchaCanvas');
            var ctx = canvas.getContext('2d');
            ctx.clearRect(0, 0, canvas.width, canvas.height);
            ctx.fillStyle = '#f4f6f8';
            ctx.fillRect(0, 0, canvas.width, canvas.height);
            // Generar código aleatorio de 5 caracteres (letras y números)
            captchaCode = '';
            for (var i = 0; i < 5; i++) {
                captchaCode += randomChar();
            }
            // Dibujar el código con distorsión y colores
            for (var i = 0; i < captchaCode.length; i++) {
                ctx.save();
                ctx.font = (32 + Math.floor(Math.random() * 10)) + 'px Segoe UI, Tahoma, Arial';
                ctx.fillStyle = (i % 2 == 0) ? '#2c3e50' : '#0f5a85';
                ctx.translate(30 + i * 35, 40 + Math.random() * 10);
                ctx.rotate((Math.random() - 0.5) * 0.5);
                ctx.fillText(captchaCode[i], 0, 0);
                ctx.restore();
            }
            // Líneas de ruido
            for (var i = 0; i < 5; i++) {
                ctx.beginPath();
                ctx.moveTo(Math.random() * canvas.width, Math.random() * canvas.height);
                ctx.lineTo(Math.random() * canvas.width, Math.random() * canvas.height);
                ctx.strokeStyle = '#cbd6df';
                ctx.lineWidth = 2;
                ctx.stroke();
            }
            // Puntos de ruido
            for (var i = 0; i < 12; i++) {
                ctx.beginPath();
                ctx.arc(Math.random() * canvas.width, Math.random() * canvas.height, Math.random() * 5, 0, 2 * Math.PI);
                ctx.fillStyle = '#b0b7c3';
                ctx.fill();
            }
            document.getElementById('captchaError').textContent = '';
            document.getElementById('txtCodigoCaptcha').value = '';
        }
        function validateCaptchaAndFolio() {
            var folioInput = document.getElementById('txtFolioIterno_I');
            var folioValue = folioInput.value.trim();
            var folioError = document.getElementById('folioError');
            var folioRegex = /^\d{1,3}-\d{1,2}-\d{4}[SC]$/i;
            var captchaInput = document.getElementById('txtCodigoCaptcha').value.trim().toUpperCase();
            var captchaError = document.getElementById('captchaError');
            var valid = true;
            if (folioValue === '') {
                folioError.textContent = 'El folio es obligatorio.';
                folioInput.classList.add('input-error');
                valid = false;
            } else {
                folioError.textContent = '';
                folioInput.classList.remove('input-error');
            }
            if (captchaInput !== captchaCode) {
                captchaError.textContent = 'Código incorrecto. Intente de nuevo.';
                drawCaptcha();
                valid = false;
            } else {
                captchaError.textContent = '';
            }
            return valid;
        }
        function toggleMaximizeStatusPanel() {
            var panel = document.getElementById('statusPanel');
            if (panel.classList.contains('maximized')) {
                panel.classList.remove('maximized');
                document.body.style.overflow = '';
            } else {
                panel.classList.add('maximized');
                document.body.style.overflow = 'hidden';
            }
        }
        window.onload = function () {
            drawCaptcha();
        };
    </script>
</head>
<body>
    <form id="form1" runat="server" onsubmit="return validateCaptchaAndFolio();">

        <div class="page">
            <!-- Logo agregado aquí -->
            <div class="logo-container">
                <img src="../imagenes/login/LogoNotaria.svg" alt="Logo Notaria" class="logo" />
            </div>

            <header class="page-header">
                <h1>Notaria 01 Huamantla</h1>
                <p>Consulta de Expediente</p>
            </header>

            <main class="page-body">
                <section class="form-card">
                    <div class="field-row">
                        <label class="label" for="txtFolioIterno">Numero de Expediente:</label>
                        <div style="flex:1; display:flex; flex-direction:column; justify-content:center; align-items:center;">
                            <dx:ASPxTextBox runat="server" ID="txtFolioIterno" ClientInstanceName="txtFolioIterno" CssClass="folio-box" NullText="Introduzca el número de folio" />
                            <div id="folioError" class="field-error"></div>
                        </div>
                    </div>

                    <div style="text-align:center; color:#4b5563; font-weight:600;">Verificación de seguridad</div>

                    <dx:ASPxCallbackPanel runat="server" ID="cpConsultaFolio" ClientInstanceName="cpConsultaFolio" OnCallback="cpConsultaFolio_Callback">
                        <PanelCollection>
                            <dx:PanelContent>
                                <div class="captcha-area">
                                    <div class="captcha-box">
                                        <canvas id="captchaCanvas" class="captcha-canvas" width="220" height="70"></canvas>
                                        <input type="text" id="txtCodigoCaptcha" class="captcha-input" placeholder="Introduzca el código mostrado" autocomplete="off" />
                                        <button type="button" class="captcha-refresh" onclick="drawCaptcha()">Mostrar otro código</button>
                                        <div id="captchaError" class="captcha-error"></div>
                                    </div>
                                    <div style="display:flex; align-items:center; justify-content:center;">
                                        <dx:ASPxButton runat="server" ID="btnConsultar" ClientInstanceName="btnConsultar"
                                            CssClass="btn-consultar" Text="Consultar" AutoPostBack="false" ClientEnabled="true">
                                            <ClientSideEvents Click="function(s,e){ if(validateCaptchaAndFolio()){ cpConsultaFolio.PerformCallback(txtFolioIterno.GetText()); } }" />
                                        </dx:ASPxButton>
                                    </div>
                                </div>
                                <div class="status-panel" id="statusPanel">
                                    <button type="button" class="maximize-btn" onclick="toggleMaximizeStatusPanel()" title="Maximizar/Restaurar">&#x26F6;</button>
                                    <h3>Estatus del folio:</h3>
                                    <dx:ASPxMemo runat="server" ID="txtEstatusFolio" ClientInstanceName="txtEstatusFolio"
                                        CssClass="status-memo" Width="100%" Rows="15" NullText="Necesita pasar la verificación de seguridad para consultar su estatus" ReadOnly="true" />
                                </div>
                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxCallbackPanel>
                </section>
            </main>

            <footer class="page-footer">
                © 2025 | <a href="https://www.bing.com/ck/a?!&&p=1a1e56f44becf2a5ea326ed7bd978543dd93fedd822080850fd3d9f4eff3308eJmltdHM9MTc1OTUzNjAwMA&ptn=3&ver=2&hsh=4&fclid=08d34849-2bc1-6527-2027-5cb92a96647a&u=a1L21hcHM_Jm1lcGk9MH5-RW1iZWRkZWR-QWRkcmVzc19MaW5rJnR5PTE4JnE9Tm90YXJpYSUyME5vLjElMjBIdWFtYW50bGElMjBUbGF4LiZzcz15cGlkLllOOTAwMXg2ODQ3ODE0ODQ0NDYwNDk3NjIyJnBwb2lzPTE5LjMxMjI4NDQ2OTYwNDQ5Ml8tOTcuOTI1MzE1ODU2OTMzNl9Ob3RhcmlhJTIwTm8uMSUyMEh1YW1hbnRsYSUyMFRsYXguX1lOOTAwMXg2ODQ3ODE0ODQ0NDYwNDk3NjIyfiZjcD0xOS4zMTIyODR-LTk3LjkyNTMxNiZ2PTImc1Y9MSZGT1JNPU1QU1JQTA" target="_blank" style="color:inherit; text-decoration:underline;">Notaria No.1 Huamantla Tlax. | 247 472 1542 | Avenida Zaragoza Poniente, #213</a>
            </footer>
        </div>

        <!-- Eventos globales de cliente de DevExpress -->
        <dx:ASPxGlobalEvents ID="ASPxGlobalEvents1" runat="server">
            <ClientSideEvents
                ControlsInitialized="OnControlsInitialized"
                ValidationCompleted="OnValidationCompleted" />
        </dx:ASPxGlobalEvents>

    </form>
</body>
</html>