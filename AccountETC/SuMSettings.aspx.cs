using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;

namespace SuM_Manga_V3.AccountETC
{
    public partial class SuMSettings : System.Web.UI.Page
    {
        /*protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Request.Browser.IsMobileDevice)
                MasterPageFile = "~/SuMManga.Mobile.Master";
        }*/
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
                if (GetUserInfoCookie == null)
                {
                    //MPB.InnerText = "Explore";
                    //MPB.Attributes["href"] = "Library.aspx";
                    Response.Redirect("~/AccountETC/LoginETC.aspx");
                }
                else 
                {
                    UserNameForShow0.InnerText = GetUserInfoCookie["UserName"].ToString();
                }
            }
        }
        protected void BACApply(object sender, EventArgs e)
        {
            HttpCookie user = Request.Cookies["SuMCurrentUser"];
            bool NoCreatorName = string.IsNullOrEmpty(CreatorNameBAC.Value);
            bool NoPhoneNum = string.IsNullOrEmpty(PhoneNumBAC.Value);
            bool NoPassword = string.IsNullOrEmpty(PasswordBAC.Value);
            bool NoQ = string.IsNullOrEmpty(Q.Value);
            if (NoCreatorName == false && NoPhoneNum == false && NoPassword == false)
            {
                using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    sqlCon.Open();

                    string query = "SELECT COUNT(1) FROM SuMUsersAccounts WHERE UserName = @UserName AND Password = @Password ";
                    SqlCommand sqlCmd0 = new SqlCommand(query, sqlCon);
                    string username = user["UserName"].ToString();
                    sqlCmd0.Parameters.AddWithValue("@UserName", username);
                    string password = sha256(PasswordBAC.Value.ToString());
                    sqlCmd0.Parameters.AddWithValue("@Password", password);
                    int count = Convert.ToInt32(sqlCmd0.ExecuteScalar());
                    if (count > 0)
                    {


                        SqlCommand sqlgetid = new SqlCommand("SELECT UserID FROM SuMUsersAccounts WHERE UserName = @UserName", sqlCon);
                        sqlgetid.Parameters.AddWithValue("@UserName", user["UserName"].ToString());
                        var gid = sqlgetid.ExecuteScalar();
                        int ID = Convert.ToInt32(gid);
                        SqlCommand sqlCmd = new SqlCommand("INSERT INTO SuMCreatorReq(Req,UserName,UserID,CreatorName,PhoneNum,Q) values(@Req,@UserName,@UserID,@CreatorName,@PhoneNum,@Q)", sqlCon);
                        sqlCmd.Parameters.AddWithValue("@Req", "BeACreator!");
                        sqlCmd.Parameters.AddWithValue("@UserName", username);
                        sqlCmd.Parameters.AddWithValue("@UserID", ID);
                        sqlCmd.Parameters.AddWithValue("@CreatorName", CreatorNameBAC.Value.ToString());
                        sqlCmd.Parameters.AddWithValue("@PhoneNum", PhoneNumBAC.Value.ToString());
                        if (NoQ == true) { sqlCmd.Parameters.AddWithValue("@Q", "NoMsg!"); }
                        else { sqlCmd.Parameters.AddWithValue("@Q", Q.Value.ToString()); }
                        sqlCmd.ExecuteNonQuery();
                        sqlCon.Close();
                        creatorsupmitform.InnerHtml = "<h4>Request Sent!</h4><p>it may take up to 7 busness days</p>";
                    }
                    else
                    {
                        sqlCon.Close();
                        PasswordBAC.Attributes["style"] = "border:solid 2px #ff0000;";
                    }
                }
            }
            else
            {
                if (NoCreatorName == true) { CreatorNameBAC.Attributes["style"] = "border:solid 2px #ff0000;"; }
                if (NoPassword == true) { PasswordBAC.Attributes["style"] = "border:solid 2px #ff0000;"; }
                if (NoPhoneNum == true) { PhoneNumBAC.Attributes["style"] = "border:solid 2px #ff0000;"; }
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