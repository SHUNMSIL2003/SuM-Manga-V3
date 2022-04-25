using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient; using MySql.Data.MySqlClient; using System.Configuration;
using System.Data;
using System.Drawing;
using System.Net.Mail;
using System.IO;
using System.Text;

namespace SuM_Manga_V3.storeitems
{
    public partial class ContantExplorerCard : System.Web.UI.Page
    {
        public int ChapterCValue = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //TheMangaPhotosF.Attributes["style"] = "width:100%;height:fit-content;padding-top:6px;background-color:" + Request.QueryString["TC"].Replace("0.74", "1") + ";";
            //LastRefreshPross();   -- Needs work  %-- No need now !
            bool ThereIsMoreCHs = false;
            if (Request.QueryString["Manga"] == null || Request.QueryString["VC"] == null) { backhome(); }
            string CardBG = string.Empty;
            string MangaNameFMySql = ShowName();
            string ThemeColor = string.Empty;
            if (Request.QueryString["TC"] != null)
            {
                ThemeColor = Request.QueryString["TC"].ToString();
            }
            else { ThemeColor = "var(--SuMThemeColor)"; }
            string abtntheme = "padding-block:0px;padding:0px;border-radius:0px;color:#ffffff;width:100%;height:fit-content;float:left;";//ORgbConverter(getDominantColor(bMap));------background-color:" + ThemeColor + ";
            string theme = ThemeColor;
            int idfg0554 = Convert.ToInt32(Request.QueryString["VC"].ToString());
            int cn1 = 0;
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
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
            SuMViewsPlaceHolder.InnerHtml = Request.QueryString["VC"];
            ScriptInjectorB000.InnerHtml = "<script> androidAPIs.ShowSuMToastsOverview('" + MangaNameFMySql + " :" + cn1.ToString() + " Chapters!'); androidAPIs.SuMExploreInfoMangaDisc('" + GetDisc().Replace("'", "") + "'); </script>";
            if (IsPostBack == false)
            {
                string ThemeSBM = Request.QueryString["TC"].ToString().Replace("0.74", "0.86");
            }
            string pathstartnochx = "/storeitems/";
            string extraexplore = "MangaExplorer.aspx";
            string identifylast = "?Manga=" + Request.QueryString["Manga"].ToString();
            string identifynexthelper = "&Chapter=";
            string epath = System.IO.Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            if (Request.QueryString["Manga"] == null) { backhome(); }
            string M0path = epath + "\\storeitems\\" + Request.QueryString["Manga"] + "\\";
            if (System.IO.Directory.Exists(M0path) == false) { backhome(); }
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
            btnanimationclass = b12.ToString() + "fadeIn animated btn" + b12.ToString();
            string linktoupdate = pathstartnochx + extraexplore + identifylast + "&TC=" + themecolor + "&VC=" + Request.QueryString["VC"].ToString();
            string linktoupdatech = identifynexthelper + "ch";
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
                int MID = Convert.ToInt32(Request.QueryString["VC"].ToString());
                MangaUserStateV(MID, linktoupdate, linktoupdatech);
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
                        RLink = pathstartnochx + extraexplore + identifylast + identifynexthelper + "ch" + ChapterFixedForm + "&TC=" + themecolor + "&VC=" + Request.QueryString["VC"].ToString();//+ OptionToAddCurrFunc;
                        TheMangaPhotosF.InnerHtml += "<a href=" + "#" + " onclick=" + sc.ToString() + "androidAPIs.SuMExploreLoadReader('" + RLink + "',"+ ChapterCValue + ");" + sc.ToString() + " style=" + abtntheme + " class=" + btnanimationclass + " ><img onerror=" + b12.ToString() + "this.onerror = null; this.src = '/assets/BrokeIMG.png'" + b12.ToString() + " " + LazyLoading + " src=" + cpcover + " style=" + b12.ToString() + "margin:6px;margin-left:12px !important;width:72px;height:72px;float:left;opacity:0.92;border-radius:12px;" + b12.ToString() + "> <p style=" + b12.ToString() + "color:#ffffff;float:left;margin-left:6px;margin-top:14px !important;font-size:112%;" + b12.ToString() + ">Chapter " + chxC + "</p></a>";
                    }
                    else
                    {
                        TheMangaPhotosF.InnerHtml += "<a onclick=" + sc.ToString() + "SuMTXTShowThis('Unavailable','" + themecolor + "','Chapter " + chxC + "','ContantExplorer');" + sc.ToString() + " style=" + abtntheme + " class=" + btnanimationclass + " ><img onerror=" + b12.ToString() + "this.onerror = null; this.src = '/assets/BrokeIMG.png'" + b12.ToString() + " " + LazyLoading + " src=" + cpcover + " style=" + b12.ToString() + "margin:6px;margin-left:12px;width:72px;height:72px;float:left;opacity:0.92;border-radius:12px;opacity:0.54;" + b12.ToString() + "> <p style=" + b12.ToString() + "opacity:0.64;color:#ffffff;float:left;margin-left:6px;margin-top:14px !important;font-size:112%;" + b12.ToString() + ">Chapter " + chxC + "</p> <p style=" + b12.ToString() + "opacity:0.64;color:#ffffff;float:right;margin-right:calc(100% - 188px);margin-top:-13px;height:fit-content;width:fit-content;" + b12.ToString() + ">unavailable!</p></a>";
                    }
                    if (c < cn1) { TheMangaPhotosF.InnerHtml += "<hr style=" + sc.ToString() + "margin:0 auto !important;height:2px;border-radius:1px;border-width:0;color:#ffffff;background-color:#FFFFFF;width:80%;opacity:0.08;margin:0px;margin-block:0px;" + sc.ToString() + ">"; }
                }
            }
            else
            {
                string TC = Request.QueryString["TC"].ToString();
                TC = TC.Substring(0, TC.Length - 6);
                TC += ")";
                MRSW.InnerHtml = "<b>Start Reading</b><br /><p style=" + "margin-top:-4px;font-size:60%;color:" + TC + ">You need to Login!</p>";
                MRSW.Attributes["style"] = "overflow:hidden;color:" + TC + ";";
                MRSC.Attributes["style"] = "overflow:hidden;background-color:rgb(255, 255, 255, 0.84);border-radius:12px;width:160px;height:38px;margin:0 auto;text-align:center;justify-content:center;margin-top:3px !important;margin-bottom:13px !important;";
                MRSW.Attributes["onclick"] = "document.getElementById('MainContent_SuMLoginUI').style.display = 'block';";
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
                        RLink = pathstartnochx + extraexplore + identifylast + identifynexthelper + "ch" + ChapterFixedForm + "&TC=" + themecolor + "&VC=" + Request.QueryString["VC"].ToString();//+ OptionToAddCurrFunc;
                        TheMangaPhotosF.InnerHtml += "<a href=" + "#" + " onclick=" + sc.ToString() + "document.getElementById('MainContent_SuMLoginUI').style.display = 'block';" + sc.ToString() + " style=" + abtntheme + " class=" + btnanimationclass + " ><img onerror=" + b12.ToString() + "this.onerror = null; this.src = '/assets/BrokeIMG.png'" + b12.ToString() + " " + LazyLoading + " src=" + cpcover + " style=" + b12.ToString() + "margin:6px;margin-left:12px !important;width:72px;height:72px;float:left;opacity:0.92;border-radius:12px;" + b12.ToString() + "> <p style=" + b12.ToString() + "color:#ffffff;float:left;margin-left:6px;margin-top:14px !important;font-size:112%;" + b12.ToString() + ">Chapter " + chxC + "</p></a>";
                    }
                    else
                    {
                        TheMangaPhotosF.InnerHtml += "<a onclick=" + sc.ToString() + "SuMTXTShowThis('Unavailable','" + themecolor + "','Chapter " + chxC + "','ContantExplorer');" + sc.ToString() + " style=" + abtntheme + " class=" + btnanimationclass + " ><img onerror=" + b12.ToString() + "this.onerror = null; this.src = '/assets/BrokeIMG.png'" + b12.ToString() + " " + LazyLoading + " src=" + cpcover + " style=" + b12.ToString() + "margin:6px;margin-left:12px;width:72px;height:72px;float:left;opacity:0.92;border-radius:12px;opacity:0.54;" + b12.ToString() + "> <p style=" + b12.ToString() + "opacity:0.64;color:#ffffff;float:left;margin-left:6px;margin-top:14px !important;font-size:112%" + b12.ToString() + ">Chapter " + chxC + "</p> <p style=" + b12.ToString() + "opacity:0.64;color:#ffffff;float:right;margin-right:calc(100% - 188px);margin-top:-13px;height:fit-content;width:fit-content;" + b12.ToString() + ">unavailable!</p></a>";
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
                FavListManager(UID);
                WannaListManager(UID);
                ReasentMarker(UID);
            }
            else
            {
                AddToFavNWanna.Attributes.Add("onclick", "document.getElementById('MainContent_SuMLoginUI').style.display = 'block';");
            }
        }

        protected string ShowName()
        {
            string V = string.Empty;
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string query = "SELECT MangaName FROM SuMManga WHERE MangaID = @MangaID";
                MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
                string x = Request.QueryString["VC"];
                int y = Convert.ToInt32(x);
                MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                MySqlCmd.Parameters["@MangaID"].Value = y;
                using (MySqlDataReader dr = MySqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        V = dr[0].ToString();
                    }
                }
                MySqlCon.Close();
            }
            return V;
        }
        protected string GetDisc()
        {
            string V = string.Empty;
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string query = "SELECT MangaInfo FROM SuMManga WHERE MangaID = @MangaID";
                MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
                string x = Request.QueryString["VC"];
                int y = Convert.ToInt32(x);
                MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                MySqlCmd.Parameters["@MangaID"].Value = y;
                using (MySqlDataReader dr = MySqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        V = dr[0].ToString();
                    }
                }
                MySqlCon.Close();
            }
            return V;
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
        protected void WannaListManager(int UID)
        {
            int MID = Convert.ToInt32(Request.QueryString["VC"].ToString());
            bool ItsAWanna = false;
            object RawRes;
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string qwi = "SELECT Wanna FROM SuMUsersAccounts WHERE UserID = @UID";
                MySqlCommand MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                MySqlCmd00.Parameters["@UID"].Value = UID;
                RawRes = MySqlCmd00.ExecuteScalar();
                MySqlCon.Close();
            }
            if (RawRes != null)
            {
                if (RawRes.ToString().Contains("#" + MID + "&") == true)
                {
                    ItsAWanna = true;
                }
            }
            if (ItsAWanna == true)
            {
                Wanna.Attributes["src"] = "/svg/check.svg";
                Wanna.Attributes.Add("onclick", "RemoveFromWannaJava();");
            }
            else
            {
                Wanna.Attributes["src"] = "/svg/add.svg";
                Wanna.Attributes.Add("onclick", "AddToWannaJava();");
            }
        }
        protected void FavListManager(int UID)
        {
            int MID = Convert.ToInt32(Request.QueryString["VC"].ToString());
            bool ItsAFav = false;
            object RawRes;
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string qwi = "SELECT Fav FROM SuMUsersAccounts WHERE UserID = @UID";
                MySqlCommand MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                MySqlCmd00.Parameters["@UID"].Value = UID;
                RawRes = MySqlCmd00.ExecuteScalar();
                MySqlCon.Close();
            }
            if (RawRes != null)
            {
                if (RawRes.ToString().Contains("#" + MID + "&") == true)
                {
                    ItsAFav = true;
                }
            }
            if (ItsAFav == true)
            {
                Fav.Attributes["src"] = "/svg/favorite.svg";
                Fav.Attributes.Add("onclick", "RemoveFromFavJava();");
            }
            else
            {
                Fav.Attributes["src"] = "/svg/favoriteNOTFILLED.svg";
                Fav.Attributes.Add("onclick", "AddToFavJava();");
            }
        }
        protected void AddToWannaList(object sender, EventArgs e)
        {
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            if (GetUserInfoCookie != null)
            {
                int UID = Convert.ToInt32(GetUserInfoCookie["ID"].ToString());
                object RawRes;
                string NewLIST = string.Empty;
                bool NeedUpdate = false;
                string Target = "#" + Request.QueryString["VC"].ToString() + "&";
                string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
                {
                    MySqlCon.Open();
                    string qwi = "SELECT Wanna FROM SuMUsersAccounts WHERE UserID = @UID";
                    MySqlCommand MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                    MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                    MySqlCmd00.Parameters["@UID"].Value = UID;
                    RawRes = MySqlCmd00.ExecuteScalar();
                    if (RawRes != null)
                    {
                        if (RawRes.ToString().Contains(Target) == false)
                        {
                            NewLIST = RawRes.ToString() + Target;
                            NeedUpdate = true;
                        }
                    }
                    if (NeedUpdate == true)
                    {
                        qwi = "UPDATE SuMUsersAccounts SET Wanna = @NEWWanna WHERE UserID = @UID";
                        MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                        MySqlCmd00.Parameters.AddWithValue("@NEWWanna", NewLIST);
                        MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                        MySqlCmd00.Parameters["@UID"].Value = UID;
                        MySqlCmd00.ExecuteNonQuery();
                    }
                    MySqlCon.Close();
                }
            }
        }
        protected void RemoveFromWannaList(object sender, EventArgs e)
        {
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            if (GetUserInfoCookie != null)
            {
                int UID = Convert.ToInt32(GetUserInfoCookie["ID"].ToString());
                object RawRes;
                string NewLIST = string.Empty;
                bool NeedUpdate = false;
                string Target = "#" + Request.QueryString["VC"].ToString() + "&";
                string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
                {
                    MySqlCon.Open();
                    string qwi = "SELECT Wanna FROM SuMUsersAccounts WHERE UserID = @UID";
                    MySqlCommand MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                    MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                    MySqlCmd00.Parameters["@UID"].Value = UID;
                    RawRes = MySqlCmd00.ExecuteScalar();
                    if (RawRes != null)
                    {
                        if (RawRes.ToString().Contains(Target) == true)
                        {
                            NewLIST = RawRes.ToString().Replace(Target, "");
                            NeedUpdate = true;
                        }
                    }
                    if (NeedUpdate == true)
                    {
                        qwi = "UPDATE SuMUsersAccounts SET Wanna = @NEWWanna WHERE UserID = @UID";
                        MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                        MySqlCmd00.Parameters.AddWithValue("@NEWWanna", NewLIST);
                        MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                        MySqlCmd00.Parameters["@UID"].Value = UID;
                        MySqlCmd00.ExecuteNonQuery();
                    }
                    MySqlCon.Close();
                }
            }
        }
        protected void AddToFavList(object sender, EventArgs e)
        {
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            if (GetUserInfoCookie != null)
            {
                int UID = Convert.ToInt32(GetUserInfoCookie["ID"].ToString());
                object RawRes;
                string NewLIST = string.Empty;
                bool NeedUpdate = false;
                string Target = "#" + Request.QueryString["VC"].ToString() + "&";
                string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
                {
                    MySqlCon.Open();
                    string qwi = "SELECT Fav FROM SuMUsersAccounts WHERE UserID = @UID";
                    MySqlCommand MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                    MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                    MySqlCmd00.Parameters["@UID"].Value = UID;
                    RawRes = MySqlCmd00.ExecuteScalar();
                    if (RawRes != null)
                    {
                        if (RawRes.ToString().Contains(Target) == false)
                        {
                            NewLIST = RawRes.ToString() + Target;
                            NeedUpdate = true;
                        }
                    }
                    if (NeedUpdate == true)
                    {
                        qwi = "UPDATE SuMUsersAccounts SET Fav = @NEWFav WHERE UserID = @UID";
                        MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                        MySqlCmd00.Parameters.AddWithValue("@NEWFav", NewLIST);
                        MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                        MySqlCmd00.Parameters["@UID"].Value = UID;
                        MySqlCmd00.ExecuteNonQuery();
                    }
                    MySqlCon.Close();
                }
            }
        }
        protected void RemoveFromFavList(object sender, EventArgs e)
        {
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            if (GetUserInfoCookie != null)
            {
                int UID = Convert.ToInt32(GetUserInfoCookie["ID"].ToString());
                object RawRes;
                string NewLIST = string.Empty;
                bool NeedUpdate = false;
                string Target = "#" + Request.QueryString["VC"].ToString() + "&";
                string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
                {
                    MySqlCon.Open();
                    string qwi = "SELECT Fav FROM SuMUsersAccounts WHERE UserID = @UID";
                    MySqlCommand MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                    MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                    MySqlCmd00.Parameters["@UID"].Value = UID;
                    RawRes = MySqlCmd00.ExecuteScalar();
                    if (RawRes != null)
                    {
                        if (RawRes.ToString().Contains(Target) == true)
                        {
                            NewLIST = RawRes.ToString().Replace(Target, "");
                            NeedUpdate = true;
                        }
                    }
                    if (NeedUpdate == true)
                    {
                        qwi = "UPDATE SuMUsersAccounts SET Fav = @NEWFav WHERE UserID = @UID";
                        MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                        MySqlCmd00.Parameters.AddWithValue("@NEWFav", NewLIST);
                        MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                        MySqlCmd00.Parameters["@UID"].Value = UID;
                        MySqlCmd00.ExecuteNonQuery();
                    }
                    MySqlCon.Close();
                }
            }
        }
        protected int[] ST0(string x)
        {
            Queue<int> R1 = new Queue<int>();
            bool fh = false;
            string A1 = "";
            char[] aa = x.ToCharArray();
            for (int i = 0; i < aa.Length; i++)
            {
                if (aa[i] == '&')
                {
                    fh = false;
                    R1.Enqueue(Convert.ToInt32(A1));
                    A1 = "";
                }
                if (fh == true)
                {
                    A1 += aa[i].ToString();
                }
                if (aa[i] == '#') { fh = true; }
            }
            int RdL = R1.Count;
            int[] RS = new int[RdL];
            int RFDH = 0;
            while (R1.Count > 0)
            {
                RS[RFDH] = R1.Dequeue();
                RFDH++;
            }
            return RS;
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
            //NormallCoderFromDownHere
            string ThemeColor = Request.QueryString["TC"].ToString();
            string abtntheme = "padding-block:0px;padding:0px;border-radius:0px;color:#ffffff;width:100%;height:fit-content;float:left;";
            string pathstartnochx = "/storeitems/";
            string extraexplore = "MangaExplorer.aspx";
            string identifylast = "?Manga=" + Request.QueryString["Manga"].ToString();
            string identifynexthelper = "&Chapter=";
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
                        RLink = pathstartnochx + extraexplore + identifylast + identifynexthelper + "ch" + ChapterFixedForm + "&TC=" + themecolor + "&VC=" + Request.QueryString["VC"].ToString();//+ OptionToAddCurrFunc;
                        TheMangaPhotosF.InnerHtml += "<a href=" + "#" + " onclick=" + sc.ToString() + "androidAPIs.SuMExploreLoadReader('" + RLink + "',"+ ChapterCValue + ");" + sc.ToString() + " style=" + abtntheme + " class=" + btnanimationclass + " ><img onerror=" + b12.ToString() + "this.onerror = null; this.src = '/assets/BrokeIMG.png'" + b12.ToString() + " " + LazyLoading + " src=" + cpcover + " style=" + b12.ToString() + "margin:6px;margin-left:12px !important;width:72px;height:72px;float:left;opacity:0.92;border-radius:12px;" + b12.ToString() + "> <p style=" + b12.ToString() + "color:#ffffff;float:left;margin-left:6px;margin-top:14px !important;font-size:112%;" + b12.ToString() + ">Chapter " + chxC + "</p></a>";
                    }
                    else
                    {
                        TheMangaPhotosF.InnerHtml += "<a onclick=" + sc.ToString() + "SuMTXTShowThis('Unavailable','" + themecolor + "','Chapter " + chxC + "','ContantExplorer');" + sc.ToString() + " style=" + abtntheme + " class=" + btnanimationclass + " ><img onerror=" + b12.ToString() + "this.onerror = null; this.src = '/assets/BrokeIMG.png'" + b12.ToString() + " " + LazyLoading + " src=" + cpcover + " style=" + b12.ToString() + "margin:6px;margin-left:12px;width:72px;height:72px;float:left;opacity:0.92;border-radius:12px;opacity:0.54;" + b12.ToString() + "> <p style=" + b12.ToString() + "opacity:0.64;color:#ffffff;float:left;margin-left:6px;margin-top:14px !important;font-size:112%;font-size:112%;" + b12.ToString() + ">Chapter " + chxC + "</p> <p style=" + b12.ToString() + "opacity:0.64;color:#ffffff;float:right;margin-right:calc(100% - 188px);margin-top:-13px;height:fit-content;width:fit-content;" + b12.ToString() + ">unavailable!</p></a>";
                    }
                    if (c < CEN) { TheMangaPhotosF.InnerHtml += "<hr style=" + sc.ToString() + "margin:0 auto !important;height:2px;border-radius:1px;border-width:0;color:#ffffff;background-color:#FFFFFF;width:80%;opacity:0.08;margin:0px;margin-block:0px;" + sc.ToString() + ">"; }
                }
            }
            else
            {
                string TC = Request.QueryString["TC"].ToString();
                TC = TC.Substring(0, TC.Length - 6);
                TC += ")";
                MRSW.InnerHtml = "<b>Start Reading</b><br /><p style=" + "margin-top:-4px;font-size:60%;color:" + TC + ">You need to Login!</p>";
                MRSW.Attributes["style"] = "overflow:hidden;color:" + TC + ";";
                MRSC.Attributes["style"] = "overflow:hidden;background-color:rgb(255, 255, 255, 0.84);border-radius:13px;width:160px;height:46px;margin:0 auto;text-align:center;justify-content:center;margin-top:4px !important;margin-bottom:12px !important;padding:4px;";
                MRSW.Attributes["onclick"] = "document.getElementById('MainContent_SuMLoginUI').style.display = 'block';";
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
                        RLink = pathstartnochx + extraexplore + identifylast + identifynexthelper + "ch" + ChapterFixedForm + "&TC=" + themecolor + "&VC=" + Request.QueryString["VC"].ToString();//+ OptionToAddCurrFunc;
                        TheMangaPhotosF.InnerHtml += "<a href=" + "#" + " onclick=" + sc.ToString() + "document.getElementById('MainContent_SuMLoginUI').style.display = 'block';" + sc.ToString() + " style=" + abtntheme + " class=" + btnanimationclass + " ><img onerror=" + b12.ToString() + "this.onerror = null; this.src = '/assets/BrokeIMG.png'" + b12.ToString() + " " + LazyLoading + " src=" + cpcover + " style=" + b12.ToString() + "margin:6px;margin-left:12px !important;width:72px;height:72px;float:left;opacity:0.92;border-radius:12px;" + b12.ToString() + "> <p style=" + b12.ToString() + "color:#ffffff;float:left;margin-left:6px;margin-top:14px !important;font-size:112%;" + b12.ToString() + ">Chapter " + chxC + "</p></a>";
                    }
                    else
                    {
                        TheMangaPhotosF.InnerHtml += "<a onclick=" + sc.ToString() + "SuMTXTShowThis('Unavailable','" + themecolor + "','Chapter " + chxC + "','ContantExplorer');" + sc.ToString() + " style=" + abtntheme + " class=" + btnanimationclass + " ><img onerror=" + b12.ToString() + "this.onerror = null; this.src = '/assets/BrokeIMG.png'" + b12.ToString() + " " + LazyLoading + " src=" + cpcover + " style=" + b12.ToString() + "margin:6px;margin-left:12px;width:72px;height:72px;float:left;opacity:0.92;border-radius:12px;opacity:0.54;" + b12.ToString() + "> <p style=" + b12.ToString() + "opacity:0.64;color:#ffffff;float:left;margin-left:6px;margin-top:14px !important;font-size:112%;" + b12.ToString() + ">Chapter " + chxC + "</p> <p style=" + b12.ToString() + "opacity:0.64;color:#ffffff;float:right;margin-right:calc(100% - 188px);margin-top:-13px;height:fit-content;width:fit-content;" + b12.ToString() + ">unavailable!</p></a>";
                    }
                    if (c < CEN) { TheMangaPhotosF.InnerHtml += "<hr style=" + sc.ToString() + "margin:0 auto !important;height:2px;border-radius:1px;border-width:0;color:#ffffff;background-color:#FFFFFF;width:80%;opacity:0.08;margin:0px;margin-block:0px;" + sc.ToString() + ">"; }
                }
            }
            ThreIsMoreACard.Attributes["style"] = "display:none;";
            LoadChapters.Update();
        }
        protected void ShareLink()
        {
            var V = "";
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string query = "SELECT MangaName FROM SuMManga WHERE MangaID = @MangaID";
                MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
                string x = Request.QueryString["VC"];
                int y = Convert.ToInt32(x);
                MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                MySqlCmd.Parameters["@MangaID"].Value = y;
                using (MySqlDataReader dr = MySqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        V = dr[0].ToString();
                    }
                }
                MySqlCon.Close();
            }
            string LINK = "https://sum-manga.azurewebsites.net/storeitems/ContantExplorer.aspx?Manga=" + Request.QueryString["Manga"].ToString() + "&VC=" + Request.QueryString["VC"].ToString() + "&TC=" + Request.QueryString["TC"].ToString();
            //No need- now Using androidAPIs SuMShare.Attributes["onclick"] = "navigator.share({title:'SuM Manga',text:'Check out " + V.ToString() + " on SuM Manga.',url:'" + LINK + "'});";
        }
        protected bool IsItInCurr(int MID, int UID)
        {

            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string qwi = "SELECT Curr FROM SuMUsersAccounts WHERE UserID = @UID";
                MySqlCommand MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                MySqlCmd00.Parameters["@UID"].Value = UID;
                var RawRes = MySqlCmd00.ExecuteScalar();
                if (RawRes != null)
                {
                    string Res = RawRes.ToString();
                    int[] R = ST11(Res);
                    for (int i = 0; i < R.GetLength(1); i++)
                    {
                        if (R[i] == MID)
                        {
                            return true;
                        }
                    }
                    return false;
                }
                else { return false; }
            }
        }
        protected int[] ST11(string x)
        {
            Queue<int> R1 = new Queue<int>();
            bool fh = false;
            bool fc = false;
            string A1 = "";
            char[] aa = x.ToCharArray();
            for (int i = 0; i < aa.Length; i++)
            {
                if (aa[i] == '&')
                {
                    fh = false;
                    fc = false;
                    R1.Enqueue(Convert.ToInt32(A1));
                    A1 = "";
                }
                if (aa[i] == ';') { fc = true; }
                if (fh == true && fc == false)
                {
                    A1 += aa[i].ToString();
                }
                if (aa[i] == '#') { fh = true; }
            }
            int RdL = R1.Count;
            int[] RS = new int[RdL];
            int RFDH = 0;
            while (R1.Count > 0)
            {
                RS[RFDH] = R1.Dequeue();
                RFDH++;
            }
            return RS;
        }
        protected void MangaUserStateV(int MID, string LinkToUpdate, string linktoupdatech)
        {
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            int UID = Convert.ToInt32(Convert.ToString(GetUserInfoCookie["ID"]));
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string qwi = "SELECT Curr FROM SuMUsersAccounts WHERE UserID = @UID";
                MySqlCommand MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                MySqlCmd00.Parameters["@UID"].Value = UID;
                var RawRes = MySqlCmd00.ExecuteScalar();
                if (RawRes != null)
                {
                    string TC = Request.QueryString["TC"].ToString();
                    TC = TC.Substring(0, TC.Length - 6);
                    TC += ")";

                    bool foundit = false;
                    string Res = RawRes.ToString();
                    int[,] R = ST1(Res);
                    for (int i = 0; i < R.GetLength(1); i++)
                    {
                        if (R[0, i] == MID)
                        {
                            foundit = true;
                            int c = R[1, i];
                            string ChapterFixedForm = string.Empty;
                            string chxC = c.ToString();
                            if (c < 10 && c > 0) { ChapterFixedForm = "000" + chxC; }
                            if (c > 9 && c < 100) { ChapterFixedForm = "00" + chxC; }
                            if (c > 99 && c < 1000) { ChapterFixedForm = "0" + chxC; }
                            if (c > 999 && c < 10000) { ChapterFixedForm = chxC; }
                            MRSW.InnerHtml = "<b>Continue Reading</b><br /><p style=" + "margin-top:-4px;font-size:64%;color:" + TC + ">Currently In Chapter " + c + "</p>";
                            MRSW.Attributes["style"] = "overflow:hidden;color:" + TC + ";";
                            MRSC.Attributes["style"] = "overflow:hidden;background-color:rgb(255, 255, 255, 0.84);border-radius:13px;width:160px;height:46px;margin:0 auto;text-align:center;justify-content:center;margin-top:4px !important;margin-bottom:12px !important;padding:4px;";
                            string WorkerHelp = "&UCU=" + MID.ToString();
                            MRSW.Attributes["onclick"] = "androidAPIs.SuMExploreLoadReader('" + LinkToUpdate + linktoupdatech + ChapterFixedForm + WorkerHelp + "'," + ChapterCValue + ");";
                            MySqlCon.Close();
                        }
                    }
                    if (foundit == false)
                    {
                        MRSW.InnerHtml = "<b>Start Reading</b><br /><p style=" + "margin-top:-4px;font-size:60%;color:" + TC + ">Auto adds to currently reading</p>";
                        MRSW.Attributes["style"] = "overflow:hidden;color:" + TC + ";";
                        MRSC.Attributes["style"] = "overflow:hidden;background-color:rgb(255, 255, 255, 0.84);border-radius:13px;width:160px;height:46px;margin:0 auto;text-align:center;justify-content:center;margin-top:4px !important;margin-bottom:12px !important;padding:4px;";
                        MRSW.Attributes["onclick"] = "androidAPIs.SuMExploreLoadReader('" + LinkToUpdate + linktoupdatech + "0001" + "&ADTCU=" + MID + "'," + ChapterCValue + ");";
                        MySqlCon.Close();
                    }
                }
                else
                {
                    string TC = Request.QueryString["TC"].ToString();
                    TC = TC.Substring(0, TC.Length - 6);
                    TC += ")";
                    MRSW.InnerHtml = "<b>Start Reading</b><br /><p style=" + "margin-top:-4px;font-size:60%;color:" + TC + ">Auto adds to currently reading</p>";
                    MRSW.Attributes["style"] = "overflow:hidden;color:" + TC + ";";
                    MRSC.Attributes["style"] = "overflow:hidden;background-color:rgb(255, 255, 255, 0.84);border-radius:12px;width:160px;height:38px;margin:0 auto;text-align:center;justify-content:center;margin-top:3px !important;margin-bottom:13px !important;";
                    MRSW.Attributes["onclick"] = "androidAPIs.SuMExploreLoadReader('" + LinkToUpdate + linktoupdatech + "0001" + "&ADTCU=" + MID + "'," + ChapterCValue + ");";
                    MySqlCon.Close();
                }
            }

        }
        protected int[,] ST1(string x)
        {
            Queue<int> R1 = new Queue<int>();
            Queue<int> R2 = new Queue<int>();
            bool fh = false;
            bool fc = false;
            string A1 = "";
            string A2 = "";
            char[] aa = x.ToCharArray();
            for (int i = 0; i < aa.Length; i++)
            {
                if (aa[i] == '&')
                {
                    fh = false;
                    fc = false;
                    R1.Enqueue(Convert.ToInt32(A1));
                    R2.Enqueue(Convert.ToInt32(A2));
                    A1 = "";
                    A2 = "";
                }
                if (fh == true && fc == true)
                {
                    A2 += aa[i].ToString();
                }
                if (aa[i] == ';') { fc = true; }
                if (fh == true && fc == false)
                {
                    A1 += aa[i].ToString();
                }
                if (aa[i] == '#') { fh = true; }
            }
            int RdL = R1.Count;
            int[,] RS = new int[2, RdL];
            int RFDH = 0;
            while (R1.Count > 0)
            {
                RS[0, RFDH] = R1.Dequeue();
                RFDH++;
            }
            RFDH = 0;
            while (R2.Count > 0)
            {
                RS[1, RFDH] = R2.Dequeue();
                RFDH++;
            }
            return RS;
        }
        private void backhome()
        {
            Response.Redirect("~/404.aspx");
        }
        protected string ShowDis()
        {
            string V = string.Empty;
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string query = "SELECT MangaInfo FROM SuMManga WHERE MangaID = @MangaID";
                MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
                string x = Request.QueryString["VC"];
                int y = Convert.ToInt32(x);
                MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                MySqlCmd.Parameters["@MangaID"].Value = y;
                using (MySqlDataReader dr = MySqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        V = dr[0].ToString();
                    }
                }
                MySqlCon.Close();
            }
            return V;
        }
    }
}