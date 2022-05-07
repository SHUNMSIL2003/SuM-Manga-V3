using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient; using MySql.Data.MySqlClient; using System.Configuration;
using System.Data;

namespace SuM_Manga_V3
{
    public partial class Library : System.Web.UI.Page
    {
        /*protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Request.Browser.IsMobileDevice)
                MasterPageFile = "~/SuMManga.Mobile.Master";
        }*/
        //int loadt = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowCardsCNew();
            }
        }
        protected void ShowCardsCNew()
        {
            string ResultS = " ";
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString; using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string query = "SELECT MangaID FROM SuMManga ORDER BY MangaID DESC LIMIT 0,64; ";
                MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
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
                string Name = string.Empty;
                string Cover = string.Empty;
                string Disc = string.Empty;
                string CExplorerLink = string.Empty;
                for (int i = 0; i < IDs.Length; i++)
                {
                    query = "SELECT MangaName FROM SuMManga WHERE MangaID = @MangaID";
                    MySqlCmd = new MySqlCommand(query, MySqlCon);
                    MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    MySqlCmd.Parameters["@MangaID"].Value = IDs[i];
                    var un = MySqlCmd.ExecuteScalar();
                    Name = un.ToString();
                    query = "SELECT MangaInfo FROM SuMManga WHERE MangaID = @MangaID";
                    MySqlCmd = new MySqlCommand(query, MySqlCon);
                    MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    MySqlCmd.Parameters["@MangaID"].Value = IDs[i];
                    un = MySqlCmd.ExecuteScalar();
                    Disc = un.ToString();
                    query = "SELECT CExplorerLink FROM SuMManga WHERE MangaID = @MangaID";
                    MySqlCmd = new MySqlCommand(query, MySqlCon);
                    MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    MySqlCmd.Parameters["@MangaID"].Value = IDs[i];
                    un = MySqlCmd.ExecuteScalar();
                    CExplorerLink = un.ToString();
                    query = "SELECT MangaCoverLink FROM SuMManga WHERE MangaID = @MangaID";
                    MySqlCmd = new MySqlCommand(query, MySqlCon);
                    MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    MySqlCmd.Parameters["@MangaID"].Value = IDs[i];
                    un = MySqlCmd.ExecuteScalar();
                    Cover = un.ToString();
                    query = "SELECT SuMThemeColor FROM SuMManga WHERE MangaID = @MangaID";
                    MySqlCmd = new MySqlCommand(query, MySqlCon);
                    MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    MySqlCmd.Parameters["@MangaID"].Value = IDs[i];
                    string themecolor = MySqlCmd.ExecuteScalar().ToString();
                    CExplorerLink += "&VC=" + IDs[i].ToString() + "&TC=" + themecolor;
                    query = "SELECT MangaCreator FROM SuMManga WHERE MangaID = @MangaID";
                    MySqlCmd = new MySqlCommand(query, MySqlCon);
                    MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    MySqlCmd.Parameters["@MangaID"].Value = IDs[i];
                    string MangaCReator = MySqlCmd.ExecuteScalar().ToString();
                    query = "SELECT MangaViews FROM SuMManga WHERE MangaID = @MangaID";
                    MySqlCmd = new MySqlCommand(query, MySqlCon);
                    MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    MySqlCmd.Parameters["@MangaID"].Value = IDs[i];
                    int Views = Convert.ToInt32(MySqlCmd.ExecuteScalar().ToString());
                    query = "SELECT MangaAgeRating FROM SuMManga WHERE MangaID = @MangaID";
                    MySqlCmd = new MySqlCommand(query, MySqlCon);
                    MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    MySqlCmd.Parameters["@MangaID"].Value = IDs[i];
                    string MangaAgeRating = MySqlCmd.ExecuteScalar().ToString();
                    ResultS += ContantShow(Name, Cover, CExplorerLink, themecolor, IDs[i], MangaCReator, MangaAgeRating);
                }

                MySqlCon.Close();
            }
            MangasAvalibleDiv.InnerHtml = ResultS;
        }
        public string ContantShow(string MangaName, string MangaCoverLink, string Link, string theme,int MangaID,string CraetorName,string AgeRating)
        {
            string GernsString = GetGarnas(MangaID);
            string OnClickJSCode = "androidAPIs.SuMExploreInfoStart('" + Link + "','" + theme + "','" + MangaName + "','" + CraetorName + "','" + GernsString + "','" + AgeRating + "','" + MangaCoverLink + "',);";
            string LazyLoading = "loading=" + '"'.ToString() + "lazy" + '"'.ToString();//New
            char b12 = '"';
            string zoominanim = b12.ToString() + "fadeIn animated" + b12.ToString();
            string divs0 = "margin-left:6px;display:inline-block;height:fit-content;min-width:118px;max-width:118px;";
            string as0 = "text-decoration:none;display:inline;width:118px;height:177px;overflow:hidden !important;display:block;";
            string divs1 = "border-radius:12px;position:relative;overflow:hidden;background-image:url(" + MangaCoverLink + ");background-size:cover;background-position:center;width:118px;height:177px";
            string divs2 = "background-color:" + theme + "!important;width:100%;height:fit-content;position:absolute;bottom:0;border-radius:8px;";
            string ps0 = "margin-top:8px;height:fit-content;width:auto;max-width:112px;color:var(--SuMDWhite);margin-left:6px;word-wrap:break-word;white-space:pre-wrap;word-break:break-word;text-align:center;";
            string ps1 = "height:fit-content;width:118px;max-width:118px;font-size:69%;color:var(--SuMDBlackOP64);word-wrap:break-word;white-space:pre-wrap;word-break:break-word;";
            string result = "<div class=" + zoominanim + " style=" + divs0 + "><a onclick=" + b12.ToString() + OnClickJSCode + b12.ToString() + " style=" + '"' + as0 + '"' + "><div " + LazyLoading + " style=" + divs1 + "><div class=" + "GoodBlur" + " style=" + divs2 + "><p style=" + ps0 + ">" + MangaName + "</p></div></div><p style=" + ps1 + "></p></a></div>";
            return result;
        }
        protected string GetGarnas(int id)
        {
            string garns = " ";
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString; using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
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

                MySqlCon.Close();
            }
            if (string.IsNullOrEmpty(garns) == false) { garns = garns.Substring(1, (garns.Length - 3)); }
            return garns;
        }
    }
}