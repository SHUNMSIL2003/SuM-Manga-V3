using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace SuM_Manga_V3
{
    public partial class SuMManga_Mobile : System.Web.UI.MasterPage
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Request.QueryString["TC"] != null)
            {
                //SMHead.InnerHtml += "<meta name=" + "theme-color" + " content=" + Request.QueryString["TC"].ToString() + ">";
                string DTC = Request.QueryString["TC"].ToString();
                System.Web.UI.HtmlControls.HtmlMeta meta = new System.Web.UI.HtmlControls.HtmlMeta();
                meta.Name = "theme-color";
                meta.Content = DTC;
                MetaPlaceHolder.Controls.Add(meta);
                SuMLockViewBlockInnerColor.Attributes["style"] = "width:100%;height:100%;margin:0 auto;background-color:" + DTC + ";";
                //fullnavscont
            }
            else
            {
                //SMHead.InnerHtml += "<meta name=" + "theme-color" + " content=" + "var(--SuMDGray)" + ">";
                System.Web.UI.HtmlControls.HtmlMeta meta = new System.Web.UI.HtmlControls.HtmlMeta();
                meta.Name = "theme-color";
                meta.Content = "var(--SuMDGray)";
                MetaPlaceHolder.Controls.Add(meta);
            }
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
            object QSC = Request.QueryString["TC"];
            if (QSC != null) {
                if (QSC.ToString().Contains("rgb") == true)
                {
                    UserThemeColor = QSC.ToString().Replace("rgb", "").Replace("a", "").Replace("=", "").Replace(",0.74", "").Replace(")", "").Replace("(", "");
                }
            }
            if (Request.QueryString["TC"] != null)
            {
                //SMHead.InnerHtml += "<meta name=" + "theme-color" + " content=" + Request.QueryString["TC"].ToString() + ">";
                System.Web.UI.HtmlControls.HtmlMeta meta = new System.Web.UI.HtmlControls.HtmlMeta();
                meta.Name = "theme-color";
                meta.Content = Request.QueryString["TC"].ToString();
                MetaPlaceHolder.Controls.Add(meta);
            }
            else
            {
                //SMHead.InnerHtml += "<meta name=" + "theme-color" + " content=" + "var(--SuMDGray)" + ">";
                System.Web.UI.HtmlControls.HtmlMeta meta = new System.Web.UI.HtmlControls.HtmlMeta();
                meta.Name = "theme-color";
                meta.Content = "var(--SuMDGray)";
                MetaPlaceHolder.Controls.Add(meta);
            }
            //HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            //if (GetUserInfoCookie != null)
            //{
            /*string PFPFDB = string.Empty;
            string user = GetUserInfoCookie["UserName"].ToString();*/
            //}
            string path = HttpContext.Current.Request.Url.AbsolutePath;
            subnavscont2.Attributes["style"] = "display:none !important;";
            //fullnavscont.Attributes["style"] = "border-radius:22px;height:fit-content !important;overflow:hidden !important;background-color:var(--SuMDWhite) !important;z-index:999;position:fixed !important; display:block;border:0.5px var(--SuMThemeColorOP14) solid !important;width:calc(100vw - 24px) !important;margin-left:12px;";
            if (path.Contains("MangaExplorer"))
            {
                //fullnavscont.Attributes["style"] = "display:none !important;";
                subnavscont2.Attributes["style"] = "margin-bottom:0px;z-index:999;height:44px !important;width:calc(100% - 24px) !important;padding:2px !important;border-radius:22px;position:fixed;bottom:0 !important;float:left;border-top:solid 0.4px var(--SuMDGray) !important; display:block;background-color:var(--SuMDWhite) !important;margin-left:12px;";
                //NavItems.InnerHtml = ""; nav.Attributes["style"] = "height:1vh !important;width:100% !important; ";
            }
            /*HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            if (GetUserInfoCookie == null) { SuMNotificationStart.Visible = false; }*/
            //SuMNotificationStart.Visible = false;//TMP --sumnotifications
        }
        protected string BuildSuMUserThemeCSS(string RGBRoot)
        {
            string RS = "<style> :root { --SuMThemeColor: rgb(" + RGBRoot + "); --SuMThemeColorOP94: rgba(" + RGBRoot + ",0.940); --SuMThemeColorOP92: rgba(" + RGBRoot + ",0.920); --SuMThemeColorOP86: rgba(" + RGBRoot + ",0.860); --SuMThemeColorOP84: rgba(" + RGBRoot + ",0.840); --SuMThemeColorOP74: rgba(" + RGBRoot + ",0.740); --SuMThemeColorOP64: rgba(" + RGBRoot + ",0.640); --SuMThemeColorOP62: rgba(" + RGBRoot + ",0.620); --SuMThemeColorOP54: rgba(" + RGBRoot + ",0.540); --SuMThemeColorOP32: rgba(" + RGBRoot + ",0.320); --SuMThemeColorOP14: rgba(" + RGBRoot + ",0.140); --SuMThemeColorOP08: rgba(" + RGBRoot + ",0.080); --SuMThemeColorOP00: rgba(" + RGBRoot + ",0.000); } </style>";
            return RS;
        }
        /* - New Version Of SuMAppAlerts! - */
        protected void STARTNOFIFICATIONPROSS()
        {
            /*string ThemeColor = string.Empty;
            if (Request.QueryString["TC"] != null) { ThemeColor = Request.QueryString["TC"].ToString(); }
            if (string.IsNullOrEmpty(ThemeColor) == true) { ThemeColor = "var(--SuMDGrayOP74)"; }*/
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            //SuMUserNofifications.Attributes["style"] = "background-color:" + ThemeColor + ";overflow:hidden;width:100vw;height:100vh;display:none;z-index:998 !important;margin:0 auto !important;position:absolute !important;padding-left:12px !important;padding-right:12px !important;";
            if (GetUserInfoCookie != null)
            {
                int UNSEENNum = 0;
                using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    sqlCon.Open();
                    string query = "SELECT SuMPaymentAlert FROM UsersAccountAlert WHERE UserID = @UserID ";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@UserID", SqlDbType.Int);
                    sqlCmd.Parameters["@UserID"].Value = ID;
                    using (SqlDataReader dr = sqlCmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var b = dr[0];
                            if (b != null)
                            {
                                UNSEENNum = Convert.ToInt32(b.ToString());//NUM FOR NOTIFICATION BUBILE
                            }
                        }
                    }
                    sqlCon.Close();
                }
                //
            }
            else
            {
                //
            }
        }
        protected string BuildSeenCard(string IMG, string TITLE, string INFO, string DATE, string LINK, string SENDER)
        {
            string SC = '"'.ToString();
            string DATERES = DATE + "";
            string RS = "";
            RS = "<a class=" + SC + "dropdown-item d-flex align-items-center" + SC + "href=" + LINK + "><div class=" + SC + "dropdown-list-image me-3" + SC + "><img class=" + SC + "rounded-circle" + SC + " src =" + SC + IMG + SC + "><div class=" + "status-indicator" + "></div></div><div class=" + "fw-bold" + "><div class=" + "text-truncate" + "><span>" + INFO + "</span></div><p class=" + SC + "small text-gray-500 mb-0" + SC + ">" + SENDER + " - " + DATERES + "</p></div></a>";
            RS = "";
            return RS;
        }
        protected string BuildGreenCard(string INFO, string DATE, string SENDER)
        {
            string SC = '"'.ToString();
            string DATERES = DATE + "";
            string RS = "";
            RS = "<a class=" + SC + "d-flex align-items-center" + SC + " style=" + SC + "padding-left:6px;padding-top:6px;padding-bottom:6px;" + SC + " ><div class=" + SC + "dropdown-list-image" + SC + "><div class=me-3 ><div class=" + SC + "bg-success icon-circle" + SC + "><i class=" + SC + "fas fa-donate text-white" + SC + "></i></div></div></div><div class=" + '"'.ToString() + "fw-bold NotifMaxWidth" + '"'.ToString() + " ><div class=" + "text-truncate" + "><span style=" + "color:var(--SuMDBlackOP70);" + " >" + INFO + "</span></div><p class=" + SC + "small mb-0" + SC + " style=color:var(--SuMDBlackOP50); >" + SENDER + " - " + DATERES + "</p></div></a>";
            //RS = "";
            return RS;
        }
        protected string BuildYellowCard(string INFO, string DATE, string LINK, string SENDER)
        {
            string SC = '"'.ToString();
            string DATERES = DATE + "";
            string RS = "";
            RS = "<a href=" + SC + LINK + SC + " class=" + SC + "d-flex align-items-center" + SC + " style=" + SC + "padding-left:6px;padding-top:6px;padding-bottom:6px;" + SC + " ><div class=" + SC + "dropdown-list-image" + SC + "><div class=me-3 ><div class=" + SC + "bg-warning icon-circle" + SC + "><i class=" + SC + "fas fa-exclamation-triangle text-white" + SC + "></i></div></div></div><div class=" + '"'.ToString() + "fw-bold NotifMaxWidth" + '"'.ToString() + " ><div class=" + "text-truncate" + "><span style=" + "color:var(--SuMDBlackOP70);" + " >" + INFO + "</span></div><p class=" + SC + "small mb-0" + SC + " style=color:var(--SuMDBlackOP50); >" + SENDER + " - " + DATERES + "</p></div></a>";
            //RS = "";
            return RS;
        }
        protected string BuildUnseenCard(string IMG, string TITLE, string INFO, string DATE, string LINK, string SENDER)
        {
            string SC = '"'.ToString();
            string DATERES = DATE + "";
            string RS = "";
            RS = "<a class=" + SC + "dropdown-item d-flex align-items-center" + SC + "href=" + LINK + "><div class=" + SC + "dropdown-list-image me-3" + SC + "><img class=" + SC + "rounded-circle" + SC + " src =" + SC + IMG + SC + "><div class=" + SC + "bg-warning status-indicator" + SC + "></div></div><div class=" + "fw-bold" + "><div class=" + "text-truncate" + "><span>" + INFO + "</span></div><p class=" + SC + "small text-gray-500 mb-0" + SC + ">" + SENDER + " - " + DATERES + "</p></div></a>";
            RS = "";
            return RS;
        }
        protected void ToSign(object sender, EventArgs e)
        {
            Response.Redirect("~/AccountETC/LoginETC.aspx");
        }
        /*protected void MarkReadDone(int Colum, string OValue) //name colum but its a row
        {
            string confirmseentag = "";
            string backupoldfornew = "";
            bool dollarfound = false;
            char[] value = OValue.ToCharArray();
            for (int g = 0; g < OValue.Length; g++)
            {
                if (dollarfound == false) { backupoldfornew += value[g]; } else { confirmseentag = (value[g + 1]).ToString(); g = OValue.Length; }
                if (g == '$') { dollarfound = true; }//can be optimized ! -Later-> no need now i think...
            }
            string NewSeenTag = string.Empty;
            if (confirmseentag == "N")
            {

                NewSeenTag = backupoldfornew + "Y";
            }
            else { NewSeenTag = OValue; }
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string query = "UPDATE UsersAccountAlert SET SuMPaymentAlert = @SuMPaymentAlert WHERE UserID = @UserID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                //HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
                sqlCmd.Parameters.AddWithValue("@UserID", Colum);
                sqlCmd.Parameters.AddWithValue("@SuMPaymentAlert", NewSeenTag);
                sqlCmd.ExecuteNonQuery();
                //sqlCmd.Parameters.AddWithValue("@SuMCustomPFP", SqlDbType.Image).Value = imgarray;
                sqlCon.Close();
            }
        }*/
        public void empty0() { }
        protected void LogOut(object sender, EventArgs e)
        {
            HttpCookie GetUserInfoCookie = new HttpCookie("SuMCurrentUser");
            GetUserInfoCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(GetUserInfoCookie);
            //HttpCookie GetUserpinns = Request.Cookies["SuMPinns"];
            //GetUserpinns["Pinns"] = "!";
            //Response.Cookies.Add(GetUserpinns);
            Response.Redirect("~/AccountETC/LogInETC.aspx");
        }
        /*protected string GetMangaFromSQL(string Wanted)
        {
            string ResultsQ = string.Empty;
            //int i = 0;
            string MangaName = string.Empty;
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string queryFIND = "SELECT MangaID FROM SuMManga WHERE MangaName LIKE @Wanted ";
                SqlCommand sqlCmdFIND = new SqlCommand(queryFIND, sqlCon);
                sqlCmdFIND.Parameters.AddWithValue("@Wanted", Wanted);
                var FID = sqlCmdFIND.ExecuteScalar();
                if (FID != null)
                {
                    //Debig202312.InnerHtml = FID.ToString();
                    //var X = sqlCmdFIND.ExecuteScalar(); //ExecuteNonQuery();
                    int i = Convert.ToInt32(FID);

                    string query = "SELECT ChaptersNumber FROM SuMManga WHERE MangaID = @MangaID";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    sqlCmd.Parameters["@MangaID"].Value = i;
                    //X = sqlCmd.ExecuteScalar();
                    int ChaptersNum = (Int32)sqlCmd.ExecuteScalar(); // Convert.ToInt32(sqlCmd.ExecuteScalar()); //(Int32)sqlCmd.ExecuteScalar();

                    query = "SELECT MangaInfo FROM SuMManga WHERE MangaID = @MangaID";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    sqlCmd.Parameters["@MangaID"].Value = i;
                    var X = sqlCmd.ExecuteScalar();
                    string MangaInfo = X.ToString();

                    query = "SELECT MangaViews FROM SuMManga WHERE MangaID = @MangaID";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    sqlCmd.Parameters["@MangaID"].Value = i;
                    //X = sqlCmd.ExecuteScalar();
                    int MangaViews = (Int32)sqlCmd.ExecuteScalar();

                    query = "SELECT CExplorerLink FROM SuMManga WHERE MangaID = @MangaID";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    sqlCmd.Parameters["@MangaID"].Value = i;
                    X = sqlCmd.ExecuteScalar();
                    string CExplorerLink = X.ToString();

                    query = "SELECT MangaCoverLink FROM SuMManga WHERE MangaID = @MangaID";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    sqlCmd.Parameters["@MangaID"].Value = i;
                    // X = sqlCmd.ExecuteScalar();
                    string MangaCoverLink = sqlCmd.ExecuteScalar().ToString();
                    query = "SELECT MangaName FROM SuMManga WHERE MangaID = @MangaID";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    sqlCmd.Parameters["@MangaID"].Value = i;
                    X = sqlCmd.ExecuteScalar();
                    MangaName = X.ToString();
                    return ContantShow(MangaName, MangaInfo, MangaViews, MangaCoverLink, CExplorerLink, ChaptersNum, i);


                    //return ContantShow(MangaName, MangaInfo, MangaViews, MangaCoverLink, CExplorerLink, ChaptersNum, ID);
                }
                else { return "<h4>Not Found!</h4>"; }
            }
        }*/
        /*public bool MatchUPto50Per(string a, string b)
        {
            if (a.Length > 0 && b.Length > 0)
            {
                char[] ca = a.ToCharArray();
                char[] cb = b.ToCharArray();
                int matchednum = 0;
                double devideon = b.Length;
                if (a.Length > b.Length)
                {
                    for (int i = 0; i < b.Length; i++)
                    {
                        if (ca[i] == cb[i]) { matchednum++; }
                    }
                    if ((double)(matchednum / devideon) > 0.3) { return true; }
                    else { return false; }
                }
                else
                {
                    for (int i = 0; i < a.Length; i++)
                    {
                        if (ca[i] == cb[i]) { matchednum++; }
                    }
                    if ((double)(matchednum / devideon) > 0.3) { return true; }
                    else { return false; }
                }
            }
            else { return false; }
        }*/
        /*public string ContantShow(string MangaName, string MangaInfo, int MangaViews, string MangaCoverLink, string CExplorerLink, int ChaptersNum, int id)
        {
            string cn = ChaptersNum.ToString();
            CExplorerLink += "&CN=" + cn + "&VC=" + id;
            string figureclass = "imghvr-fade box";//width:160px;
            string figurestyle = "margin-left:2.6px;margin-right:2.6px;margin-top:3px;width:136px;height:204px;border-radius:10px;border-top-left-radius:10px;border-bottom-right-radius:10px;border:-2px solid var(--SuMThemeColor);";
            string astyle = "border-radius:10px;margin:10px;width:142px;";//mw
            //string vstyle = "margin-left:4px;width:24px;height:24px;position:relative;z-index:1;display:block;";
            //string vimage = "/storeitems/view.png";
            string viewes ="<h6 style=" + "color:white;position:relative;display:inline-block;margin-top:-10px" + ">Views:" + MangaViews + " Ch: " + ChaptersNum + "</h6>";
            string divfits = "<div data-bss-hover-animate=" + "pulse" + " style=" + "display:inline-block; height:fit-content;width:142px;" + ">";//mw
            string result = divfits + "<a href=" + CExplorerLink + " ><figure class=" + figureclass + "  style = " + astyle + "  ><img style = " + figurestyle + " src=" + MangaCoverLink + ">" + viewes + "<figcaption><h6 style=" + "font-size:100%;" + " ><b>" + MangaName + "</b></h6><br/><h6 style=" + "font-size:74%;" + " >" + MangaInfo + "</h6></figcaption></figure></a></div>";
            return result;
        }*/
    }
}