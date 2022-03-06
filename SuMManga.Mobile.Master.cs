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
                //SMHead.InnerHtml += "<meta name=" + "theme-color" + " content=" + "rgb(242,242,242)" + ">";
                System.Web.UI.HtmlControls.HtmlMeta meta = new System.Web.UI.HtmlControls.HtmlMeta();
                meta.Name = "theme-color";
                meta.Content = "rgb(242,242,242)";
                MetaPlaceHolder.Controls.Add(meta);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["TC"] != null)
            {
                //SMHead.InnerHtml += "<meta name=" + "theme-color" + " content=" + Request.QueryString["TC"].ToString() + ">";
                System.Web.UI.HtmlControls.HtmlMeta meta = new System.Web.UI.HtmlControls.HtmlMeta();
                meta.Name = "theme-color";
                meta.Content = Request.QueryString["TC"].ToString();
                MetaPlaceHolder.Controls.Add(meta);
                if (Request.QueryString["TC"].ToString().Contains("255,255,255") == false)
                {
                    NavigateBackF0C0.Attributes["style"] = "font-size:54%;display:block !important;margin-left:12px;margin-top:-10px;color:" + Request.QueryString["TC"].ToString() + ";";
                    NavigateBackF0C1.Attributes["style"] = "font-size:54%;display:block !important;margin-left:46px;margin-top:-10px;color:" + Request.QueryString["TC"].ToString() + ";";
                }
                else 
                {
                    NavigateBackF0C0.Attributes["style"] = "font-size:54%;display:block !important;margin-left:12px;margin-top:-10px;color:#6840D9BD;";
                    NavigateBackF0C1.Attributes["style"] = "font-size:54%;display:block !important;margin-left:46px;margin-top:-10px;color:#6840D9BD;";
                }
                //fullnavscont
            }
            else
            {
                NavigateBackF0C0.Attributes["style"] = "font-size:54%;display:block !important;margin-left:12px;margin-top:-10px;color:#6840D9BD;";
                NavigateBackF0C1.Attributes["style"] = "font-size:54%;display:block !important;margin-left:46px;margin-top:-10px;color:#6840D9BD;";
                //SMHead.InnerHtml += "<meta name=" + "theme-color" + " content=" + "rgb(242,242,242)" + ">";
                System.Web.UI.HtmlControls.HtmlMeta meta = new System.Web.UI.HtmlControls.HtmlMeta();
                meta.Name = "theme-color";
                meta.Content = "rgb(242,242,242)";
                MetaPlaceHolder.Controls.Add(meta);
            }
            //HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            //if (GetUserInfoCookie != null)
            //{
            /*string PFPFDB = string.Empty;
            string user = GetUserInfoCookie["UserName"].ToString();*/
            //}
            string path = HttpContext.Current.Request.Url.AbsolutePath;
            bool foundit = false;
            subnavscont2.Attributes["style"] = "display:none !important;";
            fullnavscont.Attributes["style"] = "border-top-left-radius:22px;border-top-right-radius:22px;height:fit-content !important;overflow:hidden !important;background-color:#ffffff !important;z-index:999;position:fixed !important;-webkit-transition: all 0.18s !important; -moz-transition: all 0.18s !important; -ms-transition: all 0.18s !important; -o-transition: all 0.18s !important; transition: all 0.18s !important;";
            if (path.Contains("Explore") == true || string.IsNullOrEmpty(path) == true || path == "/")
            {
                foundit = true;
                ExpIMG.Attributes["src"] = "/svg/Explore.svg"; ExpText.Attributes["style"] = "font-size:64%;color:#6840D9;height:19px !important;text-align:center !important;display:block;position:relative;";
                LibIMG.Attributes["src"] = "/svg/bookmarksNA.svg"; LibText.Attributes["style"] = "font-size:64%;color:#636166;height:19px !important;text-align:center !important;display:block;position:relative;";
                SetIMG.Attributes["src"] = "/svg/settingsNA.svg"; SetText.Attributes["style"] = "font-size:64%;color:#636166;height:19px !important;text-align:center !important;display:block;position:relative;";
            }
            if (path.Contains("Library") == true)
            {
                foundit = true;
                ExpIMG.Attributes["src"] = "/svg/ExploreNA.svg"; ExpText.Attributes["style"] = "font-size:64%;color:#636166;height:19px !important;text-align:center !important;display:block;position:relative;";
                LibIMG.Attributes["src"] = "/svg/bookmarks.svg"; LibText.Attributes["style"] = "font-size:64%;color:#6840D9;height:19px !important;text-align:center !important;display:block;position:relative;";
                SetIMG.Attributes["src"] = "/svg/settingsNA.svg"; SetText.Attributes["style"] = "font-size:64%;color:#636166;height:19px !important;text-align:center !important;display:block;position:relative;";
            }
            if (path.Contains("Settings"))
            {
                foundit = true;
                ExpIMG.Attributes["src"] = "/svg/ExploreNA.svg"; ExpText.Attributes["style"] = "font-size:64%;color:#636166;height:19px !important;text-align:center !important;display:block;position:relative;";
                LibIMG.Attributes["src"] = "/svg/bookmarksNA.svg"; LibText.Attributes["style"] = "font-size:64%;color:#636166;height:19px !important;text-align:center !important;display:block;position:relative;";
                SetIMG.Attributes["src"] = "/svg/settings.svg"; SetText.Attributes["style"] = "font-size:64%;color:#6840D9;height:19px !important;text-align:center !important;display:block;position:relative;";
            }
            if (path.Contains("Hits") == true)
            {
                foundit = true;
                ExpIMG.Attributes["src"] = "/svg/ExploreNA.svg"; ExpText.Attributes["style"] = "font-size:64%;color:#636166;height:19px !important;text-align:center !important;display:block;position:relative;";
                LibIMG.Attributes["src"] = "/svg/bookmarksNA.svg"; LibText.Attributes["style"] = "font-size:64%;color:#636166;height:19px !important;text-align:center !important;display:block;position:relative;";
                SetIMG.Attributes["src"] = "/svg/settingsNA.svg"; SetText.Attributes["style"] = "font-size:64%;color:#636166;height:19px !important;text-align:center !important;display:block;position:relative;";
                HitsIMG.Attributes["src"] = "/svg/MostSeen.svg"; HitsTEXT.Attributes["style"] = "font-size:64%;color:#6840D9;height:19px !important;text-align:center !important;display:block;position:relative;";
            }
            /*if (path.Contains("smth") == true) 
            {
                ExpIMG.Attributes["src"] = "/svg/Explore.svg"; ExpText.Attributes["style"] = "font-size:64%;color:#6840D9;height:2vh !important;text-align:center !important;display:block;position:relative;";
                LibIMG.Attributes["src"] = "/svg/bookmarksNA.svg"; LibText.Attributes["style"] = "font-size:64%;color:#a3a3a3;height:2vh !important;text-align:center !important;display:block;position:relative;";
                SetIMG.Attributes["src"] = "/svg/settingsNA.svg"; SetText.Attributes["style"] = "font-size:64%;color:#a3a3a3;height:2vh !important;text-align:center !important;display:block;position:relative;";
            }*/
            if (/*path.Contains("ContantExplorer") ||*/ path.Contains("MangaExplorer"))
            {
                //if (Request.QueryString["TC"] != null)
                //{
                //fullnavscont.Attributes["style"] = "border-top-left-radius:22px;border-top-right-radius:22px;height:fit-content;background-color:" + Request.QueryString["TC"].ToString() + " !important;";
                //subnavscont.Attributes["style"] = "height:36px;width:100% !important;padding:2px !important;border-top-left-radius:22px;border-top-right-radius:22px;background-color:" + Request.QueryString["TC"].ToString() + " !important;";
                //wrapper.Attributes["style"] = "overflow:hidden;background-color:" + Request.QueryString["TC"].ToString() + " !important;";
                //}
                fullnavscont.Attributes["style"] = "display:none !important;";
                subnavscont2.Attributes["style"] = "margin-bottom:-2px;z-index:999;height:50px !important;width:100% !important;padding:2px !important;border-top-left-radius:22px;border-top-right-radius:22px;position:fixed;bottom:0 !important;float:left;border-top:solid 0.4px #f2f2f2 !important;-webkit-transition: all 0.18s !important; -moz-transition: all 0.18s !important; -ms-transition: all 0.18s !important; -o-transition: all 0.18s !important; transition: all 0.18s !important;";
                foundit = true; NavItems.InnerHtml = ""; nav.Attributes["style"] = "height:1vh !important;width:100% !important;-webkit-transition: all 0.18s !important; -moz-transition: all 0.18s !important; -ms-transition: all 0.18s !important; -o-transition: all 0.18s !important; transition: all 0.18s !important;";
            }
            if (foundit == false)
            {
                ExpIMG.Attributes["src"] = "/svg/ExploreNA.svg"; ExpText.Attributes["style"] = "font-size:64%;color:#636166;height:19px !important;text-align:center !important;display:block;position:relative;";
                LibIMG.Attributes["src"] = "/svg/bookmarksNA.svg"; LibText.Attributes["style"] = "font-size:64%;color:#636166;height:19px !important;text-align:center !important;display:block;position:relative;";
                SetIMG.Attributes["src"] = "/svg/settingsNA.svg"; SetText.Attributes["style"] = "font-size:64%;color:#636166;height:19px !important;text-align:center !important;display:block;position:relative;";
            }
            if (Request.QueryString["TC"] != null)
            {
                mangacolor.Attributes["style"] = "display:inline;color:" + Request.QueryString["TC"].ToString() + ";margin-top:8px !important;";
                mangacolor2.Attributes["style"] = "display:inline;color:" + Request.QueryString["TC"].ToString() + ";margin-top:8px !important;";
            }
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            if (GetUserInfoCookie == null) { SuMNotificationStart.Visible = false; }
        }
        /* - New Version Of SuMAppAlerts! - */
        protected void STARTNOFIFICATIONPROSS()
        {
            /*string ThemeColor = string.Empty;
            if (Request.QueryString["TC"] != null) { ThemeColor = Request.QueryString["TC"].ToString(); }
            if (string.IsNullOrEmpty(ThemeColor) == true) { ThemeColor = "rgba(242,242,242,0.74)"; }*/
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
        protected void SuMAppAlertsStartsS(object sender, EventArgs e)
        {
            HttpCookie GetUserInfoCookie2 = Request.Cookies["SuMCurrentUser"];
            if (GetUserInfoCookie2 != null)
            {
                string ThemeColor = string.Empty;
                if (Request.QueryString["TC"] != null) { ThemeColor = Request.QueryString["TC"].ToString().Replace("0.74", "0.92"); }
                if (string.IsNullOrEmpty(ThemeColor) == true || ThemeColor.Contains("255,255,255") == true) { ThemeColor = "rgba(104,64,217,0.92)"; }
                SuMUserNofifications.Attributes["style"] = "animation-duration:0.36s !important;background-color:" + ThemeColor + ";overflow:hidden;width:100vw;height:100vh;display:block;z-index:998 !important;margin:0 auto !important;position:absolute !important;padding-left:12px !important;padding-right:12px !important;margin-left:-100vw !important;";
                int ID = Convert.ToInt32(GetUserInfoCookie2["ID"].ToString());
                string UserName = GetUserInfoCookie2["UserName"].ToString();
                string UserPFP = string.Empty;
                object UNSEENRawPayAlert = string.Empty;
                object SEENRawPayAlert = string.Empty;
                object UNSEENRawSecureAlert = string.Empty;
                object SEENRawSecureAlert = string.Empty;
                object UNSEENRawOtherAlerts = string.Empty;
                object SEENRawOtherAlerts = string.Empty;
                using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    sqlCon.Open();
                    //Pay
                    string query = "SELECT SuMPaymentAlert FROM UsersAccountAlert WHERE UserID = @UserID ";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@UserID", SqlDbType.Int);
                    sqlCmd.Parameters["@UserID"].Value = ID;
                    using (SqlDataReader dr = sqlCmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            UNSEENRawPayAlert = dr[0];//PAY NOT SEEN
                        }
                    }
                    /*query = "SELECT SuMPaymentAlertSeen FROM UsersAccountAlert WHERE UserID = @UserID ";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@UserID", SqlDbType.Int);
                    sqlCmd.Parameters["@UserID"].Value = ID;
                    using (SqlDataReader dr = sqlCmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            SEENRawPayAlert = dr[0];
                        }
                    }*/
                    //SECURE
                    query = "SELECT SecurityAlert FROM UsersAccountAlert WHERE UserID = @UserID ";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@UserID", SqlDbType.Int);
                    sqlCmd.Parameters["@UserID"].Value = ID;
                    using (SqlDataReader dr = sqlCmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            UNSEENRawSecureAlert = dr[0];//SECURITY NOT SEEN
                        }
                    }
                    query = "SELECT SecurityAlertSeen FROM UsersAccountAlert WHERE UserID = @UserID ";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@UserID", SqlDbType.Int);
                    sqlCmd.Parameters["@UserID"].Value = ID;
                    using (SqlDataReader dr = sqlCmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            SEENRawSecureAlert = dr[0];//SECURITY SEEN
                        }
                    }
                    //OTHER
                    /*query = "SELECT OtherAlerts FROM UsersAccountAlert WHERE UserID = @UserID ";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@UserID", SqlDbType.Int);
                    sqlCmd.Parameters["@UserID"].Value = ID;
                    using (SqlDataReader dr = sqlCmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            UNSEENRawOtherAlerts = dr[0];//OTHER NOT SEEN
                        }
                    }
                    query = "SELECT OtherAlertsSeen FROM UsersAccountAlert WHERE UserID = @UserID ";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@UserID", SqlDbType.Int);
                    sqlCmd.Parameters["@UserID"].Value = ID;
                    using (SqlDataReader dr = sqlCmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            SEENRawOtherAlerts = dr[0];//OTHER SEEN
                        }
                    }*/
                    query = "SELECT PFP FROM SuMUsersAccounts WHERE UserID = @UserID ";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@UserID", SqlDbType.Int);
                    sqlCmd.Parameters["@UserID"].Value = ID;
                    using (SqlDataReader dr = sqlCmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            UserPFP = dr[0].ToString();//User-PFP
                        }
                    }
                    sqlCon.Close();
                }
                NotiUPFP.Attributes["src"] = UserPFP;
                NotiUserName.InnerText = UserName;
                // - only Payment Notification for now! -
                /*if (SEENRawPayAlert != null)
                {
                    // - May Not Be Used! - 
                }*/
                if (UNSEENRawPayAlert != null)
                {
                    RawPayProssor(UNSEENRawPayAlert.ToString());
                }
                //MarkReadDone(ID, RawAlert);
                // -TEMP!-
                USERNOTIFICATIONS.InnerHtml = "<a style=" + '"'.ToString() + "width:100% !important;height:calc(50vh - 200px) !important;display:block !important;" + '"'.ToString() + "></a> <a style=" + '"'.ToString() + "color:" + ThemeColor + ";margin:0 auto !important;text-align:center;width:100%;font-size:94%;vertical-align:middle !important;margin-top:18px;" + '"'.ToString() + "><b> no notifications yet! </b></a>";
            }
        }
        protected void RawPayProssor(string RawPay)
        {
            //#FreeT?Y2021?M12?D23$N
            string ACCOUNTSTATUSKEY = string.Empty;
            string ASDY = "";
            string ASDM = "";
            string ASDD = "";
            char[] Pross = RawPay.ToCharArray();
            for (int i = 0; i < Pross.Length; i++)
            {
                if (Pross[i] == '#')
                {
                    ACCOUNTSTATUSKEY = Pross[i + 1].ToString() + Pross[i + 2].ToString() + Pross[i + 3].ToString() + Pross[i + 4].ToString();
                }
                if (Pross[i] == '?' && Pross[i + 1] == 'Y')
                {
                    ASDY = Pross[i + 2].ToString() + Pross[i + 3].ToString() + Pross[i + 4].ToString() + Pross[i + 5].ToString();
                }
                if (Pross[i] == '?' && Pross[i + 1] == 'M')
                {
                    ASDM = Pross[i + 2].ToString() + Pross[i + 3].ToString();
                }
                if (Pross[i] == '?' && Pross[i + 1] == 'D')
                {
                    ASDD = Pross[i + 2].ToString() + Pross[i + 3].ToString();
                }
            }
            /*int DD = Convert.ToInt32(DateTime.UtcNow.ToString("dd")) - ASDD;
            int DDbw = ASDD - Convert.ToInt32(DateTime.UtcNow.ToString("dd"));
            int MD = Convert.ToInt32(DateTime.UtcNow.ToString("MM")) - ASDM;
            int YD = Convert.ToInt32(DateTime.UtcNow.ToString("yyyy")) - ASDY;*/
            bool MembershipIsValid = false;
            DateTime STARTDate = DateTime.ParseExact(ASDY + ASDM + ASDD, "yyyyMMdd", null);
            //DateTime.Parse(ASDM + "/" + ASDD + "/" + ASDY);
            if ((DateTime.UtcNow - STARTDate).TotalDays < 31)
            {
                MembershipIsValid = true;
            }
            ACCOUNTSTATUSKEY = ACCOUNTSTATUSKEY.ToUpper();
            if (MembershipIsValid == true)
            {
                if (ACCOUNTSTATUSKEY == "FREE")
                {
                    ACCOUNTNOTOFICATIONSPaymentCard.InnerHtml = BuildGreenCard("No actiond is needed, enjoy your free trial!", STARTDate.ToString("MMMM d yyyy"), "SuM System");
                }
                if (ACCOUNTSTATUSKEY == "PAID")
                {
                    ACCOUNTNOTOFICATIONSPaymentCard.InnerHtml = BuildGreenCard("No actiond is needed, enjoy!", STARTDate.ToString("MMMM d yyyy"), "SuM System");
                }
            }
            if (MembershipIsValid == false)
            {
                if (ACCOUNTSTATUSKEY == "FREE")
                {
                    ACCOUNTNOTOFICATIONSPaymentCard.InnerHtml = BuildYellowCard("payment is needed, your free trial has expired!", DateTime.Now.ToString("MMMM d yyyy"), "/AccountETC/Settings.aspx?TC=rgba(255,255,255,1)", "SuM System");
                }
                if (ACCOUNTSTATUSKEY == "PAID")
                {
                    ACCOUNTNOTOFICATIONSPaymentCard.InnerHtml = BuildYellowCard("payment is needed, your free subscription has expired!", DateTime.Now.ToString("MMMM d yyyy"), "/AccountETC/Settings.aspx?TC=rgba(255,255,255,1)", "SuM System");
                }
            }
            //ACCOUNTNOTOFICATIONSPaymentCard.InnerHtml += "<a>" + ACCOUNTSTATUSKEY + " MS:" + MembershipIsValid.ToString() + "</a>"; DEBUG
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
            RS = "<a class=" + SC + "d-flex align-items-center" + SC + " style=" + SC + "padding-left:6px;padding-top:6px;padding-bottom:6px;" + SC + " ><div class=" + SC + "dropdown-list-image" + SC + "><div class=me-3 ><div class=" + SC + "bg-success icon-circle" + SC + "><i class=" + SC + "fas fa-donate text-white" + SC + "></i></div></div></div><div class=" + '"'.ToString() + "fw-bold NotifMaxWidth" + '"'.ToString() + " ><div class=" + "text-truncate" + "><span style=" + "color:#000000B3;" + " >" + INFO + "</span></div><p class=" + SC + "small mb-0" + SC + " style=color:#00000080; >" + SENDER + " - " + DATERES + "</p></div></a>";
            //RS = "";
            return RS;
        }
        protected string BuildYellowCard(string INFO, string DATE, string LINK, string SENDER)
        {
            string SC = '"'.ToString();
            string DATERES = DATE + "";
            string RS = "";
            RS = "<a href=" + SC + LINK + SC + " class=" + SC + "d-flex align-items-center" + SC + " style=" + SC + "padding-left:6px;padding-top:6px;padding-bottom:6px;" + SC + " ><div class=" + SC + "dropdown-list-image" + SC + "><div class=me-3 ><div class=" + SC + "bg-warning icon-circle" + SC + "><i class=" + SC + "fas fa-exclamation-triangle text-white" + SC + "></i></div></div></div><div class=" + '"'.ToString() + "fw-bold NotifMaxWidth" + '"'.ToString() + " ><div class=" + "text-truncate" + "><span style=" + "color:#000000B3;" + " >" + INFO + "</span></div><p class=" + SC + "small mb-0" + SC + " style=color:#00000080; >" + SENDER + " - " + DATERES + "</p></div></a>";
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
            string figurestyle = "margin-left:2.6px;margin-right:2.6px;margin-top:3px;width:136px;height:204px;border-radius:10px;border-top-left-radius:10px;border-bottom-right-radius:10px;border:-2px solid #6840D9;";
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