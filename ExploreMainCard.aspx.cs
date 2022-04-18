﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace SuM_Manga_V3
{
    public partial class ExploreMainCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //LastRefreshPross();
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            if (GetUserInfoCookie != null)
            {
                int UID = Convert.ToInt32(GetUserInfoCookie["ID"].ToString());
                SussionProssINB(UID, GetUserInfoCookie["SID"].ToString());
                ScriptInjectorA000.InnerHtml = "<script> androidAPIs.ShowSuMToastsOverview('welcome " + GetUserInfoCookie["UserName"].ToString() + "!'); </script>";
            }
            else 
            {
                ScriptInjectorA000.InnerHtml = "<script> androidAPIs.ShowSuMToastsOverview('welcome to SuMManga!'); </script>";
            }
            ShowCardsCNew();
        }
        protected void SussionPross(object sender, EventArgs e)
        {
            HttpCookie userInfo = Request.Cookies["SuMCurrentUser"];
            if (userInfo != null) 
            {
                string SID = userInfo["SID"].ToString();
                object CMDRs;
                using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    sqlCon.Open();
                    string qwi = "SELECT SIDs FROM SuMUsersAccounts WHERE UserID = @UID";
                    SqlCommand sqlCmd = new SqlCommand(qwi, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@UID", SqlDbType.Int);
                    sqlCmd.Parameters["@UID"].Value = Convert.ToInt32(userInfo["ID"].ToString());
                    CMDRs = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                }
                if (CMDRs != null) 
                {
                    if (CMDRs.ToString().Contains(SID) == false)
                    {
                        LogOut();
                    }
                }
                else 
                {
                    LogOut();
                }
            }
        }
        protected string[] SIDsToStringArray(string SIDs) 
        {
            Queue<string> R1 = new Queue<string>();
            bool fh = false;
            string A1 = "";
            char[] aa = SIDs.ToCharArray();
            for (int i = 0; i < aa.Length; i++)
            {
                if (aa[i] == ';')
                {
                    fh = false;
                    R1.Enqueue(A1);
                    A1 = "";
                }
                if (fh == true)
                {
                    A1 += aa[i].ToString();
                }
                if (aa[i] == '#') { fh = true; }
            }
            int RdL = R1.Count;
            string[] RS = new string[RdL];
            int RFDH = 0;
            while (R1.Count > 0)
            {
                RS[RFDH] = R1.Dequeue();
                RFDH++;
            }
            return RS;
        }
        protected void LogOut()
        {
            HttpCookie GetUserInfoCookie = new HttpCookie("SuMCurrentUser");
            GetUserInfoCookie.Expires = DateTime.Now.AddDays(-100);
            Response.Cookies.Add(GetUserInfoCookie);
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
        protected void ShowCardsCNew()
        {
            string ResultS = " ";
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string query = "SELECT TOP 9 MangaID from SuMManga order by MangaID desc";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                Queue<int> RawIDs = new Queue<int>();
                using (var reader = sqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        RawIDs.Enqueue(Convert.ToInt32(reader[0].ToString()));
                    }
                }
                int[] IDs = new int[RawIDs.Count];
                int IDHELPER = 0;
                while (RawIDs.Count > 0)
                {
                    IDs[IDHELPER] = RawIDs.Dequeue();
                    IDHELPER++;
                }
                string Name = string.Empty;
                string Cover = string.Empty;
                string Disc = string.Empty;
                string CExplorerLink = string.Empty;
                for (int i = 0; i < IDs.Length; i++)
                {
                    query = "SELECT MangaName FROM SuMManga WHERE MangaID = @MangaID";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    sqlCmd.Parameters["@MangaID"].Value = IDs[i];
                    var un = sqlCmd.ExecuteScalar();
                    Name = un.ToString();
                    query = "SELECT MangaInfo FROM SuMManga WHERE MangaID = @MangaID";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    sqlCmd.Parameters["@MangaID"].Value = IDs[i];
                    un = sqlCmd.ExecuteScalar();
                    Disc = un.ToString();
                    query = "SELECT CExplorerLink FROM SuMManga WHERE MangaID = @MangaID";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    sqlCmd.Parameters["@MangaID"].Value = IDs[i];
                    un = sqlCmd.ExecuteScalar();
                    CExplorerLink = un.ToString();
                    query = "SELECT MangaCoverLink FROM SuMManga WHERE MangaID = @MangaID";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    sqlCmd.Parameters["@MangaID"].Value = IDs[i];
                    un = sqlCmd.ExecuteScalar();
                    Cover = un.ToString();
                    query = "SELECT SuMThemeColor FROM SuMManga WHERE MangaID = @MangaID";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    sqlCmd.Parameters["@MangaID"].Value = IDs[i];
                    string themecolor = sqlCmd.ExecuteScalar().ToString();
                    CExplorerLink += "&VC=" + IDs[i].ToString() + "&TC=" + themecolor;
                    query = "SELECT MangaCreator FROM SuMManga WHERE MangaID = @MangaID";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    sqlCmd.Parameters["@MangaID"].Value = IDs[i];
                    string MangaCReator = sqlCmd.ExecuteScalar().ToString();
                    query = "SELECT MangaViews FROM SuMManga WHERE MangaID = @MangaID";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    sqlCmd.Parameters["@MangaID"].Value = IDs[i];
                    int Views = Convert.ToInt32(sqlCmd.ExecuteScalar().ToString());
                    query = "SELECT MangaAgeRating FROM SuMManga WHERE MangaID = @MangaID";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    sqlCmd.Parameters["@MangaID"].Value = IDs[i];
                    string MangaAgeRating = sqlCmd.ExecuteScalar().ToString();
                    ResultS += BuildCard(Cover, Name, Disc, CExplorerLink, themecolor, MangaCReator, MangaAgeRating, Views, i, IDs[i]);
                    if (i == 0) 
                    {
                        cardscontain.Attributes["style"] = "scroll-margin-top:0px !important;scroll-snap-align:start;border-radius:22px !important;width:100% !important;height:100vh !important;overflow:hidden !important;margin-top:0px;margin-left:0px;display:block;background-color:" + themecolor + " !important;transition: background-color 0.32s ease !important;scroll-snap-align:start !important;scroll-snap-stop: always !important;";
                    }
                }
                cardstoshow.InnerHtml = ResultS;
                cardsdots.InnerHtml = " ";
                for (int i = 0; i < IDs.Length; i++) { cardsdots.InnerHtml += "<span class=" + "dot" + "></span> "; }

                sqlCon.Close();
            }
        }
        protected string BuildCard(string CardBG, string cardtitle, string discr0, string Link, string theme, string CraetorName, string AgeRating, int V, int Num, int MangaID)
        {
            Num++;
            char b12 = '"';
            string divclass = b12.ToString() + "mySlides pulse animated" + b12.ToString();
            string ViewsNumPart = string.Empty;
            string ViewsLPart = string.Empty;
            if (V < 1000)
            {
                ViewsNumPart = V.ToString();
                ViewsLPart = "";
            }
            if (V > 999 && V < 1000000)
            {
                double B = V / 1000.0;
                ViewsNumPart = String.Format("{0:0.00}", B);
                ViewsLPart = "K";
            }
            if (V > 999999 && V < 1000000000)
            {
                double B = V / 1000000.0;
                ViewsNumPart = String.Format("{0:0.00}", B);
                ViewsLPart = "M";
            }
            if (V > 999999999)
            {
                double B = V / 1000000000.0;
                ViewsNumPart = String.Format("{0:0.00}", B);
                ViewsLPart = "B";
            }
            string divstyle = b12.ToString() + "overflow:hidden !important;background-image:linear-gradient(" + theme + ",rgba(0,0,0,0.3)),url(" + CardBG + ") !important;background-size:cover;background-position:center !important;width:100% !important;height:76vw;max-width:630px !important;max-height:300px !important;padding:12px;margin:0 auto !important;border-radius:12px !important;" + b12.ToString();
            string DivContant = "<div style=" + b12.ToString() + "width:calc(98% - 24px);height:fit-content;position:relative;margin:0 auto;margin-top:2px;" + b12.ToString() + ">";
            DivContant += "<h1 style=" + b12.ToString() + "float:left;margin-top:12px;margin-left:12px;color:#ffffff;font-size:178%;margin-right:14px !important;width:calc(100% - 24px) !important;height:34.17px !important;white-space:nowrap !important;overflow:hidden !important;text-overflow:ellipsis !important;" + b12.ToString() + ">" + cardtitle + "</h1>";
            DivContant += "<p style=" + b12.ToString() + "color:rgb(255, 255, 255, 0.82); float:right; margin-top:-18px; margin-right:10px;" + b12.ToString() + ">By <b style=" + "font-size:80%;" + ">" + CraetorName + "</b></p></div>";
            DivContant += "<hr style=" + b12.ToString() + "margin:0 auto !important;height:2px!important;border-width:0;color:#ffffff;background-color:#ffffff;width:80%;opacity:0.32;margin:0px;margin-block:0px;border-radius:1.3px !important;margin-bottom:4px;margin-bottom:4px !important;margin-top:-8px !important;" + b12.ToString() + " />";
            DivContant += "<p style=" + b12.ToString() + "text-align:center;height:135px;max-height:135px !important;width:calc(98% - 24px);max-width:98vw;font-size:96%;color:#ffffff;margin:4px !important;margin-bottom:6px !important;margin-top:8px !important;text-overflow:ellipsis !important;display:inline-block;overflow:hidden;" + b12.ToString() + ">" + discr0 + "</p>";
            DivContant += "<div style=" + b12.ToString() + "margin:0 auto;margin-bottom:0px;height:fit-content;width:100%;position:relative;margin-top:0px !important;" + b12.ToString() + "><a style=" + b12.ToString() + "display:block;float:right !important;margin-bottom:0px;margin-right:8px;bottom:0;position:relative;" + b12.ToString() + ">";
            DivContant += "<p style=" + b12.ToString() + "display:inline;color:rgba(255,255,255,0.74);" + b12.ToString() + "> " + AgeRating + " </p><img style=" + b12.ToString() + "width:20px;height:20px;display:inline;" + b12.ToString() + " src=" + b12.ToString() + "/svg/views.svg" + b12.ToString() + ">";
            DivContant += "<p style=" + "display:inline;color:#ffffff;" + "> " + ViewsNumPart + " </p><b style=" + "display:inline;color:#ffffff;" + ">" + ViewsLPart + "</b></a></div>";
            string result = "<div onclick=" + b12.ToString() + "SuMApplyInfoToUltraCard('" + MangaID + "', '" + CardBG + "', '" + cardtitle.Replace("'", "") + "', '" + Link + "', 'ContantExplorer', '" + cardtitle.Replace("'", "") + "', '" + theme + "');" + b12.ToString() + " class=" + divclass + " style=" + divstyle + ">" + "<div class=" + b12.ToString() + "animated fadeIn" + b12.ToString() + " >" + DivContant + "</div>" + "</div>";
            result += "<p id=CardNuM" + Num.ToString() + "Theme style=display:none;visibility:hidden; >" + theme + "</p>";
            return result;
        }
        protected void SussionProssINB(int UID, string SID)
        {
            object CMDRs;
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string qwi = "SELECT SIDs FROM SuMUsersAccounts WHERE UserID = @UID";
                SqlCommand sqlCmd = new SqlCommand(qwi, sqlCon);
                sqlCmd.Parameters.AddWithValue("@UID", SqlDbType.Int);
                sqlCmd.Parameters["@UID"].Value = UID;
                CMDRs = sqlCmd.ExecuteScalar();
                sqlCon.Close();
            }
            if (CMDRs != null)
            {
                if (CMDRs.ToString().Contains(SID) == false)
                {
                    ForceLogOut();
                }
            }
            else
            {
                ForceLogOut();
            }
        }
        protected void ForceLogOut()
        {
            HttpCookie GetUserInfoCookie = new HttpCookie("SuMCurrentUser");
            GetUserInfoCookie.Expires = DateTime.Now.AddDays(-100);
            Response.Cookies.Add(GetUserInfoCookie);
            HttpCookie SetInfo = new HttpCookie("SuMPerformanceMode");
            SetInfo.Expires = DateTime.Now.AddDays(-100);
            HttpContext.Current.Response.Cookies.Add(SetInfo);
            HttpCookie SetInfo2 = new HttpCookie("SuMLockMode");
            SetInfo2.Expires = DateTime.Now.AddDays(-100);
            HttpContext.Current.Response.Cookies.Add(SetInfo2);
            HttpCookie userInfo0 = new HttpCookie("SuMUserThemeColor");
            userInfo0.Expires = DateTime.Now.AddDays(-100);
            HttpContext.Current.Response.Cookies.Add(userInfo0);
            ReloadAndUpdate();
        }
        protected void ReloadAndUpdate()
        {
            string CurrURL = Request.Url.ToString();
            if (CurrURL.Contains("?") == true)
            {
                Response.Redirect(Request.Url.ToString() + "&" + RandomQuryForUpdate());
            }
            else
            {
                Response.Redirect(Request.Url.ToString() + "?" + RandomQuryForUpdate());
            }
        }
        protected static string RandomQuryForUpdate()
        {
            int length = 9;
            char[] chArray = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            string str = string.Empty;
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                int index = random.Next(1, chArray.Length);
                if (!str.Contains(chArray.GetValue(index).ToString()))
                {
                    str = str + chArray.GetValue(index);
                }
                else
                {
                    i--;
                }
            }
            Random r = new Random();
            int randNum = r.Next(1000000);
            string sixDigitNumber = randNum.ToString("D6");
            str = sixDigitNumber[0] + sixDigitNumber[1] + sixDigitNumber[2] + str + sixDigitNumber[3] + sixDigitNumber[4] + sixDigitNumber[5];
            return "UPDATE=" + str;
        }
    }
}