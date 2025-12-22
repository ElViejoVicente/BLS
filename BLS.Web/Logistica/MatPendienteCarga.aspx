<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MatPendienteCarga.aspx.cs" Inherits="GPB.Web.Logistica.MatPendienteCarga" %>

<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v25.2, Version=25.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>
<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v25.2, Version=25.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler.Controls" TagPrefix="dxwschsc" %>
<%@ Register Src="~/Controles/Usuario/InfoMsgBox.ascx" TagPrefix="uc1" TagName="cuInfoMsgbox" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v25.2, Version=25.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="user-scalable=0, width=device-width, initial-scale=1.0, maximum-scale=1.0" />
    <link rel="stylesheet" href="../SwitcherResources/Content/Simplex/bootstrap.min.css" crossorigin="anonymous" />
    <link rel="stylesheet" href="../Content/all.css" crossorigin="anonymous" />
    <link rel="stylesheet" href="../Content/generic/pageStyle.css" crossorigin="anonymous" />
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>

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
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <uc1:cuInfoMsgbox runat="server" ID="cuInfoMsgbox1" />

        <header class="CLPageHeader">
            <dx:ASPxImage runat="server" ID="imagenLogo" CssClass="imagenLogo"></dx:ASPxImage>
            <dx:ASPxLabel ID="lblNombrePagina" CssClass="titleHeader" runat="server" Text="Administración de Usuarios" Font-Bold="true"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblVersion" CssClass="titleHeader version" runat="server" Text="Versión: 1.0 Beta" Font-Bold="true"></dx:ASPxLabel>
        </header>
        <div style="margin-left: 30px;">
            <a class="btn-box-tool" data-toggle="collapse" data-target="#controles" role="button" onclick="iconMaxMin()" aria-expanded="false" aria-controls="controles"><i id="iconCollapse" data-original="fas fa-angle-double-down" class="fas fa-angle-double-down"></i></a>
        </div>

        <section class="CLPageControls" id="controles" class="collapse show" aria-labelledby="controles">
            <div class="" style="width: 100%; padding-left: 10px;">
                <div class="row">
                    <div class="">
                        <%--     <dx:BootstrapButton ID="btnNuevo" runat="server" AutoPostBack="false" Text="" CssClasses-Icon="fas fa-file" ToolTip="Nuevo"
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
                        </dx:BootstrapButton>--%>

                        <dx:BootstrapButton ID="btnBuscar" runat="server" AutoPostBack="false" Text="" CssClasses-Icon="fas fa-binoculars" ToolTip="Buscar"
                            Style='font-size: 17px' SettingsBootstrap-Sizing="Small" OnClick="btnBuscar_Click">
                            <ClientSideEvents Click="function(s, e) {  Callback.PerformCallback(); LoadingPanel.Show(); }" />
                        </dx:BootstrapButton>

                        <dx:BootstrapButton ID="btnExportar" runat="server" AutoPostBack="false" Text="" CssClasses-Icon="fas fa-print" ToolTip="Exportar"
                            Style='font-size: 17px' SettingsBootstrap-Sizing="Small" OnClick="btnExportar_Click">
                        </dx:BootstrapButton>
                    </div>
                </div>
            </div>
        </section>

        <section class="CLPageContent">
            <div class="">
                <dx:ASPxCallback ID="Callback" runat="server" ClientInstanceName="Callback">
                    <ClientSideEvents CallbackComplete="function(s, e) { LoadingPanel.Hide(); }" />
                </dx:ASPxCallback>

                <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td>
                                    <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" ShowCollapseButton="true" Width="100px" HeaderText="Opciones de consulta:" View="GroupBox">
                                        <PanelCollection>
                                            <dx:PanelContent>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <dx:ASPxComboBox runat="server" ID="cbSocieades" ClientInstanceName="cbSocieades" Width="200px"
                                                                OnDataBinding="cbSocieades_DataBinding" Caption="Sociedad:" AutoPostBack="true">
                                                            </dx:ASPxComboBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </dx:PanelContent>
                                        </PanelCollection>
                                    </dx:ASPxRoundPanel>
                                </td>
                            </tr>
                        </table>


                        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="gvPendientesCarga"></dx:ASPxGridViewExporter>


                        <dx:ASPxGridView ID="gvPendientesCarga" runat="server" AutoGenerateColumns="false" Width="100%" Visible="false" Settings-HorizontalScrollBarMode="Auto"
                            OnDataBinding="gvPendientesCarga_DataBinding">

                            <SettingsCookies Enabled="true" />

                            <Toolbars>
                                <dx:GridViewToolbar>
                                    <Items>
                                        <dx:GridViewToolbarItem Command="ShowCustomizationWindow" />
                                    </Items>
                                </dx:GridViewToolbar>
                            </Toolbars>

                            <SettingsAdaptivity AdaptivityMode="HideDataCellsWindowLimit"
                                AllowOnlyOneAdaptiveDetailExpanded="true"
                                AllowHideDataCellsByColumnMinWidth="true">
                            </SettingsAdaptivity>
                            <Settings ShowFooter="True" ShowFilterRow="true" ShowFilterBar="Auto" ShowFilterRowMenu="True" ShowHeaderFilterButton="True" ShowGroupPanel="True" />

                            <SettingsBehavior AllowSelectByRowClick="True" ProcessFocusedRowChangedOnServer="True" AllowSelectSingleRowOnly="True" AllowEllipsisInText="true" />
                            <SettingsDataSecurity AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>

                            <EditFormLayoutProperties>
                                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="300" />
                            </EditFormLayoutProperties>

                            <Columns>
                                <dx:GridViewDataSpinEditColumn VisibleIndex="0" ReadOnly="true" Caption="Id Agencia" FieldName="AgenciaId" Visible="false">
                                    <PropertiesSpinEdit SpinButtons-ShowIncrementButtons="false"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataTextColumn VisibleIndex="1" ReadOnly="true" Caption="Nom. Agencia" FieldName="AgenciaNom" Visible="false"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn VisibleIndex="2" ReadOnly="true" Caption="Articulo" FieldName="ArtNom" Visible="true"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataSpinEditColumn VisibleIndex="3" ReadOnly="true" Caption="CP. Envio" FieldName="CP_Envio" Visible="true">
                                    <PropertiesSpinEdit SpinButtons-ShowIncrementButtons="false"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn VisibleIndex="4" ReadOnly="true" Caption="Id Cliente" FieldName="ClienteGESAGId" Visible="false">
                                    <PropertiesSpinEdit SpinButtons-ShowIncrementButtons="false"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataTextColumn VisibleIndex="5" ReadOnly="true" Caption="Nom Cliente" FieldName="ClienteNom" Visible="true"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn VisibleIndex="6" ReadOnly="true" Caption="Cliente SAP ID" FieldName="ClienteSAPId" Visible="true"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn VisibleIndex="7" ReadOnly="true" Caption="Dir. Envio" FieldName="Dir_Envio" Visible="true"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataSpinEditColumn VisibleIndex="8" ReadOnly="true" Caption="Entrega Real" FieldName="EntregaReal" Visible="false">
                                    <PropertiesSpinEdit SpinButtons-ShowIncrementButtons="false"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>

                                <dx:GridViewDataSpinEditColumn VisibleIndex="10" ReadOnly="true" Caption="Estado Id" FieldName="EstadoId" Visible="false">
                                    <PropertiesSpinEdit SpinButtons-ShowIncrementButtons="false"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataTextColumn VisibleIndex="11" ReadOnly="true" Caption="Estado Nom" FieldName="EstadoNom" Visible="true"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn VisibleIndex="12" ReadOnly="true" Caption="Fec. Creacion" FieldName="FecCreacion" Visible="true"></dx:GridViewDataDateColumn>
                                <dx:GridViewDataDateColumn VisibleIndex="13" ReadOnly="true" Caption="Fec. Autorizacion" FieldName="FechaAutorizacion" Visible="false"></dx:GridViewDataDateColumn>
                                <dx:GridViewDataDateColumn VisibleIndex="14" ReadOnly="true" Caption="Fec. Bruto" FieldName="FechaBruto" Visible="false"></dx:GridViewDataDateColumn>
                                <dx:GridViewDataDateColumn VisibleIndex="15" ReadOnly="true" Caption="Fec. Entrada" FieldName="FechaEntrada" Visible="false"></dx:GridViewDataDateColumn>
                                <dx:GridViewDataDateColumn VisibleIndex="16" ReadOnly="true" Caption="Fec. EntregaMaterial" FieldName="FechaEntregaMaterial" Visible="false"></dx:GridViewDataDateColumn>
                                <dx:GridViewDataDateColumn VisibleIndex="17" ReadOnly="true" Caption="Fec. EstimadaEntrega" FieldName="FechaEstimadaEntrega" Visible="false"></dx:GridViewDataDateColumn>
                                <dx:GridViewDataDateColumn VisibleIndex="18" ReadOnly="true" Caption="Fec. EstimadaRecogida" FieldName="FechaEstimadaRecogida" Visible="false"></dx:GridViewDataDateColumn>
                                <dx:GridViewDataDateColumn VisibleIndex="19" ReadOnly="true" Caption="Fec. LLamada" FieldName="FechaLLamada" Visible="false"></dx:GridViewDataDateColumn>
                                <dx:GridViewDataDateColumn VisibleIndex="20" ReadOnly="true" Caption="Fec. Matricula" FieldName="FechaMatricula" Visible="false"></dx:GridViewDataDateColumn>
                                <dx:GridViewDataDateColumn VisibleIndex="21" ReadOnly="true" Caption="Fec. Parque" FieldName="FechaParque" Visible="false"></dx:GridViewDataDateColumn>
                                <dx:GridViewDataDateColumn VisibleIndex="22" ReadOnly="true" Caption="Fec. Salida" FieldName="FechaSalida" Visible="false"></dx:GridViewDataDateColumn>
                                <dx:GridViewDataDateColumn VisibleIndex="23" ReadOnly="true" Caption="Fec. Tara" FieldName="FechaTara" Visible="false"></dx:GridViewDataDateColumn>
                                <dx:GridViewDataSpinEditColumn VisibleIndex="24" ReadOnly="true" Caption="Kilos Reservados" FieldName="KilReser" Visible="true">
                                    <PropertiesSpinEdit SpinButtons-ShowIncrementButtons="false"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn VisibleIndex="25" ReadOnly="true" Caption="Kilos" FieldName="Kilos" Visible="true">
                                    <PropertiesSpinEdit SpinButtons-ShowIncrementButtons="false"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataTextColumn VisibleIndex="26" ReadOnly="true" Caption="Matricula" FieldName="Matricula" Visible="false"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataSpinEditColumn VisibleIndex="27" ReadOnly="true" Caption="Nota ID" FieldName="NotaID" Visible="false">
                                    <PropertiesSpinEdit SpinButtons-ShowIncrementButtons="false"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataTextColumn VisibleIndex="28" ReadOnly="true" Caption="Observaciones" FieldName="Observaciones" Visible="false"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataSpinEditColumn VisibleIndex="29" ReadOnly="true" Caption="Pais Id" FieldName="PaisId" Visible="false">
                                    <PropertiesSpinEdit SpinButtons-ShowIncrementButtons="false"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataTextColumn VisibleIndex="30" ReadOnly="true" Caption="Pais Nom." FieldName="PaisNom" Visible="true"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataSpinEditColumn VisibleIndex="31" ReadOnly="true" Caption="Pedido ID" FieldName="PedidoID" Visible="false">
                                    <PropertiesSpinEdit SpinButtons-ShowIncrementButtons="false"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataTextColumn VisibleIndex="32" ReadOnly="true" Caption="Pob. Envio" FieldName="Pob_Envio" Visible="true"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataSpinEditColumn VisibleIndex="33" ReadOnly="true" Caption="Pos Pedido" FieldName="PosPedidoID" Visible="false">
                                    <PropertiesSpinEdit SpinButtons-ShowIncrementButtons="false"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataSpinEditColumn VisibleIndex="34" ReadOnly="true" Caption="Producto Id" FieldName="ProductoId" Visible="false">
                                    <PropertiesSpinEdit SpinButtons-ShowIncrementButtons="false"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                                <dx:GridViewDataTextColumn VisibleIndex="35" ReadOnly="true" Caption="Remolque" FieldName="Remolque" Visible="true"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataSpinEditColumn VisibleIndex="36" ReadOnly="true" Caption="Reserva Mat" FieldName="ReservaMat" Visible="false">
                                    <PropertiesSpinEdit SpinButtons-ShowIncrementButtons="false"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>

                                <dx:GridViewDataTextColumn VisibleIndex="38" ReadOnly="true" Caption="Tipo Trans." FieldName="TipoTransNom" Visible="true"></dx:GridViewDataTextColumn>

                                <dx:GridViewDataSpinEditColumn VisibleIndex="40" ReadOnly="true" Caption="Transportista ID" FieldName="TransportistaID" Visible="false">
                                    <PropertiesSpinEdit SpinButtons-ShowIncrementButtons="false"></PropertiesSpinEdit>
                                </dx:GridViewDataSpinEditColumn>
                            </Columns>
                            <SettingsPager PageSize="50" NumericButtonCount="50"></SettingsPager>
                              <SettingsBehavior EnableCustomizationWindow="true" />
                        </dx:ASPxGridView>
                    </ContentTemplate>
                </asp:UpdatePanel>


            </div>
        </section>

        <dx:ASPxLoadingPanel ID="LoadingPanel" runat="server" ClientInstanceName="LoadingPanel" Modal="true" />
    </form>

</body>
</html>
