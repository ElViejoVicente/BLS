<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignacionMatRet.aspx.cs" Inherits="GPB.Web.AsignacionMatRet" %>

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
    <script src="../Content/AsignacionMatricula.js"></script>
    

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script>
        function iconMaxMin() {
            var i = $('#iconCollapse');
            i.attr('class', i.hasClass('fas fa-angle-double-down') ? 'fas fa-angle-double-up' : i.attr('data-original'));
        }
          function Agencia_RowDblClick(s, e) {
            __doPostBack("seleccionar", "true");
          
        }


    </script>
</head>

<body>
    <form id="frmPage" runat="server" class="Principal">
        <uc1:cuInfoMsgbox runat="server" ID="cuInfoMsgbox1"  OnRespuestaClick="cuInfoMsgbox1_RespuestaClick"/>
        <%--<header id="header" runat="server" class="CLPageHeader">
            <dx:ASPxImage runat="server" ID="imagenLogo" CssClass="imagenLogo">  </dx:ASPxImage>
            <dx:ASPxLabel ID="lblNombrePagina" CssClass="titleHeader" runat="server" Text="" Font-Bold="true"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblVersion" CssClass="titleHeader version" runat="server" Text="Versión: 1.0 Beta" Font-Bold="true"></dx:ASPxLabel>
        </header>--%>
      
         <div style="margin-left: 30px;">
            <a class="btn-box-tool" data-toggle="collapse" data-target="#controles" role="button" onclick="iconMaxMin()" aria-expanded="false" aria-controls="controles"><i id="iconCollapse" data-original="fas fa-angle-double-down" class="fas fa-angle-double-down"></i></a>
        </div>
        <section class="CLPageControls collapse show" id="controles" runat="server" aria-labelledby="controles">
            <div class="" style="width: 70%; padding-left:10px;">
                <div class="row">
                    <div class="">
                       <%-- <dx:BootstrapButton ID="btnNuevo" runat="server" AutoPostBack="false" Text="" CssClasses-Icon="fas fa-file" ToolTip="Nuevo"
                            Style='font-size: 17px' SettingsBootstrap-Sizing="Small">
                        </dx:BootstrapButton>--%>

                        <dx:BootstrapButton ID="btnGuardar" runat="server" AutoPostBack="false" Text="" CssClasses-Icon="fas fa-save" ToolTip="Guardar"
                            Style='font-size: 17px' SettingsBootstrap-Sizing="Small" OnClick="btnGuardar_Click">
                        </dx:BootstrapButton>

                        <dx:BootstrapButton ID="btnCancelar" runat="server" AutoPostBack="false" Text="" CssClasses-Icon="fas fa-window-close" ToolTip="Cancelar"
                            Style='font-size: 17px' SettingsBootstrap-Sizing="Small" OnClick="btnCancelar_Click">
                        </dx:BootstrapButton>

                        <dx:BootstrapButton ID="btnBorrar" runat="server" AutoPostBack="false" Text="" CssClasses-Icon="fas fa-trash-alt" ToolTip="Borrar"
                            Style='font-size: 17px' SettingsBootstrap-Sizing="Small" OnClick="btnBorrar_Click">
                        </dx:BootstrapButton>

                    <%--    <dx:BootstrapButton ID="btnBuscar" runat="server" AutoPostBack="false" Text="" CssClasses-Icon="fas fa-binoculars" ToolTip="Buscar"
                            Style='font-size: 17px' SettingsBootstrap-Sizing="Small">
                        </dx:BootstrapButton>--%>

                      <%--  <dx:BootstrapButton ID="btnExportar" runat="server" AutoPostBack="false" Text="" CssClasses-Icon="fas fa-print" ToolTip="Exportar"
                            Style='font-size: 17px' SettingsBootstrap-Sizing="Small">
                        </dx:BootstrapButton> --%>
                    </div>
                     
                </div>
            </div>
        </section>
        

        <section class="CLPageContent" style="width:100%;">
            <div class="" style="display:inline-block; ">
                <dx:BootstrapFormLayout ID="Frm_Asignacion" runat="server" LayoutType="Vertical" > 
                    <Items >
                        <dx:BootstrapLayoutItem Caption="Expedicion" ColSpanLg="4" ColSpanMd="6" >
                            <ContentCollection>
                                <dx:ContentControl>
                                
                                    <dx:BootstrapTextBox ID="Txt_expedicion" runat="server" NullText="número de expedición" Enabled="false" />
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                        <dx:BootstrapLayoutItem Caption="Sociedad" ColSpanLg="4" ColSpanMd="6">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                 
                                    <dx:BootstrapTextBox ID="Txt_sociedad" runat="server" NullText="Sociedad" Enabled="false" />
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>

                             <dx:BootstrapLayoutItem Caption="Urgente" ColSpanLg="4" ColSpanMd="12" >
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:ASPxCheckBox ID="CB_Urgente" runat="server" Enabled="false" ></dx:ASPxCheckBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                        <dx:BootstrapLayoutItem Caption="Origen" ColSpanLg="6" ColSpanMd="10">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                  
                                    <dx:BootstrapTextBox ID="Txt_origen" runat="server" NullText="origen" Enabled="false" />
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                          <dx:BootstrapLayoutItem Caption="Centro Carga" ColSpanLg="6" ColSpanMd="6">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                              
                                       <dx:BootstrapTextBox ID="Txt_CentroCarga" runat="server" NullText="centro carga" Enabled="false" />
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                        <dx:BootstrapLayoutItem Caption="Destino" ColSpanLg="3" ColSpanMd="12">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                 
                                       <dx:BootstrapTextBox ID="Txt_destino" runat="server" NullText="destino" Enabled="false" />
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                        <dx:BootstrapLayoutItem Caption="Unidad Transporte"  ColSpanLg="3" ColSpanMd="6" >
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                              
                                       <dx:BootstrapTextBox ID="Txt_UnidadTransporte" runat="server" NullText="unidad transporte" Enabled="false" />
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                         <dx:BootstrapLayoutItem Caption="Peso Teorico"  ColSpanLg="3" ColSpanMd="6" >
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                              
                                       <dx:BootstrapTextBox ID="Txt_pesoteorico" runat="server" NullText="Peso teorico" Enabled="false" />
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                         <dx:BootstrapLayoutItem Caption="Observaciones" ColSpanLg="12" ColSpanMd="12" >
                            <ContentCollection>
                                <dx:ContentControl>
                                    <dx:BootstrapMemo ID="Txt_Observaciones"  runat="server" Enabled="false"/>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                        <dx:BootstrapLayoutItem Caption="Observaciones Log" ColSpanLg="12" ColSpanMd="12" >
                            <ContentCollection>
                                <dx:ContentControl>
                                    <dx:BootstrapMemo ID="Txt_Observacioneslog"  runat="server" Enabled="false"/>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                     
                        <dx:BootstrapLayoutItem Caption="Matricula" ColSpanLg="6" ColSpanMd="6">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                
                                       <dx:BootstrapTextBox ID="txt_matricula" runat="server" NullText="Matrícula" Enabled="true" AutoPostBack="true" OnTextChanged="txt_matricula_TextChanged1">
                                      
                                         <ValidationSettings>
                                                 <RequiredField IsRequired="true" ErrorText="Matrícula es obligatorio" />
                                        </ValidationSettings>
                                           </dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                         <dx:BootstrapLayoutItem Caption="Matricula remolque" ColSpanLg="6" ColSpanMd="6">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                 
                                     <dx:BootstrapTextBox ID="txt_matricularemolque" runat="server" NullText="Matrícula remolque" Enabled="true" >
                                          <ValidationSettings>
                                                 <RequiredField IsRequired="true" ErrorText="Matrícula es obligatorio" />
                                        </ValidationSettings>
                                           </dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                        <dx:BootstrapLayoutItem Caption="Id. Agencia"  Name="elidagencia" ColSpanLg="12" ColSpanMd="12">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                   <%-- <dx:ASPxTextBox ID="txt_idagencia" runat="server">
                                    </dx:ASPxTextBox>--%>
                                    
                                    <dx:BootstrapComboBox ID="CB_Agencia" OnDataBinding="CB_Agencia_DataBinding" runat="server"></dx:BootstrapComboBox>
                               
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                         <dx:BootstrapLayoutItem Caption="Fecha Prevista Carga"  ColSpanLg="6" ColSpanMd="6">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapDateEdit ID="Txt_Fechaprevcarga" runat="server" OnCalendarDayCellPrepared="Txt_Fechaprevcarga_CalendarDayCellPrepared">
                                          <ValidationSettings>
                                                 <RequiredField IsRequired="true" ErrorText="Fecha es obligatorio" />
                                        </ValidationSettings>
                                           
                                    </dx:BootstrapDateEdit>
                                    
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                        <dx:BootstrapLayoutItem Caption="Fecha Prevista Descarga"  ColSpanLg="6" ColSpanMd="6">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                   <dx:BootstrapDateEdit ID="Txt_Fechaprevdescarga" runat="server" OnCalendarDayCellPrepared="Txt_Fechaprevcarga_CalendarDayCellPrepared">
                                        <ValidationSettings>
                                                 <RequiredField IsRequired="true" ErrorText="Fecha es obligatorio" />
                                        </ValidationSettings>
                                   </dx:BootstrapDateEdit>
                                    
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                     <%--   <dx:LayoutItem Caption="" ColSpan="1">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxButton ID="Bt_BuscarAgencia"  OnClick="Bt_BuscarAgencia_Click" CssClasses-Icon="fas fa-search-plus" runat="server">
                                    </dx:ASPxButton>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>--%>
                          <dx:BootstrapLayoutItem Caption="Nombre Transportista" ColSpanMd="10">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                 
                                       <%-- <dx:BootstrapTextBox ID="Txt_transportista" runat="server" NullText="nombre transportista" Enabled="true" />--%>
                                      <dx:BootstrapComboBox ID="CB_Transportistas" OnDataBinding="CB_Transportistas_DataBinding" runat="server"></dx:BootstrapComboBox>

                               
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                         
                        <dx:BootstrapLayoutItem Caption=" " ColSpanMd="2" >
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                 
                                      <dx:BootstrapButton ID="BT_AñadirTrans" runat="server" AutoPostBack="false"   Text="" CssClasses-Icon="fas fa-plus" ToolTip="Nuevo"
                            Style='font-size: 17px' SettingsBootstrap-Sizing="Small" OnClick="BT_AñadirTrans_Click">
                        </dx:BootstrapButton>

                               
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                           <dx:BootstrapLayoutItem Caption="Nº Permiso especial" ColSpanLg="6" ColSpanMd="6">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                 
                                     <dx:BootstrapTextBox ID="Txt_numpermisoespecial" runat="server" NullText="Nº Permiso especial" Enabled="true" >
                                         
                                           </dx:BootstrapTextBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                    </Items>

                </dx:BootstrapFormLayout>
                    <dx:BootstrapPopupControl ID="PUp_VerAgencias" ClientInstanceName="PUp_VerAgencias" runat="server"  Width="700px" Height="400px"  
                    PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"  AllowDragging="True" CloseAction="CloseButton" CloseOnEscape="True" Modal="True"
                    PopupAnimationType="None" EnableViewState="False" HeaderText="Agencias Asignadas"  >
                    <ClientSideEvents Shown=" function(s, e){Gv_AgenciasAsignadas.PerformCallback();}"    />
                    <ContentCollection>
                         <dx:ContentControl>
                             <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="gvConsulta"></dx:ASPxGridViewExporter>
                             <dx:BootstrapGridView ID="Gv_AgenciasAsignadas"  ClientInstanceName="Gv_AgenciasAsignadas" runat="server" OnCustomCallback="Gv_AgenciasAsignadas_CustomCallback"
                                 OnDataBinding="Gv_AgenciasAsignadas_DataBinding" Width="100%" AutoGenerateColumns="False"  KeyFieldName="AgenciaId;AgenciaNom;TransportistaId;MatRemolque">
                                 <CssClasses Control="testClass"  CommandColumn="testClass" EditForm="testClass" HeaderRow="testClass" FilterRow="testClass" CommandColumnItem="testClass" IconHeaderFilter="iconClass"  IconFilterRowButton="iconClass" />
                                 <ClientSideEvents  RowDblClick="Agencia_RowDblClick" />

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
                                     
                                     <dx:BootstrapGridViewTextColumn Caption="ID Agencia" FieldName="AgenciaId"  VisibleIndex="0">
                                     </dx:BootstrapGridViewTextColumn>
                                     <dx:BootstrapGridViewTextColumn Caption="Nombre Agencia" FieldName="AgenciaNom"  VisibleIndex="1">
                                     </dx:BootstrapGridViewTextColumn>
                                         <dx:BootstrapGridViewTextColumn Caption="Transportista" FieldName="TransportistaNom" VisibleIndex="2">
                                     </dx:BootstrapGridViewTextColumn>
                                       <dx:BootstrapGridViewTextColumn Caption="Mat Remolque" FieldName="MatRemolque" VisibleIndex="3">
                                     </dx:BootstrapGridViewTextColumn>
                                 </Columns>
                                 <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="DataAware" />

                             </dx:BootstrapGridView>
                        </dx:ContentControl>
                    </ContentCollection>

                </dx:BootstrapPopupControl>
                     <dx:BootstrapPopupControl ID="Pup_AddTransportista" ClientInstanceName="Pup_AddTransportista" runat="server"  Width="1000px" Height="500px"  
                    PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"  AllowDragging="True" CloseAction="CloseButton" CloseOnEscape="True" Modal="True"
                    PopupAnimationType="None" EnableViewState="False" HeaderText="Añadir Transportista"  >
                           <ClientSideEvents CloseButtonClick="function(s, e) {            RefrescaTransportistas();
                        }" />
                  
                    <ContentCollection>
                         <dx:ContentControl>
                          
                        </dx:ContentControl>
                    </ContentCollection>

                </dx:BootstrapPopupControl>
            </div>
        </section>

     <%--   <footer class="CLPageFooter">
            © Derechos Reservados 2020-2021 CL Grupo Industrial Todos los Derechos Reservados.
        </footer>--%>
    </form>

</body>
</html>
