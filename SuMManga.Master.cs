using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI;
using System.Data;
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
                SuMAppAlert.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(SuMAppAlert, string.Empty));
                if (IsPostBack && Request["__EVENTTARGET"] == SuMAppAlert.UniqueID)
                {
                    SuMAppAlertsStartsS(SuMAppAlert, EventArgs.Empty);
                }
                //ignOption.Attributes["onclick"] = "LogOut";
                SignOption.InnerText = " Logout";
                bool once = true;
                if (once == true)
                {
                    once = false;
                    PayNoti();
                }
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
        protected void PayNoti()
        {
            int ID = 0;
            string D = DateTime.UtcNow.ToString("dd");
            string M = DateTime.UtcNow.ToString("MM");
            string Y = DateTime.UtcNow.ToString("yyyy");
            HttpCookie GetUserInfoCookie2 = Request.Cookies["SuMCurrentUser"];
            string UserName = GetUserInfoCookie2["UserName"].ToString();
            int AlS = 0;
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:shun-sum-projctdb-server.database.windows.net,1433;Initial Catalog=Shun-SuM-Projct_db;User Id=SuMSite2003@shun-sum-projctdb-server;Password=55878833shunpass#SQL"))
            {
                sqlCon.Open();
                string query = "SELECT UserID FROM SuMUsersAccounts WHERE UserName = @UserName ";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@UserName", UserName);
                using (SqlDataReader dr = sqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ID = Convert.ToInt32(dr[0]);
                    }
                }
                sqlCon.Close();
            }
            string RawAlert = string.Empty;
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:shun-sum-projctdb-server.database.windows.net,1433;Initial Catalog=Shun-SuM-Projct_db;User Id=SuMSite2003@shun-sum-projctdb-server;Password=55878833shunpass#SQL"))
            {
                sqlCon.Open();
                string query = "SELECT SuMPaymentAlert FROM UsersAccountAlert WHERE UserID = @UserID ";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@UserID", SqlDbType.Int);
                sqlCmd.Parameters["@UserID"].Value = ID;
                using (SqlDataReader dr = sqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        RawAlert = dr[0].ToString();
                    }
                }
                sqlCon.Close();
            }
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:shun-sum-projctdb-server.database.windows.net,1433;Initial Catalog=Shun-SuM-Projct_db;User Id=SuMSite2003@shun-sum-projctdb-server;Password=55878833shunpass#SQL"))
            {
                sqlCon.Open();
                string query = "SELECT AlertsSeen FROM UsersAccountAlert WHERE UserID = @UserID ";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@UserID", SqlDbType.Int);
                sqlCmd.Parameters["@UserID"].Value = ID;
                using (SqlDataReader dr = sqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        AlS = Convert.ToInt32(dr[0]);
                    }
                }
                sqlCon.Close();
            }
            //dataready now
            payalertshow.Attributes["style"] = "height:fit-content;";
            string month = string.Empty;
            string[] months = { "January", "February", "March ", "April", "May ", "June ", "July", "August", "September", "October", "November", "December" };
            //PayDate.InnerText = Month + " " + d.ToString() + Y; wrong
            string SType = "";
            string SD = string.Empty;
            string SM = string.Empty;
            string SY = string.Empty;
            string SNotReadden = "";
            char[] Alert = RawAlert.ToCharArray();
            bool Q = false;
            for (int i = 0; i < Alert.Length; i++)
            {
                if (Alert[i] == '?') { Q = true; }
                if (Alert[i] != '#' && Q == false)
                {
                    SType += Alert[i];
                }
                if (Alert[i] == '?' && Alert[i + 1] == 'Y')
                {
                    SY = "" + Alert[i + 2] + Alert[i + 3] + Alert[i + 4] + Alert[i + 5];
                }
                if (Alert[i] == '?' && Alert[(i + 1)] == 'M')
                {
                    SM = (Alert[i + 2]).ToString() + (Alert[i + 3]).ToString();
                }
                if (Alert[i] == '?' && Alert[i + 1] == 'D')
                {
                    SD = "" + Alert[i + 2] + Alert[i + 3];
                }
                if (Alert[i] == '$') { SNotReadden = (Alert[i + 1]).ToString(); }
            }//Remember to add red to seen in register
            int pm = Convert.ToInt32(SM);
            int fixedday = Convert.ToInt32(SD);
            PayDate.InnerText = months[pm - 1] + " " + fixedday.ToString() + " " + SY;
            bool timepassed = false;
            if ((Convert.ToInt32(SY) - Convert.ToInt32(Y)) <= 0)
            {
                if ((Convert.ToInt32(SM) - Convert.ToInt32(M)) == 0)
                {
                    if ((Convert.ToInt32(SD) <= Convert.ToInt32(D)))
                    {
                        if (SType == "FreeT") { PayDisc.InnerText = "Enjoy your One Month FREE Traial :) "; }
                        if (SType == "Paied") { PayDisc.InnerText = "Payment Confirmed, Enjoy SuM Manga :) "; }
                    }
                    else { timepassed = true; }
                }
                if ((Convert.ToInt32(M) - Convert.ToInt32(SM)) == 1)
                {
                    if ((Convert.ToInt32(SD) > Convert.ToInt32(D)))
                    {
                        if (SType == "FreeT") { PayDisc.InnerText = "Enjoy your One Month FREE Traial :) "; }
                        if (SType == "Paied") { PayDisc.InnerText = "Payment Confirmed, Enjoy SuM Manga :) "; }
                    }
                    else { timepassed = true; }
                }
                if ((Convert.ToInt32(SM) - Convert.ToInt32(M)) != 0 && (Convert.ToInt32(M) - Convert.ToInt32(SM)) != 1) { timepassed = true; }
            }
            else { timepassed = true; }
            if (timepassed == true)
            {
                if (SType == "FreeT") { PayDisc.InnerText = "Your One Month FREE Traial has endded,Create a subscription to contenue. "; }
                if (SType == "Paied") { PayDisc.InnerText = "Your subscription hase expired!, Renew it contenue."; }
                HttpCookie userInfo = new HttpCookie("SuMCurrentUser");  //Request.Cookies["userInfo"].Value;  
                userInfo["UserName"] = UserName;
                userInfo["SubValid"] = "N";
                //userInfo.Expires.Add(new TimeSpan(4, 1, 0));
                userInfo.Expires = DateTime.MaxValue;
                HttpContext.Current.Response.Cookies.Add(userInfo);
            }
            else
            {
                HttpCookie userInfo = new HttpCookie("SuMCurrentUser");  //Request.Cookies["userInfo"].Value;  
                userInfo["UserName"] = UserName;
                userInfo["SubValid"] = "N";
            }
            /*SuMAppAlert.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(SuMAppAlert, string.Empty));
            if (IsPostBack && Request["__EVENTTARGET"] == SuMAppAlert.UniqueID)
            {
                MarkReadDone(ID, RawAlert, SuMAppAlert, EventArgs.Empty);
            }*/
            // if (SType == "FreeT") { PayDisc.InnerText = "Enjoy your One Month FREE Traial :) "; }
            // if (SType == "Paied") { PayDisc.InnerText = "Payment Confirmed, Enjoy SuM Manga :) "; }
        }
        private void SuMAppAlertsStartsS(object sender, EventArgs e) 
        {
            int ID = 0;
            HttpCookie GetUserInfoCookie2 = Request.Cookies["SuMCurrentUser"];
            string UserName = GetUserInfoCookie2["UserName"].ToString();
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:shun-sum-projctdb-server.database.windows.net,1433;Initial Catalog=Shun-SuM-Projct_db;User Id=SuMSite2003@shun-sum-projctdb-server;Password=55878833shunpass#SQL"))
            {
                sqlCon.Open();
                string query = "SELECT UserID FROM SuMUsersAccounts WHERE UserName = @UserName ";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@UserName", UserName);
                using (SqlDataReader dr = sqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ID = Convert.ToInt32(dr[0]);
                    }
                }
                sqlCon.Close();
            }
            string RawAlert = string.Empty;
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:shun-sum-projctdb-server.database.windows.net,1433;Initial Catalog=Shun-SuM-Projct_db;User Id=SuMSite2003@shun-sum-projctdb-server;Password=55878833shunpass#SQL"))
            {
                sqlCon.Open();
                string query = "SELECT SuMPaymentAlert FROM UsersAccountAlert WHERE UserID = @UserID ";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@UserID", SqlDbType.Int);
                sqlCmd.Parameters["@UserID"].Value = ID;
                using (SqlDataReader dr = sqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        RawAlert = dr[0].ToString();
                    }
                }
                sqlCon.Close();
            }
            MarkReadDone(ID, RawAlert);
        }
        protected void ToSign(object sender, EventArgs e) 
        {
            Response.Redirect("~/AccountETC/LoginETC.aspx");
        }
        protected void MarkReadDone(int Colum, string OValue) //name colum but its a row
        {
            string confirmseentag = "";
            string backupoldfornew = "";
            bool dollarfound = false;
            char[] value = OValue.ToCharArray();
            for (int g = 0; g < OValue.Length; g++) 
            {
                if (dollarfound == false) { backupoldfornew += value[g]; } else { confirmseentag = (value[g + 1]).ToString(); g = OValue.Length; }
                if (g == '$'){ dollarfound = true; }//can be optimized ! -Later-> no need now i think...
            }
            string NewSeenTag = string.Empty;
            if (confirmseentag == "N")
            {

                NewSeenTag = backupoldfornew + "Y";
            }
            else { NewSeenTag = OValue; }
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:shun-sum-projctdb-server.database.windows.net,1433;Initial Catalog=Shun-SuM-Projct_db;User Id=SuMSite2003@shun-sum-projctdb-server;Password=55878833shunpass#SQL"))
            {
                sqlCon.Open();
                string query = "UPDATE UsersAccountAlert SET SuMPaymentAlert = @SuMPaymentAlert WHERE UserID = @UserID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                //HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
                sqlCmd.Parameters.AddWithValue("@UserID", Colum);
                sqlCmd.Parameters.AddWithValue("@SuMPaymentAlert", NewSeenTag);
                sqlCmd.ExecuteNonQuery();
                //sqlCmd.Parameters.AddWithValue("@SuMCustomPFP", SqlDbType.Image).Value = imgarray;
                sqlCon.Close();
            }
        }
        public void empty0() { }
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