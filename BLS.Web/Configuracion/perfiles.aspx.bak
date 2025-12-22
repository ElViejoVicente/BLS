<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="perfiles.aspx.cs" Inherits=" SGN.Web.Configuracion.Perfiles" %>

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

        function perfil_RowClick(s, e) {
            __doPostBack("seleccionar", "true");
            Callback.PerformCallback();
        }

        function asignacionPerfil() {
            __doPostBack("asignacionPerfil", "true");
            Callback.PerformCallback();
        }
    </script>
    <style>
        .componentes {
            width: 50%;
        }
    </style>
</head>

<body>
    <form id="frmPage" runat="server" class="Principal">
        <uc1:cuInfoMsgbox runat="server" ID="cuInfoMsgbox1" />      
      
        <section class="CLPageContent">
            <div class="">

                <dx:ASPxPageControl ID="carTabPage" runat="server" ActiveTabIndex="0"
                    Width="100%" AutoPostBack="True" Font-Size="Large" OnTabClick="carTabPage_TabClick">
                    <TabPages>
                        <dx:TabPage Name="TpPerfil" Text="Perfil por Usuario">
                            <ContentCollection>
                                <dx:ContentControl ID="TpPerfil" runat="server">
                                    <div class="col-md-24">
                                        <dx:ASPxComboBox Caption="Usuario" runat="server" ID="Cb_Usuarios" AutoPostBack="True" Width="200px" OnDataBinding="Cb_Usuarios_DataBinding"
                                            OnSelectedIndexChanged="Cb_Usuarios_SelectedIndexChanged">
                                        </dx:ASPxComboBox>
                                    </div>
                                    <br />
                                    <div class="col-md-24">
                                        <dx:ASPxGridView ID="GV_Perfil" runat="server" AutoGenerateColumns="False" KeyFieldName="Id" Width="100%" ClientIDMode="Static" EnableCallBacks="false"
                                            OnDataBinding="GV_Perfil_DataBinding"
                                            OnRowUpdating="GV_Perfil_RowUpdating"
                                            OnRowInserting="GV_Perfil_RowInserting"
                                            OnInitNewRow="GV_Perfil_InitNewRow">

                                            <SettingsEditing Mode="Batch"></SettingsEditing>
                                            <SettingsBehavior AllowFocusedRow="true" ProcessFocusedRowChangedOnServer="true" />
                                            <SettingsDataSecurity AllowDelete="False" AllowInsert="False" />
                                            <SettingsSearchPanel Visible="True" ShowClearButton="true" />
                                            <EditFormLayoutProperties>
                                                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit"></SettingsAdaptivity>
                                            </EditFormLayoutProperties>
                                            <Columns>
                                                <dx:GridViewDataCheckColumn FieldName="chk" CellStyle-HorizontalAlign="Center" VisibleIndex="1" Caption="Asignaciòn">
                                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                                </dx:GridViewDataCheckColumn>
                                                <dx:GridViewDataTextColumn FieldName="Id" Caption="ID" VisibleIndex="2" Visible="true" ReadOnly="true">
                                                    <PropertiesTextEdit EnableFocusedStyle="False"></PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Nombre" Caption="Nombre Perfil" VisibleIndex="3" ReadOnly="True">
                                                    <PropertiesTextEdit EnableFocusedStyle="False">
                                                        <ValidationSettings>
                                                            <RequiredField IsRequired="True" ErrorText="Campo requerido."></RequiredField>
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Desc" Caption="Descripción" VisibleIndex="4" ReadOnly="True">
                                                    <PropertiesTextEdit EnableFocusedStyle="False">
                                                        <ValidationSettings>
                                                            <RequiredField IsRequired="True" ErrorText="Campo requerido."></RequiredField>
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataCheckColumn FieldName="Activo" Caption="Activo" VisibleIndex="5" ReadOnly="True">
                                                </dx:GridViewDataCheckColumn>
                                            </Columns>
                                        </dx:ASPxGridView>
                                    </div>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:TabPage>
                        <dx:TabPage Name="TpModulos" Text="Perfiles y Módulos">
                            <ContentCollection>
                                <dx:ContentControl runat="server" CssClass="">
                                    <div style="display: inline-block; width: 100%">
                                        <div class="col-md-12">
                                            <dx:ASPxGridView ID="GV_modulo_perfil" runat="server" AutoGenerateColumns="False" KeyFieldName="Id" Width="100%" EnableCallBacks="false"
                                                OnDataBinding="GV_modulo_perfil_DataBinding"
                                                OnRowUpdating="GV_modulo_perfil_RowUpdating"
                                                OnRowInserting="GV_modulo_perfil_RowInserting"
                                                OnInitNewRow="GV_modulo_perfil_InitNewRow">
                                                <ClientSideEvents RowDblClick="perfil_RowClick"></ClientSideEvents>

                                                <SettingsBehavior AllowSelectByRowClick="True" ProcessFocusedRowChangedOnServer="True" AllowSelectSingleRowOnly="True" />
                                                <SettingsEditing Mode="EditForm"></SettingsEditing>
                                                <EditFormLayoutProperties>
                                                    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit"></SettingsAdaptivity>
                                                </EditFormLayoutProperties>
                                                <Columns>
                                                    <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0" ButtonRenderMode="Button" ButtonType="Button" />

                                                    <dx:GridViewDataTextColumn FieldName="Id" Caption="ID" VisibleIndex="1" Visible="true" ReadOnly="true" />
                                                    <dx:GridViewDataTextColumn FieldName="Nombre" Caption="Nombre Perfil" VisibleIndex="2" >
                                                        <PropertiesTextEdit EnableFocusedStyle="False">
                                                            <ValidationSettings>
                                                                <RequiredField IsRequired="True" ErrorText="Campo requerido."></RequiredField>
                                                            </ValidationSettings>
                                                        </PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="Desc" Caption="Descripción" VisibleIndex="3">
                                                        <PropertiesTextEdit>
                                                            <ValidationSettings>
                                                                <RequiredField IsRequired="True" ErrorText="Campo requerido."></RequiredField>
                                                            </ValidationSettings>
                                                        </PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataCheckColumn FieldName="Activo" Caption="Activo" VisibleIndex="4">
                                                    </dx:GridViewDataCheckColumn>
                                                </Columns>
                                            </dx:ASPxGridView>

                                        </div>

                                    </div>
                                    <div class="col-md-12" style="">


                                        <div id="ContModulos" class="contmenu" style="width: 100%; margin: 10px 50px 0px 0px; border: 1px solid #a52a2a;">

                                            <dx:ASPxTreeView ID="rtvModulos" runat="server" Theme="Default" AutoGenerateColumns="False" OnCheckedChanged="rtvModulos_CheckedChanged" EnableCallBacks="false"
                                                AutoPostBack="false">
                                            </dx:ASPxTreeView>

                                        </div>

                                    </div>
                                </dx:ContentControl>
                            </ContentCollection>

                        </dx:TabPage>
                    </TabPages>
                </dx:ASPxPageControl>
            </div>
        </section>

        <footer class="CLPageFooter">
            © Derechos Reservados 2020-2021 CL Grupo Industrial Todos los Derechos Reservados.
        </footer>
    </form>

</body>
</html>
