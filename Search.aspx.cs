using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient; 
using System.Configuration;
using System.Data;

namespace SuM_Manga_V3
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ShowResults(object sender, EventArgs e) 
        {
            var TITB = TextBoxForSuM.Text;
            char sc = '"';
            if (TITB != null)
            {
                string TextFS = TITB.ToString();
                if (TextFS != "Search for..." && string.IsNullOrEmpty(TextFS) == false)
                {
                    string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
                    {
                        MySqlCon.Open();
                        string qwi = "SELECT MangaID FROM SuMManga WHERE MangaName LIKE '%" + TextFS + "%'";//@SearchText + '%'";
                        MySqlCommand MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                        var jdbvg = MySqlCmd00.ExecuteScalar();
                        Queue<int> IDs = new Queue<int>();
                        using (MySqlDataReader sdr = MySqlCmd00.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                IDs.Enqueue(Convert.ToInt32(sdr["MangaID"].ToString()));
                            }
                        }
                        while (IDs.Count > 0)
                        {
                            int MID = IDs.Dequeue();
                            string Name = string.Empty;
                            string Cover = string.Empty;
                            string Disc = string.Empty;
                            string CExplorerLink = string.Empty;
                            int MangaIDF = MID;
                            string query = "SELECT MangaName FROM SuMManga WHERE MangaID = @MangaID";
                            MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
                            MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            MySqlCmd.Parameters["@MangaID"].Value = MangaIDF;
                            var un = MySqlCmd.ExecuteScalar();
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
                            // X = MySqlCmd.ExecuteScalar();
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
                            string CreatorName = un.ToString();

                            query = "SELECT MangaAgeRating FROM SuMManga WHERE MangaID = @MangaID";
                            MySqlCmd = new MySqlCommand(query, MySqlCon);
                            MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            MySqlCmd.Parameters["@MangaID"].Value = MangaIDF;
                            un = MySqlCmd.ExecuteScalar();
                            string AgeRating = un.ToString();

                            ShowSuMResults.InnerHtml += BuildSearchCard(Cover, Name, CExplorerLink, themecolor, MangaIDF, CreatorName, AgeRating);
                            if (IDs.Count != 0) { ShowSuMResults.InnerHtml += "<hr style=" + sc.ToString() + "margin:0 auto !important;height:2px;color:var(--SuMDGrayOP100);width:calc(100vw - 36px);margin:0 auto important;" + sc.ToString() + ">"; } //"<hr style=" + sc.ToString() + "margin:0 auto !important;height:1px;border-width:0;color:rgba(120,120,120,0.8);background-color:rgba(120,120,120,0.8);width:96vw;opacity:0.18;margin:0px;margin-block:0px;" + sc.ToString() + ">"; }
                            
                        }
                        MySqlCon.Close();
                    }
                    //ShowSuMResults.InnerHtml = Result;
                }
                else
                {
                    ShowSuMResults.InnerHtml = "<p class=" + sc.ToString() + "animated pulse" + sc.ToString() + " style=" + sc.ToString() + "margin:0 auto;color:#c3c3c3;font-size:80%;" + sc.ToString() + ">...</p>";
                }
            }
            else 
            {
                ShowSuMResults.InnerHtml = "<p class=" + sc.ToString() + "animated pulse" + sc.ToString() + " style=" + sc.ToString() + "margin:0 auto;color:#c3c3c3;font-size:80%;" + sc.ToString() + ">...</p>";
            }
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
        protected string BuildSearchCard(string CoverLink, string MangaName, string ExplorerLink, string MangaTheme, int MID, string MangaCreator,string AgeRating)
        {
            string GernsString = GetGarnas(MID);
            string OnClickJSCode = "androidAPIs.SuMExploreInfoStart('" + ExplorerLink + "','" + MangaTheme + "','" + MangaName + "','" + MangaCreator + "','" + GernsString + "','" + AgeRating + "','" + CoverLink + "',);";
            char sc = '"'; string scfu = sc.ToString();
            string divST = "<div style=" + "overflow:clip;width:fit-content;height:fit-content;position:relative;" + ">";
            string PDivST = "<div style=" + "margin-top:52px;display:block;width:fit-content;padding-left:8px;" + ">";
            string astyle = scfu + "width:100vw;height:100px;position:relative;margin-left:0px;display:block;" + scfu;
            string imgstyle = scfu + "height:84px;width:84px;object-fit:cover;display:inline;border-radius:12px;float:left;margin:8px;" + scfu;
            string h4style = scfu + "color:" + MangaTheme + ";margin-top:-42px;float:left;margin-left:6px;margin-top:12px;width:calc(100% - 120px);" + scfu;
            //string hr = ""; //"<hr style=" + sc.ToString() + "margin:0 auto !important;height:1px;border-width:0;color:rgba(99,99,99,0.9);background-color:rgba(99,99,99,0.9);width:96vw;opacity:0.24;margin:0px;margin-block:0px;" + sc.ToString() + ">";
            string AuthString = "<p style=" + "color:var(--SuMDBlackOP50);float:left;margin-top:-10px;margin-left:6px;" + ">By <b style=" + "font-size:80%;" + ">" + MangaCreator + "</b></p>";
            string RS = divST + "<a style=" + astyle + " onclick="+'"'+ OnClickJSCode + '"'+" ><img src=" + CoverLink + " class=" + sc.ToString() + "animated pulse" + sc.ToString() + " style=" + imgstyle + "><h4 style=" + h4style + ">" + MangaName + "</h4>" + AuthString + "<br style=" + "float:left;" + ">" + PDivST + "<p style=" + "color:#6b6b6b;font-size:84%;" + ">" + GernsString + "</p></div></a></div>";// + hr;
            return RS;
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
    }
}