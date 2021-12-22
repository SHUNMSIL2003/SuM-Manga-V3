using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Net.Mail;

namespace SuM_Manga_V3.AccountETC
{
    public partial class SuMAccount : System.Web.UI.Page
    {
        /*protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Request.Browser.IsMobileDevice)
                MasterPageFile = "~/SuMManga.Mobile.Master";
        }*/
        public string currSignetsure = string.Empty;
        public string currEmail = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            if (GetUserInfoCookie == null)
            {
                Response.Redirect("/AccountETC/LogInETC.aspx");
            }
            string UserName = GetUserInfoCookie["UserName"].ToString();
            UserNameForShow0.InnerText = UserName;
            string CurrPFP = string.Empty;
            //string currSignetsure = string.Empty;
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:summangaserver.database.windows.net,1433;Initial Catalog=SuMMangaSQL;User Id=summangasqladmin;Password=55878833sqlpass#S"))
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
                string query3 = "SELECT Signetsure FROM SuMUsersAccounts WHERE UserName = @UserName";
                SqlCommand sqlCmd3 = new SqlCommand(query3, sqlCon);
                //HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
                sqlCmd3.Parameters.AddWithValue("@UserName", UserName);
                using (SqlDataReader dr = sqlCmd3.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        currSignetsure = dr[0].ToString();
                    }
                }
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
            SignaturePE.Attributes["placeholder"] = currSignetsure;
            UserNameEP.Attributes["placeholder"] = UserName;
            EmailEP.Attributes["placeholder"] = currEmail;
            PFP.Attributes["src"] = ResolveUrl(CurrPFP);
        }
        protected void ChangePFP(object sender, EventArgs e) 
        {
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            string UserName = GetUserInfoCookie["UserName"].ToString();
            if (SuMCustomPFP.HasFile == true)
            {
                string oldimg = PFP.Attributes["src"].ToString();
                char[] fixing = oldimg.ToCharArray();
                string OrPATH = string.Empty;
                for (int i = 0; i < fixing.Length; i++)
                { 
                    if (fixing[i] == '/')
                    {
                        if (string.IsNullOrEmpty(OrPATH) == true) { OrPATH = "\\"; }
                        else { OrPATH += "\\"; }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(OrPATH) == true) { OrPATH = fixing[i].ToString(); }
                        else { OrPATH += fixing[i].ToString(); }
                    }
                }
                bool fixer = File.Exists(Server.MapPath(OrPATH));
                bool Fix5 = OrPATH.Contains("DeafultPFP.jpg");
                if (fixer == true && Fix5 == false) { File.Delete(Server.MapPath(OrPATH)); }
                //if(SuMCustomPFP.PostedFile.ContentType!="png"|| SuMCustomPFP.PostedFile.ContentType != "jpeg")
                //
                string fileName = System.IO.Path.GetFileName(SuMCustomPFP.PostedFile.FileName);
                string ffn = DateTime.Now.ToString("yyyyMMddHHmmss") + UserName + fileName; //System.IO.Path.Combine("UsersUploads",ffn)
                //string path0123 = HttpContext.Current.Request.PhysicalApplicationPath + "\\UsersUploads";
                SuMCustomPFP.PostedFile.SaveAs(Server.MapPath(System.IO.Path.Combine("UsersUploads", ffn))); //Server.MapPath("/UsersUploads/"+ UserName + fileName)
                string pfppath = "/AccountETC/UsersUploads/" + ffn; //Server.MapPath(Server.MapPath(System.IO.Path.Combine("UsersUploads", ffn)));
                //CurrUserName.InnerText = UserName; ---------------------------
                //System.Drawing.Image pfp = System.Drawing.Image.FromFile(SuMCustomPFP.PostedFile.InputStream);
                //
                using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:summangaserver.database.windows.net,1433;Initial Catalog=SuMMangaSQL;User Id=summangasqladmin;Password=55878833sqlpass#S"))
                {
                    sqlCon.Open();
                    string query = "UPDATE SuMUsersAccounts SET PFP = @SuMCustomPFP WHERE UserName = @UserName";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    //HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
                    sqlCmd.Parameters.AddWithValue("@UserName", UserName);
                    sqlCmd.Parameters.AddWithValue("@SuMCustomPFP", pfppath);
                    sqlCmd.ExecuteNonQuery();
                    //sqlCmd.Parameters.AddWithValue("@SuMCustomPFP", SqlDbType.Image).Value = imgarray;
                    sqlCon.Close();
                }
            }
        }
        protected void ChangeSIG(object sender, EventArgs e)
        {
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            string UserName = GetUserInfoCookie["UserName"].ToString();
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:summangaserver.database.windows.net,1433;Initial Catalog=SuMMangaSQL;User Id=summangasqladmin;Password=55878833sqlpass#S"))
            {
                sqlCon.Open();
                string newSignetsure = SignaturePE.Value.ToString();
                if (newSignetsure != currSignetsure && newSignetsure != null && newSignetsure != "" && newSignetsure != " ")
                {
                    string query = "UPDATE SuMUsersAccounts SET Signetsure = @Signetsure WHERE UserName = @UserName";
                    SqlCommand sqlCmd2 = new SqlCommand(query, sqlCon);
                    sqlCmd2.Parameters.AddWithValue("@UserName", UserName);
                    sqlCmd2.Parameters.AddWithValue("@Signetsure", newSignetsure);
                    sqlCmd2.ExecuteNonQuery();
                }
                sqlCon.Close();
            }
        }
        protected void ChangeEmail(object sender, EventArgs e)
        {
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            string UserName = GetUserInfoCookie["UserName"].ToString();
            string Email = EmailEP.Value.ToString();

            if (currEmail != Email)
            {
                using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:summangaserver.database.windows.net,1433;Initial Catalog=SuMMangaSQL;User Id=summangasqladmin;Password=55878833sqlpass#S"))
                {
                    string query = "UPDATE SuMUsersAccounts SET Email = @Email WHERE UserName = @UserName";
                    SqlCommand sqlCmd2 = new SqlCommand(query, sqlCon);
                    sqlCmd2.Parameters.AddWithValue("@UserName", UserName);
                    sqlCmd2.Parameters.AddWithValue("@Email", Email);
                    sqlCmd2.ExecuteNonQuery();
                    sqlCon.Close();
                }
            }
        }
    }
}