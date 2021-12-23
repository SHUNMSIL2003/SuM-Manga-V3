using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace SuM_Manga_V3.AccountETC
{
    public partial class Settings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            if (GetUserInfoCookie != null)
            {
                string UserName = GetUserInfoCookie["UserName"].ToString();
                SuMUserName.InnerText = UserName;
                string CurrPFP = string.Empty;
                string currEmail = string.Empty;
                //string currSignetsure = string.Empty;
                using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    sqlCon.Open();
                    string query = "SELECT PFP FROM SuMUsersAccounts WHERE UserName = @UserName";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    //HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
                    sqlCmd.Parameters.AddWithValue("@UserName", UserName);
                    using (SqlDataReader dr = sqlCmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            CurrPFP = dr[0].ToString();
                        }
                    }
                    //string query3 = "SELECT Signetsure FROM SuMUsersAccounts WHERE UserName = @UserName";
                    //SqlCommand sqlCmd3 = new SqlCommand(query3, sqlCon);
                    //HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
                    //sqlCmd3.Parameters.AddWithValue("@UserName", UserName);
                    /*using (SqlDataReader dr = sqlCmd3.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            currSignetsure = dr[0].ToString();
                        }
                    }*/
                    string query4 = "SELECT Email FROM SuMUsersAccounts WHERE UserName = @UserName";
                    SqlCommand sqlCmd4 = new SqlCommand(query4, sqlCon);
                    //HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
                    sqlCmd4.Parameters.AddWithValue("@UserName", UserName);
                    using (SqlDataReader dr = sqlCmd4.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            currEmail = dr[0].ToString();
                        }
                    }
                    sqlCon.Close();
                }
                SignedWith.InnerText = currEmail;
                PFP.Attributes["src"] = ResolveUrl(CurrPFP);
            }
            else
            {
                LogOutBTN.Attributes["style"] = "display:none;";
                LogOutBTN.Attributes["OnClick"] = "NULL";
            }
        }
        public void NULL(object sender, EventArgs e) { }
        protected void LogOut(object sender, EventArgs e)
        {
            HttpCookie GetUserInfoCookie = new HttpCookie("SuMCurrentUser");
            GetUserInfoCookie.Expires = DateTime.Now.AddDays(-100);
            Response.Cookies.Add(GetUserInfoCookie);
            Response.Redirect("~/AccountETC/LogInETC.aspx");
        }
    }
}