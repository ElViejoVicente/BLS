<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RetornoMovil.aspx.cs" Inherits="GPB.Web.RetornoMovil" %>

<%@ Register Src="~/Controles/Usuario/InfoMsgBoxMovil.ascx" TagPrefix="uc1" TagName="cuInfoMsgboxMovil" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v25.1, Version=25.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="user-scalable=0, width=device-width, initial-scale=1.0, maximum-scale=1.0" />
    
    <link rel="stylesheet" href="../SwitcherResources/Content/Simplex/bootstrap.min.css" crossorigin="anonymous" />
    <link rel="stylesheet" href="Content/all.css" crossorigin="anonymous" />
    <link rel="stylesheet" href="Content/generic/StylesMovil.css" crossorigin="anonymous" />
    <link rel="stylesheet" type="text/css" href="Content/ContentMovil.css" />

    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>

    <script>
        $(document).ready(function () {

        });

        function iconMaxMin() {
            var i = $('#iconCollapse');
            i.attr('class', i.hasClass('fas fa-angle-double-down') ? 'fas fa-angle-double-up' : i.attr('data-original'));
        }
        
        function AsignarRetorno() {
            parent.document.getElementById('content').src = "Logistica/DetalleRetorno.aspx";
        }
         function Refrescaretornos(s, e)
    {
        __doPostBack("Refrescaretornos", "true");
        Callback.PerformCallback();
    }
    </script>

</head>
<body>
   
    <form id="frmPageMovil" runat="server" class="Principal">
      <uc1:cuInfoMsgboxMovil runat="server" ID="cuInfoMsgboxMovil" />
        
        <header class="CLPageHeader">
            <dx:ASPxImage runat="server" ID="imgLogo" CssClass="imagenLogo" ImageUrl="imagenes/menu/usuarioLarge.ico" ToolTip="Grupo Gallardo">
            </dx:ASPxImage>
            <dx:ASPxLabel ID="lblNombrePagina" CssClass="titleHeader" runat="server" Text="Página Inicial" Font-Bold="true"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblVersion" CssClass="titleHeader version" runat="server" Text="Versión: 1.0 Beta" Font-Bold="true"></dx:ASPxLabel>
        </header>
        
        <section class="CLPageContent">
            <div class="">
                <dx:ASPxPanel ID="Pnl_retornos" runat="server" Width="100%">
                    <PanelCollection>
                        <dx:PanelContent>
                            <contentcollection>
                              
                            <table style="width:100%; height:50px;">
                                <tr>
                                    <td>
                                        <dx:ASPxLabel  id="Label1" Text="Mis Retornos:" runat="server"></dx:ASPxLabel>
                                        <dx:ASPxCheckBox ID="chkMisRet" runat="server" Checked="false" ToggleSwitchDisplayMode="Always" Width="70"
                                            OnCheckedChanged="chkMisRet_CheckedChanged" AutoPostBack="true" Height="20px" Theme="iOS">
                                        </dx:ASPxCheckBox>
                                        <dx:ASPxLabel  id="lblExpEntregada" Text="Retornos Entregados:" runat="server"></dx:ASPxLabel>
                                         <dx:ASPxCheckBox ID="chkRetEntragada" runat="server" Checked="false" ToggleSwitchDisplayMode="Always" Width="50" 
                                            OnCheckedChanged="chkRetEntragada_CheckedChanged" AutoPostBack="true" Height="20px" Theme="iOS">
                                        </dx:ASPxCheckBox>
                                    </td>
                                    <td>
                                       
                                    </td>
                                </tr>
                            </table>
                           </contentcollection>
                             <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="Gv_expedicion_desk"></dx:ASPxGridViewExporter>
                            <dx:BootstrapGridView ID="Gv_retornos_desk" runat="server" OnDataBinding="Gv_retornos_desk_DataBinding" AutoGenerateColumns="False" OnDataBound="Gv_retornos_desk_DataBound" KeyFieldName="MiIdRetorno">
	                            <SettingsAdaptivity AdaptivityMode="HideDataCellsWindowLimit"
		                            AllowOnlyOneAdaptiveDetailExpanded="true"
		                            AllowHideDataCellsByColumnMinWidth="true">
	                            </SettingsAdaptivity>
                                <Settings ShowHeaderFilterButton="true" />
	                            <SettingsPager PageSize="20">
	                            </SettingsPager>
	                            <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True"></SettingsBehavior>
                                   <Toolbars>
                                    <dx:BootstrapGridViewToolbar>
                                        <Items>
                                            <dx:BootstrapGridViewToolbarItem Command="ExportToXls" />
                                        </Items>
                                    </dx:BootstrapGridViewToolbar>
                                </Toolbars>
	                            <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
	                            <Columns>
		                            <dx:BootstrapGridViewTextColumn Caption="Retorno" FieldName="MiIdRetorno" VisibleIndex="0" Visible="false">
		                            </dx:BootstrapGridViewTextColumn>
		                            <dx:BootstrapGridViewTextColumn Caption="Num Entreg" FieldName="MiNumEntrega" VisibleIndex="1" Width="5%">
		                            </dx:BootstrapGridViewTextColumn>
                                     <dx:BootstrapGridViewTextColumn Caption="Empresa" FieldName="MsNombreEmpresa" VisibleIndex="2" Width="8%">
		                            </dx:BootstrapGridViewTextColumn>
		                            <dx:BootstrapGridViewTextColumn Caption="Origen" FieldName="MsOrigen" VisibleIndex="3" Width="8%">
		                            </dx:BootstrapGridViewTextColumn>
                                    <dx:BootstrapGridViewTextColumn Caption="Centro Carga" FieldName="MsCentroCarga" VisibleIndex="4" Width="8%">
		                            </dx:BootstrapGridViewTextColumn>
		                            <dx:BootstrapGridViewTextColumn Caption="Destino" FieldName="MsDestino" VisibleIndex="5" Width="10%">
		                            </dx:BootstrapGridViewTextColumn>
                                    
		                           
		                            <dx:BootstrapGridViewTextColumn Caption="Agencia" FieldName="MsNombreAgencia" VisibleIndex="9" Visible="false" Width="12%">
		                            </dx:BootstrapGridViewTextColumn>
		                            <dx:BootstrapGridViewTextColumn Caption="Matricula" FieldName="MsMatricula" VisibleIndex="10" Visible="false" Width="10%">
		                            </dx:BootstrapGridViewTextColumn>
                                    <dx:BootstrapGridViewTextColumn Caption="Estado" FieldName="MsDesEstadoGesag" VisibleIndex="11" Visible="false" Width="10%">
		                            </dx:BootstrapGridViewTextColumn>
                                     <dx:BootstrapGridViewTextColumn VisibleIndex="12" Width="5%">
                                        <DataItemTemplate>
                                            <asp:LinkButton ID="BtIDExpedicion" ClientIDMode="Static" Style="display: none;" Font-Size="Smaller" Text='<%# Eval("MiIdRetorno") %>' runat="server"></asp:LinkButton>
                                            <dx:BootstrapButton ID="btnAsignarAgencia" runat="server" AutoPostBack="false" Text="" CssClasses-Icon="fas fa-dolly" ToolTip="Asignar Retorno"
                                                Style='font-size: 17px' SettingsBootstrap-Sizing="Small" OnClick="btnAsignarAgencia_Click">
                                            </dx:BootstrapButton>
                                        </DataItemTemplate>
                                    </dx:BootstrapGridViewTextColumn>
                                    <dx:BootstrapGridViewTextColumn Caption="" VisibleIndex="13">
                                        <DataItemTemplate>
                                            <asp:LinkButton ID="BtIDExpedicionSL" ClientIDMode="Static" Style="display: none;" Font-Size="Smaller" Text='<%# Eval("MiIdRetorno") %>' runat="server"></asp:LinkButton>
                                            <dx:BootstrapButton ID="btnDetalleExp" runat="server" AutoPostBack="false" Text="Detalle" CssClasses-Icon="fas fa-info" ToolTip="Ver Detalle retorno"
                                                Style='font-size: 17px' SettingsBootstrap-Sizing="Small" OnClick="btnDetalleExp_Click">
                                            </dx:BootstrapButton>
                                        </DataItemTemplate>
                                    </dx:BootstrapGridViewTextColumn>
                                    <dx:BootstrapGridViewTextColumn Caption="" VisibleIndex="14" HorizontalAlign="Center">
                                        <DataItemTemplate>
                                            <asp:LinkButton ID="BtIDMarcarEntrega" ClientIDMode="Static" Style="display: none;" Font-Size="Smaller" Text='<%# Eval("MiIdRetorno") %>' runat="server"></asp:LinkButton>
                                            <dx:BootstrapButton ID="btnMarcarEntrega" runat="server" AutoPostBack="false" Text="Entregado" CssClasses-Icon="fas fa-dolly-flatbed" ToolTip="Marcar como entregado"
                                                Style='font-size: 17px' SettingsBootstrap-Sizing="Small" OnClick="btnMarcarEntrega_Click">
                                                 <ClientSideEvents Click = "function (s, e) { e.processOnServer = confirm('desea marcar como entegada este retorno?');  }" />
                                            </dx:BootstrapButton>
                                        </DataItemTemplate>
                                    </dx:BootstrapGridViewTextColumn>
		                         


	                            </Columns>
                                                                    <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="DataAware" />
                            </dx:BootstrapGridView>



                            <dx:BootstrapCardView ID="Gv_Retornos" runat="server" OnDataBinding="Gv_Retornos_DataBinding" AutoGenerateColumns="False" OnDataBound="Gv_Retornos_DataBound">
                                 <Settings ShowHeaderFilterButton="true" ShowHeaderPanel="true"/>
                             
                                <SettingsLayout CardColSpanMd="4" CardColSpanSm="6" />
                                <SettingsBehavior AllowSelectByCardClick="true" />
                             
                                <Columns>
                                    <dx:BootstrapCardViewTextColumn Caption="Retorno" FieldName="MiIdRetorno" VisibleIndex="0" Visible="false">
                                          <Settings AllowHeaderFilter="False"  AllowFilterBySearchPanel="False"  AllowSort="False" />
                                         
                                    </dx:BootstrapCardViewTextColumn>
                                    <dx:BootstrapCardViewTextColumn Caption="Num Entrega" FieldName="MiNumEntrega" VisibleIndex="1">
                                          <Settings AllowHeaderFilter="False"  AllowFilterBySearchPanel="False"  AllowSort="False" />
                                    </dx:BootstrapCardViewTextColumn>
                                    <dx:BootstrapCardViewTextColumn Caption="Empresa" FieldName="MsNombreEmpresa" VisibleIndex="2">
                                           <Settings AllowHeaderFilter="True" />
                                    </dx:BootstrapCardViewTextColumn>
                                    <dx:BootstrapCardViewTextColumn Caption="Origen" FieldName="MsOrigen" VisibleIndex="2">
                                           <Settings AllowHeaderFilter="True" />
                                    </dx:BootstrapCardViewTextColumn>
                                    <dx:BootstrapCardViewTextColumn Caption="Destino" FieldName="MsDestino" VisibleIndex="3">
                                    </dx:BootstrapCardViewTextColumn>
                                    <dx:BootstrapCardViewTextColumn Caption="Centro Carga" FieldName="MsCentroCarga" VisibleIndex="3">
                                          <Settings AllowHeaderFilter="False"  AllowFilterBySearchPanel="False"  AllowSort="False" />
		                            </dx:BootstrapCardViewTextColumn>
                                   
                                    <dx:BootstrapCardViewTextColumn Caption="Agencia" FieldName="MsNombreAgencia" VisibleIndex="6" Visible="false">
                                          <Settings AllowHeaderFilter="False"  AllowFilterBySearchPanel="False"  AllowSort="False" />
                                    </dx:BootstrapCardViewTextColumn>
                                    <dx:BootstrapCardViewTextColumn Caption="Matricula" FieldName="MsMatricula" VisibleIndex="7" Visible="false">
                                          <Settings AllowHeaderFilter="False"  AllowFilterBySearchPanel="False"  AllowSort="False" />
                                    </dx:BootstrapCardViewTextColumn>
                                    <dx:BootstrapCardViewTextColumn VisibleIndex="8">
                                        <DataItemTemplate>
                                            <asp:LinkButton ID="BtIDExpedicion" ClientIDMode="Static" Style="display: none;" Font-Size="Smaller" Text='<%# Eval("MiIdRetorno") %>' runat="server"></asp:LinkButton>
                                            <dx:BootstrapButton ID="btnAsignarAgencia" runat="server" AutoPostBack="false" Text="" CssClasses-Icon="fas fa-dolly" ToolTip="Asignar Retorno"
                                                Style='font-size: 17px' SettingsBootstrap-Sizing="Small" OnClick="btnAsignarAgencia_Click">
                                            </dx:BootstrapButton>
                                        </DataItemTemplate>
                                    </dx:BootstrapCardViewTextColumn>
                                    <dx:BootstrapCardViewTextColumn VisibleIndex="9">
                                        <DataItemTemplate>
                                            <asp:LinkButton ID="BtIDExpedicionSL" ClientIDMode="Static" Style="display: none;" Font-Size="Smaller" Text='<%# Eval("MiIdRetorno") %>' runat="server"></asp:LinkButton>
                                            <dx:BootstrapButton ID="btnDetalleExp" runat="server" AutoPostBack="false" Text="Detalle" CssClasses-Icon="fas fa-info" ToolTip="Ver Detalle retorno"
                                                Style='font-size: 17px' SettingsBootstrap-Sizing="Small" OnClick="btnDetalleExp_Click">
                                            </dx:BootstrapButton>
                                        </DataItemTemplate>
                                    </dx:BootstrapCardViewTextColumn>
                                    <dx:BootstrapCardViewTextColumn Caption="Marcar expediciòn como Entregada" VisibleIndex="10" HorizontalAlign="Center">
                                        <DataItemTemplate>
                                            <asp:LinkButton ID="BtIDMarcarEntrega" ClientIDMode="Static" Style="display: none;" Font-Size="Smaller" Text='<%# Eval("MiIdRetorno") %>' runat="server"></asp:LinkButton>
                                            <dx:BootstrapButton ID="btnMarcarEntrega" runat="server" AutoPostBack="false" Text="Entregado" CssClasses-Icon="fas fa-dolly-flatbed" ToolTip="Marcar como entrega"
                                                Style="font-size: 17px" SettingsBootstrap-Sizing="Small" OnClick="btnMarcarEntrega_Click">
                                                <ClientSideEvents Click = "function (s, e) { e.processOnServer = confirm('desea marcar como entegada este retorno?');  }" />
                                            </dx:BootstrapButton>

                                        </DataItemTemplate>
                                    </dx:BootstrapCardViewTextColumn>
                                </Columns>
                                <SettingsPager ItemsPerPage="6" NumericButtonCount="4" EnableAdaptivity="true"></SettingsPager>
                            </dx:BootstrapCardView>

                            <dx:ASPxPopupControl ID="Pup_AsignarAgencias" ClientInstanceName="puasignaragencias" runat="server" Width="600px" Height="600px"
                                PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowDragging="True" CloseAction="CloseButton"  CloseOnEscape="false" Modal="True" ShowCloseButton="false"
                                PopupAnimationType="None" EnableViewState="False">
                                <ContentCollection>
                                    <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                                    </dx:PopupControlContentControl>
                                </ContentCollection>

                            </dx:ASPxPopupControl>
                             <dx:BootstrapPopupControl ID="PUp_Detalle" ClientInstanceName="PUp_Detalle" runat="server"  Width="600px" Height="600px"   OnWindowCallback="PUp_Detalle_WindowCallback"
                                PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ShowCloseButton="false"  AllowDragging="True" CloseAction="None"  Modal="True"
                                PopupAnimationType="Fade" EnableViewState="False" HeaderText="Detalle de Expedición "  EnableClientSideAPI="True">
                                
                                <ContentCollection>
                                     <dx:ContentControl>
                                     <dx:BootstrapFormLayout ID="Frm_Asignacion" runat="server" LayoutType="Vertical" >
                                        <Items>
                                            <dx:BootstrapLayoutItem Caption="Retorno" ColSpanLg="6" ColSpanMd="6">
                                                <ContentCollection>
                                                    <dx:ContentControl>
                                                        <dx:BootstrapTextBox ID="Txt_retorno" runat="server" NullText="número de expedición" Enabled="false" />
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:BootstrapLayoutItem>
						
						
						                    <dx:BootstrapLayoutItem Caption="Sociedad FI" ColSpanLg="6" ColSpanMd="6">
                                                <ContentCollection>
                                                    <dx:ContentControl>
                                                        <dx:BootstrapTextBox ID="Txt_sociedad" runat="server" NullText="Sociedad" Enabled="false"/>
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:BootstrapLayoutItem>
						
						
						                    <dx:BootstrapLayoutItem Caption="Origen" ColSpanLg="6" ColSpanMd="6">
                                                <ContentCollection>
                                                    <dx:ContentControl>
                                                        <dx:BootstrapTextBox ID="Txt_origen" runat="server" NullText="Origen" Enabled="false"/>
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:BootstrapLayoutItem>
                                              <dx:BootstrapLayoutItem Caption="Centro Carga" ColSpanLg="6" ColSpanMd="6">
                                                <ContentCollection>
                                                    <dx:ContentControl>
                                                        <dx:BootstrapTextBox ID="Txt_centrocarga" runat="server" NullText="Centro Carga" Enabled="false"/>
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
                                            <dx:BootstrapLayoutItem Caption="Unidad Transporte" ColSpanLg="4" ColSpanMd="6">
                                                <ContentCollection>
                                                    <dx:ContentControl>
                                                        <dx:BootstrapTextBox ID="Txt_unidadtransporte" runat="server" NullText="Destino" Enabled="false"/>
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:BootstrapLayoutItem>
                                             
                                              <dx:BootstrapLayoutItem ShowCaption="False" ColSpanLg="10" ColSpanMd="10">
                                                <ContentCollection>
                                                    <dx:ContentControl>
                                                         <dx:ASPxLabel  ID="lblCapturar" Text="Introducir los siguientes campos:" runat="server"></dx:ASPxLabel>
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:BootstrapLayoutItem>
                       
                                            <dx:BootstrapLayoutItem Caption="Nombre Transportista" ColSpanLg="12" ColSpanMd="6">
                                                <ContentCollection>
                                                    <dx:ContentControl>
                                                        <%--<dx:BootstrapTextBox ID="Txt_transportista" runat="server" NullText="Nombre Transportista" />--%>
                                                         <dx:BootstrapComboBox ID="CB_Transportistas" OnDataBinding="CB_Transportistas_DataBinding" runat="server"></dx:BootstrapComboBox>
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:BootstrapLayoutItem>

						                    <dx:BootstrapLayoutItem Caption="Matricula" ColSpanLg="6" ColSpanMd="6">
                                                <ContentCollection>
                                                    <dx:ContentControl>
                                                        <dx:BootstrapTextBox ID="txt_matricula" OnTextChanged="txt_matricula_TextChanged1" AutoPostBack="true" runat="server" NullText="Matricula" />
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:BootstrapLayoutItem>
						
						
						                    <dx:BootstrapLayoutItem Caption="Matricula remolque" ColSpanLg="6" ColSpanMd="6">
                                                <ContentCollection>
                                                    <dx:ContentControl>
                                                        <dx:BootstrapTextBox ID="txt_matricularemolque" runat="server" NullText="Matricula remolque" />
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:BootstrapLayoutItem>
                                               <dx:BootstrapLayoutItem Caption="Nº Permiso especial" ColSpanLg="12" ColSpanMd="6">
                                                <ContentCollection>
                                                    <dx:ContentControl runat="server">
                                                        <dx:BootstrapTextBox ID="Txt_numpermisoespecial" runat="server" NullText="Nº Permiso especial" Enabled="false" >
                                                          </dx:BootstrapTextBox>
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                        </dx:BootstrapLayoutItem>
                                              <dx:BootstrapLayoutItem Caption="Fecha Prevista Carga"  ColSpanLg="4" ColSpanMd="6">
                                                  <ContentCollection>
                                                    <dx:ContentControl runat="server">
                                                        <dx:BootstrapDateEdit ID="Txt_Fechaprevcarga" runat="server" Enabled="false"></dx:BootstrapDateEdit>
                                    
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:BootstrapLayoutItem>
                                            <dx:BootstrapLayoutItem Caption="Fecha Prevista Descarga"  ColSpanLg="4" ColSpanMd="6">
                                                <ContentCollection>
                                                    <dx:ContentControl runat="server">
                                                       <dx:BootstrapDateEdit ID="Txt_Fechaprevdescarga" runat="server" Enabled="false"></dx:BootstrapDateEdit>
                                    
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:BootstrapLayoutItem>
						
                                            <dx:BootstrapLayoutItem ShowCaption="False" HorizontalAlign="left">
                                                <ContentCollection>
                                                    <dx:ContentControl>
                                                          <%--<dx:BootstrapButton ID="btnCancel" Text="Cerrar" AutoPostBack="true" CausesValidation="false" runat="server" OnClick="btnCancel_Click" CssClasses-Control="btn-primary bg-primary border-primary">--%>
                               <%--                             <SettingsBootstrap RenderOption="Secondary" />--%>
                                                        <%--</dx:BootstrapButton>--%>
                                                        <dx:BootstrapButton ID="btnGuardar" Text="Guardar" AutoPostBack="true" CausesValidation="false" runat="server" OnClick="btnGuardar_Click" CssClasses-Control="btn-success bg-success border-success">
                                                            <%--<SettingsBootstrap RenderOption="Primary" />--%>
                                                        </dx:BootstrapButton>
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:BootstrapLayoutItem>
                                        </Items>
                                    </dx:BootstrapFormLayout>
                                    </dx:ContentControl>
                                </ContentCollection>
                                  <ClientSideEvents CloseUp="function(s, e) { s.PerformCallback(); }" />  
                            </dx:BootstrapPopupControl>
                              <dx:BootstrapPopupControl ID="Pup_AsignarMatricula" ClientInstanceName="puasignaragencias" runat="server"  Width="1200px" Height="800px"
                      PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"  AllowDragging="True" CloseAction="CloseButton" CloseOnEscape="True" Modal="True"
                     PopupAnimationType="Fade" EnableViewState="False"  HeaderText="Asignar matricula"  EnableClientSideAPI="True"> 
                                  
                       <ClientSideEvents CloseButtonClick="function(s, e) {
	                            Refrescaretornos();}" />
                    <ContentCollection>
                                              <dx:ContentControl>
                            
                        </dx:ContentControl>
                    </ContentCollection>

                </dx:BootstrapPopupControl>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </div>
        </section>

        <footer class="CLPageFooter">
            © Derechos Reservados 2020-2021 CL Grupo Industrial Todos los Derechos Reservados.
        </footer>
    </form>

</body>
</html>
