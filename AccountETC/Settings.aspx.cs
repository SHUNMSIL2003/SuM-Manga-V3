using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace SuM_Manga_V3.AccountETC
{
    public partial class Settings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SussionPross();
            LastRefreshPross();
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            if (GetUserInfoCookie != null)
            {
                // -Debug Start-
                //RootDebug.InnerText = GetUserInfoCookie.Value;
                // -Debug End-
                AccountSettingsOrLogin.Attributes["onclick"] = "if (document.getElementById('UserSettingsCards').style.height == '0px') { document.getElementById('UserSettingsCards').style.height = '275px'; } else { document.getElementById('UserSettingsCards').style.height = '0px'; document.getElementById('PFPDiv').style.display = 'none'; document.getElementById('ChangeEmailDiv').style.display = 'none'; document.getElementById('SigAndMore').style.display = 'none'; document.getElementById('creatorsupmitform').style.display = 'none'; document.getElementById('MainContent_PaymentCard').style.display = 'none'; document.getElementById('ManageDevicesCard').style.display = 'none'; }"; //"if (document.getElementById('UserSettingsCards').style.height == '0px') { document.getElementById('UserSettingsCards').style.height = '232px'; } else { document.getElementById('UserSettingsCards').style.height = '0px'; }";
                //"document.getElementById('UserSettingsCards').style.display = (document.getElementById('UserSettingsCards').style.display == 'block') ? 'none' : 'block';";
                AccountSettingsOrLogin.Attributes["href"] = "#";
                string UserName = GetUserInfoCookie["UserName"].ToString();
                SuMUserName.InnerText = UserName;
                string CurrPFP = string.Empty;
                string currEmail = string.Empty;
                using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    sqlCon.Open();
                    string query = "SELECT PFP FROM SuMUsersAccounts WHERE UserName = @UserName";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@UserName", UserName);
                    using (SqlDataReader dr = sqlCmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            CurrPFP = dr[0].ToString();
                        }
                    }
                    string query4 = "SELECT Email FROM SuMUsersAccounts WHERE UserName = @UserName";
                    SqlCommand sqlCmd4 = new SqlCommand(query4, sqlCon);
                    sqlCmd4.Parameters.AddWithValue("@UserName", UserName);
                    using (SqlDataReader dr = sqlCmd4.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            currEmail = dr[0].ToString();
                        }
                    }
                    //Sig start
                    string query3 = "SELECT Signetsure FROM SuMUsersAccounts WHERE UserName = @UserName";
                    SqlCommand sqlCmd3 = new SqlCommand(query3, sqlCon);
                    sqlCmd3.Parameters.AddWithValue("@UserName", UserName);
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
                //Imported code from SuMAccount.aspx.cs + Sig from above
                SignaturePE.Attributes["placeholder"] = currSignetsure;
                UserNameEP.Attributes["placeholder"] = UserName;
                EmailEP.Attributes["placeholder"] = currEmail;
                PFPC.Attributes["src"] = ResolveUrl(CurrPFP);
            }
            else
            {
                LogOutBTN.Attributes["style"] = "display:none;";
                LogOutBTN.Attributes["OnClick"] = "NULL";
            }
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
            GetUserInfoCookie = new HttpCookie("SuMCurrentUser");
            GetUserInfoCookie.Expires = DateTime.Now.AddDays(-100);
            Response.Cookies.Add(GetUserInfoCookie);
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
            Response.Redirect("~/AccountETC/LogInETC.aspx");
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
        }
        // UserSettingsStart     -imported from SuMAccount.aspx.cs-
        public string currSignetsure = string.Empty;
        public string currEmail = string.Empty;
        protected void ChangePFP(object sender, EventArgs e)
        {
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
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
                bool Fix5 = OrPATH.Contains("DeafultPFP.jpg");
                if (fixer == true && Fix5 == false) { File.Delete(Server.MapPath(OrPATH)); }
                string fileName = System.IO.Path.GetFileName(SuMCustomPFP.PostedFile.FileName);
                string ffn = DateTime.Now.ToString("yyyyMMddHHmmss") + UserName + fileName;
                SuMCustomPFP.PostedFile.SaveAs(Server.MapPath(Path.Combine("UsersUploads", ffn)));
                string pfppath = "/AccountETC/UsersUploads/" + ffn;
                using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    sqlCon.Open();
                    string query = "UPDATE SuMUsersAccounts SET PFP = @SuMCustomPFP WHERE UserName = @UserName";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@UserName", UserName);
                    sqlCmd.Parameters.AddWithValue("@SuMCustomPFP", pfppath);
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                }
            }
        }
        protected void ChangeSIG(object sender, EventArgs e)
        {
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            string UserName = GetUserInfoCookie["UserName"].ToString();
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string newSignetsure = SignaturePE.Value.ToString();
                if (newSignetsure != currSignetsure && newSignetsure != null && newSignetsure != "" && newSignetsure != " ")
                {
                    string query = "UPDATE SuMUsersAccounts SET Signetsure = @Signetsure WHERE UserName = @UserName";
                    SqlCommand sqlCmd2 = new SqlCommand(query, sqlCon);
                    sqlCmd2.Parameters.AddWithValue("@UserName", UserName);
                    sqlCmd2.Parameters.AddWithValue("@Signetsure", newSignetsure);
                    sqlCmd2.ExecuteNonQuery();
                }
                sqlCon.Close();
            }
        }
        protected void ChangeEmail(object sender, EventArgs e)
        {
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            string UserName = GetUserInfoCookie["UserName"].ToString();
            string Email = EmailEP.Value.ToString();

            if (currEmail != Email)
            {
                using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    string query = "UPDATE SuMUsersAccounts SET Email = @Email WHERE UserName = @UserName";
                    SqlCommand sqlCmd2 = new SqlCommand(query, sqlCon);
                    sqlCmd2.Parameters.AddWithValue("@UserName", UserName);
                    sqlCmd2.Parameters.AddWithValue("@Email", Email);
                    sqlCmd2.ExecuteNonQuery();
                    sqlCon.Close();
                }
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
                            if ((CurrHour - Hour) > 8) { ReloadAndUpdate(); }
                        }
                        else { ReloadAndUpdate(); }
                    }
                    else { ReloadAndUpdate(); }
                }
                else { ReloadAndUpdate(); }
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