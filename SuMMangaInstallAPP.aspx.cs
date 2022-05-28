using System;

namespace SuM_Manga_V3
{
    public partial class SuMMangaInstallAPP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /*protected private void AndroidDownloadAppStart(object sender, EventArgs e)
        {
            Response.ContentType = "application/apk";
            Response.AppendHeader("Content-Disposition", "attachment; filename=SuM-Manga-330.apk");
            Response.TransmitFile(Server.MapPath("~/SuM-Manga-330.apk"));
            Response.End();
        }*/
    }
}