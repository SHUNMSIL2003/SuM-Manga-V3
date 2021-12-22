using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace SuM_Manga_V3.storeitems
{
    public partial class MangaExplorer : System.Web.UI.Page
    {
        /*protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Request.Browser.IsMobileDevice)
                MasterPageFile = "~/SuMManga.Mobile.Master";
        }*/
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            if (GetUserInfoCookie == null)
            {
                Response.Redirect("~/AccountETC/LoginETC.aspx");
            }
            else
            {
                if (Request.QueryString["Chapter"] == null || Request.QueryString["Manga"] == null) { backhome(); }
                else
                {
                    string MangaName = Request.QueryString["Manga"].ToString();
                    string ChapterX = Request.QueryString["Chapter"].ToString();
                    char[] chnum = ChapterX.ToCharArray();
                    for (int i = 0; i < chnum.Length; i++) { if (Char.IsDigit(chnum[i]) == false) { chnum[i] = '0'; } }
                    string chnumst = new string(chnum);
                    int ab = Int32.Parse(chnumst);
                    //MainCardT.InnerText = MangaName + " - Chapter " + ab.ToString();
                    string help0136 = "\\";
                    string epath = System.IO.Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
                    string ActivePath = epath + "\\storeitems\\" + MangaName + help0136 + ChapterX + help0136;
                    char[] ActivePatharr = ActivePath.ToCharArray();
                    if (System.IO.Directory.Exists(ActivePath) == true)
                    {
                        TheMangaPhotos.InnerHtml = "";
                        if (Request.QueryString["TC"] != null) { pfc.Attributes["style"] = "background-color:" + Request.QueryString["TC"].ToString() + ";"; }
                        string[] filePaths = System.IO.Directory.GetFiles(ActivePath, "*.jpg");
                        //string sendhtmlforchimges = "";
                        string deafultstartitems = "/storeitems/";
                        string slash0 = "/";
                        string imgstyle = "width:100%;max-width:800px;";
                        //string x = "lazy";
                        for (int i = 0; i < filePaths.Length; i++)
                        {
                            string filename = System.IO.Path.GetFileName(filePaths[i]);
                            TheMangaPhotos.InnerHtml += "<img class=" + "lazyload" + " style=" + imgstyle + " src=" + deafultstartitems + MangaName + slash0 + ChapterX + slash0 + filename + " /><br/>";
                        }
                        //string beforerelasecode = "";
                        //beforerelasecode += sendhtmlforchimges;
                        //TheMangaPhotos.InnerHtml = beforerelasecode;


                        UpdateChapterNumInCurr();


                        string pathstartnochx = "/storeitems/";
                        string extraexplore = "MangaExplorer.aspx";
                        string identifylast = "?Manga=" + Request.QueryString["Manga"].ToString();
                        string identifynexthelper = "Chapter=";
                        string NextCh = Request.QueryString["Chapter"].ToString();
                        if (NextCh == null) { Response.Redirect("~/404.aspx"); }
                        char[] NectChConvToInt = NextCh.ToCharArray();
                        int countNumLength = 0;
                        int PreFixedChapterNum = 0;
                        string FixedChapterNum = string.Empty;
                        int o = 0; int oo = 0; int ooo = 0; int oooo = 0;
                        for (int nc = 0; nc < NextCh.Length; nc++)
                        {
                            if (NectChConvToInt[nc] == '0' || NectChConvToInt[nc] == '1' || NectChConvToInt[nc] == '2' || NectChConvToInt[nc] == '3' || NectChConvToInt[nc] == '4' || NectChConvToInt[nc] == '5' || NectChConvToInt[nc] == '6' || NectChConvToInt[nc] == '7' || NectChConvToInt[nc] == '8' || NectChConvToInt[nc] == '9')
                            {
                                countNumLength++;
                                if (countNumLength == 1) { oooo = (int)Char.GetNumericValue(NectChConvToInt[nc]); }
                                if (countNumLength == 2) { ooo = (int)Char.GetNumericValue(NectChConvToInt[nc]); }
                                if (countNumLength == 3) { oo = (int)Char.GetNumericValue(NectChConvToInt[nc]); }
                                if (countNumLength == 4) { o = (int)Char.GetNumericValue(NectChConvToInt[nc]); }
                            }
                        }
                        PreFixedChapterNum = oooo * 1000 + ooo * 100 + oo * 10 + o * 1;
                        PreFixedChapterNum = PreFixedChapterNum + 1;
                        string ProccesingPreFixedChapterNum = Convert.ToString(PreFixedChapterNum);
                        int fixcount = ProccesingPreFixedChapterNum.Length;
                        if (fixcount == 1) { FixedChapterNum = "000" + ProccesingPreFixedChapterNum; }
                        if (fixcount == 2) { FixedChapterNum = "00" + ProccesingPreFixedChapterNum; }
                        if (fixcount == 3) { FixedChapterNum = "0" + ProccesingPreFixedChapterNum; }
                        if (fixcount == 4) { FixedChapterNum = ProccesingPreFixedChapterNum; }
                        string chaptertocheckexsis = Request.QueryString["Chapter"].ToString();
                        chaptertocheckexsis = NextChapterNum(chaptertocheckexsis);
                        string managtocheckexsis = Request.QueryString["Manga"].ToString();
                        string rootpath = System.IO.Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
                        string checkifitexsists = rootpath + "\\storeitems\\" + managtocheckexsis + "\\" + chaptertocheckexsis + "\\";
                        string CurWorker = "";
                        /*string NCN = chaptertocheckexsis;
                        NCN = NCN.Remove(0, 2);
                        if (Request.QueryString["UCICU"] == "T" && Request.QueryString["MID"] != null)
                        {
                            CurWorker = "&UCU=" + Request.QueryString["MID"] + "&CUUC=" + Convert.ToInt32(NCN);
                        }*/
                        if (Request.QueryString["UCU"] != null) { CurWorker = "&UCU=" + Request.QueryString["UCU"].ToString(); }
                        if (System.IO.Directory.Exists(checkifitexsists) == true)
                        {
                            //"<a class="+"btn btn-primary btn-sm"+" href=" "> Next Chapter  &raquo;</a>"
                            string sendNextChapter = "<a style=" + "color:#ffffff;" + " class=" + "btn btn-primary btn-sm" + " href=" + pathstartnochx + extraexplore + identifylast + "&" + identifynexthelper + "ch" + FixedChapterNum + "&TC=" + Request.QueryString["TC"].ToString() + CurWorker + "> Next Chapter  &raquo;</a>";
                            NextChapter.InnerHtml = sendNextChapter;
                        }
                        else
                        {
                            NextChapter.InnerHtml = "<h4 style=" + "color:#ffffff;" + ">No Chapters Left for now!</h4>";
                        }
                        AddToCurrIfNot();
                    }
                    else
                    {
                        Response.Redirect("~/404.aspx");
                    }
                }
            }
        }
        protected void UpdateChapterNumInCurr()
        {
            if (Request.QueryString["UCU"] != null)
            {
                int MID = Convert.ToInt32(Request.QueryString["UCU"].ToString());
                HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
                int UID = Convert.ToInt32(Convert.ToString(GetUserInfoCookie["ID"]));
                bool CIIDI = IsItAlraedyInCurr(MID, UID);

                if (CIIDI == true)
                {
                    string NCN = Request.QueryString["Chapter"].ToString();
                    NCN = NCN.Remove(0, 2);
                    int CurPageCH = Convert.ToInt32(NCN);

                    using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:summangaserver.database.windows.net,1433;Initial Catalog=SuMMangaSQL;User Id=summangasqladmin;Password=55878833sqlpass#S"))
                    {
                        sqlCon.Open();
                        string qwi = "SELECT Curr FROM SuMUsersAccounts WHERE UserID = @UID";
                        SqlCommand sqlCmd00 = new SqlCommand(qwi, sqlCon);
                        sqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                        sqlCmd00.Parameters["@UID"].Value = UID;
                        var RawRes = sqlCmd00.ExecuteScalar();
                        string query = "SELECT MangaName FROM SuMManga WHERE MangaID = @MID";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@MID", SqlDbType.Int);
                        sqlCmd.Parameters["@MID"].Value = MID;
                        var CIME = sqlCmd.ExecuteScalar();
                        bool MDE = false;
                        if (CIME != null) { MDE = true; }
                        if (RawRes != null && MDE == true)
                        {
                            string Res = RawRes.ToString();
                            int[,] R = ST1(Res);
                            for (int i = 0; i < R.GetLength(1); i++)
                            {
                                if (R[0, i] == MID)
                                {
                                    if ((R[1, i] + 1) == CurPageCH)
                                    {
                                        R[1, i] = CurPageCH;
                                    }
                                }
                            }
                            string RawST1 = RevercST1(R);
                            string InsertQ = "UPDATE SuMUsersAccounts SET Curr = @NewCurr WHERE UserID = @UID";
                            SqlCommand sqlCmdIn = new SqlCommand(InsertQ, sqlCon);
                            sqlCmdIn.Parameters.AddWithValue("@UID", SqlDbType.Int);
                            sqlCmdIn.Parameters["@UID"].Value = UID;
                            sqlCmdIn.Parameters.AddWithValue("@NewCurr", RawST1);
                            sqlCmdIn.ExecuteNonQuery();
                        }
                        sqlCon.Close();
                    }
                }
            }
        }
        protected string RevercST1(int[,] ST1R) 
        {
            string Result = "";
            for (int i = 0; i < ST1R.GetLength(1); i++) 
            {
                Result += "#" + ST1R[0, i].ToString() + ";" + ST1R[1, i].ToString() + "&";
            }
            return Result;
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
        protected void AddToCurrIfNot()
        {
            var Ce = Request.QueryString["ADTCU"];
            if (Ce != null)
            {
                string RM = Ce.ToString();
                HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
                int UID = Convert.ToInt32(Convert.ToString(GetUserInfoCookie["ID"]));
                if (IsItAlraedyInCurr(Convert.ToInt32(Ce.ToString()), UID) == false)
                {
                    using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:summangaserver.database.windows.net,1433;Initial Catalog=SuMMangaSQL;User Id=summangasqladmin;Password=55878833sqlpass#S"))
                    {
                        sqlCon.Open();
                        string qwi = "SELECT Curr FROM SuMUsersAccounts WHERE UserID = @UID";
                        SqlCommand sqlCmd00 = new SqlCommand(qwi, sqlCon);
                        sqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                        sqlCmd00.Parameters["@UID"].Value = UID;
                        var RawRes = sqlCmd00.ExecuteScalar();

                        string query = "SELECT MangaName FROM SuMManga WHERE MangaID = @MID";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@MID", SqlDbType.Int);
                        sqlCmd.Parameters["@MID"].Value = Convert.ToInt32(Ce.ToString());
                        var CIME = sqlCmd00.ExecuteScalar();
                        bool MDE = false;
                        if (CIME != null) { MDE = true; }

                        if (RawRes != null && MDE == true)
                        {
                            query = "UPDATE SuMUsersAccounts SET Curr = @NewCurr WHERE UserID = @UID";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@UID", SqlDbType.Int);
                            sqlCmd.Parameters["@UID"].Value = UID;
                            sqlCmd.Parameters.AddWithValue("@NewCurr", RawRes.ToString() + "#" + Ce.ToString() + ";1&");
                            sqlCmd.ExecuteNonQuery();
                            sqlCon.Close();
                        }
                        else
                        {
                            if (MDE == true)
                            {
                                query = "UPDATE SuMUsersAccounts SET Curr = @NewCurr WHERE UserID = @UID";
                                sqlCmd = new SqlCommand(query, sqlCon);
                                sqlCmd.Parameters.AddWithValue("@UID", SqlDbType.Int);
                                sqlCmd.Parameters["@UID"].Value = UID;
                                sqlCmd.Parameters.AddWithValue("@NewCurr", "#" + Ce.ToString() + ";1&");
                                sqlCmd.ExecuteNonQuery();
                                sqlCon.Close();
                            }
                        }
                        sqlCon.Close();
                    }
                }
            }
        }
        protected bool IsItAlraedyInCurr(int MID, int UID)
        {

            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:summangaserver.database.windows.net,1433;Initial Catalog=SuMMangaSQL;User Id=summangasqladmin;Password=55878833sqlpass#S"))
            {
                sqlCon.Open();
                string qwi = "SELECT Curr FROM SuMUsersAccounts WHERE UserID = @UID";
                SqlCommand sqlCmd00 = new SqlCommand(qwi, sqlCon);
                sqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                sqlCmd00.Parameters["@UID"].Value = UID;
                var RawRes = sqlCmd00.ExecuteScalar();
                if (RawRes != null)
                {
                    string Res = RawRes.ToString();
                    int[] R = ST11(Res);
                    for (int i = 0; i < R.Length; i++)
                    {
                        if (R[i] == MID)
                        {
                            return true;
                        }
                    }
                    return false;
                }
                else { return false; }
            }
        }
        protected int[] ST11(string x)
        {
            Queue<int> R1 = new Queue<int>();
            bool fh = false;
            bool fc = false;
            string A1 = "";
            char[] aa = x.ToCharArray();
            for (int i = 0; i < aa.Length; i++)
            {
                if (aa[i] == '&')
                {
                    fh = false;
                    fc = false;
                    R1.Enqueue(Convert.ToInt32(A1));
                    A1 = "";
                }
                if (aa[i] == ';') { fc = true; }
                if (fh == true && fc == false)
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
        public void backhome()
        {
            Response.Redirect("~/404.aspx");
        }
        public static string NextChapterNum(string cname)
        {
            char[] pross = cname.ToCharArray();
            int num = 0;
            int help0 = 5;
            int md = 0;
            for (int d = 2; d < pross.Length; d++)
            {
                    if (pross[d] == '0' && (d + 1) < pross.Length && pross[d + 1] != '9')
                    {
                        md++;
                    }
                    help0--;
                    int help1 = 0;
                    if (help0 == 4) { help1 = 1000; }
                    if (help0 == 3) { help1 = 100; }
                    if (help0 == 2) { help1 = 10; }
                    if (help0 == 1) { help1 = 1; }
                    int sf = pross[d] - '0';
                    num += (help1) * sf;
            }
            string zeros = "";
            while (md > 0) { md--; zeros += "0"; }
            int xnum = num + 1;
            string nnum = (xnum).ToString();
            cname = "ch" + zeros + nnum;
            return cname;
        }
    }
}