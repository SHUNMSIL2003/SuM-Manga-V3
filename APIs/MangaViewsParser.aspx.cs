using System;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web;
using System.Data;

namespace SuM_Manga_V3
{
    public partial class MangaViewsParser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string json = string.Empty;
            if (Request.QueryString["MID"] != null)//  /MangaViewsParser.aspx?MID=0
            {
                HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
                if (GetUserInfoCookie != null)
                {
                    int MID = Convert.ToInt32(Request.QueryString["MID"].ToString());
                    json = ShowViews(MID);
                }
                else json = "[LOGIN_PLZ]";
            }
            else json = "[MISSING_MID]";
            Response.Clear();
            //Response.ContentType = "application/json; charset=utf-8";
            //.Content = new StringContent(result, System.Text.Encoding.UTF8, "text/plain");
            Response.ContentType = "text/plain; charset=utf-8";
            Response.Write(json);
            Response.End();
        }
        protected static string ShowViews(int y)
        {
            string parta = string.Empty;
            string partb = string.Empty;
            int V = 0;
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString; using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string query = "SELECT MangaViews FROM SuMManga WHERE MangaID = @MangaID";
                MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
                MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                MySqlCmd.Parameters["@MangaID"].Value = y;
                using (MySqlDataReader dr = MySqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        V = Convert.ToInt32(dr[0].ToString());
                    }
                }
                MySqlCon.Close();
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