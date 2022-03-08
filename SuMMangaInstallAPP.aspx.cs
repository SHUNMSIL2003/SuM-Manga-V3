using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuM_Manga_V3
{
    public partial class SuMMangaInstallAPP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void AndroidDownloadAppStart(object sender, EventArgs e)
        {
            Response.ContentType = "application/apk";
            Response.AppendHeader("Content-Disposition", "attachment; filename=SuM-Manga-330.apk");
            Response.TransmitFile(Server.MapPath("~/SuM-Manga-330.apk"));
            Response.End();
        }
    }
}