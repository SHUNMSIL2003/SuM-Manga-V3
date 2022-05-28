using System;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace SuM_Manga_V3.storeitems
{
    public partial class ContantExplorerCard : System.Web.UI.Page
    {
        public int ChapterCValue = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            bool ThereIsMoreCHs = false;
            if (Request.QueryString["Manga"] == null || Request.QueryString["VC"] == null) Response.Redirect("~/404.aspx");
            string ThemeColor = string.Empty;
            if (Request.QueryString["TC"] != null)
            {
                ThemeColor = Request.QueryString["TC"].ToString();
            }
            else { ThemeColor = "var(--SuMThemeColor)"; }
            string abtntheme = "padding-block:0px;padding:0px;border-radius:0px;color:#ffffff;width:100%;height:fit-content;float:left;";//ORgbConverter(getDominantColor(bMap));------background-color:" + ThemeColor + ";
            int idfg0554 = Convert.ToInt32(Request.QueryString["VC"].ToString());
            int cn1 = 0;
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;
            using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string query = "SELECT ChaptersNumber FROM SuMManga WHERE MangaID = @MangaID";
                MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
                MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                MySqlCmd.Parameters["@MangaID"].Value = idfg0554;
                var un = MySqlCmd.ExecuteScalar();
                cn1 = Convert.ToInt32(un);
                query = "SELECT ChapterCValue FROM SuMManga WHERE MangaID = @MangaID";
                MySqlCmd = new MySqlCommand(query, MySqlCon);
                MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                MySqlCmd.Parameters["@MangaID"].Value = idfg0554;
                un = MySqlCmd.ExecuteScalar();
                ChapterCValue = Convert.ToInt32(un);
                MySqlCon.Close();
            }
            ScriptInjectorB000.InnerHtml = "<script> androidAPIs.ShowSuMToastsOverview('" + cn1.ToString() + " Chapters!'); </script>";
            string epath = System.IO.Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            if (Request.QueryString["Manga"] == null) Response.Redirect("~/404.aspx");
            string M0path = epath + "\\storeitems\\" + Request.QueryString["Manga"] + "\\";
            if (System.IO.Directory.Exists(M0path) == false) Response.Redirect("~/404.aspx");
            if (cn1 > 12)
            {
                ThereIsMoreCHs = true;
                cn1 = 12;
            }
            string ChapterFixedForm = string.Empty;
            string RLink = string.Empty;
            string themecolor = ThemeColor;
            char sc = '"';
            char b12 = '"';
            string btnanimationclass = string.Empty;
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            string managtocheckexsis = Request.QueryString["Manga"].ToString();
            string rootpath = System.IO.Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            string checkifitexsistsStart = rootpath + "\\storeitems\\" + managtocheckexsis + "\\";
            string LazyLoading = "loading=" + '"'.ToString() + "lazy" + '"'.ToString();
            if (GetUserInfoCookie != null)
            {
                if (IsPostBack == false)
                {
                }
                string MangaSName = Request.QueryString["Manga"];
                string MangaID = Request.QueryString["VC"];
                for (int c = 1; c < (cn1 + 1); c++)
                {
                    string chxC = c.ToString();
                    if (c < 10 && c > 0) { ChapterFixedForm = "000" + chxC; }
                    if (c > 9 && c < 100) { ChapterFixedForm = "00" + chxC; }
                    if (c > 99 && c < 1000) { ChapterFixedForm = "0" + chxC; }
                    if (c > 999 && c < 10000) { ChapterFixedForm = chxC; }
                    if (c > 10000) { c = (cn1 + 1); }
                    string cpcover = "/storeitems/" + Request.QueryString["Manga"].ToString() + "/sumcp" + ChapterFixedForm + ".jpg";
                    if (System.IO.Directory.Exists(checkifitexsistsStart + "ch" + ChapterFixedForm + "\\") == true)
                    {
                        RLink = "/APIs/MangaParser.aspx?MID=" + MangaID + "&CN=" + "ch" + ChapterFixedForm + "&MN=" + MangaSName;
                        TheMangaPhotosF.InnerHtml += "<a href=" + "#" + " onclick=" + sc.ToString() + "androidAPIs.SuMExploreLoadReader('" + RLink + "');" + sc.ToString() + " style=" + abtntheme + " class=" + btnanimationclass + " ><img onerror=" + b12.ToString() + "this.onerror = null; this.src = '/assets/BrokeIMG.png'" + b12.ToString() + " " + LazyLoading + " src=" + cpcover + " style=" + b12.ToString() + "margin:6px;margin-left:12px !important;width:72px;height:72px;float:left;opacity:0.92;border-radius:12px;" + b12.ToString() + "> <p style=" + b12.ToString() + "color:#ffffff;float:left;margin-left:6px;margin-top:14px !important;font-size:112%;" + b12.ToString() + ">Chapter " + chxC + "</p></a>";
                    }
                    else
                    {
                        TheMangaPhotosF.InnerHtml += "<a onclick=" + sc.ToString() + "SuMTXTShowThis('Unavailable','" + themecolor + "','Chapter " + chxC + "','ContantExplorer');" + sc.ToString() + " style=" + abtntheme + " class=" + btnanimationclass + " ><img onerror=" + b12.ToString() + "this.onerror = null; this.src = '/assets/BrokeIMG.png'" + b12.ToString() + " " + LazyLoading + " src=" + cpcover + " style=" + b12.ToString() + "margin:6px;margin-left:12px;width:72px;height:72px;float:left;opacity:0.92;border-radius:12px;opacity:0.54;" + b12.ToString() + "> <p style=" + b12.ToString() + "opacity:0.64;color:#ffffff;float:left;margin-left:6px;margin-top:14px !important;font-size:112%;" + b12.ToString() + ">Chapter " + chxC + "</p> <p style=" + b12.ToString() + "opacity:0.64;color:#ffffff;float:right;margin-right:calc(100% - 188px);margin-top:-13px;height:fit-content;width:fit-content;" + b12.ToString() + ">unavailable!</p></a>";
                    }
                    if (c < cn1) { TheMangaPhotosF.InnerHtml += "<hr style=" + sc.ToString() + "margin:0 auto !important;height:2px;border-radius:1px;border-width:0;color:#ffffff;background-color:#FFFFFF;width:80%;opacity:0.08;margin:0px;margin-block:0px;" + sc.ToString() + ">"; }
                }
            }
            if (ThereIsMoreCHs == true)
            {
                ThreIsMoreACard.Attributes["style"] = "width:100%;height:fit-content;text-align:center !important;margin:0 auto !important;display:block;padding-bottom:2px !important;padding-top:60px !important;";
            }
            else
            {
                ThreIsMoreACard.Attributes["style"] = "display:none;";
            }
            if (GetUserInfoCookie != null)
            {
                int UID = Convert.ToInt32(GetUserInfoCookie["ID"].ToString());
                ReasentMarker(UID);
            }
        }
        protected void ReasentMarker(int UID)
        {
            object RawRes;
            string NewSol = string.Empty;
            string Target = "#" + Request.QueryString["VC"].ToString() + "&";
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string qwi = "SELECT Resently FROM SuMUsersAccounts WHERE UserID = @UID";
                MySqlCommand MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                MySqlCmd00.Parameters["@UID"].Value = UID;
                RawRes = MySqlCmd00.ExecuteScalar();
                if (RawRes != null)
                {
                    if (RawRes.ToString().Contains(Target) == true)
                    {
                        NewSol = Target + RawRes.ToString().Replace(Target, "");
                    }
                    else
                    {
                        NewSol = Target + RawRes.ToString();
                    }
                }
                else
                {
                    NewSol = Target;
                }
                qwi = "UPDATE SuMUsersAccounts SET Resently = @NEWResently WHERE UserID = @UID";
                MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                MySqlCmd00.Parameters.AddWithValue("@NEWResently", NewSol);
                MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                MySqlCmd00.Parameters["@UID"].Value = UID;
                MySqlCmd00.ExecuteNonQuery();
                MySqlCon.Close();
            }
        }
        protected void LOADMORECHAPTERS(object sender, EventArgs e)
        {
            int CSN = 1 * 12;
            int CEN = 0;
            int idfg0554 = Convert.ToInt32(Request.QueryString["VC"].ToString());
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string query = "SELECT ChaptersNumber FROM SuMManga WHERE MangaID = @MangaID";
                MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
                MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                MySqlCmd.Parameters["@MangaID"].Value = idfg0554;
                var un = MySqlCmd.ExecuteScalar();
                CEN = Convert.ToInt32(un);
                MySqlCon.Close();
            }
            string ThemeColor = Request.QueryString["TC"].ToString();
            string abtntheme = "padding-block:0px;padding:0px;border-radius:0px;color:#ffffff;width:100%;height:fit-content;float:left;";
            string ChapterFixedForm = string.Empty;
            string RLink = string.Empty;
            string themecolor = ThemeColor;
            char sc = '"';
            char b12 = '"';
            TheMangaPhotosF.InnerHtml += "<hr style=" + sc.ToString() + "margin:0 auto !important;height:2px;border-radius:1px;border-width:0;color:#ffffff;background-color:#FFFFFF;width:80%;opacity:0.08;margin:0px;margin-block:0px;" + sc.ToString() + ">";
            string btnanimationclass = string.Empty;
            btnanimationclass = b12.ToString() + "fadeIn animated btn" + b12.ToString();
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            string managtocheckexsis = Request.QueryString["Manga"].ToString();
            string rootpath = System.IO.Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            string checkifitexsistsStart = rootpath + "\\storeitems\\" + managtocheckexsis + "\\";
            string LazyLoading = "loading=" + '"'.ToString() + "lazy" + '"'.ToString();
            if (GetUserInfoCookie != null)
            {
                string MangaSName = Request.QueryString["Manga"];
                string MangaID = Request.QueryString["VC"];
                for (int c = (CSN + 1); c < (CEN + 1); c++)
                {
                    string chxC = c.ToString();
                    if (c < 10 && c > 0) { ChapterFixedForm = "000" + chxC; }
                    if (c > 9 && c < 100) { ChapterFixedForm = "00" + chxC; }
                    if (c > 99 && c < 1000) { ChapterFixedForm = "0" + chxC; }
                    if (c > 999 && c < 10000) { ChapterFixedForm = chxC; }
                    if (c > 10000) { c = (CEN + 1); }
                    string cpcover = "/storeitems/" + Request.QueryString["Manga"].ToString() + "/sumcp" + ChapterFixedForm + ".jpg";
                    if (System.IO.Directory.Exists(checkifitexsistsStart + "ch" + ChapterFixedForm + "\\") == true)
                    {
                        RLink = "/APIs/MangaParser.aspx?MID=" + MangaID + "&CN=" + "ch" + ChapterFixedForm + "&MN=" + MangaSName;
                        TheMangaPhotosF.InnerHtml += "<a href=" + "#" + " onclick=" + sc.ToString() + "androidAPIs.SuMExploreLoadReader('" + RLink + "');" + sc.ToString() + " style=" + abtntheme + " class=" + btnanimationclass + " ><img onerror=" + b12.ToString() + "this.onerror = null; this.src = '/assets/BrokeIMG.png'" + b12.ToString() + " " + LazyLoading + " src=" + cpcover + " style=" + b12.ToString() + "margin:6px;margin-left:12px !important;width:72px;height:72px;float:left;opacity:0.92;border-radius:12px;" + b12.ToString() + "> <p style=" + b12.ToString() + "color:#ffffff;float:left;margin-left:6px;margin-top:14px !important;font-size:112%;" + b12.ToString() + ">Chapter " + chxC + "</p></a>";
                    }
                    else
                    {
                        TheMangaPhotosF.InnerHtml += "<a onclick=" + sc.ToString() + "SuMTXTShowThis('Unavailable','" + themecolor + "','Chapter " + chxC + "','ContantExplorer');" + sc.ToString() + " style=" + abtntheme + " class=" + btnanimationclass + " ><img onerror=" + b12.ToString() + "this.onerror = null; this.src = '/assets/BrokeIMG.png'" + b12.ToString() + " " + LazyLoading + " src=" + cpcover + " style=" + b12.ToString() + "margin:6px;margin-left:12px;width:72px;height:72px;float:left;opacity:0.92;border-radius:12px;opacity:0.54;" + b12.ToString() + "> <p style=" + b12.ToString() + "opacity:0.64;color:#ffffff;float:left;margin-left:6px;margin-top:14px !important;font-size:112%;font-size:112%;" + b12.ToString() + ">Chapter " + chxC + "</p> <p style=" + b12.ToString() + "opacity:0.64;color:#ffffff;float:right;margin-right:calc(100% - 188px);margin-top:-13px;height:fit-content;width:fit-content;" + b12.ToString() + ">unavailable!</p></a>";
                    }
                    if (c < CEN) { TheMangaPhotosF.InnerHtml += "<hr style=" + sc.ToString() + "margin:0 auto !important;height:2px;border-radius:1px;border-width:0;color:#ffffff;background-color:#FFFFFF;width:80%;opacity:0.08;margin:0px;margin-block:0px;" + sc.ToString() + ">"; }
                }
            }
            ThreIsMoreACard.Attributes["style"] = "display:none;";
            LoadChapters.Update();
        }
    }
}