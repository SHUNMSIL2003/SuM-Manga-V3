using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace SuM_Manga_V3
{
    public partial class ExploreGetByGarnAPI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object GRQS = Request.QueryString["GR"];
            string json = string.Empty;
            if (GRQS != null)
            {
                json = GetFromGarna(GRQS.ToString());
            }
            else 
            {
                json = GetFromNullGarna();
            }
            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.Write(json);
            Response.End();
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
        protected string GetFromGarna(string Garna)
        {
            string Result = "[ ";
            if (string.IsNullOrEmpty(Garna) == false)
            {
                string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString; using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
                {
                    MySqlCon.Open();
                    string Name = string.Empty;
                    string Cover = string.Empty;
                    string Disc = string.Empty;
                    string CExplorerLink = string.Empty;
                    string Auther = string.Empty;
                    string AgeRating = string.Empty;
                    string query = "SELECT MangaID FROM SuMManga WHERE " + Garna + " = 1 ORDER BY MangaID DESC LIMIT 0,24; ";
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

                        query = "SELECT MangaCreator FROM SuMManga WHERE MangaID = @MangaID";
                        MySqlCmd = new MySqlCommand(query, MySqlCon);
                        MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                        MySqlCmd.Parameters["@MangaID"].Value = MangaIDF;
                        un = MySqlCmd.ExecuteScalar();
                        Auther = un.ToString();
                        query = "SELECT MangaAgeRating FROM SuMManga WHERE MangaID = @MangaID";
                        MySqlCmd = new MySqlCommand(query, MySqlCon);
                        MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                        MySqlCmd.Parameters["@MangaID"].Value = MangaIDF;
                        un = MySqlCmd.ExecuteScalar();
                        AgeRating = un.ToString();


                        Result += BuildGCard(Cover, Name, CExplorerLink, themecolor, MangaIDF, Auther, AgeRating);
                        if ((i + 1) < IDs.Length) Result += ",";
                    }
                    Result += " ]";

                    MySqlCon.Close();
                }
            }
            else { Result = ""; }
            return Result;
        }
        protected string GetFromNullGarna()
        {
            string Result = "[ ";
                string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString; using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
                {
                    MySqlCon.Open();
                    string Name = string.Empty;
                    string Cover = string.Empty;
                    string Disc = string.Empty;
                    string CExplorerLink = string.Empty;
                    string Auther = string.Empty;
                    string AgeRating = string.Empty;
                    string query = "SELECT MangaID FROM SuMManga ORDER BY MangaID DESC LIMIT 0,24; ";
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

                        query = "SELECT MangaCreator FROM SuMManga WHERE MangaID = @MangaID";
                        MySqlCmd = new MySqlCommand(query, MySqlCon);
                        MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                        MySqlCmd.Parameters["@MangaID"].Value = MangaIDF;
                        un = MySqlCmd.ExecuteScalar();
                        Auther = un.ToString();
                        query = "SELECT MangaAgeRating FROM SuMManga WHERE MangaID = @MangaID";
                        MySqlCmd = new MySqlCommand(query, MySqlCon);
                        MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                        MySqlCmd.Parameters["@MangaID"].Value = MangaIDF;
                        un = MySqlCmd.ExecuteScalar();
                        AgeRating = un.ToString();


                        Result += BuildGCard(Cover, Name, CExplorerLink, themecolor, MangaIDF, Auther, AgeRating);
                        if ((i + 1) < IDs.Length) Result += ",";
                    }
                    Result += " ]";

                    MySqlCon.Close();
                }
            return Result;
        }
        protected string BuildGCard(string CardBG, string cardtitle, string Link, string theme, int id, string Auther, string AgeRating)
        {
            string GernsString = GetGarnas(id);
            return "{ " + '"' + "CardBG" + '"' + ": " + '"' + CardBG + '"' + ", " + '"' + "cardtitle" + '"' + ": " + '"' + cardtitle + '"' + ", " + '"' + "id" + '"' + ": " + id + ", " + '"' + "theme" + '"' + ": " + '"' + theme + '"' + ", " + '"' + "Link" + '"' + ": " + '"' + Link + '"' + ", " + '"' + "Auther" + '"' + ": " + '"' + Auther + '"' + ", " + '"' + "AgeRating" + '"' + ": " + '"' + AgeRating + '"' + ", " + '"' + "GernsString" + '"' + ": " + '"' + GernsString + '"' + " }";
        }
    }
}