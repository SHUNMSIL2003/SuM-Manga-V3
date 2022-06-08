using System;
using System.Web;
using System.Text;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Net.Mail;
using System.IO;
 

namespace SuM_Manga_V3.AccountETC
{
    public partial class PassRecovryETC : System.Web.UI.Page
    {
        //protected string ConfCode = string.Empty;
        //protected string emailre = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            if (GetUserInfoCookie != null)
            {
                //MPB.InnerText = "Explore";
                //MPB.Attributes["href"] = "Library.aspx";
                Response.Redirect("~/Explore.aspx");
            }
        }
        protected void PassResetStart(object sender, EventArgs e) 
        {
            errormsg.InnerText = "";
            //emailre = EmailF.Value.ToString();
            string email = EmailF.Value.ToString();
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string query = "SELECT UserName FROM SuMUsersAccounts WHERE Email = @Email";
                MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
                MySqlCmd.Parameters.AddWithValue("@Email", email);
                var smth = MySqlCmd.ExecuteScalar();
                //string username = smth.ToString();
                if (smth != null)
                {
                    string username = smth.ToString();
                    string vc21520 = GetVerificationCode(8);
                    //debug454540d2.InnerText = vc21520;
                    //ConfCode = vc21520;
                    //debug454540d2.InnerText += "SV " + ConfCode + " Ok?";
                    HttpCookie sd654fgsd65d5 = new HttpCookie("sd654fgsd65d5", EmailF.Value.ToString());
                    sd654fgsd65d5.Expires.AddMinutes(5);
                    HttpContext.Current.Response.Cookies.Add(sd654fgsd65d5);
                    HttpCookie dfjgh2512021dsaf = new HttpCookie("dfjgh2512021dsaf", sha256(vc21520));
                    dfjgh2512021dsaf.Expires.AddMinutes(5);
                    HttpContext.Current.Response.Cookies.Add(dfjgh2512021dsaf);
                    SendVirifyEmail(vc21520, username);
                    //emailre = EmailF.Value.ToString();
                    EmailF.Attributes["style"] = "display:none;";
                    //PasswordRes.Attributes["style"] = "";
                    //PasswordResC.Attributes["style"] = "";
                    VCODECONF.Attributes["style"] = "";
                    BtnP.Visible = false;
                    BtnC.Visible = true;
                    BtnS.Visible = false;
                    SuMRP.InnerText = "Type in the code send to your email";
                    SuMRP.Attributes["style"] = "";
                    //BtnP.Attributes["OnClick"] = "ConfAndSavePass";
                }
                else
                {
                    EmailF.Attributes["style"] = "border-color:red;border-width:2px;border-radius:14px;";
                    errormsg.InnerText = "Email doesn't match any user";
                }
                MySqlCon.Close();
            }
        }
        protected void ConfirmCode(object sender, EventArgs e)
        {
            //debug454540d2.InnerText += "SV " + ConfCode + " Ok?";
            if (Request.Cookies["dfjgh2512021dsaf"] != null)
            {
                string ConfCode = Request.Cookies["dfjgh2512021dsaf"].Value.ToString();
                if (VCODECONF.Value != null)
                {
                    string enteredConfCode = sha256(VCODECONF.Value.ToString());
                    if (enteredConfCode == ConfCode)
                    {
                        BtnP.Visible = false;
                        BtnC.Visible = false;
                        BtnS.Visible = true;
                        SuMRP.Attributes["style"] = "display:none;";
                        VCODECONF.Attributes["style"] = "display:none;";
                        EmailF.Attributes["style"] = "display:none;";
                        PasswordRes.Attributes["style"] = "";
                        PasswordResC.Attributes["style"] = "";
                    }
                    else
                    {
                        SuMRP.InnerText = "Code is invalid! Plz make sure you have typed it currectly";
                    }
                }
                else { SuMRP.InnerText = "Enter the Code plz"; }
            }
            else { SuMRP.InnerText = "Code Expired! Plz try again later"; }
        }
        protected void SaveNewPass(object sender, EventArgs e)
        {
            //debug454540d2.InnerText += "SV " + ConfCode + " Ok?";
            PasswordRes.Attributes["style"] = "";
            PasswordResC.Attributes["style"] = "";
            SuMRP.InnerText = "";
            if (PasswordRes.Value == PasswordResC.Value && PasswordRes.Value != null)
            {
                string newPass = PasswordRes.Value.ToString();
                if (PasswordIsOk(newPass) == true)
                {
                    string emailre = Request.Cookies["sd654fgsd65d5"].Value.ToString();
                    string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
                    {
                        MySqlCon.Open();
                        string query = "UPDATE SuMUsersAccounts SET Password = @Password WHERE Email = @Email";
                        MySqlCommand MySqlCmd2 = new MySqlCommand(query, MySqlCon);
                        MySqlCmd2.Parameters.AddWithValue("@Email", emailre);
                        MySqlCmd2.Parameters.AddWithValue("@Password", sha256(newPass));
                        MySqlCmd2.ExecuteNonQuery();
                        //LogOutPartStart
                        query = "SELECT UserID FROM SuMUsersAccounts WHERE Email = @Email";
                        MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
                        MySqlCmd.Parameters.AddWithValue("@Email", emailre);
                        HttpCookie CacheUserInfo = new HttpCookie("SuMCurrentLoginWorkerCache");
                        CacheUserInfo["ID"] = MySqlCmd.ExecuteScalar().ToString();
                        CacheUserInfo.Expires = DateTime.Now.AddMinutes(30);
                        HttpContext.Current.Response.Cookies.Add(CacheUserInfo);
                        MySqlCon.Close();
                    }
                    LogOutOffAll();
                    Response.Redirect("~/AccountETC/LoginETC.aspx");
                }
                else { SuMRP.InnerText = "Password Must Contain atleast 8 numbers and 4 more latters/charecter !"; }
            }
            else 
            {
                SuMRP.InnerText = "Passwords do not match or they are empty!";
                PasswordRes.Attributes["style"] = "border: solid 2px red;border-radius:14px;";
                PasswordResC.Attributes["style"] = "border: solid 2px red;border-radius:14px;";
            }
        }
        protected void LogOutOffAll()
        {
            HttpCookie GetLoginCacheUserInfo = Request.Cookies["SuMCurrentLoginWorkerCache"];
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string query = "UPDATE SuMUsersAccounts SET SIDs = NULL WHERE UserID = @UID";
                MySqlCommand MySqlCmd2 = new MySqlCommand(query, MySqlCon);
                MySqlCmd2.Parameters.AddWithValue("@UID", System.Data.SqlDbType.Int);
                MySqlCmd2.Parameters["@UID"].Value = Convert.ToInt32(GetLoginCacheUserInfo["ID"].ToString());
                MySqlCmd2.ExecuteNonQuery();
                MySqlCon.Close();
            }
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
        protected string MailTemplate(string VC,string username)
        {
            StreamReader sr = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/AccountETC/EmailPassword.html"));
            string body = sr.ReadToEnd();
            sr.Close();
            body = body.Replace("#USERNAME#", username);
            body = body.Replace("#VC#", VC);
            return body;
        }
        protected void SendVirifyEmail(string VCODE,string USERNAME)
        {
            //Send Email
            string emailbody = MailTemplate(VCODE,USERNAME);
            MailMessage Msg = new MailMessage();
            Msg.From = new MailAddress("sumverifysystem@gmail.com", "SuM System");// Sender details here, replace with valid value
            Msg.Subject = "Password Reset!"; // subject of email
            string useremail = Request.Cookies["sd654fgsd65d5"].Value.ToString();
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
        public bool PasswordIsOk(string pass)
        {
            char[] x = pass.ToCharArray();
            int numnum = 0;
            int otherthannum = 0;
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] == ' ') { return false; }
                if (x[i] == '0' || x[i] == '1' || x[i] == '2' || x[i] == '3' || x[i] == '4' || x[i] == '5' || x[i] == '6' || x[i] == '7' || x[i] == '8' || x[i] == '9')
                {
                    numnum++;
                }
                else { otherthannum++; }

            }
            if (numnum > 7 && otherthannum > 3) { return true; }
            else { return false; }
        }
    }
}