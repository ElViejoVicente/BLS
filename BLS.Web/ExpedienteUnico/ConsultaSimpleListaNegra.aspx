<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultaSimpleListaNegra.aspx.cs" Inherits="BLS.Web.ExpedienteUnico.ConsultaSimpleListaNegra" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v25.2, Version=25.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v25.2, Version=25.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../SwitcherResources/Content/Cosmo/bootstrap.min.css" crossorigin="anonymous" />
    <link rel="stylesheet" href="../Content/all.css" />
    <link rel="stylesheet" href="../Content/generic/pageMinimalStyle.css" />
    <script src="../Scripts/sweetalert2.all.min.js"></script>
    <link rel="stylesheet" href="../Scripts/sweetalert2.min.css"/>
    <script src="../Scripts/mensajes.js"></script>

    <script  type="text/javascript" >
        function VerReporte(s, e) {

            window.open("../Reportes/reporteAcuseConsultaListaNegraSimple.aspx", "_blank");
        }
    </script>
        

    <title>SGN</title>
</head>
<body>
    <form id="form1" runat="server" class="Principal">
        <section class="CLPageContent" id="maindiv">

            <dx:ASPxCallbackPanel runat="server" ID="pnBusquedaListaNegra" ClientInstanceName="pnBusquedaListaNegra" 
                OnCallback="pnBusquedaListaNegra_Callback">
                <ClientSideEvents EndCallback="VerReporte" />
                <PanelCollection>
                    <dx:PanelContent>
                        <dx:ASPxFormLayout runat="server" ID="frmConsultaListaNegra" Width="40%">

                            <Items>
                                <dx:LayoutGroup Caption="Datos de consulta" ColCount="2" ColumnCount="2" ColSpan="1">
                                    <Items>
                                        <dx:LayoutItem Caption="Nombre (s)" ColSpan="2" ColumnSpan="2">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxTextBox runat="server" ID="txtNombre" Width="100%">
                                                        <ValidationSettings ValidationGroup="validacion">
                                                            <RequiredField IsRequired="true" ErrorText="Campo Obligatorio." />
                                                        </ValidationSettings>
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Apellido Paterno" ColSpan="2" ColumnSpan="2">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxTextBox runat="server" ID="txtApellidoPaterno" Width="100%">
                                                        <ValidationSettings ValidationGroup="validacion">
                                                            <RequiredField IsRequired="true" ErrorText="Campo Obligatorio." />
                                                        </ValidationSettings>
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Apellido Materno" ColSpan="2" ColumnSpan="2">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxTextBox runat="server" ID="txtApellidoMaterno" Width="100%">
                                                        <ValidationSettings ValidationGroup="validacion">
                                                            <RequiredField IsRequired="true" ErrorText="Campo Obligatorio." />
                                                        </ValidationSettings>
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Sexo" ColSpan="2" ColumnSpan="2">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxRadioButtonList runat="server" ID="chkSexo">
                                                        <Items>
                                                            <dx:ListEditItem Text="Hombre" Value="H"></dx:ListEditItem>
                                                            <dx:ListEditItem Text="Mujer" Value="M"></dx:ListEditItem>
                                                        </Items>
                                                        <ValidationSettings ValidationGroup="validacion">
                                                            <RequiredField IsRequired="true" ErrorText="Campo Obligatorio." />
                                                        </ValidationSettings>
                                                    </dx:ASPxRadioButtonList>

                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Fecha de nacimiento:" ColSpan="2" ColumnSpan="2">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxDateEdit runat="server" ID="dtFechaNacimiento">
                                                        <ValidationSettings ValidationGroup="validacion">
                                                            <RequiredField IsRequired="true" ErrorText="Campo Obligatorio." />
                                                        </ValidationSettings>
                                                    </dx:ASPxDateEdit>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="RFC" ColSpan="2" ColumnSpan="2">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxTextBox runat="server" ID="txtRFC" Width="100%">
                                                        <ValidationSettings ValidationGroup="validacion">
                                                            <RequiredField IsRequired="true" ErrorText="Campo Obligatorio." />
                                                        </ValidationSettings>
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Tipo Persona" ColSpan="2" ColumnSpan="2">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxRadioButtonList runat="server" ID="chkTipoPersona" ClientInstanceName="chkTipoPersona">
                                                        <Items>
                                                            <dx:ListEditItem Text="Fisica" Value="Fisica"></dx:ListEditItem>
                                                            <dx:ListEditItem Text="Moral" Value="Moral"></dx:ListEditItem>
                                                        </Items>
                                                        <ClientSideEvents SelectedIndexChanged="  function(s, e) {
                                                                                 if (chkTipoPersona.GetValue()=='Fisica')
                                                                                     {
                                                                                          txtNombreSociedad.SetEnabled(false);
                                                                                          txtNombreSociedad.SetValue('No requerido');
                                                                                     }
                                                                                     else
                                                                                     {
                                                                                          txtNombreSociedad.SetEnabled(true);
                                                                                          txtNombreSociedad.SetValue('');
                                                                                     }
                                                                                 }" />

                                                        <ValidationSettings ValidationGroup="validacion">
                                                            <RequiredField IsRequired="true" ErrorText="Campo Obligatorio." />
                                                        </ValidationSettings>
                                                    </dx:ASPxRadioButtonList>

                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Sociedad:" ColSpan="2" ColumnSpan="2">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxTextBox runat="server" ID="txtNombreSociedad" ClientInstanceName="txtNombreSociedad" Width="100%"></dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="" ColSpan="1">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxButton runat="server" Text="Consultar" ID="btnConsultar" AutoPostBack="false" >
                                                        <Image IconID="actions_show_16x16gray"></Image>
                                                        <ClientSideEvents Click="function(s, e) {
                                                                               if (ASPxClientEdit.ValidateGroup('validacion'))
                                                                                   {
                                                                                   pnBusquedaListaNegra.PerformCallback('Busqueda'); 
                                                                                   }
                                                                               }" />

                                                    </dx:ASPxButton>

                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                            </Items>
                        </dx:ASPxFormLayout>
                    </dx:PanelContent>
                </PanelCollection>

            </dx:ASPxCallbackPanel>


        </section>
    </form>
</body>
</html>
