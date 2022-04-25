using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient; using MySql.Data.MySqlClient; using System.Configuration;
using System.Security.Cryptography;
 
using System.Web.Security;
using System.Net.Mail;
using System.IO;
 
namespace SuM_Manga_V3.AccountETC
{
    public partial class ValidateUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["UserName"]) != true && string.IsNullOrEmpty(Request.QueryString["VCode"]) != true)
            {
                string username = Request.QueryString["UserName"];
                string vcode = Request.QueryString["VCode"];
                string acs = "#R$" + vcode;
                string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
                {
                    MySqlCon.Open();
                    string query = "SELECT COUNT(1) FROM SuMUsersAccounts WHERE UserName = @UserName AND AccountStatus = @AccountStatus ";
                    MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
                    MySqlCmd.Parameters.AddWithValue("@UserName", username);
                    MySqlCmd.Parameters.AddWithValue("@AccountStatus", acs);
                    int count = Convert.ToInt32(MySqlCmd.ExecuteScalar());
                    if (count > 0)
                    {
                        string query2 = "UPDATE SuMUsersAccounts SET AccountStatus = @AccountStatus WHERE UserName = @UserName";
                        MySqlCommand MySqlCmd2 = new MySqlCommand(query2, MySqlCon);
                        MySqlCmd2.Parameters.AddWithValue("@UserName", username);
                        MySqlCmd2.Parameters.AddWithValue("@AccountStatus", "#S$FT");//#S --> subscriped      $FT   ---> (The subscription type)Free Trial
                        MySqlCmd2.ExecuteNonQuery();
                        MySqlCon.Close();
                        Response.Redirect("~/AccountETC/LoginETC.aspx");
                    }
                    else
                    {
                        vtitle.InnerText = "Somthing Went Wrong!";
                        vtitle.Attributes["style"] = "color:red;";
                        vp.InnerText = "The Code Might have Expired..";
                        ReSendLink2.Visible = true;
                    }
                }
            }
            else
            {
                vtitle.InnerText = "Invalid Link!";
                vtitle.Attributes["style"] = "color:red;";
                vp.InnerText = "Make Sure you cliked the right link... ";
                vp.Attributes["style"] = "color:lightcoral;";
            }
          
        }
        protected void ResendConfLink(object sender, EventArgs e)
        {
            string virivicationcode = GetVerificationCode(8);
            string accountstats = "#R$" + virivicationcode;
            string UserName = Request.QueryString["UserName"];
            string Email = string.Empty;
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string query = "UPDATE SuMUsersAccounts SET AccountStatus = @AccountStatus WHERE UserName = @UserName";
                MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
                //HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
                MySqlCmd.Parameters.AddWithValue("@UserName", UserName);
                MySqlCmd.Parameters.AddWithValue("@AccountStatus", accountstats);
                MySqlCmd.ExecuteNonQuery();
                //MySqlCmd.Parameters.AddWithValue("@SuMCustomPFP", SqlDbType.Image).Value = imgarray;

                string query4 = "SELECT Email FROM SuMUsersAccounts WHERE UserName = @UserName";
                MySqlCommand MySqlCmd4 = new MySqlCommand(query4, MySqlCon);
                //HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
                MySqlCmd4.Parameters.AddWithValue("@UserName", UserName);
                using (MySqlDataReader dr = MySqlCmd4.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Email = dr[0].ToString();
                    }
                }
                MySqlCon.Close();
            }
            SendVirifyEmail(virivicationcode, Email);

        }
        protected void SendVirifyEmail(string VCODE,string Email)
        {
            //Send Email
            string thelink = "https://sum-manga.azurewebsites.net/AccountETC/ValidateUsers.aspx?UserName=" + Request.QueryString["UserName"].ToString() + "&VCode=" + VCODE;
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
            string username = Request.QueryString["UserName"].ToString();
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
    }
}