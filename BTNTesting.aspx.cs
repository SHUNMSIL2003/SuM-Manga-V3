using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Script.Services;

namespace SuM_Manga_V3
{
    public partial class BTNTesting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected static string ShowDisFSQL(int MID)
        {
            string V = string.Empty;
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string query = "SELECT MangaInfo FROM SuMManga WHERE MangaID = @MangaID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = MID;
                using (SqlDataReader dr = sqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        V = dr[0].ToString();
                    }
                }
                sqlCon.Close();
            }
            return V;
        }
        //[WebMethod(EnableSession = true)]
        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static string GetMDiscFSQL(object MID)
        {
            object RS = ShowDisFSQL(Convert.ToInt32(MID.ToString()));
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
        public static string GetMYearFSQL(int MID)
        {
            string RS = ShowMYFSQL(MID);
            return RS;
        }
        protected static string ShowMYFSQL(int MID)
        {
            string V = string.Empty;
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string query = "SELECT LastUpdateDate FROM SuMManga WHERE MangaID = @MangaID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = MID;
                using (SqlDataReader dr = sqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        V = dr[0].ToString();
                    }
                }
                sqlCon.Close();
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
        public static int GetMChapterNumFSQL(int MID)
        {
            int RS = ShowMChaptersNumFSQL(MID);
            return RS;
        }
        protected static int ShowMChaptersNumFSQL(int MID)
        {
            int V = 0;
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string query = "SELECT ChaptersNumber FROM SuMManga WHERE MangaID = @MangaID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = MID;
                using (SqlDataReader dr = sqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        V = Convert.ToInt32(dr[0].ToString());
                    }
                }
                sqlCon.Close();
            }
            return V;
        }
        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static string GetMAgeRatingFSQL(int MID)
        {
            string RS = ShowMAgeRatingFSQL(MID);
            return RS;
        }
        protected static string ShowMAgeRatingFSQL(int MID)
        {
            string V = string.Empty;
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string query = "SELECT MangaAgeRating FROM SuMManga WHERE MangaID = @MangaID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = MID;
                using (SqlDataReader dr = sqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        V = dr[0].ToString();
                    }
                }
                sqlCon.Close();
            }
            return V;
        }
        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static bool GetMIsFavFSQL(int MID, int UID)
        {
            bool SQLR = ShowFavSFSQL(MID, UID);
            return SQLR;
        }
        public static bool ShowFavSFSQL(int MID, int UID)
        {
            bool ItsAFav = false;
            object RawRes;
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string qwi = "SELECT Fav FROM SuMUsersAccounts WHERE UserID = @UID";
                SqlCommand sqlCmd00 = new SqlCommand(qwi, sqlCon);
                sqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                sqlCmd00.Parameters["@UID"].Value = UID;
                RawRes = sqlCmd00.ExecuteScalar();
                sqlCon.Close();
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
        public static bool GetMIsWannaFSQL(int MID, int UID)
        {
            bool SQLR = ShowWannaSFSQL(MID, UID);
            return SQLR;
        }
        public static bool ShowWannaSFSQL(int MID, int UID)
        {
            bool ItsAWanna = false;
            object RawRes;
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string qwi = "SELECT Wanna FROM SuMUsersAccounts WHERE UserID = @UID";
                SqlCommand sqlCmd00 = new SqlCommand(qwi, sqlCon);
                sqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                sqlCmd00.Parameters["@UID"].Value = UID;
                RawRes = sqlCmd00.ExecuteScalar();
                sqlCon.Close();
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
        public static int GetMIsCurrFSQL(int MID, int UID)
        {
            int SQLR = ShowCurrSFSQL(MID, UID);
            return SQLR;
        }
        public static int ShowCurrSFSQL(int MID, int UID)
        {
            bool ItsACurr = false;
            object RawRes;
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string qwi = "SELECT Curr FROM SuMUsersAccounts WHERE UserID = @UID";
                SqlCommand sqlCmd00 = new SqlCommand(qwi, sqlCon);
                sqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                sqlCmd00.Parameters["@UID"].Value = UID;
                RawRes = sqlCmd00.ExecuteScalar();
                sqlCon.Close();
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
        public static string GetMCurrLinkSQLWM(int MID, int CN, string ThemeColor)
        {
            string SQLR = GetCurrLinkFSQL(MID, CN, ThemeColor);
            return SQLR;
        }
        public static string GetCurrLinkFSQL(int MID, int CN, string ThemeColor)
        {
            string Link = string.Empty;
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string qwi = "SELECT CExplorerLink FROM SuMManga WHERE MangaID = @MID";
                SqlCommand sqlCmd00 = new SqlCommand(qwi, sqlCon);
                sqlCmd00.Parameters.AddWithValue("@MID", SqlDbType.Int);
                sqlCmd00.Parameters["@MID"].Value = MID;
                Link = sqlCmd00.ExecuteScalar().ToString().Replace("ContantExplorer.aspx", "MangaExplorer.aspx");
                sqlCon.Close();
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
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string qwi = "SELECT Wanna FROM SuMUsersAccounts WHERE UserID = @UID";
                SqlCommand sqlCmd00 = new SqlCommand(qwi, sqlCon);
                sqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                sqlCmd00.Parameters["@UID"].Value = UID;
                RawRes = sqlCmd00.ExecuteScalar();
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
                    sqlCmd00 = new SqlCommand(qwi, sqlCon);
                    sqlCmd00.Parameters.AddWithValue("@NEWWanna", NewLIST);
                    sqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                    sqlCmd00.Parameters["@UID"].Value = UID;
                    sqlCmd00.ExecuteNonQuery();
                }
                sqlCon.Close();
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
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string qwi = "SELECT Wanna FROM SuMUsersAccounts WHERE UserID = @UID";
                SqlCommand sqlCmd00 = new SqlCommand(qwi, sqlCon);
                sqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                sqlCmd00.Parameters["@UID"].Value = UID;
                RawRes = sqlCmd00.ExecuteScalar();
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
                    sqlCmd00 = new SqlCommand(qwi, sqlCon);
                    sqlCmd00.Parameters.AddWithValue("@NEWWanna", NewLIST);
                    sqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                    sqlCmd00.Parameters["@UID"].Value = UID;
                    sqlCmd00.ExecuteNonQuery();
                }
                sqlCon.Close();
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
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string qwi = "SELECT Fav FROM SuMUsersAccounts WHERE UserID = @UID";
                SqlCommand sqlCmd00 = new SqlCommand(qwi, sqlCon);
                sqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                sqlCmd00.Parameters["@UID"].Value = UID;
                RawRes = sqlCmd00.ExecuteScalar();
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
                    sqlCmd00 = new SqlCommand(qwi, sqlCon);
                    sqlCmd00.Parameters.AddWithValue("@NEWFav", NewLIST);
                    sqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                    sqlCmd00.Parameters["@UID"].Value = UID;
                    sqlCmd00.ExecuteNonQuery();
                }
                sqlCon.Close();
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
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string qwi = "SELECT Fav FROM SuMUsersAccounts WHERE UserID = @UID";
                SqlCommand sqlCmd00 = new SqlCommand(qwi, sqlCon);
                sqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                sqlCmd00.Parameters["@UID"].Value = UID;
                RawRes = sqlCmd00.ExecuteScalar();
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
                    sqlCmd00 = new SqlCommand(qwi, sqlCon);
                    sqlCmd00.Parameters.AddWithValue("@NEWFav", NewLIST);
                    sqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                    sqlCmd00.Parameters["@UID"].Value = UID;
                    sqlCmd00.ExecuteNonQuery();
                }
                sqlCon.Close();
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
            object ResultFromSQL;
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string qwi = "SELECT Resently FROM SuMUsersAccounts WHERE UserID = @UID";
                SqlCommand sqlCmd00 = new SqlCommand(qwi, sqlCon);
                sqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                sqlCmd00.Parameters["@UID"].Value = UID;
                ResultFromSQL = sqlCmd00.ExecuteScalar();
                sqlCon.Close();
            }
            if (ResultFromSQL != null)
            {
                if (string.IsNullOrEmpty(ResultFromSQL.ToString()) == false)
                {
                    string HTMLRS = "";
                    int[] MIDs = SuMRescrntsArray(ResultFromSQL.ToString() + "0");
                    int LS = HowMany * IndexOfSend;
                    if (LS > 32) { return "MaxAmount"; }
                    int LE = LS + HowMany;
                    if (LE > MIDs.Length) { LE = MIDs.Length - 1; }
                    if (LE > 32) { LE = 32; }
                    if (LE < 1) { return "Nothing Yet!"; }
                    using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                    {
                        sqlCon.Open();
                        object un;
                        string query = string.Empty;
                        SqlCommand sqlCmd = new SqlCommand("", sqlCon);
                        for (int i = LS; i < LE; i++)
                        {
                            query = "SELECT MangaName FROM SuMManga WHERE MangaID = @MangaID";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = MIDs[i];
                            un = sqlCmd.ExecuteScalar();
                            string MTitle = un.ToString();
                            query = "SELECT CExplorerLink FROM SuMManga WHERE MangaID = @MangaID";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = MIDs[i];
                            un = sqlCmd.ExecuteScalar();
                            string CExplorerLink = un.ToString();
                            query = "SELECT MangaCoverLink FROM SuMManga WHERE MangaID = @MangaID";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = MIDs[i];
                            un = sqlCmd.ExecuteScalar();
                            string Cover = un.ToString();
                            query = "SELECT SuMThemeColor FROM SuMManga WHERE MangaID = @MangaID";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = MIDs[i];
                            string themecolor = sqlCmd.ExecuteScalar().ToString();
                            CExplorerLink += "&VC=" + MIDs[i].ToString() + "&TC=" + themecolor;
                            HTMLRS += BuildRecentCard(Cover, MTitle, themecolor, CExplorerLink, (i + 1), MIDs[i]);
                        }
                        sqlCon.Close();
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
        public static int GetCoinsCountFSQL(object UID)
        {
            if (UID != null)
            {
                int RS = CoinsCountDSQL(Convert.ToInt32(UID.ToString()));
                return RS;
            }
            else return 0;
        }
        protected static int CoinsCountDSQL(int UID)
        {
            int V = 0;
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string query = "SELECT UserCoins FROM SuMUsersAccounts WHERE UserID = @UID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@UID", SqlDbType.Int);
                sqlCmd.Parameters["@UID"].Value = UID;
                using (SqlDataReader dr = sqlCmd.ExecuteReader())
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
                sqlCon.Close();
            }
            return V;
        }
        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static void UpdateCoinsCountFSQL(object UID, object TokensNum)
        {
            if (UID != null && TokensNum != null)
            {
                UpdateCoinsCountDSQL(Convert.ToInt32(UID.ToString()), Convert.ToInt32(TokensNum.ToString()));
            }
        }
        protected static void UpdateCoinsCountDSQL(int UID,int Token)
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string query = "UPDATE SuMUsersAccounts SET UserCoins = UserCoins + " + Token.ToString() + " WHERE UserID = @UID ";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@UID", SqlDbType.Int);
                sqlCmd.Parameters["@UID"].Value = UID;
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static int GetMangaCoinsCountFSQL(object MID)
        {
            if (MID != null)
            {
                int RS = MangaCoinsCountDSQL(Convert.ToInt32(MID.ToString()));
                return RS;
            }
            else return 0;
        }
        protected static int MangaCoinsCountDSQL(int MID)
        {
            int V = 0;
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string query = "SELECT ChapterCValue FROM SuMManga WHERE MangaID = @MID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MID", SqlDbType.Int);
                sqlCmd.Parameters["@MID"].Value = MID;
                using (SqlDataReader dr = sqlCmd.ExecuteReader())
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
                sqlCon.Close();
            }
            return V;
        }
        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static string GetMangaViewsCountFSQL(object MID)
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
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string query = "SELECT MangaViews FROM SuMManga WHERE MangaID = @MangaID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = y;
                using (SqlDataReader dr = sqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        V = Convert.ToInt32(dr[0].ToString());
                    }
                }
                sqlCon.Close();
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