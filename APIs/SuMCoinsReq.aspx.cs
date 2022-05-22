using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;

namespace SuM_Manga_V3
{
    public partial class SuMCoinsReq : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string json = string.Empty;
            if (Request.QueryString["MID"] != null)//  /MangaParser.aspx?MID=0&CN=0&MN=X
            {
                HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
                if (GetUserInfoCookie != null)
                {
                    int MID = Convert.ToInt32(Request.QueryString["MID"].ToString());
                    json = MangaCoinsCountDMySql(MID).ToString();
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
        protected static int MangaCoinsCountDMySql(int MID)
        {
            int V = 0;
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString; using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string query = "SELECT ChapterCValue FROM SuMManga WHERE MangaID = @MID";
                MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
                MySqlCmd.Parameters.AddWithValue("@MID", SqlDbType.Int);
                MySqlCmd.Parameters["@MID"].Value = MID;
                using (MySqlDataReader dr = MySqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (dr[0] != null)
                        {
                            if (dr[0].ToString().Replace(" ", "") != "")
                            {
                                V = Convert.ToInt32(dr[0].ToString());
                            }
                        }
                    }
                }
                MySqlCon.Close();
            }
            return V;
        }
    }
}