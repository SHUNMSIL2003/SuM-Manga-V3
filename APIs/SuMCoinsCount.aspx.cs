using System;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web;
using System.Data;

namespace SuM_Manga_V3
{
    public partial class SuMCoinsCount : System.Web.UI.Page
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
                        json = MangaCoinsCountDMySql(UID).ToString();
                    }
                    else json = "[SESSION_EXPIRED]";
                }
                else json = "[SESSION_EXPIRED]";
            }
            else json = "[LOGIN_PLZ]";
            Response.Clear();
            //Response.ContentType = "application/json; charset=utf-8";
            //.Content = new StringContent(result, System.Text.Encoding.UTF8, "text/plain");
            Response.ContentType = "text/plain; charset=utf-8";
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
        protected static int MangaCoinsCountDMySql(int UID)
        {
            int V = 0;
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString; using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string query = "SELECT UserCoins FROM SuMUsersAccounts WHERE UserID = @UID";
                MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
                MySqlCmd.Parameters.AddWithValue("@UID", SqlDbType.Int);
                MySqlCmd.Parameters["@UID"].Value = UID;
                using (MySqlDataReader dr = MySqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (dr[0] != null)
                        {
                            if (dr[0].ToString().Replace(" ", "") != "")
                            {
                                V = Convert.ToInt32(dr[0].ToString());
                            }
                        }
                    }
                }
                MySqlCon.Close();
            }
            return V;
        }
    }
}