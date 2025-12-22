<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArchivosExpedientes.aspx.cs" Inherits="BLS.Web.ExpedientesTramites.ArchivosExpedientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../Content/all.css" />
    <link rel="stylesheet" href="../Content/generic/pageMinimalStyle.css" />
    <script src="../Scripts/sweetalert2.all.min.js"></script>
    <link rel="stylesheet" href="../Scripts/sweetalert2.min.css"/>
    <script src="../Scripts/mensajes.js"></script>
    <script>

    </script>

    <title>SGN</title>
</head>
<body>
    <form id="frmPage" runat="server" class="Principal">
        <section class="CLPageContent" id="maindiv">       

              <dx:ASPxFileManager ID="fmArchivosControl" ClientInstanceName="fmArchivosControl" runat="server" OnCustomThumbnail="fmArchivosControl_CustomThumbnail" >
                            <Settings RootFolder="~/GNArchivosRoot" AllowedFileExtensions=".jpg,.jpeg,.gif,.rtf,.txt,.png,.xls,.xlsx,.docx,.doc,.pdf" EnableMultiSelect="true" />
                            <SettingsEditing AllowCreate="false" AllowDelete="true" AllowMove="true" AllowRename="true" AllowCopy="true" AllowDownload="true" />
                            <SettingsFileList View="Details">
                                <DetailsViewSettings AllowColumnResize="true" AllowColumnDragDrop="true" AllowColumnSort="true" ShowHeaderFilterButton="false" />
                            </SettingsFileList>
                            <SettingsFileList ShowFolders="true" ShowParentFolder="true" />
                            <SettingsBreadcrumbs Visible="true" ShowParentFolderButton="true" Position="Top" />
                            <SettingsUpload UseAdvancedUploadMode="true">
                                <AdvancedModeSettings EnableMultiSelect="true" />
                            </SettingsUpload>
                            <SettingsAdaptivity Enabled="true" />
                        </dx:ASPxFileManager>

        </section>
    </form>
</body>
</html>
