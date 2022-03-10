using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace SuM_Manga_V3
{
    public partial class Library : System.Web.UI.Page
    {
        /*protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Request.Browser.IsMobileDevice)
                MasterPageFile = "~/SuMManga.Mobile.Master";
        }*/
        //int loadt = 1;
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
                    MangasAvalibleDiv.InnerHtml = "";
                    var pn = Request.QueryString["P"];
                    if (pn == null || pn == "" || pn == string.Empty) { ContantLoad(1); }
                    else 
                    {
                        string TN = pn.ToString();
                        if (PageNumIsOk(TN) == true) { ContantLoad(Convert.ToInt32(TN)); }
                        else { ContantLoad(1); }
                    }
                    //ContantLoad(1);
                    /*PrePageG.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(PrePageG, string.Empty));
                    if (IsPostBack && Request["__EVENTTARGET"] == PrePageG.UniqueID)
                    {
                        PreviousLPage(PrePageG, EventArgs.Empty);
                    }
                    NextPageG.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(NextPageG, string.Empty));
                    if (IsPostBack && Request["__EVENTTARGET"] == NextPageG.UniqueID)
                    {
                        NextLPage(NextPageG, EventArgs.Empty);
                    }*/
                }
            }
        }
        protected bool PageNumIsOk(string orig) 
        {
            if (orig != null && orig != "" && orig != " ")
            {
                char[] check = orig.ToCharArray();
                for (int i = 0; i < orig.Length; i++)
                {
                    if (char.IsDigit(check[i]) == false) { return false; }
                }
                if (Convert.ToInt32(orig) > 0) { return true; }
                else { return false; }
            }
            else { return false; }
        }
        protected void NextLPage(object sender, EventArgs e) 
        {
            int n = Convert.ToInt32(CurrPageNum.InnerText.ToString());
            int more = n + 1;
            if (NPS.Attributes["class"] == "page-item")
            {
                //string link = "~/Library.aspx?P=" + more.ToString();
                //Response.Redirect(link);
                Response.Redirect(string.Format("~/Library.aspx?P={0}", more.ToString()));
                ContantLoad(more);
            }
            //else { PPS.Attributes["class"] = "page-item disabled"; }
            //if(more)
            /*int maxID = 0;
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string query = "SELECT MAX(MangaID) FROM SuMManga";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                var result = sqlCmd.ExecuteScalar();
                maxID = Convert.ToInt32(result);
                sqlCon.Close();
            }
            if (maxID != 0 && maxID != null && maxID >= (more * 5))
            {
                NPS.Attributes["class"] = "page-item";
                ContantLoad(more);
            }
            else { NPS.Attributes["class"] = "page-item disabled"; }*/
        }
        protected void PreviousLPage(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(CurrPageNum.InnerText.ToString());
            int more = n - 1;
            if (PPS.Attributes["class"] == "page-item") //(n > 1)
            {
                //string link = "~/Library.aspx?P=" + more.ToString();
                //Response.Redirect(link);
                Response.Redirect(string.Format("~/Library.aspx?P={0}", more.ToString()));
                ContantLoad(more);
            }
        }
        /*protected void LoadMore(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(CurrPageNum.InnerText.ToString());
            int more = n + 1;
            ContantLoad(more);
        }*/
        protected void ContantLoad(int lt)
        {
            CurrPageNum.InnerText = lt.ToString();
            if (lt <= 1) { PPS.Attributes["class"] = "page-item disabled"; PrePageG.Attributes["href"] = "#"; }
            else { PPS.Attributes["class"] = "page-item"; PrePageG.Attributes["href"] = "/Library.aspx?P=" + (lt - 1).ToString(); }
            MangasAvalibleDiv.InnerHtml = "";
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                /*string query = string.Empty;
                if (lt == 1)
                {
                    query = "SELECT TOP 12 MangaID from SuMManga order by MangaViews desc;";
                }
                else 
                {
                    query = "SELECT TOP 12 MangaID from SuMManga WHERE  order by MangaViews desc;";
                }
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                Queue<int> RawIDs = new Queue<int>();
                using (var reader = sqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        RawIDs.Enqueue(Convert.ToInt32(reader[0].ToString()));
                    }
                }
                int[] IDs = new int[RawIDs.Count];
                int IDHELPER = 0;
                while (RawIDs.Count > 0)
                {
                    IDs[IDHELPER] = RawIDs.Dequeue();
                    IDHELPER++;
                }

                */
                //
                string qwi = "SELECT MAX(MangaID) FROM SuMManga";
                SqlCommand sqlCmd00 = new SqlCommand(qwi, sqlCon);
                var jdbvg = sqlCmd00.ExecuteScalar();
                if (jdbvg != null)
                {
                    object X;
                    string themecolor = string.Empty;
                    string CExplorerLink = string.Empty;
                    string MangaCoverLink = string.Empty;
                    string MangaName = string.Empty;
                    int MaxID = Convert.ToInt32(jdbvg);
                    for (int i = (lt * 12 ); i > ((lt - 1)* 12); i--)//ph!-----------------------------!important
                    {
                        if ((i + 1) < MaxID) { NPS.Attributes["class"] = "page-item"; NextPageG.Attributes["href"] = "/Library.aspx?P=" + (lt + 1).ToString(); }
                        else { NPS.Attributes["class"] = "page-item disabled"; NextPageG.Attributes["href"] = "#"; }
                        if (i <= MaxID)
                        {
                            NPS.Attributes["class"] = "page-item";
                            string query = "SELECT MangaName FROM SuMManga WHERE MangaID = @MangaID";
                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                            sqlCmd.Parameters["@MangaID"].Value = i;
                            if (sqlCmd.ExecuteScalar() != null)
                            {
                                X = sqlCmd.ExecuteScalar(); //ExecuteNonQuery();
                                MangaName = X.ToString();

                                query = "SELECT MangaCoverLink FROM SuMManga WHERE MangaID = @MangaID";
                                sqlCmd = new SqlCommand(query, sqlCon);
                                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                                sqlCmd.Parameters["@MangaID"].Value = i;
                                // X = sqlCmd.ExecuteScalar();
                                MangaCoverLink = sqlCmd.ExecuteScalar().ToString();

                                query = "SELECT SuMThemeColor FROM SuMManga WHERE MangaID = @MangaID";
                                sqlCmd = new SqlCommand(query, sqlCon);
                                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                                sqlCmd.Parameters["@MangaID"].Value = i;
                                themecolor = sqlCmd.ExecuteScalar().ToString();

                                query = "SELECT CExplorerLink FROM SuMManga WHERE MangaID = @MangaID";
                                sqlCmd = new SqlCommand(query, sqlCon);
                                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                                sqlCmd.Parameters["@MangaID"].Value = i;
                                X = sqlCmd.ExecuteScalar();
                                CExplorerLink = X.ToString();
                                CExplorerLink += "&VC=" + i.ToString();

                                CExplorerLink += "&TC=" + themecolor;

                                MangasAvalibleDiv.InnerHtml += ContantShow(MangaName, MangaCoverLink, CExplorerLink, themecolor);
                            }
                        }
                        else { NPS.Attributes["class"] = "page-item disabled"; }
                        if (MangasAvalibleDiv.InnerHtml == "" || MangasAvalibleDiv.InnerHtml == null || MangasAvalibleDiv.InnerHtml == string.Empty)
                        {
                            MangasAvalibleDiv.InnerHtml = "<h4>No More Pages Left!</h4>";
                        }
                    }
                    sqlCon.Close();
                }
                else { sqlCon.Close(); Response.Redirect("~/404.aspx"); }
            }
        }
        public string ContantShow(string MangaName, string MangaCoverLink, string Link, string theme)
        {
            string LazyLoading = "loading=" + '"'.ToString() + "lazy" + '"'.ToString();//New
            char b12 = '"';
            string zoominanim = b12.ToString() + "fadeIn animated" + b12.ToString();
            string divs0 = "margin-left:6px;display:inline-block;height:fit-content;min-width:118px;max-width:118px;";
            string as0 = "text-decoration:none;display:inline;width:118px;height:177px;overflow:hidden !important;display:block;";//backdrop-filter:blur(1px); Down in divs2
            string divs1 = "border-radius:12px;position:relative;overflow:hidden;background-image:url(" + MangaCoverLink + ");background-size:cover;background-position:center;width:118px;height:177px";
            string divs2 = "background-color:" + theme + "!important;width:100%;height:fit-content;position:absolute;bottom:0;border-radius:8px;"; //var(--SuMThemeColorOP64)
            string ps0 = "margin-top:8px;height:fit-content;width:auto;max-width:112px;color:#ffffff;margin-left:6px;word-wrap:break-word;white-space:pre-wrap;word-break:break-word;text-align:center;";
            string ps1 = "height:fit-content;width:118px;max-width:118px;font-size:69%;color:#2e2e2e;word-wrap:break-word;white-space:pre-wrap;word-break:break-word;";
            string result = "<div class=" + zoominanim + " style=" + divs0 + "><a onclick=" + b12.ToString() + "if (!navigator.onLine) { fetch('" + Link + "', { method: 'GET' }).then(res => { location.href = '" + Link + "'; }).catch(err => { document.getElementById('Offline').style.display = 'block'; }); } else { location.href = '" + Link + "'; }" + b12.ToString() + " style=" + '"' + as0 + '"' + "><div " + LazyLoading + " style=" + divs1 + "><div class=" + "GoodBlur" + " style=" + divs2 + "><p style=" + ps0 + ">" + MangaName + "</p></div></div><p style=" + ps1 + "></p></a></div>"; //GetGarnas(id)
            return result;
        }
    }
}