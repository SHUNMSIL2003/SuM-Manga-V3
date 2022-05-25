using System;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web;
using System.Data;

namespace SuM_Manga_V3
{
    public partial class ClaimOneDailyCoinByADs : System.Web.UI.Page
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
                        json = SuMCoinPass(UID);
                    }
                    else json = "[SESSION_EXPIRED]";
                }
                else json = "[SESSION_EXPIRED]";
            }
            else json = "[LOGIN_PLZ]";
            Response.Clear();
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
        protected private string SuMCoinPass(int UID)
        {
            int MAX_COIN_PERDAY = 5;
            string ProssR = "0";
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;
            using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                int UCC = 0;//UserCoinsCount
                string CURRDATE = string.Empty;
                string USERCDATE = string.Empty;
                string query = "SELECT DailyAdCoinCoubt FROM SuMUsersAccounts WHERE UserID = @UID";
                MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
                MySqlCmd.Parameters.AddWithValue("@UID", SqlDbType.Int);
                MySqlCmd.Parameters["@UID"].Value = UID;
                string drfe = string.Empty;
                using (MySqlDataReader dr = MySqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (dr[0] != null)
                        {
                            if (dr[0].ToString().Replace(" ", "") != "")
                            {
                                drfe = dr[0].ToString();
                            }
                        }
                    }
                }
                string rs = drfe.ToString().Replace(" ", "");
                if (rs.Length == 9)
                {
                    UCC = Convert.ToInt32(rs[0].ToString());
                    USERCDATE = rs[1].ToString() + rs[2].ToString() + rs[3].ToString() + rs[4].ToString() + rs[5].ToString() + rs[6].ToString() + rs[7].ToString() + rs[8].ToString();
                    DateTime dateTime = DateTime.UtcNow.Date;
                    CURRDATE = dateTime.ToString("yyyy/MM/dd").Replace("/", "").Replace(" ", "");
                    if (CURRDATE != USERCDATE)
                    {
                        UCC = 0;
                        query = "UPDATE SuMUsersAccounts SET DailyAdCoinCoubt = '" + (UCC + 1).ToString() + CURRDATE + "' WHERE UserID = @UID ";
                        MySqlCmd = new MySqlCommand(query, MySqlCon);
                        MySqlCmd.Parameters.AddWithValue("@UID", SqlDbType.Int);
                        MySqlCmd.Parameters["@UID"].Value = UID;
                        MySqlCmd.ExecuteNonQuery();
                    }
                    if ((UCC + 1) < (MAX_COIN_PERDAY + 1) && CURRDATE == USERCDATE)
                    {
                        query = "UPDATE SuMUsersAccounts SET DailyAdCoinCoubt = '" + (UCC + 1).ToString() + CURRDATE + "' WHERE UserID = @UID ";
                        MySqlCmd = new MySqlCommand(query, MySqlCon);
                        MySqlCmd.Parameters.AddWithValue("@UID", SqlDbType.Int);
                        MySqlCmd.Parameters["@UID"].Value = UID;
                        MySqlCmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    UCC = 0;
                    query = "UPDATE SuMUsersAccounts SET DailyAdCoinCoubt = '" + (UCC + 1).ToString() + CURRDATE + "' WHERE UserID = @UID ";
                    MySqlCmd = new MySqlCommand(query, MySqlCon);
                    MySqlCmd.Parameters.AddWithValue("@UID", SqlDbType.Int);
                    MySqlCmd.Parameters["@UID"].Value = UID;
                    MySqlCmd.ExecuteNonQuery();
                }
                if ((UCC + 1) <= MAX_COIN_PERDAY)
                {
                    query = "UPDATE SuMUsersAccounts SET UserCoins = UserCoins + 1 WHERE UserID = @UID ";
                    MySqlCmd = new MySqlCommand(query, MySqlCon);
                    MySqlCmd.Parameters.AddWithValue("@UID", SqlDbType.Int);
                    MySqlCmd.Parameters["@UID"].Value = UID;
                    MySqlCmd.ExecuteNonQuery();
                    ProssR = "[COIN_CLAIMED_BY_AD]";
                }
                else
                {
                    ProssR = "[DAYLY_ADS_COINS_MAXED_OUT]";
                }
                MySqlCon.Close();
            }
            return ProssR;
        }
    }
}