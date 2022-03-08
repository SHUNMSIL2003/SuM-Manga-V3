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
                Link = "SuMGoToThis('" + Link + "&UCU=" + MID.ToString() + "','" + ThemeColor + "','Chapter " + CN.ToString() + "','ContantExplorer');";
            }
            else
            {
                Link += "&Chapter=ch0001&VC=" + MID + "&TC=" + ThemeColor;
                Link = "SuMGoToThis('" + Link + "&ADTCU=" + MID + "','" + ThemeColor + "','Chapter 1','ContantExplorer');";
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
    }
}