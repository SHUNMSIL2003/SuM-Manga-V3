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
    public partial class CreatorMangaPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //CREATORS=draft/new
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            if (GetUserInfoCookie == null || Request.QueryString["CREATORS"] == null) { Response.Redirect("~/404.aspx"); }
            if (GetUserInfoCookie["CreatorName"] == null) { Response.Redirect("~/404.aspx"); }
            string CreatorName = GetUserInfoCookie["CreatorName"].ToString();
            bool PreformanceMode = false;
            HttpCookie GetPerModeInfoCookie = Request.Cookies["SuMPerformanceMode"];
            if (GetPerModeInfoCookie != null)
            {
                PreformanceMode = true;
            }
            string CardBG = string.Empty;
            string ThemeColor = "rgba(104,64,217,0.74)";
            if (IsPostBack == false)
            {
                MangaChAMConta.Attributes["style"] = "display:block;height:fit-content;min-height:100vh !important;background-color:" + ThemeColor + ";padding-bottom:164px !important;min-height:calc(100vh + 6px) !important;";
            }
            string abtntheme = "padding-block:0px;padding:0px;border-radius:0px;color:#ffffff;width:100%;height:fit-content;float:left;";//ORgbConverter(getDominantColor(bMap));------background-color:" + ThemeColor + ";
            string theme = ThemeColor;
            if (IsPostBack == false)
            {
                infoCover.Attributes["style"] = "overflow:hidden !important;animation-duration:1.2s !important;background-image:linear-gradient(" + theme + ",rgba(0,0,0,0.3)),url(" + CardBG + ");background-size:cover;background-position:center;width:100%;max-width:720px !important;height:fit-content;";
            }
            int cn1 = 0;
            if (IsPostBack == false)
            {
                GernsTags.Attributes["style"] = "border-top-right-radius:22px;border-top-left-radius:22px;width:100%;height:fit-content;background-color:" + ThemeColor.Replace("0.74", "1") + ";align-content:center;justify-content:center;padding:8px;align-content:center;text-align:center !important;padding-bottom:12px;padding-top:18px;";
            }
            string epath = System.IO.Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            string M0path = epath + "\\storeitems\\" + "" + "\\";
            /*if (System.IO.Directory.Exists(M0path) == false) 
            { willneeditlater
            }*/
            string ChapterFixedForm = string.Empty;
            string RLink = string.Empty;
            string themecolor = ThemeColor;
            char sc = '"';
            char b12 = '"';
            string btnanimationclass = string.Empty;
            if (PreformanceMode == false)
            {
                btnanimationclass = b12.ToString() + "fadeIn animated btn" + b12.ToString();
            }
            else
            {
                btnanimationclass = "btn";
            }
            string managtocheckexsis = "";
            string rootpath = System.IO.Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            string checkifitexsistsStart = rootpath + "\\storeitems\\" + managtocheckexsis + "\\";
            string LazyLoading = "loading=" + '"'.ToString() + "lazy" + '"'.ToString();
            if (GetUserInfoCookie != null)
            {
                MangaUserStateV(ThemeColor);
                MangaCreator.InnerText = CreatorName;
                for (int c = 1; c < (cn1 + 1); c++)
                {
                    string chxC = c.ToString();
                    if (c < 10 && c > 0) { ChapterFixedForm = "000" + chxC; }
                    if (c > 9 && c < 100) { ChapterFixedForm = "00" + chxC; }
                    if (c > 99 && c < 1000) { ChapterFixedForm = "0" + chxC; }
                    if (c > 999 && c < 10000) { ChapterFixedForm = chxC; }
                    if (c > 10000) { c = (cn1 + 1); }
                    string cpcover = "/storeitems/" + "" + "/sumcp" + ChapterFixedForm + ".jpg";
                    if (System.IO.Directory.Exists(checkifitexsistsStart + "ch" + ChapterFixedForm + "\\") == true)
                    {
                        TheMangaPhotosF.InnerHtml += "<a href=" + "#" + " onclick=" + sc.ToString() + "if (!navigator.onLine) { fetch('" + RLink + "', { method: 'GET' }).then(res => { location.href = '" + RLink + "'; }).catch(err => { document.getElementById('Offline').style.display = 'block'; }); } else { location.href = '" + RLink + "'; }" + sc.ToString() + " style=" + abtntheme + " class=" + btnanimationclass + " ><img onerror=" + b12.ToString() + "this.onerror = null; this.src = '/assets/BrokeIMG.png'" + b12.ToString() + " " + LazyLoading + " src=" + cpcover + " style=" + b12.ToString() + "margin:6px;margin-left:12px !important;width:72px;height:72px;float:left;opacity:0.92;border-radius:12px;" + b12.ToString() + "> <p style=" + b12.ToString() + "color:#ffffff;float:left;margin-left:6px;margin-top:14px !important;font-size:112%;" + b12.ToString() + ">Chapter " + chxC + "</p></a>";
                    }
                    else
                    {
                        TheMangaPhotosF.InnerHtml += "<a onclick=" + sc.ToString() + "document.getElementById('MainContent_ChapterUnavaliblePOPUP').style.display = 'block';" + sc.ToString() + " style=" + abtntheme + " class=" + btnanimationclass + " ><img onerror=" + b12.ToString() + "this.onerror = null; this.src = '/assets/BrokeIMG.png'" + b12.ToString() + " " + LazyLoading + " src=" + cpcover + " style=" + b12.ToString() + "margin:6px;margin-left:12px;width:72px;height:72px;float:left;opacity:0.92;border-radius:12px;opacity:0.54;" + b12.ToString() + "> <p style=" + b12.ToString() + "opacity:0.64;color:#ffffff;float:left;margin-left:6px;margin-top:14px !important;font-size:112%;" + b12.ToString() + ">Chapter " + chxC + "</p> <p style=" + b12.ToString() + "opacity:0.64;color:#ffffff;float:right;margin-right:calc(100% - 188px);margin-top:-13px;height:fit-content;width:fit-content;" + b12.ToString() + ">unavailable!</p></a>";
                    }
                    if (c < cn1) { TheMangaPhotosF.InnerHtml += "<hr style=" + sc.ToString() + "margin:0 auto !important;height:2px;border-radius:1px;border-width:0;color:#ffffff;background-color:#ffffff;width:90%;opacity:0.16;margin:0px;margin-block:0px;" + sc.ToString() + ">"; }
                }
            }
            else
            {
                string TC = "";
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
                    string cpcover = "/storeitems/" + "" + "/sumcp" + ChapterFixedForm + ".jpg";
                    if (System.IO.Directory.Exists(checkifitexsistsStart + "ch" + ChapterFixedForm + "\\") == true)
                    {
                        TheMangaPhotosF.InnerHtml += "<a href=" + "#" + " onclick=" + sc.ToString() + "document.getElementById('MainContent_SuMLoginUI').style.display = 'block';" + sc.ToString() + " style=" + abtntheme + " class=" + btnanimationclass + " ><img onerror=" + b12.ToString() + "this.onerror = null; this.src = '/assets/BrokeIMG.png'" + b12.ToString() + " " + LazyLoading + " src=" + cpcover + " style=" + b12.ToString() + "margin:6px;margin-left:12px !important;width:72px;height:72px;float:left;opacity:0.92;border-radius:12px;" + b12.ToString() + "> <p style=" + b12.ToString() + "color:#ffffff;float:left;margin-left:6px;margin-top:14px !important;font-size:112%;" + b12.ToString() + ">Chapter " + chxC + "</p></a>";
                    }
                    else
                    {
                        TheMangaPhotosF.InnerHtml += "<a onclick=" + sc.ToString() + "document.getElementById('MainContent_ChapterUnavaliblePOPUP').style.display = 'block';" + sc.ToString() + " style=" + abtntheme + " class=" + btnanimationclass + " ><img onerror=" + b12.ToString() + "this.onerror = null; this.src = '/assets/BrokeIMG.png'" + b12.ToString() + " " + LazyLoading + " src=" + cpcover + " style=" + b12.ToString() + "margin:6px;margin-left:12px;width:72px;height:72px;float:left;opacity:0.92;border-radius:12px;opacity:0.54;" + b12.ToString() + "> <p style=" + b12.ToString() + "opacity:0.64;color:#ffffff;float:left;margin-left:6px;margin-top:14px !important;font-size:112%" + b12.ToString() + ">Chapter " + chxC + "</p> <p style=" + b12.ToString() + "opacity:0.64;color:#ffffff;float:right;margin-right:calc(100% - 188px);margin-top:-13px;height:fit-content;width:fit-content;" + b12.ToString() + ">unavailable!</p></a>";
                    }
                    if (c < cn1) { TheMangaPhotosF.InnerHtml += "<hr style=" + sc.ToString() + "margin:0 auto !important;height:2px;border-radius:1px;border-width:0;color:#ffffff;background-color:#ffffff;width:90%;opacity:0.16;margin:0px;margin-block:0px;" + sc.ToString() + ">"; }
                }
            }
            if (IsPostBack == false)
            {
                AddToFavNWanna.Attributes["style"] = "overflow:hidden !important;animation-duration:0.26s !important;width:fit-content;height:38px;background-color:" + ThemeColor.Replace("0.74", "0.92") + ";border-radius:18px;padding:4px !important;margin-left:0px;float:left !important;margin-top:28px !important;border-bottom-left-radius:0px !important;border-top-left-radius:0px !important;";
            }
            if (PreformanceMode == true)
            {
                ACont0.Attributes["class"] = "";
                CategoryX.Attributes["class"] = "";
                infoCover.Attributes["class"] = "";
                FavNWannaContaner.Attributes["class"] = "";
                AddToFavNWanna.Attributes["class"] = "";
                WannaListTXT.Attributes["class"] = "";
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
        protected void MangaUserStateV(string TC)
        {
            //TC = TC.Substring(0, TC.Length - 6);
            //TC += ")";
            SVC.Attributes["style"] = "overflow:hidden;background-color:" + TC + ";margin:0 auto;height:fit-content;margin-top:-2px !important;";
            MRSW.InnerHtml = "<b>Start Reading</b><br /><p style=" + "margin-top:-4px;font-size:60%;color:" + TC + ">Auto adds to currently reading</p>";
            MRSW.Attributes["style"] = "overflow:hidden;color:" + TC + ";";
            MRSC.Attributes["style"] = "overflow:hidden;background-color:rgb(255, 255, 255, 0.84);border-radius:12px;width:160px;height:38px;margin:0 auto;text-align:center;justify-content:center;margin-top:3px !important;margin-bottom:13px !important;";
            MRSW.Attributes["onclick"] = "return false;";
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