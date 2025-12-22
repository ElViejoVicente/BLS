<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HojaDeDatos.aspx.cs" Inherits="BLS.Web.ExpedientesTramites.HojaDeDatos" %>

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
            var width = document.getElementById('maindiv').clientWidth;
            gvHojaDatos.SetHeight(height);

        }


        function gridView_EndCallback(s, e) {

            if (s.cp_swMsg != null) {
                mostrarMensajeSweet(s.cp_swType, s.cp_swMsg);
                s.cp_swType = null;
                s.cp_swMsg = null;
            }

            //validar con un parametro si es necesario el refreco de los datos

            if (s.cp_Update != null) {

                gvHojaDatos.UnselectRows();
                gvHojaDatos.PerformCallback('CargarRegistros');
                s.cp_Update = null;
            }
        }

        function CerrarModalyVerAlertas(s, e) {

            // cbListaMatFleje.PerformCallback();

            if (s.cp_swType != null && s.cp_swAlert == null) {

                ppNuevaHojaDatos.Hide();


                mostrarMensajeSweet(s.cp_swType, s.cp_swMsg);
                gvHojaDatos.PerformCallback('CargarRegistros');
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


                case "cmdNuevaHojaDatos": // Esta opracion ya noes valida en este modulo ya que la informacion inicial (alta) partira de la hoja de datos

                    ppNuevaHojaDatos.Show();
                    ppNuevaHojaDatos.PerformCallback("NuevaHojaDatos");

                    break;


                case "cmdEditarHojaDatos":

                    if (gvHojaDatos.GetFocusedRowIndex() >= 0) {

                        gvHojaDatos.GetRowValues(gvHojaDatos.GetFocusedRowIndex(), 'IdHojaDatos', onCallbackEditarHoja);
                    }


                    break;

                case "cmdReporteHojaDatos":
                    if (gvHojaDatos.GetFocusedRowIndex() >= 0) {
                        gvHojaDatos.GetRowValues(gvHojaDatos.GetFocusedRowIndex(), 'IdHojaDatos', onCallbackReport);
                    }
                    break;


            }
        }

        function onCallbackReport(value) {

            window.open("../Reportes/reporteHojaDatos?idHojaDatos=" + value, "_blank");
        }

        function onCallbackEditarHoja(value) {

            ppNuevaHojaDatos.Show();
            ppNuevaHojaDatos.PerformCallback("EditarHojaDatos~" + value);
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
                                <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" ShowCollapseButton="true" Width="170px" HeaderText="Opciones de consulta:" View="GroupBox">
                                    <PanelCollection>
                                        <dx:PanelContent>

                                            <div style="display: flex; gap: 10px; align-items: flex-end; flex-wrap: nowrap;">

                                                <dx:ASPxDateEdit Caption="Inicio" runat="server" ID="dtFechaInicio" ClientInstanceName="dtFechaInicio" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy" AutoPostBack="false">
                                                </dx:ASPxDateEdit>

                                                <dx:ASPxDateEdit Caption="Fin" runat="server" ID="dtFechaFin" ClientInstanceName="dtFechaFin" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy" AutoPostBack="false">
                                                </dx:ASPxDateEdit>

                                                <dx:ASPxCheckBox runat="server" ID="chkBusquedaCompleta" Width="150px" ClientInstanceName="chkBusquedaCompleta" Text="Todas las fechas" ToggleSwitchDisplayMode="Always">
                                                    <ClientSideEvents CheckedChanged="function(s, e) {  
                                                                         if (chkBusquedaCompleta.GetChecked()) 
                                                                         {
                                                                         dtFechaInicio.SetEnabled(false);
                                                                         dtFechaFin.SetEnabled(false);
                                                                         }
                                                                         else
                                                                         {
                                                                         dtFechaInicio.SetEnabled(true);
                                                                         dtFechaFin.SetEnabled(true);
                                                                         }                }" />
                                                </dx:ASPxCheckBox>

                                                <dx:ASPxButton ID="btnActualizar" runat="server" Image-IconID="xaf_action_reload_svg_16x16" Text="Actualizar" AutoPostBack="false" Enabled="true">
                                                    <ClientSideEvents Click="function(s, e) {  gvHojaDatos.PerformCallback('CargarRegistros'); }" />
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
            <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="gvHojaDatos"></dx:ASPxGridViewExporter>

            <dx:ASPxHiddenField runat="server" ID="HidDocumentoSelect" ClientInstanceName="HidDocumentoSelect"></dx:ASPxHiddenField>

            <dx:ASPxGridView runat="server" ID="gvHojaDatos" ClientInstanceName="gvHojaDatos" AutoGenerateColumns="False" Width="100%" KeyFieldName="IdHojaDatos"
                OnDataBinding="gvHojaDatos_DataBinding"
                OnCustomCallback="gvHojaDatos_CustomCallback"
                OnToolbarItemClick="gvHojaDatos_ToolbarItemClick" OnHtmlDataCellPrepared="gvHojaDatos_HtmlDataCellPrepared">

                <ClientSideEvents Init="AdjustSize" EndCallback="gridView_EndCallback" />

                <ClientSideEvents ToolbarItemClick="OnToolbarItemClick" />


                <SettingsPager Mode="ShowPager" PageSize="100" />

                <Settings ShowFooter="True" ShowFilterRow="true" ShowFilterBar="Auto" ShowFilterRowMenu="True" ShowHeaderFilterButton="True" ShowGroupPanel="True" VerticalScrollBarMode="Auto" HorizontalScrollBarMode="Auto" />

                <%--                <SettingsCookies Enabled="true" />--%>

                <SettingsResizing ColumnResizeMode="Control" />


                <SettingsDetail ExportMode="Expanded" ShowDetailRow="true" />

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

                <Styles>
                    <AlternatingRow Enabled="true" />
                    <SelectedRow BackColor="#0066ff"></SelectedRow>
                </Styles>

                <SettingsDataSecurity AllowInsert="false" AllowDelete="false" AllowEdit="false" />
                <SettingsSearchPanel Visible="true" />
                <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="DataAware" />

                <Columns>
                    <dx:GridViewDataTextColumn VisibleIndex="1" Caption="Num hoja datos" FieldName="IdHojaDatos" Width="100px" Visible="false">
                        <EditFormSettings Visible="False"></EditFormSettings>
                    </dx:GridViewDataTextColumn>



                    <dx:GridViewDataTextColumn VisibleIndex="2" Caption="Estatus" FieldName="TextoEstatus" Width="120px" Visible="true">
                        <EditFormSettings Visible="False"></EditFormSettings>
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataDateColumn PropertiesDateEdit-DisplayFormatString="dd/MM/yyyy" VisibleIndex="3" Caption="Fecha ingreso" FieldName="FechaIngreso" Width="120px" Visible="true">
                        <EditFormSettings Visible="False"></EditFormSettings>
                    </dx:GridViewDataDateColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="4" Caption="Num Expediente" FieldName="numExpediente" Width="100px" Visible="true">
                        <EditFormSettings Visible="False"></EditFormSettings>
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="5" Caption="Acto" FieldName="TextoActo" Width="120px" Visible="true">
                        <EditFormSettings Visible="False"></EditFormSettings>
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="6" Caption="Variente" FieldName="TextoVariante" Width="100px" Visible="true">
                        <EditFormSettings Visible="False"></EditFormSettings>
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="7" Caption="Otorga o Solicita" FieldName="Otorga" Width="250px" Visible="true">
                        <EditFormSettings Visible="False"></EditFormSettings>
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="8" Caption="A favor de" FieldName="AfavorDe" Width="250px" Visible="true">
                        <EditFormSettings Visible="False"></EditFormSettings>
                    </dx:GridViewDataTextColumn>


                    <dx:GridViewDataTextColumn VisibleIndex="9" Caption="Asesor" FieldName="NombreAsesor" Width="150px" Visible="true">
                        <EditFormSettings Visible="False"></EditFormSettings>
                    </dx:GridViewDataTextColumn>



                    <dx:GridViewDataTextColumn VisibleIndex="10" Caption="Tramita" FieldName="NumbreUsuarioTramita" Width="150px" Visible="true">
                        <EditFormSettings Visible="False"></EditFormSettings>
                    </dx:GridViewDataTextColumn>


                    <dx:GridViewDataTextColumn VisibleIndex="11" Caption="Telefono" FieldName="NumTelCelular1" Width="100px" Visible="true">
                        <EditFormSettings Visible="False"></EditFormSettings>
                    </dx:GridViewDataTextColumn>



                    <dx:GridViewDataTextColumn VisibleIndex="11" Caption="Correo" FieldName="CorreoElectronico" Width="150px" Visible="false">
                        <EditFormSettings Visible="False"></EditFormSettings>
                    </dx:GridViewDataTextColumn>



                    <%--  columnas datos generales de la hoja de datos--%>
                </Columns>


                <Toolbars>
                    <dx:GridViewToolbar>
                        <Items>





                            <dx:GridViewToolbarItem Text="Nueva hoja datos" Image-IconID="dashboards_new_svg_16x16" Name="cmdNuevaHojaDatos" />

                            <dx:GridViewToolbarItem Text="Editar hoja datos" Image-IconID="dashboards_edit_svg_16x16" Name="cmdEditarHojaDatos" />

                            <dx:GridViewToolbarItem Text="Generar Impresion" Image-IconID="actions_print_16x16devav" Name="cmdReporteHojaDatos" />

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


                <Templates>
                    <DetailRow>
                        <div style="padding: 3px 3px 2px 3px">
                            <dx:ASPxPageControl runat="server" ID="pageControl" Width="100%" EnableCallBacks="true">
                                <TabPages>
                                    <dx:TabPage Text="Otorga o solicitante" Visible="true">
                                        <ContentCollection>
                                            <dx:ContentControl>


                                                <dx:ASPxGridView runat="server"
                                                    ID="gvOtorgaSolictaDetalle"
                                                    ClientInstanceName="gvOtorgaSolictaDetalle"
                                                    KeyFieldName="IdHojaDatos"
                                                    EnablePagingGestures="False"
                                                    AutoGenerateColumns="true"
                                                    OnBeforePerformDataSelect="gvOtorgaSolictaDetalle_BeforePerformDataSelect">
                                                    <SettingsPager PageSize="100" NumericButtonCount="100"></SettingsPager>

                                                    <Settings ShowFooter="false" ShowFilterRow="false" ShowFilterBar="Hidden" ShowFilterRowMenu="false" ShowHeaderFilterButton="false" ShowGroupPanel="false" VerticalScrollBarMode="Auto" HorizontalScrollBarMode="Auto" />


                                                    <SettingsBehavior
                                                        AllowGroup="false"
                                                        AllowDragDrop="false"
                                                        AllowFixedGroups="false"
                                                        AllowSelectByRowClick="true"
                                                        AllowSelectSingleRowOnly="false"
                                                        AutoExpandAllGroups="false"
                                                        AllowFocusedRow="True"
                                                        ProcessFocusedRowChangedOnServer="False"
                                                        AllowSort="false"
                                                        ConfirmDelete="true"
                                                        EnableCustomizationWindow="true"></SettingsBehavior>


                                                    <Columns>

                                                        <%--  columnas Otorga Solicta Detalle --%>


                                                        <dx:GridViewDataTextColumn VisibleIndex="1" Caption="Rol" FieldName="RolOperacion" Width="120px" Visible="true" Settings-AllowSort="False">
                                                            <EditFormSettings Visible="False"></EditFormSettings>
                                                        </dx:GridViewDataTextColumn>

                                                        <dx:GridViewDataTextColumn VisibleIndex="2" Caption="T.Persona" FieldName="TipoRegimen" Width="120px" Visible="true">
                                                            <EditFormSettings Visible="False"></EditFormSettings>
                                                        </dx:GridViewDataTextColumn>

                                                        <dx:GridViewDataTextColumn VisibleIndex="2" Caption="Nombre(s)" FieldName="Nombres" Width="120px" Visible="true">
                                                            <EditFormSettings Visible="False"></EditFormSettings>
                                                        </dx:GridViewDataTextColumn>

                                                        <dx:GridViewDataTextColumn VisibleIndex="3" Caption="Apellido paterno" FieldName="ApellidoPaterno" Width="110px" Visible="true">
                                                            <EditFormSettings Visible="False"></EditFormSettings>
                                                        </dx:GridViewDataTextColumn>

                                                        <dx:GridViewDataTextColumn VisibleIndex="4" Caption="Apellido Materno" FieldName="ApellidoMaterno" Width="110px" Visible="true">
                                                            <EditFormSettings Visible="False"></EditFormSettings>
                                                        </dx:GridViewDataTextColumn>

                                                        <dx:GridViewDataDateColumn PropertiesDateEdit-DisplayFormatString="dd/MM/yyyy" VisibleIndex="5" Caption="Fecha nacimiento" FieldName="FechaNacimiento" Width="100px" Visible="true">
                                                            <EditFormSettings Visible="False"></EditFormSettings>
                                                        </dx:GridViewDataDateColumn>


                                                        <dx:GridViewDataTextColumn VisibleIndex="6" Caption="Sexo" FieldName="Sexo" Width="50px" Visible="true">
                                                            <EditFormSettings Visible="False"></EditFormSettings>
                                                        </dx:GridViewDataTextColumn>


                                                        <dx:GridViewDataTextColumn VisibleIndex="7" Caption="Sabe Leer/escribir " FieldName="SabeLeerEscribir" Width="100px" Visible="true">
                                                            <EditFormSettings Visible="False"></EditFormSettings>
                                                        </dx:GridViewDataTextColumn>

                                                        <dx:GridViewDataTextColumn VisibleIndex="8" Caption="Estado civil" FieldName="EstadoCivil" Width="100px" Visible="true">
                                                            <EditFormSettings Visible="False"></EditFormSettings>
                                                        </dx:GridViewDataTextColumn>


                                                        <dx:GridViewDataTextColumn VisibleIndex="9" Caption="regimen conyugal" FieldName="RegimenConyugal" Width="100px" Visible="true">
                                                            <EditFormSettings Visible="False"></EditFormSettings>
                                                        </dx:GridViewDataTextColumn>


                                                        <dx:GridViewDataTextColumn VisibleIndex="10" Caption="Anotaciones" FieldName="Notas" Width="300px" Visible="true">
                                                            <EditFormSettings Visible="False"></EditFormSettings>
                                                        </dx:GridViewDataTextColumn>



                                                    </Columns>
                                                </dx:ASPxGridView>

                                            </dx:ContentControl>
                                        </ContentCollection>
                                    </dx:TabPage>
                                    <dx:TabPage Text="A favor de " Visible="true">
                                        <ContentCollection>
                                            <dx:ContentControl>


                                                <dx:ASPxGridView runat="server" ID="gvAfavorDeDetalle" ClientInstanceName="gvAfavorDeDetalle" KeyFieldName="IdHojaDatos"
                                                    EnablePagingGestures="False" AutoGenerateColumns="true" OnBeforePerformDataSelect="gvAfavorDeDetalle_BeforePerformDataSelect">
                                                    <SettingsPager PageSize="100" NumericButtonCount="100"></SettingsPager>
                                                    <Columns>

                                                        <%--  columnas Otorga Solicta Detalle --%>


                                                        <dx:GridViewDataTextColumn VisibleIndex="1" Caption="Rol" FieldName="RolOperacion" Width="120px" Visible="true">
                                                            <EditFormSettings Visible="False"></EditFormSettings>
                                                        </dx:GridViewDataTextColumn>

                                                        <dx:GridViewDataTextColumn VisibleIndex="2" Caption="T.Persona" FieldName="TipoRegimen" Width="120px" Visible="true">
                                                            <EditFormSettings Visible="False"></EditFormSettings>
                                                        </dx:GridViewDataTextColumn>

                                                        <dx:GridViewDataTextColumn VisibleIndex="2" Caption="Nombre(s)" FieldName="Nombres" Width="120px" Visible="true">
                                                            <EditFormSettings Visible="False"></EditFormSettings>
                                                        </dx:GridViewDataTextColumn>

                                                        <dx:GridViewDataTextColumn VisibleIndex="3" Caption="Apellido paterno" FieldName="ApellidoPaterno" Width="110px" Visible="true">
                                                            <EditFormSettings Visible="False"></EditFormSettings>
                                                        </dx:GridViewDataTextColumn>

                                                        <dx:GridViewDataTextColumn VisibleIndex="4" Caption="Apellido Materno" FieldName="ApellidoMaterno" Width="110px" Visible="true">
                                                            <EditFormSettings Visible="False"></EditFormSettings>
                                                        </dx:GridViewDataTextColumn>

                                                        <dx:GridViewDataDateColumn PropertiesDateEdit-DisplayFormatString="dd/MM/yyyy" VisibleIndex="5" Caption="Fecha nacimiento" FieldName="FechaNacimiento" Width="100px" Visible="true">
                                                            <EditFormSettings Visible="False"></EditFormSettings>
                                                        </dx:GridViewDataDateColumn>


                                                        <dx:GridViewDataTextColumn VisibleIndex="6" Caption="Sexo" FieldName="Sexo" Width="50px" Visible="true">
                                                            <EditFormSettings Visible="False"></EditFormSettings>
                                                        </dx:GridViewDataTextColumn>


                                                        <dx:GridViewDataTextColumn VisibleIndex="7" Caption="Sabe Leer/escribir " FieldName="SabeLeerEscribir" Width="100px" Visible="true">
                                                            <EditFormSettings Visible="False"></EditFormSettings>
                                                        </dx:GridViewDataTextColumn>

                                                        <dx:GridViewDataTextColumn VisibleIndex="8" Caption="Estado civil" FieldName="EstadoCivil" Width="100px" Visible="true">
                                                            <EditFormSettings Visible="False"></EditFormSettings>
                                                        </dx:GridViewDataTextColumn>


                                                        <dx:GridViewDataTextColumn VisibleIndex="9" Caption="regimen conyugal" FieldName="RegimenConyugal" Width="100px" Visible="true">
                                                            <EditFormSettings Visible="False"></EditFormSettings>
                                                        </dx:GridViewDataTextColumn>


                                                        <dx:GridViewDataTextColumn VisibleIndex="10" Caption="Anotaciones" FieldName="Notas" Width="300px" Visible="true">
                                                            <EditFormSettings Visible="False"></EditFormSettings>
                                                        </dx:GridViewDataTextColumn>



                                                    </Columns>
                                                </dx:ASPxGridView>

                                            </dx:ContentControl>
                                        </ContentCollection>
                                    </dx:TabPage>


                                </TabPages>
                            </dx:ASPxPageControl>
                        </div>
                    </DetailRow>
                </Templates>


            </dx:ASPxGridView>






            <dx:ASPxPopupControl runat="server" ID="ppNuevaHojaDatos" ClientInstanceName="ppNuevaHojaDatos" Height="700px" Width="1300px" EnableClientSideAPI="true" ShowFooter="true"
                PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowResize="false" AllowDragging="true" CloseAction="CloseButton" HeaderText="Nueva hoja de datos"
                PopupAnimationType="Auto" AutoUpdatePosition="true" CloseOnEscape="true" OnWindowCallback="ppNuevaHojaDatos_WindowCallback1" Modal="true" >
                <ClientSideEvents EndCallback="CerrarModalyVerAlertas" Init="AdjustStylePopUp" />
                <ContentCollection>
                    <dx:PopupControlContentControl runat="server">

                        <dx:ASPxFormLayout runat="server" ID="frmNuevaHojaDatos" ClientInstanceName="frmNuevaHojaDatos" ColCount="4" ColumnCount="4" Width="100%">

                            <Items>
                                <dx:LayoutGroup Caption="Operacion" ColCount="4" ColumnCount="4" ColSpan="4" ColumnSpan="4">
                                    <Items>
                                        <dx:LayoutItem FieldName="FechaIngreso" ColSpan="1">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxDateEdit runat="server" ID="dtFechaIngreso" ClientEnabled="false" AutoPostBack="false" DisplayFormatString="dd/MM/yyyy HH:mm">
                                                        <TimeSectionProperties Visible="true"></TimeSectionProperties>
                                                    </dx:ASPxDateEdit>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem FieldName="Acto" ColSpan="1">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxComboBox runat="server" AutoPostBack="false" ID="cbActosNuevo" OnDataBinding="cbActosNuevo_DataBinding">
                                                        <ValidationSettings ValidationGroup="requerido" SetFocusOnError="true" ErrorDisplayMode="ImageWithTooltip">
                                                            <RequiredField IsRequired="true" ErrorText="Campo obligatorio" />
                                                        </ValidationSettings>

                                                        <ClientSideEvents SelectedIndexChanged="function(s, e) 
                                                                                     {     
                                                                                           
                                                                                              ppNuevaHojaDatos.PerformCallback('CargarVariantes~'+ s.GetSelectedItem().value);

                                                                                     }" />
                                                    </dx:ASPxComboBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem FieldName="Variante" ColSpan="1">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxComboBox runat="server" AutoPostBack="false" ID="cbVarienteNuevo" OnDataBinding="cbVarienteNuevo_DataBinding">
                                                        <ValidationSettings ValidationGroup="requerido" SetFocusOnError="true" ErrorDisplayMode="ImageWithTooltip">
                                                            <RequiredField IsRequired="true" ErrorText="Campo obligatorio" />
                                                        </ValidationSettings>
                                                        <ClientSideEvents SelectedIndexChanged="function(s, e) 
                                                                                     {     
                                                                                           
                                                                                              ppNuevaHojaDatos.PerformCallback('CargarDocXvariantes~'+ s.GetSelectedItem().value);

                                                                                     }" />

                                                    </dx:ASPxComboBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem FieldName="Asesor" ColSpan="1">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxTextBox runat="server" ID="txtNombreAsesor" ClientEnabled="false" AutoPostBack="false"></dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem FieldName="NumReciboInicio" ColSpan="1">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxTextBox runat="server" ID="txtReciboPagoIni" AutoPostBack="false">
                                                        <ValidationSettings ValidationGroup="requerido" SetFocusOnError="true" ErrorDisplayMode="ImageWithTooltip">
                                                            <RequiredField IsRequired="true" ErrorText="Campo obligatorio" />
                                                        </ValidationSettings>
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem FieldName="Cliente:" ColSpan="1">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxTextBox runat="server" ID="txtClienteTramita" AutoPostBack="false">
                                                        <ValidationSettings ValidationGroup="requerido" SetFocusOnError="true" ErrorDisplayMode="ImageWithTooltip">
                                                            <RequiredField IsRequired="true" ErrorText="Campo obligatorio" />
                                                        </ValidationSettings>
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem FieldName="NumCelular" ColSpan="1">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxTextBox runat="server" ID="txtNumCelular" AutoPostBack="false">
                                                        <ValidationSettings ValidationGroup="requerido" SetFocusOnError="true" ErrorDisplayMode="ImageWithTooltip">
                                                            <RequiredField IsRequired="true" ErrorText="Campo obligatorio" />
                                                        </ValidationSettings>
                                                        <MaskSettings Mask="0000000000" ErrorText="10 Digitos" />
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem FieldName="Correo" ColSpan="1">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxTextBox runat="server" ID="txtCorreoElectronico" AutoPostBack="false">
                                                        <ValidationSettings ValidationGroup="requerido" SetFocusOnError="true" ErrorDisplayMode="ImageWithTooltip">
                                                            <RequiredField IsRequired="true" ErrorText="Campo obligatorio" />
                                                        </ValidationSettings>
                                                        <ValidationSettings ErrorDisplayMode="ImageWithTooltip">
                                                            <RegularExpression ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorText="e-mail. no valido" />
                                                        </ValidationSettings>
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                                <dx:LayoutGroup Caption="Otorga o solicitante" ColCount="4" ColumnCount="4" ColSpan="3" ColumnSpan="3">
                                    <Items>
                                        <dx:LayoutItem ColSpan="4" ColumnSpan="4" ShowCaption="False">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxGridView runat="server" ID="gvOtorgaSolicita" ClientInstanceName="gvOtorgaSolicita" AutoGenerateColumns="False" Width="933px" KeyFieldName="IdRegistro"
                                                        OnDataBinding="gvOtorgaSolicita_DataBinding"
                                                        OnRowValidating="gvOtorgaSolicita_RowValidating"
                                                        OnRowInserting="gvOtorgaSolicita_RowInserting"
                                                        OnRowDeleting="gvOtorgaSolicita_RowDeleting"
                                                        OnRowUpdating="gvOtorgaSolicita_RowUpdating">

                                                        <SettingsPager Mode="ShowAllRecords" />

                                                        <Settings ShowFooter="True" ShowFilterRow="false"
                                                            ShowFilterBar="Auto" ShowFilterRowMenu="false"
                                                            ShowHeaderFilterButton="True" ShowGroupPanel="false"
                                                            VerticalScrollBarMode="Auto" HorizontalScrollBarMode="Auto" />

                                                        <SettingsResizing ColumnResizeMode="Control" />

                                                        <SettingsEditing Mode="PopupEditForm" />

                                                        <SettingsPopup>
                                                            <EditForm HorizontalAlign="WindowCenter" VerticalAlign="WindowCenter" Modal="true">
                                                            </EditForm>

                                                        </SettingsPopup>

                                                        <SettingsDetail ExportMode="All" ShowDetailRow="false" />

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
                                                        <SettingsSearchPanel Visible="false" />

                                                        <Columns>

                                                            <dx:GridViewCommandColumn Visible="true" VisibleIndex="1" ShowNewButton="false" ShowEditButton="true" ShowDeleteButton="true" ShowNewButtonInHeader="true" ButtonRenderMode="Button" Width="50px"></dx:GridViewCommandColumn>


                                                            <dx:GridViewDataComboBoxColumn Visible="true" VisibleIndex="2" FieldName="RolOperacion" Name="RolOperacion" Caption="Rol" Width="80px">
                                                                <EditItemTemplate>
                                                                    <dx:ASPxComboBox ID="cbRolOtorgaSolicita" ClientInstanceName="cbRolOtorgaSolicita" Value='<%# Bind("RolOperacion") %>' runat="server" AutoPostBack="false"
                                                                        OnInit="cbRolOtorgaSolicita_Init" Width="100%">

                                                                        <ClientSideEvents SelectedIndexChanged="function(s, e) 
                                                                                     {                                                                                           
                                                                                              cbAnafabetaOtorgaSolicita.PerformCallback(s.GetSelectedItem().value);
                                                                                     }" />

                                                                    </dx:ASPxComboBox>
                                                                </EditItemTemplate>

                                                            </dx:GridViewDataComboBoxColumn>


                                                            <dx:GridViewDataComboBoxColumn Visible="true" VisibleIndex="3" FieldName="TipoRegimen" Caption="T.Persona" Width="80px">


                                                                <EditItemTemplate>
                                                                    <dx:ASPxComboBox ID="cbTipoRegimen" ClientInstanceName="cbTipoRegimen" runat="server" Value='<%# Bind("TipoRegimen") %>' Width="100%"
                                                                        OnInit="cbTipoRegimen_Init">

                                                                        <Items>
                                                                            <dx:ListEditItem Text="Fisica" Value="Fisica" Selected="true"></dx:ListEditItem>
                                                                            <dx:ListEditItem Text="Moral" Value="Moral"></dx:ListEditItem>
                                                                            <dx:ListEditItem Text="Apoderado" Value="Apoderado"></dx:ListEditItem>
                                                                            <dx:ListEditItem Text="Fideicomiso" Value="Fideicomiso"></dx:ListEditItem>
                                                                        </Items>

                                                                    </dx:ASPxComboBox>
                                                                </EditItemTemplate>
                                                            </dx:GridViewDataComboBoxColumn>


                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="3" Caption="Nombres" FieldName="Nombres" Width="80px">
                                                            </dx:GridViewDataTextColumn>


                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="4" Caption="Apellido paterno" FieldName="ApellidoPaterno" Width="">
                                                            </dx:GridViewDataTextColumn>


                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="5" Caption="Apellido Materno" FieldName="ApellidoMaterno" Width="">
                                                            </dx:GridViewDataTextColumn>

                                                            <dx:GridViewDataComboBoxColumn Visible="true" VisibleIndex="6" FieldName="Sexo" Caption="Sexo" Width="60px">

                                                                <EditItemTemplate>
                                                                    <dx:ASPxComboBox ID="cbSexoOtorgaSolicita" ClientInstanceName="cbSexoOtorgaSolicita" runat="server" Value='<%# Bind("Sexo") %>' Width="100%"
                                                                        OnInit="cbSexoOtorgaSolicita_Init">

                                                                        <Items>
                                                                            <dx:ListEditItem Text="Masculino" Value="M" Selected="true"></dx:ListEditItem>
                                                                            <dx:ListEditItem Text="Femenino" Value="F"></dx:ListEditItem>
                                                                        </Items>

                                                                    </dx:ASPxComboBox>
                                                                </EditItemTemplate>
                                                            </dx:GridViewDataComboBoxColumn>

                                                            <dx:GridViewDataDateColumn PropertiesDateEdit-DisplayFormatString="dd/MM/yyyy" Visible="true" VisibleIndex="7" FieldName="FechaNacimiento" Caption="Fecha nacimiento">
                                                            </dx:GridViewDataDateColumn>


                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="9" Caption="Ocupacion" FieldName="Ocupacion" Width="100px">
                                                            </dx:GridViewDataTextColumn>



                                                            <dx:GridViewDataComboBoxColumn Visible="true" VisibleIndex="10" FieldName="EstadoCivil" Caption="Estado civil">
                                                                <EditItemTemplate>
                                                                    <dx:ASPxComboBox ID="cbEstadoCivilOtorgaSolicita" ClientInstanceName="cbEstadoCivilOtorgaSolicita" Value='<%# Bind("EstadoCivil") %>' runat="server" Width="100%"
                                                                        OnInit="cbEstadoCivilOtorgaSolicita_Init">
                                                                        <Items>
                                                                            <dx:ListEditItem Text="Casado(a)" Value="Casado" Selected="true"></dx:ListEditItem>
                                                                            <dx:ListEditItem Text="Soltero(a)" Value="Soltero"></dx:ListEditItem>
                                                                            <dx:ListEditItem Text="No Aplica" Value="NA"></dx:ListEditItem>
                                                                        </Items>
                                                                    </dx:ASPxComboBox>
                                                                </EditItemTemplate>
                                                            </dx:GridViewDataComboBoxColumn>

                                                            <dx:GridViewDataComboBoxColumn Visible="true" VisibleIndex="11" FieldName="RegimenConyugal" Caption="Regimen conyugal">
                                                                <EditItemTemplate>
                                                                    <dx:ASPxComboBox ID="cbRegimenConyugalOtorgaSolicita" ClientInstanceName="cbRegimenConyugalOtorgaSolicita" Value='<%# Bind("RegimenConyugal") %>' runat="server" Width="100%"
                                                                        OnInit="cbRegimenConyugalOtorgaSolicita_Init">
                                                                        <Items>
                                                                            <dx:ListEditItem Text="Sociedad conyugal" Value="Sociedad Conyugal" Selected="true"></dx:ListEditItem>
                                                                            <dx:ListEditItem Text="Separacion de bienes(a)" Value="Bienes separado"></dx:ListEditItem>
                                                                            <dx:ListEditItem Text="No Aplica" Value="NA"></dx:ListEditItem>
                                                                        </Items>
                                                                    </dx:ASPxComboBox>
                                                                </EditItemTemplate>
                                                            </dx:GridViewDataComboBoxColumn>

                                                            <dx:GridViewDataComboBoxColumn Visible="true" VisibleIndex="12" FieldName="SabeLeerEscribir" Caption="Sabe leer" Width="80px">
                                                                <EditItemTemplate>
                                                                    <dx:ASPxComboBox ID="cbAnafabetaOtorgaSolicita" ClientInstanceName="cbAnafabetaOtorgaSolicita" OnCallback="cbAnafabetaOtorgaSolicita_Callback" Value='<%# Bind("SabeLeerEscribir") %>' runat="server" Width="100%">
                                                                        <Items>
                                                                            <dx:ListEditItem Text="Si" Value="Si" Selected="true"></dx:ListEditItem>
                                                                            <dx:ListEditItem Text="No" Value="No"></dx:ListEditItem>
                                                                            <dx:ListEditItem Text="No Aplica" Value="NA"></dx:ListEditItem>
                                                                        </Items>
                                                                    </dx:ASPxComboBox>
                                                                </EditItemTemplate>
                                                            </dx:GridViewDataComboBoxColumn>



                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="13" Caption="Anotacion especial" FieldName="Notas" Width="100%">
                                                            </dx:GridViewDataTextColumn>

                                                            <%--  columnas datos generales de la hoja de datos--%>
                                                        </Columns>



                                                    </dx:ASPxGridView>


                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                                <dx:LayoutGroup Caption="Documentacion" ColCount="4" ColumnCount="4" ColSpan="1" Width="100%">
                                    <Items>
                                        <dx:LayoutItem ColSpan="4" ColumnSpan="4" ShowCaption="False">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxListBox runat="server" ID="lbDocumentacionOtorgaSolicita" ClientInstanceName="lbDocumentacionOtorgaSolicita" SelectionMode="CheckColumn" EnableSelectAll="true" Width="100%" Height="255px" AutoPostBack="false"
                                                        OnDataBinding="lbDocumentacionOtorgaSolicita_DataBinding">
                                                        <FilteringSettings ShowSearchUI="true" />
                                                        <ClientSideEvents SelectedIndexChanged="function(s, e) 
                                                                                     {     
                                                                                          HidDocumentoSelect.Set('OtorgaSolicita',lbDocumentacionOtorgaSolicita.GetSelectedValues());                                                                                              

                                                                                     }" />
                                                    </dx:ASPxListBox>

                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                                <dx:LayoutGroup Caption="A favor de " ColCount="4" ColumnCount="4" ColSpan="3" ColumnSpan="3">
                                    <Items>
                                        <dx:LayoutItem ColSpan="4" ColumnSpan="4" ShowCaption="False">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxGridView runat="server" ID="gvaFavorDe" ClientInstanceName="gvaFavorDe" AutoGenerateColumns="False" Width="933px" KeyFieldName="IdRegistro"
                                                        OnDataBinding="gvaFavorDe_DataBinding"
                                                        OnRowValidating="gvaFavorDe_RowValidating"
                                                        OnRowInserting="gvaFavorDe_RowInserting"
                                                        OnRowDeleting="gvaFavorDe_RowDeleting"
                                                        OnRowUpdating="gvaFavorDe_RowUpdating">

                                                        <SettingsPager Mode="ShowAllRecords" />

                                                        <Settings ShowFooter="True" ShowFilterRow="false"
                                                            ShowFilterBar="Auto" ShowFilterRowMenu="false"
                                                            ShowHeaderFilterButton="True" ShowGroupPanel="false"
                                                            VerticalScrollBarMode="Auto" HorizontalScrollBarMode="Auto" />

                                                        <SettingsResizing ColumnResizeMode="Control" />

                                                        <SettingsEditing Mode="PopupEditForm" />

                                                        <SettingsPopup>
                                                            <EditForm HorizontalAlign="WindowCenter" VerticalAlign="WindowCenter" Modal="true">
                                                            </EditForm>

                                                        </SettingsPopup>

                                                        <SettingsDetail ExportMode="All" ShowDetailRow="false" />

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
                                                        <SettingsSearchPanel Visible="false" />

                                                        <Columns>

                                                            <dx:GridViewCommandColumn Visible="true" VisibleIndex="1" ShowNewButton="false" ShowEditButton="true" ShowDeleteButton="true" ShowNewButtonInHeader="true" ButtonRenderMode="Button" Width="50px"></dx:GridViewCommandColumn>


                                                            <dx:GridViewDataComboBoxColumn Visible="true" VisibleIndex="2" FieldName="RolOperacion" Name="RolOperacion" Caption="Rol" Width="80px">
                                                                <EditItemTemplate>
                                                                    <dx:ASPxComboBox ID="cbRolAfavorDe" ClientInstanceName="cbRolAfavorDe" Value='<%# Bind("RolOperacion") %>' runat="server" AutoPostBack="false"
                                                                        OnInit="cbRolAfavorDe_Init" Width="100%">

                                                                        <ClientSideEvents SelectedIndexChanged="function(s, e) 
                                                                                             {                                                                                           
                                                                                                      cbAnafabetaAFavorDe.PerformCallback(s.GetSelectedItem().value);
                                                                                             }" />

                                                                    </dx:ASPxComboBox>
                                                                </EditItemTemplate>

                                                            </dx:GridViewDataComboBoxColumn>

                                                            <dx:GridViewDataComboBoxColumn Visible="true" VisibleIndex="3" FieldName="TipoRegimen" Caption="T.Persona" Width="80px">


                                                                <EditItemTemplate>
                                                                    <dx:ASPxComboBox ID="cbTipoRegimen" ClientInstanceName="cbTipoRegimen" runat="server" Value='<%# Bind("TipoRegimen") %>' Width="100%"
                                                                        OnInit="cbTipoRegimen_Init">

                                                                        <Items>
                                                                            <dx:ListEditItem Text="Fisica" Value="Fisica" Selected="true"></dx:ListEditItem>
                                                                            <dx:ListEditItem Text="Moral" Value="Moral"></dx:ListEditItem>
                                                                            <dx:ListEditItem Text="Apoderado" Value="Apoderado"></dx:ListEditItem>
                                                                            <dx:ListEditItem Text="Fideicomiso" Value="Fideicomiso"></dx:ListEditItem>
                                                                        </Items>

                                                                    </dx:ASPxComboBox>
                                                                </EditItemTemplate>
                                                            </dx:GridViewDataComboBoxColumn>

                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="3" Caption="Nombres" FieldName="Nombres" Width="80px">
                                                            </dx:GridViewDataTextColumn>


                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="4" Caption="Apellido paterno" FieldName="ApellidoPaterno" Width="">
                                                            </dx:GridViewDataTextColumn>


                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="5" Caption="Apellido Materno" FieldName="ApellidoMaterno" Width="">
                                                            </dx:GridViewDataTextColumn>

                                                            <dx:GridViewDataComboBoxColumn Visible="true" VisibleIndex="6" FieldName="Sexo" Caption="Sexo" Width="60px">

                                                                <EditItemTemplate>
                                                                    <dx:ASPxComboBox ID="cbSexoAfavorDe" ClientInstanceName="cbSexoAfavorDe" runat="server" Value='<%# Bind("Sexo") %>' Width="100%"
                                                                        OnInit="cbSexoAfavorDe_Init">

                                                                        <Items>
                                                                            <dx:ListEditItem Text="Masculino" Value="M" Selected="true"></dx:ListEditItem>
                                                                            <dx:ListEditItem Text="Femenino" Value="F"></dx:ListEditItem>
                                                                        </Items>

                                                                    </dx:ASPxComboBox>
                                                                </EditItemTemplate>
                                                            </dx:GridViewDataComboBoxColumn>

                                                            <dx:GridViewDataDateColumn PropertiesDateEdit-DisplayFormatString="dd/MM/yyyy" Visible="true" VisibleIndex="7" FieldName="FechaNacimiento" Caption="Fecha nacimiento">
                                                            </dx:GridViewDataDateColumn>



                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="8" Caption="Ocupacion" FieldName="Ocupacion" Width="100px">
                                                            </dx:GridViewDataTextColumn>



                                                            <dx:GridViewDataComboBoxColumn Visible="true" VisibleIndex="9" FieldName="EstadoCivil" Caption="Estado civil">
                                                                <EditItemTemplate>
                                                                    <dx:ASPxComboBox ID="cbEstadoCivilAfavorDe" ClientInstanceName="cbEstadoCivilAfavorDe" Value='<%# Bind("EstadoCivil") %>' runat="server" Width="100%"
                                                                        OnInit="cbEstadoCivilAfavorDe_Init">
                                                                        <Items>
                                                                            <dx:ListEditItem Text="Casado(a)" Value="Casado" Selected="true"></dx:ListEditItem>
                                                                            <dx:ListEditItem Text="Soltero(a)" Value="Soltero"></dx:ListEditItem>
                                                                            <dx:ListEditItem Text="Divorciado(a)" Value="Divorciado"></dx:ListEditItem>
                                                                            <dx:ListEditItem Text="No Aplica" Value="NA"></dx:ListEditItem>
                                                                        </Items>
                                                                    </dx:ASPxComboBox>
                                                                </EditItemTemplate>
                                                            </dx:GridViewDataComboBoxColumn>

                                                            <dx:GridViewDataComboBoxColumn Visible="true" VisibleIndex="10" FieldName="RegimenConyugal" Caption="Regimen conyugal">
                                                                <EditItemTemplate>
                                                                    <dx:ASPxComboBox ID="cbRegimenConyugalAfavorDe" ClientInstanceName="cbRegimenConyugalAfavorDe" Value='<%# Bind("RegimenConyugal") %>' runat="server" Width="100%"
                                                                        OnInit="cbRegimenConyugalAfavorDe_Init">
                                                                        <Items>
                                                                            <dx:ListEditItem Text="Sociedad conyugal" Value="Sociedad Conyugal" Selected="true"></dx:ListEditItem>
                                                                            <dx:ListEditItem Text="Separacion de bienes(a)" Value="Bienes separado"></dx:ListEditItem>
                                                                            <dx:ListEditItem Text="No Aplica" Value="NA"></dx:ListEditItem>
                                                                        </Items>
                                                                    </dx:ASPxComboBox>
                                                                </EditItemTemplate>
                                                            </dx:GridViewDataComboBoxColumn>

                                                            <dx:GridViewDataComboBoxColumn Visible="true" VisibleIndex="11" FieldName="SabeLeerEscribir" Caption="Sabe leer" Width="80px">
                                                                <EditItemTemplate>
                                                                    <dx:ASPxComboBox ID="cbAnafabetaAFavorDe" ClientInstanceName="cbAnafabetaAFavorDe" OnCallback="cbAnafabetaAFavorDe_Callback" Value='<%# Bind("SabeLeerEscribir") %>' runat="server" Width="100%">
                                                                        <Items>
                                                                            <dx:ListEditItem Text="Si" Value="Si" Selected="true"></dx:ListEditItem>
                                                                            <dx:ListEditItem Text="No" Value="No"></dx:ListEditItem>
                                                                            <dx:ListEditItem Text="No Aplica" Value="NA"></dx:ListEditItem>
                                                                        </Items>
                                                                    </dx:ASPxComboBox>
                                                                </EditItemTemplate>
                                                            </dx:GridViewDataComboBoxColumn>



                                                            <dx:GridViewDataTextColumn Visible="true" VisibleIndex="12" Caption="Anotacion especial" FieldName="Notas" Width="100%">
                                                            </dx:GridViewDataTextColumn>

                                                            <%--  columnas datos generales de la hoja de datos--%>
                                                        </Columns>



                                                    </dx:ASPxGridView>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                                <dx:LayoutGroup Caption="Documentacion" ColCount="4" ColumnCount="4" ColSpan="1" Width="100%">
                                    <Items>
                                        <dx:LayoutItem ColSpan="4" ColumnSpan="4" ShowCaption="False">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxListBox runat="server" ID="lbDocumentacionAfavorDe" ClientInstanceName="lbDocumentacionAfavorDe" SelectionMode="CheckColumn" EnableSelectAll="true" Width="100%" Height="255px" AutoPostBack="false"
                                                        OnDataBinding="lbDocumentacionAfavorDe_DataBinding">
                                                        <FilteringSettings ShowSearchUI="true" />
                                                        <ClientSideEvents SelectedIndexChanged="function(s, e) 
                                                                                                  {     

                                                                                                        HidDocumentoSelect.Set('AfavorDe',lbDocumentacionAfavorDe.GetSelectedValues());                                                                                                              

                                                                                                  }" />

                                                    </dx:ASPxListBox>

                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                            </Items>
                        </dx:ASPxFormLayout>

                    </dx:PopupControlContentControl>
                </ContentCollection>
                <FooterContentTemplate>
                    <div>
                        <dx:ASPxButton Style="float: right" Image-IconID="richedit_trackingchanges_accept_svg_16x16" HorizontalAlign="Right" runat="server" ID="btnAceptar" Text="Aceptar" AutoPostBack="false" ClientInstanceName="btnAceptar">
                            <ClientSideEvents Click="function(s, e) {
                                                      if (ASPxClientEdit.ValidateGroup('requerido'))
                                                          {
                                                          ppNuevaHojaDatos.PerformCallback('guardar');   
                                                          }
                                                      }" />

                        </dx:ASPxButton>

                        <%-- <dx:ASPxButton Style="float: right" Image-IconID="actions_cancel_16x16office2013" HorizontalAlign="Right" runat="server" ID="btnCancelar" Text="Cancelar" AutoPostBack="false" ClientInstanceName="btnCancelar">
                            <ClientSideEvents Click="function(s, e) 
                                                    {                                     
                                                        ppOrdenNuevoExpediente.Hide() 
                                                    }" />
                        </dx:ASPxButton>--%>
                    </div>
                </FooterContentTemplate>
            </dx:ASPxPopupControl>



        </section>


    </form>
</body>
</html>
