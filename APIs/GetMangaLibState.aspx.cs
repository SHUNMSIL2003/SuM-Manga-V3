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
    public partial class GetMangaLibState : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string json = string.Empty;
            if (Request.QueryString["MID"] != null && Request.QueryString["LIB"] != null)//  /SetMangaLibState.aspx?MID=0&SB=0/1&LIB=Fav/Wanna
            {
                HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
                if (GetUserInfoCookie != null)
                {
                    int UID = Convert.ToInt32(GetUserInfoCookie["ID"].ToString());
                    int MID = Convert.ToInt32(Request.QueryString["MID"].ToString());
                    string LIB = Request.QueryString["LIB"].ToString();
                    if (LIB == "Fav" || LIB == "Wanna") json = IsItX(LIB, MID, UID);
                    if (LIB == "Curr") json = IsItCurr(LIB, MID, UID);
                }
                else json = "0";
            }
            else json = "0";
            Response.Clear();
            //Response.ContentType = "application/json; charset=utf-8";
            //.Content = new StringContent(result, System.Text.Encoding.UTF8, "text/plain");
            Response.ContentType = "text/plain; charset=utf-8";
            Response.Write(json);
            Response.End();
        }
        protected private string IsItX(string lib, int MID, int UID)
        {
            string Target = "#" + MID.ToString() + "&";
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;
            object RawRes;
            using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string qwi = "SELECT " + lib + " FROM SuMUsersAccounts WHERE UserID = @UID";
                MySqlCommand MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                MySqlCmd00.Parameters["@UID"].Value = UID;
                RawRes = MySqlCmd00.ExecuteScalar();
                MySqlCon.Close();
            }
            if (RawRes != null)
            {
                string RR = RawRes.ToString().Replace(" ", "");
                if (RR.Contains(Target))
                {
                    return "1";
                }
                else return "0";
            }
            else
            {
                return "0";
            }
        }
        protected private string IsItCurr(string lib, int MID, int UID)
        {
            string Target = "#" + MID.ToString() + ";";
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;
            object RawRes;
            using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string qwi = "SELECT " + lib + " FROM SuMUsersAccounts WHERE UserID = @UID";
                MySqlCommand MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                MySqlCmd00.Parameters["@UID"].Value = UID;
                RawRes = MySqlCmd00.ExecuteScalar();
                MySqlCon.Close();
            }
            if (RawRes != null)
            {
                string Res = RawRes.ToString().Replace(" ", "");
                if (Res.Contains(Target))
                {
                    int SOCIndex = Res.IndexOf("#" + MID.ToString() + ";");
                    for (int i = SOCIndex; i < (SOCIndex + 32); i++)
                    {
                        if (Res[i] == '&')
                        {
                            string ORS = "";
                            for (int j = SOCIndex; j < (i + 1); j++)
                            {
                                ORS += Res[j].ToString();
                            }
                            ORS = ORS.Replace(Target, "").Replace("&", "");
                            int ABSR = Convert.ToInt32(ORS);
                            return ABSR.ToString();
                            //i = SOCIndex + 32;
                        }
                    }
                }
                else return "0";
            }
            else
            {
                return "0";
            }
            return "0";
        }
    }
}