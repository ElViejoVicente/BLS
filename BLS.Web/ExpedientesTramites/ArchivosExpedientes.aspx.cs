using DevExpress.Web;
using DevExpress.XtraPrinting;
using BLS.Negocio.CRUD;
using BLS.Negocio.ORM;
using BLS.Web.Controles.Servidor;
using System.ComponentModel.Design;
using System;


namespace BLS.Web.ExpedientesTramites
{
    public partial class ArchivosExpedientes : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void fmArchivosControl_CustomThumbnail(object source, DevExpress.Web.FileManagerThumbnailCreateEventArgs e)
        {
            if (e.File == null)
            {
                return;
            }

            switch (((FileManagerFile)e.Item).Extension)
            {
                case ".pdf":
                    e.ThumbnailImage.Url = "../imagenes/Iconos/application-pdf-2.ico";
                    break;
                case ".doc":
                    e.ThumbnailImage.Url = "../imagenes/Iconos/x-office-document.ico";
                    break;
                case ".docx":
                    e.ThumbnailImage.Url = "../imagenes/Iconos/x-office-document.ico";
                    break;
                case ".xlsx":
                    e.ThumbnailImage.Url = "../imagenes/Iconos/x-office-spreadsheet.ico";
                    break;
                case ".xls":
                    e.ThumbnailImage.Url = "../imagenes/Iconos/x-office-spreadsheet.ico";
                    break;
                case ".png":
                    e.ThumbnailImage.Url = "../imagenes/Iconos/image-x-generic.ico";
                    break;
                case ".txt":
                    e.ThumbnailImage.Url = "../imagenes/Iconos/text-x-generic.ico";
                    break;
                case ".rtf":
                    e.ThumbnailImage.Url = "../imagenes/Iconos/image-x-generic.ico";
                    break;
                case ".gif":
                    e.ThumbnailImage.Url = "../imagenes/Iconos/image-x-generic.ico";
                    break;
                case ".jpeg":
                    e.ThumbnailImage.Url = "../imagenes/Iconos/image-x-generic.ico";
                    break;
                case ".jpg":
                    e.ThumbnailImage.Url = "../imagenes/Iconos/image-x-generic.ico";
                    break;
            }
        }

    }
}
