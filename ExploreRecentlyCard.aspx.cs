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
    public partial class ExploreRecentlyCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //LastRefreshPross();
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            if (GetUserInfoCookie != null)
            {
                int UID = Convert.ToInt32(GetUserInfoCookie["ID"].ToString());
                LoadResents(UID);
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
        protected void LoadResents(int UID)
        {
            object ResultFromSQL;
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string qwi = "SELECT Resently FROM SuMUsersAccounts WHERE UserID = @UID";
                SqlCommand sqlCmd00 = new SqlCommand(qwi, sqlCon);
                sqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                sqlCmd00.Parameters["@UID"].Value = UID;
                ResultFromSQL = sqlCmd00.ExecuteScalar();
                sqlCon.Close();
            }
            if (ResultFromSQL != null)
            {
                if (string.IsNullOrEmpty(ResultFromSQL.ToString()) == false)
                {
                    Recent.InnerHtml = "";
                    using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                    {
                        sqlCon.Open();
                        object un;
                        string query = string.Empty;
                        SqlCommand sqlCmd = new SqlCommand("", sqlCon);
                        int[] MIDs = ST0(ResultFromSQL.ToString());
                        for (int i = 0; i < MIDs.Length; i++)
                        {
                            int maxidf = MIDs[i];
                            query = "SELECT MangaName FROM SuMManga WHERE MangaID = @MangaID";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = maxidf;
                            un = sqlCmd.ExecuteScalar();
                            string MTitle = un.ToString();
                            query = "SELECT CExplorerLink FROM SuMManga WHERE MangaID = @MangaID";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = maxidf;
                            un = sqlCmd.ExecuteScalar();
                            string CExplorerLink = un.ToString();
                            query = "SELECT MangaCoverLink FROM SuMManga WHERE MangaID = @MangaID";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = maxidf;
                            un = sqlCmd.ExecuteScalar();
                            string Cover = un.ToString();
                            query = "SELECT SuMThemeColor FROM SuMManga WHERE MangaID = @MangaID";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = maxidf;
                            string themecolor = sqlCmd.ExecuteScalar().ToString();
                            CExplorerLink += "&VC=" + maxidf.ToString() + "&TC=" + themecolor;
                            Recent.InnerHtml += BuildRecentCard(Cover, MTitle, themecolor, CExplorerLink, (i + 1), maxidf);
                        }
                        sqlCon.Close();
                    }
                }
                else
                {
                    RecentsSuperCont.Attributes["style"] = "display:none !important;";
                }
            }
            else
            {
                RecentsSuperCont.Attributes["style"] = "display:none !important;";
            }
        }
        protected string BuildRecentCard(string CoverLink, string MangaTitle, string ThemeColor, string ExplorerLink, int Num, int MangaID)
        {
            string RS = "<div class=" + '"' + "animated fadeInRight" + '"' + " onclick=" + '"' + "SuMApplyInfoToUltraCard('" + MangaID + "', '" + CoverLink + "', '" + MangaTitle.Replace("'", "") + "', '" + ExplorerLink + "', 'ContantExplorer', '" + MangaTitle.Replace("'", "") + "', '" + ThemeColor + "');" + '"' + " loading=lazy style=" + '"' + "border-radius:12px;position:relative;overflow:hidden;background-image:url(" + CoverLink + ");background-size:cover;background-position:center;width:96px;height:96px;overflow:hidden !important;margin-left:16px !important;" + '"' + "><div id=RecentItem" + Num.ToString() + " class=GoodBlur style=" + '"' + "background-color:" + ThemeColor + " !important;width:98px;margin-left:-1px;height:36px;position:absolute;bottom:0;border-radius:0px;overflow:hidden !important;" + '"' + "><p style=" + '"' + "margin-top:2px;height:fit-content;width:auto;max-width:112px;color:#ffffff;margin-left:6px;word-wrap:break-word;white-space:pre-wrap;word-break:break-word;text-align:center;white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" + '"' + ">" + MangaTitle + "</p></div></div>";
            return RS;
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
    }
}