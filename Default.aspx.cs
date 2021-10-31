using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuM_Manga_V3
{
    public partial class Default : System.Web.UI.Page
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
                MPB.InnerText = "Explore";
                MPB.Attributes["href"] = "Library.aspx";
            }
        }
    }
}