using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace SuM_Manga_V3
{
    public partial class SuMExplore : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //LastRefreshPross();
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            if (GetUserInfoCookie != null)
            {
                int UID = Convert.ToInt32(GetUserInfoCookie["ID"].ToString());
                SussionProssINB(UID, GetUserInfoCookie["SID"].ToString());
                LoadResents(UID);
                ScriptInjectorA000.InnerHtml = "<script> androidAPIs.ShowSuMToastsOverview('welcome " + GetUserInfoCookie["UserName"].ToString() + "!'); </script>";
            }
            else 
            {
                RecentsSuperCont.Attributes["style"] = "display:none !important;";
                ScriptInjectorA000.InnerHtml = "<script> androidAPIs.ShowSuMToastsOverview('welcome to SuMManga!'); </script>";
            }
            if (!IsPostBack)
            {
                HttpCookie GetPerModeInfoCookie = Request.Cookies["SuMPerformanceMode"];
                if (GetPerModeInfoCookie != null)
                {
                    AnimatedMainContHEx.Attributes["class"] = "";
                    RecentsCont.Attributes["class"] = "";
                    Action.InnerHtml = GetFromGarnaPerMode("Action");
                    Fantasy.InnerHtml = GetFromGarnaPerMode("Fantasy");
                    Comedy.InnerHtml = GetFromGarnaPerMode("Comedy");
                    Supernatural.InnerHtml = GetFromGarnaPerMode("Supernatural");
                    SciFi.InnerHtml = GetFromGarnaPerMode("Sci-Fi");
                    Drama.InnerHtml = GetFromGarnaPerMode("Drama");
                    Mystery.InnerHtml = GetFromGarnaPerMode("Mystery");
                    SliceofLife.InnerHtml = GetFromGarnaPerMode("Slice of Life");
                }
                else
                {
                    Action.InnerHtml = GetFromGarna("Action");// Comedy
                    Fantasy.InnerHtml = GetFromGarna("Fantasy");
                    Comedy.InnerHtml = GetFromGarna("Comedy");
                    Supernatural.InnerHtml = GetFromGarna("Supernatural");
                    SciFi.InnerHtml = GetFromGarna("Sci-Fi");
                    Drama.InnerHtml = GetFromGarna("Drama");
                    Mystery.InnerHtml = GetFromGarna("Mystery");
                    SliceofLife.InnerHtml = GetFromGarna("Slice of Life");
                }
                ShowCardsCNew();
                //.InnerHtml = GetFromGarna("");
                //.InnerHtml = GetFromGarna("");
                //.InnerHtml = GetFromGarna("");
                //.InnerHtml = GetFromGarna("");
                //.InnerHtml = GetFromGarna("");
                //.InnerHtml = GetFromGarna("");
                //.InnerHtml = GetFromGarna("");
                //.InnerHtml = GetFromGarna("");
            }
        }
        protected void SussionPross(object sender, EventArgs e)
        {
            HttpCookie userInfo = Request.Cookies["SuMCurrentUser"];
            if (userInfo != null) 
            {
                string SID = userInfo["SID"].ToString();
                object CMDRs;
                using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    sqlCon.Open();
                    string qwi = "SELECT SIDs FROM SuMUsersAccounts WHERE UserID = @UID";
                    SqlCommand sqlCmd = new SqlCommand(qwi, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@UID", SqlDbType.Int);
                    sqlCmd.Parameters["@UID"].Value = Convert.ToInt32(userInfo["ID"].ToString());
                    CMDRs = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                }
                if (CMDRs != null) 
                {
                    if (CMDRs.ToString().Contains(SID) == false)
                    {
                        LogOut();
                    }
                }
                else 
                {
                    LogOut();
                }
            }
        }
        protected string[] SIDsToStringArray(string SIDs) 
        {
            Queue<string> R1 = new Queue<string>();
            bool fh = false;
            string A1 = "";
            char[] aa = SIDs.ToCharArray();
            for (int i = 0; i < aa.Length; i++)
            {
                if (aa[i] == ';')
                {
                    fh = false;
                    R1.Enqueue(A1);
                    A1 = "";
                }
                if (fh == true)
                {
                    A1 += aa[i].ToString();
                }
                if (aa[i] == '#') { fh = true; }
            }
            int RdL = R1.Count;
            string[] RS = new string[RdL];
            int RFDH = 0;
            while (R1.Count > 0)
            {
                RS[RFDH] = R1.Dequeue();
                RFDH++;
            }
            return RS;
        }
        protected void LogOut()
        {
            HttpCookie GetUserInfoCookie = new HttpCookie("SuMCurrentUser");
            GetUserInfoCookie.Expires = DateTime.Now.AddDays(-100);
            Response.Cookies.Add(GetUserInfoCookie);
        }
        protected void LoadResents(int UID)
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
                    Recent.InnerHtml = "";
                    bool PreformanceMode = false;
                    HttpCookie GetPerModeInfoCookie = Request.Cookies["SuMPerformanceMode"];
                    if (GetPerModeInfoCookie != null)
                    {
                        PreformanceMode = true;
                    }
                    using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                    {
                        sqlCon.Open();
                        object un;
                        string query = string.Empty;
                        SqlCommand sqlCmd = new SqlCommand("", sqlCon);
                        int[] MIDs = ST0(ResultFromSQL.ToString());
                        for (int i = 0; i < MIDs.Length; i++)
                        {
                            int maxidf = MIDs[i];
                            query = "SELECT MangaName FROM SuMManga WHERE MangaID = @MangaID";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = maxidf;
                            un = sqlCmd.ExecuteScalar();
                            string MTitle = un.ToString();
                            query = "SELECT CExplorerLink FROM SuMManga WHERE MangaID = @MangaID";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = maxidf;
                            un = sqlCmd.ExecuteScalar();
                            string CExplorerLink = un.ToString();
                            query = "SELECT MangaCoverLink FROM SuMManga WHERE MangaID = @MangaID";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = maxidf;
                            un = sqlCmd.ExecuteScalar();
                            string Cover = un.ToString();
                            query = "SELECT SuMThemeColor FROM SuMManga WHERE MangaID = @MangaID";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = maxidf;
                            string themecolor = sqlCmd.ExecuteScalar().ToString();
                            CExplorerLink += "&VC=" + maxidf.ToString() + "&TC=" + themecolor;
                            if (PreformanceMode == false)
                            {
                                Recent.InnerHtml += BuildRecentCard(Cover, MTitle, themecolor, CExplorerLink);
                            }
                            else
                            {
                                Recent.InnerHtml += BuildRecentCardPerMode(Cover, MTitle, themecolor, CExplorerLink);
                            }
                        }
                        sqlCon.Close();
                    }
                }
                else
                {
                    RecentsSuperCont.Attributes["style"] = "display:none !important;";
                }
            }
            else
            {
                RecentsSuperCont.Attributes["style"] = "display:none !important;";
            }
        }
        protected string BuildRecentCard(string CoverLink, string MangaTitle, string ThemeColor, string ExplorerLink)
        {
            string RS = "<div class=" + '"' + "animated fadeInRight" + '"' + " onclick=" + '"' + "SuMGoToThis('" + ExplorerLink + "','" + ThemeColor + "','" + MangaTitle.Replace("'", "") + "','ContantExplorer');" + '"' + " loading=lazy style=" + '"' + "border-radius:12px;position:relative;overflow:hidden;background-image:url(" + CoverLink + ");background-size:cover;background-position:center;width:96px;height:96px;overflow:hidden !important;margin-left:16px !important;" + '"' + "><div class=GoodBlur style=" + '"' + "background-color:" + ThemeColor + " !important;width:98px;margin-left:-1px;height:36px;position:absolute;bottom:0;border-radius:0px;overflow:hidden !important;" + '"' + "><p style=" + '"' + "margin-top:2px;height:fit-content;width:auto;max-width:112px;color:#ffffff;margin-left:6px;word-wrap:break-word;white-space:pre-wrap;word-break:break-word;text-align:center;white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" + '"' + ">" + MangaTitle + "</p></div></div>";
            return RS;
        }
        protected string BuildRecentCardPerMode(string CoverLink, string MangaTitle, string ThemeColor, string ExplorerLink)
        {
            string RS = "<div onclick=" + '"' + "SuMGoToThis('" + ExplorerLink + "','" + ThemeColor + "','" + MangaTitle.Replace("'", "") + "','ContantExplorer');" + '"' + " loading=lazy style=" + '"' + "border-radius:12px;position:relative;overflow:hidden;background-image:url(" + CoverLink + ");background-size:cover;background-position:center;width:96px;height:96px;overflow:hidden !important;margin-left:16px !important;" + '"' + "><div style=" + '"' + "background-color:" + ThemeColor + " !important;width:98px;margin-left:-1px;height:36px;position:absolute;bottom:0;border-radius:0px;overflow:hidden !important;" + '"' + "><p style=" + '"' + "margin-top:2px;height:fit-content;width:auto;max-width:112px;color:#ffffff;margin-left:6px;word-wrap:break-word;white-space:pre-wrap;word-break:break-word;text-align:center;white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" + '"' + ">" + MangaTitle + "</p></div></div>";
            return RS;
        }
        protected int[] ST0(string x)
        {
            Queue<int> R1 = new Queue<int>();
            bool fh = false;
            string A1 = "";
            char[] aa = x.ToCharArray();
            for (int i = 0; i < aa.Length; i++)
            {
                if (aa[i] == '&')
                {
                    fh = false;
                    R1.Enqueue(Convert.ToInt32(A1));
                    A1 = "";
                }
                if (fh == true)
                {
                    A1 += aa[i].ToString();
                }
                if (aa[i] == '#') { fh = true; }
            }
            int RdL = R1.Count;
            int[] RS = new int[RdL];
            int RFDH = 0;
            while (R1.Count > 0)
            {
                RS[RFDH] = R1.Dequeue();
                RFDH++;
            }
            return RS;
        }
        protected void ShowCardsCNew()
        {
            string ResultS = " ";
            int RN = 0;
            bool PreformanceMode = false;
            HttpCookie GetPerModeInfoCookie = Request.Cookies["SuMPerformanceMode"];
            if (GetPerModeInfoCookie != null)
            {
                PreformanceMode = true;
            }
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string qwi = "SELECT MAX(MangaID) FROM SuMManga";
                SqlCommand sqlCmd00 = new SqlCommand(qwi, sqlCon);
                var jdbvg = sqlCmd00.ExecuteScalar();
                if (jdbvg != null)
                {
                    int maxidf = Convert.ToInt32(jdbvg);
                    int vet = 0;
                    while (vet < 6 && maxidf > 0)
                    {
                        string Name = string.Empty;
                        string Cover = string.Empty;
                        string Disc = string.Empty;
                        string CExplorerLink = string.Empty;
                        string query = "SELECT MangaName FROM SuMManga WHERE MangaID = @MangaID";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                        sqlCmd.Parameters["@MangaID"].Value = maxidf;
                        var un = sqlCmd.ExecuteScalar();
                        if (un != null)
                        {
                            Name = un.ToString();
                            query = "SELECT MangaInfo FROM SuMManga WHERE MangaID = @MangaID";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = maxidf;
                            un = sqlCmd.ExecuteScalar();
                            Disc = un.ToString();
                            query = "SELECT CExplorerLink FROM SuMManga WHERE MangaID = @MangaID";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = maxidf;
                            un = sqlCmd.ExecuteScalar();
                            CExplorerLink = un.ToString();
                            query = "SELECT MangaCoverLink FROM SuMManga WHERE MangaID = @MangaID";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = maxidf;
                            un = sqlCmd.ExecuteScalar();
                            Cover = un.ToString();
                            query = "SELECT SuMThemeColor FROM SuMManga WHERE MangaID = @MangaID";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = maxidf;
                            string themecolor = sqlCmd.ExecuteScalar().ToString();
                            CExplorerLink += "&VC=" + maxidf.ToString() + "&TC=" + themecolor;
                            query = "SELECT MangaCreator FROM SuMManga WHERE MangaID = @MangaID";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = maxidf;
                            string MangaCReator = sqlCmd.ExecuteScalar().ToString();
                            query = "SELECT MangaViews FROM SuMManga WHERE MangaID = @MangaID";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = maxidf;
                            int Views = Convert.ToInt32(sqlCmd.ExecuteScalar().ToString());
                            query = "SELECT MangaAgeRating FROM SuMManga WHERE MangaID = @MangaID";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = maxidf;
                            string MangaAgeRating = sqlCmd.ExecuteScalar().ToString();
                            if (PreformanceMode == false)
                            {
                                ResultS += BuildCard(Cover, Name, Disc, CExplorerLink, themecolor, MangaCReator, MangaAgeRating, Views);
                            }
                            else
                            {
                                ResultS += BuildCardPerMode(Cover, Name, Disc, CExplorerLink, themecolor, MangaCReator, MangaAgeRating, Views);
                            }
                            vet++;
                            RN = vet;
                            maxidf = maxidf - 1;
                        }
                    }
                    cardstoshow.InnerHtml = ResultS;
                    cardsdots.InnerHtml = " ";
                    for (int i = 0; i < RN; i++) { cardsdots.InnerHtml += "<span class=" + "dot" + "></span> "; }
                }
                sqlCon.Close();
            }
        }
        protected string GetGarnas(int id)
        {
            string garns = " ";
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                bool IsIt = false;
                sqlCon.Open();
                string query = "SELECT Fantasy FROM SuMManga WHERE MangaID = @MangaID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = id;
                using (var reader = sqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        IsIt = reader.GetBoolean(0);
                    }
                }
                if (IsIt == true) { garns += "Fantasy, "; }

                query = "SELECT Comedy FROM SuMManga WHERE MangaID = @MangaID";
                sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = id;
                using (var reader = sqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        IsIt = reader.GetBoolean(0);
                    }
                }
                if (IsIt == true) { garns += "Comedy, "; }

                query = "SELECT Supernatural FROM SuMManga WHERE MangaID = @MangaID";
                sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = id;
                using (var reader = sqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        IsIt = reader.GetBoolean(0);
                    }
                }
                if (IsIt == true) { garns += "Supernatural, "; }

                query = "SELECT SciFi FROM SuMManga WHERE MangaID = @MangaID";
                sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = id;
                using (var reader = sqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        IsIt = reader.GetBoolean(0);
                    }
                }
                if (IsIt == true) { garns += "Sci-Fi, "; }

                query = "SELECT Drama FROM SuMManga WHERE MangaID = @MangaID";
                sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = id;
                using (var reader = sqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        IsIt = reader.GetBoolean(0);
                    }
                }
                if (IsIt == true) { garns += "Drama, "; }

                query = "SELECT Mystery FROM SuMManga WHERE MangaID = @MangaID";
                sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = id;
                using (var reader = sqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        IsIt = reader.GetBoolean(0);
                    }
                }
                if (IsIt == true) { garns += "Mystery, "; }

                query = "SELECT SliceofLife FROM SuMManga WHERE MangaID = @MangaID";
                sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = id;
                using (var reader = sqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        IsIt = reader.GetBoolean(0);
                    }
                }
                if (IsIt == true) { garns += "Slice of Life, "; }

                query = "SELECT Action FROM SuMManga WHERE MangaID = @MangaID";
                sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = id;
                using (var reader = sqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        IsIt = reader.GetBoolean(0);
                    }
                }
                if (IsIt == true) { garns += "Action, "; }

                /*query = "SELECT TYPE FROM SuMManga WHERE MangaID = @MangaID";
                sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = id;
                if (sqlCmd.ExecuteScalar() != null) { garns += "TYPE, "; }*/

                //if (garns != null) { if (garns[garns.Length - 2] == ',' && garns[garns.Length - 1] == ' ') { garns.Substring(garns.Length - 3); } }

                sqlCon.Close();
            }
            if (string.IsNullOrEmpty(garns) == false) { garns = garns.Substring(1, (garns.Length - 3)); }
            return garns;
        }
        protected string GetFromGarna(string G)
        {
            string Result = string.Empty;
            string Garna = string.Empty;
            if (G == "Action") { Garna = "Action"; }
            if (G == "Fantasy") { Garna = "Fantasy"; }
            if (G == "Comedy") { Garna = "Comedy"; }
            if (G == "Romance") { Garna = "Romance"; }
            if (G == "BL") { Garna = "BL"; }
            if (G == "GL") { Garna = "GL"; }
            if (G == "Drama") { Garna = "Drama"; }
            if (G == "Mystery") { Garna = "Mystery"; }
            if (G == "Slice of Life") { Garna = "SliceofLife"; }
            if (G == "Supernatural") { Garna = "Supernatural"; }
            if (G == "Sport") { Garna = "Sport"; }
            if (G == "Sci-Fi") { Garna = "SciFi"; }
            if (string.IsNullOrEmpty(G) == false)
            {
                using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    sqlCon.Open();
                    string Name = string.Empty;
                    string Cover = string.Empty;
                    string Disc = string.Empty;
                    string CExplorerLink = string.Empty;
                    string query = "SELECT TOP 12 MangaID from SuMManga WHERE " + Garna + " = 1  order by MangaID desc;";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    int MangaIDF = 0;
                    object un;
                    Queue<int> RawIDs = new Queue<int>();
                    using (var reader = sqlCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RawIDs.Enqueue(Convert.ToInt32(reader[0].ToString()));
                        }
                    }
                    int[] IDs = new int[RawIDs.Count];
                    int IDHELPER = 0;
                    while (RawIDs.Count > 0)
                    {
                        IDs[IDHELPER] = RawIDs.Dequeue();
                        IDHELPER++;
                    }
                    for (int i = 0; i < IDs.Length; i++)
                    {
                        MangaIDF = IDs[i];
                        query = "SELECT MangaName FROM SuMManga WHERE MangaID = @MangaID";
                        sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                        sqlCmd.Parameters["@MangaID"].Value = MangaIDF;
                        un = sqlCmd.ExecuteScalar();
                        Name = un.ToString();
                        query = "SELECT CExplorerLink FROM SuMManga WHERE MangaID = @MangaID";
                        sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                        sqlCmd.Parameters["@MangaID"].Value = MangaIDF;
                        un = sqlCmd.ExecuteScalar();
                        CExplorerLink = un.ToString();
                        CExplorerLink += "&VC=" + MangaIDF.ToString();
                        query = "SELECT MangaCoverLink FROM SuMManga WHERE MangaID = @MangaID";
                        sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                        sqlCmd.Parameters["@MangaID"].Value = MangaIDF;
                        un = sqlCmd.ExecuteScalar();
                        Cover = un.ToString();
                        query = "SELECT SuMThemeColor FROM SuMManga WHERE MangaID = @MangaID";
                        sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                        sqlCmd.Parameters["@MangaID"].Value = MangaIDF;
                        string themecolor = sqlCmd.ExecuteScalar().ToString();
                        CExplorerLink += "&TC=" + themecolor;
                        Result += BuildGCard(Cover, Name, G, CExplorerLink, themecolor, MangaIDF);
                    }
                    sqlCon.Close();
                }
            }
            else { Result = " "; }
            return Result;
        }
        protected string GetFromGarnaPerMode(string G)
        {
            string Result = string.Empty;
            string Garna = string.Empty;
            if (G == "Action") { Garna = "Action"; }
            if (G == "Fantasy") { Garna = "Fantasy"; }
            if (G == "Comedy") { Garna = "Comedy"; }
            if (G == "Romance") { Garna = "Romance"; }
            if (G == "BL") { Garna = "BL"; }
            if (G == "GL") { Garna = "GL"; }
            if (G == "Drama") { Garna = "Drama"; }
            if (G == "Mystery") { Garna = "Mystery"; }
            if (G == "Slice of Life") { Garna = "SliceofLife"; }
            if (G == "Supernatural") { Garna = "Supernatural"; }
            if (G == "Sport") { Garna = "Sport"; }
            if (G == "Sci-Fi") { Garna = "SciFi"; }
            if (string.IsNullOrEmpty(G) == false)
            {
                using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    sqlCon.Open();
                    string Name = string.Empty;
                    string Cover = string.Empty;
                    string Disc = string.Empty;
                    string CExplorerLink = string.Empty;
                    string query = "SELECT TOP 12 MangaID from SuMManga WHERE " + Garna + " = 1  order by MangaID desc;";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    int MangaIDF = 0;
                    object un;
                    Queue<int> RawIDs = new Queue<int>();
                    using (var reader = sqlCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RawIDs.Enqueue(Convert.ToInt32(reader[0].ToString()));
                        }
                    }
                    int[] IDs = new int[RawIDs.Count];
                    int IDHELPER = 0;
                    while (RawIDs.Count > 0)
                    {
                        IDs[IDHELPER] = RawIDs.Dequeue();
                        IDHELPER++;
                    }
                    for (int i = 0; i < IDs.Length; i++)
                    {
                        MangaIDF = IDs[i];
                        query = "SELECT MangaName FROM SuMManga WHERE MangaID = @MangaID";
                        sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                        sqlCmd.Parameters["@MangaID"].Value = MangaIDF;
                        un = sqlCmd.ExecuteScalar();
                        Name = un.ToString();
                        query = "SELECT CExplorerLink FROM SuMManga WHERE MangaID = @MangaID";
                        sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                        sqlCmd.Parameters["@MangaID"].Value = MangaIDF;
                        un = sqlCmd.ExecuteScalar();
                        CExplorerLink = un.ToString();
                        CExplorerLink += "&VC=" + MangaIDF.ToString();
                        query = "SELECT MangaCoverLink FROM SuMManga WHERE MangaID = @MangaID";
                        sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                        sqlCmd.Parameters["@MangaID"].Value = MangaIDF;
                        un = sqlCmd.ExecuteScalar();
                        Cover = un.ToString();
                        query = "SELECT SuMThemeColor FROM SuMManga WHERE MangaID = @MangaID";
                        sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                        sqlCmd.Parameters["@MangaID"].Value = MangaIDF;
                        string themecolor = sqlCmd.ExecuteScalar().ToString();
                        CExplorerLink += "&TC=" + themecolor;
                        Result += BuildGCard(Cover, Name, G, CExplorerLink, themecolor, MangaIDF);
                    }
                    sqlCon.Close();
                }
            }
            else { Result = " "; }
            return Result;
        }
        protected string BuildCard(string CardBG, string cardtitle, string discr0, string Link, string theme, string CraetorName, string AgeRating, int V)
        {
            char b12 = '"';
            string divclass = b12.ToString() + "mySlides pulse animated" + b12.ToString();
            string ViewsNumPart = string.Empty;
            string ViewsLPart = string.Empty;
            if (V < 1000)
            {
                ViewsNumPart = V.ToString();
                ViewsLPart = "";
            }
            if (V > 999 && V < 1000000)
            {
                double B = V / 1000.0;
                ViewsNumPart = String.Format("{0:0.00}", B);
                ViewsLPart = "K";
            }
            if (V > 999999 && V < 1000000000)
            {
                double B = V / 1000000.0;
                ViewsNumPart = String.Format("{0:0.00}", B);
                ViewsLPart = "M";
            }
            if (V > 999999999)
            {
                double B = V / 1000000000.0;
                ViewsNumPart = String.Format("{0:0.00}", B);
                ViewsLPart = "B";
            }
            string divstyle = b12.ToString() + "overflow:hidden !important;background-image:linear-gradient(" + theme + ",rgba(0,0,0,0.3)),url(" + CardBG + ") !important;background-size:cover;background-position:center !important;width:calc(100vw - 24px) !important;height:76vw;max-width:630px !important;max-height:300px !important;padding:12px;margin:0 auto !important;border-radius:12px !important;" + b12.ToString();
            string DivContant = "<div style=" + b12.ToString() + "width:calc(98% - 24px);height:fit-content;position:relative;margin:0 auto;margin-top:2px;" + b12.ToString() + ">";
            DivContant += "<h1 style=" + b12.ToString() + "float:left;margin-top:12px;margin-left:12px;color:#ffffff;font-size:178%;margin-right:14px !important;width:calc(100% - 24px) !important;height:34.17px !important;white-space:nowrap !important;overflow:hidden !important;text-overflow:ellipsis !important;" + b12.ToString() + ">" + cardtitle + "</h1>";
            DivContant += "<p style=" + b12.ToString() + "color:rgb(255, 255, 255, 0.82); float:right; margin-top:-18px; margin-right:10px;" + b12.ToString() + ">By <b style=" + "font-size:80%;" + ">" + CraetorName + "</b></p></div>";
            DivContant += "<hr style=" + b12.ToString() + "margin:0 auto !important;height:2px!important;border-width:0;color:#ffffff;background-color:#ffffff;width:80%;opacity:0.32;margin:0px;margin-block:0px;border-radius:1.3px !important;margin-bottom:4px;margin-bottom:4px !important;margin-top:-8px !important;" + b12.ToString() + " />";
            DivContant += "<p style=" + b12.ToString() + "text-align:center;height:135px;max-height:135px !important;width:calc(98% - 24px);max-width:98vw;font-size:96%;color:#ffffff;margin:4px !important;margin-bottom:6px !important;margin-top:8px !important;text-overflow:ellipsis !important;display:inline-block;overflow:hidden;" + b12.ToString() + ">" + discr0 + "</p>";
            DivContant += "<div style=" + b12.ToString() + "margin:0 auto;margin-bottom:0px;height:fit-content;width:100%;position:relative;margin-top:0px !important;" + b12.ToString() + "><a style=" + b12.ToString() + "display:block;float:right !important;margin-bottom:0px;margin-right:8px;bottom:0;position:relative;" + b12.ToString() + ">";
            DivContant += "<p style=" + b12.ToString() + "display:inline;color:rgba(255,255,255,0.74);" + b12.ToString() + "> " + AgeRating + " </p><img style=" + b12.ToString() + "width:20px;height:20px;display:inline;" + b12.ToString() + " src=" + b12.ToString() + "/svg/views.svg" + b12.ToString() + ">";
            DivContant += "<p style=" + "display:inline;color:#ffffff;" + "> " + ViewsNumPart + " </p><b style=" + "display:inline;color:#ffffff;" + ">" + ViewsLPart + "</b></a></div>";
            string result = "<div onclick=" + b12.ToString() + "SuMGoToThis('" + Link + "','" + theme + "','" + cardtitle.Replace("'", "") + "','ContantExplorer');" + b12.ToString() + " class=" + divclass + " style=" + divstyle + ">" + "<div class=" + b12.ToString() + "animated fadeIn" + b12.ToString() + " >" + DivContant + "</div>" + "</div>";
            return result;
        }
        protected string BuildCardPerMode(string CardBG, string cardtitle, string discr0, string Link, string theme, string CraetorName, string AgeRating, int V)
        {
            char b12 = '"';
            string divclass = b12.ToString() + "mySlides" + b12.ToString();
            string ViewsNumPart = string.Empty;
            string ViewsLPart = string.Empty;
            if (V < 1000)
            {
                ViewsNumPart = V.ToString();
                ViewsLPart = "";
            }
            if (V > 999 && V < 1000000)
            {
                double B = V / 1000.0;
                ViewsNumPart = String.Format("{0:0.00}", B);
                ViewsLPart = "K";
            }
            if (V > 999999 && V < 1000000000)
            {
                double B = V / 1000000.0;
                ViewsNumPart = String.Format("{0:0.00}", B);
                ViewsLPart = "M";
            }
            if (V > 999999999)
            {
                double B = V / 1000000000.0;
                ViewsNumPart = String.Format("{0:0.00}", B);
                ViewsLPart = "B";
            }
            string divstyle = b12.ToString() + "overflow:hidden !important;background-image:linear-gradient(" + theme + ",rgba(0,0,0,0.3)),url(" + CardBG + ") !important;background-size:cover;background-position:center !important;width:calc(100vw - 24px) !important;height:76vw;max-width:630px !important;max-height:300px !important;padding:12px;margin:0 auto !important;border-radius:12px !important;" + b12.ToString();
            string DivContant = "<div style=" + b12.ToString() + "width:calc(98% - 24px);height:fit-content;position:relative;margin:0 auto;margin-top:2px;" + b12.ToString() + ">";
            DivContant += "<h1 style=" + b12.ToString() + "float:left;margin-top:12px;margin-left:12px;color:#ffffff;font-size:178%;margin-right:14px !important;width:calc(100% - 24px) !important;height:34.17px !important;white-space:nowrap !important;overflow:hidden !important;text-overflow:ellipsis !important;" + b12.ToString() + ">" + cardtitle + "</h1>";
            DivContant += "<p style=" + b12.ToString() + "color:rgb(255, 255, 255, 0.82); float:right; margin-top:-18px; margin-right:10px;" + b12.ToString() + ">By <b style=" + "font-size:80%;" + ">" + CraetorName + "</b></p></div>";
            DivContant += "<hr style=" + b12.ToString() + "margin:0 auto !important;height:2px!important;border-width:0;color:#ffffff;background-color:#ffffff;width:80%;opacity:0.32;margin:0px;margin-block:0px;border-radius:1.3px !important;margin-bottom:4px;margin-bottom:4px !important;margin-top:-8px !important;" + b12.ToString() + " />";
            DivContant += "<p style=" + b12.ToString() + "text-align:center;height:135px;max-height:135px !important;width:calc(98% - 24px);max-width:98vw;font-size:96%;color:#ffffff;margin:4px !important;margin-bottom:6px !important;margin-top:8px !important;text-overflow:ellipsis !important;display:inline-block;overflow:hidden;" + b12.ToString() + ">" + discr0 + "</p>";
            DivContant += "<div style=" + b12.ToString() + "margin:0 auto;margin-bottom:0px;height:fit-content;width:100%;position:relative;margin-top:0px !important;" + b12.ToString() + "><a style=" + b12.ToString() + "display:block;float:right !important;margin-bottom:0px;margin-right:8px;bottom:0;position:relative;" + b12.ToString() + ">";
            DivContant += "<p style=" + b12.ToString() + "display:inline;color:rgba(255,255,255,0.74);" + b12.ToString() + "> " + AgeRating + " </p><img style=" + b12.ToString() + "width:20px;height:20px;display:inline;" + b12.ToString() + " src=" + b12.ToString() + "/svg/views.svg" + b12.ToString() + ">";
            DivContant += "<p style=" + "display:inline;color:#ffffff;" + "> " + ViewsNumPart + " </p><b style=" + "display:inline;color:#ffffff;" + ">" + ViewsLPart + "</b></a></div>";
            string result = "<div onclick=" + b12.ToString() + "SuMGoToThis('" + Link + "','" + theme + "','" + cardtitle.Replace("'", "") + "','ContantExplorer');" + b12.ToString() + " class=" + divclass + " style=" + divstyle + ">" + "<div >" + DivContant + "</div>" + "</div>";
            return result;
        }
        /*
        protected static string HexConverter(Color c)
        {
            return String.Format("#{0:X6}", c.ToArgb() & 0x00FFFFFF);
        }*/
        protected static string RgbConverter(Color c)
        {
            return String.Format("rgba({0},{1},{2},0.74)", c.R, c.G, c.B);
        }
        protected static Color getDominantColor(Bitmap bmp)
        {
            //Used for tally
            int r = 0;
            int g = 0;
            int b = 0;

            int total = 0;

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color clr = bmp.GetPixel(x, y);

                    r += clr.R;
                    g += clr.G;
                    b += clr.B;

                    total++;
                }
            }

            //Calculate average
            r /= total;
            g /= total;
            b /= total;

            return Color.FromArgb(r, g, b);
        }
        protected string BuildGCard(string CardBG, string cardtitle, string G, string Link, string theme, int id)
        {
            string LazyLoading = "loading=" + '"'.ToString() + "lazy" + '"'.ToString();//New
            char b12 = '"';
            string zoominanim = b12.ToString() + "fadeIn animated" + b12.ToString();
            string divs0 = "margin-left:6px;display:inline-block;height:fit-content;min-width:118px;max-width:118px;";
            string as0 = "text-decoration:none;display:inline;margin-left:6px;margin-right:6px;";//backdrop-filter:blur(1px); Down in divs2
            string divs1 = "border-radius:12px;position:relative;overflow:hidden;background-image:url(" + CardBG + ");background-size:cover;background-position:center;width:118px;height:177px";
            string divs2 = '"' + "background-color:" + theme + " !important; width:100%;height:fit-content;position:absolute;bottom:0;border-radius:8px;" + '"'; //rgb(104,64,217,0.64)
            string ps0 = "margin-top:8px;height:fit-content;width:auto;max-width:112px;color:#ffffff;margin-left:6px;word-wrap:break-word;white-space:pre-wrap;word-break:break-word;text-align:center;";
            string ps1 = "height:fit-content;width:118px;max-width:118px;font-size:69%;color:#2e2e2e;word-wrap:break-word;white-space:pre-wrap;word-break:break-word;";
            string result = "<div class=" + zoominanim + " style=" + divs0 + "><a onclick=" + b12.ToString() + "SuMGoToThis('" + Link + "','" + theme + "','" + cardtitle.Replace("'", "") + "','ContantExplorer');" + b12.ToString() + " style=" + as0 + "><div " + LazyLoading + " style=" + divs1 + "><div class=" + "GoodBlur" + " style=" + divs2 + "><p style=" + ps0 + ">" + cardtitle + "</p></div></div><p style=" + ps1 + ">" + GetGarnas(id) + "</p></a></div>"; //GetGarnas(id)
            return result;
        }
        protected string BuildGCardPerMode(string CardBG, string cardtitle, string G, string Link, string theme, int id)
        {
            string LazyLoading = "loading=" + '"'.ToString() + "lazy" + '"'.ToString();//New
            char b12 = '"';
            string divs0 = "margin-left:6px;display:inline-block;height:fit-content;min-width:118px;max-width:118px;";
            string as0 = "text-decoration:none;display:inline;margin-left:6px;margin-right:6px;";//backdrop-filter:blur(1px); Down in divs2
            string divs1 = "border-radius:12px;position:relative;overflow:hidden;background-image:url(" + CardBG + ");background-size:cover;background-position:center;width:118px;height:177px";
            string divs2 = '"' + "background-color:" + theme + "!important;width:100%;height:fit-content;position:absolute;bottom:0;border-radius:8px;" + '"'; //rgb(104,64,217,0.64)
            string ps0 = "margin-top:8px;height:fit-content;width:auto;max-width:112px;color:#ffffff;margin-left:6px;word-wrap:break-word;white-space:pre-wrap;word-break:break-word;text-align:center;";
            string ps1 = "height:fit-content;width:118px;max-width:118px;font-size:69%;color:#2e2e2e;word-wrap:break-word;white-space:pre-wrap;word-break:break-word;";
            string result = "<div style=" + divs0 + "><a onclick=" + b12.ToString() + "SuMGoToThis('" + Link + "','" + theme + "','" + cardtitle.Replace("'", "") + "','ContantExplorer');" + b12.ToString() + " style=" + as0 + "><div " + LazyLoading + " style=" + divs1 + "><div style=" + divs2 + "><p style=" + ps0 + ">" + cardtitle + "</p></div></div><p style=" + ps1 + ">" + GetGarnas(id) + "</p></a></div>"; //GetGarnas(id)
            return result;
        }
        protected void SussionProssINB(int UID, string SID)
        {
            object CMDRs;
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string qwi = "SELECT SIDs FROM SuMUsersAccounts WHERE UserID = @UID";
                SqlCommand sqlCmd = new SqlCommand(qwi, sqlCon);
                sqlCmd.Parameters.AddWithValue("@UID", SqlDbType.Int);
                sqlCmd.Parameters["@UID"].Value = UID;
                CMDRs = sqlCmd.ExecuteScalar();
                sqlCon.Close();
            }
            if (CMDRs != null)
            {
                if (CMDRs.ToString().Contains(SID) == false)
                {
                    ForceLogOut();
                }
            }
            else
            {
                ForceLogOut();
            }
        }
        protected void ForceLogOut()
        {
            HttpCookie GetUserInfoCookie = new HttpCookie("SuMCurrentUser");
            GetUserInfoCookie.Expires = DateTime.Now.AddDays(-100);
            Response.Cookies.Add(GetUserInfoCookie);
        }
        protected void LastRefreshPross()
        {
            HttpCookie GetRefreshInfoCookie = Request.Cookies["SuMMangaRefreshProssHome"];
            if (GetRefreshInfoCookie != null)
            {
                int Year = Convert.ToInt32(GetRefreshInfoCookie["LatestUpdatedYear"].ToString());
                int Month = Convert.ToInt32(GetRefreshInfoCookie["LatestUpdatedMonth"].ToString());
                int Day = Convert.ToInt32(GetRefreshInfoCookie["LatestUpdatedDay"].ToString());
                int Hour = Convert.ToInt32(GetRefreshInfoCookie["LatestUpdatedHour"].ToString());
                int CurrYear = Convert.ToInt32(DateTime.UtcNow.ToString("yyyy"));
                int CurrMonth = Convert.ToInt32(DateTime.UtcNow.ToString("MM"));
                int CurrDay = Convert.ToInt32(DateTime.UtcNow.ToString("dd"));
                int CurrHour = Convert.ToInt32(DateTime.UtcNow.ToString("HH"));
                if ((Year - CurrYear) == 0)
                {
                    if ((Month - CurrMonth) == 0)
                    {
                        if ((CurrDay - Day) > 1)
                        {
                            HttpCookie UpdateInfo = new HttpCookie("SuMMangaRefreshProssHome");
                            UpdateInfo["LatestUpdatedYear"] = DateTime.UtcNow.ToString("yyyy");
                            UpdateInfo["LatestUpdatedMonth"] = DateTime.UtcNow.ToString("MM");
                            UpdateInfo["LatestUpdatedDay"] = DateTime.UtcNow.ToString("dd");
                            UpdateInfo["LatestUpdatedHour"] = DateTime.UtcNow.ToString("HH");
                            UpdateInfo.Expires = DateTime.MaxValue;
                            HttpContext.Current.Response.Cookies.Add(UpdateInfo);
                            ReloadAndUpdate();
                        }
                    }
                    else
                    {
                        HttpCookie UpdateInfo = new HttpCookie("SuMMangaRefreshProssHome");
                        UpdateInfo["LatestUpdatedYear"] = DateTime.UtcNow.ToString("yyyy");
                        UpdateInfo["LatestUpdatedMonth"] = DateTime.UtcNow.ToString("MM");
                        UpdateInfo["LatestUpdatedDay"] = DateTime.UtcNow.ToString("dd");
                        UpdateInfo["LatestUpdatedHour"] = DateTime.UtcNow.ToString("HH");
                        UpdateInfo.Expires = DateTime.MaxValue;
                        HttpContext.Current.Response.Cookies.Add(UpdateInfo);
                        ReloadAndUpdate();
                    }
                }
                else
                {
                    HttpCookie UpdateInfo = new HttpCookie("SuMMangaRefreshProssHome");
                    UpdateInfo["LatestUpdatedYear"] = DateTime.UtcNow.ToString("yyyy");
                    UpdateInfo["LatestUpdatedMonth"] = DateTime.UtcNow.ToString("MM");
                    UpdateInfo["LatestUpdatedDay"] = DateTime.UtcNow.ToString("dd");
                    UpdateInfo["LatestUpdatedHour"] = DateTime.UtcNow.ToString("HH");
                    UpdateInfo.Expires = DateTime.MaxValue;
                    HttpContext.Current.Response.Cookies.Add(UpdateInfo);
                    ReloadAndUpdate();
                }
            }
            else
            {
                HttpCookie UpdateInfo = new HttpCookie("SuMMangaRefreshProssHome");
                UpdateInfo["LatestUpdatedYear"] = DateTime.UtcNow.ToString("yyyy");
                UpdateInfo["LatestUpdatedMonth"] = DateTime.UtcNow.ToString("MM");
                UpdateInfo["LatestUpdatedDay"] = DateTime.UtcNow.ToString("dd");
                UpdateInfo["LatestUpdatedHour"] = DateTime.UtcNow.ToString("HH");
                UpdateInfo.Expires = DateTime.MaxValue;
                HttpContext.Current.Response.Cookies.Add(UpdateInfo);
            }
        }
        protected void ReloadAndUpdate()
        {
            string CurrURL = Request.Url.ToString();
            if (CurrURL.Contains("?") == true)
            {
                Response.Redirect(Request.Url.ToString() + "&" + RandomQuryForUpdate());
            }
            else
            {
                Response.Redirect(Request.Url.ToString() + "?" + RandomQuryForUpdate());
            }
        }
        protected static string RandomQuryForUpdate()
        {
            int length = 9;
            char[] chArray = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            string str = string.Empty;
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                int index = random.Next(1, chArray.Length);
                if (!str.Contains(chArray.GetValue(index).ToString()))
                {
                    str = str + chArray.GetValue(index);
                }
                else
                {
                    i--;
                }
            }
            Random r = new Random();
            int randNum = r.Next(1000000);
            string sixDigitNumber = randNum.ToString("D6");
            str = sixDigitNumber[0] + sixDigitNumber[1] + sixDigitNumber[2] + str + sixDigitNumber[3] + sixDigitNumber[4] + sixDigitNumber[5];
            return "UPDATE=" + str;
        }
    }
}