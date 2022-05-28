using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient; using MySql.Data.MySqlClient; using System.Configuration;

namespace SuM_Manga_V3
{
    public partial class SuMManga_Mobile_card : System.Web.UI.MasterPage
    {
        private void Page_PreInit(object sender, EventArgs e)
        {
            if (!Request.Browser.IsMobileDevice) Response.Redirect("~/SuMMangaInstallAPP.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string UserThemeColor = string.Empty;
            HttpCookie userInfo = Request.Cookies["SuMUserThemeColor"];
            if (userInfo != null)
            {
                object FRGBROOTRC = userInfo["RGBRoot"];
                UserThemeColor = FRGBROOTRC.ToString();
            }
            else
            {
                UserThemeColor = "104,64,217";
            }
            SuMUserThemeColorCSSDiv.InnerHtml = BuildSuMUserThemeCSS(UserThemeColor);
        }
        protected string BuildSuMUserThemeCSS(string RGBRoot)
        {
            string RS = "<style> :root { --SuMThemeColor: rgb(" + RGBRoot + "); --SuMThemeColorOP94: rgba(" + RGBRoot + ",0.940); --SuMThemeColorOP92: rgba(" + RGBRoot + ",0.920); --SuMThemeColorOP86: rgba(" + RGBRoot + ",0.860); --SuMThemeColorOP84: rgba(" + RGBRoot + ",0.840); --SuMThemeColorOP74: rgba(" + RGBRoot + ",0.740); --SuMThemeColorOP64: rgba(" + RGBRoot + ",0.640); --SuMThemeColorOP62: rgba(" + RGBRoot + ",0.620); --SuMThemeColorOP54: rgba(" + RGBRoot + ",0.540); --SuMThemeColorOP32: rgba(" + RGBRoot + ",0.320); --SuMThemeColorOP14: rgba(" + RGBRoot + ",0.140); --SuMThemeColorOP08: rgba(" + RGBRoot + ",0.080); --SuMThemeColorOP00: rgba(" + RGBRoot + ",0.000); } </style>";
            return RS;
        }
    }
}