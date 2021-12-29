using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace SuM_Manga_V3
{
    public partial class UserLibrary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
                if (GetUserInfoCookie == null)
                {
                    Response.Redirect("~/AccountETC/LoginETC.aspx");
                }
                else
                {
                    int UID = Convert.ToInt32(Convert.ToString(GetUserInfoCookie["ID"]));
                    var CT = Request.QueryString["RT"];
                    if (CT != null)
                    {
                        string CTPSK = CT.ToString();
                        if (CT == "Curr" || CT == "Fav" || CT == "Wanna")
                        {
                            if (CT == "Curr") 
                            { 
                                LoadReqContant("Curr", UID);
                                cr.Attributes["style"] = "margin-left:8px;color:#6840D9;";
                                cr.Attributes["class"] = "pulse animated";
                                wr.Attributes["style"] = "margin-right:8px;color:#636166;";
                                mf.Attributes["style"] = "margin-right:3px;margin-left:3px;color:#636166;";
                            }
                            else 
                            {
                                if (CT == "Fav") 
                                { 
                                    LoadReqContant("Fav", UID);
                                    mf.Attributes["style"] = "margin-right:3px;margin-left:3px;color:#6840D9;";
                                    mf.Attributes["class"] = "pulse animated";
                                    cr.Attributes["style"] = "margin-left:8px;color:#636166;";
                                    wr.Attributes["style"] = "margin-right:8px;color:#636166;";
                                }
                                else 
                                { 
                                    LoadReqContant("Wanna", UID);
                                    wr.Attributes["style"] = "margin-right:8px;color:#6840D9;";
                                    wr.Attributes["class"] = "pulse animated";
                                    cr.Attributes["style"] = "margin-left:8px;color:#636166;";
                                    mf.Attributes["style"] = "margin-right:3px;margin-left:3px;color:#636166;";
                                }
                            }
                        }
                        else { Response.Redirect("~/404.aspx"); }
                    }
                    else { Response.Redirect("~/404.aspx"); }
                }
            }
        }
        protected int[,] ST1(string x) 
        {
            Queue<int> R1 = new Queue<int>();
            Queue<int> R2 = new Queue<int>();
            bool fh = false;
            bool fc = false;
            string A1 = "";
            string A2 = "";
            char[] aa = x.ToCharArray();
            for (int i = 0; i < aa.Length; i++)
            {
                if (aa[i] == '&') 
                { 
                    fh = false;
                    fc = false;
                    R1.Enqueue(Convert.ToInt32(A1));
                    R2.Enqueue(Convert.ToInt32(A2));
                    A1 = "";
                    A2 = "";
                }
                if (fh == true && fc == true)
                {
                    A2 += aa[i].ToString();
                }
                if (aa[i] == ';') { fc = true; }
                if (fh == true && fc == false)
                {
                    A1 += aa[i].ToString();
                }
                if (aa[i] == '#') { fh = true; }
            }
            int RdL = R1.Count;
            int[,] RS = new int[2, RdL];
            int RFDH = 0;
            while (R1.Count > 0) 
            {
                RS[0, RFDH] = R1.Dequeue();
                RFDH++;
            }
            RFDH = 0;
            while (R2.Count > 0)
            {
                RS[1, RFDH] = R2.Dequeue();
                RFDH++;
            }
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
        protected void LoadReqContant(string Type, int UserID)
        {
            bool fail = false;
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string qwi = "SELECT " + Type + " FROM SuMUsersAccounts WHERE UserID = @UID";
                SqlCommand sqlCmd00 = new SqlCommand(qwi, sqlCon);
                sqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                sqlCmd00.Parameters["@UID"].Value = UserID;
                var RawRes = sqlCmd00.ExecuteScalar();
                if (RawRes != null)
                {
                    string Res = RawRes.ToString();
                    if (Type == "Curr")
                    {
                        int[,] R = ST1(Res);//JsonConvert.DeserializeObject<int[,]>(a);
                        for (int i = (R.GetLength(1) - 1); i > (-1); i--)
                        {
                            //ShowReqContant.InnerHtml += "<p> " + R[0, i].ToString() + "|" + R[1, i].ToString() + " </p>"; DEBUG

                            string query = "SELECT MangaName FROM SuMManga WHERE MangaID = @MangaID";
                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = R[0, i];
                            var g = sqlCmd.ExecuteScalar();
                            string MangaName = g.ToString();

                            query = "SELECT SuMThemeColor FROM SuMManga WHERE MangaID = @MangaID";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = R[0, i];
                            g = sqlCmd.ExecuteScalar();
                            string MangaTheme = g.ToString();

                            query = "SELECT CExplorerLink FROM SuMManga WHERE MangaID = @MangaID";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = R[0, i];
                            g = sqlCmd.ExecuteScalar();
                            string ExplorerLink = g.ToString();
                            query = "SELECT ChaptersNumber FROM SuMManga WHERE MangaID = @MangaID";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = R[0, i];
                            var un = sqlCmd.ExecuteScalar();
                            int ChaptersNum = Convert.ToInt32(un);
                            ExplorerLink += "&CN=" + ChaptersNum.ToString() + "&VC=" + R[0, i].ToString() + "&TC=" + MangaTheme;

                            query = "SELECT MangaCoverLink FROM SuMManga WHERE MangaID = @MangaID";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = R[0, i];
                            g = sqlCmd.ExecuteScalar();
                            string CoverLink = g.ToString();

                            query = "SELECT MangaCreator FROM SuMManga WHERE MangaID = @MangaID";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = R[0, i];
                            g = sqlCmd.ExecuteScalar();
                            string CreatorName = g.ToString();

                            ShowReqContant.InnerHtml += BuildCurrCard(MangaName, MangaTheme, ExplorerLink, R[1, i].ToString(), CoverLink, CreatorName);
                            if (i == 0) { ShowReqContant.InnerHtml += "<br/><br/><br/><br/>"; }
                        }
                    }
                    else 
                    {

                        int[] R = ST0(Res);//JsonConvert.DeserializeObject<int[,]>(a);
                        for (int i = 0; i < R.Length; i++)
                        {
                            //ShowReqContant.InnerHtml += "<p> " + R[0, i].ToString() + "|" + R[1, i].ToString() + " </p>"; DEBUG

                            string query = "SELECT MangaName FROM SuMManga WHERE MangaID = @MangaID";
                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = R[i];
                            var g = sqlCmd.ExecuteScalar();
                            string MangaName = g.ToString();

                            query = "SELECT SuMThemeColor FROM SuMManga WHERE MangaID = @MangaID";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = R[i];
                            g = sqlCmd.ExecuteScalar();
                            string MangaTheme = g.ToString();

                            query = "SELECT CExplorerLink FROM SuMManga WHERE MangaID = @MangaID";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = R[i];
                            g = sqlCmd.ExecuteScalar();
                            string ExplorerLink = g.ToString();
                            query = "SELECT ChaptersNumber FROM SuMManga WHERE MangaID = @MangaID";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = R[i];
                            var un = sqlCmd.ExecuteScalar();
                            int ChaptersNum = Convert.ToInt32(un);
                            ExplorerLink += "&CN=" + ChaptersNum.ToString() + "&VC=" + R[i].ToString() + "&TC=" + MangaTheme;

                            query = "SELECT MangaCoverLink FROM SuMManga WHERE MangaID = @MangaID";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = R[i];
                            g = sqlCmd.ExecuteScalar();
                            string CoverLink = g.ToString();

                            ShowReqContant.InnerHtml += BuildRestCard(MangaName, MangaTheme, ExplorerLink, CoverLink);
                        }
                    }
                    sqlCon.Close();
                }
                else 
                {
                    fail = true;
                    sqlCon.Close();
                }
            }
            if (fail == true) { Response.Redirect("~/404.aspx"); }
        }
        protected string BuildCurrCard(string MangaName, string MangaTheme, string ExplorerLink, string chapter,string CoverLink,string MangaCreator) 
        {
            char sc = '"'; string scfu = sc.ToString();
            string divST = "<div style=" + "overflow:clip;width:fit-content;height:fit-content;" + ">";
            string PDivST = "<div style=" + "margin-top:52px;display:block;width:fit-content;padding-left:8px;" + ">";
            string astyle = scfu + "width:100vw;height:100px;position:relative;margin-left:0px;display:block;" + scfu;
            string imgstyle = scfu + "height:84px;width:84px;object-fit:cover;display:inline;border-radius:4px;float:left;margin:8px;" + scfu;
            string h4style = scfu + "color:" + MangaTheme + ";margin-top:-42px;float:left;margin-left:6px;margin-top:12px;width:calc(100% - 120px);" + scfu;
            string hr = "<hr style=" + sc.ToString() + "margin:0 auto !important;height:1px;border-width:0;color:rgba(99,99,99,0.9);background-color:rgba(99,99,99,0.9);width:96vw;opacity:0.24;margin:0px;margin-block:0px;" + sc.ToString() + ">";
            string AuthString = "<p style=" + "color:rgb(0,0,0,0.50);float:left;margin-top:-10px;margin-left:6px;" + ">By <b style=" + "font-size:80%;" + ">" + MangaCreator + "</b></p>";
            string RS = divST + "<a onclick=" + sc.ToString() + "fetch('" + ExplorerLink + "', { method: 'GET' }).then(res => {location.href = '" + ExplorerLink + "';}).catch(err => { location.href = '/SuMOffline.html'; })" + sc.ToString() + " style=" + astyle + " ><img src=" + CoverLink + " class=" + sc.ToString() + "animated pulse" + sc.ToString() + " style=" + imgstyle + "><h4 style=" + h4style + ">" + MangaName + "</h4>" + AuthString + "<br style=" + "float:left;" + ">" + PDivST + "<p style=" + "color:#6b6b6b;font-size:84%;" + ">Chapter: " + chapter + "</p></div></a></div>" + hr;
            return RS;
        }
        protected string BuildRestCard(string MangaName, string MangaTheme, string ExplorerLink, string CoverLink)
        {
            char sc = '"'; string scfu = sc.ToString();
            string astyle = scfu + "width:100vw;height:74px;background-color:#ffffff;border-bottom:#f2f2f2 1px solid;border-top:#f2f2f2 1px solid;position:relative;margin-left:0px;display:block;" + scfu;
            string imgstyle = scfu + "height:74px;width:74px;object-fit:cover;display:inline;margin-left:0px;border-radius:0px;float:left;margin-left:0px;" + scfu;
            string h3style = scfu + "color:" + MangaTheme + ";margin-top:-42px;float:left;margin-left:6px;margin-top:12px;" + scfu;
            string RS = "<a onclick=" + sc.ToString() + "fetch('" + ExplorerLink + "', { method: 'GET' }).then(res => {location.href = '" + ExplorerLink + "';}).catch(err => { location.href = '/SuMOffline.html'; })" + sc.ToString() + " style=" + astyle + " ><img src=" + CoverLink + " style=" + imgstyle + "><h3 style=" + h3style + ">" + MangaName + "</h3><br style=" + "float:left;" + "></a>";
            return RS;
        }
    }
}