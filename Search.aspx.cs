using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;
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
                    using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                    {
                        sqlCon.Open();
                        string qwi = "SELECT MangaID FROM SuMManga WHERE MangaName LIKE '%" + TextFS + "%'";//@SearchText + '%'";
                        SqlCommand sqlCmd00 = new SqlCommand(qwi, sqlCon);
                        var jdbvg = sqlCmd00.ExecuteScalar();
                        Queue<int> IDs = new Queue<int>();
                        using (SqlDataReader sdr = sqlCmd00.ExecuteReader())
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
                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = MangaIDF;
                            var un = sqlCmd.ExecuteScalar();
                            Name = un.ToString();
                            query = "SELECT CExplorerLink FROM SuMManga WHERE MangaID = @MangaID";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = MangaIDF;
                            un = sqlCmd.ExecuteScalar();
                            CExplorerLink = un.ToString();
                            query = "SELECT ChaptersNumber FROM SuMManga WHERE MangaID = @MangaID";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = MangaIDF;
                            un = sqlCmd.ExecuteScalar();
                            int ChaptersNum = Convert.ToInt32(un);
                            CExplorerLink += "&CN=" + ChaptersNum.ToString() + "&VC=" + MangaIDF.ToString();
                            query = "SELECT MangaCoverLink FROM SuMManga WHERE MangaID = @MangaID";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = MangaIDF;
                            // X = sqlCmd.ExecuteScalar();
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
                            string CreatorName = un.ToString();
                            ShowSuMResults.InnerHtml += BuildSearchCard(Cover, Name, CExplorerLink, themecolor, MangaIDF, CreatorName);
                            if (IDs.Count != 0) { ShowSuMResults.InnerHtml += "<hr style=" + sc.ToString() + "margin:0 auto !important;height:1px;border-width:0;color:rgba(120,120,120,0.8);background-color:rgba(120,120,120,0.8);width:96vw;opacity:0.24;margin:0px;margin-block:0px;" + sc.ToString() + ">"; }
                            
                        }
                        sqlCon.Close();
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
        protected string BuildSearchCard(string CoverLink, string MangaName, string ExplorerLink, string MangaTheme, int MID, string MangaCreator)
        {
            char sc = '"'; string scfu = sc.ToString();
            string divST = "<div style=" + "overflow:clip;width:fit-content;height:fit-content;position:relative;" + ">";
            string PDivST = "<div style=" + "margin-top:52px;display:block;width:fit-content;padding-left:8px;" + ">";
            string astyle = scfu + "width:100vw;height:100px;position:relative;margin-left:0px;display:block;" + scfu;
            string imgstyle = scfu + "height:84px;width:84px;object-fit:cover;display:inline;border-radius:4px;float:left;margin:8px;" + scfu;
            string h4style = scfu + "color:" + MangaTheme + ";margin-top:-42px;float:left;margin-left:6px;margin-top:12px;width:calc(100% - 120px);" + scfu;
            string hr = ""; //"<hr style=" + sc.ToString() + "margin:0 auto !important;height:1px;border-width:0;color:rgba(99,99,99,0.9);background-color:rgba(99,99,99,0.9);width:96vw;opacity:0.24;margin:0px;margin-block:0px;" + sc.ToString() + ">";
            string AuthString = "<p style=" + "color:rgb(0,0,0,0.50);float:left;margin-top:-10px;margin-left:6px;" + ">By <b style=" + "font-size:80%;" + ">" + MangaCreator + "</b></p>";
            string RS = divST + "<a style=" + astyle + " href=" + ExplorerLink + "><img src=" + CoverLink + " class=" + sc.ToString() + "animated pulse" + sc.ToString() + " style=" + imgstyle + "><h4 style=" + h4style + ">" + MangaName + "</h4>" + AuthString + "<br style=" + "float:left;" + ">" + PDivST + "<p style=" + "color:#6b6b6b;font-size:84%;" + ">" + GetGarnas(MID) + "</p></div></a></div>" + hr;
            return RS;
        }
        /*protected string BuildGCard(string CoverLink, string MangaName, string ExplorerLink, string MangaTheme, int id)
        {
            char b12 = '"';
            string zoominanim = b12.ToString() + "fadeIn animated" + b12.ToString();
            string divs0 = "margin-left:6px;display:inline-block;height:fit-content;width:174px;max-height:300px;overflow:clip;";
            string as0 = "text-decoration:none;display:inline;margin-left:6px;margin-right:6px;";//backdrop-filter:blur(1px); Down in divs2
            string divs1 = "border-radius:8px;position:relative;overflow:hidden;background-image:url(" + CardBG + ");background-size:cover;background-position:center;width:174px;height:261px";
            //string divstyle = "overflow:hidden;background-image:linear-gradient(rgba(0,0,0,0.527),rgba(0,0,0,0.3)),url(" + CardBG + ");background-size:cover;background-position:center;width:100vw;height:74vw;padding:12px;";
            string divs2 = "background-color:" + theme + "!important;width:100%;height:fit-content;position:absolute;bottom:0;border-radius:8px;"; //rgb(104,64,217,0.64)
            string ps0 = "height:fit-content;width:auto;max-width:112px;color:#ffffff;margin-left:6px;word-wrap:break-word;white-space:pre-wrap;word-break:break-word;";
            string ps1 = "height:fit-content;width:118px;max-width:118px;font-size:69%;color:#2e2e2e;word-wrap:break-word;white-space:pre-wrap;word-break:break-word;";
            string result = "<div class=" + zoominanim + " style=" + divs0 + "><a href=" + Link + " style=" + as0 + "><div style=" + divs1 + "><div class="+ "GoodBlur" + " style=" + divs2 + "><p style=" + ps0 + ">" + cardtitle + "</p></div></div><p style=" + ps1 + ">" + GetGarnas(id) + "</p></a></div>";//GetGarnas(id)
            return result;
        }*/
        protected string GetGarnas(int id)
        {
            string garns = " ";
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string query = "SELECT ID FROM Fantasy WHERE MangaID = @MangaID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = id;
                if (sqlCmd.ExecuteScalar() != null) { garns += "Fantasy, "; }

                query = "SELECT ID FROM Comedy WHERE MangaID = @MangaID";
                sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = id;
                if (sqlCmd.ExecuteScalar() != null) { garns += "Comedy, "; }

                query = "SELECT ID FROM Supernatural WHERE MangaID = @MangaID";
                sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = id;
                if (sqlCmd.ExecuteScalar() != null) { garns += "Supernatural, "; }

                query = "SELECT ID FROM SciFi WHERE MangaID = @MangaID";
                sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = id;
                if (sqlCmd.ExecuteScalar() != null) { garns += "Sci-Fi, "; }

                query = "SELECT ID FROM Drama WHERE MangaID = @MangaID";
                sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = id;
                if (sqlCmd.ExecuteScalar() != null) { garns += "Drama, "; }

                query = "SELECT ID FROM Mystery WHERE MangaID = @MangaID";
                sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = id;
                if (sqlCmd.ExecuteScalar() != null) { garns += "Mystery, "; }

                query = "SELECT ID FROM SliceofLife WHERE MangaID = @MangaID";
                sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = id;
                if (sqlCmd.ExecuteScalar() != null) { garns += "Slice of Life, "; }

                query = "SELECT ID FROM Action WHERE MangaID = @MangaID";
                sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = id;
                if (sqlCmd.ExecuteScalar() != null) { garns += "Action, "; }

                /*query = "SELECT ID FROM smth WHERE MangaID = @MangaID";
                sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = id;
                if (sqlCmd.ExecuteScalar() != null) { garns += "smth, "; }

                query = "SELECT ID FROM smth WHERE MangaID = @MangaID";
                sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = id;
                if (sqlCmd.ExecuteScalar() != null) { garns += "smth, "; }

                query = "SELECT ID FROM smth WHERE MangaID = @MangaID";
                sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = id;
                if (sqlCmd.ExecuteScalar() != null) { garns += "smth, "; }*/

                //if (garns != null) { if (garns[garns.Length - 2] == ',' && garns[garns.Length - 1] == ' ') { garns.Substring(garns.Length - 3); } }

                sqlCon.Close();
            }
            if (string.IsNullOrEmpty(garns) == false) { garns = garns.Substring(1, (garns.Length - 3)); }
            return garns;
        }
    }
}