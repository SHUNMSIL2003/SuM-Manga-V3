using System;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web;
using System.Data;

namespace SuM_Manga_V3
{
    public partial class UserBanner64String : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string json = string.Empty;
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            if (GetUserInfoCookie != null)
            {
                int UID = Convert.ToInt32(GetUserInfoCookie["ID"].ToString());
                object SIDObj = GetUserInfoCookie["SID"].ToString();
                if (SIDObj != null)
                {
                    if (SID_State(UID, SIDObj.ToString()))
                    {
                        json = GetBanner(UID);
                    }
                    else json = "[SESSION_EXPIRED]";
                }
                else json = "[SESSION_EXPIRED]";
            }
            else json = "[LOGIN_PLZ]";
            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.Write(json);
            Response.End();
        }
        protected private bool SID_State(int UID, string SID)
        {
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;
            using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string qwi = "SELECT SIDs FROM SuMUsersAccounts WHERE UserID = @UID";
                MySqlCommand MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                MySqlCmd00.Parameters["@UID"].Value = UID;
                var RawRes = MySqlCmd00.ExecuteScalar();
                if (RawRes != null)
                {
                    string Res = RawRes.ToString().Replace(" ", "");
                    if (Res.Contains(SID)) return true;
                    else return false;
                }
                else return false;
            }
        }
        protected string GetBanner(int UID)
        {
            string Result = "";
            string BannerPath = string.Empty;
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;
            using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string query = "SELECT UserBanner FROM SuMUsersAccounts WHERE UserID = " + UID+" ";
                MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
                using (var reader = MySqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        BannerPath = reader[0].ToString();
                    }
                }
                MySqlCon.Close();
            }
            byte[] imageArray = System.IO.File.ReadAllBytes(Server.MapPath("~" + BannerPath));
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);
            Result = BuildRespons(base64ImageRepresentation);
            return Result;
        }
        protected string GetBannerByPath(string Path)
        {
            string Result = "";
            string BannerPath = Path;
            byte[] imageArray = System.IO.File.ReadAllBytes(Server.MapPath("~" + BannerPath));
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);
            Result = BuildRespons(base64ImageRepresentation);
            return Result;
        }
        protected string BuildRespons(string UserBanner_64String)
        {
            return "{ " + '"' + "UserBanner64" + '"' + ": " + '"' + UserBanner_64String + '"' + " }";
        }
    }
}