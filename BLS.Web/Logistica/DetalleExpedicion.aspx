<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleExpedicion.aspx.cs" Inherits="GPB.Web.Logistica.DetalleExpedicion" %>

<%@ Register Src="~/Controles/Usuario/InfoMsgBoxMovil.ascx" TagPrefix="uc1" TagName="cuInfoMsgboxMovil" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v25.2, Version=25.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="user-scalable=0, width=device-width, initial-scale=1.0, maximum-scale=1.0" />
    <%--<link rel="stylesheet" href="../Content/bootstrap.min.css" crossorigin="anonymous" />--%>
    <link rel="stylesheet" href="../SwitcherResources/Content/Simplex/bootstrap.min.css" crossorigin="anonymous" />
    <link rel="stylesheet" href="../Content/all.css" crossorigin="anonymous" />
    <link rel="stylesheet" href="../Content/generic/StylesMovil.css" crossorigin="anonymous" />
    <link rel="stylesheet" type="text/css" href="../Content/ContentMovil.css" />

    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>

    <script>
        $(document).ready(function () {

        });

        function iconMaxMin() {
            var i = $('#iconCollapse');
            i.attr('class', i.hasClass('fas fa-angle-double-down') ? 'fas fa-angle-double-up' : i.attr('data-original'));
        }

         function regresarAsignacion() {
            parent.document.getElementById('content').src = "Logistica/ExpedicionesMovil.aspx?initCod=20";
        }
        function AltaTransportista() {
            parent.document.getElementById('content').src = "Logistica/AltaTransportistaMovil.aspx";
        }
    </script>

</head>
<body>

    <form id="frmPageMovil" runat="server" class="Principal">
        <uc1:cuInfoMsgboxMovil runat="server" ID="cuInfoMsgboxMovil" />

        <header class="CLPageHeader">
            <dx:ASPxLabel ID="lblNombrePagina" CssClass="titleHeader" runat="server" Text="Página Inicial" Font-Bold="true"></dx:ASPxLabel>
        </header>



        <section class="CLPageContent">
            <div class="">
                <dx:BootstrapFormLayout ID="Frm_Asignacion" runat="server" LayoutType="Vertical" >
                    <Items>
                        <dx:BootstrapLayoutItem Caption="Expedicion" ColSpanLg="4" ColSpanMd="6">
                            <ContentCollection>
                                <dx:ContentControl>
                                    <dx:BootstrapTextBox ID="Txt_expedicion" runat="server" NullText="número de expedición" Enabled="false" />
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
						
						
						<dx:BootstrapLayoutItem Caption="Sociedad FI" ColSpanLg="4" ColSpanMd="6">
                            <ContentCollection>
                                <dx:ContentControl>
                                    <dx:BootstrapTextBox ID="Txt_sociedad" runat="server" NullText="Sociedad" Enabled="false"/>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
						
						
						<dx:BootstrapLayoutItem Caption="Origen" ColSpanLg="4" ColSpanMd="6">
                            <ContentCollection>
                                <dx:ContentControl>
                                    <dx:BootstrapTextBox ID="Txt_origen" runat="server" NullText="Origen" Enabled="false"/>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                        <dx:BootstrapLayoutItem Caption="Centro Carga" ColSpanLg="4" ColSpanMd="6">
                            <ContentCollection>
                                <dx:ContentControl>
                                    <dx:BootstrapTextBox ID="Txt_CentroCarga" runat="server" NullText="Origen" Enabled="false"/>
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
                                    <dx:BootstrapTextBox ID="Txt_UnidadTransporte" runat="server" NullText="Destino" Enabled="false"/>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                        <dx:BootstrapLayoutItem Caption="Peso Teorico" ColSpanLg="4" ColSpanMd="6" >
                            <ContentCollection>
                                <dx:ContentControl>
                                    <dx:BootstrapMemo ID="Txt_Pesoteorico"  runat="server" Enabled="false"/>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                        <dx:BootstrapLayoutItem Caption="Urgente" ColSpanLg="4" ColSpanMd="12">
                            <ContentCollection>
                                <dx:ContentControl>
                                    <dx:BootstrapCheckBox ID="CB_Urgente" runat="server"></dx:BootstrapCheckBox>
                                    
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
						 <dx:BootstrapLayoutItem Caption="Observaciones" ColSpanLg="4" ColSpanMd="6" >
                            <ContentCollection>
                                <dx:ContentControl>
                                    <dx:BootstrapMemo ID="Observaciones"  runat="server" Enabled="false"/>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                         <dx:BootstrapLayoutItem Caption="Observaciones Log" ColSpanLg="4" ColSpanMd="6" >
                            <ContentCollection>
                                <dx:ContentControl>
                                    <dx:BootstrapMemo ID="ObservacionesLog"  runat="server" Enabled="false"/>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                         

                          <dx:BootstrapLayoutItem ShowCaption="False" ColSpanLg="4" ColSpanMd="12">
                            <ContentCollection>
                                <dx:ContentControl>
                                     <dx:ASPxLabel  ID="lblCapturar" Text="Introducir los siguientes campos:" runat="server"></dx:ASPxLabel>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                       
                    

						<dx:BootstrapLayoutItem Caption="Matricula" ColSpanLg="4" ColSpanMd="6">
                            <ContentCollection>
                                <dx:ContentControl>
                                    <dx:BootstrapTextBox ID="txt_matricula" OnTextChanged="txt_matricula_TextChanged1" AutoPostBack="true" runat="server" NullText="Matricula" />
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
						
						
						<dx:BootstrapLayoutItem Caption="Matricula remolque" ColSpanLg="4" ColSpanMd="6">

                            <ContentCollection>
                                <dx:ContentControl>
                                    <dx:BootstrapTextBox ID="txt_matricularemolque" runat="server" NullText="Matricula remolque" />
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                            <dx:BootstrapLayoutItem Caption="Nombre Transportista" ColSpanLg="4" ColSpanMd="10">
                            <ContentCollection>
                                <dx:ContentControl>
                                    <%--<dx:BootstrapTextBox ID="Txt_transportista" runat="server" NullText="Nombre Transportista" />--%>
                                  <dx:BootstrapComboBox ID="CB_Transportistas" OnDataBinding="CB_Transportistas_DataBinding" runat="server"></dx:BootstrapComboBox>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                         <dx:BootstrapLayoutItem Caption=" " name="AddTrans" ColSpanLg="1" ColSpanMd="2" >
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
                        <dx:BootstrapLayoutItem Caption="Fecha Prevista Carga"  ColSpanLg="4" ColSpanMd="6">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                    <dx:BootstrapDateEdit ID="Txt_Fechaprevcarga" runat="server" OnCalendarDayCellPrepared="Txt_Fechaprevcarga_CalendarDayCellPrepared"></dx:BootstrapDateEdit>
                                    
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                        <dx:BootstrapLayoutItem Caption="Fecha Prevista Descarga"  ColSpanLg="4" ColSpanMd="6">
                            <ContentCollection>
                                <dx:ContentControl runat="server">
                                   <dx:BootstrapDateEdit ID="Txt_Fechaprevdescarga" runat="server" OnCalendarDayCellPrepared="Txt_Fechaprevdescarga_CalendarDayCellPrepared"></dx:BootstrapDateEdit>
                                    
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
						
                        <dx:BootstrapLayoutItem ShowCaption="False" HorizontalAlign="Right">
                            <ContentCollection>
                                <dx:ContentControl>
                                      <dx:BootstrapButton ID="btnCancel" Text="Cancelar" AutoPostBack="true" CausesValidation="false" runat="server" OnClick="btnCancel_Click">
                                        <SettingsBootstrap RenderOption="Secondary" />
                                    </dx:BootstrapButton>
                                    <dx:BootstrapButton ID="btnGuardar" Text="Guardar" AutoPostBack="true" CausesValidation="false" runat="server" OnClick="btnGuardar_Click">
                                        <SettingsBootstrap RenderOption="Primary" />
                                    </dx:BootstrapButton>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:BootstrapLayoutItem>
                    </Items>
                </dx:BootstrapFormLayout>
            </div>
        </section>
    </form>

</body>
</html>
