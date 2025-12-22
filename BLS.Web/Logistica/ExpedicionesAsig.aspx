<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExpedicionesAsig.aspx.cs" Inherits="GPB.Web.ExpedicionesAsig" %>
<%@ Register Src="~/Controles/Usuario/InfoMsgBox.ascx" TagPrefix="uc1" TagName="cuInfoMsgbox" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v25.2, Version=25.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src='<%# ResolveUrl("../Content/ExpedicionesAsig.js") %>'></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="user-scalable=0, width=device-width, initial-scale=1.0, maximum-scale=1.0" />
    <%--<link rel="stylesheet" href="../Content/bootstrap.min.css" crossorigin="anonymous" />--%>
    <link rel="stylesheet" href="../SwitcherResources/Content/Simplex/bootstrap.min.css" crossorigin="anonymous" />
    <link rel="stylesheet" href="../Content/all.css" crossorigin="anonymous" />
    <link rel="stylesheet" href="../Content/generic/pageStyle.css" crossorigin="anonymous" />
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
      <script src="../Content/ExpedicionesAsig.js"></script>

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
            <dx:ASPxLabel ID="lblNombrePagina" CssClass="titleHeader" runat="server" Text="Expediciones" Font-Bold="true"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblVersion" CssClass="titleHeader version" runat="server" Text="Versión: 1.0 Beta" Font-Bold="true"></dx:ASPxLabel>
        </header>
        <div style="margin-left: 30px;">
            <a class="btn-box-tool" data-toggle="collapse" data-target="#controles" role="button" onclick="iconMaxMin()" aria-expanded="false" aria-controls="controles"><i id="iconCollapse" data-original="fas fa-angle-double-down" class="fas fa-angle-double-down"></i></a>
        </div>

        <section class="CLPageControls" id="controles" class="collapse show" aria-labelledby="controles">
            <div class="" style="width: 100%; padding-left:10px;">
                <div class="row">
                    <div class="">
                      <%--  <dx:BootstrapButton ID="btnNuevo" runat="server" AutoPostBack="false" Text="" CssClasses-Icon="fas fa-file" ToolTip="Nuevo"
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
                        </dx:BootstrapButton>

<%--                        <dx:BootstrapButton ID="btnExportar" runat="server" AutoPostBack="false" Text="" CssClasses-Icon="fas fa-print" ToolTip="Exportar"
                            Style='font-size: 17px' SettingsBootstrap-Sizing="Small">
                        </dx:BootstrapButton>--%>
                    </div>
                </div>
            </div>
        </section>

        <section class="CLPageContent">
            <div class="">
               
                    <asp:HiddenField ID="HidIdexpedicion" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="HidEmpresa" runat="server" ClientIDMode="Static" />
                   <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" ShowCollapseButton="true" Width="50%" HeaderText="Opciones de consulta:" View="GroupBox">
                    <PanelCollection>
                        <dx:PanelContent>
                            <dx:BootstrapFormLayout ID="BootstrapFormLayout1" runat="server" Width="100%">
                                <Items >
                                <dx:BootstrapLayoutItem Caption="" ColSpanLg="5" ColSpanMd="6" >
                                  <ContentCollection>
                                    <dx:ContentControl>
                                          <dx:ASPxComboBox runat="server" ID="cbAgencias" ClientInstanceName="cbAgencias"  Width="100%"
                                            AutoPostBack="True" OnDataBinding="cbAgencias_DataBinding"  OnValueChanged="cbAgencias_ValueChanged" Caption="Agencias:" >
                                        </dx:ASPxComboBox>
                                    </dx:ContentControl>
                                      </ContentCollection>
                                </dx:BootstrapLayoutItem>
                                <dx:BootstrapLayoutItem Caption="" ColSpanLg="4" ColSpanMd="6" >
                                  <ContentCollection>
                                    <dx:ContentControl>
                                        <dx:ASPxComboBox runat="server" ID="CbEstados" ClientInstanceName="cbestados"  Width="200px"
                                            AutoPostBack="True" OnDataBinding="CbEstados_DataBinding"  OnValueChanged="CbEstados_ValueChanged" Caption="Estados:" >
                                        </dx:ASPxComboBox>
                                    </dx:ContentControl>
                                  </ContentCollection>
                                    </dx:BootstrapLayoutItem>
                                    <dx:BootstrapLayoutItem Caption="" ColSpanLg="3" ColSpanMd="6" >
                                    <ContentCollection>
                                    <dx:ContentControl>
                                             <dx:BootstrapCheckBox ID="cb_verretrasadas" Text="Ver expediciones retrasadas" runat="server" AutoPostBack="true" OnCheckedChanged="cb_verretrasadas_CheckedChanged"></dx:BootstrapCheckBox>
                                        </dx:ContentControl>
                                      </ContentCollection>
                                        </dx:BootstrapLayoutItem>
                                
                                    </Items>
                            </dx:BootstrapFormLayout>
                           
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxRoundPanel>
                <dx:ASPxPanel ID="Pnl_Expedicione_log" runat="server" Width="100%">
                    <PanelCollection>
                        <dx:PanelContent>
                              <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="GV_Expediciones"></dx:ASPxGridViewExporter>
                            <dx:BootstrapGridView ID="GV_Expediciones" runat="server"  ClientIDMode="Static" Width="100%"   OnDataBinding="GV_Expediciones_DataBinding" AutoGenerateColumns="False" KeyFieldName="exId" 
                                
                                 >
                                <SettingsCustomizationDialog Enabled="true"  ShowColumnChooserPage="true" /> 
                                   <Toolbars>
                        <dx:BootstrapGridViewToolbar>
                            <Items>
                                    <dx:BootstrapGridViewToolbarItem Command="ShowCustomizationDialog" />
                                     <dx:BootstrapGridViewToolbarItem Command="ExportToXls" />
                               
                            </Items>
                        </dx:BootstrapGridViewToolbar>
                    </Toolbars>
                                 <SettingsAdaptivity AdaptivityMode="HideDataCellsWindowLimit"        AllowOnlyOneAdaptiveDetailExpanded="true"  AllowHideDataCellsByColumnMinWidth="true">
                                </SettingsAdaptivity>
                                <SettingsPager PageSize="20">
                                </SettingsPager>
                                <Settings ShowHeaderFilterButton="true" />
                                <SettingsBehavior AllowSelectByRowClick="True" />

                                <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                                <Columns>
                                    <dx:BootstrapGridViewTextColumn Caption="Expedición"  FieldName="ExNumexpedicion"    VisibleIndex="0" Width="10%">
                                    </dx:BootstrapGridViewTextColumn>
                                    <dx:BootstrapGridViewTextColumn Caption="Origen" FieldName="ExOrigen"   VisibleIndex="1" Width="10%">
                                    </dx:BootstrapGridViewTextColumn>
                                    <dx:BootstrapGridViewTextColumn Caption="Centro carga" FieldName="ExCentroCarga"   VisibleIndex="2" Width="10%">
                                    </dx:BootstrapGridViewTextColumn>
                                    <dx:BootstrapGridViewTextColumn Caption="Destino" FieldName="ExDestino" VisibleIndex="3" Width="10%">
                                        <SettingsHeaderFilter Mode="CheckedList"></SettingsHeaderFilter>
                                    </dx:BootstrapGridViewTextColumn>
                                    <dx:BootstrapGridViewTextColumn Caption="Longitud"   FieldName="ExLongitud"  VisibleIndex="4" Width="10%">
                                        <SettingsHeaderFilter Mode="CheckedList"></SettingsHeaderFilter>
                                    </dx:BootstrapGridViewTextColumn>
                                    <dx:BootstrapGridViewTextColumn Caption="Unidad Transp"   FieldName="ExUnidadTransporte"  VisibleIndex="5" Width="10%">
                                        <SettingsHeaderFilter Mode="CheckedList"></SettingsHeaderFilter>
                                    </dx:BootstrapGridViewTextColumn>
                                    <dx:BootstrapGridViewTextColumn Caption="Agencia" FieldName="ExNombreAgencia"   VisibleIndex="6" Width="10%">
                                        <SettingsHeaderFilter Mode="CheckedList"></SettingsHeaderFilter>
                                    </dx:BootstrapGridViewTextColumn>
                                    <dx:BootstrapGridViewTextColumn Caption="Matricula" FieldName="ExMatricula"   VisibleIndex="7" Width="10%">
                                    </dx:BootstrapGridViewTextColumn>
                                      <dx:BootstrapGridViewTextColumn Caption="Estado" FieldName="Descripcion"  VisibleIndex="8" Width="10%">
                                          <SettingsHeaderFilter Mode="CheckedList"></SettingsHeaderFilter>
                                    </dx:BootstrapGridViewTextColumn>
                                      <dx:BootstrapGridViewCheckColumn   ReadOnly="False"  Caption="Urgente" VisibleIndex="9"   FieldName="Exurgente" Width="3%" Visible="True" >
                                                             
                                         </dx:BootstrapGridViewCheckColumn>
                                       <dx:BootstrapGridViewTextColumn Caption="Fecha Creación" FieldName="ExFechaCreaExp"   VisibleIndex="7" Width="10%"  Visible="False" >
                                    </dx:BootstrapGridViewTextColumn>
                                      <dx:BootstrapGridViewTextColumn Caption="Fecha Asignación" FieldName="ExFechaAsignacion"   VisibleIndex="7" Width="10%"  Visible="False" >
                                    </dx:BootstrapGridViewTextColumn>
                                    <dx:BootstrapGridViewTextColumn Caption="Fecha Matricula" FieldName="ExFechaMatricula"   VisibleIndex="7" Width="10%"  Visible="False" >
                                    </dx:BootstrapGridViewTextColumn>
                                       <dx:BootstrapGridViewTextColumn Caption="Estado GESAG" FieldName="ExDescripcionEstado" VisibleIndex="10" Visible="true" Width="10%">
		                            </dx:BootstrapGridViewTextColumn>
                                    <dx:BootstrapGridViewTextColumn  VisibleIndex="11" Width="10%">
                                        <DataItemTemplate>
                                            <dx:BootstrapButton ID="btnVerAgencias" runat="server" AutoPostBack="false" Text="" CssClasses-Icon="fas fa-search-plus" ToolTip="Nuevo"
                                             Style='font-size: 17px' SettingsBootstrap-Sizing="Small" OnClick="btnVerAgencias_Click">
                                           <%--           <ClientSideEvents Click="function(s, e) { VerAgencias();  }" />--%>
                                                 </dx:BootstrapButton>
                                            <asp:LinkButton  ID="BtIDExpedicion" ClientIDMode="Static"  style="display:none;" Font-Size="Smaller" Text='<%# Eval("ExNumexpedicion") %>' runat="server"></asp:LinkButton>
                                          
                                            <dx:BootstrapButton ID="btnAsignarAgencia" runat="server" AutoPostBack="false" OnClick="btnAsignarAgencia_Click" Text="" CssClasses-Icon="fas fa-dolly" ToolTip="Nuevo"
                                             Style='font-size: 17px' SettingsBootstrap-Sizing="Small">
                                                     <ClientSideEvents Click="function(s, e) { AsignarMatriculas();  }" />
                                                 </dx:BootstrapButton>
                                       </DataItemTemplate>
                                    </dx:BootstrapGridViewTextColumn>
                                </Columns>
                                <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="DataAware" />
                                  <FormatConditions>
                        <dx:GridViewFormatConditionHighlight ApplyToRow="true"   Format="Custom"  Expression="ExEstadobloqueado='1'">
                            	<RowStyle BackColor= "#F1948E" />
                        </dx:GridViewFormatConditionHighlight>
                         <dx:GridViewFormatConditionHighlight ApplyToRow="true"  Format="Custom"   Expression="ExEstadobloqueado='2'">
                            <RowStyle BackColor="#C4D8E9" />
                        </dx:GridViewFormatConditionHighlight>
                    </FormatConditions>
                            </dx:BootstrapGridView>
                        </dx:PanelContent>
                        
                        </PanelCollection>
                </dx:ASPxPanel>
                <dx:BootstrapPopupControl ID="PUp_VerAgencias" ClientInstanceName="PUp_VerAgencias" runat="server"  Width="600px" Height="600px"  
                    PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"  AllowDragging="True" CloseAction="CloseButton" CloseOnEscape="True" Modal="True"
                    PopupAnimationType="None" EnableViewState="False" HeaderText="Agencias Asignadas" >
                    <ClientSideEvents Shown=" function(s, e){Gv_AgenciasAsignadas.PerformCallback();}"  CloseButtonClick="function(s, e) {  Refrescaexpedientes();}"  />
                    <ContentCollection>
                         <dx:ContentControl >
                             <dx:BootstrapButton ID="BT_Quitartodo" Width="50%" runat="server"   ClientInstanceName="btquitartodo"  AutoPostBack="true" OnClick="BT_Quitartodo_Click"  Text="Quitar todo"  ToolTip="Quitar todo" Style='font-size: 17px' SettingsBootstrap-Sizing="Small" >
                               <SettingsBootstrap Sizing="Small"></SettingsBootstrap>
                                </dx:BootstrapButton>
                             </p>
                                  <dx:ASPxGridViewExporter ID="ASPxGridViewExporter2" runat="server" GridViewID="Gv_AgenciasAsignadas"></dx:ASPxGridViewExporter>
                             <dx:BootstrapGridView ID="Gv_AgenciasAsignadas" ClientInstanceName="Gv_AgenciasAsignadas" runat="server" OnCustomCallback="Gv_AgenciasAsignadas_CustomCallback"  OnDataBinding="Gv_AgenciasAsignadas_DataBinding" Width="100%" AutoGenerateColumns="False">
                                
                                 <Settings ShowHeaderFilterButton="true" />
                                 <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                                  <Toolbars>
                                      <dx:BootstrapGridViewToolbar>
                                        <Items>
                                            <dx:BootstrapGridViewToolbarItem Command="ExportToXls" />
                             
                                        </Items>
                                    </dx:BootstrapGridViewToolbar>
                                </Toolbars>
                                 <Columns>
                                   <dx:BootstrapGridViewTextColumn Caption="ID Agencia" FieldName="AeIdAgencia"  VisibleIndex="0">
                                     </dx:BootstrapGridViewTextColumn>
                                     <dx:BootstrapGridViewTextColumn Caption="Nombre Agencia" FieldName="AeNombreAgencia"  VisibleIndex="1">
                                     </dx:BootstrapGridViewTextColumn>
                                      <dx:BootstrapGridViewTextColumn ShowInCustomizationDialog="True" VisibleIndex="11" Width="15%">
                                                            <DataItemTemplate>
                                      <dx:BootstrapButton ID="btn_quitaragencia" runat="server" AutoPostBack="false" Text="" CssClasses-Icon="fas fa-trash-alt" ToolTip="Quitar Agencia"
                                                                    Style='font-size: 12px' SettingsBootstrap-Sizing="Small" OnClick="btn_quitaragencia_Click">
                                                                  <ClientSideEvents Click="function(s, e) { AsignarMatriculas();  }" />
                                      </dx:BootstrapButton>
                                                          </DataItemTemplate>
                                                         </dx:BootstrapGridViewTextColumn>

                                 </Columns>

                                 <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="DataAware" />
                             </dx:BootstrapGridView>
                        </dx:ContentControl>
                    </ContentCollection>

                </dx:BootstrapPopupControl>
                 <dx:BootstrapPopupControl ID="Pup_AsignarAgencias" ClientInstanceName="puasignaragencias" runat="server"   Width="1200px" Height="800px"
                      PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"  AllowDragging="True" CloseAction="CloseButton" CloseOnEscape="True" Modal="True"
                     PopupAnimationType="None" EnableViewState="False" HeaderText="Asignar Matricula">
                     <ClientSideEvents CloseButtonClick="function(s, e) {
	                Refrescaexpedientes();
                        }" />
                    <ContentCollection>
                         <dx:ContentControl>
                             
                        </dx:ContentControl>
                    </ContentCollection>

                </dx:BootstrapPopupControl>
                   <dx:BootstrapPopupControl ID="PU_Expedicionesretrasadas" ClientInstanceName="PU_Expedicionesretrasadas" runat="server"   Width="1200px" Height="800px"
                      PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"  AllowDragging="True" CloseAction="CloseButton" CloseOnEscape="True" Modal="True"
                     PopupAnimationType="None" EnableViewState="False" HeaderText="Expediciones sin Matricula">
                       <ClientSideEvents Shown=" function(s, e){Gv_ExpedicionesRetrasadas.PerformCallback();}" />
                    <ContentCollection>
                         <dx:ContentControl >
                             <dx:ASPxGridViewExporter ID="ASPxGridViewExporter3" runat="server" GridViewID="Gv_ExpedicionesRetrasadas"></dx:ASPxGridViewExporter>
                             <dx:BootstrapGridView ID="Gv_ExpedicionesRetrasadas" ClientInstanceName="Gv_ExpedicionesRetrasadas" KeyFieldName="MiNumExpedicion" runat="server" OnCustomCallback="Gv_ExpedicionesRetrasadas_CustomCallback" OnDataBinding="Gv_ExpedicionesRetrasadas_DataBinding" Width="100%" AutoGenerateColumns="False">
                               
                               <Settings ShowHeaderFilterButton="true" />
                                <SettingsBehavior AllowSelectByRowClick="True" />
                                   <Toolbars>
                                      <dx:BootstrapGridViewToolbar>
                                        <Items>
                                        
                                            <dx:BootstrapGridViewToolbarItem Command="ExportToXls" />
                             
                                        </Items>
                                    </dx:BootstrapGridViewToolbar>
                                </Toolbars>
                                <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                                 <Columns>
                                     

                                       <dx:BootstrapGridViewTextColumn Caption="Expedición"  FieldName="MiNumExpedicion"    VisibleIndex="0" Width="10%">
                                    </dx:BootstrapGridViewTextColumn>
                                    <dx:BootstrapGridViewTextColumn Caption="Origen" FieldName="MsOrigen"   VisibleIndex="1" Width="10%">
                                    </dx:BootstrapGridViewTextColumn>
                                    <dx:BootstrapGridViewTextColumn Caption="Centro carga" FieldName="MsCentroCarga"   VisibleIndex="2" Width="10%">
                                    </dx:BootstrapGridViewTextColumn>
                                    <dx:BootstrapGridViewTextColumn Caption="Destino" FieldName="MsDestino" VisibleIndex="3" Width="10%">
                                        <SettingsHeaderFilter Mode="CheckedList"></SettingsHeaderFilter>
                                    </dx:BootstrapGridViewTextColumn>
                                    <dx:BootstrapGridViewTextColumn Caption="Longitud"   FieldName="MsLongitud"  VisibleIndex="4" Width="10%">
                                        <SettingsHeaderFilter Mode="CheckedList"></SettingsHeaderFilter>
                                    </dx:BootstrapGridViewTextColumn>
                                         <dx:BootstrapGridViewTextColumn Caption="Fecha Asignacion"   FieldName="MdFechaAsignacion"  VisibleIndex="4" Width="10%">
                                        <SettingsHeaderFilter Mode="CheckedList"></SettingsHeaderFilter>
                                    </dx:BootstrapGridViewTextColumn>
                                       <dx:BootstrapGridViewTextColumn  VisibleIndex="10" Width="10%">
                                        <DataItemTemplate>
                                            <dx:BootstrapButton ID="btnVerAgencias" runat="server" AutoPostBack="false" Text="" CssClasses-Icon="fas fa-search-plus" ToolTip="Nuevo"
                                             Style='font-size: 17px' SettingsBootstrap-Sizing="Small" OnClick="btnVerAgenciasPup_Click">
                                           <%--           <ClientSideEvents Click="function(s, e) { VerAgencias();  }" />--%>
                                                 </dx:BootstrapButton>
                                            <asp:LinkButton  ID="BtIDExpedicion" ClientIDMode="Static"  style="display:none;" Font-Size="Smaller" Text='<%# Eval("MiNumExpedicion") %>' runat="server"></asp:LinkButton>
                                          
                                            <dx:BootstrapButton ID="btnAsignarAgencia" runat="server" AutoPostBack="false" OnClick="btnVerAgenciasPup_Click" Text="" CssClasses-Icon="fas fa-dolly" ToolTip="Nuevo"
                                             Style='font-size: 17px' SettingsBootstrap-Sizing="Small">
                                                     <ClientSideEvents Click="function(s, e) { AsignarMatriculas();  }" />
                                                 </dx:BootstrapButton>
                                       </DataItemTemplate>
                                    </dx:BootstrapGridViewTextColumn>
                                 </Columns>
                                      <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="DataAware" />


                             </dx:BootstrapGridView>
                        </dx:ContentControl>
                    </ContentCollection>

                </dx:BootstrapPopupControl>

            </div>
        </section>

        <footer class="CLPageFooter">
            © Derechos Reservados 2020-2021 CL Grupo Industrial Todos los Derechos Reservados.
        </footer>
    </form>

</body>
</html>
