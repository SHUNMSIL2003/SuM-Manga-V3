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
    public partial class RegisterETC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
                if (GetUserInfoCookie != null)
                {
                    //MPB.InnerText = "Explore";
                    //MPB.Attributes["href"] = "Library.aspx";
                    Response.Redirect("~/Explore.aspx");
                }
            }
            PasswordSWM.InnerText = "";
            UserNameSWM.InnerText = "";
            EmailSWM.InnerText = "";
            EmailR.Attributes["style"] = "";
            UserNameR.Attributes["style"] = "";
            PasswordR.Attributes["style"] = "";
            PasswordRc.Attributes["style"] = "";
        }
        protected void RegisterProsss(object sender, EventArgs e)
        {
            bool PasswordsMatch = false;
            bool UserNameExsists = true;
            bool EmailExsists = true;
            if (PasswordR.Value == PasswordRc.Value) { PasswordsMatch = true; }
            else { PasswordsMatch = false; }
            if (XExsisits("UserName", UserNameR.Value.ToString()) == true) { UserNameExsists = true; }
            else { UserNameExsists = false; }
            if (XExsisits("Email", EmailR.Value.ToString()) == true) { EmailExsists = true; }
            else { EmailExsists = false; }
            bool passwordcheckok = PasswordIsOk(PasswordR.Value);
            string DPFP = "/AccountETC/DeafultPFP.jpg";
            string dsig = "#Joined_to_SuM_Manga " + DateTime.Now.ToString("yyyy MM dd");
            if (UserNameExsists == false && EmailExsists == false && PasswordsMatch == true && passwordcheckok == true)
            {
                string virivicationcode = GetVerificationCode(8);
                string accountstats = "#R$" + virivicationcode;
                using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:summangaserver.database.windows.net,1433;Initial Catalog=SuMMangaSQL;User Id=summangasqladmin;Password=55878833sqlpass#S"))//Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=P:\Shun-MuS-Projct\App_Data\SuMAccounts.mdf; Integrated Security=True
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("INSERT INTO SuMUsersAccounts(UserName,Password,Email,AccountStatus,PFP,Signetsure) values(@UserName,@Password,@Email,@AccountStatus,@PFP,@Signetsure)", sqlCon);
                    sqlCmd.Parameters.AddWithValue("@UserName", UserNameR.Value);
                    sqlCmd.Parameters.AddWithValue("@Password", sha256(PasswordR.Value));
                    sqlCmd.Parameters.AddWithValue("@Email", EmailR.Value);
                    sqlCmd.Parameters.AddWithValue("@PFP", DPFP);
                    sqlCmd.Parameters.AddWithValue("@AccountStatus", accountstats);
                    sqlCmd.Parameters.AddWithValue("@Signetsure", dsig);
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                }
                int id = 0;
                using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:summangaserver.database.windows.net,1433;Initial Catalog=SuMMangaSQL;User Id=summangasqladmin;Password=55878833sqlpass#S"))
                {
                    sqlCon.Open();
                    string query = "SELECT UserID FROM SuMUsersAccounts WHERE UserName = @UserName";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    //HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
                    string username0 = UserNameR.Value.ToString();
                    sqlCmd.Parameters.AddWithValue("@UserName", username0);
                    using (SqlDataReader dr = sqlCmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            id = Convert.ToInt32(dr[0]);
                        }
                    }
                }
                //
                string D = DateTime.UtcNow.ToString("dd");
                string M = DateTime.UtcNow.ToString("MM");
                string Y = DateTime.UtcNow.ToString("yyyy");
                string freetrialalert = "#FreeT?Y" + Y + "?M" + M + "?D" + D + "$N";
                //
                using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:summangaserver.database.windows.net,1433;Initial Catalog=SuMMangaSQL;User Id=summangasqladmin;Password=55878833sqlpass#S"))//Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=P:\Shun-MuS-Projct\App_Data\SuMAccounts.mdf; Integrated Security=True
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("INSERT INTO UsersAccountAlert(UserID,SuMPaymentAlert,AlertsSeen) values(@UserID,@SuMPaymentAlert,@AlertsSeen)", sqlCon);
                    sqlCmd.Parameters.AddWithValue("@UserID", SqlDbType.Int);
                    sqlCmd.Parameters["@UserID"].Value = id;
                    sqlCmd.Parameters.AddWithValue("@SuMPaymentAlert", freetrialalert);
                    sqlCmd.Parameters.AddWithValue("@AlertsSeen", "1");
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                }
                SendVirifyEmail(virivicationcode);
                Response.Redirect("~/AccountETC/LoginETC.aspx");
            }
            else
            {
                PasswordSWM.InnerText = "";
                UserNameSWM.InnerText = "";
                EmailSWM.InnerText = "";
                EmailR.Attributes["style"] = "";
                UserNameR.Attributes["style"] = "";
                PasswordR.Attributes["style"] = "";
                PasswordRc.Attributes["style"] = "";
                if (EmailExsists == true)
                {
                    //somthingwrong.InnerText += "- Email is already in use! -\n";
                    EmailSWM.InnerText = "Email is already in use!     ";
                    EmailR.Attributes["style"] = "border: solid 2px red;";
                }
                if (UserNameExsists == true)
                {
                    UserNameSWM.InnerText = "Username is unavalible!";
                    UserNameR.Attributes["style"] = "border: solid 2px red;";
                }
                if (PasswordsMatch == false)
                {
                    PasswordSWM.InnerText = "Passwords does not match";
                    PasswordR.Attributes["style"] = "border: solid 2px red;";
                    PasswordRc.Attributes["style"] = "border: solid 2px red;";
                }
                if (PasswordsMatch == true && passwordcheckok == false)
                {
                    PasswordSWM.InnerText = "Your password should have atleast 8 numbers and 4 other charecters";
                    PasswordR.Attributes["style"] = "border: solid 2px red;";
                    PasswordRc.Attributes["style"] = "border: solid 2px red;";
                }
            }
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
        public bool XExsisits(string type, string X)
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:summangaserver.database.windows.net,1433;Initial Catalog=SuMMangaSQL;User Id=summangasqladmin;Password=55878833sqlpass#S"))
            {
                sqlCon.Open();
                string query = "SELECT COUNT(1) FROM SuMUsersAccounts WHERE " + type + " = @" + type + " ";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@" + type + "", X);
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count > 0) { return true; }
                else { return false; }
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
        protected string MailTemplate(string link)
        {
            StreamReader sr = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/AccountETC/Email.html"));
            string body = sr.ReadToEnd();
            sr.Close();
            string username = UserNameR.Value.ToString();
            body = body.Replace("#USERNAME#", username);
            body = body.Replace("#LINK#", link);
            return body;
        }
        protected void SendVirifyEmail(string VCODE)
        {
            //Send Email
            string thelink = "https://sum-manga.azurewebsites.net/AccountETC/ValidateUsers.aspx?UserName=" + UserNameR.Value.ToString() + "&VCode=" + VCODE;
            string emailbody = MailTemplate(thelink);
            MailMessage Msg = new MailMessage();
            Msg.From = new MailAddress("sumverifysystem@gmail.com", "SuM System");// Sender details here, replace with valid value
            Msg.Subject = "Setup SuM Account!"; // subject of email
            string useremail = EmailR.Value.ToString();
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
    }
}