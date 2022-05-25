using System;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web;
using System.Data;

namespace SuM_Manga_V3
{
    public partial class SetMangaLibState : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string json = string.Empty;
            if (Request.QueryString["MID"] != null && Request.QueryString["CN"] != null && Request.QueryString["LIB"] != null)//  /SetMangaLibState.aspx?MID=0&SB=0/1&LIB=Fav/Wanna
            {
                HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
                if (GetUserInfoCookie != null)
                {
                    int UID = Convert.ToInt32(GetUserInfoCookie["ID"].ToString());
                    object SIDObj = GetUserInfoCookie["SID"].ToString();
                    if (SIDObj != null)
                    {
                        if (SID_State(UID, SIDObj.ToString()))
                        {
                            int MID = Convert.ToInt32(Request.QueryString["MID"].ToString());
                            int SB = Convert.ToInt32(Request.QueryString["CN"].ToString());
                            string LIB = Request.QueryString["LIB"].ToString();
                            if (LIB == "Fav" || LIB == "Wanna")
                            {
                                if (SB == 1) json = AddToX(LIB, MID, UID);
                                if (SB == 0) json = RemoveFromX(LIB, MID, UID);
                            }
                        }
                        else json = "[SESSION_EXPIRED]";
                    }
                    else json = "[SESSION_EXPIRED]";
                }
                else json = "[LOGIN_PLZ]";
            }
            else json = "0";
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
        protected private string AddToX(string lib,int MID,int UID)
        {
            bool NeedUpdate = false;
            string Target = "#" + MID.ToString() + "&";
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;
            object RawRes;
            string NewLIST = string.Empty;
            using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string qwi = "SELECT "+ lib + " FROM SuMUsersAccounts WHERE UserID = @UID";
                MySqlCommand MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                MySqlCmd00.Parameters["@UID"].Value = UID;
                RawRes = MySqlCmd00.ExecuteScalar();
                if (RawRes != null)
                {
                    if (RawRes.ToString().Contains(Target) == false)
                    {
                        NewLIST = Target + RawRes.ToString();
                        NeedUpdate = true;
                    }
                }
                if (NeedUpdate == true)
                {
                    qwi = "UPDATE SuMUsersAccounts SET "+ lib + " = @NEW WHERE UserID = @UID";
                    MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                    MySqlCmd00.Parameters.AddWithValue("@NEW", NewLIST);
                    MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                    MySqlCmd00.Parameters["@UID"].Value = UID;
                    MySqlCmd00.ExecuteNonQuery();
                }
                MySqlCon.Close();
            }
            if (!NeedUpdate) return "[NO_CHANGE_DETECTED]";
            return "1";
        }
        protected private string RemoveFromX(string lib, int MID, int UID)
        {
            object RawRes;
            string NewLIST = string.Empty;
            bool NeedUpdate = false;
            string Target = "#" + MID.ToString() + "&";
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString; using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string qwi = "SELECT "+ lib + " FROM SuMUsersAccounts WHERE UserID = @UID";
                MySqlCommand MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                MySqlCmd00.Parameters["@UID"].Value = UID;
                RawRes = MySqlCmd00.ExecuteScalar();
                if (RawRes != null)
                {
                    if (RawRes.ToString().Contains(Target) == true)
                    {
                        NewLIST = RawRes.ToString().Replace(Target, "");
                        NeedUpdate = true;
                    }
                }
                if (NeedUpdate == true)
                {
                    qwi = "UPDATE SuMUsersAccounts SET "+ lib + " = @NEWWanna WHERE UserID = @UID";
                    MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                    MySqlCmd00.Parameters.AddWithValue("@NEWWanna", NewLIST);
                    MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                    MySqlCmd00.Parameters["@UID"].Value = UID;
                    MySqlCmd00.ExecuteNonQuery();
                }
                MySqlCon.Close();
            }
            if (!NeedUpdate) return "[NO_CHANGE_DETECTED]";
            return "0";
        }
    }
}