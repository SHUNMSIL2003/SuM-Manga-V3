using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;

namespace SuM_Manga_V3.AccountETC
{
    public partial class Settings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SussionPross();
            //LastRefreshPross();
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            if (GetUserInfoCookie != null)
            {
                // -Debug Start-
                //RootDebug.InnerText = GetUserInfoCookie.Value;
                // -Debug End-
                AccountSettingsOrLogin.Attributes["onclick"] = "if (document.getElementById('MainContent_UserSettingsCards').style.height == '0px') { document.getElementById('MainContent_UserSettingsCards').style.height = '308px'; document.getElementById('MainContent_TapForXText').innerText = 'Tap for less!'; } else { document.getElementById('MainContent_UserSettingsCards').style.height = '0px'; document.getElementById('MainContent_TapForXText').innerText = 'Tap for more!'; document.getElementById('MainContent_PFPDiv').style.display = 'none'; document.getElementById('MainContent_ChangeEmailDiv').style.display = 'none'; document.getElementById('MainContent_SigAndMore').style.display = 'none'; document.getElementById('MainContent_creatorsupmitform').style.display = 'none'; document.getElementById('MainContent_PaymentCard').style.display = 'none'; document.getElementById('MainContent_ManageDevicesCard').style.display = 'none'; }"; //"if (document.getElementById('UserSettingsCards').style.height == '0px') { document.getElementById('UserSettingsCards').style.height = '232px'; } else { document.getElementById('UserSettingsCards').style.height = '0px'; }";
                //"document.getElementById('UserSettingsCards').style.display = (document.getElementById('UserSettingsCards').style.display == 'block') ? 'none' : 'block';";
                AccountSettingsOrLogin.Attributes["href"] = "#";
                string UserName = GetUserInfoCookie["UserName"].ToString();
                int UserID = Convert.ToInt32(GetUserInfoCookie["ID"].ToString());
                SuMUserName.InnerText = UserName;
                string CurrPFP = string.Empty;
                string currEmail = string.Empty;
                string CurrBanner = string.Empty;
                using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    sqlCon.Open();
                    string query = "SELECT PFP FROM SuMUsersAccounts WHERE UserID = @UID";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@UID", SqlDbType.Int);
                    sqlCmd.Parameters["@UID"].Value = UserID;
                    using (SqlDataReader dr = sqlCmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            CurrPFP = dr[0].ToString();
                        }
                    }
                    string query4 = "SELECT Email FROM SuMUsersAccounts WHERE UserID = @UID";
                    SqlCommand sqlCmd4 = new SqlCommand(query4, sqlCon);
                    sqlCmd4.Parameters.AddWithValue("@UID", SqlDbType.Int);
                    sqlCmd4.Parameters["@UID"].Value = UserID;
                    using (SqlDataReader dr = sqlCmd4.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            currEmail = dr[0].ToString();
                        }
                    }
                    //Banner start
                    string query5 = "SELECT UserBanner FROM SuMUsersAccounts WHERE UserID = @UID";
                    SqlCommand sqlCmd5 = new SqlCommand(query5, sqlCon);
                    sqlCmd5.Parameters.AddWithValue("@UID", SqlDbType.Int);
                    sqlCmd5.Parameters["@UID"].Value = UserID;
                    using (SqlDataReader dr = sqlCmd5.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            object TIIIS = dr[0];
                            if (TIIIS != null)
                            {
                                CurrBanner = TIIIS.ToString();
                            }
                        }
                    }
                    //Sig start
                    string query3 = "SELECT Signetsure FROM SuMUsersAccounts WHERE UserID = @UID";
                    SqlCommand sqlCmd3 = new SqlCommand(query3, sqlCon);
                    sqlCmd3.Parameters.AddWithValue("@UID", SqlDbType.Int);
                    sqlCmd3.Parameters["@UID"].Value = UserID;
                    using (SqlDataReader dr = sqlCmd3.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            currSignetsure = dr[0].ToString();
                        }
                    }
                    sqlCon.Close();
                }
                SignedWith.InnerText = currEmail;
                PFP.Attributes["src"] = ResolveUrl(CurrPFP);
                if (string.IsNullOrEmpty(CurrBanner) == false)
                {
                    ThisPageMaxNoShowScrool.Attributes["style"] = "background-color:var(--SuMThemeColorOP74) !important;border-radius:20px !important;width:100%;margin:0 auto !important;padding:16px !important;margin-top:0px !important; margin-bottom:0px !important;z-index:998;position:relative;background-image:linear-gradient(rgba(0,0,0,0.16),rgba(0,0,0,0.16)) , url(" + CurrBanner + "); background-size: cover; background-position: center;";
                    CurrUserBannerPlaceHolder.InnerText = CurrBanner;
                }
                //Imported code from SuMAccount.aspx.cs + Sig from above
                SignaturePE.Attributes["placeholder"] = currSignetsure;
                UserNameEP.Attributes["placeholder"] = UserName;
                EmailEP.Attributes["placeholder"] = currEmail;
                PFPC.Attributes["src"] = ResolveUrl(CurrPFP);
                if (GetUserInfoCookie["CreatorName"] != null) 
                {
                    CreatorClick.Attributes["onclick"] = "SuMGoToThis('/SuMCreator/CreatorPanel.aspx','var(--SuMThemeColorOP74)','Creator Panel','Creator');";
                    CraetorSecTitle.InnerText = "creator panel";
                }
            }
            else
            {
                LogOutBTN.Attributes["style"] = "display:none;";
                LogOutBTN.Attributes["OnClick"] = "NULL";
                PFP.Attributes["src"] = SuMRandomPFP();
                TapForXText.Attributes["style"] = "color:var(--SuMDWhiteOP64);margin-top:-18px;width:100%;text-align:center;font-size:76%;padding-bottom:-16px;";
                TapForXText.InnerText = "Tap to login!";
            }
            /*HttpCookie GetPerModeInfoCookie = Request.Cookies["SuMPerformanceMode"];
            if (GetPerModeInfoCookie != null)
            {
                SettingsUnavaliblePOPUP.Attributes["style"] = "animation-duration:0s !important;background-color:var(--SuMDBlackOP32) !important;overflow:hidden;width:100vw;height:100vh;display:none;z-index:999 !important;margin:0 auto !important;position:absolute !important;padding-left:12px !important;padding-right:12px !important;";
                StartSetAnim.Attributes["class"] = "";
                SlideDownCard.Attributes["class"] = "";
                PFP.Attributes["class"] = "";
                UserInfoDiv.Attributes["class"] = "";
                PFPDiv.Attributes["class"] = "card-body text-center";
                ChangeEmailDiv.Attributes["class"] = "card-body";
                SigAndMore.Attributes["class"] = "card-body";
                PaymentCard.Attributes["class"] = "card-body";
                creatorsupmitform.Attributes["class"] = "card-body";
                UserSettingsCards.Attributes["style"] = "display:block;height:0px;overflow:hidden;transition:none;background-color:var(--SuMDWhite);";
                SlideDownCard.Attributes["style"] = "animation-duration:0s !important;width:100%; padding:0px !important;padding-top:8px !important;padding-bottom:8px !important; background-color:var(--SuMDWhite) !important;margin:0 auto !important; margin-top:0px !important;border-bottom-left-radius:20px;border-bottom-right-radius:20px;padding:0px !important;padding-bottom:12px !important;padding-top:8px !important;margin-bottom:22px !important;";
            }*/

        }
        protected void SavePreformanceSettingCookie(object sender, EventArgs e)
        {
            HttpCookie SetInfo = new HttpCookie("SuMPerformanceMode");
            SetInfo.Expires = DateTime.MaxValue;
            HttpContext.Current.Response.Cookies.Add(SetInfo);
        }
        protected void RemovePreformanceSettingCookie(object sender, EventArgs e)
        {
            HttpCookie SetInfo = new HttpCookie("SuMPerformanceMode");
            SetInfo.Expires = DateTime.Now.AddDays(-100);
            HttpContext.Current.Response.Cookies.Add(SetInfo);
        }
        protected void SaveSuMLockSettingCookie(object sender, EventArgs e)
        {
            HttpCookie SetInfo = new HttpCookie("SuMLockMode");
            SetInfo.Expires = DateTime.MaxValue;
            HttpContext.Current.Response.Cookies.Add(SetInfo);
        }
        protected void RemoveSuMLockSettingCookie(object sender, EventArgs e)
        {
            HttpCookie SetInfo = new HttpCookie("SuMLockMode");
            SetInfo.Expires = DateTime.Now.AddDays(-100);
            HttpContext.Current.Response.Cookies.Add(SetInfo);
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
        protected string[] SIDsToStringArray(string SIDs)
        {
            Queue<string> R1 = new Queue<string>();
            bool fh = false;
            string A1 = "";
            char[] aa = SIDs.ToCharArray();
            for (int i = 0; i < aa.Length; i++)
            {
                if (aa[i] == '@')
                {
                    A1 += "@";
                    fh = false;
                    R1.Enqueue(A1);
                    A1 = "";
                }
                if (aa[i] == '#') { fh = true; }
                if (fh == true)
                {
                    A1 += aa[i].ToString();
                }
            }
            string[] RS = new string[R1.Count];
            while (R1.Count > 0)
            {
                RS[R1.Count - 1] = R1.Dequeue();
            }
            return RS;
        }
        public void NULL(object sender, EventArgs e) { }
        protected void LogOut(object sender, EventArgs e)
        {
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            string CurrSID = GetUserInfoCookie["SID"].ToString();
            int CurrUID = Convert.ToInt32(GetUserInfoCookie["ID"].ToString());
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string query = "SELECT SIDs FROM SuMUsersAccounts WHERE UserID = @UID ";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@UID", SqlDbType.Int);
                sqlCmd.Parameters["@UID"].Value = CurrUID;
                var Res = sqlCmd.ExecuteScalar();
                if (Res != null)
                {
                    string NewSIDsSQLString = RemoveAnSIDfromSIDsString(Res.ToString(), CurrSID);
                    query = "UPDATE SuMUsersAccounts SET SIDs = @NewSIDs WHERE UserID = @UID";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@UID", SqlDbType.Int);
                    sqlCmd.Parameters["@UID"].Value = CurrUID;
                    sqlCmd.Parameters.AddWithValue("@NewSIDs", NewSIDsSQLString);
                    sqlCmd.ExecuteNonQuery();
                    //DebugSettings.InnerText = "RemoveTarget:" + CurrSID + " Result:" + NewSIDsSQLString;
                }
                sqlCon.Close();
            }
            ForceLogOut();
            ReloadAndUpdate();
        }
        protected string RemoveAnSIDfromSIDsString(string SIDs, string SIDToRemove)
        {
            string[] SQLCurrSIDs = SIDsToStringArray(SIDs);
            string Result = "";
            for (int i = 0; i < SQLCurrSIDs.Length; i++) 
            {
                if (SQLCurrSIDs[i] != SIDToRemove) 
                {
                    Result += SQLCurrSIDs[i];
                }
            }
            return Result;
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
        // UserSettingsStart     -imported from SuMAccount.aspx.cs-
        public string currSignetsure = string.Empty;
        public string currEmail = string.Empty;
        protected void ChangePFP(object sender, EventArgs e)
        {
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            string UserID = GetUserInfoCookie["ID"].ToString();
            string UserName = GetUserInfoCookie["UserName"].ToString();
            if (SuMCustomPFP.HasFile == true)
            {
                string oldimg = PFP.Attributes["src"].ToString();
                char[] fixing = oldimg.ToCharArray();
                string OrPATH = string.Empty;
                for (int i = 0; i < fixing.Length; i++)
                {
                    if (fixing[i] == '/')
                    {
                        if (string.IsNullOrEmpty(OrPATH) == true) { OrPATH = "\\"; }
                        else { OrPATH += "\\"; }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(OrPATH) == true) { OrPATH = fixing[i].ToString(); }
                        else { OrPATH += fixing[i].ToString(); }
                    }
                }
                bool fixer = File.Exists(Server.MapPath(OrPATH));
                bool Deafult = PFPIsNotADeafult(oldimg);
                if (fixer == true && Deafult == false) { File.Delete(Server.MapPath(OrPATH)); }
                string fileName = System.IO.Path.GetFileName(SuMCustomPFP.PostedFile.FileName);
                string ffn = DateTime.Now.ToString("yyyyMMddHHmmss") + UserName + fileName;
                SuMCustomPFP.PostedFile.SaveAs(Server.MapPath(Path.Combine("UsersUploads", ffn)));
                string pfppath = "/AccountETC/UsersUploads/" + ffn;
                using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    sqlCon.Open();
                    string query = "UPDATE SuMUsersAccounts SET PFP = @SuMCustomPFP WHERE UserID = @ID";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@ID", SqlDbType.Int);
                    sqlCmd.Parameters["@ID"].Value = Convert.ToInt32(UserID);
                    sqlCmd.Parameters.AddWithValue("@SuMCustomPFP", pfppath);
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                }
                ReloadAndUpdate();
            }
        }
        protected void ChangeUserBanner(object sender, EventArgs e)
        {
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            string UserID = GetUserInfoCookie["ID"].ToString();
            string UserName = GetUserInfoCookie["UserName"].ToString();
            if (SuMCustomBanner.HasFile == true)
            {
                string oldimg = CurrUserBannerPlaceHolder.InnerText.ToString();
                char[] fixing = oldimg.ToCharArray();
                string OrPATH = string.Empty;
                for (int i = 0; i < fixing.Length; i++)
                {
                    if (fixing[i] == '/')
                    {
                        if (string.IsNullOrEmpty(OrPATH) == true) { OrPATH = "\\"; }
                        else { OrPATH += "\\"; }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(OrPATH) == true) { OrPATH = fixing[i].ToString(); }
                        else { OrPATH += fixing[i].ToString(); }
                    }
                }
                bool fixer = File.Exists(Server.MapPath(OrPATH));
                //bool Deafult = PFPIsNotADeafult(oldimg);
                if (fixer == true && OrPATH.Contains(".svg") == false) { File.Delete(Server.MapPath(OrPATH)); }
                string fileName = System.IO.Path.GetFileName(SuMCustomBanner.PostedFile.FileName);
                string ffn = DateTime.Now.ToString("yyyyMMddHHmmss") + UserName + fileName;
                SuMCustomBanner.PostedFile.SaveAs(Server.MapPath(Path.Combine("UsersUploads", ffn)));
                string pfppath = "/AccountETC/UsersUploads/" + ffn;
                //New User Theme
                Bitmap PicBitMap = new Bitmap(SuMCustomBanner.PostedFile.InputStream);
                string BannerThemeColorRGBRoot = RgbConverter(getDominantColor(PicBitMap));
                SaveUserThemeCookie(BannerThemeColorRGBRoot);
                using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    sqlCon.Open();
                    string query = "UPDATE SuMUsersAccounts SET UserBanner = @SuMCustomPFP WHERE UserID = @ID";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@ID", SqlDbType.Int);
                    sqlCmd.Parameters["@ID"].Value = Convert.ToInt32(UserID);
                    sqlCmd.Parameters.AddWithValue("@SuMCustomPFP", pfppath);
                    sqlCmd.ExecuteNonQuery();
                    query = "UPDATE SuMUsersAccounts SET UserTheme = @SuMUserColor WHERE UserID = @ID";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@ID", SqlDbType.Int);
                    sqlCmd.Parameters["@ID"].Value = Convert.ToInt32(UserID);
                    sqlCmd.Parameters.AddWithValue("@SuMUserColor", BannerThemeColorRGBRoot);
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                }
                ReloadAndUpdate();
            }
        }
        protected static void SaveUserThemeCookie(string RGBRootString)
        {
            HttpCookie userInfo = new HttpCookie("SuMUserThemeColor");
            userInfo["RGBRoot"] = RGBRootString;
            userInfo.Expires = DateTime.MaxValue;
            HttpContext.Current.Response.Cookies.Add(userInfo);
        }
        protected Color getDominantColor(Bitmap bmp)
        {
            //Used for tally
            int r = 0;
            int g = 0;
            int b = 0;

            int total = 0;

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color clr = bmp.GetPixel(x, y);

                    r += clr.R;
                    g += clr.G;
                    b += clr.B;

                    total++;
                }
            }

            //Calculate average
            r /= total;
            g /= total;
            b /= total;

            return Color.FromArgb(r, g, b);
        }
        protected static string RgbConverter(Color c)
        {
            return String.Format("{0},{1},{2}", c.R, c.G, c.B);
        }
        protected void ChangeSIG(object sender, EventArgs e)
        {
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            string UserID = GetUserInfoCookie["ID"].ToString();
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string newSignetsure = SignaturePE.Value.ToString();
                if (newSignetsure != currSignetsure && newSignetsure != null && newSignetsure != "" && newSignetsure != " ")
                {
                    string query = "UPDATE SuMUsersAccounts SET Signetsure = @Signetsure WHERE UserID = @ID";
                    SqlCommand sqlCmd2 = new SqlCommand(query, sqlCon);
                    sqlCmd2.Parameters.AddWithValue("@ID", SqlDbType.Int);
                    sqlCmd2.Parameters["@ID"].Value = Convert.ToInt32(UserID);
                    sqlCmd2.Parameters.AddWithValue("@Signetsure", newSignetsure);
                    sqlCmd2.ExecuteNonQuery();
                }
                sqlCon.Close();
            }
            ReloadAndUpdate();
        }
        protected void ChangeEmail(object sender, EventArgs e)
        {
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            string UserID = GetUserInfoCookie["ID"].ToString();
            string Email = EmailEP.Value.ToString();

            if (currEmail != Email)
            {
                using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    string query = "UPDATE SuMUsersAccounts SET Email = @Email WHERE UserID = @ID";
                    SqlCommand sqlCmd2 = new SqlCommand(query, sqlCon);
                    sqlCmd2.Parameters.AddWithValue("@ID", SqlDbType.Int);
                    sqlCmd2.Parameters["@ID"].Value = Convert.ToInt32(UserID);
                    sqlCmd2.Parameters.AddWithValue("@Email", Email);
                    sqlCmd2.ExecuteNonQuery();
                    sqlCon.Close();
                }
                ReloadAndUpdate();
            }
        }
        protected void LastRefreshPross()
        {
            HttpCookie GetRefreshInfoCookie = Request.Cookies["SuMMangaRefreshProssSettings"];
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
                            if ((CurrHour - Hour) > 8)
                            {
                                HttpCookie UpdateInfo = new HttpCookie("SuMMangaRefreshProssSettings");
                                UpdateInfo["LatestUpdatedYear"] = DateTime.UtcNow.ToString("yyyy");
                                UpdateInfo["LatestUpdatedMonth"] = DateTime.UtcNow.ToString("MM");
                                UpdateInfo["LatestUpdatedDay"] = DateTime.UtcNow.ToString("dd");
                                UpdateInfo["LatestUpdatedHour"] = DateTime.UtcNow.ToString("HH");
                                UpdateInfo.Expires = DateTime.MaxValue;
                                HttpContext.Current.Response.Cookies.Add(UpdateInfo);
                                ReloadAndUpdate();
                            }
                        }
                        else
                        {
                            HttpCookie UpdateInfo = new HttpCookie("SuMMangaRefreshProssSettings");
                            UpdateInfo["LatestUpdatedYear"] = DateTime.UtcNow.ToString("yyyy");
                            UpdateInfo["LatestUpdatedMonth"] = DateTime.UtcNow.ToString("MM");
                            UpdateInfo["LatestUpdatedDay"] = DateTime.UtcNow.ToString("dd");
                            UpdateInfo["LatestUpdatedHour"] = DateTime.UtcNow.ToString("HH");
                            UpdateInfo.Expires = DateTime.MaxValue;
                            HttpContext.Current.Response.Cookies.Add(UpdateInfo);
                            ReloadAndUpdate();
                        }
                    }
                    else
                    {
                        HttpCookie UpdateInfo = new HttpCookie("SuMMangaRefreshProssSettings");
                        UpdateInfo["LatestUpdatedYear"] = DateTime.UtcNow.ToString("yyyy");
                        UpdateInfo["LatestUpdatedMonth"] = DateTime.UtcNow.ToString("MM");
                        UpdateInfo["LatestUpdatedDay"] = DateTime.UtcNow.ToString("dd");
                        UpdateInfo["LatestUpdatedHour"] = DateTime.UtcNow.ToString("HH");
                        UpdateInfo.Expires = DateTime.MaxValue;
                        HttpContext.Current.Response.Cookies.Add(UpdateInfo);
                        ReloadAndUpdate();
                    }
                }
                else
                {
                    HttpCookie UpdateInfo = new HttpCookie("SuMMangaRefreshProssSettings");
                    UpdateInfo["LatestUpdatedYear"] = DateTime.UtcNow.ToString("yyyy");
                    UpdateInfo["LatestUpdatedMonth"] = DateTime.UtcNow.ToString("MM");
                    UpdateInfo["LatestUpdatedDay"] = DateTime.UtcNow.ToString("dd");
                    UpdateInfo["LatestUpdatedHour"] = DateTime.UtcNow.ToString("HH");
                    UpdateInfo.Expires = DateTime.MaxValue;
                    HttpContext.Current.Response.Cookies.Add(UpdateInfo);
                    ReloadAndUpdate();
                }
            }
            else
            {
                HttpCookie UpdateInfo = new HttpCookie("SuMMangaRefreshProssSettings");
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
        protected string RandomQuryForUpdate()
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
        protected string SuMRandomPFP()
        {
            string PFP = string.Empty;
            Random random = new Random();
            int index = random.Next(1, 14);
            PFP = "/AccountETC/DeafultPFP/" + index.ToString() + ".jpg";
            return PFP;
        }
        protected bool PFPIsNotADeafult(string PFP) 
        {
            bool Deafult = false;
            for (int i = 1; i < 15; i++) 
            {
                if (PFP == "/AccountETC/DeafultPFP/" + i.ToString() + ".jpg") { Deafult = true; }
            }
            return Deafult;
        }
        protected void ChangePFPAtRandom(object sender, EventArgs e)
        {
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            string UserID = GetUserInfoCookie["ID"].ToString();
            string oldimg = PFP.Attributes["src"].ToString();
            char[] fixing = oldimg.ToCharArray();
            string OrPATH = string.Empty;
            for (int i = 0; i < fixing.Length; i++)
            {
                if (fixing[i] == '/')
                {
                    if (string.IsNullOrEmpty(OrPATH) == true) { OrPATH = "\\"; }
                    else { OrPATH += "\\"; }
                }
                else
                {
                    if (string.IsNullOrEmpty(OrPATH) == true) { OrPATH = fixing[i].ToString(); }
                    else { OrPATH += fixing[i].ToString(); }
                }
            }
            bool fixer = File.Exists(Server.MapPath(OrPATH));
            bool Deafult = PFPIsNotADeafult(oldimg);
            if (fixer == true && Deafult == false) { File.Delete(Server.MapPath(OrPATH)); }
            string pfppath = SuMRandomPFP();
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string query = "UPDATE SuMUsersAccounts SET PFP = @SuMCustomPFP WHERE UserID = @ID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@ID", SqlDbType.Int);
                sqlCmd.Parameters["@ID"].Value = Convert.ToString(UserID);
                sqlCmd.Parameters.AddWithValue("@SuMCustomPFP", pfppath);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            ReloadAndUpdate();
        }
        protected void RemoveBanner(object sender, EventArgs e)
        {
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            string UserID = GetUserInfoCookie["ID"].ToString();
            string oldimg = CurrUserBannerPlaceHolder.InnerText.ToString();
            char[] fixing = oldimg.ToCharArray();
            string OrPATH = string.Empty;
            for (int i = 0; i < fixing.Length; i++)
            {
                if (fixing[i] == '/')
                {
                    if (string.IsNullOrEmpty(OrPATH) == true) { OrPATH = "\\"; }
                    else { OrPATH += "\\"; }
                }
                else
                {
                    if (string.IsNullOrEmpty(OrPATH) == true) { OrPATH = fixing[i].ToString(); }
                    else { OrPATH += fixing[i].ToString(); }
                }
            }
            bool fixer = File.Exists(Server.MapPath(OrPATH));
            if (fixer == true&& OrPATH.Contains(".svg") == false) { File.Delete(Server.MapPath(OrPATH)); }
            string pfppath = string.Empty;
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string query = "UPDATE SuMUsersAccounts SET UserBanner = @SuMCustomPFP WHERE UserID = @ID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@ID", SqlDbType.Int);
                sqlCmd.Parameters["@ID"].Value = Convert.ToString(UserID);
                sqlCmd.Parameters.AddWithValue("@SuMCustomPFP", pfppath);
                sqlCmd.ExecuteNonQuery();
                query = "UPDATE SuMUsersAccounts SET UserBanner = NULL WHERE UserID = @ID";
                sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@ID", SqlDbType.Int);
                sqlCmd.Parameters["@ID"].Value = Convert.ToString(UserID);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            HttpCookie userInfo = new HttpCookie("SuMUserThemeColor");
            userInfo.Expires = DateTime.Now.AddDays(-100);
            HttpContext.Current.Response.Cookies.Add(userInfo);
            ReloadAndUpdate();
        }
    }
}