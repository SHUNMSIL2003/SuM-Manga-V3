using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Configuration;
using System.Web.Security;
using System.Net.Mail;
using System.IO;

namespace SuM_Manga_V3.AccountETC
{
    public partial class LoginETC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            if (GetUserInfoCookie != null)
            {
                //MPB.InnerText = "Explore";
                //MPB.Attributes["href"] = "Library.aspx";
                Response.Redirect("~/AccountETC/SettingsAccountCard.aspx");
            }
            else
            {
                ResendConf.Visible = false;
                LoginStatus.InnerText = "";
                UserNameL.Attributes["style"] = "border-radius:14px;";
                PasswordL.Attributes["style"] = "border-radius:14px;";
            }
        }
        protected void LoginToSuM(object sender, EventArgs e)
        {
            LoginStatus.InnerText = "";
            LogInProssInfo.Attributes["style"] = "display:none;";
            string statevalid = "";
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string query = "SELECT UserID FROM SuMUsersAccounts WHERE UserName = @UserName AND Password = @Password ";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                string username = UserNameL.Value.ToString().Replace(" ", ""); //Request.QueryString["UserNameL"].ToString();
                sqlCmd.Parameters.AddWithValue("@UserName", username);
                string password = PasswordL.Value; //Request.QueryString["PasswordL"].ToString();
                sqlCmd.Parameters.AddWithValue("@Password", sha256(password));
                var Res = sqlCmd.ExecuteScalar();
                if (Res != null)
                {
                    int ID = Convert.ToInt32(Res.ToString());
                    //New -s
                    string queryRGB = "SELECT UserTheme FROM SuMUsersAccounts WHERE UserID = @UserID";
                    SqlCommand sqlCmdRGB = new SqlCommand(queryRGB, sqlCon);
                    sqlCmdRGB.Parameters.AddWithValue("@UserID", SqlDbType.Int);
                    sqlCmdRGB.Parameters["@UserID"].Value = ID;
                    object RGBRS = sqlCmdRGB.ExecuteScalar();
                    if (RGBRS != null) 
                    {
                        SaveUserThemeCookie(RGBRS.ToString());
                    }
                    //New -e
                    string query2 = "SELECT AccountStatus FROM SuMUsersAccounts WHERE UserID = @UserID";
                    SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);
                    sqlCmd2.Parameters.AddWithValue("@UserID", SqlDbType.Int);
                    sqlCmd2.Parameters["@UserID"].Value = ID;
                    using (SqlDataReader dr = sqlCmd2.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            statevalid = dr[0].ToString();
                        }
                    }
                    if (statevalid.Contains("#R") == true)//statevalid[0] == '#' && statevalid[1] == 'R'&&
                    {
                        LoginStatus.InnerText = "You need to Complete SuM Account registration! You will find a link in you email-inbox.";
                        LogInProssInfo.Attributes["style"] = "background-color:rgba(255,124,107,0.16);width:100%;text-align:center;padding:0px;height:fit-content;border-radius:14px;display:block;";
                        ResendConf.Visible = true;
                    }
                    else
                    {
                        string qwi = "SELECT SIDs FROM SuMUsersAccounts WHERE UserID = @UID";
                        sqlCmd = new SqlCommand(qwi, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@UID", SqlDbType.Int);
                        sqlCmd.Parameters["@UID"].Value = ID;
                        var CMDRs = sqlCmd.ExecuteScalar();
                        if (CMDRs != null)
                        {

                            if (SIDsCountLessThanX(CMDRs.ToString(), 3) == true)
                            {
                                string qc = "SELECT Creator FROM SuMUsersAccounts WHERE UserID = @UID";
                                SqlCommand cv = new SqlCommand(qc, sqlCon);
                                cv.Parameters.AddWithValue("@UID", SqlDbType.Int);
                                cv.Parameters["@UID"].Value = ID;
                                bool ituac = false;
                                using (var reader = cv.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        if (reader != null)
                                        {
                                            ituac = reader.GetBoolean(0);
                                        }
                                    }
                                }
                                string GSID = GetNewSID(username);
                                qc = "UPDATE SuMUsersAccounts SET SIDs = @NSID WHERE UserID = @UID";
                                cv = new SqlCommand(qc, sqlCon);
                                cv.Parameters.AddWithValue("@UID", SqlDbType.Int);
                                cv.Parameters["@UID"].Value = ID;
                                cv.Parameters.AddWithValue("@NSID", CMDRs.ToString() + GSID);
                                cv.ExecuteNonQuery();
                                if (ituac == false)
                                {
                                    SaveCookie(username, ID, GSID);
                                    sqlCon.Close();
                                    HttpContext.Current.Response.Redirect("~/AccountETC/SettingsAccountCard.aspx");
                                }
                                else
                                {
                                    qc = "SELECT CreatorName FROM SuMCreators WHERE CreatorID = @CreatorID";
                                    cv = new SqlCommand(qc, sqlCon);
                                    cv.Parameters.AddWithValue("@CreatorID", SqlDbType.Int);
                                    cv.Parameters["@CreatorID"].Value = ID;
                                    string CreatorIDName = cv.ExecuteScalar().ToString();
                                    SaveSCCookie(username, ID, CreatorIDName, GSID);
                                    sqlCon.Close();
                                    HttpContext.Current.Response.Redirect("~/AccountETC/SettingsAccountCard.aspx");
                                }
                            }
                            else
                            {
                                HttpCookie CacheUserInfo = new HttpCookie("SuMCurrentLoginWorkerCache");
                                CacheUserInfo["ID"] = ID.ToString();
                                CacheUserInfo.Expires = DateTime.Now.AddMinutes(30);
                                HttpContext.Current.Response.Cookies.Add(CacheUserInfo);
                                LoginStatus.InnerText = "You can login to a maximum of three devices!";
                                LogInProssInfo.Attributes["style"] = "background-color:rgba(255,124,107,0.16);width:100%;text-align:center;padding:0px;height:fit-content;border-radius:14px;display:block;";
                                LogOutOffAllBTN.Visible = true;
                            }
                        }
                        else
                        {
                            string qc = "SELECT Creator FROM SuMUsersAccounts WHERE UserID = @UID";
                            SqlCommand cv = new SqlCommand(qc, sqlCon);
                            cv.Parameters.AddWithValue("@UID", SqlDbType.Int);
                            cv.Parameters["@UID"].Value = ID;
                            bool ituac = false;
                            using (var reader = cv.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    if (reader != null)
                                    {
                                        ituac = reader.GetBoolean(0);
                                    }
                                }
                            }
                            string GSID = GetNewSID(username);
                            qc = "UPDATE SuMUsersAccounts SET SIDs = @NSID WHERE UserID = @UID";
                            cv = new SqlCommand(qc, sqlCon);
                            cv.Parameters.AddWithValue("@UID", SqlDbType.Int);
                            cv.Parameters["@UID"].Value = ID;
                            cv.Parameters.AddWithValue("@NSID", CMDRs.ToString() + GSID);
                            cv.ExecuteNonQuery();
                            if (ituac == false)
                            {
                                SaveCookie(username, ID, GSID);
                                sqlCon.Close();
                                HttpContext.Current.Response.Redirect("~/AccountETC/SettingsAccountCard.aspx");
                            }
                            else
                            {
                                qc = "SELECT CreatorName FROM SuMCreators WHERE CreatorID = @CreatorID";
                                cv = new SqlCommand(qc, sqlCon);
                                cv.Parameters.AddWithValue("@CreatorID", SqlDbType.Int);
                                cv.Parameters["@CreatorID"].Value = ID;
                                string CreatorIDName = cv.ExecuteScalar().ToString();
                                SaveSCCookie(username, ID, CreatorIDName, GSID);
                                sqlCon.Close();
                                HttpContext.Current.Response.Redirect("~/AccountETC/SettingsAccountCard.aspx");
                            }
                        }
                    }
                }
                else
                {
                    UserNameL.Attributes["style"] = "border: solid 2px rgb(255,90,69);border-radius:14px;";
                    PasswordL.Attributes["style"] = "border: solid 2px rgb(255,90,69);border-radius:14px;";
                    LoginStatus.InnerText = "Username Or Password are incurrect!";
                    LogInProssInfo.Attributes["style"] = "background-color:rgba(255,124,107,0.16);width:100%;text-align:center;padding:0px;height:fit-content;border-radius:14px;display:block;";
                    sqlCon.Close();
                }
                sqlCon.Close();
            }
        }
        protected void LogOutOffAll(object sender, EventArgs e)
        {
            HttpCookie GetLoginCacheUserInfo = Request.Cookies["SuMCurrentLoginWorkerCache"];
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string query = "UPDATE SuMUsersAccounts SET SIDs = NULL WHERE UserID = @UID";
                SqlCommand sqlCmd2 = new SqlCommand(query, sqlCon);
                sqlCmd2.Parameters.AddWithValue("@UID", System.Data.SqlDbType.Int);
                sqlCmd2.Parameters["@UID"].Value = Convert.ToInt32(GetLoginCacheUserInfo["ID"].ToString());
                sqlCmd2.ExecuteNonQuery();
                sqlCon.Close();
            }
            Response.Redirect("~/AccountETC/LoginETC.aspx");
        }
        static string sha256(string randomString)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
        protected static void SaveCookie(string UserName, int ID, string SessionID)
        {
            HttpCookie userInfo = new HttpCookie("SuMCurrentUser");
            userInfo["UserName"] = UserName;
            userInfo["ID"] = ID.ToString();
            userInfo["SID"] = SessionID;
            userInfo.Expires = DateTime.MaxValue;
            HttpContext.Current.Response.Cookies.Add(userInfo);
            HttpContext.Current.Response.Redirect("~/AccountETC/SettingsAccountCard.aspx");
        }
        protected static void SaveSCCookie(string UserName, int ID, string CreatorName, string SessionID)
        {
            HttpCookie userInfo = new HttpCookie("SuMCurrentUser");
            userInfo["UserName"] = UserName;
            userInfo["CreatorName"] = CreatorName;
            userInfo["SID"] = SessionID;
            userInfo["ID"] = ID.ToString();
            userInfo.Expires = DateTime.MaxValue;
            HttpContext.Current.Response.Cookies.Add(userInfo);
            HttpContext.Current.Response.Redirect("~/AccountETC/SettingsAccountCard.aspx");
        }
        protected static void SaveUserThemeCookie(string RGBRootString)
        {
            HttpCookie userInfo = new HttpCookie("SuMUserThemeColor");
            userInfo["RGBRoot"] = RGBRootString;
            userInfo.Expires = DateTime.MaxValue;
            HttpContext.Current.Response.Cookies.Add(userInfo);
        }
        protected void ResendConfLink(object sender, EventArgs e)
        {
            string virivicationcode = GetVerificationCode(8);
            string accountstats = "#R$" + virivicationcode;
            string UserName = UserNameL.Value.ToString();
            string Email = string.Empty;
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string query = "UPDATE SuMUsersAccounts SET AccountStatus = @AccountStatus WHERE UserName = @UserName";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                //HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
                sqlCmd.Parameters.AddWithValue("@UserName", UserName);
                sqlCmd.Parameters.AddWithValue("@AccountStatus", accountstats);
                sqlCmd.ExecuteNonQuery();
                //sqlCmd.Parameters.AddWithValue("@SuMCustomPFP", SqlDbType.Image).Value = imgarray;

                string query4 = "SELECT Email FROM SuMUsersAccounts WHERE UserName = @UserName";
                SqlCommand sqlCmd4 = new SqlCommand(query4, sqlCon);
                //HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
                sqlCmd4.Parameters.AddWithValue("@UserName", UserName);
                using (SqlDataReader dr = sqlCmd4.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Email = dr[0].ToString();
                    }
                }
                sqlCon.Close();
            }
            SendVirifyEmail(virivicationcode, Email);

        }
        protected void SendVirifyEmail(string VCODE, string Email)
        {
            //Send Email
            string thelink = "https://sum-manga.azurewebsites.net/AccountETC/ValidateUsers.aspx?UserName=" + UserNameL.Value.ToString() + "&VCode=" + VCODE;
            string emailbody = MailTemplate(thelink);
            MailMessage Msg = new MailMessage();
            Msg.From = new MailAddress("sumverifysystem@gmail.com", "SuM System");// Sender details here, replace with valid value
            Msg.Subject = "Setup SuM Account!"; // subject of email
            string useremail = Email;
            Msg.To.Add(useremail); //Add Email id, to which we will send email
            Msg.Body = emailbody;
            Msg.IsBodyHtml = true;
            Msg.Priority = MailPriority.High;
            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false; // to get rid of error "SMTP server requires a secure connection"
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("sumverifysystem@gmail.com", "rxuclaczswvdhjpj");// replace with valid value
            smtp.EnableSsl = true;
            smtp.Timeout = 20000;
            smtp.Send(Msg);
        }
        protected string MailTemplate(string link)
        {
            StreamReader sr = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/AccountETC/Email.html"));
            string body = sr.ReadToEnd();
            sr.Close();
            string username = UserNameL.Value.ToString();
            body = body.Replace("#USERNAME#", username);
            body = body.Replace("#LINK#", link);
            return body;
        }
        protected static string GetVerificationCode(int length)
        {
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
            return str;
        }
        protected static string GetNewSID(string UserName)
        {
            int length = 6;
            char[] chArray = "abcd168efgh1ijklmnopqrst16uvwxyz122d34567890ABdCDEFGHI6J3KLMNOPQRST6UVWXYZ".ToCharArray();
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
            DateTime dateTime = DateTime.UtcNow.Date;
            str = "#" + str + "%" + UserName + "%" + dateTime.ToString("yyyyMMdd") + "@";
            return str;
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
        protected bool SIDsCountLessThanX(string SIDs, int MAX)
        {
            int HCount = SIDs.Count(f => (f == '#'));
            int CCount = SIDs.Count(f => (f == '@'));
            if (HCount == CCount)
            {
                if (CCount < MAX) { return true; }
                else { return false; }
            }
            else { return false; }
        }
        protected void LogInWithGoogle(object sender, EventArgs e)
        {

        }
    }
}
