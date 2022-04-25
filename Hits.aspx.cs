using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient; using MySql.Data.MySqlClient; using System.Configuration;
using System.Data;
using System.Drawing;

namespace SuM_Manga_V3
{
    public partial class Hits : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadTop10();
        }
        protected void LoadTop10()
        {
            Top10Con.InnerHtml = "";
            string[] tHEMEcOLORS = new string[10];
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string Name = string.Empty;
                string Cover = string.Empty;
                string Disc = string.Empty;
                string CExplorerLink = string.Empty;
                int views = 0;
                string AgeRating = string.Empty;
                string query = "SELECT TOP 10 MangaID from SuMManga order by MangaViews desc;";
                MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
                int MangaIDF = 0;
                object un;
                Queue<int> RawIDs = new Queue<int>();
                using (var reader = MySqlCmd.ExecuteReader())
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
                    MySqlCmd = new MySqlCommand(query, MySqlCon);
                    MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    MySqlCmd.Parameters["@MangaID"].Value = MangaIDF;
                    un = MySqlCmd.ExecuteScalar();
                    Name = un.ToString();
                    query = "SELECT CExplorerLink FROM SuMManga WHERE MangaID = @MangaID";
                    MySqlCmd = new MySqlCommand(query, MySqlCon);
                    MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    MySqlCmd.Parameters["@MangaID"].Value = MangaIDF;
                    un = MySqlCmd.ExecuteScalar();
                    CExplorerLink = un.ToString();
                    CExplorerLink += "&VC=" + MangaIDF.ToString();
                    query = "SELECT MangaCoverLink FROM SuMManga WHERE MangaID = @MangaID";
                    MySqlCmd = new MySqlCommand(query, MySqlCon);
                    MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    MySqlCmd.Parameters["@MangaID"].Value = MangaIDF;
                    un = MySqlCmd.ExecuteScalar();
                    Cover = un.ToString();
                    query = "SELECT SuMThemeColor FROM SuMManga WHERE MangaID = @MangaID";
                    MySqlCmd = new MySqlCommand(query, MySqlCon);
                    MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    MySqlCmd.Parameters["@MangaID"].Value = MangaIDF;
                    string themecolor = MySqlCmd.ExecuteScalar().ToString();
                    CExplorerLink += "&TC=" + themecolor;
                    query = "SELECT MangaViews FROM SuMManga WHERE MangaID = @MangaID";
                    MySqlCmd = new MySqlCommand(query, MySqlCon);
                    MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    MySqlCmd.Parameters["@MangaID"].Value = MangaIDF;
                    un = MySqlCmd.ExecuteScalar();
                    views = Convert.ToInt32(un.ToString());
                    query = "SELECT MangaAgeRating FROM SuMManga WHERE MangaID = @MangaID";
                    MySqlCmd = new MySqlCommand(query, MySqlCon);
                    MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    MySqlCmd.Parameters["@MangaID"].Value = MangaIDF;
                    un = MySqlCmd.ExecuteScalar();
                    AgeRating = un.ToString();
                    query = "SELECT MangaInfo FROM SuMManga WHERE MangaID = @MangaID";
                    MySqlCmd = new MySqlCommand(query, MySqlCon);
                    MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    MySqlCmd.Parameters["@MangaID"].Value = MangaIDF;
                    un = MySqlCmd.ExecuteScalar();
                    Disc = un.ToString();
                    Top10Con.InnerHtml += BuildTopCard(i + 1, themecolor, Cover, Name, Disc, AgeRating, views, CExplorerLink);
                    tHEMEcOLORS[i] = themecolor;
                }
                MySqlCon.Close();
            }
            //HitsStylePlaceHolder.InnerHtml = "<style> #HitsBG { animation: rainbow 12s linear infinite; } @keyframes rainbow { 0% { background-color: " + tHEMEcOLORS[0] + "; } 10% { background-color: " + tHEMEcOLORS[0] + "; } 20% { background-color: " + tHEMEcOLORS[1] + "; } 30% { background-color: " + tHEMEcOLORS[2] + "; } 40% { background-color: " + tHEMEcOLORS[3] + "; } 50% { background-color: " + tHEMEcOLORS[4] + "; } 60% { background-color: " + tHEMEcOLORS[5] + "; } 70% { background-color: " + tHEMEcOLORS[6] + "; } 80% { background-color: " + tHEMEcOLORS[7] + "; } 90% { background-color: " + tHEMEcOLORS[8] + "; } 100% { background-color: " + tHEMEcOLORS[9] + "; } } </style>";
        }
        protected string GetGarnas(int id)
        {
            string garns = " ";
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                bool IsIt = false;
                MySqlCon.Open();
                string query = "SELECT Fantasy FROM SuMManga WHERE MangaID = @MangaID";
                MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
                MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                MySqlCmd.Parameters["@MangaID"].Value = id;
                using (var reader = MySqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        IsIt = reader.GetBoolean(0);
                    }
                }
                if (IsIt == true) { garns += "Fantasy, "; }

                query = "SELECT Comedy FROM SuMManga WHERE MangaID = @MangaID";
                MySqlCmd = new MySqlCommand(query, MySqlCon);
                MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                MySqlCmd.Parameters["@MangaID"].Value = id;
                using (var reader = MySqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        IsIt = reader.GetBoolean(0);
                    }
                }
                if (IsIt == true) { garns += "Comedy, "; }

                query = "SELECT Supernatural FROM SuMManga WHERE MangaID = @MangaID";
                MySqlCmd = new MySqlCommand(query, MySqlCon);
                MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                MySqlCmd.Parameters["@MangaID"].Value = id;
                using (var reader = MySqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        IsIt = reader.GetBoolean(0);
                    }
                }
                if (IsIt == true) { garns += "Supernatural, "; }

                query = "SELECT SciFi FROM SuMManga WHERE MangaID = @MangaID";
                MySqlCmd = new MySqlCommand(query, MySqlCon);
                MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                MySqlCmd.Parameters["@MangaID"].Value = id;
                using (var reader = MySqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        IsIt = reader.GetBoolean(0);
                    }
                }
                if (IsIt == true) { garns += "Sci-Fi, "; }

                query = "SELECT Drama FROM SuMManga WHERE MangaID = @MangaID";
                MySqlCmd = new MySqlCommand(query, MySqlCon);
                MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                MySqlCmd.Parameters["@MangaID"].Value = id;
                using (var reader = MySqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        IsIt = reader.GetBoolean(0);
                    }
                }
                if (IsIt == true) { garns += "Drama, "; }

                query = "SELECT Mystery FROM SuMManga WHERE MangaID = @MangaID";
                MySqlCmd = new MySqlCommand(query, MySqlCon);
                MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                MySqlCmd.Parameters["@MangaID"].Value = id;
                using (var reader = MySqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        IsIt = reader.GetBoolean(0);
                    }
                }
                if (IsIt == true) { garns += "Mystery, "; }

                query = "SELECT SliceofLife FROM SuMManga WHERE MangaID = @MangaID";
                MySqlCmd = new MySqlCommand(query, MySqlCon);
                MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                MySqlCmd.Parameters["@MangaID"].Value = id;
                using (var reader = MySqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        IsIt = reader.GetBoolean(0);
                    }
                }
                if (IsIt == true) { garns += "Slice of Life, "; }

                query = "SELECT Action FROM SuMManga WHERE MangaID = @MangaID";
                MySqlCmd = new MySqlCommand(query, MySqlCon);
                MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                MySqlCmd.Parameters["@MangaID"].Value = id;
                using (var reader = MySqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        IsIt = reader.GetBoolean(0);
                    }
                }
                if (IsIt == true) { garns += "Action, "; }

                /*query = "SELECT TYPE FROM SuMManga WHERE MangaID = @MangaID";
                MySqlCmd = new MySqlCommand(query, MySqlCon);
                MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                MySqlCmd.Parameters["@MangaID"].Value = id;
                if (MySqlCmd.ExecuteScalar() != null) { garns += "TYPE, "; }*/

                //if (garns != null) { if (garns[garns.Length - 2] == ',' && garns[garns.Length - 1] == ' ') { garns.Substring(garns.Length - 3); } }

                MySqlCon.Close();
            }
            if (string.IsNullOrEmpty(garns) == false) { garns = garns.Substring(1, (garns.Length - 3)); }
            return garns;
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
            string divstyle = b12.ToString() + "overflow:hidden !important;background-image:linear-gradient(" + theme + ",var(--SuMDBlackOP30)),url(" + CardBG + ") !important;background-size:cover;background-position:center !important;width:calc(100vw - 24px) !important;height:76vw;max-width:630px !important;max-height:300px !important;padding:12px;margin:0 auto !important;border-radius:12px !important;" + b12.ToString();
            string DivContant = "<div style=" + b12.ToString() + "width:calc(98% - 24px);height:fit-content;position:relative;margin:0 auto;margin-top:2px;" + b12.ToString() + ">";
            DivContant += "<h1 style=" + b12.ToString() + "float:left;margin-top:12px;margin-left:12px;color:var(--SuMDWhite);font-size:178%;margin-right:14px !important;width:calc(100% - 24px) !important;height:34.17px !important;white-space:nowrap !important;overflow:hidden !important;text-overflow:ellipsis !important;" + b12.ToString() + ">" + cardtitle + "</h1>";
            DivContant += "<p style=" + b12.ToString() + "color:var(--SuMDWhiteOP82); float:right; margin-top:-18px; margin-right:10px;" + b12.ToString() + ">By <b style=" + "font-size:80%;" + ">" + CraetorName + "</b></p></div>";
            DivContant += "<hr style=" + b12.ToString() + "margin:0 auto !important;height:2px!important;border-width:0;color:var(--SuMDWhite);background-color:var(--SuMDWhite);width:80%;opacity:0.32;margin:0px;margin-block:0px;border-radius:1.3px !important;margin-bottom:4px;margin-bottom:4px !important;margin-top:-8px !important;" + b12.ToString() + " />";
            DivContant += "<p style=" + b12.ToString() + "text-align:center;height:135px;max-height:135px !important;width:calc(98% - 24px);max-width:98vw;font-size:96%;color:var(--SuMDWhite);margin:4px !important;margin-bottom:6px !important;margin-top:8px !important;text-overflow:ellipsis !important;display:inline-block;overflow:hidden;" + b12.ToString() + ">" + discr0 + "</p>";
            DivContant += "<div style=" + b12.ToString() + "margin:0 auto;margin-bottom:0px;height:fit-content;width:100%;position:relative;margin-top:0px !important;" + b12.ToString() + "><a style=" + b12.ToString() + "display:block;float:right !important;margin-bottom:0px;margin-right:8px;bottom:0;position:relative;" + b12.ToString() + ">";
            DivContant += "<p style=" + b12.ToString() + "display:inline;color:var(--SuMDWhiteOP74);" + b12.ToString() + "> " + AgeRating + " </p><img style=" + b12.ToString() + "width:20px;height:20px;display:inline;" + b12.ToString() + " src=" + b12.ToString() + "/svg/views.svg" + b12.ToString() + ">";
            DivContant += "<p style=" + "display:inline;color:var(--SuMDWhite);" + "> " + ViewsNumPart + " </p><b style=" + "display:inline;color:var(--SuMDWhite);" + ">" + ViewsLPart + "</b></a></div>";
            string result = "<div onclick=" + b12.ToString() + "SuMGoToThis('" + Link + "','" + theme + "','" + cardtitle.Replace("'", "") + "','ContantExplorer');" + b12.ToString() + " class=" + divclass + " style=" + divstyle + ">" + "<div class=" + b12.ToString() + "animated fadeIn" + b12.ToString() + " >" + DivContant + "</div>" + "</div>";
            return result;
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
            string NewPart = "<div " + HerfingCode + " style=" + '"' + "width:fit-contant;height:fit-contant;-webkit-transition: all 0.5s !important; -moz-transition: all 0.5s !important; -ms-transition: all 0.5s !important; -o-transition: all 0.5s !important; transition: all 0.5s !important;" + '"' + " > <div style=display:inline-block; > <img src=/svg/ExploreBook.svg style=" + "margin-left:8px;margin-right:6px !important;pointer-events:all !important;" + " height=26 width=26 class=" + "animated pulse" + " >  <p style=" + '"' + "color:#FFFFFFAD !important;font-size:76%;margin-right:12px !important;display:inline !important;" + '"' + " class=" + '"' + "animated pulse" + '"' + "><b>Explore manga</b></p> </div> </div>";
            string RS = "<div id=NuM" + Num.ToString() + " style=" + '"' + "padding:12px;padding-top:22px;padding-bottom:22px;background-image:linear-gradient(" + ThemeColor + ", rgba(0, 0, 0, 0.3)), url(" + CoverURL + ") !important;background-size: cover;background-position: center center !important;height:0px;width:100%;overflow:hidden;-webkit-transition: all 0.5s !important; -moz-transition: all 0.5s !important; -ms-transition: all 0.5s !important; -o-transition: all 0.5s !important; transition: all 0.5s !important;" + '"' + "> <div style=" + '"' + "height:fit-content;width:100%;margin:0 auto !important;display:inline !important;position:relative;-webkit-transition: all 0.5s !important; -moz-transition: all 0.5s !important; -ms-transition: all 0.5s !important; -o-transition: all 0.5s !important; transition: all 0.5s !important;" + '"' + "> <div style=" + '"' + "height:fit-content;margin-top:-26px;-webkit-transition: all 0.5s !important; -moz-transition: all 0.5s !important; -ms-transition: all 0.5s !important; -o-transition: all 0.5s !important; transition: all 0.5s !important;" + '"' + " id=NuM" + Num.ToString() + "Expandor " + ExpandingCode + " ><p style=" + '"' + "float:right;margin-top:8px;margin-right:8px;font-size:240%;color:rgba(255,255,255,0.86);-webkit-transition: all 0.5s !important; -moz-transition: all 0.5s !important; -ms-transition: all 0.5s !important; -o-transition: all 0.5s !important; transition: all 0.5s !important;" + '"' + ">#" + Num.ToString() + "</p> <p id=NuM" + Num.ToString() + "Title style=" + '"' + "font-size:160%;color:#ffffff;width:calc(100% - 90px);overflow:hidden;margin-top:18px;height:fit-content;-webkit-transition: all 0.5s !important; -moz-transition: all 0.5s !important; -ms-transition: all 0.5s !important; -o-transition: all 0.5s !important; transition: all 0.5s !important;" + '"' + ">" + ManagTitle + "</p></div><div id=NuM" + Num.ToString() + "CardRest style=display:none;animation-duration:0.3s; class=" + '"' + "animated fadeInDown" + '"' + " > <div style=" + '"' + "border-radius:18px;background-color:" + ThemeColor.Replace("0.74", "0.94") + ";padding-top:26px;padding-left:18px;padding-right:18px;margin-bottom:32px;-webkit-transition: all 0.5s !important; -moz-transition: all 0.5s !important; -ms-transition: all 0.5s !important; -o-transition: all 0.5s !important; transition: all 0.5s !important;" + '"' + " > <p id=NuM" + Num.ToString() + "Disc style=" + '"' + "width:100%;overflow:hidden;font-size:92%;color:rgba(255,255,255,0.98);text-align:center;height:fit-content;-webkit-transition: all 0.5s !important; -moz-transition: all 0.5s !important; -ms-transition: all 0.5s !important; -o-transition: all 0.5s !important; transition: all 0.5s !important;" + '"' + ">" + ManagDisc + "</p> <div style=width:fit-content;float:right;margin-bottom:18px;margin-top:8px;> <p style=display:inline;color:rgba(255,255,255,0.74);>" + AgeRating + "</p> <img style=width:20px;height:20px;display:inline; src=" + '"' + "/svg/views.svg" + '"' + "> <p  style=display:inline;color:#ffffff;>" + ViewsNumPart + "</p> <b style=display:inline;color:#ffffff;>" + ViewsLPart + "</b> </div> " + NewPart + " </div> </div> </div> " + "<p style=display:none; id=Top" + Num + "ThemeColor >" + ThemeColor + "</p>" + " </div>";
            return RS;
        }
    }
}