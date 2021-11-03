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
                    UserNameforshow.InnerText = GetUserInfoCookie["UserName"].ToString();
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
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:shun-sum-projctdb-server.database.windows.net,1433;Initial Catalog=Shun-SuM-Projct_db;User Id=SuMSite2003@shun-sum-projctdb-server;Password=55878833shunpass#SQL"))
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
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:shun-sum-projctdb-server.database.windows.net,1433;Initial Catalog=Shun-SuM-Projct_db;User Id=SuMSite2003@shun-sum-projctdb-server;Password=55878833shunpass#SQL"))
            {
                sqlCon.Open();
                string qwi = "SELECT MAX(MangaID) FROM SuMManga";
                SqlCommand sqlCmd00 = new SqlCommand(qwi, sqlCon);
                var jdbvg = sqlCmd00.ExecuteScalar();
                if (jdbvg != null)
                {
                    int MaxID = Convert.ToInt32(jdbvg);
                    for (int i = ((lt - 1) * 12 + 1); i < (lt * 12 + 1); i++)//ph!-----------------------------!important
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
                                var X = sqlCmd.ExecuteScalar(); //ExecuteNonQuery();
                                string MangaName = X.ToString();

                                query = "SELECT ChaptersNumber FROM SuMManga WHERE MangaID = @MangaID";
                                sqlCmd = new SqlCommand(query, sqlCon);
                                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                                sqlCmd.Parameters["@MangaID"].Value = i;
                                //X = sqlCmd.ExecuteScalar();
                                int ChaptersNum = (Int32)sqlCmd.ExecuteScalar(); // Convert.ToInt32(sqlCmd.ExecuteScalar()); //(Int32)sqlCmd.ExecuteScalar();

                                query = "SELECT MangaInfo FROM SuMManga WHERE MangaID = @MangaID";
                                sqlCmd = new SqlCommand(query, sqlCon);
                                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                                sqlCmd.Parameters["@MangaID"].Value = i;
                                X = sqlCmd.ExecuteScalar();
                                string MangaInfo = X.ToString();

                                query = "SELECT MangaViews FROM SuMManga WHERE MangaID = @MangaID";
                                sqlCmd = new SqlCommand(query, sqlCon);
                                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                                sqlCmd.Parameters["@MangaID"].Value = i;
                                //X = sqlCmd.ExecuteScalar();
                                int MangaViews = (Int32)sqlCmd.ExecuteScalar();

                                query = "SELECT CExplorerLink FROM SuMManga WHERE MangaID = @MangaID";
                                sqlCmd = new SqlCommand(query, sqlCon);
                                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                                sqlCmd.Parameters["@MangaID"].Value = i;
                                X = sqlCmd.ExecuteScalar();
                                string CExplorerLink = X.ToString();

                                query = "SELECT MangaCoverLink FROM SuMManga WHERE MangaID = @MangaID";
                                sqlCmd = new SqlCommand(query, sqlCon);
                                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                                sqlCmd.Parameters["@MangaID"].Value = i;
                                // X = sqlCmd.ExecuteScalar();
                                string MangaCoverLink = sqlCmd.ExecuteScalar().ToString();
                                MangasAvalibleDiv.InnerHtml += ContantShow(MangaName, MangaInfo, MangaViews, MangaCoverLink, CExplorerLink, ChaptersNum, i);
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
        public string ContantShow(string MangaName, string MangaInfo, int MangaViews, string MangaCoverLink, string CExplorerLink, int ChaptersNum, int id)
        {
            string cn = ChaptersNum.ToString();
            CExplorerLink += "&CN=" + cn + "&VC=" + id;
            string figureclass = "imghvr-fade box";//width:160px;
            string figurestyle = "margin-left:2.4px;margin-right:2.4px;margin-top:6px;width:36vw;height:54vw;max-width:160px;max-height:240px;border-radius:12px;border-top-left-radius:12px;border-bottom-right-radius:12px;border:-2px solid #6840D9;";
            string astyle = "border-radius:12px;margin:6px;width:38vw;max-width:168px;";//mw
            //string vstyle = "margin-left:4px;width:24px;height:24px;position:relative;z-index:1;display:block;";
            //string vimage = "/storeitems/view.png";
            string viewes = /*"<img src=" + vimage + " style=" + vstyle + ">" +*/ "<h6 style=" + "color:white;position:relative;display:inline-block;margin-top:-10px;font-size:90%;" + ">Views:" + MangaViews + " Ch: " + ChaptersNum + "<h6>";
            string divfits = "<div data-bss-hover-animate="+"pulse"+" style=" + "display:inline-block; height:fit-content;max-height:268px;width:32vw;max-width:170px;" + ">";//mw class="lazyload"
            string result = divfits + "<a href=" + CExplorerLink + " ><figure class=" + figureclass + "  style = " + astyle + "  ><img class=" + "lazyload" + " style = " + figurestyle + " src=" + MangaCoverLink + ">" + viewes + "<figcaption><h4 style=" + "font-size:100%;" + " ><b>" + MangaName + "</b></h4><br/><h6 style=" + "font-size:74%;" + " >" + MangaInfo + "</h6></figcaption></figure></a></div>";
            return result;
        }
    }
}