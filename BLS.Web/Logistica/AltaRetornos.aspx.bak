<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaRetornos.aspx.cs" Inherits="GPB.Web.AltaRetornos" %>
<%@ Register Src="~/Controles/Usuario/InfoMsgBox.ascx" TagPrefix="uc1" TagName="cuInfoMsgbox" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v25.1, Version=25.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="user-scalable=0, width=device-width, initial-scale=1.0, maximum-scale=1.0" />
     
     <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="user-scalable=0, width=device-width, initial-scale=1.0, maximum-scale=1.0" />
    <%--<link rel="stylesheet" href="../Content/bootstrap.min.css" crossorigin="anonymous" />--%>
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
        <uc1:cuInfoMsgbox runat="server" ID="cuInfoMsgbox1" />
        <header class="CLPageHeader">
           <dx:ASPxImage runat="server" ID="imagenLogo" CssClass="imagenLogo">  </dx:ASPxImage>
            <dx:ASPxLabel ID="lblNombrePagina" CssClass="titleHeader" runat="server" Text="Asignación Agencias Expediciones" Font-Bold="true"></dx:ASPxLabel>
            <dx:ASPxLabel ID="lblVersion" CssClass="titleHeader version" runat="server" Text="Versión: 1.0 Beta" Font-Bold="true"></dx:ASPxLabel>
        </header>
        <div style="margin-left: 30px;">
            <a class="btn-box-tool" data-toggle="collapse" data-target="#controles" role="button" onclick="iconMaxMin()" aria-expanded="false" aria-controls="controles"><i id="iconCollapse" data-original="fas fa-angle-double-down" class="fas fa-angle-double-down"></i></a>
        </div>

        <section class="CLPageControls" id="controles" class="collapse show" aria-labelledby="controles">
            <div class="" style="width: 100%; padding-left:10px;">
                <div class="row">
                    <div class="">
                        <dx:BootstrapButton ID="btnNuevo" runat="server" AutoPostBack="false" OnClick="btnNuevo_Click" Text="" CssClasses-Icon="fas fa-file" ToolTip="Nuevo"
                            Style='font-size: 17px' SettingsBootstrap-Sizing="Small">
                        </dx:BootstrapButton>

                        <dx:BootstrapButton ID="btnGuaqrdar" runat="server" AutoPostBack="false" OnClick="btnGuaqrdar_Click" Text="" CssClasses-Icon="fas fa-save" ToolTip="Guardar"
                            Style='font-size: 17px' SettingsBootstrap-Sizing="Small">
                        </dx:BootstrapButton>

                        <dx:BootstrapButton ID="btnCancelar" runat="server" AutoPostBack="false" OnClick="btnCancelar_Click" Text="" CssClasses-Icon="fas fa-window-close" ToolTip="Cancelar"
                            Style='font-size: 17px' SettingsBootstrap-Sizing="Small">
                        </dx:BootstrapButton>

                     <%--   <dx:BootstrapButton ID="btnBorrar" runat="server" AutoPostBack="false" Text="" CssClasses-Icon="fas fa-trash-alt" ToolTip="Borrar"
                            Style='font-size: 17px' SettingsBootstrap-Sizing="Small">
                        </dx:BootstrapButton>

                        <dx:BootstrapButton ID="btnBuscar" runat="server" AutoPostBack="false" Text="" CssClasses-Icon="fas fa-binoculars" ToolTip="Buscar"
                            Style='font-size: 17px' SettingsBootstrap-Sizing="Small">
                        </dx:BootstrapButton>

                        <dx:BootstrapButton ID="btnExportar" runat="server" AutoPostBack="false" Text="" CssClasses-Icon="fas fa-print" ToolTip="Exportar"
                            Style='font-size: 17px' SettingsBootstrap-Sizing="Small">
                        </dx:BootstrapButton>--%>
                    </div>
                </div>
            </div>
        </section>

        <section class="CLPageContent">
            <div class="">
                <dx:BootstrapFormLayout ID="Frm_Retornos" runat="server">
                   <CssClasses Control="testClass" />
                    <Items>
                        <dx:BootstrapLayoutItem  Caption="Proveedor" name="Proveedor" ColSpanMd="12" >  
                            <ContentCollection>
                                <dx:ContentControl>
                                    <dx:BootstrapComboBox ID="Cb_ProveedoresMM" OnDataBinding="Cb_ProveedoresMM_DataBinding" runat="server" Width="100%"  OnValueChanged="Cb_ProveedoresMM_ValueChanged" AutoPostBack="true"></dx:BootstrapComboBox>
                                </dx:ContentControl>
                            </ContentCollection>
                         </dx:BootstrapLayoutItem>
                        <dx:BootstrapLayoutGroup Caption="Dirección" ColSpanMd="12">
                            <Items>
                                <dx:BootstrapLayoutItem Caption="Calle" ColSpanMd="6">
                                    <ContentCollection>
                                    <dx:ContentControl>
                                        <dx:BootstrapTextBox ID="Txt_Calle"  runat="server" Width="100%"></dx:BootstrapTextBox>
                                    </dx:ContentControl>
                                    </ContentCollection>
                                </dx:BootstrapLayoutItem>
                                 
                                <dx:BootstrapLayoutItem Caption="CP"  ColSpanMd="4">
                                    <ContentCollection>
                                    <dx:ContentControl>
                                        <dx:BootstrapTextBox ID="Txt_Codpostal"  runat="server" Width="100%"></dx:BootstrapTextBox>
                                    </dx:ContentControl>
                                    </ContentCollection>
                                 </dx:BootstrapLayoutItem>
                                <dx:BootstrapLayoutItem Caption="Población"  ColSpanMd="6">
                                    <ContentCollection>
                                    <dx:ContentControl>
                                      <dx:BootstrapComboBox ID="CB_Poblaciones" OnDataBinding="CB_Poblaciones_DataBinding" runat="server" Width="100%" OnValueChanged="CB_Poblaciones_ValueChanged" AutoPostBack="true">
                                          <ValidationSettings>
                                                 <RequiredField IsRequired="true" ErrorText="Población obligatoria" />
                                        </ValidationSettings>
                                      </dx:BootstrapComboBox>
                                    </dx:ContentControl>
                                    </ContentCollection>
                                 </dx:BootstrapLayoutItem>
                                <dx:BootstrapLayoutItem Caption="Pais"  ColSpanMd="3">
                                    <ContentCollection>
                                    <dx:ContentControl>
                                        <dx:BootstrapComboBox ID="CB_Pais" runat="server"  OnDataBinding="CB_Pais_DataBinding" Width="100%"></dx:BootstrapComboBox>
                                    </dx:ContentControl>
                                    </ContentCollection>
                                 </dx:BootstrapLayoutItem>
                                <%--<dx:BootstrapLayoutItem Caption="Region"  ColSpanMd="3">
                                    <ContentCollection>
                                    <dx:ContentControl>
                                        <dx:BootstrapComboBox ID="CB_Region" runat="server" OnDataBinding="CB_Region_DataBinding"  Width="100%"></dx:BootstrapComboBox>
                                    </dx:ContentControl>
                                    </ContentCollection>
                                 </dx:BootstrapLayoutItem>
                                 --%>
                                 <dx:BootstrapLayoutItem Caption="Latitud"  ColSpanMd="2" Visible="false">
                                    <ContentCollection>
                                    <dx:ContentControl>
                                        <dx:BootstrapTextBox ID="Txt_Latitud"  runat="server" Width="100%"></dx:BootstrapTextBox>
                                    </dx:ContentControl>
                                    </ContentCollection>
                                 </dx:BootstrapLayoutItem>
                                 
                                 <dx:BootstrapLayoutItem Caption="Longitud"  ColSpanMd="2"  Visible="false">
                                    <ContentCollection>
                                    <dx:ContentControl>
                                        <dx:BootstrapTextBox ID="Txt_Longitud"  runat="server" Width="100%"></dx:BootstrapTextBox>
                                    </dx:ContentControl>
                                    </ContentCollection>
                                 </dx:BootstrapLayoutItem>
                                
                                <dx:BootstrapLayoutItem Caption=""  ColSpanMd="8" Visible="false">
                                    <ContentCollection>
                                    <dx:ContentControl>
                                        <dx:BootstrapButton ID="BT_vergeolocalizacion" OnClick="BT_vergeolocalizacion_Click" runat="server" AutoPostBack="false" Text="Localizar"></dx:BootstrapButton>
                                    </dx:ContentControl>
                                    </ContentCollection>
                                 </dx:BootstrapLayoutItem>
                                <dx:BootstrapLayoutItem Caption="Dir. Lat/Lon"  ColSpanMd="4"  Visible="false">
                                    <ContentCollection>
                                    <dx:ContentControl>
                                        <dx:BootstrapTextBox ID="Txt_dirlatlon"  runat="server" Width="100%"></dx:BootstrapTextBox>
                                    </dx:ContentControl>
                                    </ContentCollection>
                                 </dx:BootstrapLayoutItem>
                                   <dx:BootstrapLayoutItem Caption=""  ColSpanMd="8"  Visible="false">
                                    <ContentCollection>
                                    <dx:ContentControl>
                                        <dx:BootstrapButton ID="BT_Verdireccion" OnClick="BT_Verdireccion_Click" runat="server" AutoPostBack="false" Text="Direccion"></dx:BootstrapButton>
                                    </dx:ContentControl>
                                    </ContentCollection>
                                 </dx:BootstrapLayoutItem>


                            </Items>
                        </dx:BootstrapLayoutGroup>
                          <dx:BootstrapLayoutGroup Caption="Detalle Entrega" ColSpanMd="12">
                            <Items>
                                 <dx:BootstrapLayoutItem Caption="Nº Camiones" ColSpanMd="6">
                                    <ContentCollection>
                                    <dx:ContentControl>
                                        <dx:BootstrapTextBox ID="Txt_numcamiones"  runat="server" Width="100%">
                                            <MaskSettings Mask="<0..999>" IncludeLiterals="None" ErrorText="Solo Números" />
                                             <ValidationSettings>
                                                 <RequiredField IsRequired="true" ErrorText="Num camiones obligatorio" />
                                        </ValidationSettings>
                                        </dx:BootstrapTextBox>
                                    </dx:ContentControl>
                                    </ContentCollection>
                                </dx:BootstrapLayoutItem>
                                <dx:BootstrapLayoutItem  Caption="Portes" ColSpanMd="6"  ShowCaption="False">  
                            <ContentCollection>
                                <dx:ContentControl>
                                    <dx:BootstrapCheckBox ID="Chb_Portespagados" Text="Portes Pagados" runat="server"></dx:BootstrapCheckBox>
                                </dx:ContentControl>
                            </ContentCollection>
                         </dx:BootstrapLayoutItem>
                                
                                 
                            </Items>
                           </dx:BootstrapLayoutGroup>
                          <dx:BootstrapLayoutGroup Caption="Detalle camión" ColSpanMd="12">
                            <Items>
                                 <dx:BootstrapLayoutItem Caption="Cantidad" ColSpanMd="4" >
                                    <ContentCollection>
                                    <dx:ContentControl>
                                        <dx:BootstrapTextBox ID="Txt_Cantidad"  runat="server" Width="90%">
                                                 <MaskSettings Mask="<0..23>.<0..99>"  ErrorText="Solo Números" />
                                             <ValidationSettings>
                                                 
                                        </ValidationSettings>
                                        </dx:BootstrapTextBox>

                                    
                                    </dx:ContentControl>
                                    </ContentCollection>
                                </dx:BootstrapLayoutItem>
                                <dx:BootstrapLayoutItem Caption="" ColSpanMd="1" >
                                    <ContentCollection>
                                    <dx:ContentControl>
                                          <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Toneladas" Width="100%"></dx:ASPxLabel>
                                    </dx:ContentControl>
                                    </ContentCollection>
                                </dx:BootstrapLayoutItem>
                                <dx:BootstrapLayoutItem Caption="Material"  ColSpanMd="5" >
                                    <ContentCollection>
                                    <dx:ContentControl>
                                           <dx:BootstrapComboBox ID="CB_Material" OnDataBinding="CB_Material_DataBinding" runat="server" Width="100%">
                                               <ValidationSettings>
                                               
                                        </ValidationSettings>
                                           </dx:BootstrapComboBox>
                                    </dx:ContentControl>
                                    </ContentCollection>
                                </dx:BootstrapLayoutItem>
                                 <dx:BootstrapLayoutItem Caption=""  ColSpanMd="2" >
                                    <ContentCollection>
                                    <dx:ContentControl>
                                           <dx:BootstrapButton ID="BT_Anadirdetalle" runat="server" AutoPostBack="false" OnClick="BT_Anadirdetalle_Click" Text="" CssClasses-Icon="fas fa-plus" ToolTip="Cancelar"
                            Style='font-size: 17px' SettingsBootstrap-Sizing="Small">
                        </dx:BootstrapButton>
                                    </dx:ContentControl>
                                    </ContentCollection>
                                </dx:BootstrapLayoutItem>
                                <dx:BootstrapLayoutItem Caption="" ColSpanMd="12" >
                                    <ContentCollection>
                                    <dx:ContentControl>
                                        <dx:BootstrapGridView ID="GV_Detallecamion" runat="server" OnDataBinding="GV_Detallecamion_DataBinding">
                                            <SettingsAdaptivity AdaptivityMode="HideDataCellsWindowLimit"
                                                           AllowOnlyOneAdaptiveDetailExpanded="true"
                                                          AllowHideDataCellsByColumnMinWidth="true">
                                            </SettingsAdaptivity>
                                            <Settings ShowHeaderFilterButton="true" />
                                             <Columns>
                                                        <dx:BootstrapGridViewTextColumn Caption="Cantidad" Name="Cantidad" FieldName="Cantidad" VisibleIndex="0">
                                                    
                                                        </dx:BootstrapGridViewTextColumn>
                                                        <dx:BootstrapGridViewTextColumn Caption="Material"  FieldName="Material"  VisibleIndex="1">
                                                        </dx:BootstrapGridViewTextColumn>
                                                    <dx:BootstrapGridViewTextColumn Caption="Material"  FieldName="DesMaterial"  VisibleIndex="1">
                                                        </dx:BootstrapGridViewTextColumn>
                                                 </Columns>
                                        </dx:BootstrapGridView>
                                    </dx:ContentControl>
                                    </ContentCollection>
                                </dx:BootstrapLayoutItem>
                                 
                            </Items>
                           </dx:BootstrapLayoutGroup>
                        
                          <dx:BootstrapLayoutItem  Caption="Observaciones" ColSpanMd="12"  ShowCaption="true">  
                            <ContentCollection>
                                <dx:ContentControl>
                                          <dx:BootstrapMemo ID="Txt_Observaciones"  runat="server" Enabled="true"/>
                                </dx:ContentControl>
                            </ContentCollection>
                         </dx:BootstrapLayoutItem>
                        
                        </Items>
                </dx:BootstrapFormLayout>
            </div>
        </section>

        <footer class="CLPageFooter">
            © Derechos Reservados 2020-2021 CL Grupo Industrial Todos los Derechos Reservados.
        </footer>
    </form>

</body>
</html>
