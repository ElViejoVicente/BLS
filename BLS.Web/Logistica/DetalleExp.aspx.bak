<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleExp.aspx.cs" Inherits="GPB.Web.DetalleExp" %>
<%@ Register Src="~/Controles/Usuario/InfoMsgBox.ascx" TagPrefix="uc1" TagName="cuInfoMsgbox" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v25.1, Version=25.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="user-scalable=0, width=device-width, initial-scale=1.0, maximum-scale=1.0" />
    <%--<link rel="stylesheet" href="Content/bootstrap.min.css" crossorigin="anonymous" />--%>
    <link rel="stylesheet" href="../SwitcherResources/Content/Simplex/bootstrap.min.css" crossorigin="anonymous" />
    <link rel="stylesheet" href="Content/all.css" crossorigin="anonymous" />
    <link rel="stylesheet" href="Content/generic/pageStyle.css" crossorigin="anonymous" />
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script>
        function iconMaxMin() {
            var i = $('#iconCollapse');
            i.attr('class', i.hasClass('fas fa-angle-double-down') ? 'fas fa-angle-double-up' : i.attr('data-original'));
        }

    </script>
</head>

<body>
    <form id="frmPage" runat="server" class="Principal">
        <uc1:cuInfoMsgbox runat="server" ID="cuInfoMsgbox1" />
        <header class="CLPageHeader">
            <dx:ASPxImage runat="server" ID="imagenLogo" CssClass="imagenLogo">  </dx:ASPxImage>
            <dx:ASPxLabel ID="lblNombrePagina" CssClass="titleHeader" runat="server" Text="Administración de Usuarios" Font-Bold="true"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblVersion" CssClass="titleHeader version" runat="server" Text="Versión: 1.0 Beta" Font-Bold="true"></dx:ASPxLabel>
        </header>
       <%-- <div style="margin-left: 30px;">
            <a class="btn-box-tool" data-toggle="collapse" data-target="#controles" role="button" onclick="iconMaxMin()" aria-expanded="false" aria-controls="controles"><i id="iconCollapse" data-original="fas fa-angle-double-down" class="fas fa-angle-double-down"></i></a>
        </div>

        <section class="CLPageControls" id="controles" class="collapse show" aria-labelledby="controles">
            <div class="" style="width: 100%; padding-left:10px;">
                <div class="row">
                    <div class="">
                        <dx:BootstrapButton ID="btnNuevo" runat="server" AutoPostBack="false" Text="" CssClasses-Icon="fas fa-file" ToolTip="Nuevo"
                            Style='font-size: 17px' SettingsBootstrap-Sizing="Small">
                        </dx:BootstrapButton>

                        <dx:BootstrapButton ID="btnGuaqrdar" runat="server" AutoPostBack="false" Text="" CssClasses-Icon="fas fa-save" ToolTip="Guardar"
                            Style='font-size: 17px' SettingsBootstrap-Sizing="Small">
                        </dx:BootstrapButton>

                        <dx:BootstrapButton ID="btnCancelar" runat="server" AutoPostBack="false" Text="" CssClasses-Icon="fas fa-window-close" ToolTip="Cancelar"
                            Style='font-size: 17px' SettingsBootstrap-Sizing="Small">
                        </dx:BootstrapButton>

                        <dx:BootstrapButton ID="btnBorrar" runat="server" AutoPostBack="false" Text="" CssClasses-Icon="fas fa-trash-alt" ToolTip="Borrar"
                            Style='font-size: 17px' SettingsBootstrap-Sizing="Small">
                        </dx:BootstrapButton>

                        <dx:BootstrapButton ID="btnBuscar" runat="server" AutoPostBack="false" Text="" CssClasses-Icon="fas fa-binoculars" ToolTip="Buscar"
                            Style='font-size: 17px' SettingsBootstrap-Sizing="Small">
                        </dx:BootstrapButton>

                        <dx:BootstrapButton ID="btnExportar" runat="server" AutoPostBack="false" Text="" CssClasses-Icon="fas fa-print" ToolTip="Exportar"
                            Style='font-size: 17px' SettingsBootstrap-Sizing="Small">
                        </dx:BootstrapButton>
                    </div>
                </div>
            </div>
        </section>--%>

        <section class="CLPageContent">
            <div class="">
                <dx:BootstrapFormLayout ID="FLY_Detalle" runat="server">
                    <Items>
                        <dx:BootstrapLayoutItem Caption="Expedicion" ColSpanLg="4" ColSpanMd="12">
                            <ContentCollection>
                                <dx:ContentControl>
                                    <dx:BootstrapTextBox ID="Txt_expedicion" runat="server" NullText="número de expedición" Enabled="false" />
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
						
						
						<dx:BootstrapLayoutItem Caption="Sociedad FI" ColSpanLg="4" ColSpanMd="6">
                            <ContentCollection>
                                <dx:ContentControl>
                                    <dx:BootstrapTextBox ID="Txt_sociedad" runat="server" NullText="Sociedad" Enabled="false"/>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
						
						
						<dx:BootstrapLayoutItem Caption="Origen" ColSpanLg="4" ColSpanMd="6">
                            <ContentCollection>
                                <dx:ContentControl>
                                    <dx:BootstrapTextBox ID="Txt_origen" runat="server" NullText="Origen" Enabled="false"/>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
						
						<dx:BootstrapLayoutItem Caption="Destino" ColSpanLg="4" ColSpanMd="6">
                            <ContentCollection>
                                <dx:ContentControl>
                                    <dx:BootstrapTextBox ID="Txt_destino" runat="server" NullText="Destino" Enabled="false"/>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                        	<dx:BootstrapLayoutItem Caption="Cliente" ColSpanLg="4" ColSpanMd="6">
                            <ContentCollection>
                                <dx:ContentControl>
                                    <dx:BootstrapTextBox ID="Txt_Cliente" runat="server" NullText="Destino" Enabled="false"/>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
						 <dx:BootstrapLayoutItem Caption="Observaciones" ColSpanLg="4" ColSpanMd="6" >
                            <ContentCollection>
                                <dx:ContentControl>
                                    <dx:BootstrapMemo ID="Observaciones"  runat="server" Enabled="false"/>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                         <dx:BootstrapLayoutItem Caption="Observaciones Logistica" ColSpanLg="4" ColSpanMd="6" >
                            <ContentCollection>
                                <dx:ContentControl>
                                    <dx:BootstrapMemo ID="ObservacionesLog"  runat="server" Enabled="false"/>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                       
                        <dx:BootstrapLayoutItem Caption="Nombre Transportista" ColSpanLg="4" ColSpanMd="6">
                            <ContentCollection>
                                <dx:ContentControl>
                                    <dx:BootstrapTextBox ID="Txt_transportista" runat="server" NullText="Nombre Transportista" />
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>

						<dx:BootstrapLayoutItem Caption="Matricula" ColSpanLg="4" ColSpanMd="6">
                            <ContentCollection>
                                <dx:ContentControl>
                                    <dx:BootstrapTextBox ID="txt_matricula"  AutoPostBack="true" runat="server" NullText="Matricula" />
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
							<dx:BootstrapLayoutItem Caption="Matricula Remolque" ColSpanLg="4" ColSpanMd="6">
                            <ContentCollection>
                                <dx:ContentControl>
                                    <dx:BootstrapTextBox ID="Txt_matricularemolque"  AutoPostBack="true" runat="server" NullText="Matricula Remolque" />
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
						
					
						
                        <dx:BootstrapLayoutItem ShowCaption="False" HorizontalAlign="Right">
                            <ContentCollection>
                                <dx:ContentControl>
                                      <dx:BootstrapButton ID="btnCancel" Text="Cancelar" AutoPostBack="true" CausesValidation="false" runat="server" OnClick="btnCancel_Click">
                                        <SettingsBootstrap RenderOption="Secondary" />
                                    </dx:BootstrapButton>
                                    <dx:BootstrapButton ID="btnGuardar" Text="Guardar" AutoPostBack="true" CausesValidation="false" runat="server" OnClick="btnGuardar_Click">
                                        <SettingsBootstrap RenderOption="Primary" />
                                    </dx:BootstrapButton>
                                </dx:ContentControl>

                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                    </Items>
                </dx:BootstrapFormLayout>
            </div>
        </section>

        <footer class="CLPageFooter">
            © Derechos Reservados 2020-2021 CL Grupo Industrial Todos los Derechos Reservados.
        </footer>
    </form>

</body>
</html>
