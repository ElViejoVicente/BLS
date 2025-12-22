<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modulos.aspx.cs" Inherits=" SGN.Web.Configuracion.Modulos" %>


<%@ Register Src="~/Controles/Usuario/InfoMsgBox.ascx" TagPrefix="uc1" TagName="cuInfoMsgbox" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v25.1, Version=25.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="user-scalable=0, width=device-width, initial-scale=1.0, maximum-scale=1.0" />

    <link rel="stylesheet" href="../Content/all.css" crossorigin="anonymous" />
    <link rel="stylesheet" href="../Content/generic/pageStyle.css" crossorigin="anonymous" />


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
                <dx:ASPxGridView ID="gvModulos" runat="server" AutoGenerateColumns="False" KeyFieldName="IdModulo" Width="100%" EnableCallBacks="false"
                    OnDataBinding="gvModulos_DataBinding"
                    OnRowUpdating="gvModulos_RowUpdating"
                    OnRowInserting="gvModulos_RowInserting"
                    OnInitNewRow="gvModulos_InitNewRow">
                    <Settings HorizontalScrollBarMode="Visible" />
                    <SettingsPager PageSize="40" ></SettingsPager>
                    <SettingsAdaptivity AdaptivityMode="HideDataCellsWindowLimit"
                        AllowOnlyOneAdaptiveDetailExpanded="true"
                        AllowHideDataCellsByColumnMinWidth="true">
                    </SettingsAdaptivity>
                    <SettingsEditing Mode="EditForm"></SettingsEditing>

                    <SettingsSearchPanel Visible="True" ShowClearButton="true" />
                    <EditFormLayoutProperties>
                        <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit"></SettingsAdaptivity>
                    </EditFormLayoutProperties>
                    <Columns>
                        <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0" ButtonRenderMode="Button" ButtonType="Button" />

                         <dx:GridViewDataTextColumn FieldName="IdModulo" Caption="" VisibleIndex="1" Visible="false">
                            <PropertiesTextEdit>
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" ErrorText="Campo requerido."></RequiredField>
                                </ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Descripcion" Caption="" VisibleIndex="2">
                            <PropertiesTextEdit>
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" ErrorText="Campo requerido."></RequiredField>
                                </ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="DescripcioLarga" Caption="" VisibleIndex="3" >
                            <PropertiesTextEdit >
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" ErrorText="Campo requerido."></RequiredField>
                                </ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="URL" Caption="" VisibleIndex="4"  Width="300px">
                            <PropertiesTextEdit>
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" ErrorText="Campo requerido."></RequiredField>
                                </ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="ParentID" Caption="" VisibleIndex="5">
                            <PropertiesTextEdit>
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" ErrorText="Campo requerido."></RequiredField>
                                </ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="UrlICon" Caption="Url Icon" VisibleIndex="7" Width="280px">
                            <PropertiesTextEdit>
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" ErrorText="Campo requerido."></RequiredField>
                                </ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="UrlIConLarge" Caption="Url Icon largo" VisibleIndex="8"  Width="280px">
                            <PropertiesTextEdit>
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" ErrorText="Campo requerido."></RequiredField>
                                </ValidationSettings>
                             </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Orden" Caption="" VisibleIndex="9" />
                        <dx:GridViewDataTextColumn FieldName="Version" Caption="" VisibleIndex="10">
                            <PropertiesTextEdit>
                                <ValidationSettings>
                                    <RequiredField IsRequired="True" ErrorText="Campo requerido."></RequiredField>
                                </ValidationSettings>
                             </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Comentarios" Caption="Comentario" VisibleIndex="11"  Width="200px">
                            <PropertiesTextEdit ConvertEmptyStringToNull="False"></PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>

                    </Columns>
                </dx:ASPxGridView>
            </div>
        </section>

       <%-- <footer class="CLPageFooter">
            © Derechos Reservados 2020-2021 CL Grupo Industrial Todos los Derechos Reservados.
        </footer>--%>
    </form>

</body>
</html>

