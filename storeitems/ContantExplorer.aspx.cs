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
        protected void Page_Load(object sender, EventArgs e)
        {
            //LastRefreshPross();   -- Needs work  %-- No need now !
            bool ThereIsMoreCHs = false;
            if (Request.QueryString["Manga"] == null || Request.QueryString["VC"] == null) { backhome(); }
            string CardBG = string.Empty;
            if (IsPostBack == false)
            {
                MTitle.InnerText = ShowName();
                CardBG = ShowCover();
            }
            string ThemeColor = string.Empty;
            if (Request.QueryString["TC"] != null)
            {
                ThemeColor = Request.QueryString["TC"].ToString();
            }
            else { ThemeColor = "#6840D9"; }
            if (IsPostBack == false)
            {
                MangaChAMConta.Attributes["style"] = "display:block;height:fit-content;min-height:100vh !important;background-color:" + ThemeColor + ";padding-bottom:164px !important;min-height:calc(100vh + 6px) !important;";
                //BackgroundLayer3.Attributes["style"] = "background-color:" + ThemeColor.Replace("0.74", "0.32") + ";width:100%;height:100%;";
            }
            string abtntheme = "padding-block:0px;padding:0px;border-radius:0px;color:#ffffff;width:100%;height:fit-content;float:left;";//ORgbConverter(getDominantColor(bMap));------background-color:" + ThemeColor + ";
            string theme = ThemeColor;
            if (IsPostBack == false)
            {
                infoCover.Attributes["style"] = "overflow:hidden !important;animation-duration:1.2s !important;background-image:linear-gradient(" + theme + ",rgba(0,0,0,0.3)),url(" + CardBG + ");background-size:cover;background-position:center;width:100%;max-width:720px !important;height:fit-content;";
            }
            int idfg0554 = Convert.ToInt32(Request.QueryString["VC"].ToString());
            int cn1 = 0;
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string query = "SELECT ChaptersNumber FROM SuMManga WHERE MangaID = @MangaID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = idfg0554;
                var un = sqlCmd.ExecuteScalar();
                cn1 = Convert.ToInt32(un);
                sqlCon.Close();
            }
            if (IsPostBack == false)
            {
                MdiscS.InnerText = ShowDis();
                GernsTags.InnerHtml = GetGerns(idfg0554);
                GernsTags.Attributes["style"] = "border-top-right-radius:22px;border-top-left-radius:22px;width:100%;height:fit-content;background-color:" + ThemeColor.Replace("0.74", "1") + ";align-content:center;justify-content:center;padding:8px;align-content:center;text-align:center !important;padding-bottom:12px;padding-top:18px;";
            }
            string pathstartnochx = "/storeitems/";
            string extraexplore = "MangaExplorer.aspx";
            string identifylast = "?Manga=" + Request.QueryString["Manga"].ToString();
            string identifynexthelper = "&Chapter=";
            string epath = System.IO.Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            if (Request.QueryString["Manga"] == null) { backhome(); }
            string M0path = epath + "\\storeitems\\" + Request.QueryString["Manga"] + "\\";
            if (System.IO.Directory.Exists(M0path) == false) { backhome(); }
            if (cn1 > 12)
            {
                ThereIsMoreCHs = true;
                cn1 = 12;
            }
            string ChapterFixedForm = string.Empty;
            string RLink = string.Empty;
            string themecolor = ThemeColor;
            char sc = '"';
            char b12 = '"';
            if (IsPostBack == false)
            {
                SuMLoginUI.Attributes["style"] = "background-color:" + ThemeColor + ";overflow:hidden;width:100vw;height:100vh;display:block;z-index:999 !important;margin:0 auto !important;position:absolute !important;";
            }
            string btnanimationclass = b12.ToString() + "fadeIn animated btn" + b12.ToString();
            string linktoupdate = pathstartnochx + extraexplore + identifylast + "&TC=" + themecolor + "&VC=" + Request.QueryString["VC"].ToString();
            string linktoupdatech = identifynexthelper + "ch";
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            string managtocheckexsis = Request.QueryString["Manga"].ToString();
            string rootpath = System.IO.Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            string checkifitexsistsStart = rootpath + "\\storeitems\\" + managtocheckexsis + "\\";
            string LazyLoading = "loading=" + '"'.ToString() + "lazy" + '"'.ToString();
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
                    if (System.IO.Directory.Exists(checkifitexsistsStart + "ch" + ChapterFixedForm + "\\") == true)
                    {
                        RLink = pathstartnochx + extraexplore + identifylast + identifynexthelper + "ch" + ChapterFixedForm + "&TC=" + themecolor + "&VC=" + Request.QueryString["VC"].ToString();//+ OptionToAddCurrFunc;
                        TheMangaPhotosF.InnerHtml += "<a href=" + "#" + " onclick=" + sc.ToString() + "if (!navigator.onLine) { fetch('" + RLink + "', { method: 'GET' }).then(res => { location.href = '" + RLink + "'; }).catch(err => { document.getElementById('Offline').style.display = 'block'; }); } else { location.href = '" + RLink + "'; }" + sc.ToString() + " style=" + abtntheme + " class=" + btnanimationclass + " ><img onerror=" + b12.ToString() + "this.onerror = null; this.src = '/assets/BrokeIMG.png'" + b12.ToString() + " " + LazyLoading + " src=" + cpcover + " style=" + b12.ToString() + "margin:6px;margin-left:12px !important;width:64px;height:64px;float:left;opacity:0.92;border-radius:8px;" + b12.ToString() + "> <p style=" + b12.ToString() + "color:#ffffff;float:left;margin-left:6px;margin-top:8px !important;" + b12.ToString() + ">Chapter " + chxC + "</p></a>";
                    }
                    else
                    {
                        TheMangaPhotosF.InnerHtml += "<a onclick=" + sc.ToString() + "document.getElementById('MainContent_ChapterUnavaliblePOPUP').style.display = 'block';" + sc.ToString() + " style=" + abtntheme + " class=" + btnanimationclass + " ><img onerror=" + b12.ToString() + "this.onerror = null; this.src = '/assets/BrokeIMG.png'" + b12.ToString() + " " + LazyLoading + " src=" + cpcover + " style=" + b12.ToString() + "margin:6px;margin-left:12px;width:64px;height:64px;float:left;opacity:0.92;border-radius:8px;opacity:0.54;" + b12.ToString() + "> <p style=" + b12.ToString() + "opacity:0.64;color:#ffffff;float:left;margin-left:6px;margin-top:8px !important;" + b12.ToString() + ">Chapter " + chxC + "</p> <p style=" + b12.ToString() + "opacity:0.64;color:#ffffff;float:right;margin-right:calc(100% - 182px);margin-top:-12px;height:fit-content;width:fit-content;" + b12.ToString() + ">unavailable!</p></a>";
                    }
                    if (c < cn1) { TheMangaPhotosF.InnerHtml += "<hr style=" + sc.ToString() + "margin:0 auto !important;height:2px;border-radius:1px;border-width:0;color:#ffffff;background-color:#ffffff;width:94vw;opacity:0.18;margin:0px;margin-block:0px;" + sc.ToString() + ">"; }
                }
            }
            else
            {
                string TC = Request.QueryString["TC"].ToString();
                TC = TC.Substring(0, TC.Length - 6);
                TC += ")";
                SVC.Attributes["style"] = "overflow:hidden;background-color:" + TC + ";margin:0 auto;height:fit-content;margin-top:-2px !important;";
                MRSW.InnerHtml = "<b>Start Reading</b><br /><p style=" + "margin-top:-4px;font-size:60%;color:" + TC + ">You need to Login!</p>";
                MRSW.Attributes["style"] = "overflow:hidden;color:" + TC + ";";
                MRSC.Attributes["style"] = "overflow:hidden;background-color:rgb(255, 255, 255, 0.84);border-radius:12px;width:160px;height:38px;margin:0 auto;text-align:center;justify-content:center;margin-top:3px !important;margin-bottom:13px !important;";
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
                    if (System.IO.Directory.Exists(checkifitexsistsStart + "ch" + ChapterFixedForm + "\\") == true)
                    {
                        RLink = pathstartnochx + extraexplore + identifylast + identifynexthelper + "ch" + ChapterFixedForm + "&TC=" + themecolor + "&VC=" + Request.QueryString["VC"].ToString();//+ OptionToAddCurrFunc;
                        TheMangaPhotosF.InnerHtml += "<a href=" + "#" + " onclick=" + sc.ToString() + "document.getElementById('MainContent_SuMLoginUI').style.display = 'block';" + sc.ToString() + " style=" + abtntheme + " class=" + btnanimationclass + " ><img onerror=" + b12.ToString() + "this.onerror = null; this.src = '/assets/BrokeIMG.png'" + b12.ToString() + " " + LazyLoading + " src=" + cpcover + " style=" + b12.ToString() + "margin:6px;margin-left:12px !important;width:64px;height:64px;float:left;opacity:0.92;border-radius:8px;" + b12.ToString() + "> <p style=" + b12.ToString() + "color:#ffffff;float:left;margin-left:6px;margin-top:8px !important;" + b12.ToString() + ">Chapter " + chxC + "</p></a>";
                    }
                    else
                    {
                        TheMangaPhotosF.InnerHtml += "<a onclick=" + sc.ToString() + "document.getElementById('MainContent_ChapterUnavaliblePOPUP').style.display = 'block';" + sc.ToString() + " style=" + abtntheme + " class=" + btnanimationclass + " ><img onerror=" + b12.ToString() + "this.onerror = null; this.src = '/assets/BrokeIMG.png'" + b12.ToString() + " " + LazyLoading + " src=" + cpcover + " style=" + b12.ToString() + "margin:6px;margin-left:12px;width:64px;height:64px;float:left;opacity:0.92;border-radius:8px;opacity:0.54;" + b12.ToString() + "> <p style=" + b12.ToString() + "opacity:0.64;color:#ffffff;float:left;margin-left:6px;margin-top:8px !important;" + b12.ToString() + ">Chapter " + chxC + "</p> <p style=" + b12.ToString() + "opacity:0.64;color:#ffffff;float:right;margin-right:calc(100% - 182px);margin-top:-12px;height:fit-content;width:fit-content;" + b12.ToString() + ">unavailable!</p></a>";
                    }
                    if (c < cn1) { TheMangaPhotosF.InnerHtml += "<hr style=" + sc.ToString() + "margin:0 auto !important;height:1px;border-width:0;color:#ffffff;background-color:#ffffff;width:96vw;opacity:0.18;margin:0px;margin-block:0px;" + sc.ToString() + ">"; }
                }
            }
            if (ThereIsMoreCHs == true)
            {
                ThreIsMoreACard.Attributes["style"] = "width:100%;height:fit-content;text-align:center !important;margin:0 auto !important;display:block;padding-bottom:2px !important;padding-top:60px !important;";
            }
            else
            {
                ThreIsMoreACard.Attributes["style"] = "display:none;";
            }
            if (IsPostBack == false)
            {
                ChapterUnavaliblePOPUP.Attributes["style"] = "background-color:" + ThemeColor + ";overflow:hidden;width:100%;height:100vh;display:none;z-index:998 !important;margin:0 auto !important;position:absolute !important;padding-left:12px !important;padding-right:12px !important;";
                ShowCreator();
                ShowViews();
                ShowAgeRating();
                ShareLink();
            }
            if (GetUserInfoCookie != null)
            {
                FavListManager(Convert.ToInt32(GetUserInfoCookie["ID"].ToString()));
                WannaListManager(Convert.ToInt32(GetUserInfoCookie["ID"].ToString()));
            }
            else 
            {
                AddToFavNWanna.Attributes.Add("onclick", "document.getElementById('MainContent_SuMLoginUI').style.display = 'block';");
            }
            if (IsPostBack == false)
            {
                AddToFavNWanna.Attributes["style"] = "overflow:hidden !important;animation-duration:0.26s !important;width:fit-content;height:38px;background-color:" + ThemeColor.Replace("0.74", "0.92") + ";border-radius:18px;padding:4px !important;margin-left:0px;float:left !important;margin-top:28px !important;border-bottom-left-radius:0px !important;border-top-left-radius:0px !important;";
                AddOneView();
            }
        }
        protected void WannaListManager(int UID)
        {
            int MID = Convert.ToInt32(Request.QueryString["VC"].ToString());
            bool ItsAWanna = false;
            object RawRes;
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string qwi = "SELECT Wanna FROM SuMUsersAccounts WHERE UserID = @UID";
                SqlCommand sqlCmd00 = new SqlCommand(qwi, sqlCon);
                sqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                sqlCmd00.Parameters["@UID"].Value = UID;
                RawRes = sqlCmd00.ExecuteScalar();
                sqlCon.Close();
            }
            if (RawRes != null)
            {
                if (RawRes.ToString().Contains("#" + MID + "&") == true)
                {
                    ItsAWanna = true;
                }
            }
            if (ItsAWanna == true) 
            {
                Wanna.Attributes["src"] = "/svg/check.svg";
                Wanna.Attributes.Add("onclick", "RemoveFromWannaJava();");
            }
            else 
            {
                Wanna.Attributes["src"] = "/svg/add.svg";
                Wanna.Attributes.Add("onclick", "AddToWannaJava();");
            }
        }
        protected void FavListManager(int UID)
        {
            int MID = Convert.ToInt32(Request.QueryString["VC"].ToString());
            bool ItsAFav = false;
            object RawRes;
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string qwi = "SELECT Fav FROM SuMUsersAccounts WHERE UserID = @UID";
                SqlCommand sqlCmd00 = new SqlCommand(qwi, sqlCon);
                sqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                sqlCmd00.Parameters["@UID"].Value = UID;
                RawRes = sqlCmd00.ExecuteScalar();
                sqlCon.Close();
            }
            if (RawRes != null)
            {
                if (RawRes.ToString().Contains("#" + MID + "&") == true)
                {
                    ItsAFav = true;
                }
            }
            if (ItsAFav == true)
            {
                Fav.Attributes["src"] = "/svg/favorite.svg";
                Fav.Attributes.Add("onclick", "RemoveFromFavJava();");
            }
            else
            {
                Fav.Attributes["src"] = "/svg/favoriteNOTFILLED.svg";
                Fav.Attributes.Add("onclick", "AddToFavJava();");
            }
        }
        protected void AddToWannaList(object sender, EventArgs e)
        {
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            if (GetUserInfoCookie != null)
            {
                int UID = Convert.ToInt32(GetUserInfoCookie["ID"].ToString());
                object RawRes;
                string NewLIST = string.Empty;
                bool NeedUpdate = false;
                string Target = "#" + Request.QueryString["VC"].ToString() + "&";
                using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    sqlCon.Open();
                    string qwi = "SELECT Wanna FROM SuMUsersAccounts WHERE UserID = @UID";
                    SqlCommand sqlCmd00 = new SqlCommand(qwi, sqlCon);
                    sqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                    sqlCmd00.Parameters["@UID"].Value = UID;
                    RawRes = sqlCmd00.ExecuteScalar();
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
                        qwi = "UPDATE SuMUsersAccounts SET Wanna = @NEWWanna WHERE UserID = @UID";
                        sqlCmd00 = new SqlCommand(qwi, sqlCon);
                        sqlCmd00.Parameters.AddWithValue("@NEWWanna", NewLIST);
                        sqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                        sqlCmd00.Parameters["@UID"].Value = UID;
                        sqlCmd00.ExecuteNonQuery();
                    }
                    sqlCon.Close();
                }
            }
        }
        protected void RemoveFromWannaList(object sender, EventArgs e)
        {
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            if (GetUserInfoCookie != null)
            {
                int UID = Convert.ToInt32(GetUserInfoCookie["ID"].ToString());
                object RawRes;
                string NewLIST = string.Empty;
                bool NeedUpdate = false;
                string Target = "#" + Request.QueryString["VC"].ToString() + "&";
                using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    sqlCon.Open();
                    string qwi = "SELECT Wanna FROM SuMUsersAccounts WHERE UserID = @UID";
                    SqlCommand sqlCmd00 = new SqlCommand(qwi, sqlCon);
                    sqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                    sqlCmd00.Parameters["@UID"].Value = UID;
                    RawRes = sqlCmd00.ExecuteScalar();
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
                        qwi = "UPDATE SuMUsersAccounts SET Wanna = @NEWWanna WHERE UserID = @UID";
                        sqlCmd00 = new SqlCommand(qwi, sqlCon);
                        sqlCmd00.Parameters.AddWithValue("@NEWWanna", NewLIST);
                        sqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                        sqlCmd00.Parameters["@UID"].Value = UID;
                        sqlCmd00.ExecuteNonQuery();
                    }
                    sqlCon.Close();
                }
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
                using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    sqlCon.Open();
                    string qwi = "SELECT Fav FROM SuMUsersAccounts WHERE UserID = @UID";
                    SqlCommand sqlCmd00 = new SqlCommand(qwi, sqlCon);
                    sqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                    sqlCmd00.Parameters["@UID"].Value = UID;
                    RawRes = sqlCmd00.ExecuteScalar();
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
                        sqlCmd00 = new SqlCommand(qwi, sqlCon);
                        sqlCmd00.Parameters.AddWithValue("@NEWFav", NewLIST);
                        sqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                        sqlCmd00.Parameters["@UID"].Value = UID;
                        sqlCmd00.ExecuteNonQuery();
                    }
                    sqlCon.Close();
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
                using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    sqlCon.Open();
                    string qwi = "SELECT Fav FROM SuMUsersAccounts WHERE UserID = @UID";
                    SqlCommand sqlCmd00 = new SqlCommand(qwi, sqlCon);
                    sqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                    sqlCmd00.Parameters["@UID"].Value = UID;
                    RawRes = sqlCmd00.ExecuteScalar();
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
                        sqlCmd00 = new SqlCommand(qwi, sqlCon);
                        sqlCmd00.Parameters.AddWithValue("@NEWFav", NewLIST);
                        sqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                        sqlCmd00.Parameters["@UID"].Value = UID;
                        sqlCmd00.ExecuteNonQuery();
                    }
                    sqlCon.Close();
                }
            }
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
        protected void LOADMORECHAPTERS(object sender, EventArgs e)
        {
            int CSN = 1 * 12;
            int CEN = 0;
            int idfg0554 = Convert.ToInt32(Request.QueryString["VC"].ToString());
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string query = "SELECT ChaptersNumber FROM SuMManga WHERE MangaID = @MangaID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = idfg0554;
                var un = sqlCmd.ExecuteScalar();
                CEN = Convert.ToInt32(un);
                sqlCon.Close();
            }
            //NormallCoderFromDownHere
            string ThemeColor = Request.QueryString["TC"].ToString();
            string abtntheme = "padding-block:0px;padding:0px;border-radius:0px;color:#ffffff;width:100%;height:fit-content;float:left;";
            string pathstartnochx = "/storeitems/";
            string extraexplore = "MangaExplorer.aspx";
            string identifylast = "?Manga=" + Request.QueryString["Manga"].ToString();
            string identifynexthelper = "&Chapter=";
            string ChapterFixedForm = string.Empty;
            string RLink = string.Empty;
            string themecolor = ThemeColor;
            char sc = '"';
            char b12 = '"';
            TheMangaPhotosF.InnerHtml += "<hr style=" + sc.ToString() + "margin:0 auto !important;height:1px;border-width:0;color:#ffffff;background-color:#ffffff;width:96vw;opacity:0.18;margin:0px;margin-block:0px;" + sc.ToString() + ">";
            string btnanimationclass = b12.ToString() + "fadeIn animated btn" + b12.ToString();
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            string managtocheckexsis = Request.QueryString["Manga"].ToString();
            string rootpath = System.IO.Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            string checkifitexsistsStart = rootpath + "\\storeitems\\" + managtocheckexsis + "\\";
            string LazyLoading = "loading=" + '"'.ToString() + "lazy" + '"'.ToString();
            if (GetUserInfoCookie != null)
            {
                for (int c = (CSN + 1); c < (CEN + 1); c++)
                {
                    string chxC = c.ToString();
                    if (c < 10 && c > 0) { ChapterFixedForm = "000" + chxC; }
                    if (c > 9 && c < 100) { ChapterFixedForm = "00" + chxC; }
                    if (c > 99 && c < 1000) { ChapterFixedForm = "0" + chxC; }
                    if (c > 999 && c < 10000) { ChapterFixedForm = chxC; }
                    if (c > 10000) { c = (CEN + 1); }
                    string cpcover = "/storeitems/" + Request.QueryString["Manga"].ToString() + "/sumcp" + ChapterFixedForm + ".jpg";
                    if (System.IO.Directory.Exists(checkifitexsistsStart + "ch" + ChapterFixedForm + "\\") == true)
                    {
                        RLink = pathstartnochx + extraexplore + identifylast + identifynexthelper + "ch" + ChapterFixedForm + "&TC=" + themecolor + "&VC=" + Request.QueryString["VC"].ToString();//+ OptionToAddCurrFunc;
                        TheMangaPhotosF.InnerHtml += "<a href=" + "#" + " onclick=" + sc.ToString() + "if (!navigator.onLine) { fetch('" + RLink + "', { method: 'GET' }).then(res => { location.href = '" + RLink + "'; }).catch(err => { document.getElementById('Offline').style.display = 'block'; }); } else { location.href = '" + RLink + "'; }" + sc.ToString() + " style=" + abtntheme + " class=" + btnanimationclass + " ><img onerror=" + b12.ToString() + "this.onerror = null; this.src = '/assets/BrokeIMG.png'" + b12.ToString() + " " + LazyLoading + " src=" + cpcover + " style=" + b12.ToString() + "margin:6px;margin-left:12px !important;width:64px;height:64px;float:left;opacity:0.92;border-radius:8px;" + b12.ToString() + "> <p style=" + b12.ToString() + "color:#ffffff;float:left;margin-left:6px;margin-top:8px !important;" + b12.ToString() + ">Chapter " + chxC + "</p></a>";
                    }
                    else
                    {
                        TheMangaPhotosF.InnerHtml += "<a onclick=" + sc.ToString() + "document.getElementById('MainContent_ChapterUnavaliblePOPUP').style.display = 'block';" + sc.ToString() + " style=" + abtntheme + " class=" + btnanimationclass + " ><img onerror=" + b12.ToString() + "this.onerror = null; this.src = '/assets/BrokeIMG.png'" + b12.ToString() + " " + LazyLoading + " src=" + cpcover + " style=" + b12.ToString() + "margin:6px;margin-left:12px;width:64px;height:64px;float:left;opacity:0.92;border-radius:8px;opacity:0.54;" + b12.ToString() + "> <p style=" + b12.ToString() + "opacity:0.64;color:#ffffff;float:left;margin-left:6px;margin-top:8px !important;" + b12.ToString() + ">Chapter " + chxC + "</p> <p style=" + b12.ToString() + "opacity:0.64;color:#ffffff;float:right;margin-right:calc(100% - 182px);margin-top:-12px;height:fit-content;width:fit-content;" + b12.ToString() + ">unavailable!</p></a>";
                    }
                    if (c < CEN) { TheMangaPhotosF.InnerHtml += "<hr style=" + sc.ToString() + "margin:0 auto !important;height:2px;border-radius:1px;border-width:0;color:#ffffff;background-color:#ffffff;width:94vw;opacity:0.18;margin:0px;margin-block:0px;" + sc.ToString() + ">"; }
                }
            }
            else
            {
                string TC = Request.QueryString["TC"].ToString();
                TC = TC.Substring(0, TC.Length - 6);
                TC += ")";
                SVC.Attributes["style"] = "overflow:hidden;background-color:" + TC + ";margin:0 auto;height:fit-content;margin-top:-2px !important;";
                MRSW.InnerHtml = "<b>Start Reading</b><br /><p style=" + "margin-top:-4px;font-size:60%;color:" + TC + ">You need to Login!</p>";
                MRSW.Attributes["style"] = "overflow:hidden;color:" + TC + ";";
                MRSC.Attributes["style"] = "overflow:hidden;background-color:rgb(255, 255, 255, 0.84);border-radius:12px;width:160px;height:38px;margin:0 auto;text-align:center;justify-content:center;margin-top:3px !important;margin-bottom:13px !important;";
                MRSW.Attributes["onclick"] = "document.getElementById('MainContent_SuMLoginUI').style.display = 'block';";
                for (int c = (CSN + 1); c < (CEN + 1); c++)
                {
                    string chxC = c.ToString();
                    if (c < 10 && c > 0) { ChapterFixedForm = "000" + chxC; }
                    if (c > 9 && c < 100) { ChapterFixedForm = "00" + chxC; }
                    if (c > 99 && c < 1000) { ChapterFixedForm = "0" + chxC; }
                    if (c > 999 && c < 10000) { ChapterFixedForm = chxC; }
                    if (c > 10000) { c = (CEN + 1); }
                    string cpcover = "/storeitems/" + Request.QueryString["Manga"].ToString() + "/sumcp" + ChapterFixedForm + ".jpg";
                    if (System.IO.Directory.Exists(checkifitexsistsStart + "ch" + ChapterFixedForm + "\\") == true)
                    {
                        RLink = pathstartnochx + extraexplore + identifylast + identifynexthelper + "ch" + ChapterFixedForm + "&TC=" + themecolor + "&VC=" + Request.QueryString["VC"].ToString();//+ OptionToAddCurrFunc;
                        TheMangaPhotosF.InnerHtml += "<a href=" + "#" + " onclick=" + sc.ToString() + "document.getElementById('MainContent_SuMLoginUI').style.display = 'block';" + sc.ToString() + " style=" + abtntheme + " class=" + btnanimationclass + " ><img onerror=" + b12.ToString() + "this.onerror = null; this.src = '/assets/BrokeIMG.png'" + b12.ToString() + " " + LazyLoading + " src=" + cpcover + " style=" + b12.ToString() + "margin:6px;margin-left:12px !important;width:64px;height:64px;float:left;opacity:0.92;border-radius:8px;" + b12.ToString() + "> <p style=" + b12.ToString() + "color:#ffffff;float:left;margin-left:6px;margin-top:8px !important;" + b12.ToString() + ">Chapter " + chxC + "</p></a>";
                    }
                    else
                    {
                        TheMangaPhotosF.InnerHtml += "<a onclick=" + sc.ToString() + "document.getElementById('MainContent_ChapterUnavaliblePOPUP').style.display = 'block';" + sc.ToString() + " style=" + abtntheme + " class=" + btnanimationclass + " ><img onerror=" + b12.ToString() + "this.onerror = null; this.src = '/assets/BrokeIMG.png'" + b12.ToString() + " " + LazyLoading + " src=" + cpcover + " style=" + b12.ToString() + "margin:6px;margin-left:12px;width:64px;height:64px;float:left;opacity:0.92;border-radius:8px;opacity:0.54;" + b12.ToString() + "> <p style=" + b12.ToString() + "opacity:0.64;color:#ffffff;float:left;margin-left:6px;margin-top:8px !important;" + b12.ToString() + ">Chapter " + chxC + "</p> <p style=" + b12.ToString() + "opacity:0.64;color:#ffffff;float:right;margin-right:calc(100% - 182px);margin-top:-12px;height:fit-content;width:fit-content;" + b12.ToString() + ">unavailable!</p></a>";
                    }
                    if (c < CEN) { TheMangaPhotosF.InnerHtml += "<hr style=" + sc.ToString() + "margin:0 auto !important;height:1px;border-width:0;color:#ffffff;background-color:#ffffff;width:96vw;opacity:0.18;margin:0px;margin-block:0px;" + sc.ToString() + ">"; }
                }
            }
            ThreIsMoreACard.Attributes["style"] = "display:none;";
            LoadChapters.Update();
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
            string LINK = "https://sum-manga.azurewebsites.net/storeitems/ContantExplorer.aspx?Manga=" + Request.QueryString["Manga"].ToString() + "&VC=" + Request.QueryString["VC"].ToString() + "&TC=" + Request.QueryString["TC"].ToString();
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
        protected void MangaUserStateV(int MID, string LinkToUpdate, string linktoupdatech)
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
                            SVC.Attributes["style"] = "overflow:hidden;background-color:" + TC + ";margin:0 auto;height:fit-content;margin-top:-2px !important;";
                            MRSW.InnerHtml = "<b>Continue Reading</b><br /><p style=" + "margin-top:-4px;font-size:64%;color:" + TC + ">Currently In Chapter " + c + "</p>";
                            MRSW.Attributes["style"] = "overflow:hidden;color:" + TC + ";";
                            MRSC.Attributes["style"] = "overflow:hidden;background-color:rgb(255, 255, 255, 0.84);border-radius:12px;width:160px;height:38px;margin:0 auto;text-align:center;justify-content:center;margin-top:3px !important;margin-bottom:13px !important;";
                            string WorkerHelp = "&UCU=" + MID.ToString();
                            MRSW.Attributes["onclick"] = "if (!navigator.onLine) { fetch('" + LinkToUpdate + linktoupdatech + ChapterFixedForm + WorkerHelp + "', { method: 'GET' }).then(res => { location.href = '" + LinkToUpdate + linktoupdatech + ChapterFixedForm + WorkerHelp + "'; }).catch(err => { document.getElementById('Offline').style.display = 'block'; }); } else { location.href = '" + LinkToUpdate + linktoupdatech + ChapterFixedForm + WorkerHelp + "'; }";
                            sqlCon.Close();
                        }
                    }
                    if (foundit == false)
                    {
                        SVC.Attributes["style"] = "overflow:hidden;background-color:" + TC + ";margin:0 auto;height:fit-content;margin-top:-2px !important;";
                        MRSW.InnerHtml = "<b>Start Reading</b><br /><p style=" + "margin-top:-4px;font-size:60%;color:" + TC + ">Auto adds to currently reading</p>";
                        MRSW.Attributes["style"] = "overflow:hidden;color:" + TC + ";";
                        MRSC.Attributes["style"] = "overflow:hidden;background-color:rgb(255, 255, 255, 0.84);border-radius:12px;width:160px;height:38px;margin:0 auto;text-align:center;justify-content:center;margin-top:3px !important;margin-bottom:13px !important;";
                        MRSW.Attributes["onclick"] = "if (!navigator.onLine) { fetch('" + LinkToUpdate + linktoupdatech + "0001" + "&ADTCU=" + MID + "', { method: 'GET' }).then(res => { location.href = '" + LinkToUpdate + linktoupdatech + "0001" + "&ADTCU=" + MID + "'; }).catch(err => { document.getElementById('Offline').style.display = 'block'; }); } else { location.href = '" + LinkToUpdate + linktoupdatech + "0001" + "&ADTCU=" + MID + "'; }";
                        sqlCon.Close();
                    }
                }
                else
                {
                    string TC = Request.QueryString["TC"].ToString();
                    TC = TC.Substring(0, TC.Length - 6);
                    TC += ")";
                    SVC.Attributes["style"] = "overflow:hidden;background-color:" + TC + ";margin:0 auto;height:fit-content;margin-top:-2px !important;";
                    MRSW.InnerHtml = "<b>Start Reading</b><br /><p style=" + "margin-top:-4px;font-size:60%;color:" + TC + ">Auto adds to currently reading</p>";
                    MRSW.Attributes["style"] = "overflow:hidden;color:" + TC + ";";
                    MRSC.Attributes["style"] = "overflow:hidden;background-color:rgb(255, 255, 255, 0.84);border-radius:12px;width:160px;height:38px;margin:0 auto;text-align:center;justify-content:center;margin-top:3px !important;margin-bottom:13px !important;";
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
            FakeBody.Attributes["style"] = "background-image:url(" + V + ");width:100vw !important;height:100vh !important;max-height:100vh !important;position:absolute !important;";
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
        protected bool IsGernXCodeName(string X, int MangaID)
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
        protected string GetGerns(int ID)
        {
            char b12 = '"';
            string flashani = b12.ToString() + "fadeIn animated" + b12.ToString();
            bool un = false;
            string gernsincard = " ";
            //string TagViewer0 = "/storeitems/TagView.aspx";
            string ThemeColor = "rgba(225,225,225,0.36)";//DesignChange!
            string DivACStyle = b12.ToString() + "height:fit-content !important;margin-left:6px;display:inline-block;width:fit-content;height:38px;background-color:" + ThemeColor + ";border-radius:19px;padding:2px;" + b12.ToString();
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
            LogInProssInfo.Attributes["style"] = "display:none;";
            string statevalid = "";
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string query = "SELECT UserID FROM SuMUsersAccounts WHERE UserName = @UserName AND Password = @Password ";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                string username = UserNameL.Value; //Request.QueryString["UserNameL"].ToString();
                sqlCmd.Parameters.AddWithValue("@UserName", username);
                string password = PasswordL.Value; //Request.QueryString["PasswordL"].ToString();
                sqlCmd.Parameters.AddWithValue("@Password", sha256(password));
                var Res = sqlCmd.ExecuteScalar();
                if (Res != null)
                {
                    int ID = Convert.ToInt32(Res.ToString());
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
                    if (statevalid.Contains("#R") == true)//statevalid[0] == '#' && statevalid[1] == 'R'&&
                    {
                        LoginStatus.InnerText = "You need to Complete SuM Account registration! You will find a link in you email-inbox.";
                        LogInProssInfo.Attributes["style"] = "background-color:rgba(255,124,107,0.16);width:100%;text-align:center;padding:0px;height:fit-content;border-radius:14px;display:block;";
                        ResendConf.Visible = true;
                    }
                    else
                    {
                        string qwi = "SELECT SIDs FROM SuMUsersAccounts WHERE UserID = @UID";
                        sqlCmd = new SqlCommand(qwi, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@UID", SqlDbType.Int);
                        sqlCmd.Parameters["@UID"].Value = ID;
                        var CMDRs = sqlCmd.ExecuteScalar();
                        if (CMDRs != null)
                        {

                            if (SIDsCountLessThanX(CMDRs.ToString(), 3) == true)
                            {
                                string qc = "SELECT CreatorName FROM SuMCreators WHERE UserName = @UserName";
                                SqlCommand cv = new SqlCommand(qc, sqlCon);
                                cv.Parameters.AddWithValue("@UserName", username);
                                var ituac = cv.ExecuteScalar();
                                string GSID = GetNewSID(username);
                                qc = "UPDATE SuMUsersAccounts SET SIDs = @NSID WHERE UserID = @UID";
                                cv = new SqlCommand(qc, sqlCon);
                                cv.Parameters.AddWithValue("@UID", SqlDbType.Int);
                                cv.Parameters["@UID"].Value = ID;
                                cv.Parameters.AddWithValue("@NSID", CMDRs.ToString() + GSID);
                                cv.ExecuteNonQuery();
                                if (ituac == null)
                                {
                                    SaveCookie(username, ID, GSID);
                                    sqlCon.Close();
                                    Response.Redirect(Request.Url.ToString() + RandomQuryForReload());
                                }
                                else
                                {
                                    qc = "SELECT UserID FROM SuMCreators WHERE UserName = @UserName";
                                    cv = new SqlCommand(qc, sqlCon);
                                    cv.Parameters.AddWithValue("@UserName", username);
                                    int CID = Convert.ToInt32(cv.ExecuteScalar().ToString());
                                    SaveSCCookie(username, ituac.ToString(), ID, CID, GSID);
                                    sqlCon.Close();
                                    Response.Redirect(Request.Url.ToString() + RandomQuryForReload());
                                }
                            }
                            else
                            {
                                HttpCookie CacheUserInfo = new HttpCookie("SuMCurrentLoginWorkerCache");
                                CacheUserInfo["ID"] = ID.ToString();
                                CacheUserInfo.Expires = DateTime.Now.AddMinutes(30);
                                HttpContext.Current.Response.Cookies.Add(CacheUserInfo);
                                LoginStatus.InnerText = "You can login to a maximum of three devices!";
                                LogInProssInfo.Attributes["style"] = "background-color:rgba(255,124,107,0.16);width:100%;text-align:center;padding:0px;height:fit-content;border-radius:14px;display:block;";
                                LogOutOffAllBTN.Visible = true;
                            }
                        }
                        else
                        {
                            string qc = "SELECT CreatorName FROM SuMCreators WHERE UserName = @UserName";
                            SqlCommand cv = new SqlCommand(qc, sqlCon);
                            cv.Parameters.AddWithValue("@UserName", username);
                            var ituac = cv.ExecuteScalar();
                            string GSID = GetNewSID(username);
                            qc = "UPDATE SuMUsersAccounts SET SIDs = @NSID WHERE UserID = @UID";
                            cv = new SqlCommand(qc, sqlCon);
                            cv.Parameters.AddWithValue("@UID", SqlDbType.Int);
                            cv.Parameters["UID"].Value = ID;
                            cv.Parameters.AddWithValue("@NSID", GSID);
                            cv.ExecuteNonQuery();
                            if (ituac == null)
                            {
                                SaveCookie(username, ID, GSID);
                                sqlCon.Close();
                                Response.Redirect(Request.Url.ToString() + RandomQuryForReload());
                            }
                            else
                            {
                                qc = "SELECT UserID FROM SuMCreators WHERE UserName = @UserName";
                                cv = new SqlCommand(qc, sqlCon);
                                cv.Parameters.AddWithValue("@UserName", username);
                                int CID = Convert.ToInt32(cv.ExecuteScalar().ToString());
                                SaveSCCookie(username, ituac.ToString(), ID, CID, GSID);
                                sqlCon.Close();
                                Response.Redirect(Request.Url.ToString() + RandomQuryForReload());
                            }
                        }
                    }
                }
                else
                {
                    UserNameL.Attributes["style"] = "border: solid 2px rgb(255,90,69);border-radius:14px;";
                    PasswordL.Attributes["style"] = "border: solid 2px rgb(255,90,69);border-radius:14px;";
                    LoginStatus.InnerText = "Username Or Password are incurrect!";
                    LogInProssInfo.Attributes["style"] = "background-color:rgba(255,124,107,0.16);width:100%;text-align:center;padding:0px;height:fit-content;border-radius:14px;display:block;";
                    sqlCon.Close();
                }
                sqlCon.Close();
            }
        }
        protected void LogOutOffAll(object sender, EventArgs e)
        {
            HttpCookie GetLoginCacheUserInfo = Request.Cookies["SuMCurrentLoginWorkerCache"];
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string query = "UPDATE SuMUsersAccounts SET SIDs = NULL WHERE UserID = @UID";
                SqlCommand sqlCmd2 = new SqlCommand(query, sqlCon);
                sqlCmd2.Parameters.AddWithValue("@UID", System.Data.SqlDbType.Int);
                sqlCmd2.Parameters["@UID"].Value = Convert.ToInt32(GetLoginCacheUserInfo["ID"].ToString());
                sqlCmd2.ExecuteNonQuery();
                sqlCon.Close();
            }
            Response.Redirect(Request.Url.ToString() + RandomQuryForReload());
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
        protected static void SaveCookie(string UserName, int ID, string SessionID)
        {
            HttpCookie userInfo = new HttpCookie("SuMCurrentUser");
            userInfo["UserName"] = UserName;
            userInfo["ID"] = ID.ToString();
            userInfo["SID"] = SessionID;
            userInfo.Expires = DateTime.MaxValue;
            HttpContext.Current.Response.Cookies.Add(userInfo);
        }
        protected static void SaveSCCookie(string UserName, string craetorname, int ID, int CID, string SessionID)
        {
            HttpCookie userInfo = new HttpCookie("SuMCurrentUser");
            userInfo["UserName"] = UserName;
            userInfo["CreatorName"] = craetorname;
            userInfo["SID"] = SessionID;
            userInfo["ID"] = ID.ToString();
            userInfo["CID"] = CID.ToString();
            userInfo.Expires = DateTime.MaxValue;
            HttpContext.Current.Response.Cookies.Add(userInfo);
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
        protected static string GetNewSID(string UserName)
        {
            int length = 6;
            char[] chArray = "abcd168efgh1ijklmnopqrst16uvwxyz122d34567890ABdCDEFGHI6J3KLMNOPQRST6UVWXYZ".ToCharArray();
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
            DateTime dateTime = DateTime.UtcNow.Date;
            str = "#" + str + "%" + UserName + "%" + dateTime.ToString("yyyyMMdd") + "@";
            return str;
        }
        protected string[] SIDsToStringArray(string SIDs)
        {
            Queue<string> R1 = new Queue<string>();
            bool fh = false;
            string A1 = "";
            char[] aa = SIDs.ToCharArray();
            for (int i = 0; i < aa.Length; i++)
            {
                if (aa[i] == '@')
                {
                    A1 += "@";
                    fh = false;
                    R1.Enqueue(A1);
                    A1 = "";
                }
                if (aa[i] == '#') { fh = true; }
                if (fh == true)
                {
                    A1 += aa[i].ToString();
                }
            }
            string[] RS = new string[R1.Count];
            while (R1.Count > 0)
            {
                RS[R1.Count - 1] = R1.Dequeue();
            }
            return RS;
        }
        protected bool SIDsCountLessThanX(string SIDs, int MAX)
        {
            int HCount = SIDs.Count(f => (f == '#'));
            int CCount = SIDs.Count(f => (f == '@'));
            if (HCount == CCount)
            {
                if (CCount < MAX) { return true; }
                else { return false; }
            }
            else { return false; }
        }
        protected void LogInWithGoogle(object sender, EventArgs e)
        {

        }
        // -- Login Part Eng --
        protected void LastRefreshPross()
        {
            HttpCookie GetRefreshInfoCookie = Request.Cookies["SuMMangaRefreshPross" + Request.QueryString["Manga"].ToString()];
            if (GetRefreshInfoCookie != null)
            {
                int Year = Convert.ToInt32(GetRefreshInfoCookie["LatestUpdatedYear"].ToString());
                int Month = Convert.ToInt32(GetRefreshInfoCookie["LatestUpdatedMonth"].ToString());
                int Day = Convert.ToInt32(GetRefreshInfoCookie["LatestUpdatedDay"].ToString());
                int Hour = Convert.ToInt32(GetRefreshInfoCookie["LatestUpdatedHour"].ToString());
                int CurrYear = Convert.ToInt32(DateTime.UtcNow.ToString("yyyy"));
                int CurrMonth = Convert.ToInt32(DateTime.UtcNow.ToString("MM"));
                int CurrDay = Convert.ToInt32(DateTime.UtcNow.ToString("dd"));
                int CurrHour = Convert.ToInt32(DateTime.UtcNow.ToString("HH"));
                if ((Year - CurrYear) == 0)
                {
                    if ((Month - CurrMonth) == 0)
                    {
                        if ((Day - CurrDay) != 0)
                        {
                            HttpCookie UpdateInfo = new HttpCookie("SuMMangaRefreshPross" + Request.QueryString["Manga"].ToString());
                            UpdateInfo["LatestUpdatedYear"] = DateTime.UtcNow.ToString("yyyy");
                            UpdateInfo["LatestUpdatedMonth"] = DateTime.UtcNow.ToString("MM");
                            UpdateInfo["LatestUpdatedDay"] = DateTime.UtcNow.ToString("dd");
                            UpdateInfo["LatestUpdatedHour"] = DateTime.UtcNow.ToString("HH");
                            UpdateInfo.Expires = DateTime.MaxValue;
                            HttpContext.Current.Response.Cookies.Add(UpdateInfo);
                            ReloadAndUpdate();
                        }
                    }
                    else
                    {
                        HttpCookie UpdateInfo = new HttpCookie("SuMMangaRefreshPross" + Request.QueryString["Manga"].ToString());
                        UpdateInfo["LatestUpdatedYear"] = DateTime.UtcNow.ToString("yyyy");
                        UpdateInfo["LatestUpdatedMonth"] = DateTime.UtcNow.ToString("MM");
                        UpdateInfo["LatestUpdatedDay"] = DateTime.UtcNow.ToString("dd");
                        UpdateInfo["LatestUpdatedHour"] = DateTime.UtcNow.ToString("HH");
                        UpdateInfo.Expires = DateTime.MaxValue;
                        HttpContext.Current.Response.Cookies.Add(UpdateInfo);
                        ReloadAndUpdate();
                    }
                }
                else
                {
                    HttpCookie UpdateInfo = new HttpCookie("SuMMangaRefreshPross" + Request.QueryString["Manga"].ToString());
                    UpdateInfo["LatestUpdatedYear"] = DateTime.UtcNow.ToString("yyyy");
                    UpdateInfo["LatestUpdatedMonth"] = DateTime.UtcNow.ToString("MM");
                    UpdateInfo["LatestUpdatedDay"] = DateTime.UtcNow.ToString("dd");
                    UpdateInfo["LatestUpdatedHour"] = DateTime.UtcNow.ToString("HH");
                    UpdateInfo.Expires = DateTime.MaxValue;
                    HttpContext.Current.Response.Cookies.Add(UpdateInfo);
                    ReloadAndUpdate();
                }
            }
            else
            {
                HttpCookie UpdateInfo = new HttpCookie("SuMMangaRefreshPross" + Request.QueryString["Manga"].ToString());
                UpdateInfo["LatestUpdatedYear"] = DateTime.UtcNow.ToString("yyyy");
                UpdateInfo["LatestUpdatedMonth"] = DateTime.UtcNow.ToString("MM");
                UpdateInfo["LatestUpdatedDay"] = DateTime.UtcNow.ToString("dd");
                UpdateInfo["LatestUpdatedHour"] = DateTime.UtcNow.ToString("HH");
                UpdateInfo.Expires = DateTime.MaxValue;
                HttpContext.Current.Response.Cookies.Add(UpdateInfo);
            }
        }
        protected void ReloadAndUpdate()
        {
            string CurrURL = Request.Url.ToString();
            if (CurrURL.Contains("?") == true)
            {
                Response.Redirect(Request.Url.ToString() + "&" + RandomQuryForUpdate());
            }
            else
            {
                Response.Redirect(Request.Url.ToString() + "?" + RandomQuryForUpdate());
            }
        }
        protected static string RandomQuryForUpdate()
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
            return "UPDATE=" + str;
        }

    }
}