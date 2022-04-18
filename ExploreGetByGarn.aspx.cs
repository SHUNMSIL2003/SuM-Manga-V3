using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.IO;

namespace SuM_Manga_V3
{
    public partial class ExploreGetByGarn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object GRQS = Request.QueryString["GR"];
            if (GR != null)
            {
                GR.InnerHtml = GetFromGarna(GRQS.ToString());
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

                sqlCon.Close();
            }
            if (string.IsNullOrEmpty(garns) == false) { garns = garns.Substring(1, (garns.Length - 3)); }
            return garns;
        }
        protected string GetFromGarna(string Garna)
        {
            string Result = string.Empty;
            if (string.IsNullOrEmpty(Garna) == false)
            {
                using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    sqlCon.Open();
                    string Name = string.Empty;
                    string Cover = string.Empty;
                    string Disc = string.Empty;
                    string CExplorerLink = string.Empty;
                    string Auther = string.Empty;
                    string AgeRating = string.Empty;
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

                        query = "SELECT MangaCreator FROM SuMManga WHERE MangaID = @MangaID";
                        sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                        sqlCmd.Parameters["@MangaID"].Value = MangaIDF;
                        un = sqlCmd.ExecuteScalar();
                        Auther = un.ToString();
                        query = "SELECT MangaAgeRating FROM SuMManga WHERE MangaID = @MangaID";
                        sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                        sqlCmd.Parameters["@MangaID"].Value = MangaIDF;
                        un = sqlCmd.ExecuteScalar();
                        AgeRating = un.ToString();


                        Result += BuildGCard(Cover, Name, CExplorerLink, themecolor, MangaIDF, Auther, AgeRating);
                    }
                    sqlCon.Close();
                }
            }
            else { Result = " "; }
            return Result;
        }
        protected string BuildGCard(string CardBG, string cardtitle, string Link, string theme, int id,string Auther,string AgeRating)
        {
            string GernsString = GetGarnas(id);
            string OnClickJSCode = "androidAPIs.SuMExploreInfoStart('" + Link + "','" + theme + "','" + cardtitle + "','" + Auther + "','" + GernsString + "','" + AgeRating + "','" + CardBG + "',);";
            string LazyLoading = "loading=" + '"'.ToString() + "lazy" + '"'.ToString();//New
            char b12 = '"';
            string zoominanim = b12.ToString() + "fadeIn animated" + b12.ToString();
            string divs0 = "margin-left:6px;display:inline-block;height:fit-content;min-width:118px;max-width:118px;scroll-snap-align:start;";
            string as0 = "text-decoration:none;display:inline;margin-left:6px;margin-right:6px;";//backdrop-filter:blur(1px); Down in divs2
            string divs1 = "border-radius:12px;position:relative;overflow:hidden;background-image:url(" + CardBG + ");background-size:cover;background-position:center;width:118px;height:177px";
            string divs2 = '"' + "background-color:" + theme + " !important; width:100%;height:fit-content;position:absolute;bottom:0;border-radius:8px;" + '"'; //var(--SuMThemeColorOP64)
            string ps0 = "margin-top:8px;height:fit-content;width:auto;max-width:112px;color:rgb(255,255,255);margin-left:6px;word-wrap:break-word;white-space:pre-wrap;word-break:break-word;text-align:center;";
            string ps1 = "height:fit-content;width:118px;max-width:118px;font-size:69%;color:var(--SuMDBlackOP64);word-wrap:break-word;white-space:pre-wrap;word-break:break-word;";
            string result = "<div class=" + zoominanim + " style=" + divs0 + "><a onclick=" + b12.ToString() + OnClickJSCode + b12.ToString() + " style=" + as0 + "><div " + LazyLoading + " style=" + divs1 + "><div class=" + "GoodBlur" + " style=" + divs2 + "><p style=" + ps0 + ">" + cardtitle + "</p></div></div><p style=" + ps1 + ">" + GernsString + "</p></a></div>"; //GetGarnas(id)
            return result;
        }
    }
}