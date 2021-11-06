using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuM_Manga_V3.SuMCreator
{
    public partial class CreatorPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            if (GetUserInfoCookie == null)
            {
                //MPB.InnerText = "Explore";
                //MPB.Attributes["href"] = "Library.aspx";
                Response.Redirect("~/AccountETC/LoginETC.aspx");
            }
            else
            {
                if (GetUserInfoCookie["CreatorName"] == null || GetUserInfoCookie["CreatorName"] == string.Empty) { Response.Redirect("~/404.aspx"); }
                else
                {
                 
                }
            }
        }
    }
}