<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignacionRet.aspx.cs" Inherits="GPB.Web.AsignacionRet" %>
<%@ Register Src="~/Controles/Usuario/InfoMsgBox.ascx" TagPrefix="uc1" TagName="cuInfoMsgbox" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v25.1, Version=25.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="user-scalable=0, width=device-width, initial-scale=1.0, maximum-scale=1.0" />
    <%--<link rel="stylesheet" href="../Content/bootstrap.min.css" crossorigin="anonymous" />--%>
    <link rel="stylesheet" href="../SwitcherResources/Content/Simplex/bootstrap.min.css" crossorigin="anonymous" />
    <link rel="stylesheet" href="../Content/all.css" crossorigin="anonymous" />
    <link rel="stylesheet" href="../Content/generic/pageStyle.css" crossorigin="anonymous" />
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Content/AsignacionRet.js"></script>

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
        <asp:ScriptManager runat="server" ID="ScriptManager1" AsyncPostBackTimeout="300" />
        <uc1:cuInfoMsgbox runat="server" ID="cuInfoMsgbox1" />
        <header class="CLPageHeader">
            <dx:ASPxImage runat="server" ID="imagenLogo" CssClass="imagenLogo">  </dx:ASPxImage>
            <dx:ASPxLabel ID="lblNombrePagina" CssClass="titleHeader" runat="server" Text="Asignación Retornos" Font-Bold="true"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblVersion" CssClass="titleHeader version" runat="server" Text="Versión: 1.0 Beta" Font-Bold="true"></dx:ASPxLabel>
        </header>
        <div style="margin-left: 30px;">
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
                            Style='font-size: 17px' SettingsBootstrap-Sizing="Small" OnClick="btnGuaqrdar_Click">
                        </dx:BootstrapButton>

                        <dx:BootstrapButton ID="btnCancelar" runat="server" AutoPostBack="false" Text="" CssClasses-Icon="fas fa-window-close" ToolTip="Cancelar"
                            Style='font-size: 17px' SettingsBootstrap-Sizing="Small">
                        </dx:BootstrapButton>

                        <dx:BootstrapButton ID="btnBorrar" runat="server" AutoPostBack="false" Text="" CssClasses-Icon="fas fa-trash-alt" ToolTip="Borrar"
                            Style='font-size: 17px' SettingsBootstrap-Sizing="Small">
                        </dx:BootstrapButton>

                        <dx:BootstrapButton ID="btnBuscar" runat="server" AutoPostBack="false" Text="" CssClasses-Icon="fas fa-binoculars" OnClick="btnBuscar_Click" ToolTip="Buscar"
                            Style='font-size: 17px' SettingsBootstrap-Sizing="Small">
                        </dx:BootstrapButton>

                        <dx:BootstrapButton ID="btnExportar" runat="server" AutoPostBack="false" Text="" CssClasses-Icon="fas fa-print" ToolTip="Exportar"
                            Style='font-size: 17px' SettingsBootstrap-Sizing="Small">
                        </dx:BootstrapButton>
                    </div>
                </div>
            </div>
        </section>

        <section class="CLPageContent">
            <div class="">
             <dx:ASPxGridViewExporter ExportedRowType="Selected"  GridViewID="GV_agencias" ID="exportGrid" runat="server"></dx:ASPxGridViewExporter>
                     
                     <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                    <ContentTemplate>
              <asp:HiddenField ID="HidIdretorno" runat="server" ClientIDMode="Static" />
               <asp:HiddenField ID="HidEmpresa" runat="server" ClientIDMode="Static" />
                   
                <dx:BootstrapFormLayout ID="Frm_Retornos" runat="server" Width="100%">
                    <CssClasses Control="testClass" />
                    <Items>
                        
                          <dx:BootstrapLayoutGroup Caption="Retornos"    ColSpanMd="12" ShowCaption="True">
                              <CssClasses GroupHeader="testClass" />
                                <Items>
                                      <dx:BootstrapLayoutItem  ColSpanMd="12" Caption="" ShowCaption="False">  
                                          <ContentCollection>
                                     
                                            <dx:ContentControl>
                                                    
                                                       <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="gv_retornos"></dx:ASPxGridViewExporter>
                                         <dx:BootstrapGridView ID="gv_retornos" ClientInstanceName="gv_retornos" KeyFieldName="NumEntrega"  runat="server" Width="100%" AutoGenerateColumns="False"  OnDataBinding="gv_retornos_DataBinding"
                                             >
                                            <%-- <CssClasses Control="testClass"  CommandColumn="testClass" EditForm="testClass" HeaderRow="testClass" FilterRow="testClass" CommandColumnItem="testClass"    
                                                  PanelHeading="testClass"/>
                                            --%>
                                                 <Toolbars>
                                                     <dx:BootstrapGridViewToolbar>
                                                        <Items>
                                                            <dx:BootstrapGridViewToolbarItem Command="ExportToXls" />
                                                        </Items>
                                                    </dx:BootstrapGridViewToolbar>
                                                </Toolbars>
                                                    <SettingsPager PageSize="10">
                                                    </SettingsPager>
                                                      <SettingsAdaptivity AdaptivityMode="HideDataCellsWindowLimit" AllowOnlyOneAdaptiveDetailExpanded="true"
                                                    AllowHideDataCellsByColumnMinWidth="true">
                                                    </SettingsAdaptivity>
                                           <Settings ShowHeaderFilterButton="true" >
                                               
                                             </Settings>
                                                    <SettingsBehavior AllowSelectByRowClick="True" />
                                             <SettingsCommandButton RenderMode="Button">  
                                                <UpdateButton CssClass="btn-primary" />  
                                                <CancelButton CssClass="btn-info" />  
                                                </SettingsCommandButton>  
                                               <%-- <EditFormLayoutProperties>
                                                    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="768"></SettingsAdaptivity>
                                                </EditFormLayoutProperties>--%>
                                             <SettingsDataSecurity  AllowEdit="true"  />  
                                                  <%--<SettingsEditing  EditFormColumnSpan="3" Mode="PopupEditForm" />--%>
                                              
                                                    <Columns>
                                                        <dx:BootstrapGridViewCommandColumn ShowClearFilterButton="True" ShowEditButton="True" ShowNewButtonInHeader="False" VisibleIndex="0" ButtonRenderMode="Button" ButtonType="Button" SelectAllCheckboxMode="Page"  Width="3%"   />
                                                                                                             
                                                        <dx:BootstrapGridViewCommandColumn ShowSelectCheckbox="True"  VisibleIndex="1" Width="2%"/>
                                                        
                                                        <dx:BootstrapGridViewTextColumn ReadOnly="True" Caption="N. Entrega" Name="NumEntrega" FieldName="NumEntrega" Width="7%" VisibleIndex ="2">
                                                      <SettingsHeaderFilter Mode="CheckedList"></SettingsHeaderFilter>     
                                                      <SettingsEditForm Visible="True"  VisibleIndex="1"/>
                                                        </dx:BootstrapGridViewTextColumn>
                                                   
                                                         <%-- <dx:GridViewDataTextColumn ReadOnly="True" Caption="Fecha" VisibleIndex="4" FieldName="FechaCreacion" Width="5%" UnboundType="DateTime" >
                                                              <EditFormSettings Visible="True" VisibleIndex="2" />
                                                        </dx:GridViewDataTextColumn>--%>
                                                        
                                                        <dx:BootstrapGridViewDateColumn ReadOnly="True" Caption="Fecha" VisibleIndex="4" FieldName="FechaCreacion" Width="3%" >  
                                                                    <PropertiesDateEdit DisplayFormatString="dd-MM-yyyy" EditFormatString="dd-MM-yyyy"></PropertiesDateEdit>  
                                                            <SettingsEditForm Visible="True"  VisibleIndex="3"/>
                                                        </dx:BootstrapGridViewDateColumn>  
                                                        <dx:BootstrapGridViewTextColumn ReadOnly="True" Caption="Origen" VisibleIndex="5" FieldName="Poblacion" Width="15%">
                                                      <SettingsHeaderFilter Mode="CheckedList"></SettingsHeaderFilter>
                                                            <SettingsEditForm Visible="True"  VisibleIndex="4"/>
                                                        </dx:BootstrapGridViewTextColumn>
                                                        <dx:BootstrapGridViewTextColumn  ReadOnly="True" Caption="Destino" VisibleIndex="6" FieldName="Destino" Width="30%">
                                                         <SettingsEditForm Visible="True" VisibleIndex="5"/>
                                                            <SettingsHeaderFilter Mode="CheckedList"></SettingsHeaderFilter>
                                                        </dx:BootstrapGridViewTextColumn>
                                                        <%-- <dx:BootstrapGridViewMemoColumn  ReadOnly="True" Caption="Destino" VisibleIndex="6" FieldName="Destino" Visible="false">
                                                         <SettingsEditForm Visible="True" />
                                                             <SettingsHeaderFilter Mode="CheckedList"></SettingsHeaderFilter>
                                                        </dx:BootstrapGridViewMemoColumn>--%>
                                                      
                                                         <dx:BootstrapGridViewCheckColumn   ReadOnly="True"  Caption="Asignado" VisibleIndex="10"   FieldName="Asignado" Width="3%" >
                                                               <SettingsEditForm Visible="True"  VisibleIndex="8" />
                                                        </dx:BootstrapGridViewCheckColumn>
                                                        <dx:BootstrapGridViewMemoColumn  ReadOnly="True" Caption="Observaciones" VisibleIndex="9" FieldName="Observaciones" Visible="false" Width="30%">
                                                               <SettingsEditForm Visible="True" VisibleIndex="9"  />
                                                            
                                                        </dx:BootstrapGridViewMemoColumn>
                                                        
                                                        
                                                      <%--  <dx:GridViewDataTextColumn ReadOnly="True" Caption="Cliente" VisibleIndex="8" FieldName="Cliente">
                                                        </dx:GridViewDataTextColumn>--%>
                                                        
                                                       
                                                          
                                                        <dx:BootstrapGridViewTextColumn ShowInCustomizationDialog="True" VisibleIndex="11" Width="15%">
                                                            <DataItemTemplate>
                                                                <dx:BootstrapButton ID="btnVerAgencias" runat="server" AutoPostBack="false"  OnClick="btnVerAgencias_Click" Text="" CssClasses-Icon="fas fa-search-plus" ToolTip="Ver Agencias asignadas"
                                                                    Style='font-size: 12px' SettingsBootstrap-Sizing="Small">
                                                                <%--<ClientSideEvents Click="function(s, e) { VerAgencias();  }" />--%>
                                                                </dx:BootstrapButton>
                                                                <asp:LinkButton  ID="BtIDExpedicion" ClientIDMode="Static"  style="display:none;" Font-Size="Smaller" Text='<%# Eval("NumEntrega") %>' runat="server"></asp:LinkButton>
                                                                <dx:BootstrapButton ID="btnAsignarAgencia" runat="server" AutoPostBack="false" Text="" CssClasses-Icon="fas fa-dolly" ToolTip="Asignar Matricula"
                                                                    Style='font-size: 12px' SettingsBootstrap-Sizing="Small" OnClick="btnAsignarAgencia_Click">
                                                                 <%-- <ClientSideEvents Click="function(s, e) { AsignarMatriculas();  }" />--%>
                                                                </dx:BootstrapButton>
                                                            </DataItemTemplate>
                                                               <SettingsEditForm Visible="False" VisibleIndex="0" />
                                                        </dx:BootstrapGridViewTextColumn>
                                                    </Columns>
                                             <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="DataAware" />
                                                <Templates>
                                                        <EditForm>
                                                         
                                                                                
                                                                                <dx:BootstrapGridViewTemplateReplacement runat="server" ID="tr"
                                                                                    ReplacementType="EditFormEditors" />
                                                                      
                                                            <dx:BootstrapGridViewTemplateReplacement runat="server" id="tr2"
                                                              replacementtype="EditFormUpdateButton" />
                                                            <dx:BootstrapGridViewTemplateReplacement runat="server" id="tr3"
                                                              replacementtype="EditFormCancelButton" />
                                                        </EditForm>
                                                </Templates>
                                               
                                         
                                              <FormatConditions>
                                                  <dx:GridViewFormatConditionHighlight  FieldName="Asignado" Expression="[Asignado] = 'True'" Format="GreenFillWithDarkGreenText" ApplyToRow="True" />
                                                   
                                              </FormatConditions>
                                                </dx:BootstrapGridView>
                                          
                                               </dx:ContentControl>
                                                </ContentCollection>
                                                
                                          </dx:BootstrapLayoutItem>
                                    </Items>
                          </dx:BootstrapLayoutGroup>
                     
                          <dx:BootstrapLayoutGroup Caption="Agencias"    ColSpanMd="12" ShowCaption="True">
                                <Items>
                                      <dx:BootstrapLayoutItem ColSpanMd="12" Caption="Filtro" ShowCaption="False" Visible="true">                                                                                                     
                                       <ContentCollection>
                                        <dx:ContentControl>
                                            
                                            <dx:ASPxComboBox runat="server" ID="CB_Filtros" ClientInstanceName="cbFIltro"  Width="100%"
                                            AutoPostBack="True"    Caption=""  OnSelectedIndexChanged="CB_Filtros_SelectedIndexChanged" >
                                                <Items>
                                                <dx:ListEditItem Text="Todas" Value="-" selected="true" /> 
                                                <dx:ListEditItem Text="Grupo Agencias" Value="ZG" />
                                                <dx:ListEditItem Text="Grupo Autonomos" Value="ZT" />
                                                <dx:ListEditItem Text="Grupo Alfonso Gallardo" Value="ZL" />
                                                <dx:ListEditItem Text="Grupo Getafe Nacional" Value="ZN" />
                                                <dx:ListEditItem Text="Grupo Getafe Francia" Value="ZF" />
                                                <dx:ListEditItem Text="Grupo Lasao" Value="Z0" />
                                                <dx:ListEditItem Text="Grupo FerroMallas" Value="ZQ" />
                                                <dx:ListEditItem Text="Grupo Siderurgica" Value="ZS" />
                                                 </Items>
                                        </dx:ASPxComboBox>
                                                 
                                            </dx:ContentControl>
                                        </ContentCollection>
                                        </dx:BootstrapLayoutItem>
                                     
                                      <dx:BootstrapLayoutItem ColSpanMd="6" Caption="Agencias" ShowCaption="False">                                                                                                     
                                       <ContentCollection>
                                        <dx:ContentControl>
                                            
                                                    <dx:ASPxListBox ID="LB_Agencias" runat="server"  Width="100%"  EnableSelectAll="true" Height="200px" ClientInstanceName="lbAgencias" SelectionMode="CheckColumn"  ValueType="System.String" OnDataBinding="LB_Agencias_DataBinding">
                                                        <FilteringSettings ShowSearchUI="true" />
                                                        
                                                            <%--<ClientSideEvents SelectedIndexChanged="function(s, e) { ActualizaBotones(); }" />--%>
                                                    </dx:ASPxListBox>
                                            </dx:ContentControl>
                                        </ContentCollection>
                                        </dx:BootstrapLayoutItem>
                                    <dx:BootstrapLayoutItem  ColSpanMd="6" Caption="Agencias" ShowCaption="False">                                                                                                     
                                        <ContentCollection>
                                            <dx:ContentControl>
                                                 <div class="contentButtons">
                                                
                                                    <div>
                                                        <dx:BootstrapButton ID="BT_Asignar" Width="100%" runat="server"   ClientInstanceName="btasignar"  AutoPostBack="true" OnClick="BT_Asignar_Click" Text="Asignar"  ToolTip="Asignar" Style='font-size: 17px' SettingsBootstrap-Sizing="Small" >
                                                        <SettingsBootstrap Sizing="Small"></SettingsBootstrap>
                                   
                                   
                                                        </dx:BootstrapButton>
                                                    </div>
                                               </div>    
                                            </dx:ContentControl>
                                        </ContentCollection>
                                        </dx:BootstrapLayoutItem>
                                  
                                </Items>
                           </dx:BootstrapLayoutGroup>
                       
                             <dx:BootstrapLayoutGroup Caption="Asociación"  ColSpanMd="12" ShowCaption="True">
                                <Items>
                                    <dx:BootstrapLayoutItem  ColSpanMd="12" Caption="" ShowCaption="False">                                                                                                     
                                        <ContentCollection>
                                            <dx:ContentControl runat="server">
                                                    <asp:UpdatePanel runat="server" ID="updAgenciaasig">
                                                    <ContentTemplate>
                                                       
                                                      <dx:BootstrapGridView ID="GV_Asignacion" ClientInstanceName="gv_asignacion" OnDataBinding="GV_Asignacion_DataBinding" Width="100%" KeyFieldName="id" 
                                                    runat="server" OnCustomCallback="GV_Asignacion_CustomCallback">
                                                    
                                                         <SettingsAdaptivity AdaptivityMode="HideDataCellsWindowLimit"
                                                           AllowOnlyOneAdaptiveDetailExpanded="true"
                                                           AllowHideDataCellsByColumnMinWidth="true">
                                                        </SettingsAdaptivity>
                                                          <Settings ShowHeaderFilterButton="true" />
                                                      <Columns>
                                                        <dx:BootstrapGridViewTextColumn Caption="Num. Entrega" Name="NumEntrega" FieldName="numentrega" VisibleIndex="0">
                                                        </dx:BootstrapGridViewTextColumn>
                                                        <dx:BootstrapGridViewTextColumn Caption="Proveedor"  FieldName="proveedor"  VisibleIndex="1">
                                                        </dx:BootstrapGridViewTextColumn>
                                                        <dx:BootstrapGridViewTextColumn Caption="Origen" FieldName="origen" VisibleIndex="2">
                                                        </dx:BootstrapGridViewTextColumn>
                                                          <dx:BootstrapGridViewTextColumn Caption="Destino"  FieldName="destino" VisibleIndex="4">
                                                        </dx:BootstrapGridViewTextColumn>
                                                        
                                                        <dx:BootstrapGridViewTextColumn Caption="Agencia"  FieldName="nombreagencia" VisibleIndex="6">
                                                        </dx:BootstrapGridViewTextColumn>
                                                         
                                                        
                                                    </Columns>
                                                
                                                    </dx:BootstrapGridView> 
                                                </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </dx:ContentControl>
                                        </ContentCollection>
                                        </dx:BootstrapLayoutItem>
                                </Items>
                           </dx:BootstrapLayoutGroup>
                            
                        </Items>
                    </dx:BootstrapFormLayout>
                      

                    </ContentTemplate>
                </asp:UpdatePanel>                      
                <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                    <ContentTemplate>
                    <dx:BootstrapPopupControl ID="PUp_VerAgencias" ClientInstanceName="PUp_VerAgencias" runat="server"  Width="600px" Height="600px"  
                    PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"  AllowDragging="True" CloseAction="CloseButton" CloseOnEscape="True" Modal="True"
                    PopupAnimationType="None" EnableViewState="False" HeaderText="Agencias Asignadas" >
                    <ClientSideEvents Shown=" function(s, e){Gv_AgenciasAsignadas.PerformCallback();}"  CloseButtonClick="function(s, e) {  Refrescaretornos();}" />
                    <ContentCollection>
                        <dx:ContentControl>
                          <dx:BootstrapButton ID="BT_Quitartodo" Width="50%" runat="server"   ClientInstanceName="btquitartodo"  AutoPostBack="true" OnClick="BT_Quitartodo_Click" Text="Quitar todo"  ToolTip="Quitar todo" Style='font-size: 17px' SettingsBootstrap-Sizing="Small" >
                               <SettingsBootstrap Sizing="Small"></SettingsBootstrap>
                                </dx:BootstrapButton>
                            </p>
                                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter2" runat="server" GridViewID="Gv_AgenciasAsignadas"></dx:ASPxGridViewExporter>
                             <dx:BootstrapGridView ID="Gv_AgenciasAsignadas" ClientInstanceName="Gv_AgenciasAsignadas" runat="server" OnCustomCallback="Gv_AgenciasAsignadas_CustomCallback" OnDataBinding="Gv_AgenciasAsignadas_DataBinding" Width="100%" AutoGenerateColumns="False">
                                 
                                 <CssClasses Control="testClass"  CommandColumn="testClass" EditForm="testClass" HeaderRow="testClass" FilterRow="testClass" CommandColumnItem="testClass" IconHeaderFilter="iconClass"  IconFilterRowButton="iconClass" />

                                 <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                                     <Toolbars>
                                                     <dx:BootstrapGridViewToolbar>
                                                        <Items>
                                                            <dx:BootstrapGridViewToolbarItem Command="ExportToXls" />
                                                        </Items>
                                                    </dx:BootstrapGridViewToolbar>
                                                </Toolbars>
                                 <Columns>
                                     <dx:BootstrapGridViewTextColumn Caption="ID Agencia" FieldName="AeIdAgencia" VisibleIndex="0">
                                     </dx:BootstrapGridViewTextColumn>
                                     <dx:BootstrapGridViewTextColumn Caption="Nombre Agencia" FieldName="AeNombreAgencia"  VisibleIndex="1">
                                     </dx:BootstrapGridViewTextColumn>
                                      <dx:BootstrapGridViewTextColumn ShowInCustomizationDialog="True" VisibleIndex="11" Width="15%">
                                                            <DataItemTemplate>
                                      <dx:BootstrapButton ID="btn_quitaragencia" runat="server" AutoPostBack="false" Text="" CssClasses-Icon="fas fa-trash-alt" ToolTip="Quitar Agencia"
                                                                    Style='font-size: 12px' SettingsBootstrap-Sizing="Small" OnClick="btn_quitaragencia_Click" >
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
                         </ContentTemplate>
                </asp:UpdatePanel>  
                   <asp:UpdatePanel runat="server" ID="UpdatePanel3">
                    <ContentTemplate>
                 <dx:BootstrapPopupControl ID="Pup_AsignarAgencias" ClientInstanceName="puasignaragencias" runat="server"  Width="1200px" Height="800px"
                      PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"  AllowDragging="True" CloseAction="CloseButton" CloseOnEscape="True" Modal="True"
                     PopupAnimationType="Fade" EnableViewState="False"  HeaderText="Asignar matricula"  EnableClientSideAPI="True"> 
                                  
                       <ClientSideEvents CloseButtonClick="function(s, e) {
	                            Refrescaretornos();}" />
                    <ContentCollection>
                                              <dx:ContentControl>
                            
                        </dx:ContentControl>
                    </ContentCollection>

                </dx:BootstrapPopupControl>
                         </ContentTemplate>
                        <Triggers>  
            <asp:PostBackTrigger ControlID="btnExportar" />  
        </Triggers>  
                </asp:UpdatePanel>  
                   
           <dx:ASPxLoadingPanel ID="LoadingPanel" runat="server" ClientInstanceName="LoadingPanel" Modal="true" />
            </div>
        </section>

        <footer class="CLPageFooter">
            © Derechos Reservados 2020-2021 CL Grupo Industrial Todos los Derechos Reservados.
        </footer>
    </form>

</body>
</html>
