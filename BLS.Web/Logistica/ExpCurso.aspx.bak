<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExpCurso.aspx.cs" Inherits="GPB.Web.ExpCurso" %>
<%@ Register Src="~/Controles/Usuario/InfoMsgBox.ascx" TagPrefix="uc1" TagName="cuInfoMsgbox" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v25.1, Version=25.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>


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
         <asp:ScriptManager runat="server" ID="ScriptManager1" AsyncPostBackTimeout="300" />
        <uc1:cuInfoMsgbox runat="server" ID="cuInfoMsgbox1" />
        <header class="CLPageHeader">
              
               <dx:ASPxImage runat="server" ID="imagenLogo" CssClass="imagenLogo" ToolTip="Grupo Gallardo">  </dx:ASPxImage>
         
            <dx:ASPxLabel ID="lblNombrePagina" CssClass="titleHeader" runat="server" Text="Expediciones En curso" Font-Bold="true"></dx:ASPxLabel>
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
                    <dx:ASPxCallback ID="Callback" runat="server" ClientInstanceName="Callback">
                    <ClientSideEvents CallbackComplete="function(s, e) { LoadingPanel.Hide(); }" />
                </dx:ASPxCallback>
                  <asp:HiddenField ID="HidIdexpedicion" runat="server" ClientIDMode="Static" />
             
                        <%--  <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" ShowCollapseButton="true" Width="100px" HeaderText="Opciones de consulta:" View="GroupBox">
                    <PanelCollection>
                        <dx:PanelContent>
                            <table>
                                <tr>
                                    <td>
                                        <dx:ASPxComboBox runat="server" ID="cbSocieades" ClientInstanceName="cbSocieades"  Width="200px"
                                            AutoPostBack="True" OnDataBinding="cbSocieades_DataBinding" OnValueChanged="cbSocieades_ValueChanged" Caption="Sociedad:" >
                                        </dx:ASPxComboBox>
                                    </td>
                                   
                                </tr>
                            </table>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxRoundPanel>--%>
                   <asp:UpdatePanel runat="server" ID="updControlesIng">
                  <ContentTemplate>
                <dx:ASPxPanel ID="Pnl_Expedicione_log" runat="server" Width="100%">
                    <PanelCollection>
                        <dx:PanelContent>
                            <dx:ASPxGridViewExporter ID="ASPxGridViewExporter3" runat="server" GridViewID="GV_Expediciones"></dx:ASPxGridViewExporter>
                            <dx:BootstrapGridView ID="GV_Expediciones" runat="server"  ClientIDMode="Static" Width="100%" OnDataBinding="GV_Expediciones_DataBinding" AutoGenerateColumns="False" KeyFieldName="exId" >
                                <CssClasses Control="testClass"  CommandColumn="testClass" EditForm="testClass" HeaderRow="testClass" FilterRow="testClass" CommandColumnItem="testClass"  />
                                 <SettingsAdaptivity AdaptivityMode="HideDataCellsWindowLimit"        AllowOnlyOneAdaptiveDetailExpanded="true"  AllowHideDataCellsByColumnMinWidth="true">
                                </SettingsAdaptivity>
                                <SettingsCustomizationDialog Enabled="true"  ShowColumnChooserPage="true" /> 
                                <SettingsPager PageSize="20">
                                </SettingsPager>
                                <Settings ShowHeaderFilterButton="true" />
                                <SettingsBehavior AllowSelectByRowClick="True" />
                                    <Toolbars>
                                      <dx:BootstrapGridViewToolbar>
                                        <Items>
                                            <dx:BootstrapGridViewToolbarItem Command="ShowCustomizationDialog" />
                                            <dx:BootstrapGridViewToolbarItem Command="ExportToXls" />
                             
                                        </Items>
                                    </dx:BootstrapGridViewToolbar>
                                </Toolbars>
                                <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                                <Columns>
                                    <dx:BootstrapGridViewTextColumn Caption="Expedición"  FieldName="ExNumexpedicion"    VisibleIndex="0" Width="10%">
                                    </dx:BootstrapGridViewTextColumn>
                                    <dx:BootstrapGridViewTextColumn Caption="Origen" FieldName="ExOrigen"   VisibleIndex="1" Width="10%">
                                    </dx:BootstrapGridViewTextColumn>
                                    <dx:BootstrapGridViewTextColumn Caption="Centro carga" FieldName="ExCentroCarga"   VisibleIndex="2" Width="10%">
                                    </dx:BootstrapGridViewTextColumn>
                                    <dx:BootstrapGridViewTextColumn Caption="Destino" FieldName="ExDestino" VisibleIndex="3" Width="10%">
                                    </dx:BootstrapGridViewTextColumn>
                                    <dx:BootstrapGridViewTextColumn Caption="Longitud"   FieldName="ExLongitud"  VisibleIndex="4" Width="10%">
                                    </dx:BootstrapGridViewTextColumn>
                                    <dx:BootstrapGridViewTextColumn Caption="Agencia" FieldName="ExNombreAgencia"   VisibleIndex="5" Width="10%">
                                    </dx:BootstrapGridViewTextColumn>
                                    <dx:BootstrapGridViewTextColumn Caption="Matricula" FieldName="ExMatricula"   VisibleIndex="6" Width="10%">
                                    </dx:BootstrapGridViewTextColumn>
                                      <dx:BootstrapGridViewTextColumn Caption="Fecha Creacion" FieldName="ExFechaCreaExp"  VisibleIndex="7" Width="10%">
                                    </dx:BootstrapGridViewTextColumn>
                                   <dx:BootstrapGridViewTextColumn Caption="Fecha Asignacion" FieldName="ExFechaAsignacion"  VisibleIndex="8" Width="10%">
                                    </dx:BootstrapGridViewTextColumn>
                                    <dx:BootstrapGridViewTextColumn Caption="Fecha Matricula" FieldName="ExFechaCreaExp"  VisibleIndex="9" Width="10%">
                                    </dx:BootstrapGridViewTextColumn>
                                     <dx:BootstrapGridViewTextColumn Caption="Estado GESAG" FieldName="ExDescripcionEstado" VisibleIndex="10" Visible="false" Width="10%">
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
                       </ContentTemplate>
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
