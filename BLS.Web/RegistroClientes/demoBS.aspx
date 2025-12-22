<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="demoBS.aspx.cs" Inherits="BLS.Web.RegistroClientes.demoBS" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v25.2, Version=25.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <link rel="stylesheet" href="../SwitcherResources/Content/Cyborg/bootstrap.min.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">


        <div>

            <dx:BootstrapFormLayout runat="server" ID="frmAltaCliente" AlignItemCaptionsInAllGroups="True">

                <Items>
                    <dx:BootstrapLayoutGroup ColumnCount="12" Caption="Datos Personales" ColCount="12">
                        <Items>
                            <dx:BootstrapLayoutItem Caption="Nombre">
                                <ContentCollection>
                                    <dx:ContentControl runat="server">
                                        <dx:BootstrapTextBox runat="server" ID="frmAltaCliente_E1"></dx:BootstrapTextBox>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:BootstrapLayoutItem>
                            <dx:BootstrapLayoutItem Caption="app Paterno">
                                <ContentCollection>
                                    <dx:ContentControl runat="server">
                                        <dx:BootstrapTextBox runat="server" ID="frmAltaCliente_E2"></dx:BootstrapTextBox>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:BootstrapLayoutItem>
                            <dx:BootstrapLayoutItem Caption="fecha Nacimiento">
                                <ContentCollection>
                                    <dx:ContentControl runat="server">
                                        <dx:BootstrapCalendar runat="server" ID="frmAltaCliente_E3"></dx:BootstrapCalendar>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:BootstrapLayoutItem>
                        </Items>
                    </dx:BootstrapLayoutGroup>
                    <dx:BootstrapLayoutGroup ColumnCount="12" Caption="aceso" ColCount="12">
                        <Items>
                            <dx:BootstrapLayoutItem>
                                <ContentCollection>
                                    <dx:ContentControl runat="server">
                                        <dx:BootstrapButton runat="server" ID="frmAltaCliente_E4"></dx:BootstrapButton>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:BootstrapLayoutItem>
                            <dx:BootstrapLayoutItem>
                                <ContentCollection>
                                    <dx:ContentControl runat="server">
                                        <dx:BootstrapCheckBox runat="server" CheckState="Unchecked" ID="frmAltaCliente_E5"></dx:BootstrapCheckBox>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:BootstrapLayoutItem>
                            <dx:BootstrapLayoutItem>
                                <ContentCollection>
                                    <dx:ContentControl runat="server">
                                        <dx:BootstrapRadioButtonList runat="server" ID="frmAltaCliente_E6"></dx:BootstrapRadioButtonList>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:BootstrapLayoutItem>
                            <dx:BootstrapLayoutItem>
                                <ContentCollection>
                                    <dx:ContentControl runat="server">
                                        <dx:BootstrapDateEdit runat="server" ID="frmAltaCliente_E7"></dx:BootstrapDateEdit>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:BootstrapLayoutItem>
                        </Items>
                    </dx:BootstrapLayoutGroup>
                </Items>
            </dx:BootstrapFormLayout>

        </div>
    </form>
</body>
</html>
