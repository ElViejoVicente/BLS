<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HistoricoCambios.aspx.cs" Inherits="BLS.Web.Bitacora.HistoricoCambios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../Content/all.css" />
    <link rel="stylesheet" href="../Content/generic/pageMinimalStyle.css" />
    <script src="../Scripts/sweetalert2.all.min.js"></script>
    <link rel="stylesheet" href="../Scripts/sweetalert2.min.css"/>
    <script src="../Scripts/mensajes.js"></script>
    <title>SGN</title>
    <script type="text/javascript">

        /* Script de funcionalidad de la pagina OJO solo colocar en este bloque */
        window.onresize = function (event) {
            AdjustSize();
        };

        function OnInit(s, e) {
            s.GetWindowElement(-1).className += " popupStyle";
        }
        function AdjustSize() {


            var topPanelEl = document.getElementById('TopPanel');
            if (!topPanelEl) {
                // try selector by css class (the control has CssClass="topPanel")
                topPanelEl = document.querySelector('.topPanel');
            }
            // try using client object if available (DevExpress ASPxPanel exposes GetMainElement)
            if (!topPanelEl && typeof TopPanel !== 'undefined' && TopPanel.GetMainElement) {
                topPanelEl = TopPanel.GetMainElement();
            }



            var BottomPanelEL = document.getElementById('BottomPanel');
            if (!BottomPanelEL) {
                // try selector by css class (the control has CssClass="topPanel")
                BottomPanelEL = document.querySelector('.bottomPanel');
            }
            // try using client object if available (DevExpress ASPxPanel exposes GetMainElement)
            if (!BottomPanelEL && typeof BottomPanel !== 'undefined' && BottomPanelEL.GetMainElement) {
                BottomPanelEL = BottomPanel.GetMainElement();
            }



            var bootHeight = 0;
            if (BottomPanelEL) {
                bootHeight = (BottomPanelEL.offsetHeight || BottomPanelEL.clientHeight || 0);
            }

            var topHeight = 0;
            if (topPanelEl) {
                topHeight = (topPanelEl.offsetHeight || topPanelEl.clientHeight || 0);
            }



            var height = document.getElementById('maindiv').clientHeight - topHeight - bootHeight;  // I have some buttons below the grid so needed -50

            gvHistoricoCambios.SetHeight(height);

        }


        function gridView_EndCallback(s, e) {

            if (s.cp_swMsg != null) {
                mostrarMensajeSweet(s.cp_swType, s.cp_swMsg);
                s.cp_swType = null;
                s.cp_swMsg = null;
            }

            //validar con un parametro si es necesario el refreco de los datos

            if (s.cp_Update != null) {

                gvHistoricoCambios.UnselectRows();
                gvHistoricoCambios.PerformCallback('CargarRegistros');
                s.cp_Update = null;
            }
        }

        function CerrarModalyVerAlertas(s, e) {

            // cbListaMatFleje.PerformCallback();

            if (s.cp_swType != null && s.cp_swAlert == null) {

                ppNuevaHojaDatos.Hide();


                mostrarMensajeSweet(s.cp_swType, s.cp_swMsg);
                gvHistoricoCambios.PerformCallback('CargarRegistros');
                s.cp_swType = null;
                s.cp_swMsg = null;
                s.cp_swAlert = null;
            }
            else {

                mostrarMensajeSweet(s.cp_swType, s.cp_swMsg);
                s.cp_swType = null;
                s.cp_swMsg = null;
                s.cp_swAlert = null;
            }
        }
        function AdjustStylePopUp(s, e) {

            s.GetWindowElement(-1).className += " popupStyle";
        }

        function OnToolbarItemClick(s, e) {

            switch (e.item.name) {

                case "CustomExportToXLS":
                    e.processOnServer = true;
                    e.usePostBack = true;
                    break;
                case "CustomExportToXLSX":
                    e.processOnServer = true;
                    e.usePostBack = true;
                    break;

            }
        }


    </script>

</head>
<body>
    <form id="frmPage" runat="server" class="Principal">
        <dx:ASPxPanel ID="TopPanel" runat="server" FixedPosition="WindowTop" FixedPositionOverlap="true" CssClass="topPanel">
            <PanelCollection>
                <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                    <table>
                        <tr>
                            <td>
                                <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" ShowCollapseButton="true" Width="170px" HeaderText="Folio de Operacion/Expediente:" View="GroupBox">
                                    <PanelCollection>
                                        <dx:PanelContent>

                                            <div style="display: flex; gap: 10px; align-items: flex-end; flex-wrap: nowrap;">
                                                <dx:ASPxTextBox runat="server" ID="txtNumExpdiente" AutoPostBack="false">
                                                    <ValidationSettings ValidationGroup="requerido" SetFocusOnError="true" ErrorDisplayMode="ImageWithTooltip">
                                                        <RequiredField IsRequired="true" ErrorText="Campo obligatorio" />
                                                    </ValidationSettings>

                                                </dx:ASPxTextBox>

                                                <dx:ASPxButton ID="btnActualizar" runat="server" Image-IconID="xaf_action_reload_svg_16x16" Text="Actualizar" AutoPostBack="false" Enabled="true">
                                                    <ClientSideEvents Click="function(s, e) {  gvHistoricoCambios.PerformCallback('CargarRegistros'); }" />
                                                </dx:ASPxButton>

                                            </div>

                                        </dx:PanelContent>
                                    </PanelCollection>
                                </dx:ASPxRoundPanel>
                            </td>
                        </tr>
                    </table>
                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxPanel>



        <section class="CLPageContent" id="maindiv">
            <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="gvHistoricoCambios"></dx:ASPxGridViewExporter>

            <dx:ASPxHiddenField runat="server" ID="HidDocumentoSelect" ClientInstanceName="HidDocumentoSelect"></dx:ASPxHiddenField>

            <dx:ASPxGridView runat="server" ID="gvHistoricoCambios" ClientInstanceName="gvHistoricoCambios" AutoGenerateColumns="False" Width="100%" KeyFieldName="IdRegistro"
                OnDataBinding="gvHistoricoCambios_DataBinding"
                OnCustomCallback="gvHistoricoCambios_CustomCallback"
                OnToolbarItemClick="gvHistoricoCambios_ToolbarItemClick">

                <ClientSideEvents Init="AdjustSize" EndCallback="gridView_EndCallback" />

                <ClientSideEvents ToolbarItemClick="OnToolbarItemClick" />


                <SettingsPager Mode="ShowPager" PageSize="100" />

                <Settings ShowFooter="True" ShowFilterRow="true" ShowFilterBar="Auto" ShowFilterRowMenu="True" ShowHeaderFilterButton="True" ShowGroupPanel="True" VerticalScrollBarMode="Auto" HorizontalScrollBarMode="Auto" />

                <%--                <SettingsCookies Enabled="true" />--%>

                <SettingsResizing ColumnResizeMode="Control" />


                <SettingsDetail ExportMode="Expanded" ShowDetailRow="false" />

                <SettingsBehavior
                    AllowGroup="true"
                    AllowDragDrop="true"
                    AllowFixedGroups="false"
                    AllowSelectByRowClick="true"
                    AllowSelectSingleRowOnly="true"
                    AutoExpandAllGroups="true"
                    AllowFocusedRow="True"
                    ProcessFocusedRowChangedOnServer="False"
                    AllowSort="true"
                    ConfirmDelete="true"
                    EnableCustomizationWindow="true"></SettingsBehavior>

                <SettingsCommandButton>
                    <EditButton Text="" ButtonType="Image">
                        <Image ToolTip="Editar" IconID="edit_edit_16x16"></Image>
                    </EditButton>

                    <DeleteButton Text="" ButtonType="Image">
                        <Image ToolTip="Eliminar Fabricacion" IconID="edit_delete_16x16"></Image>
                    </DeleteButton>
                </SettingsCommandButton>

                <Styles>
                    <AlternatingRow Enabled="true" />
                    <SelectedRow BackColor="#0066ff"></SelectedRow>
                </Styles>

                <SettingsDataSecurity AllowInsert="false" AllowDelete="false" AllowEdit="false" />
                <SettingsSearchPanel Visible="true" />
                <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="DataAware" />

                <Columns>


                    <dx:GridViewDataTextColumn VisibleIndex="1" Caption="Num Registro" FieldName="IdRegistro" Width="90px" Visible="true">
                        <EditFormSettings Visible="False"></EditFormSettings>
                    </dx:GridViewDataTextColumn>


                    <dx:GridViewDataTextColumn VisibleIndex="2" Caption="Usuario" FieldName="UsuarioImplicado" Width="200px" Visible="true" GroupIndex="1">
                        <EditFormSettings Visible="False"></EditFormSettings>
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="3" Caption="Expediente" FieldName="IdExpediente" Width="100px" Visible="true">
                        <EditFormSettings Visible="False"></EditFormSettings>
                    </dx:GridViewDataTextColumn>


                    <dx:GridViewDataTextColumn VisibleIndex="4" Caption="Nombre del Campo" FieldName="NombreCampo" Width="350px" Visible="true">
                        <EditFormSettings Visible="False"></EditFormSettings>
                    </dx:GridViewDataTextColumn>


                    <dx:GridViewDataTextColumn VisibleIndex="5" Caption="Valor Original" FieldName="ValorOriginal" Width="200px" Visible="true">
                        <EditFormSettings Visible="False"></EditFormSettings>
                    </dx:GridViewDataTextColumn>


                    <dx:GridViewDataTextColumn VisibleIndex="6" Caption="Valor Imputado" FieldName="ValorImputado" Width="200px" Visible="true">
                        <EditFormSettings Visible="False"></EditFormSettings>
                    </dx:GridViewDataTextColumn>


                    <dx:GridViewDataTextColumn VisibleIndex="7" Caption="Modulo" FieldName="NombreModulo" Width="100px" Visible="true">
                        <EditFormSettings Visible="False"></EditFormSettings>
                    </dx:GridViewDataTextColumn>


                    <dx:GridViewDataDateColumn PropertiesDateEdit-DisplayFormatString="dd/MM/yyyy hh:mm tt" VisibleIndex="8" Caption="Fecha Imputacion" FieldName="FechaImputacion" Width="150px" Visible="true">
                        <EditFormSettings Visible="False"></EditFormSettings>
                    </dx:GridViewDataDateColumn>



                    <%--  columnas datos generales de la hoja de datos--%>
                </Columns>


                <Toolbars>
                    <dx:GridViewToolbar>
                        <Items>


                            <dx:GridViewToolbarItem Command="ShowCustomizationWindow" Alignment="Right" />
                            <dx:GridViewToolbarItem Text="Export to" Image-IconID="actions_download_16x16office2013" BeginGroup="true" AdaptivePriority="1" Alignment="Right">
                                <Items>
                                    <dx:GridViewToolbarItem Command="ExportToPdf" />
                                    <dx:GridViewToolbarItem Command="ExportToDocx" />
                                    <dx:GridViewToolbarItem Command="ExportToRtf" />
                                    <dx:GridViewToolbarItem Command="ExportToCsv" />
                                    <dx:GridViewToolbarItem Command="ExportToXls" Text="Export to XLS(DataAware)" />
                                    <dx:GridViewToolbarItem Name="CustomExportToXLS" Text="Export to XLS(WYSIWYG)" Image-IconID="export_exporttoxls_16x16office2013">
                                        <Image IconID="export_exporttoxls_16x16office2013"></Image>
                                    </dx:GridViewToolbarItem>
                                    <dx:GridViewToolbarItem Command="ExportToXlsx" Text="Export to XLSX(DataAware)" />
                                    <dx:GridViewToolbarItem Name="CustomExportToXLSX" Text="Export to XLSX(WYSIWYG)" Image-IconID="export_exporttoxlsx_16x16office2013">
                                        <Image IconID="export_exporttoxlsx_16x16office2013"></Image>
                                    </dx:GridViewToolbarItem>
                                </Items>

                                <Image IconID="actions_download_16x16office2013"></Image>
                            </dx:GridViewToolbarItem>

                        </Items>

                        <SettingsAdaptivity Enabled="True" EnableCollapseRootItemsToIcons="True"></SettingsAdaptivity>
                    </dx:GridViewToolbar>
                </Toolbars>


            </dx:ASPxGridView>




        </section>


    </form>
</body>
</html>
