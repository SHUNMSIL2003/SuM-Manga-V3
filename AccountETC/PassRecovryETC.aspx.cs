using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Net.Mail;
using System.IO;

namespace SuM_Manga_V3.AccountETC
{
    public partial class PassRecovryETC : System.Web.UI.Page
    {
        public string emailre = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void PassResetStart(object sender, EventArgs e) 
        {
            errormsg.InnerText = "";
            string email = EmailF.Value.ToString();
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:shun-sum-projctdb-server.database.windows.net,1433;Initial Catalog=Shun-SuM-Projct_db;User Id=SuMSite2003@shun-sum-projctdb-server;Password=55878833shunpass#SQL"))
            {
                sqlCon.Open();
                string query = "SELECT COUNT(1) FROM SuMUsersAccounts WHERE Email = @Email";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@Email", email);
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count > 0)
                {
                    emailre = EmailF.Value.ToString();
                    EmailF.Attributes["style"] = "display:none;";
                    PasswordRes.Attributes["style"] = "";
                    PasswordResC.Attributes["style"] = "";
                    VCODECONF.Attributes["style"] = "";
                    BtnP.Text = "Confirm & Change Password";
                    //BtnP.Attributes["OnClick"] = "ConfAndSavePass";
                }
                else
                {
                    EmailF.Attributes["style"] = "border-color:red;border-width:2px;";
                    errormsg.InnerText = "Email doesn't match any user";
                }
                sqlCon.Close();
            }
        }
        protected void ConfAndSavePass(object sender, EventArgs e) 
        {

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
            string useremail = EmailF.Value.ToString();
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