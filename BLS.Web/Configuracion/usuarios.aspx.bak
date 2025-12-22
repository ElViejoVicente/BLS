<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="usuarios.aspx.cs" Inherits=" SGN.Web.Configuracion.usuarios" %>

<%@ Register Src="~/Controles/Usuario/InfoMsgBox.ascx" TagPrefix="uc1" TagName="cuInfoMsgbox" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v23.1, Version=23.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="user-scalable=0, width=device-width, initial-scale=1.0, maximum-scale=1.0" />
    <link rel="stylesheet" href="../Content/bootstrap.min.css" crossorigin="anonymous" />
    <link rel="stylesheet" href="../Content/all.css" crossorigin="anonymous" />
    <link rel="stylesheet" href="../Content/generic/pageStyle.css" crossorigin="anonymous" />
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>


    <script src="../Scripts/sweetalert.min.js"></script>
    <script src="../Scripts/mensajes.js"></script>



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
     
        <section class="CLPageContent">
            <div class="">
                  <asp:HiddenField ID="HidContrasena" runat="server" ClientIDMode="Static" />
                       <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="gvUsuarios"></dx:ASPxGridViewExporter>
                <dx:ASPxGridView ID="gvUsuarios" runat="server" AutoGenerateColumns="False" KeyFieldName="Id" Width="100%" EnableCallBacks="false"
                    OnDataBinding="gvUsuarios_DataBinding"
                    OnRowUpdating="gvUsuarios_RowUpdating"
                    OnRowInserting="gvUsuarios_RowInserting"
                    OnInitNewRow="gvUsuarios_InitNewRow"
                    OnDataBound="gvUsuarios_DataBound"
                    OnCommandButtonInitialize="gvUsuarios_CommandButtonInitialize"
                    >
                    <Toolbars>
                        <dx:GridViewToolbar>
                            <Items>
                                <dx:GridViewToolbarItem Command="ExportToXls"></dx:GridViewToolbarItem>
                            </Items>
                        </dx:GridViewToolbar>
                    </Toolbars>
                    <Settings HorizontalScrollBarMode="Visible" />
                     <SettingsPager PageSize="50" ></SettingsPager>
                    <SettingsEditing Mode="EditForm"></SettingsEditing>
                    <SettingsAdaptivity AdaptivityMode="HideDataCellsWindowLimit"
                        AllowOnlyOneAdaptiveDetailExpanded="true"
                        AllowHideDataCellsByColumnMinWidth="true">
                    </SettingsAdaptivity>
                    <%-- <Settings ShowFilterRow="True" />--%>
                    <SettingsSearchPanel Visible="True" ShowClearButton="true" />
                    <EditFormLayoutProperties>
                        <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit"></SettingsAdaptivity>
                    </EditFormLayoutProperties>
                    <Columns>
                        <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0" ButtonRenderMode="Button" ButtonType="Button" />

                        <dx:GridViewDataTextColumn FieldName="Id" Caption="ID" VisibleIndex="1" Visible="false" />
                        <dx:GridViewDataTextColumn FieldName="UserName"   Caption="" VisibleIndex="2">
                              
                            <PropertiesTextEdit>
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" ErrorText="Campo requerido."></RequiredField>
                                </ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Contraseña" Caption="" VisibleIndex="3"  Visible="false" >
                                 <EditFormSettings Visible="True" />
                            <PropertiesTextEdit  >
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" ErrorText="Campo requerido."></RequiredField>
                                </ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                  
                        <dx:GridViewDataTextColumn FieldName="Nombre" Caption="" VisibleIndex="4"  Width="200px">
                            <PropertiesTextEdit>
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" ErrorText="Campo requerido."></RequiredField>
                                </ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>

                        <dx:GridViewDataDateColumn FieldName="FechaAlta" Caption="" VisibleIndex="5">

                            <PropertiesDateEdit>
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" ErrorText="Campo requerido."></RequiredField>
                                </ValidationSettings>
                            </PropertiesDateEdit>
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataCheckColumn FieldName="Activo" Caption="" VisibleIndex="6" />
                        <dx:GridViewDataTextColumn FieldName="Mail" Caption="" VisibleIndex="7"  Width="250px">
                            <PropertiesTextEdit>
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" ErrorText="Campo requerido."></RequiredField>
                                </ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="FechaBaja" Caption="" VisibleIndex="8" />
            
                        <dx:GridViewDataCheckColumn FieldName="Avisoemail" Caption="Aviso Email" VisibleIndex="12" />

                                 <dx:GridViewDataCheckColumn FieldName="EsProyectista" Caption="Es proyectista" VisibleIndex="13" />
                    </Columns>
                      <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="DataAware" />
                </dx:ASPxGridView>
            </div>
        </section>

        <%--<footer class="CLPageFooter">
            © Derechos Reservados 2020-2021 CL Grupo Industrial Todos los Derechos Reservados.
        </footer>--%>
    </form>

</body>
</html>
