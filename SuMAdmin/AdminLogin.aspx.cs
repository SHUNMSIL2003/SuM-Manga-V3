using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient; using MySql.Data.MySqlClient; using System.Configuration;
using System.Text;

namespace SuM_Manga_V3.SuMAdmin
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            if (GetUserInfoCookie != null)
            {
                //MPB.InnerText = "Explore";
                //MPB.Attributes["href"] = "Library.aspx";
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                //ResendConf.Visible = false;
                LoginStatus.InnerText = "";
                UserNameL.Attributes["style"] = "";
                PasswordL.Attributes["style"] = "";
            }
        }
        protected void LoginToSuM(object sender, EventArgs e)
        {
            //LoginStatus.InnerText = "";
            //string statevalid = "";
            /*string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string query = "SELECT COUNT(1) FROM SuMAdministrators WHERE UserName = @UserName AND Password = @Password ";
                MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
                string username = UserNameL.Value; //Request.QueryString["UserNameL"].ToString();
                MySqlCmd.Parameters.AddWithValue("@UserName", sha256(username));
                string password = PasswordL.Value; //Request.QueryString["PasswordL"].ToString();
                MySqlCmd.Parameters.AddWithValue("@Password", sha256(password));
                int count = Convert.ToInt32(MySqlCmd.ExecuteScalar());
                if (count > 0)
                {
                    SaveCookie(sha256(username));
                    MySqlCon.Close();
                    HttpContext.Current.Response.Redirect("~/SuMAdmin/AdminControlPanel.aspx");
                }
                else
                {
                    LoginStatus.InnerText = "Invalid!"; MySqlCon.Close();
                    UserNameL.Attributes["style"] = "border: solid 2px red;";
                    PasswordL.Attributes["style"] = "border: solid 2px red;";
                    //LoginStatus.InnerText = "Username Or Password are incurrect!";
                    //UserNameL.BorderColor = System.Drawing.Color.Red;
                    //PasswordL.BorderColor = System.Drawing.Color.Red;
                    //rem.InnerText = "Not OK";
                }

            }*/
        }
        /*static string sha256(string randomString)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }*/
        /*static void SaveCookie(string UserName)
        {
            HttpCookie userInfo = new HttpCookie("SuMCurrentUser");  //Request.Cookies["userInfo"].Value;  
            userInfo["UserName"] = UserName;
            //userInfo.Expires.Add(new TimeSpan(4, 1, 0));
            userInfo.Expires = DateTime.MaxValue;
            HttpContext.Current.Response.Cookies.Add(userInfo);
            HttpContext.Current.Response.Redirect("/AccountETC/SuMAccount.aspx");
        }*/
    }
}