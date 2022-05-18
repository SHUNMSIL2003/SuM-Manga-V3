using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;

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
                json = GetBanner(UID);
            }
            else 
            {
                json = GetBannerByPath("/assets/img/dogs/SuM-Reader.jpg");//SuM-ReadingStart.jpg
            }
            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.Write(json);
            Response.End();
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