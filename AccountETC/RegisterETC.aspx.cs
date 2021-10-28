using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace SuM_Manga_V3.AccountETC
{
    public partial class RegisterETC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
            if (XExsisits("UserName", UserNameR.Value) == true) { UserNameExsists = true; }
            else { UserNameExsists = false; }
            if (XExsisits("Email", EmailR.Value) == true) { EmailExsists = true; }
            else { EmailExsists = false; }
            bool passwordcheckok = PasswordIsOk(PasswordR.Value);
            string DPFP = "~/AccountETC/DeafultPFP.jpg";
            string dsig = "#Joined_to_SuM " + DateTime.Now.ToString("yyyy MM dd");
            if (UserNameExsists == false && EmailExsists == false && PasswordsMatch == true && passwordcheckok == true)
            {
                using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:shun-sum-projctdb-server.database.windows.net,1433;Initial Catalog=Shun-SuM-Projct_db;User Id=SuMSite2003@shun-sum-projctdb-server;Password=55878833shunpass#SQL"))//Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=P:\Shun-MuS-Projct\App_Data\SuMAccounts.mdf; Integrated Security=True
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("INSERT INTO SuMUsersAccounts(UserName,Password,Email,AccountStatus,PFP,Signetsure) values(@UserName,@Password,@Email,@AccountStatus,@PFP,@Signetsure)", sqlCon);
                    sqlCmd.Parameters.AddWithValue("@UserName", UserNameR.Value);
                    sqlCmd.Parameters.AddWithValue("@Password", sha256(PasswordR.Value));
                    sqlCmd.Parameters.AddWithValue("@Email", EmailR.Value);
                    sqlCmd.Parameters.AddWithValue("@PFP", DPFP);
                    sqlCmd.Parameters.AddWithValue("@AccountStatus", "Regist");
                    sqlCmd.Parameters.AddWithValue("@Signetsure", dsig);
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                    UserNameR.Value = PasswordR.Value = PasswordRc.Value = EmailR.Value = "";
                    Response.Redirect("~/AccountETC/LoginETC.aspx");
                }
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
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:shun-sum-projctdb-server.database.windows.net,1433;Initial Catalog=Shun-SuM-Projct_db;User Id=SuMSite2003@shun-sum-projctdb-server;Password=55878833shunpass#SQL"))
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
    }
}