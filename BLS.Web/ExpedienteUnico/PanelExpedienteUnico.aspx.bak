<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PanelExpedienteUnico.aspx.cs" Inherits="SGN.Web.ExpedienteUnico.PanelExpedienteUnico" %>


<%@ Register Assembly="DevExpress.Web.Bootstrap.v25.1, Version=25.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v25.1, Version=25.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../SwitcherResources/Content/Cosmo/bootstrap.min.css" crossorigin="anonymous" />
    <link rel="stylesheet" href="../Content/all.css" />
    <link rel="stylesheet" href="../Content/generic/pageMinimalStyle.css" />
    <script src="../Scripts/sweetalert.min.js"></script>
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

            var height = document.getElementById('maindiv').clientHeight - 9;   // I have some buttons below the grid so needed -50
            var width = document.getElementById('maindiv').clientWidth;
            gvExpedienteUnico.SetHeight(height);

        }


        function gridView_EndCallback(s, e) {

            if (s.cp_swMsg != null) {
                mostrarMensajeSweet(s.cp_swType, s.cp_swMsg);
                s.cp_swType = null;
                s.cp_swMsg = null;
            }

            //validar con un parametro si es necesario el refreco de los datos

            if (s.cp_Update != null) {


                gvExpedienteUnico.PerformCallback('CargarRegistros');

                s.cp_Update = null;
            }
        }

        function CerrarModalyVerAlertas(s, e) {

            // cbListaMatFleje.PerformCallback();

            if (s.cp_swType != null && s.cp_swAlert == null) {


                //ppEditarExpediente.Hide();
                //ppCambiarEstatus.Hide();
                //ppArchivos.Hide();
                //ppAlertasExpediente.Hide();


                mostrarMensajeSweet(s.cp_swType, s.cp_swMsg);
                gvExpedienteUnico.PerformCallback('CargarRegistros');





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



                case "cmdValidarEnListaNegra":

                    if (gvExpedienteUnico.GetFocusedRowIndex() >= 0) {

                        gvExpedienteUnico.GetRowValues(gvExpedienteUnico.GetFocusedRowIndex(), 'IdRegistro', onCallbackValidarEnListaNegra);

                    }


                case "cmdReporteExpUnico":
                    if (gvExpedienteUnico.GetFocusedRowIndex() >= 0) {
                        gvExpedienteUnico.GetRowValues(gvExpedienteUnico.GetFocusedRowIndex(), 'IdRegistro', onCallbackReport);
                    }
                    break;

                case "cmdFormConociCliente":
                    if (gvExpedienteUnico.GetFocusedRowIndex() >= 0) {
                        gvExpedienteUnico.GetRowValues(gvExpedienteUnico.GetFocusedRowIndex(), 'IdRegistro', onCallbackFormConocimientoCliente);
                    }
                    break;



            }
        }



        function onCallbackEditarRegistroExp(value) {
            console.log(value);
            ppEditarExpediente.Show();
            ppEditarExpediente.PerformCallback("CargarRegistros~" + value);

        }


        function onCallbackReport(value) {



            window.open("../Reportes/reporteExUnico?idRegistro=" + value, "_blank");
        }


        function onCallbackFormConocimientoCliente(value) {



            window.open("../Reportes/reporteFormConociendoCliente?idRegistro=" + value, "_blank");
        }




        function onCallbackValidarEnListaNegra(value) {

            window.open("../Reportes/reporteAcuseConsultaListaNegra?idRegistro=" + value, "_blank");
        }


    </script>





    <title>SGN</title>
</head>
<body>
    <form id="frmPage" runat="server" class="Principal">
        <dx:ASPxPanel ID="TopPanel" runat="server" FixedPosition="WindowTop" FixedPositionOverlap="true" CssClass="topPanel">
            <PanelCollection>
                <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                    <table>
                        <tr>
                            <td>
                                <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" ShowCollapseButton="true" Width="170px" HeaderText="Opciones de consulta:" View="GroupBox">
                                    <PanelCollection>
                                        <dx:PanelContent>


                                            <table>
                                                <tr>
                                                    <td>
                                                        <dx:ASPxDateEdit Caption="Inicio" runat="server" ID="dtFechaInicio" ClientInstanceName="dtFechaInicio" AutoPostBack="false" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                                                        </dx:ASPxDateEdit>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                    <td>
                                                        <dx:ASPxDateEdit Caption="Fin" runat="server" ID="dtFechaFin" ClientInstanceName="dtFechaFin" AutoPostBack="false" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                                                        </dx:ASPxDateEdit>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                    <td>
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
                                                                }                                            }" />
                                                        </dx:ASPxCheckBox>
                                                    </td>
                                                    <td>&nbsp;</td>

                                                    <td>
                                                        <dx:ASPxButton ID="btnActualizar" runat="server" Image-IconID="xaf_action_reload_svg_16x16" Text="Actualizar" AutoPostBack="false" Enabled="true">
                                                            <ClientSideEvents Click="function(s, e) {  gvExpedienteUnico.PerformCallback('CargarRegistros'); }" />

                                                            <Image IconID="xaf_action_reload_svg_16x16"></Image>
                                                        </dx:ASPxButton>
                                                    </td>
                                                </tr>
                                            </table>


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



            <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="gvExpedienteUnico"></dx:ASPxGridViewExporter>


            <dx:ASPxGridView runat="server" ID="gvExpedienteUnico" ClientInstanceName="gvExpedienteUnico" AutoGenerateColumns="False" Width="100%" KeyFieldName="IdRegistro"
                OnDataBinding="gvExpedienteUnico_DataBinding"
                OnCustomCallback="gvExpedienteUnico_CustomCallback"
                OnToolbarItemClick="gvExpedienteUnico_ToolbarItemClick"
                OnHtmlDataCellPrepared="gvExpedienteUnico_HtmlDataCellPrepared"
                OnRowUpdating="gvExpedienteUnico_RowUpdating"
                OnRowValidating="gvExpedienteUnico_RowValidating">

                <ClientSideEvents Init="AdjustSize" EndCallback="gridView_EndCallback" />

                <ClientSideEvents ToolbarItemClick="OnToolbarItemClick" />

                <SettingsPager Mode="ShowPager" PageSize="100" />

                <Settings ShowFooter="True" ShowFilterRow="true" ShowFilterBar="Auto" ShowFilterRowMenu="True" ShowHeaderFilterButton="True" ShowGroupPanel="True" VerticalScrollBarMode="Auto" HorizontalScrollBarMode="Auto" />

                <%--                <SettingsCookies Enabled="true" />--%>

                <SettingsResizing ColumnResizeMode="Control" />


                <%--                <SettingsDetail ExportMode="Expanded" ShowDetailRow="true" />--%>

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

                <SettingsEditing Mode="PopupEditForm" />

                <SettingsPopup>
                    <EditForm HorizontalAlign="WindowCenter" VerticalAlign="WindowCenter" Modal="true">
                    </EditForm>

                </SettingsPopup>

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



                <SettingsDataSecurity AllowInsert="false" AllowDelete="false" AllowEdit="true" />
                <SettingsSearchPanel Visible="true" ShowApplyButton="true" ShowClearButton="true" />
                <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="DataAware" />

                <Columns>


                    <dx:GridViewCommandColumn Visible="true" VisibleIndex="0" ShowNewButton="false" ShowEditButton="true" ShowDeleteButton="false"
                        ShowNewButtonInHeader="false" ButtonRenderMode="Button" Width="50px">
                    </dx:GridViewCommandColumn>

                    <dx:GridViewDataImageColumn Visible="true" VisibleIndex="1" Caption="Estado" FieldName="ImageEstado" Width="70px">
                        <PropertiesImage ImageUrlFormatString="~/imagenes/ExUnico/{0}"></PropertiesImage>
                        <EditFormSettings Visible="False"></EditFormSettings>
                    </dx:GridViewDataImageColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="1" Caption="Resumen de la operacion:" FieldName="Resumen" Width="500px" Visible="true" GroupIndex="0" ReadOnly="true" CellStyle-Font-Bold="true">
                        <EditFormSettings Visible="True" ColumnSpan="2" CaptionLocation="Top" Caption=" "></EditFormSettings>
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="2" Caption="Estatus" FieldName="TextoEstatus" Width="150px" Visible="False">
                        <EditFormSettings Visible="False"></EditFormSettings>
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="3" Caption="Acto" FieldName="TextoActo" Width="100px" Visible="False">
                        <EditFormSettings Visible="False"></EditFormSettings>
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="4" Caption="Variante" FieldName="TextoVariante" Width="150px" Visible="False">
                        <EditFormSettings Visible="False"></EditFormSettings>
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataDateColumn PropertiesDateEdit-DisplayFormatString="dd/MM/yyyy" VisibleIndex="7" Caption="Fecha ingreso" FieldName="FechaIngreso" Width="120px" Visible="False">
                        <EditFormSettings Visible="False"></EditFormSettings>
                    </dx:GridViewDataDateColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="5" Caption="Rol" FieldName="FiguraOperacion" Width="150px" Visible="False">
                        <EditFormSettings Visible="False"></EditFormSettings>
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="6" Caption="Rol" FieldName="RolOperacion" Width="100px" Visible="true">
                        <EditFormSettings Visible="False"></EditFormSettings>
                    </dx:GridViewDataTextColumn>



                    <dx:GridViewDataTextColumn VisibleIndex="8" Caption="Nombre(s)" FieldName="Nombres" Width="120px" Visible="true" ReadOnly="true">
                        <%--               <EditFormSettings Visible="False"></EditFormSettings>--%>
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="9" Caption="Apellido Paterno" FieldName="ApellidoPaterno" Width="120px" Visible="true" ReadOnly="true">
                        <%--           <EditFormSettings Visible="False"></EditFormSettings>--%>
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="10" Caption="Apellido Materno" FieldName="ApellidoMaterno" Width="120px" Visible="true" ReadOnly="true">
                        <%--                        <EditFormSettings Visible="False"></EditFormSettings>--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn VisibleIndex="11" Caption="F. Nacimiento" FieldName="FechaNacimiento" Width="100px" Visible="true" PropertiesDateEdit-DisplayFormatString="dd/MM/yyyy">
                    </dx:GridViewDataDateColumn>

                    <dx:GridViewDataComboBoxColumn VisibleIndex="12" Caption="Sexo" FieldName="Sexo" Width="60px" Visible="true" CellStyle-HorizontalAlign="Center">

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

                    <dx:GridViewDataTextColumn VisibleIndex="13" Caption="Estado Civil" FieldName="EstadoCivil" Width="100px" Visible="False" ReadOnly="true">
                        <EditFormSettings Visible="False"></EditFormSettings>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn VisibleIndex="15" Caption="RegimenConyugal" FieldName="RegimenConyugal" Width="150px" Visible="False" ReadOnly="true">
                        <EditFormSettings Visible="False"></EditFormSettings>
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="14" Caption="Actividad/Ocupacion" FieldName="Ocupacion" Width="150px" Visible="true" ReadOnly="false">
                        <EditFormSettings Visible="true"></EditFormSettings>
                    </dx:GridViewDataTextColumn>


                    <dx:GridViewDataTextColumn VisibleIndex="16" Caption="Sabe leer y escribir" FieldName="SabeLeerEscribir" Width="150px" Visible="false" ReadOnly="true">
                        <EditFormSettings Visible="False"></EditFormSettings>
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="17" Caption="Anotaciones (Datos)" FieldName="Notas" Width="150px" Visible="false" ReadOnly="true">
                        <EditFormSettings Visible="False"></EditFormSettings>
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataComboBoxColumn VisibleIndex="18" Caption="T.Persona" FieldName="TipoRegimen" Width="80px" Visible="true" CellStyle-Font-Bold="true">

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
                        <EditFormSettings Visible="True" ColumnSpan="2"></EditFormSettings>
                    </dx:GridViewDataComboBoxColumn>

                    <dx:GridViewDataComboBoxColumn VisibleIndex="20" Caption="P.Nacimiento" FieldName="PaisNacimiento" Width="100px" Visible="true">
                        <EditItemTemplate>
                            <dx:ASPxComboBox ID="cbPaisNacimiento" ClientInstanceName="cbPaisNacimiento" runat="server" Value='<%# Bind("PaisNacimiento") %>' Width="100%"
                                OnInit="cbPaisNacimiento_Init" OnDataBinding="cbPaisNacimiento_DataBinding">
                            </dx:ASPxComboBox>
                        </EditItemTemplate>
                    </dx:GridViewDataComboBoxColumn>

                    <dx:GridViewDataComboBoxColumn VisibleIndex="19" Caption="P.Nacionalidad" FieldName="PaisNacionalidad" Width="100px" Visible="true">
                        <EditItemTemplate>
                            <dx:ASPxComboBox ID="cbPaisNacionalidad" ClientInstanceName="cbPaisNacionalidad" runat="server" Value='<%# Bind("PaisNacionalidad") %>' Width="100%"
                                OnInit="cbPaisNacionalidad_Init" OnDataBinding="cbPaisNacionalidad_DataBinding">
                            </dx:ASPxComboBox>
                        </EditItemTemplate>
                    </dx:GridViewDataComboBoxColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="21" Caption="Identificacion" FieldName="NombreIdentificacionID" Width="100px" Visible="true">
                        <EditFormSettings Visible="True" ColumnSpan="2"></EditFormSettings>
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="22" Caption="Autoridad Emite" FieldName="AutoridadEmiteID" Width="100px" Visible="true">
                        <EditFormSettings Visible="True" ColumnSpan="2"></EditFormSettings>
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="23" Caption="Numero ID" FieldName="NumeroSerieID" Width="100px" Visible="true">
                        <EditFormSettings Visible="True" ColumnSpan="2"></EditFormSettings>
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="24" Caption="Domicilio (Calle)" FieldName="Domicilio" Width="200px" Visible="true">
                        <EditFormSettings Visible="True" ColumnSpan="2"></EditFormSettings>
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="25" Caption="Num.Exterior" FieldName="NumeroExterior" Width="75px" Visible="true">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="26" Caption="Num.Interior" FieldName="NumeroInterior" Width="75px" Visible="true">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="27" Caption="Colonia" FieldName="Colonia" Width="150px" Visible="true">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="28" Caption="Municipio" FieldName="Municipio" Width="150px" Visible="true">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="29" Caption="Ciudad" FieldName="Ciudad" Width="150px" Visible="true">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="30" Caption="Estado" FieldName="Estado" Width="150px" Visible="true">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataComboBoxColumn VisibleIndex="31" Caption="P.Domicilio" FieldName="PaisDomicilio" Width="100px" Visible="true">
                        <EditItemTemplate>
                            <dx:ASPxComboBox ID="cbPaisDomicilio" ClientInstanceName="cbPaisDomicilio" runat="server" Value='<%# Bind("PaisDomicilio") %>' Width="100%"
                                OnInit="cbPaisDomicilio_Init" OnDataBinding="cbPaisDomicilio_DataBinding">
                            </dx:ASPxComboBox>
                        </EditItemTemplate>
                    </dx:GridViewDataComboBoxColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="32" Caption="CP" FieldName="CP" Width="60px" Visible="true">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="33" Caption="Num.Tefonico" FieldName="NumeroTefonico" Width="100px" Visible="true">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="34" Caption="Correo E." FieldName="CorreoElectronico" Width="180px" Visible="true">
                        <EditFormSettings Visible="True" ColumnSpan="2"></EditFormSettings>
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="35" Caption="Curp" FieldName="Curp" Width="120px" Visible="true">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="36" Caption="Rfc" FieldName="Rfc" Width="120px" Visible="true" CellStyle-Font-Bold="true">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="38" Caption="Razon Social" FieldName="RazonSocial" Width="200px" Visible="true">
                        <EditFormSettings Visible="True" ColumnSpan="2"></EditFormSettings>
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataDateColumn VisibleIndex="39" Caption="F.Constitucion" FieldName="FechaConstitucion" Width="100px" Visible="true" PropertiesDateEdit-DisplayFormatString="dd/MM/yyyy">
                    </dx:GridViewDataDateColumn>

                    <dx:GridViewDataComboBoxColumn VisibleIndex="40" Caption="P.RazonSocial" FieldName="PaisRazonSocial" Width="100px" Visible="true">
                        <EditItemTemplate>
                            <dx:ASPxComboBox ID="cbPaisRazonSocial" ClientInstanceName="cbPaisRazonSocial" runat="server" Value='<%# Bind("PaisRazonSocial") %>' Width="100%"
                                OnInit="cbPaisRazonSocial_Init" OnDataBinding="cbPaisRazonSocial_DataBinding">
                            </dx:ASPxComboBox>
                        </EditItemTemplate>
                    </dx:GridViewDataComboBoxColumn>

                    <dx:GridViewDataTextColumn VisibleIndex="41" Caption="Actividad Razon Social" FieldName="ActividadRazonSocial" Width="200px" Visible="true">
                        <EditFormSettings Visible="True" ColumnSpan="2"></EditFormSettings>
                    </dx:GridViewDataTextColumn>


                    <dx:GridViewDataTextColumn VisibleIndex="42" Caption="Num. Fideicomiso" FieldName="IdFideicomiso" Width="200px" Visible="true">
                        <EditFormSettings Visible="True" ColumnSpan="2"></EditFormSettings>
                    </dx:GridViewDataTextColumn>

                </Columns>


                <Toolbars>
                    <dx:GridViewToolbar>
                        <Items>




                            <dx:GridViewToolbarItem Text="Buscar en Lista Negra" Image-IconID="actions_show_16x16gray" Name="cmdValidarEnListaNegra" />

                            <dx:GridViewToolbarItem Text="Impresion de Expediente Unico" Image-IconID="actions_print_16x16devav" Name="cmdReporteExpUnico" />

                            <dx:GridViewToolbarItem Text="Formulario de conocimiento del cliente" Image-IconID="actions_print_16x16devav" Name="cmdFormConociCliente" />


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





                <Styles>
                    <GroupRow BackColor="#CCCCCC"></GroupRow>
                </Styles>
            </dx:ASPxGridView>


            <dx:ASPxPanel ID="BottomPanel" runat="server" FixedPosition="WindowBottom" FixedPositionOverlap="true">
                <PanelCollection>
                    <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                        <table>
                            <tr>
                                <td>
                                    <dx:ASPxImage runat="server" ImageUrl="~/imagenes/ExUnico/DatosCompletos.png" Caption="Datos Completos"></dx:ASPxImage>

                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>
                                    <dx:ASPxImage runat="server" ImageUrl="~/imagenes/ExUnico/FaltanDatos.png" Caption="Datos Incompletos"></dx:ASPxImage>
                                </td>



                            </tr>
                        </table>
                    </dx:PanelContent>
                </PanelCollection>
            </dx:ASPxPanel>


        </section>




    </form>
</body>
</html>
