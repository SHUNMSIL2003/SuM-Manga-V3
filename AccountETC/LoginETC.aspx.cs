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
                Response.Redirect("~/Explore.aspx");
            }
            else
            {
                ResendConf.Visible = false;
                LoginStatus.InnerText = "";
                UserNameL.Attributes["style"] = "";
                PasswordL.Attributes["style"] = "";
            }
        }
        protected void LoginToSuM(object sender, EventArgs e)
        {
            LoginStatus.InnerText = "";
            string statevalid = "";
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:shun-sum-projctdb-server.database.windows.net,1433;Initial Catalog=Shun-SuM-Projct_db;User Id=SuMSite2003@shun-sum-projctdb-server;Password=55878833shunpass#SQL"))
            {
                sqlCon.Open();
                string query = "SELECT UserID FROM SuMUsersAccounts WHERE UserName = @UserName AND Password = @Password ";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                string username = UserNameL.Value; //Request.QueryString["UserNameL"].ToString();
                sqlCmd.Parameters.AddWithValue("@UserName", username);
                string password = PasswordL.Value; //Request.QueryString["PasswordL"].ToString();
                sqlCmd.Parameters.AddWithValue("@Password", sha256(password));
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count > 0)
                {
                    string query2 = "SELECT AccountStatus FROM SuMUsersAccounts WHERE UserName = @UserName";
                    SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);
                    sqlCmd2.Parameters.AddWithValue("@UserName", username);
                    using (SqlDataReader dr = sqlCmd2.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            statevalid = dr[0].ToString();
                        }
                    }
                    if (statevalid[0] == '#' && statevalid[1] == 'R') 
                    {
                        LoginStatus.InnerText = "You need to Complete SuM Account registration! You will find the link in you email-inbox.";
                        ResendConf.Visible = true;
                    }
                    else
                    {
                        string qc = "SELECT CreatorName FROM SuMCreators WHERE UserName = @UserName";
                        SqlCommand cv = new SqlCommand(qc, sqlCon);
                        cv.Parameters.AddWithValue("@UserName", username);
                        var ituac = cv.ExecuteScalar();
                        if (ituac == null)
                        {
                            SaveCookie(username, count);
                            sqlCon.Close();
                            HttpContext.Current.Response.Redirect("~/Explore.aspx");
                        }
                        else
                        {
                            SaveSCCookie(username, ituac.ToString(), count);
                            sqlCon.Close();
                            HttpContext.Current.Response.Redirect("~/Explore.aspx");
                        }
                    }
                }
                else
                {
                    LoginStatus.InnerText = "Username or Password are incorrect"; sqlCon.Close();
                    UserNameL.Attributes["style"] = "border: solid 2px red;";
                    PasswordL.Attributes["style"] = "border: solid 2px red;";
                    LoginStatus.InnerText = "Username Or Password are incurrect!";
                    //UserNameL.BorderColor = System.Drawing.Color.Red;
                    //PasswordL.BorderColor = System.Drawing.Color.Red;
                    //rem.InnerText = "Not OK";
                }

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
        protected static void SaveCookie(string UserName, int ID)
        {
            HttpCookie userInfo = new HttpCookie("SuMCurrentUser");  //Request.Cookies["userInfo"].Value;  
            userInfo["UserName"] = UserName;
            userInfo["ID"] = ID.ToString();
            //userInfo.Expires.Add(new TimeSpan(4, 1, 0));
            userInfo.Expires = DateTime.MaxValue;
            HttpContext.Current.Response.Cookies.Add(userInfo);
            HttpContext.Current.Response.Redirect("/AccountETC/Settings.aspx");
        }
        protected static void SaveSCCookie(string UserName, string craetorname, int ID)
        {
            HttpCookie userInfo = new HttpCookie("SuMCurrentUser");  //Request.Cookies["userInfo"].Value;  
            userInfo["UserName"] = UserName;
            userInfo["CreatorName"] = craetorname;
            userInfo["ID"] = ID.ToString();
            //userInfo.Expires.Add(new TimeSpan(4, 1, 0));
            userInfo.Expires = DateTime.MaxValue;
            HttpContext.Current.Response.Cookies.Add(userInfo);
            HttpContext.Current.Response.Redirect("/AccountETC/Settings.aspx");
        }
        protected void ResendConfLink(object sender, EventArgs e)
        {
            string virivicationcode = GetVerificationCode(8);
            string accountstats = "#R$" + virivicationcode;
            string UserName = UserNameL.Value.ToString();
            string Email = string.Empty;
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:shun-sum-projctdb-server.database.windows.net,1433;Initial Catalog=Shun-SuM-Projct_db;User Id=SuMSite2003@shun-sum-projctdb-server;Password=55878833shunpass#SQL"))
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
        protected void LogInWithGoogle(object sender, EventArgs e)
        {

        }
    }
}
