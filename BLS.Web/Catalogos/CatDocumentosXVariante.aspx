<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CatDocumentosXVariante.aspx.cs" Inherits="BLS.Web.Catalogos.CatDocumentosXVariante" %>

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

            var topHeight = 0;
            if (topPanelEl) {
                topHeight = (topPanelEl.offsetHeight || topPanelEl.clientHeight || 0);
            }

            var height = document.getElementById('maindiv').clientHeight - topHeight;  // I have some buttons below the grid so needed -50

            gvDocumentosXvariente.SetHeight(height);

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

        function gridView_EndCallback(s, e) {

            if (s.cp_swMsg != null) {
                mostrarMensajeSweet(s.cp_swType, s.cp_swMsg);
                s.cp_swType = null;
                s.cp_swMsg = null;
            }

            //validar con un parametro si es necesario el refreco de los datos

            if (s.cp_Update != null) {

                gvDocumentosXvariente.UnselectRows();
                gvDocumentosXvariente.PerformCallback('CargarRegistros~' + cbActos.GetSelectedItem().text + '~' + cbVarientes.GetSelectedItem().text);
                s.cp_Update = null;
            }
        }

    </script>

</head>
<body>
    <form id="form1" runat="server" class="Principal">
        <dx:ASPxPanel ID="TopPanel" ClientInstanceName="TopPanel" runat="server" FixedPosition="WindowTop" FixedPositionOverlap="true" CssClass="topPanel">
            <PanelCollection>
                <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                    <table>
                        <tr>
                            <td>
                                <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" ShowCollapseButton="true" Width="600px" HeaderText="Opciones de consulta:" View="GroupBox">
                                    <PanelCollection>
                                        <dx:PanelContent>

                                            <div style="display: flex; gap: 10px; align-items: flex-end; flex-wrap: nowrap;">

                                                <dx:ASPxComboBox runat="server" ID="cbActos"
                                                    ClientInstanceName="cbActos"
                                                    Width="200px"
                                                    AutoPostBack="true"
                                                    OnDataBinding="cbActos_DataBinding"
                                                    Caption="Actos:"
                                                    EnableMultiColumn="false"
                                                    DropDownStyle="DropDownList"
                                                    SelectInputTextOnClick="true"
                                                    IncrementalFilteringMode="None"
                                                    EnableCallbackMode="true"
                                                    SelectedIndex="-1"
                                                    OnSelectedIndexChanged="cbActos_SelectedIndexChanged">
                                                </dx:ASPxComboBox>

                                                <dx:ASPxComboBox runat="server" ID="cbVarientes"
                                                    ClientInstanceName="cbVarientes"
                                                    Width="200px"
                                                    AutoPostBack="false"
                                                    OnDataBinding="cbVarientes_DataBinding"
                                                    Caption="Varientes:"
                                                    EnableMultiColumn="false"
                                                    ClientEnabled="false"
                                                    DropDownStyle="DropDownList"
                                                    SelectInputTextOnClick="true"
                                                    IncrementalFilteringMode="None"
                                                    EnableCallbackMode="true"
                                                    SelectedIndex="-1">
                                                    <ClientSideEvents SelectedIndexChanged=" function(s, e) {  gvDocumentosXvariente.PerformCallback('CargarRegistros~' + cbActos.GetSelectedItem().text +'~'+ s.GetSelectedItem().text  );    }" />
                                                </dx:ASPxComboBox>

                                                <dx:ASPxButton ID="btnActualizar" runat="server" Image-IconID="xaf_action_reload_svg_16x16" Text="Actualizar" AutoPostBack="false" Enabled="true">
                                                    <ClientSideEvents Click="function(s, e) { gvDocumentosXvariente.PerformCallback('CargarRegistros~' + cbActos.GetSelectedItem().text +'~'+ cbVarientes.GetSelectedItem().text  );    }" />
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
            <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="gvDocumentosXvariente"></dx:ASPxGridViewExporter>

            <dx:ASPxGridView runat="server" ID="gvDocumentosXvariente" ClientInstanceName="gvDocumentosXvariente" AutoGenerateColumns="False" Width="100%" KeyFieldName="IdDoc"
                OnDataBinding="gvDocumentosXvariente_DataBinding"
                OnRowInserting="gvDocumentosXvariente_RowInserting"
                OnRowUpdating="gvDocumentosXvariente_RowUpdating"
                OnRowValidating="gvDocumentosXvariente_RowValidating"
                OnRowDeleting="gvDocumentosXvariente_RowDeleting"
                OnToolbarItemClick="gvDocumentosXvariente_ToolbarItemClick"
                OnCustomCallback="gvDocumentosXvariente_CustomCallback">

                <ClientSideEvents Init="AdjustSize" />

                <ClientSideEvents ToolbarItemClick="OnToolbarItemClick" EndCallback="gridView_EndCallback" />


                <SettingsPager Mode="ShowAllRecords" />

                <Settings ShowFooter="True" ShowFilterRow="false"
                    ShowFilterBar="Auto" ShowFilterRowMenu="false"
                    ShowHeaderFilterButton="True" ShowGroupPanel="false"
                    VerticalScrollBarMode="Auto" HorizontalScrollBarMode="Auto" />

                <SettingsResizing ColumnResizeMode="Control" />

                <SettingsEditing Mode="EditForm" />

                <SettingsPager Mode="ShowPager" PageSize="100" />

                <SettingsDetail ExportMode="All" ShowDetailRow="false" />

                <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="DataAware" />

                <SettingsBehavior
                    AllowGroup="true"
                    AllowDragDrop="false"
                    AllowFixedGroups="false"
                    AllowSelectByRowClick="true"
                    AllowSelectSingleRowOnly="false"
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


                <SettingsDataSecurity AllowInsert="true" AllowDelete="true" AllowEdit="true" />
                <SettingsSearchPanel Visible="true" />

                <Columns>

                    <dx:GridViewCommandColumn Visible="true" VisibleIndex="1" ShowNewButton="false" ShowEditButton="true" ShowDeleteButton="true" ShowNewButtonInHeader="true" ButtonRenderMode="Button" Width="50px"></dx:GridViewCommandColumn>

                    <dx:GridViewDataComboBoxColumn Visible="true" VisibleIndex="2" Caption="Rol" FieldName="TextoFigura" Width="150" GroupIndex="0">
                        <PropertiesComboBox>
                            <Items>
                                <dx:ListEditItem Text="Otorga o Solicita" Value="Otorga o Solicita" />
                                <dx:ListEditItem Text="A favor de" Value="A favor de" />
                            </Items>
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>


                    <dx:GridViewDataTextColumn Visible="true" VisibleIndex="3" Caption="Documento" FieldName="TextoDocumento" Width="300px">
                    </dx:GridViewDataTextColumn>


                    <dx:GridViewDataMemoColumn Visible="true" VisibleIndex="4" Caption="Descripcion" FieldName="Descripcion" Width="450px">
                    </dx:GridViewDataMemoColumn>

                    <dx:GridViewDataCheckColumn Visible="true" VisibleIndex="5" Caption="Requiere copia" FieldName="CopiaRequerida" Width="150px"></dx:GridViewDataCheckColumn>


                    <dx:GridViewDataCheckColumn Visible="true" VisibleIndex="6" Caption="Activo" FieldName="Activo" Width="100px">
                    </dx:GridViewDataCheckColumn>


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
