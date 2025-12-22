<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="usuarios.aspx.cs" Inherits=" BLS.Web.Configuracion.usuarios" %>

<%@ Register Src="~/Controles/Usuario/InfoMsgBox.ascx" TagPrefix="uc1" TagName="cuInfoMsgbox" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../Content/all.css" />
    <link rel="stylesheet" href="../Content/generic/pageMinimalStyle.css" />
    <script src="../Scripts/sweetalert2.all.min.js"></script>
    <link rel="stylesheet" href="../Scripts/sweetalert2.min.css"/>
    <script src="../Scripts/mensajes.js"></script>



    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>SGN</title>
    <script type="text/javascript">


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

            gvUsuarios.SetHeight(height);

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


            }
        }

    </script>
</head>

<body>
    <form id="frmPage" runat="server" class="Principal">
        <uc1:cuInfoMsgbox runat="server" ID="cuInfoMsgbox1" />

        <section class="CLPageContent" id="maindiv">
            <div class="">
                <asp:HiddenField ID="HidContrasena" runat="server" ClientIDMode="Static" />
                <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="gvUsuarios"></dx:ASPxGridViewExporter>
                <dx:ASPxGridView ID="gvUsuarios" ClientInstanceName="gvUsuarios" runat="server" AutoGenerateColumns="False" KeyFieldName="Id" Width="100%" EnableCallBacks="false" Caption="Usuarios del Sistema"
                    OnDataBinding="gvUsuarios_DataBinding"
                    OnRowUpdating="gvUsuarios_RowUpdating"
                    OnRowInserting="gvUsuarios_RowInserting"
                    OnInitNewRow="gvUsuarios_InitNewRow"
                    OnDataBound="gvUsuarios_DataBound"
                    OnRowValidating="gvUsuarios_RowValidating"
                    OnCommandButtonInitialize="gvUsuarios_CommandButtonInitialize">

                    <ClientSideEvents Init="AdjustSize" />

                    <ClientSideEvents ToolbarItemClick="OnToolbarItemClick" />


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

                    <SettingsPager Mode="ShowPager" PageSize="100" />

                    <SettingsDetail ExportMode="All" ShowDetailRow="false" />

                    <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="DataAware" />

                    <Columns>
                        <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0" ButtonRenderMode="Button" ButtonType="Button" />

                        <dx:GridViewDataTextColumn FieldName="Id" Caption="ID" VisibleIndex="1" Visible="false" />
                        <dx:GridViewDataTextColumn FieldName="UserName" Caption="Nombre de Usuario" VisibleIndex="2">

                            <PropertiesTextEdit>
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" ErrorText="Campo requerido."></RequiredField>
                                </ValidationSettings>
                            </PropertiesTextEdit>
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Contraseña" Caption="" VisibleIndex="3" Visible="false">
                            <EditFormSettings Visible="True" />
                            <PropertiesTextEdit>
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" ErrorText="Campo requerido."></RequiredField>
                                </ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>

                        <dx:GridViewDataTextColumn FieldName="Nombre" Caption="" VisibleIndex="4" Width="250px">
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
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataCheckColumn FieldName="Activo" Caption="" VisibleIndex="6" />
                        <dx:GridViewDataTextColumn FieldName="Mail" Caption="" VisibleIndex="7" Width="250px">
                            <PropertiesTextEdit>
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" ErrorText="Campo requerido."></RequiredField>
                                </ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="FechaBaja" Caption="" VisibleIndex="8" />

                        <dx:GridViewDataCheckColumn FieldName="Avisoemail" Caption="Aviso Email" VisibleIndex="12" />

                        <dx:GridViewDataCheckColumn FieldName="EsProyectista" Caption="Es proyectista" VisibleIndex="13" />

                        <dx:GridViewDataCheckColumn FieldName="EsCreditos" Caption="Es Usuario de Creditos" VisibleIndex="13" Width="150px" />
                    </Columns>

                    <Toolbars>
                        <dx:GridViewToolbar>
                            <Items>
                                <dx:GridViewToolbarItem Command="ExportToXls"></dx:GridViewToolbarItem>
                            </Items>
                        </dx:GridViewToolbar>
                    </Toolbars>

                </dx:ASPxGridView>
            </div>
        </section>

    </form>

</body>
</html>
