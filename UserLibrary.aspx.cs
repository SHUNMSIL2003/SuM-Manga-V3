using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace SuM_Manga_V3
{
    public partial class UserLibrary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SussionPross();
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            if (GetUserInfoCookie == null)
            {
                Response.Redirect("~/AccountETC/LoginETC.aspx");
            }
            else
            {
                int UID = Convert.ToInt32(Convert.ToString(GetUserInfoCookie["ID"]));
                HttpCookie GetPerModeInfoCookie = Request.Cookies["SuMPerformanceMode"];
                if (GetPerModeInfoCookie != null)
                {
                    ShowReqContantContaner.Attributes["class"] = "";
                    LibCatTopPart.Attributes["class"] = "";
                    infocard.Attributes["class"] = "";
                }
                var CT = Request.QueryString["RT"];
                if (CT != null)
                {
                    if (CT == "Curr" || CT == "Fav" || CT == "Wanna")
                    {
                        if (CT == "Curr")
                        {
                            LoadReqContant("Curr", UID);
                            if (IsPostBack == false)
                            {
                                cr.Attributes["style"] = "display:inline-block;animation-duration:0.96s !important;background-color:rgb(104,64,217,0.94);border-radius:16px;margin:3px;padding-top:3px;padding-bottom:3px;padding-left:12px !important;padding-right:12px !important;color:rgba(255,255,255,0.96);";
                                if (GetPerModeInfoCookie == null)
                                {
                                    cr.Attributes["class"] = "animated pulse";
                                }
                                wr.Attributes["style"] = "display:inline-block;background-color:rgb(104,64,217,0);border-radius:16px;margin:3px;padding-top:3px;padding-bottom:3px;padding-left:12px !important;padding-right:12px !important;color:rgba(0,0,0,0.60);";
                                mf.Attributes["style"] = "display:inline-block;background-color:rgb(104,64,217,0);border-radius:16px;margin:3px;padding-top:3px;padding-bottom:3px;padding-left:12px !important;padding-right:12px !important;color:rgba(0,0,0,0.60);";
                                InfoAboutC.InnerHtml = "This library is to ease access to the mangas you are currently reading and track your process, you can <b>add mangas by clicking the " + '"'.ToString() + "Start Reading" + '"'.ToString() + " button</b> in the desired manga page.";
                            }
                        }
                        else
                        {
                            if (CT == "Fav")
                            {
                                LoadReqContant("Fav", UID);
                                if (IsPostBack == false)
                                {
                                    mf.Attributes["style"] = "display:inline-block;animation-duration:0.96s !important;background-color:rgb(104,64,217,0.94);border-radius:16px;margin:3px;padding-top:3px;padding-bottom:3px;padding-left:12px !important;padding-right:12px !important;color:rgba(255,255,255,0.96);";
                                    if (GetPerModeInfoCookie == null)
                                    {
                                        mf.Attributes["class"] = "animated pulse";
                                    }
                                    cr.Attributes["style"] = "display:inline-block;background-color:rgb(104,64,217,0);border-radius:16px;margin:3px;padding-top:3px;padding-bottom:3px;padding-left:12px !important;padding-right:12px !important;color:rgba(0,0,0,0.60);";
                                    wr.Attributes["style"] = "display:inline-block;background-color:rgb(104,64,217,0);border-radius:16px;margin:3px;padding-top:3px;padding-bottom:3px;padding-left:12px !important;padding-right:12px !important;color:rgba(0,0,0,0.60);";
                                    string FavIMG = "<img style=" + '"'.ToString() + "display:inline !important;width:20px;height:20px;margin:0 auto;" + '"'.ToString() + " src=" + '"'.ToString() + "/svg/favoriteTBlack.svg" + '"'.ToString() + " />";
                                    InfoAboutC.InnerHtml = "This library is to ease access to your favorite mangas, you can <b>add mangas by clicking the " + '"'.ToString() + "" + FavIMG + "" + '"'.ToString() + " button</b> in the desired manga page.";
                                }
                            }
                            else
                            {
                                LoadReqContant("Wanna", UID);
                                if (IsPostBack == false)
                                {
                                    wr.Attributes["style"] = "display:inline-block;animation-duration:0.96s !important;background-color:rgb(104,64,217,0.94);border-radius:16px;margin:3px;padding-top:3px;padding-bottom:3px;padding-left:12px !important;padding-right:12px !important;color:rgba(255,255,255,0.96);";
                                    if (GetPerModeInfoCookie == null)
                                    {
                                        wr.Attributes["class"] = "animated pulse";
                                    }
                                    cr.Attributes["style"] = "display:inline-block;background-color:rgb(104,64,217,0);border-radius:16px;margin:3px;padding-top:3px;padding-bottom:3px;padding-left:12px !important;padding-right:12px !important;color:rgba(0,0,0,0.60);";
                                    mf.Attributes["style"] = "display:inline-block;background-color:rgb(104,64,217,0);border-radius:16px;margin:3px;padding-top:3px;padding-bottom:3px;padding-left:12px !important;padding-right:12px !important;color:rgba(0,0,0,0.60);";
                                    string AddIMG = "<img style=" + '"'.ToString() + "display:inline !important;width:20px;height:20px;margin:0 auto;" + '"'.ToString() + " src=" + '"'.ToString() + "/svg/addTBlack.svg" + '"'.ToString() + " />";
                                    InfoAboutC.InnerHtml = "This library is to access mangas that peaked your interest, you can <b>add mangas by clicking the " + '"'.ToString() + "" + AddIMG + "" + '"'.ToString() + " button</b> in the desired manga page.";
                                }
                            }
                        }
                    }
                    else { Response.Redirect("~/404.aspx"); }
                }
                else { Response.Redirect("~/404.aspx"); }
            }
        }
        protected void LastRefreshPross()
        {
            HttpCookie GetRefreshInfoCookie = Request.Cookies["SuMMangaRefreshProssUserLibrary"];
            if (GetRefreshInfoCookie != null)
            {
                int Year = Convert.ToInt32(GetRefreshInfoCookie["LatestUpdatedYear"].ToString());
                int Month = Convert.ToInt32(GetRefreshInfoCookie["LatestUpdatedMonth"].ToString());
                int Day = Convert.ToInt32(GetRefreshInfoCookie["LatestUpdatedDay"].ToString());
                int Hour = Convert.ToInt32(GetRefreshInfoCookie["LatestUpdatedHour"].ToString());
                int CurrYear = Convert.ToInt32(DateTime.UtcNow.ToString("yyyy"));
                int CurrMonth = Convert.ToInt32(DateTime.UtcNow.ToString("MM"));
                int CurrDay = Convert.ToInt32(DateTime.UtcNow.ToString("dd"));
                int CurrHour = Convert.ToInt32(DateTime.UtcNow.ToString("HH"));
                if ((Year - CurrYear) == 0)
                {
                    if ((Month - CurrMonth) == 0)
                    {
                        if ((Day - CurrDay) == 0)
                        {
                            if ((CurrHour - Hour) != 0) { ReloadAndUpdate(); }
                        }
                        else { ReloadAndUpdate(); }
                    }
                    else { ReloadAndUpdate(); }
                }
                else { ReloadAndUpdate(); }
            }
            else
            {
                HttpCookie UpdateInfo = new HttpCookie("SuMMangaRefreshProssUserLibrary");
                UpdateInfo["LatestUpdatedYear"] = DateTime.UtcNow.ToString("yyyy");
                UpdateInfo["LatestUpdatedMonth"] = DateTime.UtcNow.ToString("MM");
                UpdateInfo["LatestUpdatedDay"] = DateTime.UtcNow.ToString("dd");
                UpdateInfo["LatestUpdatedHour"] = DateTime.UtcNow.ToString("HH");
                UpdateInfo.Expires = DateTime.MaxValue;
                HttpContext.Current.Response.Cookies.Add(UpdateInfo);
            }
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
        protected void LoadReqContant(string Type, int UserID)
        {
            ShowReqContant.InnerHtml = "";
            bool fail = false;
            char sc = '"';
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string qwi = "SELECT " + Type + " FROM SuMUsersAccounts WHERE UserID = @UID";
                SqlCommand sqlCmd00 = new SqlCommand(qwi, sqlCon);
                sqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                sqlCmd00.Parameters["@UID"].Value = UserID;
                var RawRes = sqlCmd00.ExecuteScalar();
                if (RawRes != null)
                {
                    string Res = RawRes.ToString();
                    if (string.IsNullOrEmpty(Res) == true) { fail = true; }
                    bool PreformanceMode = false;
                    HttpCookie GetPerModeInfoCookie = Request.Cookies["SuMPerformanceMode"];
                    if (GetPerModeInfoCookie != null)
                    {
                        PreformanceMode = true;
                    }
                    if (Type == "Curr")
                    {
                        int[,] R = ST1(Res);
                        if (R.GetLength(1) > 0)
                        {
                            for (int i = (R.GetLength(1) - 1); i > (-1); i--)
                            {
                                string query = "SELECT MangaName FROM SuMManga WHERE MangaID = @MangaID";
                                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                                sqlCmd.Parameters["@MangaID"].Value = R[0, i];
                                var g = sqlCmd.ExecuteScalar();
                                string MangaName = g.ToString();

                                query = "SELECT SuMThemeColor FROM SuMManga WHERE MangaID = @MangaID";
                                sqlCmd = new SqlCommand(query, sqlCon);
                                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                                sqlCmd.Parameters["@MangaID"].Value = R[0, i];
                                g = sqlCmd.ExecuteScalar();
                                string MangaTheme = g.ToString();

                                query = "SELECT CExplorerLink FROM SuMManga WHERE MangaID = @MangaID";
                                sqlCmd = new SqlCommand(query, sqlCon);
                                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                                sqlCmd.Parameters["@MangaID"].Value = R[0, i];
                                g = sqlCmd.ExecuteScalar();
                                string ExplorerLink = g.ToString();
                                query = "SELECT ChaptersNumber FROM SuMManga WHERE MangaID = @MangaID";
                                sqlCmd = new SqlCommand(query, sqlCon);
                                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                                sqlCmd.Parameters["@MangaID"].Value = R[0, i];
                                var un = sqlCmd.ExecuteScalar();
                                int ChaptersNum = Convert.ToInt32(un);
                                ExplorerLink += "&CN=" + ChaptersNum.ToString() + "&VC=" + R[0, i].ToString() + "&TC=" + MangaTheme;

                                query = "SELECT MangaCoverLink FROM SuMManga WHERE MangaID = @MangaID";
                                sqlCmd = new SqlCommand(query, sqlCon);
                                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                                sqlCmd.Parameters["@MangaID"].Value = R[0, i];
                                g = sqlCmd.ExecuteScalar();
                                string CoverLink = g.ToString();

                                query = "SELECT MangaCreator FROM SuMManga WHERE MangaID = @MangaID";
                                sqlCmd = new SqlCommand(query, sqlCon);
                                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                                sqlCmd.Parameters["@MangaID"].Value = R[0, i];
                                g = sqlCmd.ExecuteScalar();
                                string CreatorName = g.ToString();

                                if (PreformanceMode == false)
                                {
                                    ShowReqContant.InnerHtml += BuildCurrCard(MangaName, MangaTheme, ExplorerLink, R[1, i].ToString(), CoverLink, CreatorName);
                                }
                                else 
                                {
                                    ShowReqContant.InnerHtml += BuildCurrCardPerMode(MangaName, MangaTheme, ExplorerLink, R[1, i].ToString(), CoverLink, CreatorName);
                                }
                                if (i != 0) { ShowReqContant.InnerHtml += "<hr style=" + sc.ToString() + "margin:0 auto !important;height:2px;color:rgba(242,242,242,1);width:calc(100vw - 36px);margin:0 auto important;" + sc.ToString() + ">"; }
                            }
                        }
                        else
                        {
                            fail = true;
                        }
                    }
                    else
                    {
                        int[] R = ST0(Res);
                        if (R.Length > 0)
                        {
                            for (int i = (R.Length - 1); i >= 0; i--)
                            {

                                string query = "SELECT MangaName FROM SuMManga WHERE MangaID = @MangaID";
                                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                                sqlCmd.Parameters["@MangaID"].Value = R[i];
                                var g = sqlCmd.ExecuteScalar();
                                string MangaName = g.ToString();

                                query = "SELECT SuMThemeColor FROM SuMManga WHERE MangaID = @MangaID";
                                sqlCmd = new SqlCommand(query, sqlCon);
                                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                                sqlCmd.Parameters["@MangaID"].Value = R[i];
                                g = sqlCmd.ExecuteScalar();
                                string MangaTheme = g.ToString();

                                query = "SELECT CExplorerLink FROM SuMManga WHERE MangaID = @MangaID";
                                sqlCmd = new SqlCommand(query, sqlCon);
                                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                                sqlCmd.Parameters["@MangaID"].Value = R[i];
                                g = sqlCmd.ExecuteScalar();
                                string ExplorerLink = g.ToString();
                                query = "SELECT ChaptersNumber FROM SuMManga WHERE MangaID = @MangaID";
                                sqlCmd = new SqlCommand(query, sqlCon);
                                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                                sqlCmd.Parameters["@MangaID"].Value = R[i];
                                var un = sqlCmd.ExecuteScalar();
                                int ChaptersNum = Convert.ToInt32(un);
                                ExplorerLink += "&CN=" + ChaptersNum.ToString() + "&VC=" + R[i].ToString() + "&TC=" + MangaTheme;

                                query = "SELECT MangaCoverLink FROM SuMManga WHERE MangaID = @MangaID";
                                sqlCmd = new SqlCommand(query, sqlCon);
                                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                                sqlCmd.Parameters["@MangaID"].Value = R[i];
                                g = sqlCmd.ExecuteScalar();
                                string CoverLink = g.ToString();

                                query = "SELECT MangaCreator FROM SuMManga WHERE MangaID = @MangaID";
                                sqlCmd = new SqlCommand(query, sqlCon);
                                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                                sqlCmd.Parameters["@MangaID"].Value = R[i];
                                g = sqlCmd.ExecuteScalar();
                                string CreatorName = g.ToString();

                                if (PreformanceMode == false)
                                {
                                    ShowReqContant.InnerHtml += BuildRestCard(MangaName, MangaTheme, ExplorerLink, CoverLink, CreatorName);
                                }
                                else
                                {
                                    ShowReqContant.InnerHtml += BuildRestCardPerMode(MangaName, MangaTheme, ExplorerLink, CoverLink, CreatorName);
                                }
                                if (i != 0) { ShowReqContant.InnerHtml += "<hr style=" + sc.ToString() + "margin:0 auto !important;height:2px;color:rgba(242,242,242,1);width:calc(100vw - 36px);margin:0 auto important;" + sc.ToString() + ">"; }
                            }
                        }
                        else
                        {
                            fail = true;
                        }
                    }
                    sqlCon.Close();
                }
                else
                {
                    fail = true;
                    sqlCon.Close();
                }
            }
            if (fail == true)
            {
                //Response.Redirect("~/404.aspx");
                ShowReqContant.InnerHtml = "<p style=" + '"'.ToString() + "color:rgb(104,64,217,0.74);font-size:112%;width:100%;text-align:center;margin:0 auto !important;margin-top:36px !important;" + '"'.ToString() + ">Nothing Yet!</p>";
            }
        }
        protected string BuildCurrCard(string MangaName, string MangaTheme, string ExplorerLink, string chapter,string CoverLink,string MangaCreator) 
        {
            char sc = '"'; string scfu = sc.ToString();
            string divST = "<div style=" + "overflow:clip;width:fit-content;height:fit-content;" + ">";
            string PDivST = "<div style=" + "margin-top:52px;display:block;width:fit-content;padding-left:8px;" + ">";
            string astyle = scfu + "width:calc(100vw - 12px);height:100px;position:relative;margin-left:0px;display:block;overflow:hidden;" + scfu;
            string imgstyle = scfu + "height:84px;width:84px;object-fit:cover;display:inline;border-radius:12px;float:left;margin:8px;" + scfu;
            string h4style = scfu + "color:" + MangaTheme + ";margin-top:-42px;float:left;margin-left:6px;margin-top:12px;width:calc(100% - 120px);" + scfu;
            string AuthString = "<p style=" + "color:rgb(0,0,0,0.50);float:left;margin-top:-10px;margin-left:6px;" + ">By <b style=" + "font-size:80%;" + ">" + MangaCreator + "</b></p>";
            string RS = divST + "<a onclick=" + sc.ToString() + "if (!navigator.onLine) { fetch('" + ExplorerLink + "', { method: 'GET' }).then(res => { location.href = '" + ExplorerLink + "'; }).catch(err => { document.getElementById('Offline').style.display = 'block'; }); } else { location.href = '" + ExplorerLink + "'; }" + sc.ToString() + " style=" + astyle + " ><img src=" + CoverLink + " class=" + sc.ToString() + "animated pulse" + sc.ToString() + " style=" + imgstyle + "><h4 style=" + h4style + ">" + MangaName + "</h4>" + AuthString + "<br style=" + "float:left;" + ">" + PDivST + "<p style=" + "color:#6b6b6b;font-size:84%;" + ">Chapter: " + chapter + "</p></div></a></div>";// + hr;
            return RS;
        }
        protected string BuildCurrCardPerMode(string MangaName, string MangaTheme, string ExplorerLink, string chapter, string CoverLink, string MangaCreator)
        {
            char sc = '"'; string scfu = sc.ToString();
            string divST = "<div style=" + "overflow:clip;width:fit-content;height:fit-content;" + ">";
            string PDivST = "<div style=" + "margin-top:52px;display:block;width:fit-content;padding-left:8px;" + ">";
            string astyle = scfu + "width:calc(100vw - 12px);height:100px;position:relative;margin-left:0px;display:block;overflow:hidden;" + scfu;
            string imgstyle = scfu + "height:84px;width:84px;object-fit:cover;display:inline;border-radius:12px;float:left;margin:8px;" + scfu;
            string h4style = scfu + "color:" + MangaTheme + ";margin-top:-42px;float:left;margin-left:6px;margin-top:12px;width:calc(100% - 120px);" + scfu;
            string AuthString = "<p style=" + "color:rgb(0,0,0,0.50);float:left;margin-top:-10px;margin-left:6px;" + ">By <b style=" + "font-size:80%;" + ">" + MangaCreator + "</b></p>";
            string RS = divST + "<a onclick=" + sc.ToString() + "if (!navigator.onLine) { fetch('" + ExplorerLink + "', { method: 'GET' }).then(res => { location.href = '" + ExplorerLink + "'; }).catch(err => { document.getElementById('Offline').style.display = 'block'; }); } else { location.href = '" + ExplorerLink + "'; }" + sc.ToString() + " style=" + astyle + " ><img src=" + CoverLink + " style=" + imgstyle + "><h4 style=" + h4style + ">" + MangaName + "</h4>" + AuthString + "<br style=" + "float:left;" + ">" + PDivST + "<p style=" + "color:#6b6b6b;font-size:84%;" + ">Chapter: " + chapter + "</p></div></a></div>";// + hr;
            return RS;
        }
        protected string BuildRestCard(string MangaName, string MangaTheme, string ExplorerLink, string CoverLink, string MangaCreator)
        {
            char sc = '"'; string scfu = sc.ToString();
            string divST = "<div style=" + "overflow:clip;width:fit-content;height:fit-content;" + ">";
            string PDivST = "<div style=" + "margin-top:52px;display:block;width:fit-content;padding-left:8px;" + ">";
            string astyle = scfu + "width:calc(100vw - 12px);height:100px;position:relative;margin-left:0px;display:block;overflow:hidden;" + scfu;
            string imgstyle = scfu + "height:84px;width:84px;object-fit:cover;display:inline;border-radius:12px;float:left;margin:8px;" + scfu;
            string h4style = scfu + "color:" + MangaTheme + ";margin-top:-42px;float:left;margin-left:6px;margin-top:12px;width:calc(100% - 120px);" + scfu;
            string AuthString = "<p style=" + "color:rgb(0,0,0,0.50);float:left;margin-top:-10px;margin-left:6px;" + ">By <b style=" + "font-size:80%;" + ">" + MangaCreator + "</b></p>";
            string RS = divST + "<a onclick=" + sc.ToString() + "if (!navigator.onLine) { fetch('" + ExplorerLink + "', { method: 'GET' }).then(res => { location.href = '" + ExplorerLink + "'; }).catch(err => { document.getElementById('Offline').style.display = 'block'; }); } else { location.href = '" + ExplorerLink + "'; }" + sc.ToString() + " style=" + astyle + " ><img src=" + CoverLink + " class=" + sc.ToString() + "animated pulse" + sc.ToString() + " style=" + imgstyle + "><h4 style=" + h4style + ">" + MangaName + "</h4>" + AuthString + "<br style=" + "float:left;" + ">" + PDivST + "<p style=" + "color:#6b6b6b;font-size:84%;" + "> </p></div></a></div>";// + hr;
            return RS;
        }
        protected string BuildRestCardPerMode(string MangaName, string MangaTheme, string ExplorerLink, string CoverLink, string MangaCreator)
        {
            char sc = '"'; string scfu = sc.ToString();
            string divST = "<div style=" + "overflow:clip;width:fit-content;height:fit-content;" + ">";
            string PDivST = "<div style=" + "margin-top:52px;display:block;width:fit-content;padding-left:8px;" + ">";
            string astyle = scfu + "width:calc(100vw - 12px);height:100px;position:relative;margin-left:0px;display:block;overflow:hidden;" + scfu;
            string imgstyle = scfu + "height:84px;width:84px;object-fit:cover;display:inline;border-radius:12px;float:left;margin:8px;" + scfu;
            string h4style = scfu + "color:" + MangaTheme + ";margin-top:-42px;float:left;margin-left:6px;margin-top:12px;width:calc(100% - 120px);" + scfu;
            string AuthString = "<p style=" + "color:rgb(0,0,0,0.50);float:left;margin-top:-10px;margin-left:6px;" + ">By <b style=" + "font-size:80%;" + ">" + MangaCreator + "</b></p>";
            string RS = divST + "<a onclick=" + sc.ToString() + "if (!navigator.onLine) { fetch('" + ExplorerLink + "', { method: 'GET' }).then(res => { location.href = '" + ExplorerLink + "'; }).catch(err => { document.getElementById('Offline').style.display = 'block'; }); } else { location.href = '" + ExplorerLink + "'; }" + sc.ToString() + " style=" + astyle + " ><img src=" + CoverLink + " style=" + imgstyle + "><h4 style=" + h4style + ">" + MangaName + "</h4>" + AuthString + "<br style=" + "float:left;" + ">" + PDivST + "<p style=" + "color:#6b6b6b;font-size:84%;" + "> </p></div></a></div>";// + hr;
            return RS;
        }
        protected void SussionPross()
        {
            HttpCookie userInfo = Request.Cookies["SuMCurrentUser"];
            if (userInfo != null)
            {
                string SID = userInfo["SID"].ToString();
                int UID = Convert.ToInt32(userInfo["ID"].ToString());
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
        }
        protected void ForceLogOut()
        {
            HttpCookie GetUserInfoCookie = new HttpCookie("SuMCurrentUser");
            GetUserInfoCookie.Expires = DateTime.Now.AddDays(-100);
            Response.Cookies.Add(GetUserInfoCookie);
        }
    }
}