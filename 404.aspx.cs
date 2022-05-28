using System;

namespace SuM_Manga_V3
{
    public partial class _404 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object e_msg_obj = Request.QueryString["aspxerrorpath"];
            string e_mgs = "no info";
            if (e_msg_obj != null) e_mgs = e_msg_obj.ToString();
            Response.Clear();
            Response.ContentType = "text/plain; charset=utf-8";
            Response.Write("[SERVER_ERROR]:"+ e_mgs);
            Response.End();
        }
    }
}