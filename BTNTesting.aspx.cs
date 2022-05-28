using System;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace SuM_Manga_V3
{
    public partial class BTNTesting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected static string ShowDisFMySql(int MID)
        {
            string V = string.Empty;
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string query = "SELECT MangaInfo FROM SuMManga WHERE MangaID = @MangaID";
                MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
                MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                MySqlCmd.Parameters["@MangaID"].Value = MID;
                using (MySqlDataReader dr = MySqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        V = dr[0].ToString();
                    }
                }
                MySqlCon.Close();
            }
            return V;
        }
        //[WebMethod(EnableSession = true)]
        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static string GetMDiscFMySql(object MID)
        {
            object RS = ShowDisFMySql(Convert.ToInt32(MID.ToString()));
            if (RS != null)
            {
                return RS.ToString();
            }
            else
            {
                return "Failed to load!";
            }

        }
        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static string GetMYearFMySql(int MID)
        {
            string RS = ShowMYFMySql(MID);
            return RS;
        }
        protected static string ShowMYFMySql(int MID)
        {
            string V = string.Empty;
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string query = "SELECT LastUpdateDate FROM SuMManga WHERE MangaID = @MangaID";
                MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
                MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                MySqlCmd.Parameters["@MangaID"].Value = MID;
                using (MySqlDataReader dr = MySqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        V = dr[0].ToString();
                    }
                }
                MySqlCon.Close();
            }
            if (V != null)
            {
                if (V.Length >= 4)
                {
                    return V[0].ToString() + V[1].ToString() + V[2].ToString() + V[3].ToString();
                }
                else { return "0000"; }
            }
            else { return "0000"; }
        }
        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static int GetMChapterNumFMySql(int MID)
        {
            int RS = ShowMChaptersNumFMySql(MID);
            return RS;
        }
        protected static int ShowMChaptersNumFMySql(int MID)
        {
            int V = 0;
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string query = "SELECT ChaptersNumber FROM SuMManga WHERE MangaID = @MangaID";
                MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
                MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                MySqlCmd.Parameters["@MangaID"].Value = MID;
                using (MySqlDataReader dr = MySqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        V = Convert.ToInt32(dr[0].ToString());
                    }
                }
                MySqlCon.Close();
            }
            return V;
        }
        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static string GetMAgeRatingFMySql(int MID)
        {
            string RS = ShowMAgeRatingFMySql(MID);
            return RS;
        }
        protected static string ShowMAgeRatingFMySql(int MID)
        {
            string V = string.Empty;
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string query = "SELECT MangaAgeRating FROM SuMManga WHERE MangaID = @MangaID";
                MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
                MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                MySqlCmd.Parameters["@MangaID"].Value = MID;
                using (MySqlDataReader dr = MySqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        V = dr[0].ToString();
                    }
                }
                MySqlCon.Close();
            }
            return V;
        }
        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static bool GetMIsFavFMySql(int MID, int UID)
        {
            bool MySqlR = ShowFavSFMySql(MID, UID);
            return MySqlR;
        }
        public static bool ShowFavSFMySql(int MID, int UID)
        {
            bool ItsAFav = false;
            object RawRes;
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string qwi = "SELECT Fav FROM SuMUsersAccounts WHERE UserID = @UID";
                MySqlCommand MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                MySqlCmd00.Parameters["@UID"].Value = UID;
                RawRes = MySqlCmd00.ExecuteScalar();
                MySqlCon.Close();
            }
            if (RawRes != null)
            {
                if (RawRes.ToString().Contains("#" + MID + "&") == true)
                {
                    ItsAFav = true;
                }
            }
            return ItsAFav;
        }
        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static bool GetMIsWannaFMySql(int MID, int UID)
        {
            bool MySqlR = ShowWannaSFMySql(MID, UID);
            return MySqlR;
        }
        public static bool ShowWannaSFMySql(int MID, int UID)
        {
            bool ItsAWanna = false;
            object RawRes;
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string qwi = "SELECT Wanna FROM SuMUsersAccounts WHERE UserID = @UID";
                MySqlCommand MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                MySqlCmd00.Parameters["@UID"].Value = UID;
                RawRes = MySqlCmd00.ExecuteScalar();
                MySqlCon.Close();
            }
            if (RawRes != null)
            {
                if (RawRes.ToString().Contains("#" + MID + "&") == true)
                {
                    ItsAWanna = true;
                }
            }
            return ItsAWanna;
        }
        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static int GetMIsCurrFMySql(int MID, int UID)
        {
            int MySqlR = ShowCurrSFMySql(MID, UID);
            return MySqlR;
        }
        public static int ShowCurrSFMySql(int MID, int UID)
        {
            bool ItsACurr = false;
            object RawRes;
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string qwi = "SELECT Curr FROM SuMUsersAccounts WHERE UserID = @UID";
                MySqlCommand MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                MySqlCmd00.Parameters["@UID"].Value = UID;
                RawRes = MySqlCmd00.ExecuteScalar();
                MySqlCon.Close();
            }
            if (RawRes != null)
            {
                if (RawRes.ToString().Contains("#" + MID + ";") == true)
                {
                    ItsACurr = true;
                }
            }
            if (ItsACurr == true)
            {
                return GetChapterNumInCurr(RawRes.ToString(), MID);
            }
            else
            {
                return 0;
            }
        }
        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static string GetMCurrLinkMySqlWM(int MID, int CN, string ThemeColor)
        {
            string MySqlR = GetCurrLinkFMySql(MID, CN, ThemeColor);
            return MySqlR;
        }
        public static string GetCurrLinkFMySql(int MID, int CN, string ThemeColor)
        {
            string Link = string.Empty;
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string qwi = "SELECT CExplorerLink FROM SuMManga WHERE MangaID = @MID";
                MySqlCommand MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                MySqlCmd00.Parameters.AddWithValue("@MID", SqlDbType.Int);
                MySqlCmd00.Parameters["@MID"].Value = MID;
                Link = MySqlCmd00.ExecuteScalar().ToString().Replace("ContantExplorer.aspx", "MangaExplorer.aspx");
                MySqlCon.Close();
            }
            string PCS = string.Empty;
            PCS = CN.ToString();
            if (PCS.Length == 1) { PCS = "000" + PCS; }
            if (PCS.Length == 2) { PCS = "00" + PCS; }
            if (PCS.Length == 3) { PCS = "0" + PCS; }
            if (CN > 0)
            {
                Link += "&Chapter=ch" + PCS + "&VC=" + MID + "&TC=" + ThemeColor;
                Link = "SuMGoToThis('" + Link + "&UCU=" + MID.ToString() + "','" + ThemeColor + "','Chapter " + CN.ToString() + "','MangaExplorer');";
            }
            else
            {
                Link += "&Chapter=ch0001&VC=" + MID + "&TC=" + ThemeColor;
                Link = "SuMGoToThis('" + Link + "&ADTCU=" + MID + "','" + ThemeColor + "','Chapter 1','MangaExplorer');";
            }
            return Link;
        }
        protected static int GetChapterNumInCurr(string RawCurr, int RqID)
        {
            int RS = 0;
            string[] CurrPross = RawCurr.Split('&');
            for (int i = 0; i < CurrPross.Length; i++)
            {
                if (CurrPross[i].Contains("#" + RqID + ";") == true)
                {
                    RS = Convert.ToInt32(CurrPross[i].Replace("#" + RqID + ";", ""));
                    i = CurrPross.Length;
                }
            }
            return RS;
        }
        //Settings Options -s
        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static void AddToWannaWM(int MID, int UID)
        {
            AddToWannaList(MID, UID);
        }
        protected static void AddToWannaList(int MID, int UID)
        {
            object RawRes;
            string NewLIST = string.Empty;
            bool NeedUpdate = false;
            string Target = "#" + MID.ToString() + "&";
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string qwi = "SELECT Wanna FROM SuMUsersAccounts WHERE UserID = @UID";
                MySqlCommand MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                MySqlCmd00.Parameters["@UID"].Value = UID;
                RawRes = MySqlCmd00.ExecuteScalar();
                if (RawRes != null)
                {
                    if (RawRes.ToString().Contains(Target) == false)
                    {
                        NewLIST = RawRes.ToString() + Target;
                        NeedUpdate = true;
                    }
                }
                if (NeedUpdate == true)
                {
                    qwi = "UPDATE SuMUsersAccounts SET Wanna = @NEWWanna WHERE UserID = @UID";
                    MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                    MySqlCmd00.Parameters.AddWithValue("@NEWWanna", NewLIST);
                    MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                    MySqlCmd00.Parameters["@UID"].Value = UID;
                    MySqlCmd00.ExecuteNonQuery();
                }
                MySqlCon.Close();
            }
        }
        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static void RemoveFromWannaWM(int MID, int UID)
        {
            RemoveFromWannaList(MID, UID);
        }
        protected static void RemoveFromWannaList(int MID, int UID)
        {
            object RawRes;
            string NewLIST = string.Empty;
            bool NeedUpdate = false;
            string Target = "#" + MID.ToString() + "&";
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string qwi = "SELECT Wanna FROM SuMUsersAccounts WHERE UserID = @UID";
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
                    qwi = "UPDATE SuMUsersAccounts SET Wanna = @NEWWanna WHERE UserID = @UID";
                    MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                    MySqlCmd00.Parameters.AddWithValue("@NEWWanna", NewLIST);
                    MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                    MySqlCmd00.Parameters["@UID"].Value = UID;
                    MySqlCmd00.ExecuteNonQuery();
                }
                MySqlCon.Close();
            }
        }
        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static void AddToFavWM(int MID, int UID)
        {
            AddToFavList(MID, UID);
        }
        protected static void AddToFavList(int MID, int UID)
        {
            object RawRes;
            string NewLIST = string.Empty;
            bool NeedUpdate = false;
            string Target = "#" + MID.ToString() + "&";
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string qwi = "SELECT Fav FROM SuMUsersAccounts WHERE UserID = @UID";
                MySqlCommand MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                MySqlCmd00.Parameters["@UID"].Value = UID;
                RawRes = MySqlCmd00.ExecuteScalar();
                if (RawRes != null)
                {
                    if (RawRes.ToString().Contains(Target) == false)
                    {
                        NewLIST = RawRes.ToString() + Target;
                        NeedUpdate = true;
                    }
                }
                if (NeedUpdate == true)
                {
                    qwi = "UPDATE SuMUsersAccounts SET Fav = @NEWFav WHERE UserID = @UID";
                    MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                    MySqlCmd00.Parameters.AddWithValue("@NEWFav", NewLIST);
                    MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                    MySqlCmd00.Parameters["@UID"].Value = UID;
                    MySqlCmd00.ExecuteNonQuery();
                }
                MySqlCon.Close();
            }
        }
        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static void RemoveFromFavWM(int MID, int UID)
        {
            RemoveFromFavList(MID, UID);
        }
        protected static void RemoveFromFavList(int MID, int UID)
        {
            object RawRes;
            string NewLIST = string.Empty;
            bool NeedUpdate = false;
            string Target = "#" + MID.ToString() + "&";
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string qwi = "SELECT Fav FROM SuMUsersAccounts WHERE UserID = @UID";
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
                    qwi = "UPDATE SuMUsersAccounts SET Fav = @NEWFav WHERE UserID = @UID";
                    MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                    MySqlCmd00.Parameters.AddWithValue("@NEWFav", NewLIST);
                    MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                    MySqlCmd00.Parameters["@UID"].Value = UID;
                    MySqlCmd00.ExecuteNonQuery();
                }
                MySqlCon.Close();
            }
        }
        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static string GetLoadResents(int UID, int HowMany, int IndexOfSend)
        {
            return LoadResents(UID, HowMany, IndexOfSend);
        }
        protected static string LoadResents(int UID, int HowMany, int IndexOfSend)
        {
            object ResultFromMySql;
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string qwi = "SELECT Resently FROM SuMUsersAccounts WHERE UserID = @UID";
                MySqlCommand MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                MySqlCmd00.Parameters["@UID"].Value = UID;
                ResultFromMySql = MySqlCmd00.ExecuteScalar();
                MySqlCon.Close();
            }
            if (ResultFromMySql != null)
            {
                if (string.IsNullOrEmpty(ResultFromMySql.ToString()) == false)
                {
                    string HTMLRS = "";
                    int[] MIDs = SuMRescrntsArray(ResultFromMySql.ToString() + "0");
                    int LS = HowMany * IndexOfSend;
                    if (LS > 32) { return "MaxAmount"; }
                    int LE = LS + HowMany;
                    if (LE > MIDs.Length) { LE = MIDs.Length - 1; }
                    if (LE > 32) { LE = 32; }
                    if (LE < 1) { return "Nothing Yet!"; }
                    //string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;
                    using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
                    {
                        MySqlCon.Open();
                        object un;
                        string query = string.Empty;
                        MySqlCommand MySqlCmd = new MySqlCommand("", MySqlCon);
                        for (int i = LS; i < LE; i++)
                        {
                            query = "SELECT MangaName FROM SuMManga WHERE MangaID = @MangaID";
                            MySqlCmd = new MySqlCommand(query, MySqlCon);
                            MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            MySqlCmd.Parameters["@MangaID"].Value = MIDs[i];
                            un = MySqlCmd.ExecuteScalar();
                            string MTitle = un.ToString();
                            query = "SELECT CExplorerLink FROM SuMManga WHERE MangaID = @MangaID";
                            MySqlCmd = new MySqlCommand(query, MySqlCon);
                            MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            MySqlCmd.Parameters["@MangaID"].Value = MIDs[i];
                            un = MySqlCmd.ExecuteScalar();
                            string CExplorerLink = un.ToString();
                            query = "SELECT MangaCoverLink FROM SuMManga WHERE MangaID = @MangaID";
                            MySqlCmd = new MySqlCommand(query, MySqlCon);
                            MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            MySqlCmd.Parameters["@MangaID"].Value = MIDs[i];
                            un = MySqlCmd.ExecuteScalar();
                            string Cover = un.ToString();
                            query = "SELECT SuMThemeColor FROM SuMManga WHERE MangaID = @MangaID";
                            MySqlCmd = new MySqlCommand(query, MySqlCon);
                            MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            MySqlCmd.Parameters["@MangaID"].Value = MIDs[i];
                            string themecolor = MySqlCmd.ExecuteScalar().ToString();
                            CExplorerLink += "&VC=" + MIDs[i].ToString() + "&TC=" + themecolor;
                            HTMLRS += BuildRecentCard(Cover, MTitle, themecolor, CExplorerLink, (i + 1), MIDs[i]);
                        }
                        MySqlCon.Close();
                    }
                    return HTMLRS;
                }
                else
                {
                    return "Failed To load!";
                }
            }
            else
            {
                return "Failed To load!";
            }
        }
        protected static string BuildRecentCard(string CoverLink, string MangaTitle, string ThemeColor, string ExplorerLink, int Num, int MangaID)
        {
            string RS = "<div class=" + '"' + "animated fadeInRight" + '"' + " onclick=" + '"' + "SuMApplyInfoToUltraCard('" + MangaID + "', '" + CoverLink + "', '" + MangaTitle.Replace("'", "") + "', '" + ExplorerLink + "', 'ContantExplorer', '" + MangaTitle.Replace("'", "") + "', '" + ThemeColor + "');" + '"' + " loading=lazy style=" + '"' + "border-radius:12px;position:relative;overflow:hidden;background-image:url(" + CoverLink + ");background-size:cover;background-position:center;width:96px;height:96px;overflow:hidden !important;margin-left:16px !important;" + '"' + "><div id=RecentItem" + Num.ToString() + " class=GoodBlur style=" + '"' + "background-color:" + ThemeColor + " !important;width:98px;margin-left:-1px;height:36px;position:absolute;bottom:0;border-radius:0px;overflow:hidden !important;" + '"' + "><p style=" + '"' + "margin-top:2px;height:fit-content;width:auto;max-width:112px;color:#ffffff;margin-left:6px;word-wrap:break-word;white-space:pre-wrap;word-break:break-word;text-align:center;white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" + '"' + ">" + MangaTitle + "</p></div></div>";
            return RS;
        }
        protected static int[] SuMRescrntsArray(string X)
        {
            int[] myInts = Array.ConvertAll(X.Replace("#", "").Split('&'), s => int.Parse(s));
            return myInts;
        }
        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static int GetCoinsCountFMySql(object UID)
        {
            if (UID != null)
            {
                int RS = CoinsCountDMySql(Convert.ToInt32(UID.ToString()));
                return RS;
            }
            else return 0;
        }
        protected static int CoinsCountDMySql(int UID)
        {
            int V = 0;
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
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
        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static void UpdateCoinsCountFMySql(object UID, object TokensNum)
        {
            if (UID != null && TokensNum != null)
            {
                UpdateCoinsCountDMySql(Convert.ToInt32(UID.ToString()), Convert.ToInt32(TokensNum.ToString()));
            }
        }
        protected static void UpdateCoinsCountDMySql(int UID,int Token)
        {
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string query = "UPDATE SuMUsersAccounts SET UserCoins = UserCoins + " + Token.ToString() + " WHERE UserID = @UID ";
                MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
                MySqlCmd.Parameters.AddWithValue("@UID", SqlDbType.Int);
                MySqlCmd.Parameters["@UID"].Value = UID;
                MySqlCmd.ExecuteNonQuery();
                MySqlCon.Close();
            }
        }
        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static int GetMangaCoinsCountFMySql(object MID)
        {
            if (MID != null)
            {
                int RS = MangaCoinsCountDMySql(Convert.ToInt32(MID.ToString()));
                return RS;
            }
            else return 0;
        }
        protected static int MangaCoinsCountDMySql(int MID)
        {
            int V = 0;
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string query = "SELECT ChapterCValue FROM SuMManga WHERE MangaID = @MID";
                MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
                MySqlCmd.Parameters.AddWithValue("@MID", SqlDbType.Int);
                MySqlCmd.Parameters["@MID"].Value = MID;
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
        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static string GetMangaViewsCountFMySql(object MID)
        {
            if (MID != null)
            {
                string RS = ShowViews(Convert.ToInt32(MID.ToString()));
                return RS;
            }
            else return "failed!";
        }
        protected static string ShowViews(int y)
        {
            string parta = string.Empty;
            string partb = string.Empty;
            int V = 0;
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string query = "SELECT MangaViews FROM SuMManga WHERE MangaID = @MangaID";
                MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
                MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                MySqlCmd.Parameters["@MangaID"].Value = y;
                using (MySqlDataReader dr = MySqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        V = Convert.ToInt32(dr[0].ToString());
                    }
                }
                MySqlCon.Close();
            }
            if (V < 1000)
            {
                parta = V.ToString();
                partb = "";
            }
            if (V > 999 && V < 1000000)
            {
                double B = V / 1000.0;
                parta = String.Format("{0:0.00}", B);
                partb = "K";
            }
            if (V > 999999 && V < 1000000000)
            {
                double B = V / 1000000.0;
                parta = String.Format("{0:0.00}", B);
                partb = "M";
            }
            if (V > 999999999)
            {
                double B = V / 1000000000.0;
                parta = String.Format("{0:0.00}", B);
                partb = "B";
            }
            return parta + partb;

        }
    }
}