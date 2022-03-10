using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace SuM_Manga_V3.UploadConsole
{
    public partial class CreatorConsole : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            if (GetUserInfoCookie["CreatorName"] != null) 
            {
                if (Request.QueryString["CPRF"] == "UPL") { LoadUploads(GetUserInfoCookie["CreatorName"].ToString(), Convert.ToInt32(GetUserInfoCookie["CID"].ToString())); }
                if (Request.QueryString["CPRF"] == "DRA") { LoadDrafs(GetUserInfoCookie["CreatorName"].ToString(), Convert.ToInt32(GetUserInfoCookie["CID"].ToString())); }
                if (Request.QueryString["CPRF"] == "INP") { LoadInProsses(GetUserInfoCookie["CreatorName"].ToString(), Convert.ToInt32(GetUserInfoCookie["CID"].ToString())); }
                if (Request.QueryString["CPRF"] == null) { LoadUploads(GetUserInfoCookie["CreatorName"].ToString(), Convert.ToInt32(GetUserInfoCookie["CID"].ToString())); }
            }
            else { Response.Redirect("~/AccountETC/SuMSettings.aspx"); }
        }
        protected void LoadUploads(string CreatorName,int CID)
        {
            ADDB.Attributes["style"] = "display:none;";
            upl.Attributes["style"] = "color:var(--SuMThemeColor);margin-left:12px;";
            dra.Attributes["style"] = "color:#636166;";
            inp.Attributes["style"] = "color:#636166;margin-right:12px;";
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string query0 = "SELECT Uploads FROM SuMCreators WHERE UserID = @CID";
                SqlCommand sqlCmd0 = new SqlCommand(query0, sqlCon);
                sqlCmd0.Parameters.AddWithValue("@MangaCreator", CreatorName);
                var CR = sqlCmd0.ExecuteScalar();
                if (CR != null)
                {
                    int[] PCR = ST0(CR.ToString());
                    for (int i = 0; i < PCR.Length; i++)
                    {
                        string query = "SELECT MangaName FROM SuMManga WHERE MangaID = @MangaID";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                        sqlCmd.Parameters["@MangaID"].Value = PCR[i];
                        var g = sqlCmd.ExecuteScalar();
                        string MangaName = g.ToString();

                        query = "SELECT SuMThemeColor FROM SuMManga WHERE MangaID = @MangaID";
                        sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                        sqlCmd.Parameters["@MangaID"].Value = PCR[i];
                        g = sqlCmd.ExecuteScalar();
                        string MangaTheme = g.ToString();

                        query = "SELECT CExplorerLink FROM SuMManga WHERE MangaID = @MangaID";
                        sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                        sqlCmd.Parameters["@MangaID"].Value = PCR[i];
                        g = sqlCmd.ExecuteScalar();
                        string ExplorerLink = g.ToString();
                        query = "SELECT ChaptersNumber FROM SuMManga WHERE MangaID = @MangaID";
                        sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                        sqlCmd.Parameters["@MangaID"].Value = PCR[i];
                        var un = sqlCmd.ExecuteScalar();
                        int ChaptersNum = Convert.ToInt32(un);
                        ExplorerLink += "&CN=" + ChaptersNum.ToString() + "&VC=" + PCR[i].ToString() + "&TC=" + MangaTheme + "&CEPG=1";

                        query = "SELECT MangaCoverLink FROM SuMManga WHERE MangaID = @MangaID";
                        sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                        sqlCmd.Parameters["@MangaID"].Value = PCR[i];
                        g = sqlCmd.ExecuteScalar();
                        string CoverLink = g.ToString();

                        CreatorMainContant.InnerHtml += BuildRestCard(MangaName, MangaTheme, ExplorerLink, CoverLink);
                    }
                }
                sqlCon.Close();
            }
        }
        protected void LoadDrafs(string CreatorName,int CID)
        {
            upl.Attributes["style"] = "color:#636166;margin-left:12px;";
            dra.Attributes["style"] = "color:var(--SuMThemeColor);";
            inp.Attributes["style"] = "color:#636166;margin-right:12px;";
            ADDB.Attributes["style"] = "background-color:var(--SuMThemeColor);color:#ffffff;border-radius:16px;height:fit-content;width:fit-content;font-size:160%;";
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                string q = "SELECT Drafs FROM SuMCreators WHERE UserID=@CID";
                SqlCommand cmd = new SqlCommand(q, sqlCon);
                cmd.Parameters.AddWithValue("@CID", SqlDbType.Int);
                cmd.Parameters["@CID"].Value = CID;
            }
        }
        protected void LoadInProsses(string CreatorName,int CID)
        {
            upl.Attributes["style"] = "color:#636166;margin-left:12px;";
            dra.Attributes["style"] = "color:#636166;";
            inp.Attributes["style"] = "color:var(--SuMThemeColor);margin-right:12px;";
            ADDB.Attributes["style"] = "background-color:var(--SuMThemeColor);color:#ffffff;border-radius:16px;height:fit-content;width:fit-content;font-size:160%;";
        }
        protected string BuildRestCard(string MangaName, string MangaTheme, string ExplorerLink, string CoverLink)
        {
            char sc = '"'; string scfu = sc.ToString();
            string astyle = scfu + "width:100vw;height:74px;background-color:#ffffff;border-bottom:#f2f2f2 1px solid;border-top:#f2f2f2 1px solid;position:relative;margin-left:0px;display:block;" + scfu;
            string imgstyle = scfu + "height:74px;width:74px;object-fit:cover;display:inline;margin-left:0px;border-radius:0px;float:left;margin-left:0px;" + scfu;
            string h3style = scfu + "color:" + MangaTheme + ";margin-top:-42px;float:left;margin-left:6px;margin-top:12px;" + scfu;
            string RS = "<a style=" + astyle + " href=" + ExplorerLink + "><img src=" + CoverLink + " style=" + imgstyle + "><h3 style=" + h3style + ">" + MangaName + "</h3><br style=" + "float:left;" + "></a>";
            return RS;
        }
        /*protected int[] RIDsTArray(string Raw) 
        {
            int L = 0;
            bool H = false;
            bool A = false;
            string num = "";
            char[] RawPross = Raw.ToCharArray();
            for (int i = 0; i < RawPross.Length; i++) 
            {
                if (RawPross[i] == '#') { H = true; L++; num = ""; }
                if (RawPross[i] != '#' && RawPross[i] != '&' && H == true) 
                {
                    num += RawPross[i].ToString();
                }
                if (RawPross[i] == '&')
                {
                    H = false;

                }
            }
        }*/
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