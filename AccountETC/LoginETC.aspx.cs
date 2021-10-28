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


namespace SuM_Manga_V3.AccountETC
{
    public partial class LoginETC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginStatus.InnerText = "";
        }
        protected void LoginToSuM(object sender, EventArgs e)
        {
            LoginStatus.InnerText = "";
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:shun-sum-projctdb-server.database.windows.net,1433;Initial Catalog=Shun-SuM-Projct_db;User Id=SuMSite2003@shun-sum-projctdb-server;Password=55878833shunpass#SQL"))
            {
                sqlCon.Open();
                string query = "SELECT COUNT(1) FROM SuMUsersAccounts WHERE UserName = @UserName AND Password = @Password ";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                string username = UserNameL.Value; //Request.QueryString["UserNameL"].ToString();
                sqlCmd.Parameters.AddWithValue("@UserName", username);
                string password = PasswordL.Value; //Request.QueryString["PasswordL"].ToString();
                sqlCmd.Parameters.AddWithValue("@Password", sha256(password));
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count > 0)
                {
                    SaveCookie(username);
                    sqlCon.Close();
                    HttpContext.Current.Response.Redirect("~/Default.aspx");
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
        static void SaveCookie(string UserName)
        {
            HttpCookie userInfo = new HttpCookie("SuMCurrentUser");  //Request.Cookies["userInfo"].Value;  
            userInfo["UserName"] = UserName;
            //userInfo.Expires.Add(new TimeSpan(4, 1, 0));
            userInfo.Expires = DateTime.MaxValue;
            HttpContext.Current.Response.Cookies.Add(userInfo);
            HttpContext.Current.Response.Redirect("/AccountETC/SuMAccount.aspx");
        }
    }
}
