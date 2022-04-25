using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient; using MySql.Data.MySqlClient; using System.Configuration;
using System.Data;

namespace SuM_Manga_V3.storeitems
{
    public partial class MangaExplorerCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            if (GetUserInfoCookie == null)
            {
                Response.Redirect("~/AccountETC/LoginETC.aspx");
            }
            else
            {
                if (IsPostBack == false)
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
                        string help0136 = "\\";
                        string epath = System.IO.Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
                        string ActivePath = epath + "\\storeitems\\" + MangaName + help0136 + ChapterX + help0136;
                        if (System.IO.Directory.Exists(ActivePath) == true)
                        {
                            TheMangaPhotos.InnerHtml = "";
                            string[] filePaths = System.IO.Directory.GetFiles(ActivePath, "*.jpg");
                            string deafultstartitems = "/storeitems/";
                            string slash0 = "/";
                            string imgstyle = '"'.ToString() + "width:100%;margin-bottom:0px !important;display:block !important;" + '"'.ToString();
                            string LazyLoading = "loading=" + '"'.ToString() + "lazy" + '"'.ToString();
                            for (int i = 0; i < (filePaths.Length - 1); i++)
                            {
                                string filename = System.IO.Path.GetFileName(filePaths[i]);
                                TheMangaPhotos.InnerHtml += "<img " + LazyLoading + " style=" + imgstyle + " src=" + deafultstartitems + MangaName + slash0 + ChapterX + slash0 + filename + " />";
                            }
                            TheMangaPhotos.InnerHtml += "<img " + LazyLoading + " style=" + '"'.ToString() + "width:100%;margin-bottom:0px !important;display:block !important;" + '"'.ToString() + " src=" + deafultstartitems + MangaName + slash0 + ChapterX + slash0 + System.IO.Path.GetFileName(filePaths[filePaths.Length - 1]) + " />";
                            UpdateChapterNumInCurr();
                            string pathstartnochx = "/storeitems/";
                            string extraexplore = "MangaExplorer.aspx";
                            string identifylast = "?Manga=" + Request.QueryString["Manga"].ToString();
                            string identifynexthelper = "Chapter=";
                            char sc = '"';
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
                            if (Request.QueryString["UCU"] != null) { CurWorker = "&UCU=" + Request.QueryString["UCU"].ToString(); }
                            if (Request.QueryString["ADTCU"] != null && Request.QueryString["UCU"] == null) { CurWorker = "&UCU=" + Request.QueryString["ADTCU"].ToString(); }
                            string SuMCExplorerSVG = "<svg xmlns=" + '"' + "http://www.w3.org/2000/svg" + " enable-background=" + '"' + "new 0 0 24 24" + '"' + " height=26px viewBox=" + '"' + "0 0 24 24" + '"' + " width=26px fill=" + Request.QueryString["TC"].ToString() + "><g><rect fill=none height=24 width=24/><rect fill=none height=24 width=24/></g><g><path d=" + '"' + "M17.5,4.5c-1.95,0-4.05,0.4-5.5,1.5c-1.45-1.1-3.55-1.5-5.5-1.5c-1.45,0-2.99,0.22-4.28,0.79C1.49,5.62,1,6.33,1,7.14 l0,11.28c0,1.3,1.22,2.26,2.48,1.94C4.46,20.11,5.5,20,6.5,20c1.56,0,3.22,0.26,4.56,0.92c0.6,0.3,1.28,0.3,1.87,0 c1.34-0.67,3-0.92,4.56-0.92c1,0,2.04,0.11,3.02,0.36c1.26,0.33,2.48-0.63,2.48-1.94l0-11.28c0-0.81-0.49-1.52-1.22-1.85 C20.49,4.72,18.95,4.5,17.5,4.5z M21,17.23c0,0.63-0.58,1.09-1.2,0.98c-0.75-0.14-1.53-0.2-2.3-0.2c-1.7,0-4.15,0.65-5.5,1.5V8 c1.35-0.85,3.8-1.5,5.5-1.5c0.92,0,1.83,0.09,2.7,0.28c0.46,0.1,0.8,0.51,0.8,0.98V17.23z" + '"' + "/><g/><path d=" + '"' + "M13.98,11.01c-0.32,0-0.61-0.2-0.71-0.52c-0.13-0.39,0.09-0.82,0.48-0.94c1.54-0.5,3.53-0.66,5.36-0.45 c0.41,0.05,0.71,0.42,0.66,0.83c-0.05,0.41-0.42,0.71-0.83,0.66c-1.62-0.19-3.39-0.04-4.73,0.39 C14.13,10.99,14.05,11.01,13.98,11.01z" + '"' + "/><path d=" + '"' + "M13.98,13.67c-0.32,0-0.61-0.2-0.71-0.52c-0.13-0.39,0.09-0.82,0.48-0.94c1.53-0.5,3.53-0.66,5.36-0.45 c0.41,0.05,0.71,0.42,0.66,0.83c-0.05,0.41-0.42,0.71-0.83,0.66c-1.62-0.19-3.39-0.04-4.73,0.39 C14.13,13.66,14.05,13.67,13.98,13.67z" + '"' + "/><path d=" + '"' + "M13.98,16.33c-0.32,0-0.61-0.2-0.71-0.52c-0.13-0.39,0.09-0.82,0.48-0.94c1.53-0.5,3.53-0.66,5.36-0.45 c0.41,0.05,0.71,0.42,0.66,0.83c-0.05,0.41-0.42,0.7-0.83,0.66c-1.62-0.19-3.39-0.04-4.73,0.39 C14.13,16.32,14.05,16.33,13.98,16.33z" + '"' + "/></g></svg>";
                            string BackToMangaPageBTN = "<a style=" + "border-radius:22px;padding:8px;background-color:var(--SuMDWhite);margin:8px;margin-right:8px;color:" + Request.QueryString["TC"].ToString() + ";display:inline-block;padding-left:12px;padding-right:12px;" + " class=" + '"'.ToString() + "bg-white shadow-sm btn animated fadeInUp" + '"'.ToString() + " onclick=" + sc.ToString() + "androidAPIs.CloseSuMReaderMode();" + sc.ToString() + " >" + SuMCExplorerSVG + "</a>";
                            NextChapter.InnerHtml = BackToMangaPageBTN;
                            if (System.IO.Directory.Exists(checkifitexsists) == true)
                            {
                                int ChapterCValue = 0;
                                string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
                                {
                                    MySqlCon.Open();
                                    object un;
                                    string query = "SELECT ChapterCValue FROM SuMManga WHERE MangaID = @MangaID";
                                    MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
                                    MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                                    MySqlCmd.Parameters["@MangaID"].Value = Convert.ToInt32(Request.QueryString["VC"].ToString());
                                    un = MySqlCmd.ExecuteScalar();
                                    ChapterCValue = Convert.ToInt32(un);
                                    MySqlCon.Close();
                                }
                                string sendNextChapter = "<a style=" + "border-radius:22px;padding:8px;background-color:var(--SuMDWhite);margin:8px;margin-right:8px;color:" + Request.QueryString["TC"].ToString() + ";display:inline-block;" + " class=" + '"'.ToString() + "bg-white shadow-sm btn animated fadeInUp" + '"'.ToString() + " onclick=" + '"'.ToString() + "androidAPIs.SuMExploreLoadReader('" + pathstartnochx + extraexplore + identifylast + "&" + identifynexthelper + "ch" + FixedChapterNum + "&VC=" + Request.QueryString["VC"].ToString() + "&TC=" + Request.QueryString["TC"].ToString() + CurWorker + "'," + ChapterCValue + ");" + sc.ToString() + " ><b>Next &raquo;</b></a>";
                                NextChapter.InnerHtml += sendNextChapter;
                            }
                            else
                            {
                                NextChapter.InnerHtml += "<a onclick=" + '"' + "androidAPIs.ShowSuMToastsOverview('No more chapters available!'); androidAPIs.VIBRATEPhone();" + '"' + " style=" + "border-radius:22px;padding:8px;background-color:var(--SuMDWhiteOP64);margin:8px;margin-right:8px;color:" + Request.QueryString["TC"].ToString() + ";display:inline-block;" + " class=" + '"'.ToString() + " shadow-sm btn animated fadeInUp" + '"'.ToString() + "><b>Next &raquo;</b></a>";
                            }
                            AddToCurrIfNot();
                        }
                        else
                        {
                            Response.Redirect("~/404.aspx");
                        }
                    }
                    int UID = Convert.ToInt32(GetUserInfoCookie["ID"].ToString());
                    ReasentMarker(UID);
                }
                {
                    AddOneView();
                    int UID = Convert.ToInt32(GetUserInfoCookie["ID"].ToString());
                    ReasentMarker(UID);
                }
            }
        }
        protected void ReasentMarker(int UID)
        {
            object RawRes;
            string NewSol = string.Empty;
            string Target = "#" + Request.QueryString["VC"].ToString() + "&";
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string qwi = "SELECT Resently FROM SuMUsersAccounts WHERE UserID = @UID";
                MySqlCommand MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                MySqlCmd00.Parameters["@UID"].Value = UID;
                RawRes = MySqlCmd00.ExecuteScalar();
                if (RawRes != null)
                {
                    if (RawRes.ToString().Contains(Target) == true)
                    {
                        NewSol = Target + RawRes.ToString().Replace(Target, "");
                    }
                    else
                    {
                        NewSol = Target + RawRes.ToString();
                    }
                }
                else
                {
                    NewSol = Target;
                }
                qwi = "UPDATE SuMUsersAccounts SET Resently = @NEWResently WHERE UserID = @UID";
                MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                MySqlCmd00.Parameters.AddWithValue("@NEWResently", NewSol);
                MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                MySqlCmd00.Parameters["@UID"].Value = UID;
                MySqlCmd00.ExecuteNonQuery();
                MySqlCon.Close();
            }
        }
        protected void AddOneView()
        {
            string x = Request.QueryString["VC"];
            int y = Convert.ToInt32(x);
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string query = "UPDATE SuMManga SET MangaViews = MangaViews + 1 WHERE MangaID = @MangaID";
                MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
                MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                MySqlCmd.Parameters["@MangaID"].Value = y;
                MySqlCmd.ExecuteNonQuery();
                MySqlCon.Close();
            }
        }
        protected void AddToFavList(object sender, EventArgs e)
        {
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            if (GetUserInfoCookie != null)
            {
                int UID = Convert.ToInt32(GetUserInfoCookie["ID"].ToString());
                object RawRes;
                string NewLIST = string.Empty;
                bool NeedUpdate = false;
                string Target = "#" + Request.QueryString["VC"].ToString() + "&";
                string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
                {
                    MySqlCon.Open();
                    string qwi = "SELECT Fav FROM SuMUsersAccounts WHERE UserID = @UID";
                    MySqlCommand MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                    MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                    MySqlCmd00.Parameters["@UID"].Value = UID;
                    RawRes = MySqlCmd00.ExecuteScalar();
                    if (RawRes != null)
                    {
                        if (RawRes.ToString().Contains(Target) == false)
                        {
                            NewLIST = RawRes.ToString() + Target;
                            NeedUpdate = true;
                        }
                    }
                    if (NeedUpdate == true)
                    {
                        qwi = "UPDATE SuMUsersAccounts SET Fav = @NEWFav WHERE UserID = @UID";
                        MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                        MySqlCmd00.Parameters.AddWithValue("@NEWFav", NewLIST);
                        MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                        MySqlCmd00.Parameters["@UID"].Value = UID;
                        MySqlCmd00.ExecuteNonQuery();
                    }
                    MySqlCon.Close();
                }
            }
        }
        protected void FavListManager(int UID)
        {
            int MID = Convert.ToInt32(Request.QueryString["VC"].ToString());
            bool ItsAFav = false;
            object RawRes;
            string ThemeColor = Request.QueryString["TC"].ToString();
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string qwi = "SELECT Fav FROM SuMUsersAccounts WHERE UserID = @UID";
                MySqlCommand MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                MySqlCmd00.Parameters["@UID"].Value = UID;
                RawRes = MySqlCmd00.ExecuteScalar();
                MySqlCon.Close();
            }
            if (RawRes != null)
            {
                if (RawRes.ToString().Contains("#" + MID + "&") == true)
                {
                    ItsAFav = true;
                }
            }
        }
        protected void RemoveFromFavList(object sender, EventArgs e)
        {
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            if (GetUserInfoCookie != null)
            {
                int UID = Convert.ToInt32(GetUserInfoCookie["ID"].ToString());
                object RawRes;
                string NewLIST = string.Empty;
                bool NeedUpdate = false;
                string Target = "#" + Request.QueryString["VC"].ToString() + "&";
                string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
                {
                    MySqlCon.Open();
                    string qwi = "SELECT Fav FROM SuMUsersAccounts WHERE UserID = @UID";
                    MySqlCommand MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                    MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                    MySqlCmd00.Parameters["@UID"].Value = UID;
                    RawRes = MySqlCmd00.ExecuteScalar();
                    if (RawRes != null)
                    {
                        if (RawRes.ToString().Contains(Target) == true)
                        {
                            NewLIST = RawRes.ToString().Replace(Target, "");
                            NeedUpdate = true;
                        }
                    }
                    if (NeedUpdate == true)
                    {
                        qwi = "UPDATE SuMUsersAccounts SET Fav = @NEWFav WHERE UserID = @UID";
                        MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                        MySqlCmd00.Parameters.AddWithValue("@NEWFav", NewLIST);
                        MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                        MySqlCmd00.Parameters["@UID"].Value = UID;
                        MySqlCmd00.ExecuteNonQuery();
                    }
                    MySqlCon.Close();
                }
            }
        }
        protected string GetMangaNameMySql(string MangaID) {
            string CurrM = string.Empty;
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string qwi = "SELECT MangaName FROM SuMManga WHERE MangaID = @MangaID";
                MySqlCommand MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                MySqlCmd00.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                MySqlCmd00.Parameters["@MangaID"].Value = MangaID;
                var Raw = MySqlCmd00.ExecuteScalar();
                CurrM = Raw.ToString();
                MySqlCon.Close();
            }
            return CurrM;
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

                    string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
                    {
                        MySqlCon.Open();
                        string qwi = "SELECT Curr FROM SuMUsersAccounts WHERE UserID = @UID";
                        MySqlCommand MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                        MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                        MySqlCmd00.Parameters["@UID"].Value = UID;
                        var RawRes = MySqlCmd00.ExecuteScalar();
                        string query = "SELECT MangaName FROM SuMManga WHERE MangaID = @MID";
                        MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
                        MySqlCmd.Parameters.AddWithValue("@MID", SqlDbType.Int);
                        MySqlCmd.Parameters["@MID"].Value = MID;
                        var CIME = MySqlCmd.ExecuteScalar();
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
                            MySqlCommand MySqlCmdIn = new MySqlCommand(InsertQ, MySqlCon);
                            MySqlCmdIn.Parameters.AddWithValue("@UID", SqlDbType.Int);
                            MySqlCmdIn.Parameters["@UID"].Value = UID;
                            MySqlCmdIn.Parameters.AddWithValue("@NewCurr", RawST1);
                            MySqlCmdIn.ExecuteNonQuery();
                        }
                        MySqlCon.Close();
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
        protected string RevercST1String(string[,] ST1R)
        {
            string Result = "";
            for (int i = 0; i < ST1R.GetLength(1); i++)
            {
                Result += "#" + ST1R[0, i] + ";" + ST1R[1, i] + "&";
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
        protected string[,] ST1String(string x)
        {
            Queue<string> R1 = new Queue<string>();
            Queue<string> R2 = new Queue<string>();
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
                    R1.Enqueue(A1);
                    R2.Enqueue(A2);
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
            string[,] RS = new string[2, RdL];
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
                    string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
                    {
                        MySqlCon.Open();
                        string qwi = "SELECT Curr FROM SuMUsersAccounts WHERE UserID = @UID";
                        MySqlCommand MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                        MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                        MySqlCmd00.Parameters["@UID"].Value = UID;
                        var RawRes = MySqlCmd00.ExecuteScalar();

                        string query = "SELECT MangaName FROM SuMManga WHERE MangaID = @MID";
                        MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
                        MySqlCmd.Parameters.AddWithValue("@MID", SqlDbType.Int);
                        MySqlCmd.Parameters["@MID"].Value = Convert.ToInt32(Ce.ToString());
                        var CIME = MySqlCmd00.ExecuteScalar();
                        bool MDE = false;
                        if (CIME != null) { MDE = true; }

                        if (RawRes != null && MDE == true)
                        {
                            query = "UPDATE SuMUsersAccounts SET Curr = @NewCurr WHERE UserID = @UID";
                            MySqlCmd = new MySqlCommand(query, MySqlCon);
                            MySqlCmd.Parameters.AddWithValue("@UID", SqlDbType.Int);
                            MySqlCmd.Parameters["@UID"].Value = UID;
                            MySqlCmd.Parameters.AddWithValue("@NewCurr", RawRes.ToString() + "#" + Ce.ToString() + ";1&");
                            MySqlCmd.ExecuteNonQuery();
                            MySqlCon.Close();
                        }
                        else
                        {
                            if (MDE == true)
                            {
                                query = "UPDATE SuMUsersAccounts SET Curr = @NewCurr WHERE UserID = @UID";
                                MySqlCmd = new MySqlCommand(query, MySqlCon);
                                MySqlCmd.Parameters.AddWithValue("@UID", SqlDbType.Int);
                                MySqlCmd.Parameters["@UID"].Value = UID;
                                MySqlCmd.Parameters.AddWithValue("@NewCurr", "#" + Ce.ToString() + ";1&");
                                MySqlCmd.ExecuteNonQuery();
                                MySqlCon.Close();
                            }
                        }
                        MySqlCon.Close();
                    }
                }
            }
        }
        protected bool IsItAlraedyInCurr(int MID, int UID)
        {

            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string qwi = "SELECT Curr FROM SuMUsersAccounts WHERE UserID = @UID";
                MySqlCommand MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                MySqlCmd00.Parameters["@UID"].Value = UID;
                var RawRes = MySqlCmd00.ExecuteScalar();
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
        protected string BadWordsFilter(string Target) 
        {
            Target = RemoveXFromTarget(Target, "fuck");
            Target = RemoveXFromTarget(Target, "shit");
            Target = RemoveXFromTarget(Target, "dick");
            Target = RemoveXFromTarget(Target, "vagina");
            Target = RemoveXFromTarget(Target, "bitch");
            Target = RemoveXFromTarget(Target, "cunt");
            Target = RemoveXFromTarget(Target, "ass");
            Target = RemoveXFromTarget(Target, "fag");
            Target = RemoveXFromTarget(Target, "faggot");
            Target = RemoveXFromTarget(Target, "nigger");
            Target = RemoveXFromTarget(Target, "nigga");
            return Target;
        }
        public string RemoveXFromTarget(string Target,string X)
        {
            X = X.ToLower();
            if (Target.ToLower().Contains(X) == true)
            {
                string[] TargetPross = Target.Split(' ');
                Target = "";
                string Y = new String('*', X.Length);
                for (int i = 0; i < TargetPross.Length; i++) 
                {
                    if (TargetPross[i].ToLower() != X)
                    {
                        if (TargetPross[i].ToLower().Contains(X) == false)
                        {
                            Target += TargetPross[i] + " ";
                        }
                        else 
                        {
                            Target += TargetPross[i].ToLower().Replace(X, Y) + " ";
                        }
                    }
                    else 
                    {

                        Target += Y + " ";
                    }
                }
            }
            return Target;
        }
    }
}