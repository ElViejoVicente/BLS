<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PanelInventario.aspx.cs" Inherits="BLS.Web.Inventarios.PanelInventario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../Content/all.css" />
    <link rel="stylesheet" href="../Content/generic/pageMinimalStyle.css" />

    <script src="../Scripts/sweetalert2.all.min.js"></script>
    <link rel="stylesheet" href="../Scripts/sweetalert2.min.css"/>
    <script src="../Scripts/mensajes.js"></script>


    <script type="text/javascript">

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


            var height = document.getElementById('maindiv').clientHeight -  topHeight - bootHeight;  // I have some buttons below the grid so needed -50

            gvInventario.SetHeight(height);

            //  console.log(height);

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




    <title>SGN</title>

</head>
<body>
    <form id="frmPage" runat="server" class="Principal">

        <dx:ASPxPanel ID="TopPanel" ClientInstanceName="TopPanel" runat="server" FixedPosition="WindowTop" FixedPositionOverlap="true" CssClass="topPanel">
            <PanelCollection>
                <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                    <table>
                        <tr>
                            <td>
                                <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" ShowCollapseButton="true" Width="170px" HeaderText="Opciones de Consulta" View="GroupBox">
                                    <PanelCollection>
                                        <dx:PanelContent>

                                            <div style="display: flex; gap: 10px; align-items: flex-end; flex-wrap: nowrap;">

                                                <dx:ASPxDateEdit Caption="Fecha De Alta" runat="server" ID="dtFechaAlta" ClientInstanceName="dtFechaAlta" ClientEnabled="false"
                                                    DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy" AutoPostBack="false" />

                                                <dx:ASPxCheckBox runat="server" ID="chkBusquedaCompleta" Width="150px" ClientInstanceName="chkBusquedaCompleta"
                                                    Text="Todas las fechas" ToggleSwitchDisplayMode="Always" Checked="true">
                                                    <ClientSideEvents CheckedChanged="function(s, e) {
                                                                                            if (chkBusquedaCompleta.GetChecked()) {
                                                                                                dtFechaAlta.SetEnabled(false);
                                                                                            } else {
                                                                                                dtFechaAlta.SetEnabled(true);
                                                                                            }
                                                                                        }" />
                                                </dx:ASPxCheckBox>

                                                <dx:ASPxCheckBox runat="server" ID="chkSoloInventarioActivo" Width="250px" ClientInstanceName="chkSoloInventarioActivo"
                                                    Text="Mostrar solo inventario activo" ToggleSwitchDisplayMode="Always" Checked="true" />

                                                <dx:ASPxButton ID="btnActualizar" runat="server" Image-IconID="xaf_action_reload_svg_16x16" Text="Actualizar"
                                                    AutoPostBack="false" Enabled="true">
                                                    <ClientSideEvents Click="function(s, e) { gvInventario.PerformCallback('CargarLista'); }" />
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

            <dx:ASPxGridViewExporter ID="gridExporter" runat="server" GridViewID="gvInventario" />

            <dx:ASPxGridView ID="gvInventario" ClientInstanceName="gvInventario" runat="server" AutoGenerateColumns="False" Width="100%" KeyFieldName="IdInventario"
                OnDataBinding="gvInventario_DataBinding"
                OnRowInserting="gvInventario_RowInserting"
                OnRowUpdating="gvInventario_RowUpdating"
                OnRowValidating="gvInventario_RowValidating"
                OnToolbarItemClick="gvInventario_ToolbarItemClick"
                OnCustomCallback="gvInventario_CustomCallback">

                <ClientSideEvents Init="AdjustSize" />

                <ClientSideEvents ToolbarItemClick="OnToolbarItemClick" />

                <SettingsPager Mode="ShowAllRecords" />

                <Settings ShowFooter="True" ShowFilterRow="True"
                    ShowFilterBar="Auto" ShowFilterRowMenu="True"
                    ShowHeaderFilterButton="True" ShowGroupPanel="True"
                    VerticalScrollBarMode="Auto" HorizontalScrollBarMode="Auto" />

                <SettingsResizing ColumnResizeMode="Control" />


                <SettingsEditing Mode="PopupEditForm" />

                <SettingsPopup>
                    <EditForm HorizontalAlign="WindowCenter" VerticalAlign="WindowCenter" Modal="true">
                    </EditForm>

                </SettingsPopup>

                <SettingsPager Mode="ShowPager" PageSize="100" />

                <SettingsDetail ExportMode="All" ShowDetailRow="false" />

                <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="DataAware" />


                <SettingsCommandButton>
                    <EditButton Text="" ButtonType="Image">
                        <Image ToolTip="Editar" IconID="edit_edit_16x16"></Image>
                    </EditButton>

                    <DeleteButton Text="" ButtonType="Image">
                        <Image ToolTip="Eliminar" IconID="edit_delete_16x16"></Image>
                    </DeleteButton>

                    <NewButton Text="" ButtonType="Image">
                        <Image ToolTip="Nuevo" IconID="actions_add_16x16"></Image>
                    </NewButton>

                    <UpdateButton Text="" ButtonType="Image">


                        <Image ToolTip="Aceptar" IconID="actions_apply_16x16"></Image>
                    </UpdateButton>

                    <CancelButton Text="" ButtonType="Image">
                        <Image ToolTip="Cancelar" IconID="actions_cancel_16x16"></Image>
                    </CancelButton>

                </SettingsCommandButton>





                <SettingsBehavior
                    AllowGroup="true"
                    AllowDragDrop="true"
                    AllowFixedGroups="false"
                    AllowSelectByRowClick="true"
                    AllowSelectSingleRowOnly="false"
                    AutoExpandAllGroups="true"
                    AllowFocusedRow="True"
                    ProcessFocusedRowChangedOnServer="False"
                    AllowSort="true"
                    ConfirmDelete="true"
                    EnableCustomizationWindow="true"></SettingsBehavior>

                <SettingsDataSecurity AllowInsert="true" AllowDelete="false" AllowEdit="true" />
                <SettingsSearchPanel Visible="true" />


                <Columns>
                    <dx:GridViewCommandColumn Visible="true" VisibleIndex="1" ShowNewButton="false" ShowEditButton="true" ShowDeleteButton="false" ShowNewButtonInHeader="true" ButtonRenderMode="Button" Width="50px"></dx:GridViewCommandColumn>


                    <dx:GridViewDataTextColumn FieldName="IdInventario" Caption="#" Width="50px" VisibleIndex="2">
                        <EditFormSettings Visible="false" />
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataComboBoxColumn VisibleIndex="3" FieldName="TipoInventario" Name="TipoInventario" Caption="Tipo Inventario" Width="150px" GroupIndex="0">
                        <EditItemTemplate>
                            <dx:ASPxComboBox ID="cbTipoInventario" ClientInstanceName="cbTipoInventario" Value='<%# Bind("TipoInventario") %>' runat="server" AutoPostBack="false"
                                OnInit="cbTipoInventario_Init" Width="100%">
                            </dx:ASPxComboBox>
                        </EditItemTemplate>
                    </dx:GridViewDataComboBoxColumn>

                    <dx:GridViewDataTextColumn FieldName="Modelo" Caption="Modelo" VisibleIndex="4" Width="100px" />
                    <dx:GridViewDataTextColumn FieldName="Marca" Caption="Marca" VisibleIndex="5" Width="100px" />
                    <dx:GridViewDataTextColumn FieldName="Nombre" Caption="Nombre del Articulo" VisibleIndex="6" Width=" 200px" />
                    <dx:GridViewDataTextColumn FieldName="NumeroSerie" Caption="Serie del Articulo" VisibleIndex="6" Width=" 200px" />

                    <dx:GridViewDataDateColumn FieldName="FechaAlta" Caption="Fecha Alta" PropertiesDateEdit-DisplayFormatString="dd/MM/yyyy" VisibleIndex="7" Width="90px" />
                    <dx:GridViewDataDateColumn FieldName="FechaBaja" Caption="Fecha Baja" PropertiesDateEdit-DisplayFormatString="dd/MM/yyyy" VisibleIndex="8" Width="90px" />
                    <dx:GridViewDataTextColumn FieldName="ValorCompra" Caption="Valor" PropertiesTextEdit-DisplayFormatString="c2" VisibleIndex="9" Width="90px" />


                    <dx:GridViewDataComboBoxColumn VisibleIndex="10" FieldName="AreaOficina" Name="AreaOficina" Caption="Área/Oficina" Width="150px">
                        <EditItemTemplate>
                            <dx:ASPxComboBox ID="cbAreaOficina" ClientInstanceName="cbAreaOficina" Value='<%# Bind("AreaOficina") %>' runat="server" AutoPostBack="false"
                                OnInit="cbAreaOficina_Init" Width="100%">
                            </dx:ASPxComboBox>
                        </EditItemTemplate>
                    </dx:GridViewDataComboBoxColumn>



                    <dx:GridViewDataTextColumn FieldName="Responsable" Caption="Nombre del Responsable" VisibleIndex="11" Width="200px" />
                    <dx:GridViewDataDateColumn FieldName="FechaAsignacion" Caption="Asignación" PropertiesDateEdit-DisplayFormatString="dd/MM/yyyy" VisibleIndex="12" Width="100px" />
                    <dx:GridViewDataCheckColumn FieldName="Activo" Caption="Activo" VisibleIndex="13" Width="60px" />
                    <dx:GridViewDataTextColumn FieldName="Observaciones" Caption="Observaciones" VisibleIndex="14" Width="250px" />
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


