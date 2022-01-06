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
    public partial class Explore : System.Web.UI.Page
    {
        /*protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Request.Browser.IsMobileDevice)
                MasterPageFile = "~/SuMManga.Mobile.Master";
        }*/
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowCardsCNew();
                //
                //X.InnerHtml=GetFromGarna(X)
                //
                Action.InnerHtml = GetFromGarna("Action");// Comedy
                Fantasy.InnerHtml = GetFromGarna("Fantasy");
                Comedy.InnerHtml = GetFromGarna("Comedy");
                Supernatural.InnerHtml = GetFromGarna("Supernatural");
                SciFi.InnerHtml = GetFromGarna("Sci-Fi");
                Drama.InnerHtml = GetFromGarna("Drama");
                Mystery.InnerHtml = GetFromGarna("Mystery");
                SliceofLife.InnerHtml = GetFromGarna("Slice of Life");
                //.InnerHtml = GetFromGarna("");
                //.InnerHtml = GetFromGarna("");
                //.InnerHtml = GetFromGarna("");
                //.InnerHtml = GetFromGarna("");
                //.InnerHtml = GetFromGarna("");
                //.InnerHtml = GetFromGarna("");
                //.InnerHtml = GetFromGarna("");
                //.InnerHtml = GetFromGarna("");
            }
        }
        protected void SussionPross(object sender, EventArgs e)
        {
            HttpCookie userInfo = Request.Cookies["SuMCurrentUser"];
            if (userInfo != null) 
            {
                string SID = userInfo["SID"].ToString();
                object CMDRs;
                using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    sqlCon.Open();
                    string qwi = "SELECT SIDs FROM SuMUsersAccounts WHERE UserID=@UID";
                    SqlCommand sqlCmd = new SqlCommand(qwi, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@UID", SqlDbType.Int);
                    sqlCmd.Parameters["@UID"].Value = Convert.ToInt32(userInfo["ID"].ToString());
                    CMDRs = sqlCmd.ExecuteScalar();
                    sqlCon.Close();
                }
                if (CMDRs != null) 
                {
                    if (CMDRs.ToString().Contains(SID) == false)
                    {
                        LogOut();
                    }
                }
                else 
                {
                    LogOut();
                }
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
        protected void LogOut()
        {
            HttpCookie GetUserInfoCookie = new HttpCookie("SuMCurrentUser");
            GetUserInfoCookie.Expires = DateTime.Now.AddDays(-100);
            Response.Cookies.Add(GetUserInfoCookie);
        }
        protected void ShowCardsCNew()
        {
            string ResultS = " ";
            int RN = 0;
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string qwi = "SELECT MAX(MangaID) FROM SuMManga";
                SqlCommand sqlCmd00 = new SqlCommand(qwi, sqlCon);
                var jdbvg = sqlCmd00.ExecuteScalar();
                if (jdbvg != null)
                {
                    int maxidf = Convert.ToInt32(jdbvg);
                    int vet = 0;
                    while (vet < 6 && maxidf > 0)
                    {
                        string Name = string.Empty;
                        string Cover = string.Empty;
                        string Disc = string.Empty;
                        string CExplorerLink = string.Empty;
                        string query = "SELECT MangaName FROM SuMManga WHERE MangaID = @MangaID";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                        sqlCmd.Parameters["@MangaID"].Value = maxidf;
                        var un = sqlCmd.ExecuteScalar();
                        if (un != null)
                        {
                            Name = un.ToString();
                            query = "SELECT MangaInfo FROM SuMManga WHERE MangaID = @MangaID";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = maxidf;
                            un = sqlCmd.ExecuteScalar();
                            Disc = un.ToString();
                            query = "SELECT CExplorerLink FROM SuMManga WHERE MangaID = @MangaID";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = maxidf;
                            un = sqlCmd.ExecuteScalar();
                            CExplorerLink = un.ToString();
                            query = "SELECT ChaptersNumber FROM SuMManga WHERE MangaID = @MangaID";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = maxidf;
                            un = sqlCmd.ExecuteScalar();
                            int ChaptersNum = Convert.ToInt32(un);
                            //CExplorerLink += "&CN=" + ChaptersNum.ToString() + "&VC=" + maxidf.ToString() + "&T=" + Theme; moved down
                            query = "SELECT MangaCoverLink FROM SuMManga WHERE MangaID = @MangaID";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = maxidf;
                            // X = sqlCmd.ExecuteScalar();
                            un = sqlCmd.ExecuteScalar();
                            Cover = un.ToString();
                            query = "SELECT SuMThemeColor FROM SuMManga WHERE MangaID = @MangaID";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = maxidf;
                            string themecolor = sqlCmd.ExecuteScalar().ToString();
                            CExplorerLink += "&CN=" + ChaptersNum.ToString() + "&VC=" + maxidf.ToString() + "&TC=" + themecolor;
                            query = "SELECT MangaCreator FROM SuMManga WHERE MangaID = @MangaID";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = maxidf;
                            string MangaCReator = sqlCmd.ExecuteScalar().ToString();
                            query = "SELECT MangaViews FROM SuMManga WHERE MangaID = @MangaID";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = maxidf;
                            int Views = Convert.ToInt32(sqlCmd.ExecuteScalar().ToString());
                            query = "SELECT MangaAgeRating FROM SuMManga WHERE MangaID = @MangaID";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = maxidf;
                            string MangaAgeRating = sqlCmd.ExecuteScalar().ToString();
                            ResultS += BuildCard(Cover, Name, Disc, CExplorerLink, themecolor, MangaCReator, MangaAgeRating, Views);
                            vet++;
                            RN = vet;
                            maxidf = maxidf - 1;
                        }
                    }
                    cardstoshow.InnerHtml = ResultS;
                    cardsdots.InnerHtml = " ";
                    for (int i = 0; i < RN; i++) { cardsdots.InnerHtml += "<span class=" + "dot" + "></span> "; }
                }
                sqlCon.Close();
            }
        }
        protected string GetGarnas(int id)
        {
            string garns = " ";
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string query = "SELECT ID FROM Fantasy WHERE MangaID = @MangaID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = id;
                if (sqlCmd.ExecuteScalar() != null) { garns += "Fantasy, "; }

                query = "SELECT ID FROM Comedy WHERE MangaID = @MangaID";
                sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = id;
                if (sqlCmd.ExecuteScalar() != null) { garns += "Comedy, "; }

                query = "SELECT ID FROM Supernatural WHERE MangaID = @MangaID";
                sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = id;
                if (sqlCmd.ExecuteScalar() != null) { garns += "Supernatural, "; }

                query = "SELECT ID FROM SciFi WHERE MangaID = @MangaID";
                sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = id;
                if (sqlCmd.ExecuteScalar() != null) { garns += "Sci-Fi, "; }

                query = "SELECT ID FROM Drama WHERE MangaID = @MangaID";
                sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = id;
                if (sqlCmd.ExecuteScalar() != null) { garns += "Drama, "; }

                query = "SELECT ID FROM Mystery WHERE MangaID = @MangaID";
                sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = id;
                if (sqlCmd.ExecuteScalar() != null) { garns += "Mystery, "; }

                query = "SELECT ID FROM SliceofLife WHERE MangaID = @MangaID";
                sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = id;
                if (sqlCmd.ExecuteScalar() != null) { garns += "Slice of Life, "; }

                query = "SELECT ID FROM Action WHERE MangaID = @MangaID";
                sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = id;
                if (sqlCmd.ExecuteScalar() != null) { garns += "Action, "; }

                /*query = "SELECT ID FROM smth WHERE MangaID = @MangaID";
                sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = id;
                if (sqlCmd.ExecuteScalar() != null) { garns += "smth, "; }

                query = "SELECT ID FROM smth WHERE MangaID = @MangaID";
                sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = id;
                if (sqlCmd.ExecuteScalar() != null) { garns += "smth, "; }

                query = "SELECT ID FROM smth WHERE MangaID = @MangaID";
                sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                sqlCmd.Parameters["@MangaID"].Value = id;
                if (sqlCmd.ExecuteScalar() != null) { garns += "smth, "; }*/

                //if (garns != null) { if (garns[garns.Length - 2] == ',' && garns[garns.Length - 1] == ' ') { garns.Substring(garns.Length - 3); } }

                sqlCon.Close();
            }
            if (string.IsNullOrEmpty(garns) == false) { garns = garns.Substring(1, (garns.Length - 3)); }
            return garns;
        }
        protected string GetFromGarna(string G)
        {
            int RN = 0;
            string Result = string.Empty;
            string Garna = string.Empty;
            if (G == "Action") { Garna = "Action"; }
            if (G == "Fantasy") { Garna = "Fantasy"; }
            if (G == "Comedy") { Garna = "Comedy"; }
            if (G == "Romance") { Garna = "Romance"; }
            if (G == "BL") { Garna = "BL"; }
            if (G == "GL") { Garna = "GL"; }
            if (G == "Drama") { Garna = "Drama"; }
            if (G == "Mystery") { Garna = "Mystery"; }
            if (G == "Slice of Life") { Garna = "SliceofLife"; }
            if (G == "Supernatural") { Garna = "Supernatural"; }
            if (G == "Sport") { Garna = "Sport"; }
            if (G == "Sci-Fi") { Garna = "SciFi"; }
            if (string.IsNullOrEmpty(G) == false)
            {
                using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    sqlCon.Open();
                    string qwi = "SELECT MAX(ID) FROM " + Garna + " ";
                    SqlCommand sqlCmd00 = new SqlCommand(qwi, sqlCon);
                    var jdbvg = sqlCmd00.ExecuteScalar();
                    //int lt = Convert.ToInt32(StoreV.InnerText.ToString());
                    if (jdbvg != null)
                    {
                        int maxidf = Convert.ToInt32(jdbvg);
                        int vet = 0;
                        while (vet < 6 && maxidf > 0)
                        {
                            string Name = string.Empty;
                            string Cover = string.Empty;
                            string Disc = string.Empty;
                            string CExplorerLink = string.Empty;
                            string query = "SELECT MangaID FROM " + Garna + " WHERE ID = @ID";
                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@ID", SqlDbType.Int);
                            sqlCmd.Parameters["@ID"].Value = maxidf;
                            var un = sqlCmd.ExecuteScalar();
                            if (un != null)
                            {
                                int MangaIDF = Convert.ToInt32(un);
                                query = "SELECT MangaName FROM SuMManga WHERE MangaID = @MangaID";
                                sqlCmd = new SqlCommand(query, sqlCon);
                                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                                sqlCmd.Parameters["@MangaID"].Value = MangaIDF;
                                un = sqlCmd.ExecuteScalar();
                                Name = un.ToString();
                                query = "SELECT CExplorerLink FROM SuMManga WHERE MangaID = @MangaID";
                                sqlCmd = new SqlCommand(query, sqlCon);
                                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                                sqlCmd.Parameters["@MangaID"].Value = MangaIDF;
                                un = sqlCmd.ExecuteScalar();
                                CExplorerLink = un.ToString();
                                query = "SELECT ChaptersNumber FROM SuMManga WHERE MangaID = @MangaID";
                                sqlCmd = new SqlCommand(query, sqlCon);
                                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                                sqlCmd.Parameters["@MangaID"].Value = MangaIDF;
                                un = sqlCmd.ExecuteScalar();
                                int ChaptersNum = Convert.ToInt32(un);
                                CExplorerLink += "&CN=" + ChaptersNum.ToString() + "&VC=" + MangaIDF.ToString();
                                query = "SELECT MangaCoverLink FROM SuMManga WHERE MangaID = @MangaID";
                                sqlCmd = new SqlCommand(query, sqlCon);
                                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                                sqlCmd.Parameters["@MangaID"].Value = MangaIDF;
                                // X = sqlCmd.ExecuteScalar();
                                un = sqlCmd.ExecuteScalar();
                                Cover = un.ToString();
                                query = "SELECT SuMThemeColor FROM SuMManga WHERE MangaID = @MangaID";
                                sqlCmd = new SqlCommand(query, sqlCon);
                                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                                sqlCmd.Parameters["@MangaID"].Value = MangaIDF;
                                string themecolor = sqlCmd.ExecuteScalar().ToString();
                                CExplorerLink += "&TC=" + themecolor;
                                Result += BuildGCard(Cover, Name, G, CExplorerLink, themecolor, MangaIDF);
                                vet++;
                                RN = vet;
                                maxidf = maxidf - 1;
                            }
                        }
                    }
                    else { Result = " "; }
                    sqlCon.Close();
                }
            }
            else { Result = " "; }
            return Result;
        }
        protected string BuildCard(string CardBG, string cardtitle, string discr0, string Link, string theme, string CraetorName, string AgeRating, int V)
        {
            char b12 = '"';
            string divclass = b12.ToString() + "mySlides pulse animated" + b12.ToString();
            string ViewsNumPart = string.Empty;
            string ViewsLPart = string.Empty;
            if (V < 1000)
            {
                ViewsNumPart = V.ToString();
                ViewsLPart = "";
            }
            if (V > 999 && V < 1000000)
            {
                double B = V / 1000.0;
                ViewsNumPart = String.Format("{0:0.00}", B);
                ViewsLPart = "K";
            }
            if (V > 999999 && V < 1000000000)
            {
                double B = V / 1000000.0;
                ViewsNumPart = String.Format("{0:0.00}", B);
                ViewsLPart = "M";
            }
            if (V > 999999999)
            {
                double B = V / 1000000000.0;
                ViewsNumPart = String.Format("{0:0.00}", B);
                ViewsLPart = "B";
            }
            string divstyle = "overflow:hidden;background-image:linear-gradient(" + theme + ",rgba(0,0,0,0.3)),url(" + CardBG + ");background-size:cover;background-position:center;width:100vw;height:74vw;padding:12px;";
            string DivContant = "<div style=" + b12.ToString() + "width:94vw;height:fit-content;position:relative;margin:0 auto;margin-top:2px;" + b12.ToString() + ">";
            DivContant += "<h1 style=" + b12.ToString() + "float:left;margin-top:12px;margin-left:12px;color:#ffffff;font-size:178%;margin-right:14px !important;width:100%;height:fit-content;" + b12.ToString() + ">" + cardtitle + "</h1>";
            DivContant += "<p style=" + b12.ToString() + "color:rgb(255, 255, 255, 0.82); float:right; margin-top:-18px; margin-right:10px;" + b12.ToString() + ">By <b style=" + "font-size:80%;" + ">" + CraetorName + "</b></p></div>";
            DivContant += "<hr style=" + b12.ToString() + "margin:0 auto!important;height:2.6px!important;border-width:0;color:#ffffff;background-color:#ffffff;width:82vw;opacity:0.32;margin:0px;margin-block:0px;border-radius:1.3px !important;margin-bottom:4px;margin-bottom:4px !important;margin-top:-6px;" + b12.ToString() + " />";
            DivContant += "<p style=" + b12.ToString() + "text-align:center;height:36vw;max-height:135px !important;width:94vw;max-width:96vw;font-size:96%;color:#ffffff;margin:4px !important;margin-bottom:6px !important;margin-top:2px !important;text-overflow:ellipsis !important;display:inline-block;overflow:hidden;" + b12.ToString() + ">" + discr0 + "</p>";
            DivContant += "<div style=" + b12.ToString() + "margin:0 auto;margin-bottom:8px;height:fit-content;width:100%;position:relative;" + b12.ToString() + "><a style=" + b12.ToString() + "display:block;float:right !important;margin-bottom:8px;margin-left:calc(92vw - 74px);bottom:0;position:fixed;" + b12.ToString() + ">";
            DivContant += "<p style=" + b12.ToString() + "display:inline;color:rgba(255,255,255,0.74);" + b12.ToString() + ">" + AgeRating + "</p><img style=" + b12.ToString() + "width:20px;height:20px;display:inline;" + b12.ToString() + " src=" + b12.ToString() + "/svg/views.svg" + b12.ToString() + ">";
            DivContant += "<p style=" + "display:inline;color:#ffffff;" + ">" + ViewsNumPart + "</p><b style=" + "display:inline;color:#ffffff;" + ">" + ViewsLPart + "</b></a></div>";
            string result = "<div onclick=" + b12.ToString() + "if (!navigator.onLine) { fetch('" + Link + "', { method: 'GET' }).then(res => { location.href = '" + Link + "'; }).catch(err => { document.getElementById('Offline').style.display = 'block'; }); } else { location.href = '" + Link + "'; }" + b12.ToString() + " class=" + divclass + " style=" + divstyle + ">" + DivContant + "</div>";
            return result;
        }
        /*
        protected static string HexConverter(Color c)
        {
            return String.Format("#{0:X6}", c.ToArgb() & 0x00FFFFFF);
        }*/
        protected static string RgbConverter(Color c)
        {
            return String.Format("rgba({0},{1},{2},0.74)", c.R, c.G, c.B);
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
        protected string BuildGCard(string CardBG, string cardtitle, string G, string Link, string theme, int id)
        {
            //Bitmap bMap = Bitmap.FromFile(Server.MapPath("~/" + CardBG + "")) as Bitmap;
            //string ThemeColor = RgbConverter(getDominantColor(bMap));
            //string cardtitle = string.Empty;
            //string h1style = "float:left;margin-top:8px;margin-left:8px;color:#ffffff;font-size:160%;display:block;";
            //string divclass = "mySlides fade";
            //string pstyle = "color:#f2f2f2;text-align:center;vertical-align:middle;display:block;";
            //string CardBG = "Link!";
            char b12 = '"';
            string zoominanim = b12.ToString() + "fadeIn animated" + b12.ToString();
            string divs0 = "margin-left:6px;display:inline-block;height:fit-content;min-width:118px;max-width:118px;";
            string as0 = "text-decoration:none;display:inline;margin-left:6px;margin-right:6px;";//backdrop-filter:blur(1px); Down in divs2
            string divs1 = "border-radius:8px;position:relative;overflow:hidden;background-image:url(" + CardBG + ");background-size:cover;background-position:center;width:118px;height:177px";
            string divstyle = "overflow:hidden;background-image:linear-gradient(rgba(0,0,0,0.527),rgba(0,0,0,0.3)),url(" + CardBG + ");background-size:cover;background-position:center;width:100vw;height:74vw;padding:12px;";
            string divs2 = "background-color:" + theme + "!important;width:100%;height:fit-content;position:absolute;bottom:0;border-radius:8px;"; //rgb(104,64,217,0.64)
            string ps0 = "margin-top:8px;height:fit-content;width:auto;max-width:112px;color:#ffffff;margin-left:6px;word-wrap:break-word;white-space:pre-wrap;word-break:break-word;text-align:center;";
            string ps1 = "height:fit-content;width:118px;max-width:118px;font-size:69%;color:#2e2e2e;word-wrap:break-word;white-space:pre-wrap;word-break:break-word;";
            string result = "<div class=" + zoominanim + " style=" + divs0 + "><a onclick=" + b12.ToString() + "if (!navigator.onLine) { fetch('" + Link + "', { method: 'GET' }).then(res => { location.href = '" + Link + "'; }).catch(err => { document.getElementById('Offline').style.display = 'block'; }); } else { location.href = '" + Link + "'; }" + b12.ToString() + " style=" + as0 + "><div style=" + divs1 + "><div class=" + "GoodBlur" + " style=" + divs2 + "><p style=" + ps0 + ">" + cardtitle + "</p></div></div><p style=" + ps1 + ">" + GetGarnas(id) + "</p></a></div>"; //GetGarnas(id)
            return result;
        }
    }
}