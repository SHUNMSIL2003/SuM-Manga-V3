using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Net.Mail;
using System.IO;
using System.Text;

namespace SuM_Manga_V3.storeitems
{
    public partial class ContantExplorer : System.Web.UI.Page
    {
        /*protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Request.Browser.IsMobileDevice)
                MasterPageFile = "~/SuMManga.Mobile.Master";
        }*/
        protected void Page_Load(object sender, EventArgs e)
        {
            /*HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            if (GetUserInfoCookie == null)
            {
                Response.Redirect("~/AccountETC/LoginETC.aspx");
            }*/
            if (Request.QueryString["CN"] == null || Request.QueryString["Manga"] == null || Request.QueryString["VC"] == null) { backhome(); }
            MTitle.InnerText = ShowName();//rgba(0,0,0,0.527)
            string CardBG = ShowCover();
            //Bitmap bMap = Bitmap.FromFile(Server.MapPath("~/" + CardBG + "")) as Bitmap;
            string ThemeColor = string.Empty;
            if (Request.QueryString["TC"] != null)
            {
                ThemeColor = Request.QueryString["TC"].ToString();//RgbConverter(getDominantColor(bMap));
            }
            else { ThemeColor = "#6840D9"; }//height:100vh !important;min-height:100% !important;
            TheMangaPhotosF.Attributes["style"] = "display:block;height:fit-content;min-height:100vh !important;background-color:" + ThemeColor + ";padding-bottom:128px !important;";
            string abtntheme = "padding-block:0px;padding:0px;border-radius:0px;color:#ffffff;width:100vw;height:fit-content;float:left;";//ORgbConverter(getDominantColor(bMap));------background-color:" + ThemeColor + ";
            string theme = ThemeColor;//RgbConverter(getDominantColor(bMap));
            infoCover.Attributes["style"] = "background-image:linear-gradient(" + theme + ",rgba(0,0,0,0.3)),url(" + CardBG + ");background-size:cover;background-position:center;width:100vw;height:fit-content;";
            string cn = Request.QueryString["CN"].ToString();
            //MangaViewsAndChapters.InnerText = "Chapters: " + cn + "  -   Views:  "+ ShowViews() + "";
            MdiscS.InnerText = ShowDis();
            int idfg0554 = Convert.ToInt32(Request.QueryString["VC"].ToString());
            GernsTags.InnerHtml = GetGerns(theme, idfg0554);
            string ThemeColorOp1 = ThemeColor.Substring(0, ThemeColor.Length - 6);
            ThemeColorOp1 += ")";
            GernsTags.Attributes["style"] = "border-top-right-radius:22px;border-top-left-radius:22px;width:100vw;height:fit-content;background-color:" + ThemeColorOp1 + ";align-content:center;justify-content:center;padding:8px;align-content:center;text-align:center !important;";
            string pathstartnochx = "/storeitems/";
            //string btn2 = "btn";
            //string btn3 = "btn-primary btn-sm";
            string extraexplore = "MangaExplorer.aspx";
            string identifylast = "?Manga=" + Request.QueryString["Manga"].ToString();
            //MainCardT.InnerText = Request.QueryString["Manga"].ToString();
            string identifynexthelper = "&Chapter=";
            string epath = System.IO.Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            if (Request.QueryString["Manga"] == null) { backhome(); }
            string M0path = epath + "\\storeitems\\" + Request.QueryString["Manga"] + "\\";
            if (System.IO.Directory.Exists(M0path) == false) { backhome(); }
            string cn0 = Request.QueryString["CN"];
            int cn1 = Convert.ToInt32(cn0);
            string ChapterFixedForm = string.Empty;
            //string btnclass = "btn"; //btn
            string RLink = string.Empty;
            string themecolor = ThemeColor;
            char sc = '"';
            char b12 = '"';
            SuMLoginUI.Attributes["style"] = "background-color:" + ThemeColor + ";overflow:hidden;width:100vw;height:100vh;display:block;z-index:999 !important;margin:0 auto !important;position:absolute !important;";
            string btnanimationclass = b12.ToString() + "fadeIn animated btn" + b12.ToString();
            string linktoupdate = pathstartnochx + extraexplore + identifylast + "&TC=" + themecolor + "&VC=" + Request.QueryString["VC"].ToString();
            string linktoupdatech = identifynexthelper + "ch";
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            //string OptionToAddCurrFunc = "";
            if (GetUserInfoCookie != null)
            {
                int MID = Convert.ToInt32(Request.QueryString["VC"].ToString());
                MangaUserStateV(MID, linktoupdate, linktoupdatech);
                for (int c = 1; c < (cn1 + 1); c++)
                {
                    string chxC = c.ToString();
                    if (c < 10 && c > 0) { ChapterFixedForm = "000" + chxC; }
                    if (c > 9 && c < 100) { ChapterFixedForm = "00" + chxC; }
                    if (c > 99 && c < 1000) { ChapterFixedForm = "0" + chxC; }
                    if (c > 999 && c < 10000) { ChapterFixedForm = chxC; }
                    if (c > 10000) { c = (cn1 + 1); }
                    string cpcover = "/storeitems/" + Request.QueryString["Manga"].ToString() + "/sumcp" + ChapterFixedForm + ".jpg";
                    RLink = pathstartnochx + extraexplore + identifylast + identifynexthelper + "ch" + ChapterFixedForm + "&TC=" + themecolor + "&VC=" + Request.QueryString["VC"].ToString();//+ OptionToAddCurrFunc;
                    TheMangaPhotosF.InnerHtml += "<a href=" + "#" + " onclick=" + sc.ToString() + "if (!navigator.onLine) { fetch('" + RLink + "', { method: 'GET' }).then(res => { location.href = '" + RLink + "'; }).catch(err => { document.getElementById('Offline').style.display = 'block'; }); } else { location.href = '" + RLink + "'; }" + sc.ToString() + " style=" + abtntheme + " class=" + btnanimationclass + " ><img src=" + cpcover + " style=" + "margin:4px;width:64px;height:64px;float:left;opacity:0.92;border-radius:4px;" + "> <p style=" + "color:#ffffff;float:left;margin-left:6px;" + ">Chapter " + chxC + "</p></a>";
                    if (c < cn1) { TheMangaPhotosF.InnerHtml += "<hr style=" + sc.ToString() + "margin:0 auto !important;height:1px;border-width:0;color:#ffffff;background-color:#ffffff;width:96vw;opacity:0.24;margin:0px;margin-block:0px;" + sc.ToString() + ">"; }
                    //<a style="dc" class="btn" href="#"><img src="/storeitems/Anohana/0001/sumcp.png" style="width:48px;height:48px;float:left;margin:0px;" /><p style="dc">dc</p></a>
                }
            }
            else
            {
                string TC = Request.QueryString["TC"].ToString();
                TC = TC.Substring(0, TC.Length - 6);
                TC += ")";
                SVC.Attributes["style"] = "overflow:hidden;background-color:" + TC + ";margin:0 auto;height:fit-content;";
                MRSW.InnerHtml = "<b>Start Reading</b><br /><p style=" + "margin-top:-4px;font-size:60%;color:" + TC + ">You need to Login!</p>";
                MRSW.Attributes["style"] = "overflow:hidden;color:" + TC + ";";
                MRSC.Attributes["style"] = "overflow:hidden;margin-top:2px !important;margin-bottom:8px !important; background-color:rgb(255, 255, 255, 0.84);border-radius:12px;width:160px;height:38px;margin:0 auto;text-align:center;justify-content:center;";
                MRSW.Attributes["onclick"] = "document.getElementById('MainContent_SuMLoginUI').style.display = 'block';";
                for (int c = 1; c < (cn1 + 1); c++)
                {
                    string chxC = c.ToString();
                    if (c < 10 && c > 0) { ChapterFixedForm = "000" + chxC; }
                    if (c > 9 && c < 100) { ChapterFixedForm = "00" + chxC; }
                    if (c > 99 && c < 1000) { ChapterFixedForm = "0" + chxC; }
                    if (c > 999 && c < 10000) { ChapterFixedForm = chxC; }
                    if (c > 10000) { c = (cn1 + 1); }
                    string cpcover = "/storeitems/" + Request.QueryString["Manga"].ToString() + "/sumcp" + ChapterFixedForm + ".jpg";
                    TheMangaPhotosF.InnerHtml += "<a href=" + "#" + " onclick=" + sc.ToString() + "document.getElementById('MainContent_SuMLoginUI').style.display = 'block';" + sc.ToString() + " style=" + abtntheme + " class=" + btnanimationclass + " ><img src=" + cpcover + " style=" + "margin:4px;width:64px;height:64px;float:left;opacity:0.92;border-radius:4px;" + "> <p style=" + "color:#ffffff;float:left;margin-left:6px;" + ">Chapter " + chxC + "</p></a>";
                    if (c < cn1) { TheMangaPhotosF.InnerHtml += "<hr style=" + sc.ToString() + "margin:0 auto !important;height:1px;border-width:0;color:#ffffff;background-color:#ffffff;width:96vw;opacity:0.24;margin:0px;margin-block:0px;" + sc.ToString() + ">"; }
                }
            }
            ShowCreator();
            ShowViews();
            ShowAgeRating();
            ShareLink();
            if (IsPostBack == false)
            {
                AddOneView();
            }
        }
        protected void ShareLink()
        {
            var V = "";
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string query = "SELECT MangaName FROM SuMManga WHERE MangaID = @MangaID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                string x = Request.QueryString["VC"];
                int y = Convert.ToInt32(x);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = y;
                using (SqlDataReader dr = sqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        V = dr[0].ToString();
                    }
                }
                sqlCon.Close();
            }
            string LINK = "https://sum-manga.azurewebsites.net/storeitems/ContantExplorer.aspx?Manga=" + Request.QueryString["Manga"].ToString() + "&CN=" + Request.QueryString["CN"].ToString() + "&VC=" + Request.QueryString["VC"].ToString() + "&TC=" + Request.QueryString["TC"].ToString();
            SuMShare.Attributes["onclick"] = "navigator.share({title:'SuM Manga',text:'Check out " + V.ToString() + " on SuM Manga.',url:'" + LINK + "'});";
        }
        protected bool IsItInCurr(int MID, int UID)
        {

            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
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
                    for (int i = 0; i < R.GetLength(1); i++)
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
        protected void MangaUserStateV(int MID,string LinkToUpdate,string linktoupdatech)
        {
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            int UID = Convert.ToInt32(Convert.ToString(GetUserInfoCookie["ID"]));
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string qwi = "SELECT Curr FROM SuMUsersAccounts WHERE UserID = @UID";
                SqlCommand sqlCmd00 = new SqlCommand(qwi, sqlCon);
                sqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                sqlCmd00.Parameters["@UID"].Value = UID;
                var RawRes = sqlCmd00.ExecuteScalar();
                if (RawRes != null)
                {
                    string TC = Request.QueryString["TC"].ToString();
                    TC = TC.Substring(0, TC.Length - 6);
                    TC += ")";

                    bool foundit = false;
                    string Res = RawRes.ToString();
                    int[,] R = ST1(Res);
                    for (int i = 0; i < R.GetLength(1); i++) 
                    {
                        if (R[0, i] == MID)
                        {
                            foundit = true;
                            int c = R[1, i];
                            string ChapterFixedForm = string.Empty;
                            string chxC = c.ToString();
                            if (c < 10 && c > 0) { ChapterFixedForm = "000" + chxC; }
                            if (c > 9 && c < 100) { ChapterFixedForm = "00" + chxC; }
                            if (c > 99 && c < 1000) { ChapterFixedForm = "0" + chxC; }
                            if (c > 999 && c < 10000) { ChapterFixedForm = chxC; }
                            SVC.Attributes["style"] = "overflow:hidden;background-color:" + TC + ";margin:0 auto;height:fit-content;";
                            MRSW.InnerHtml = "<b>Continue Reading</b><br /><p style=" + "margin-top:-4px;font-size:64%;color:" + TC + ">Currently In Chapter " + c + "</p>";
                            MRSW.Attributes["style"] = "overflow:hidden;color:" + TC + ";";
                            MRSC.Attributes["style"] = "overflow:hidden;margin-top:2px !important;margin-bottom:8px !important; background-color:rgb(255, 255, 255, 0.84);border-radius:12px;width:160px;height:38px;margin:0 auto;text-align:center;justify-content:center;";
                            string WorkerHelp = "&UCU=" + MID.ToString();
                            MRSW.Attributes["onclick"] = "if (!navigator.onLine) { fetch('" + LinkToUpdate + linktoupdatech + ChapterFixedForm + WorkerHelp + "', { method: 'GET' }).then(res => { location.href = '" + LinkToUpdate + linktoupdatech + ChapterFixedForm + WorkerHelp + "'; }).catch(err => { document.getElementById('Offline').style.display = 'block'; }); } else { location.href = '" + LinkToUpdate + linktoupdatech + ChapterFixedForm + WorkerHelp + "'; }";
                            sqlCon.Close();
                        }
                    }
                    if (foundit == false) 
                    {
                        SVC.Attributes["style"] = "overflow:hidden;background-color:" + TC + ";margin:0 auto;height:fit-content;";
                        MRSW.InnerHtml = "<b>Start Reading</b><br /><p style=" + "margin-top:-4px;font-size:60%;color:" + TC + ">Auto adds to currently reading</p>";
                        MRSW.Attributes["style"] = "overflow:hidden;color:" + TC + ";";
                        MRSC.Attributes["style"] = "overflow:hidden;margin-top:2px !important;margin-bottom:8px !important; background-color:rgb(255, 255, 255, 0.84);border-radius:12px;width:160px;height:38px;margin:0 auto;text-align:center;justify-content:center;";
                        MRSW.Attributes["onclick"] = "if (!navigator.onLine) { fetch('" + LinkToUpdate + linktoupdatech + "0001" + "&ADTCU=" + MID + "', { method: 'GET' }).then(res => { location.href = '" + LinkToUpdate + linktoupdatech + "0001" + "&ADTCU=" + MID + "'; }).catch(err => { document.getElementById('Offline').style.display = 'block'; }); } else { location.href = '" + LinkToUpdate + linktoupdatech + "0001" + "&ADTCU=" + MID + "'; }";
                        sqlCon.Close();
                    }
                }
                else
                {
                    string TC = Request.QueryString["TC"].ToString();
                    TC = TC.Substring(0, TC.Length - 6);
                    TC += ")";
                    SVC.Attributes["style"] = "overflow:hidden;background-color:" + TC + ";margin:0 auto;height:fit-content;";
                    MRSW.InnerHtml = "<b>Start Reading</b><br /><p style=" + "margin-top:-4px;font-size:60%;color:" + TC + ">Auto adds to currently reading</p>";
                    MRSW.Attributes["style"] = "overflow:hidden;color:" + TC + ";";
                    MRSC.Attributes["style"] = "overflow:hidden;margin-top:2px !important;margin-bottom:8px !important; background-color:rgb(255, 255, 255, 0.84);border-radius:12px;width:160px;height:38px;margin:0 auto;text-align:center;justify-content:center;";
                    MRSW.Attributes["onclick"] = "if (!navigator.onLine) { fetch('" + LinkToUpdate + linktoupdatech + "0001" + "&ADTCU=" + MID + "', { method: 'GET' }).then(res => { location.href = '" + LinkToUpdate + linktoupdatech + "0001" + "&ADTCU=" + MID + "'; }).catch(err => { document.getElementById('Offline').style.display = 'block'; }); } else { location.href = '" + LinkToUpdate + linktoupdatech + "0001" + "&ADTCU=" + MID + "'; }";
                    sqlCon.Close();
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
        protected static string RgbConverter(Color c)
        {
            return String.Format("rgba({0},{1},{2},0.74)", c.R, c.G, c.B);
        }
        protected static string ORgbConverter(Color c)
        {
            return String.Format("rgba({0},{1},{2},1)", c.R, c.G, c.B);
        }
        protected static Color getDominantColor(Bitmap bmp)
        {
            //Used for tally
            int r = 0;
            int g = 0;
            int b = 0;

            int total = 0;

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color clr = bmp.GetPixel(x, y);

                    r += clr.R;
                    g += clr.G;
                    b += clr.B;

                    total++;
                }
            }

            //Calculate average
            r /= total;
            g /= total;
            b /= total;

            return Color.FromArgb(r, g, b);
        }
        private void backhome()
        {
            Response.Redirect("~/404.aspx");
        }
        protected string ShowDis() 
        {
            string V = string.Empty;
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string query = "SELECT MangaInfo FROM SuMManga WHERE MangaID = @MangaID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                string x = Request.QueryString["VC"];
                int y = Convert.ToInt32(x);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = y;
                using (SqlDataReader dr = sqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        V = dr[0].ToString();
                    }
                }
                sqlCon.Close();
            }
            return V;
        }
        protected void ShowCreator() 
        {
            string V = string.Empty;
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string query = "SELECT MangaCreator FROM SuMManga WHERE MangaID = @MangaID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                string x = Request.QueryString["VC"];
                int y = Convert.ToInt32(x);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = y;
                using (SqlDataReader dr = sqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        V = dr[0].ToString();
                    }
                }
                sqlCon.Close();
            }
            MangaCreator.InnerText = V;
        }
        protected void ShowAgeRating()
        {
            string V = string.Empty;
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string query = "SELECT MangaAgeRating FROM SuMManga WHERE MangaID = @MangaID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                string x = Request.QueryString["VC"];
                int y = Convert.ToInt32(x);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = y;
                using (SqlDataReader dr = sqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        V = dr[0].ToString();
                    }
                }
                sqlCon.Close();
            }
            MangaRating.InnerText = V;
        }
        protected void ShowViews()
        {
            int V = 0;
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string query = "SELECT MangaViews FROM SuMManga WHERE MangaID = @MangaID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                string x = Request.QueryString["VC"];
                int y = Convert.ToInt32(x);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = y;
                using (SqlDataReader dr = sqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        V = Convert.ToInt32(dr[0].ToString());
                    }
                }
                sqlCon.Close();
            }
            if (V < 1000)
            {
                ViewsSutNum.InnerText = V.ToString();
                ViewsSutLater.InnerText = "";
            }
            if (V > 999 && V < 1000000)
            {
                double B = V / 1000.0;
                ViewsSutNum.InnerText = String.Format("{0:0.00}", B);
                ViewsSutLater.InnerText = "K";
            }
            if (V > 999999 && V < 1000000000)
            {
                double B = V / 1000000.0;
                ViewsSutNum.InnerText = String.Format("{0:0.00}", B);
                ViewsSutLater.InnerText = "M";
            }
            if (V > 999999999)
            {
                double B = V / 1000000000.0;
                ViewsSutNum.InnerText = String.Format("{0:0.00}", B);
                ViewsSutLater.InnerText = "B";
            }

        }
        protected string ShowCover()
        {
            string V = string.Empty;
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string query = "SELECT MangaCoverLink FROM SuMManga WHERE MangaID = @MangaID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                string x = Request.QueryString["VC"];
                int y = Convert.ToInt32(x);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = y;
                using (SqlDataReader dr = sqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        V = dr[0].ToString();
                    }
                }
                sqlCon.Close();
            }
            //BodyStyle = "<style>body { background-image: url(" + V + "); }</style>";
            //Body.InnerText = "body { background-image: url(" + V + "); }";
            FakeBody.Attributes["style"] = "background-image:url(" + V + ");";
            return V;
        }
        protected string ShowName()
        {
            string V = string.Empty;
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string query = "SELECT MangaName FROM SuMManga WHERE MangaID = @MangaID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                string x = Request.QueryString["VC"];
                int y = Convert.ToInt32(x);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = y;
                using (SqlDataReader dr = sqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        V = dr[0].ToString();
                    }
                }
                sqlCon.Close();
            }
            return V;
        }
        protected bool IsGernXCodeName(string X,int MangaID)
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string qwi = "SELECT ID FROM " + X + " WHERE MangaID = @MangaID ";
                SqlCommand sqlCmd00 = new SqlCommand(qwi, sqlCon);
                sqlCmd00.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd00.Parameters["@MangaID"].Value = MangaID;
                var R = sqlCmd00.ExecuteScalar();
                if (R != null) { sqlCon.Close(); return true; }
                else { sqlCon.Close(); return false; }
            }
        }
        protected string GetGerns(string ThemeColor, int ID)
        {
            char b12 = '"';
            string flashani = b12.ToString() + "fadeIn animated" + b12.ToString();
            bool un = false;
            string gernsincard = " ";
            //string TagViewer0 = "/storeitems/TagView.aspx";
            ThemeColor = "rgba(225,225,225,0.36)";//DesignChange!
            string DivACStyle = b12.ToString() + "height:fit-content !important;margin-left:6px;display:inline-block;width:fit-content;height:38px;background-color:" + ThemeColor + ";border-radius:19px;" + b12.ToString();
            un = IsGernXCodeName("Action", ID);
            if (un == true)
            {
                //string TagViewer = TagViewer0 + "?G=Action";
                //un = false;
                gernsincard += "<div class=" + flashani + " style=" + DivACStyle + "><a name=" + "no-animation" + " style=" + "color:white;font-size:112%;" + ">&nbsp;&nbsp;&nbsp;Action&nbsp;&nbsp;&nbsp;</a></div>";
            }
            un = IsGernXCodeName("Fantasy", ID);
            if (un == true)
            {
                //string TagViewer = TagViewer0 + "?G=Fantasy";
                //un = false;
                gernsincard += "<div class=" + flashani + " style=" + DivACStyle + "><a name=" + "no-animation" + " style=" + "color:white;font-size:112%;" + ">&nbsp;&nbsp;&nbsp;Fantasy&nbsp;&nbsp;&nbsp;</a></div>";//onclick=" + b12.ToString() + "fetch('" + TagViewer + "', { method: 'GET' }).then(res => {location.href = '" + TagViewer + "';}).catch(err => { document.getElementById('Offline').style.display = 'block'; })" + b12.ToString()
            }
            un = IsGernXCodeName("Comedy", ID);
            if (un == true)
            {
                //string TagViewer = TagViewer0 + "?G=Comedy";
                //un = false;
                gernsincard += "<div class=" + flashani + " style=" + DivACStyle + "><a name=" + "no-animation" + " style=" + "color:white;font-size:112%;" + ">&nbsp;&nbsp;&nbsp;Comedy&nbsp;&nbsp;&nbsp;</a></div>";
            }
            un = IsGernXCodeName("SciFi", ID);
            if (un == true)
            {
                //string TagViewer = TagViewer0 + "?G=SciFi";
                //un = false;
                gernsincard += "<div class=" + flashani + " style=" + DivACStyle + "><a name=" + "no-animation" + " style=" + "color:white;font-size:112%;" + ">&nbsp;&nbsp;&nbsp;Sci-Fi&nbsp;&nbsp;&nbsp;</a></div>";
            }
            un = IsGernXCodeName("Supernatural", ID);
            if (un == true)
            {
                //string TagViewer = TagViewer0 + "?G=Supernatural";
                //un = false;
                gernsincard += "<div class=" + flashani + " style=" + DivACStyle + "><a name=" + "no-animation" + " style=" + "color:white;font-size:112%;" + ">&nbsp;&nbsp;&nbsp;Supernatural&nbsp;&nbsp;&nbsp;</a></div>";
            }
            un = IsGernXCodeName("SliceofLife", ID);
            if (un == true)
            {
                //string TagViewer = TagViewer0 + "?G=SliceofLife";
                //un = false;
                gernsincard += "<div class=" + flashani + " style=" + DivACStyle + "><a name=" + "no-animation" + " style=" + "color:white;font-size:112%;" + ">&nbsp;&nbsp;&nbsp;Slice of Life&nbsp;&nbsp;&nbsp;</a></div>";
            }
            un = IsGernXCodeName("Mystery", ID);
            if (un == true)
            {
                //string TagViewer = TagViewer0 + "?G=Mystery";
                //un = false;
                gernsincard += "<div class=" + flashani + " style=" + DivACStyle + "><a name=" + "no-animation" + " style=" + "color:white;font-size:112%;" + ">&nbsp;&nbsp;&nbsp;Mystery&nbsp;&nbsp;&nbsp;</a></div>";
            }
            un = IsGernXCodeName("Drama", ID);
            if (un == true)
            {
                //string TagViewer = TagViewer0 + "?G=Drama";
                //un = false;
                gernsincard += "<div class=" + flashani + " style=" + DivACStyle + "><a name=" + "no-animation" + " style=" + "color:white;font-size:112%;" + ">&nbsp;&nbsp;&nbsp;Drama&nbsp;&nbsp;&nbsp;</a></div>";
            }
            return gernsincard;
        }
        protected void AddOneView()
        {
            if (!IsPostBack)
            {
                using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    sqlCon.Open();
                    string query = "UPDATE SuMManga SET MangaViews = MangaViews + 1 WHERE MangaID = @MangaID";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    string x = Request.QueryString["VC"];
                    int y = Convert.ToInt32(x);
                    sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    sqlCmd.Parameters["@MangaID"].Value = y;
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                }
            }
        }
        /*    LoginCode      */
        protected void LoginToSuM(object sender, EventArgs e)
        {
            LoginStatus.InnerText = "";
            string statevalid = "";
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string query = "SELECT UserID FROM SuMUsersAccounts WHERE UserName = @UserName AND Password = @Password ";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                string username = UserNameL.Value;
                sqlCmd.Parameters.AddWithValue("@UserName", username);
                string password = PasswordL.Value;
                sqlCmd.Parameters.AddWithValue("@Password", sha256(password));
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count > 0)
                {
                    string query2 = "SELECT AccountStatus FROM SuMUsersAccounts WHERE UserName = @UserName";
                    SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);
                    sqlCmd2.Parameters.AddWithValue("@UserName", username);
                    using (SqlDataReader dr = sqlCmd2.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            statevalid = dr[0].ToString();
                        }
                    }
                    if (statevalid[0] == '#' && statevalid[1] == 'R')
                    {
                        LoginStatus.InnerText = "You need to Complete SuM Account registration! You will find the link in you email-inbox.";
                        ResendConf.Visible = true;
                    }
                    else
                    {
                        string qc = "SELECT CreatorName FROM SuMCreators WHERE UserName = @UserName";
                        SqlCommand cv = new SqlCommand(qc, sqlCon);
                        cv.Parameters.AddWithValue("@UserName", username);
                        var ituac = cv.ExecuteScalar();
                        if (ituac == null)
                        {
                            SaveCookie(username, count);
                            sqlCon.Close();
                            Response.Redirect(Request.Url.ToString() + RandomQuryForReload());
                        }
                        else
                        {
                            qc = "SELECT UserID FROM SuMCreators WHERE UserName = @UserName";
                            cv = new SqlCommand(qc, sqlCon);
                            cv.Parameters.AddWithValue("@UserName", username);
                            int CID = Convert.ToInt32(cv.ExecuteScalar().ToString());
                            SaveSCCookie(username, ituac.ToString(), count, CID);
                            sqlCon.Close();
                            Response.Redirect(Request.Url.ToString() + RandomQuryForReload());
                        }
                    }
                }
                else
                {
                    LoginStatus.InnerText = "Username or Password are incorrect"; sqlCon.Close();
                    UserNameL.Attributes["style"] = "border: solid 2px red;border-radius:14px;";
                    PasswordL.Attributes["style"] = "border: solid 2px red;border-radius:14px;";
                    LoginStatus.InnerText = "Username Or Password are incurrect!";
                }

            }
        }
        static string sha256(string randomString)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
        protected void SaveCookie(string UserName, int ID)
        {
            HttpCookie userInfo = new HttpCookie("SuMCurrentUser"); 
            userInfo["UserName"] = UserName;
            userInfo["ID"] = ID.ToString();
            //userInfo.Expires.Add(new TimeSpan(4, 1, 0));
            userInfo.Expires = DateTime.MaxValue;
            HttpContext.Current.Response.Cookies.Add(userInfo);
            HttpContext.Current.Response.Redirect(Request.Url.ToString() + RandomQuryForReload());
        }
        protected void SaveSCCookie(string UserName, string craetorname, int ID, int CID)
        {
            HttpCookie userInfo = new HttpCookie("SuMCurrentUser");
            userInfo["UserName"] = UserName;
            userInfo["CreatorName"] = craetorname;
            userInfo["ID"] = ID.ToString();
            userInfo["CID"] = CID.ToString();
            userInfo.Expires = DateTime.MaxValue;
            HttpContext.Current.Response.Cookies.Add(userInfo);
            HttpContext.Current.Response.Redirect(Request.Url.ToString() + RandomQuryForReload());
        }
        protected void ResendConfLink(object sender, EventArgs e)
        {
            string virivicationcode = GetVerificationCode(8);
            string accountstats = "#R$" + virivicationcode;
            string UserName = UserNameL.Value.ToString();
            string Email = string.Empty;
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string query = "UPDATE SuMUsersAccounts SET AccountStatus = @AccountStatus WHERE UserName = @UserName";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@UserName", UserName);
                sqlCmd.Parameters.AddWithValue("@AccountStatus", accountstats);
                sqlCmd.ExecuteNonQuery();
                string query4 = "SELECT Email FROM SuMUsersAccounts WHERE UserName = @UserName";
                SqlCommand sqlCmd4 = new SqlCommand(query4, sqlCon);
                sqlCmd4.Parameters.AddWithValue("@UserName", UserName);
                using (SqlDataReader dr = sqlCmd4.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Email = dr[0].ToString();
                    }
                }
                sqlCon.Close();
            }
            SendVirifyEmail(virivicationcode, Email);

        }
        protected void SendVirifyEmail(string VCODE, string Email)
        {
            string thelink = "https://sum-manga.azurewebsites.net/AccountETC/ValidateUsers.aspx?UserName=" + UserNameL.Value.ToString() + "&VCode=" + VCODE;
            string emailbody = MailTemplate(thelink);
            MailMessage Msg = new MailMessage();
            Msg.From = new MailAddress("sumverifysystem@gmail.com", "SuM System");// Sender details here, replace with valid value
            Msg.Subject = "Setup SuM Account!"; // subject of email
            string useremail = Email;
            Msg.To.Add(useremail); //Add Email id, to which we will send email
            Msg.Body = emailbody;
            Msg.IsBodyHtml = true;
            Msg.Priority = MailPriority.High;
            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false; // to get rid of error "SMTP server requires a secure connection"
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("sumverifysystem@gmail.com", "rxuclaczswvdhjpj");// replace with valid value
            smtp.EnableSsl = true;
            smtp.Timeout = 20000;
            smtp.Send(Msg);
        }
        protected string MailTemplate(string link)
        {
            StreamReader sr = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/AccountETC/Email.html"));
            string body = sr.ReadToEnd();
            sr.Close();
            string username = UserNameL.Value.ToString();
            body = body.Replace("#USERNAME#", username);
            body = body.Replace("#LINK#", link);
            return body;
        }
        protected static string GetVerificationCode(int length)
        {
            char[] chArray = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            string str = string.Empty;
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                int index = random.Next(1, chArray.Length);
                if (!str.Contains(chArray.GetValue(index).ToString()))
                {
                    str = str + chArray.GetValue(index);
                }
                else
                {
                    i--;
                }
            }
            Random r = new Random();
            int randNum = r.Next(1000000);
            string sixDigitNumber = randNum.ToString("D6");
            str = sixDigitNumber[0] + sixDigitNumber[1] + sixDigitNumber[2] + str + sixDigitNumber[3] + sixDigitNumber[4] + sixDigitNumber[5];
            return str;
        }
        protected static string RandomQuryForReload()
        {
            int length = 9;
            char[] chArray = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            string str = string.Empty;
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                int index = random.Next(1, chArray.Length);
                if (!str.Contains(chArray.GetValue(index).ToString()))
                {
                    str = str + chArray.GetValue(index);
                }
                else
                {
                    i--;
                }
            }
            Random r = new Random();
            int randNum = r.Next(1000000);
            string sixDigitNumber = randNum.ToString("D6");
            str = sixDigitNumber[0] + sixDigitNumber[1] + sixDigitNumber[2] + str + sixDigitNumber[3] + sixDigitNumber[4] + sixDigitNumber[5];
            return "&" + str + "=ClearCache";
        }
        protected void LogInWithGoogle(object sender, EventArgs e)
        {

        }
    }
}