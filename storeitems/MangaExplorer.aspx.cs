using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuM_Manga_V3.storeitems
{
    public partial class MangaExplorer : System.Web.UI.Page
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
                if (Request.QueryString["Chapter"] == null || Request.QueryString["Manga"] == null) { backhome(); }
                else
                {
                    string MangaName = Request.QueryString["Manga"].ToString();
                    string ChapterX = Request.QueryString["Chapter"].ToString();
                    char[] chnum = ChapterX.ToCharArray();
                    for (int i = 0; i < chnum.Length; i++) { if (Char.IsDigit(chnum[i]) == false) { chnum[i] = '0'; } }
                    string chnumst = new string(chnum);
                    int ab = Int32.Parse(chnumst);
                    MainCardT.InnerText = MangaName + " - Chapter " + ab.ToString();
                    string help0136 = "\\";
                    string epath = System.IO.Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
                    string ActivePath = epath + "\\storeitems\\" + MangaName + help0136 + ChapterX + help0136;
                    char[] ActivePatharr = ActivePath.ToCharArray();
                    if (System.IO.Directory.Exists(ActivePath) == true)
                    {
                        TheMangaPhotos.InnerHtml = "";
                        string[] filePaths = System.IO.Directory.GetFiles(ActivePath, "*.jpg");
                        //string sendhtmlforchimges = "";
                        string deafultstartitems = "/storeitems/";
                        string slash0 = "/";
                        string imgstyle = "width:92%;max-width:800px;";
                        //string x = "lazy";
                        for (int i = 0; i < filePaths.Length; i++)
                        {
                            string filename = System.IO.Path.GetFileName(filePaths[i]);
                            TheMangaPhotos.InnerHtml += "<img style=" + imgstyle + " src=" + deafultstartitems + MangaName + slash0 + ChapterX + slash0 + filename + " /><br/>";
                        }
                        //string beforerelasecode = "";
                        //beforerelasecode += sendhtmlforchimges;
                        //TheMangaPhotos.InnerHtml = beforerelasecode;
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
                        if (System.IO.Directory.Exists(checkifitexsists) == true)
                        {
                            //"<a class="+"btn btn-primary btn-sm"+" href=" "> Next Chapter  &raquo;</a>"
                            string sendNextChapter = "<a class=" + "btn btn-primary btn-sm" + " href=" + pathstartnochx + extraexplore + identifylast + "&" + identifynexthelper + "ch" + FixedChapterNum + "> Next Chapter  &raquo;</a>";
                            NextChapter.InnerHtml = sendNextChapter;
                        }
                        else
                        {
                            NextChapter.InnerHtml = "<h4 style=" + "color:#6840D9;" + ">No Chapters Left for now!</h4>";
                        }
                    }
                    else
                    {
                        Response.Redirect("~/404.aspx");
                    }
                }
            }
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