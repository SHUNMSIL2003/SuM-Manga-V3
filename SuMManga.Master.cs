using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuM_Manga_V3
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            if (GetUserInfoCookie != null)
            {
                string PFPFDB = string.Empty;
                string user = GetUserInfoCookie["UserName"].ToString();
                UserName.InnerText = user;
                using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:shun-sum-projctdb-server.database.windows.net,1433;Initial Catalog=Shun-SuM-Projct_db;User Id=SuMSite2003@shun-sum-projctdb-server;Password=55878833shunpass#SQL"))
                {
                    sqlCon.Open();
                    string query = "SELECT PFP FROM SuMUsersAccounts WHERE UserName = @UserName";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@UserName", user);
                    using (SqlDataReader dr = sqlCmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            PFPFDB = dr[0].ToString();
                        }
                    }
                }
                UserPFP.Attributes["src"] = ResolveUrl(PFPFDB);
                SignOption.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(SignOption, string.Empty));
                if (IsPostBack && Request["__EVENTTARGET"] == SignOption.UniqueID)
                {
                    LogOut(SignOption, EventArgs.Empty);
                }
                //ignOption.Attributes["onclick"] = "LogOut";
                SignOption.InnerText = " Logout";
            }
            else 
            {
                SignOption.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(SignOption, string.Empty));
                if (IsPostBack && Request["__EVENTTARGET"] == SignOption.UniqueID)
                {
                    ToSign(SignOption, EventArgs.Empty);
                }
                //SignOption.Attributes["onclick"] = "ToSign";
                SignOption.InnerText = " Login";
            }
        }
        protected void ToSign(object sender, EventArgs e) 
        {
            Response.Redirect("~/AccountETC/LoginETC.aspx");
        }
        protected void LogOut(object sender, EventArgs e) 
        {
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            GetUserInfoCookie.Expires = DateTime.Now.AddDays(-2);
            Response.Cookies.Add(GetUserInfoCookie);
            //HttpCookie GetUserpinns = Request.Cookies["SuMPinns"];
            //GetUserpinns["Pinns"] = "!";
            //Response.Cookies.Add(GetUserpinns);
            Response.Redirect("~/AccountETC/LogInETC.aspx");
        }
    }
}