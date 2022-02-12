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
    public partial class Hits : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadTop10();
            Action.InnerHtml = GetFromGarna("Action");
            Fantasy.InnerHtml = GetFromGarna("Fantasy");
            Comedy.InnerHtml = GetFromGarna("Comedy");
            Supernatural.InnerHtml = GetFromGarna("Supernatural");
            SciFi.InnerHtml = GetFromGarna("Sci-Fi");
            Drama.InnerHtml = GetFromGarna("Drama");
            Mystery.InnerHtml = GetFromGarna("Mystery");
            SliceofLife.InnerHtml = GetFromGarna("Slice of Life");
        }
        protected void LoadTop10()
        {
            Top10Con.InnerHtml = "";
            bool PreformanceMode = false;
            HttpCookie GetPerModeInfoCookie = Request.Cookies["SuMPerformanceMode"];
            if (GetPerModeInfoCookie != null)
            {
                PreformanceMode = true;
            }
            string[] tHEMEcOLORS = new string[10];
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string Name = string.Empty;
                string Cover = string.Empty;
                string Disc = string.Empty;
                string CExplorerLink = string.Empty;
                int views = 0;
                string AgeRating = string.Empty;
                string query = "SELECT TOP 10 MangaID from SuMManga order by MangaViews desc;";
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
                    query = "SELECT MangaViews FROM SuMManga WHERE MangaID = @MangaID";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    sqlCmd.Parameters["@MangaID"].Value = MangaIDF;
                    un = sqlCmd.ExecuteScalar();
                    views = Convert.ToInt32(un.ToString());
                    query = "SELECT MangaAgeRating FROM SuMManga WHERE MangaID = @MangaID";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    sqlCmd.Parameters["@MangaID"].Value = MangaIDF;
                    un = sqlCmd.ExecuteScalar();
                    AgeRating = un.ToString();
                    query = "SELECT MangaInfo FROM SuMManga WHERE MangaID = @MangaID";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    sqlCmd.Parameters["@MangaID"].Value = MangaIDF;
                    un = sqlCmd.ExecuteScalar();
                    Disc = un.ToString();
                    if (PreformanceMode == false)
                    {
                        Top10Con.InnerHtml += BuildTopCard(i + 1, themecolor, Cover, Name, Disc, AgeRating, views, CExplorerLink);
                    }
                    else
                    {
                        Top10Con.InnerHtml += BuildTopCardPerMode(i + 1, themecolor, Cover, Name, Disc, AgeRating, views, CExplorerLink);
                    }
                    tHEMEcOLORS[i] = themecolor;
                }
                sqlCon.Close();
            }
            if (PreformanceMode == false)
            {
                HitsStylePlaceHolder.InnerHtml = "<style> #HitsBG { animation: rainbow 12s linear infinite; } @keyframes rainbow { 0% { background-color: " + tHEMEcOLORS[0] + "; } 10% { background-color: " + tHEMEcOLORS[0] + "; } 20% { background-color: " + tHEMEcOLORS[1] + "; } 30% { background-color: " + tHEMEcOLORS[2] + "; } 40% { background-color: " + tHEMEcOLORS[3] + "; } 50% { background-color: " + tHEMEcOLORS[4] + "; } 60% { background-color: " + tHEMEcOLORS[5] + "; } 70% { background-color: " + tHEMEcOLORS[6] + "; } 80% { background-color: " + tHEMEcOLORS[7] + "; } 90% { background-color: " + tHEMEcOLORS[8] + "; } 100% { background-color: " + tHEMEcOLORS[9] + "; } } </style>";
            }
            else
            {
                ScrollingDivHits.Attributes["class"] = "";
                HotsScrollHelper.Attributes["style"] = "background-color:#ffffff;margin:0 auto !important;padding:0px;width:100%;height:fit-content;border-bottom-left-radius:20px !important;border-bottom-right-radius:20px !important;display:block !important;transition:none !important;";
                HitsStylePlaceHolder.InnerHtml = "<style> #HitsBG { background-color:rgba(104,64,217,0.74); } </style>";
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
                HttpCookie GetPerModeInfoCookie = Request.Cookies["SuMPerformanceMode"];
                bool PreformanceMode = false;
                if (GetPerModeInfoCookie != null)
                {
                    PreformanceMode = true;
                }
                using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    sqlCon.Open();
                    string Name = string.Empty;
                    string Cover = string.Empty;
                    string Disc = string.Empty;
                    string CExplorerLink = string.Empty;
                    string query = "SELECT TOP 10 MangaID from SuMManga WHERE " + Garna + " = 1  order by MangaViews desc;";
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
                        if (PreformanceMode == false)
                        {
                            Result += BuildGCard(Cover, Name, G, CExplorerLink, themecolor, MangaIDF);
                        }
                        else
                        {
                            Result += BuildGCardPreMode(Cover, Name, G, CExplorerLink, themecolor, MangaIDF);
                        }
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
        protected string BuildTopCard(int Num, string ThemeColor, string CoverURL, string ManagTitle, string ManagDisc, string AgeRating, int views, string ManagLink)
        {
            string ViewsNumPart = string.Empty;
            string ViewsLPart = string.Empty;
            if (views < 1000)
            {
                ViewsNumPart = views.ToString();
                ViewsLPart = "";
            }
            if (views > 999 && views < 1000000)
            {
                double B = views / 1000.0;
                ViewsNumPart = String.Format("{0:0.00}", B);
                ViewsLPart = "K";
            }
            if (views > 999999 && views < 1000000000)
            {
                double B = views / 1000000.0;
                ViewsNumPart = String.Format("{0:0.00}", B);
                ViewsLPart = "M";
            }
            if (views > 999999999)
            {
                double B = views / 1000000000.0;
                ViewsNumPart = String.Format("{0:0.00}", B);
                ViewsLPart = "B";
            }
            string HerfingCode = "onclick=" + '"' + "SuMGoToThis('" + ManagLink + "','" + ThemeColor + "','" + ManagTitle.Replace("'", "") + "','ContantExplorer');" + '"';
            string ExpandingCode = "onclick=" + '"' + "ExpandControler" + Num.ToString() + "()" + '"';
            string NewPart = "<div " + HerfingCode + " style=width:fit-contant;height:fit-contant; > <div style=display:inline-block; > <img src=/svg/ExploreBook.svg style=" + "margin-left:8px;margin-right:6px !important;pointer-events:all !important;" + " height=26 width=26 class=" + "animated pulse" + " >  <p style=" + '"' + "color:#FFFFFFAD !important;font-size:76%;margin-right:12px !important;display:inline !important;" + '"' + " class=" + '"' + "animated pulse" + '"' + "><b>Explore manga</b></p> </div> </div>";
            string RS = "<div id=NuM" + Num.ToString() + " style=" + '"' + "padding:12px;padding-top:22px;padding-bottom:22px;background-image:linear-gradient(" + ThemeColor + ", rgba(0, 0, 0, 0.3)), url(" + CoverURL + ") !important;background-size: cover;background-position: center center !important;height:0px;width:100%;overflow:hidden;" + '"' + "> <div style=" + '"' + "height:fit-content;width:100%;margin:0 auto !important;display:inline !important;position:relative;" + '"' + "> <div style=height:fit-content;margin-top:-26px; id=NuM" + Num.ToString() + "Expandor " + ExpandingCode + " ><p style=" + '"' + "float:right;margin-top:8px;margin-right:8px;font-size:240%;color:rgba(255,255,255,0.86);" + '"' + ">#" + Num.ToString() + "</p> <p id=NuM" + Num.ToString() + "Title style=" + '"' + "font-size:160%;color:#ffffff;width:calc(100% - 90px);overflow:hidden;margin-top:18px;height:fit-content;" + '"' + ">" + ManagTitle + "</p></div><div id=NuM" + Num.ToString() + "CardRest style=display:none;animation-duration:0.3s; class=" + '"' + "animated fadeInDown" + '"' + " > <div style=" + '"' + "border-radius:18px;background-color:" + ThemeColor.Replace("0.74", "0.94") + ";padding-top:26px;padding-left:18px;padding-right:18px;margin-bottom:32px;" + '"' + " > <p id=NuM" + Num.ToString() + "Disc style=" + '"' + "width:100%;overflow:hidden;font-size:92%;color:rgba(255,255,255,0.98);text-align:center;height:fit-content;" + '"' + ">" + ManagDisc + "</p> <div style=width:fit-content;float:right;margin-bottom:18px;margin-top:8px;> <p style=display:inline;color:rgba(255,255,255,0.74);>" + AgeRating + "</p> <img style=width:20px;height:20px;display:inline; src=" + '"' + "/svg/views.svg" + '"' + "> <p  style=display:inline;color:#ffffff;>" + ViewsNumPart + "</p> <b style=display:inline;color:#ffffff;>" + ViewsLPart + "</b> </div> " + NewPart + " </div> </div> </div> " + "<p style=display:none; id=Top" + Num + "ThemeColor >" + ThemeColor + "</p>" + " </div>";
            return RS;
        }
        protected string BuildTopCardPerMode(int Num, string ThemeColor, string CoverURL, string ManagTitle, string ManagDisc, string AgeRating, int views, string ManagLink)
        {
            string ViewsNumPart = string.Empty;
            string ViewsLPart = string.Empty;
            if (views < 1000)
            {
                ViewsNumPart = views.ToString();
                ViewsLPart = "";
            }
            if (views > 999 && views < 1000000)
            {
                double B = views / 1000.0;
                ViewsNumPart = String.Format("{0:0.00}", B);
                ViewsLPart = "K";
            }
            if (views > 999999 && views < 1000000000)
            {
                double B = views / 1000000.0;
                ViewsNumPart = String.Format("{0:0.00}", B);
                ViewsLPart = "M";
            }
            if (views > 999999999)
            {
                double B = views / 1000000000.0;
                ViewsNumPart = String.Format("{0:0.00}", B);
                ViewsLPart = "B";
            }
            string HerfingCode = "onclick=" + '"' + "SuMGoToThis('" + ManagLink + "','" + ThemeColor + "','" + ManagTitle.Replace("'", "") + "','ContantExplorer');" + '"';
            string ExpandingCode = "onclick=" + '"' + "ExpandControler" + Num.ToString() + "()" + '"';
            string NewPart = "<div " + HerfingCode + " style=width:fit-contant;height:fit-contant; > <div style=display:inline-block; > <img src=/svg/ExploreBook.svg style=" + "margin-left:8px;margin-right:6px !important;pointer-events:all !important;" + " height=26 width=26 >  <p style=" + '"' + "color:#FFFFFFAD !important;font-size:76%;margin-right:12px !important;display:inline !important;" + '"' + " ><b>Explore manga</b></p> </div> </div>";
            string RS = "<div id=NuM" + Num.ToString() + " style=" + '"' + "padding:12px;padding-top:22px;padding-bottom:22px;background-image:linear-gradient(" + ThemeColor + ", rgba(0, 0, 0, 0.3)), url(" + CoverURL + ") !important;background-size: cover;background-position: center center !important;height:0px;width:100%;overflow:hidden;transition:none !important;" + '"' + "> <div style=" + '"' + "height:fit-content;width:100%;margin:0 auto !important;display:inline !important;position:relative;" + '"' + "> <div style=" + '"' + "height:fit-content;margin-top:-26px;transition:none !important;" + '"' + " id=NuM" + Num.ToString() + "Expandor " + ExpandingCode + " ><p style=" + '"' + "float:right;margin-top:8px;margin-right:8px;font-size:240%;color:rgba(255,255,255,0.86);" + '"' + ">#" + Num.ToString() + "</p> <p id=NuM" + Num.ToString() + "Title style=" + '"' + "font-size:160%;color:#ffffff;width:calc(100% - 90px);overflow:hidden;margin-top:18px;height:fit-content;" + '"' + ">" + ManagTitle + "</p></div><div id=NuM" + Num.ToString() + "CardRest style=display:none; class=" + '"' + "fadeInDown" + '"' + " > <div style=" + '"' + "border-radius:18px;background-color:" + ThemeColor.Replace("0.74", "0.94") + ";padding-top:26px;padding-left:18px;padding-right:18px;margin-bottom:32px;" + '"' + " > <p id=NuM" + Num.ToString() + "Disc style=" + '"' + "width:100%;overflow:hidden;font-size:92%;color:rgba(255,255,255,0.8);text-align:center;height:fit-content;" + '"' + ">" + ManagDisc + "</p> <div style=width:fit-content;float:right;margin-bottom:18px;margin-top:8px;> <p style=display:inline;color:rgba(255,255,255,0.74);>" + AgeRating + "</p> <img style=width:20px;height:20px;display:inline; src=" + '"' + "/svg/views.svg" + '"' + "> <p  style=display:inline;color:#ffffff;>" + ViewsNumPart + "</p> <b style=display:inline;color:#ffffff;>" + ViewsLPart + "</b> </div> " + NewPart + "</div> </div> </div> " + "<p style=display:none;visibility:hidden; id=Top" + Num + "ThemeColor >" + ThemeColor + "</p>" + " </div>";
            return RS;
        }
        protected string BuildGCard(string CardBG, string cardtitle, string G, string Link, string theme, int id)
        {
            string LazyLoading = "loading=" + '"'.ToString() + "lazy" + '"'.ToString();//New
            char b12 = '"';
            string zoominanim = b12.ToString() + "fadeIn animated" + b12.ToString();
            string divs0 = "margin-left:6px;display:inline-block;height:fit-content;min-width:118px;max-width:118px;";
            string as0 = "text-decoration:none;display:inline;margin-left:6px;margin-right:6px;";//backdrop-filter:blur(1px); Down in divs2
            string divs1 = "border-radius:12px;position:relative;overflow:hidden;background-image:url(" + CardBG + ");background-size:cover;background-position:center;width:118px;height:177px";
            string divs2 = '"' + "background-color:" + theme + "!important; width:100%;height:fit-content;position:absolute;bottom:0;border-radius:8px;" + '"'; //rgb(104,64,217,0.64)
            string ps0 = "margin-top:8px;height:fit-content;width:auto;max-width:112px;color:#ffffff;margin-left:6px;word-wrap:break-word;white-space:pre-wrap;word-break:break-word;text-align:center;";
            string ps1 = "height:fit-content;width:118px;max-width:118px;font-size:69%;color:#2e2e2e;word-wrap:break-word;white-space:pre-wrap;word-break:break-word;";
            string result = "<div class=" + zoominanim + " style=" + divs0 + "><a onclick=" + b12.ToString() + "SuMGoToThis('" + Link + "','" + theme + "','" + cardtitle.Replace("'", "") + "','ContantExplorer');" + b12.ToString() + " style=" + as0 + "><div " + LazyLoading + " style=" + divs1 + "><div class=" + "GoodBlur" + " style=" + divs2 + "><p style=" + ps0 + ">" + cardtitle + "</p></div></div><p style=" + ps1 + ">" + GetGarnas(id) + "</p></a></div>"; //GetGarnas(id)
            return result;
        }
        protected string BuildGCardPreMode(string CardBG, string cardtitle, string G, string Link, string theme, int id)
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
        protected void SussionPross()
        {
            HttpCookie userInfo = Request.Cookies["SuMCurrentUser"];
            if (userInfo != null)
            {
                string SID = userInfo["SID"].ToString();
                int UID = Convert.ToInt32(userInfo["ID"].ToString());
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
        }
        protected void ForceLogOut()
        {
            HttpCookie GetUserInfoCookie = new HttpCookie("SuMCurrentUser");
            GetUserInfoCookie.Expires = DateTime.Now.AddDays(-100);
            Response.Cookies.Add(GetUserInfoCookie);
        }
    }
}