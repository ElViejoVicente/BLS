<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InfoMsgBox.ascx.cs" Inherits=" BLS.Web.Controles.Usuario.InfoMsgBox" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v25.2, Version=25.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

 <script>
function onClickOK(s, e) {  
       __doPostBack("Aceptar", "true");
} 
function onClickCancel(s, e) {  
       __doPostBack("Cancelar", "true");
} 
</script>

<dx:ASPxPopupControl ID="ppControl" ClientInstanceName="ppControl" runat="server" Height="70px" Width="450px" EnableClientSideAPI="True" PopupElementID="grid" Modal="True"
    PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AppearAfter="4000" DisappearAfter="4000" AllowResize="false" AllowDragging="false">
    <CloseButtonImage Url="../../imagenes/mensajes/close20Negro.png" AlternateText="No image" />
    <HeaderStyle ForeColor="WhiteSmoke" Font-Size="12px" BackColor="#9e311c" />
    <ContentStyle ForeColor="#666677" Font-Names="Tahoma" Font-Size="10px" />
    <controls>
        <asp:Table ID="Table2" runat="server" Height="100%" Width="100%">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" HorizontalAlign="Left"  VerticalAlign="Middle" Width="15%">
                    <dx:ASPxImage ID="imgIcon" runat="server"  Width="35px" Height="35px" ShowLoadingImage="true" />
                </asp:TableCell>
                    <asp:TableCell runat="server"  HorizontalAlign="Left" VerticalAlign="Middle" Width="85%">
                    <dx:ASPxLabel ID="Lbl_Mensaje" runat="server" Text="ASPxLabel" Width="100%" ></dx:ASPxLabel>
                </asp:TableCell>
              
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" HorizontalAlign="Right"  VerticalAlign="Middle" Width="40%">
                    <dx:ASPxButton ID="BtnOK" runat="server" Text="" CssClass="fas fa-check" ToolTip="Aceptar"
                        Style='font-size: 17px'  visible="false">
                        <ClientSideEvents Click="onClickOK" />  
                    </dx:ASPxButton>
                   
                </asp:TableCell>
                
                    <asp:TableCell runat="server"  HorizontalAlign="Center" VerticalAlign="Middle" Width="40%">
                         <dx:ASPxButton ID="BtnNo" runat="server" Text="" CssClass="fas fa-times" ToolTip="Cancelar"
                        Style='font-size: 17px' visible="false">
                        <ClientSideEvents Click="onClickCancel" />  
                    </dx:ASPxButton>
                     
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </controls>
</dx:ASPxPopupControl>


