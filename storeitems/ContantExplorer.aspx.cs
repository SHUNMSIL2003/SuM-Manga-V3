using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

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
            if (IsPostBack == false)
            {
                //string MangaPathName = Request.QueryString["Manga"].ToString();
                //string covername = MangaPathName + ".jpg";
                //string MangaPathCover = "/storeitems/" + MangaPathName + "/" + covername;
                //cover.Attributes["src"] = ShowCover();//MangaPathCover;
                MTitle.InnerText = ShowName();//rgba(0,0,0,0.527)
                string CardBG = ShowCover();
                //Bitmap bMap = Bitmap.FromFile(Server.MapPath("~/" + CardBG + "")) as Bitmap;
                string ThemeColor = string.Empty;
                if (Request.QueryString["TC"] != null)
                {
                    ThemeColor = Request.QueryString["TC"].ToString();//RgbConverter(getDominantColor(bMap));
                }
                else { ThemeColor = "#6840D9"; }//height:100vh !important;min-height:100% !important;
                TheMangaPhotosF.Attributes["style"] = "display:block;height:fit-content;min-height:100vh !important;background-color:" + ThemeColor + ";";
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
                string btnanimationclass = b12.ToString() + "fadeIn animated btn" + b12.ToString();
                string linktoupdate = pathstartnochx + extraexplore + identifylast + "&TC=" + themecolor + "&VC=" + Request.QueryString["VC"].ToString();
                string linktoupdatech = identifynexthelper + "ch";
                HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
                //string OptionToAddCurrFunc = "";
                if (GetUserInfoCookie != null)
                {
                    //int UID = Convert.ToInt32(GetUserInfoCookie["UID"].ToString());
                    int MID = Convert.ToInt32(Request.QueryString["VC"].ToString());
                    MangaUserStateV(MID, linktoupdate, linktoupdatech);
                    /*   Removed it so the func is only avalible when using Curr Button :)   */
                    /*if (IsItInCurr(MID, UID) == true)
                    {
                        OptionToAddCurrFunc = "&UCICU=T&MID=" + MID.ToString();
                    }*/
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
                    MRSW.Attributes["href"] = "/AccountETC/LogInETC.aspx";
                }
                //"<a style=" + abtntheme + "><p style="+ "color:#ffffff;float:right;font-size:142%;" + ">" + Request.QueryString["CN"].ToString() + " Chapters</p></a>";
                //TheMangaPhotosF.InnerHtml += "<hr style=" + "height:1px;border-width:0;color:#ffffff;background-color:#ffffff;width:100vw;opacity:0.42;margin:0px;margin-block:0px;" + ">";
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
                    TheMangaPhotosF.InnerHtml += "<a onclick=" + sc.ToString() + "fetch('" + RLink + "', { method: 'GET' }).then(res => {location.href = '" + RLink + "';}).catch(err => { location.href = '/SuMOffline.html'; })" + sc.ToString() + " style=" + abtntheme + " class=" + btnanimationclass + " ><img src=" + cpcover + " style=" + "margin:4px;width:64px;height:64px;float:left;opacity:0.92;border-radius:4px;" + "> <p style=" + "color:#ffffff;float:left;margin-left:6px;" + ">Chapter " + chxC + "</p></a>";
                    if (c < cn1) { TheMangaPhotosF.InnerHtml += "<hr style=" + sc.ToString() + "margin:0 auto !important;height:1px;border-width:0;color:#ffffff;background-color:#ffffff;width:96vw;opacity:0.24;margin:0px;margin-block:0px;" + sc.ToString() + ">"; }
                    //<a style="dc" class="btn" href="#"><img src="/storeitems/Anohana/0001/sumcp.png" style="width:48px;height:48px;float:left;margin:0px;" /><p style="dc">dc</p></a>
                }
                //string coverstyle = "text-align:left;width:226px;height:320px;border-radius:10px;border-top-left-radius:10px;border-bottom-right-radius:10px;";
                //string covercode = "<img style=" + coverstyle + " src=" + MangaPathCover + ">";
                //mangacoverinpage.InnerHtml += covercode;
                //TheMangaPhotos.InnerHtml += "<a><h1> &zwnj; </h1><h1> &zwnj; </1><h1> &zwnj; </h1><h2> &zwnj; </h2><h4> &zwnj; </h4></a>";
                ShowCreator();
                ShowViews();
                ShowAgeRating();
                AddOneView();
            }
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
                            MRSW.Attributes["href"] = LinkToUpdate + linktoupdatech + ChapterFixedForm + WorkerHelp;
                            sqlCon.Close();
                        }
                    }
                    if (foundit == false) 
                    {
                        SVC.Attributes["style"] = "overflow:hidden;background-color:" + TC + ";margin:0 auto;height:fit-content;";
                        MRSW.InnerHtml = "<b>Start Reading</b><br /><p style=" + "margin-top:-4px;font-size:60%;color:" + TC + ">Auto adds to currently reading</p>";
                        MRSW.Attributes["style"] = "overflow:hidden;color:" + TC + ";";
                        MRSC.Attributes["style"] = "overflow:hidden;margin-top:2px !important;margin-bottom:8px !important; background-color:rgb(255, 255, 255, 0.84);border-radius:12px;width:160px;height:38px;margin:0 auto;text-align:center;justify-content:center;";
                        MRSW.Attributes["href"] = LinkToUpdate + linktoupdatech + "0001" + "&ADTCU=" + MID;
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
                    MRSW.Attributes["href"] = LinkToUpdate + linktoupdatech + "0001" + "&ADTCU=" + MID;
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
            string TagViewer0 = "/storeitems/TagView.aspx";
            ThemeColor = "rgba(225,225,225,0.36)";//DesignChange!
            string DivACStyle = b12.ToString() + "height:fit-content !important;margin-left:6px;display:inline-block;width:fit-content;height:38px;background-color:" + ThemeColor + ";border-radius:19px;" + b12.ToString();
            un = IsGernXCodeName("Action", ID);
            if (un == true)
            {
                string TagViewer = TagViewer0 + "?G=Action";
                un = false;
                gernsincard += "<div class=" + flashani + " style=" + DivACStyle + "><a name=" + "no-animation" + " href=" + TagViewer + " style=" + "color:white;font-size:112%;" + ">&nbsp;&nbsp;&nbsp;Action&nbsp;&nbsp;&nbsp;</a></div>";
            }
            un = IsGernXCodeName("Fantasy", ID);
            if (un == true)
            {
                string TagViewer = TagViewer0 + "?G=Fantasy";
                un = false;
                gernsincard += "<div class=" + flashani + " style=" + DivACStyle + "><a name=" + "no-animation" + " href=" + TagViewer + " style=" + "color:white;font-size:112%;" + ">&nbsp;&nbsp;&nbsp;Fantasy&nbsp;&nbsp;&nbsp;</a></div>";
            }
            un = IsGernXCodeName("Comedy", ID);
            if (un == true)
            {
                string TagViewer = TagViewer0 + "?G=Comedy";
                un = false;
                gernsincard += "<div class=" + flashani + " style=" + DivACStyle + "><a name=" + "no-animation" + " href=" + TagViewer + " style=" + "color:white;font-size:112%;" + ">&nbsp;&nbsp;&nbsp;Comedy&nbsp;&nbsp;&nbsp;</a></div>";
            }
            un = IsGernXCodeName("SciFi", ID);
            if (un == true)
            {
                string TagViewer = TagViewer0 + "?G=SciFi";
                un = false;
                gernsincard += "<div class=" + flashani + " style=" + DivACStyle + "><a name=" + "no-animation" + " href=" + TagViewer + " style=" + "color:white;font-size:112%;" + ">&nbsp;&nbsp;&nbsp;Sci-Fi&nbsp;&nbsp;&nbsp;</a></div>";
            }
            un = IsGernXCodeName("Supernatural", ID);
            if (un == true)
            {
                string TagViewer = TagViewer0 + "?G=Supernatural";
                un = false;
                gernsincard += "<div class=" + flashani + " style=" + DivACStyle + "><a name=" + "no-animation" + " href=" + TagViewer + " style=" + "color:white;font-size:112%;" + ">&nbsp;&nbsp;&nbsp;Supernatural&nbsp;&nbsp;&nbsp;</a></div>";
            }
            un = IsGernXCodeName("SliceofLife", ID);
            if (un == true)
            {
                string TagViewer = TagViewer0 + "?G=SliceofLife";
                un = false;
                gernsincard += "<div class=" + flashani + " style=" + DivACStyle + "><a name=" + "no-animation" + " href=" + TagViewer + " style=" + "color:white;font-size:112%;" + ">&nbsp;&nbsp;&nbsp;Slice of Life&nbsp;&nbsp;&nbsp;</a></div>";
            }
            un = IsGernXCodeName("Mystery", ID);
            if (un == true)
            {
                string TagViewer = TagViewer0 + "?G=Mystery";
                un = false;
                gernsincard += "<div class=" + flashani + " style=" + DivACStyle + "><a name=" + "no-animation" + " href=" + TagViewer + " style=" + "color:white;font-size:112%;" + ">&nbsp;&nbsp;&nbsp;Mystery&nbsp;&nbsp;&nbsp;</a></div>";
            }
            un = IsGernXCodeName("Drama", ID);
            if (un == true)
            {
                string TagViewer = TagViewer0 + "?G=Drama";
                un = false;
                gernsincard += "<div class=" + flashani + " style=" + DivACStyle + "><a name="+"no-animation"+" href=" + TagViewer + " style=" + "color:white;font-size:112%;" + ">&nbsp;&nbsp;&nbsp;Drama&nbsp;&nbsp;&nbsp;</a></div>";
            }
            return gernsincard;
        }
        protected void AddOneView()
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
}