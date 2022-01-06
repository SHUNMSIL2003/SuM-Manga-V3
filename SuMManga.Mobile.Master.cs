using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace SuM_Manga_V3
{
    public partial class SuMManga_Mobile : System.Web.UI.MasterPage
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Request.QueryString["TC"] != null)
            {
                //SMHead.InnerHtml += "<meta name=" + "theme-color" + " content=" + Request.QueryString["TC"].ToString() + ">";
                System.Web.UI.HtmlControls.HtmlMeta meta = new System.Web.UI.HtmlControls.HtmlMeta();
                meta.Name = "theme-color";
                meta.Content = Request.QueryString["TC"].ToString();
                MetaPlaceHolder.Controls.Add(meta);
                //fullnavscont
            }
            else
            {
                //SMHead.InnerHtml += "<meta name=" + "theme-color" + " content=" + "rgb(242,242,242)" + ">";
                System.Web.UI.HtmlControls.HtmlMeta meta = new System.Web.UI.HtmlControls.HtmlMeta();
                meta.Name = "theme-color";
                meta.Content = "rgb(242,242,242)";
                MetaPlaceHolder.Controls.Add(meta);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["TC"] != null)
            {
                //SMHead.InnerHtml += "<meta name=" + "theme-color" + " content=" + Request.QueryString["TC"].ToString() + ">";
                System.Web.UI.HtmlControls.HtmlMeta meta = new System.Web.UI.HtmlControls.HtmlMeta();
                meta.Name = "theme-color";
                meta.Content = Request.QueryString["TC"].ToString();
                MetaPlaceHolder.Controls.Add(meta);
                //fullnavscont
            }
            else
            {
                //SMHead.InnerHtml += "<meta name=" + "theme-color" + " content=" + "rgb(242,242,242)" + ">";
                System.Web.UI.HtmlControls.HtmlMeta meta = new System.Web.UI.HtmlControls.HtmlMeta();
                meta.Name = "theme-color";
                meta.Content = "rgb(242,242,242)";
                MetaPlaceHolder.Controls.Add(meta);
            }
            //HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            //if (GetUserInfoCookie != null)
            //{
            /*string PFPFDB = string.Empty;
            string user = GetUserInfoCookie["UserName"].ToString();*/
            //}
            string path = HttpContext.Current.Request.Url.AbsolutePath;
            bool foundit = false;
            subnavscont2.Attributes["style"] = "display:none !important;";
            fullnavscont.Attributes["style"] = "border-top-left-radius:22px;border-top-right-radius:22px;height:fit-content !important;overflow:hidden !important;background-color:transparent !important;z-index:999;position:fixed !important;";
            if (path.Contains("Explore") == true || string.IsNullOrEmpty(path) == true || path == "/")
            {
                foundit = true;
                ExpIMG.Attributes["src"] = "/svg/Explore.svg"; ExpText.Attributes["style"] = "font-size:64%;color:#6840D9;height:2vh !important;text-align:center !important;display:block;position:relative;";
                LibIMG.Attributes["src"] = "/svg/bookmarksNA.svg"; LibText.Attributes["style"] = "font-size:64%;color:#636166;height:2vh !important;text-align:center !important;display:block;position:relative;";
                SetIMG.Attributes["src"] = "/svg/settingsNA.svg"; SetText.Attributes["style"] = "font-size:64%;color:#636166;height:2vh !important;text-align:center !important;display:block;position:relative;";
            }
            if (path.Contains("Library") == true)
            {
                foundit = true;
                ExpIMG.Attributes["src"] = "/svg/ExploreNA.svg"; ExpText.Attributes["style"] = "font-size:64%;color:#636166;height:2vh !important;text-align:center !important;display:block;position:relative;";
                LibIMG.Attributes["src"] = "/svg/bookmarks.svg"; LibText.Attributes["style"] = "font-size:64%;color:#6840D9;height:2vh !important;text-align:center !important;display:block;position:relative;";
                SetIMG.Attributes["src"] = "/svg/settingsNA.svg"; SetText.Attributes["style"] = "font-size:64%;color:#636166;height:2vh !important;text-align:center !important;display:block;position:relative;";
            }
            if (path.Contains("Settings") == true || path.Contains("SuMSettings") == true || path.Contains("SuMAccount") == true)
            {
                foundit = true;
                ExpIMG.Attributes["src"] = "/svg/ExploreNA.svg"; ExpText.Attributes["style"] = "font-size:64%;color:#636166;height:2vh !important;text-align:center !important;display:block;position:relative;";
                LibIMG.Attributes["src"] = "/svg/bookmarksNA.svg"; LibText.Attributes["style"] = "font-size:64%;color:#636166;height:2vh !important;text-align:center !important;display:block;position:relative;";
                SetIMG.Attributes["src"] = "/svg/settings.svg"; SetText.Attributes["style"] = "font-size:64%;color:#6840D9;height:2vh !important;text-align:center !important;display:block;position:relative;";
            }
            /*if (path.Contains("smth") == true) 
            {
                ExpIMG.Attributes["src"] = "/svg/Explore.svg"; ExpText.Attributes["style"] = "font-size:64%;color:#6840D9;height:2vh !important;text-align:center !important;display:block;position:relative;";
                LibIMG.Attributes["src"] = "/svg/bookmarksNA.svg"; LibText.Attributes["style"] = "font-size:64%;color:#a3a3a3;height:2vh !important;text-align:center !important;display:block;position:relative;";
                SetIMG.Attributes["src"] = "/svg/settingsNA.svg"; SetText.Attributes["style"] = "font-size:64%;color:#a3a3a3;height:2vh !important;text-align:center !important;display:block;position:relative;";
            }*/
            if (/*path.Contains("ContantExplorer") ||*/ path.Contains("MangaExplorer"))
            {
                //if (Request.QueryString["TC"] != null)
                //{
                //fullnavscont.Attributes["style"] = "border-top-left-radius:22px;border-top-right-radius:22px;height:fit-content;background-color:" + Request.QueryString["TC"].ToString() + " !important;";
                //subnavscont.Attributes["style"] = "height:36px;width:100% !important;padding:2px !important;border-top-left-radius:22px;border-top-right-radius:22px;background-color:" + Request.QueryString["TC"].ToString() + " !important;";
                //wrapper.Attributes["style"] = "overflow:hidden;background-color:" + Request.QueryString["TC"].ToString() + " !important;";
                //}
                fullnavscont.Attributes["style"] = "display:none !important;";
                subnavscont2.Attributes["style"] = "z-index:999;height:46px !important;width:100% !important;padding:2px !important;border-top-left-radius:22px;border-top-right-radius:22px;position:fixed;bottom:0 !important;float:left;border-top:solid 0.4px #f2f2f2 !important;";
                foundit = true; NavItems.InnerHtml = ""; nav.Attributes["style"] = "height:1vh !important;width:100% !important;";
            }
            if (foundit == false) 
            {
                ExpIMG.Attributes["src"] = "/svg/ExploreNA.svg"; ExpText.Attributes["style"] = "font-size:64%;color:#636166;height:2vh !important;text-align:center !important;display:block;position:relative;";
                LibIMG.Attributes["src"] = "/svg/bookmarksNA.svg"; LibText.Attributes["style"] = "font-size:64%;color:#636166;height:2vh !important;text-align:center !important;display:block;position:relative;";
                SetIMG.Attributes["src"] = "/svg/settingsNA.svg"; SetText.Attributes["style"] = "font-size:64%;color:#636166;height:2vh !important;text-align:center !important;display:block;position:relative;";
            }
            if (Request.QueryString["TC"] != null) 
            { 
                mangacolor.Attributes["style"] = "display:inline;color:" + Request.QueryString["TC"].ToString() + ";margin-top:8px !important;";
                mangacolor2.Attributes["style"] = "display:inline;color:" + Request.QueryString["TC"].ToString() + ";margin-top:8px !important;";
            }
        }
        private void SuMAppAlertsStartsS(object sender, EventArgs e)
        {
            int ID = 0;
            HttpCookie GetUserInfoCookie2 = Request.Cookies["SuMCurrentUser"];
            string UserName = GetUserInfoCookie2["UserName"].ToString();
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string query = "SELECT UserID FROM SuMUsersAccounts WHERE UserName = @UserName ";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@UserName", UserName);
                using (SqlDataReader dr = sqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ID = Convert.ToInt32(dr[0]);
                    }
                }
                sqlCon.Close();
            }
            string RawAlert = string.Empty;
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string query = "SELECT SuMPaymentAlert FROM UsersAccountAlert WHERE UserID = @UserID ";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@UserID", SqlDbType.Int);
                sqlCmd.Parameters["@UserID"].Value = ID;
                using (SqlDataReader dr = sqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        RawAlert = dr[0].ToString();
                    }
                }
                sqlCon.Close();
            }
            MarkReadDone(ID, RawAlert);
        }
        protected void ToSign(object sender, EventArgs e)
        {
            Response.Redirect("~/AccountETC/LoginETC.aspx");
        }
        protected void MarkReadDone(int Colum, string OValue) //name colum but its a row
        {
            string confirmseentag = "";
            string backupoldfornew = "";
            bool dollarfound = false;
            char[] value = OValue.ToCharArray();
            for (int g = 0; g < OValue.Length; g++)
            {
                if (dollarfound == false) { backupoldfornew += value[g]; } else { confirmseentag = (value[g + 1]).ToString(); g = OValue.Length; }
                if (g == '$') { dollarfound = true; }//can be optimized ! -Later-> no need now i think...
            }
            string NewSeenTag = string.Empty;
            if (confirmseentag == "N")
            {

                NewSeenTag = backupoldfornew + "Y";
            }
            else { NewSeenTag = OValue; }
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string query = "UPDATE UsersAccountAlert SET SuMPaymentAlert = @SuMPaymentAlert WHERE UserID = @UserID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                //HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
                sqlCmd.Parameters.AddWithValue("@UserID", Colum);
                sqlCmd.Parameters.AddWithValue("@SuMPaymentAlert", NewSeenTag);
                sqlCmd.ExecuteNonQuery();
                //sqlCmd.Parameters.AddWithValue("@SuMCustomPFP", SqlDbType.Image).Value = imgarray;
                sqlCon.Close();
            }
        }
        public void empty0() { }
        protected void LogOut(object sender, EventArgs e)
        {
            HttpCookie GetUserInfoCookie = new HttpCookie("SuMCurrentUser");
            GetUserInfoCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(GetUserInfoCookie);
            //HttpCookie GetUserpinns = Request.Cookies["SuMPinns"];
            //GetUserpinns["Pinns"] = "!";
            //Response.Cookies.Add(GetUserpinns);
            Response.Redirect("~/AccountETC/LogInETC.aspx");
        }
        protected string GetMangaFromSQL(string Wanted)
        {
            string ResultsQ = string.Empty;
            //int i = 0;
            string MangaName = string.Empty;
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string queryFIND = "SELECT MangaID FROM SuMManga WHERE MangaName LIKE @Wanted ";
                SqlCommand sqlCmdFIND = new SqlCommand(queryFIND, sqlCon);
                sqlCmdFIND.Parameters.AddWithValue("@Wanted", Wanted);
                var FID = sqlCmdFIND.ExecuteScalar();
                if (FID != null)
                {
                    //Debig202312.InnerHtml = FID.ToString();
                    //var X = sqlCmdFIND.ExecuteScalar(); //ExecuteNonQuery();
                    int i = Convert.ToInt32(FID);

                    string query = "SELECT ChaptersNumber FROM SuMManga WHERE MangaID = @MangaID";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    sqlCmd.Parameters["@MangaID"].Value = i;
                    //X = sqlCmd.ExecuteScalar();
                    int ChaptersNum = (Int32)sqlCmd.ExecuteScalar(); // Convert.ToInt32(sqlCmd.ExecuteScalar()); //(Int32)sqlCmd.ExecuteScalar();

                    query = "SELECT MangaInfo FROM SuMManga WHERE MangaID = @MangaID";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    sqlCmd.Parameters["@MangaID"].Value = i;
                    var X = sqlCmd.ExecuteScalar();
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
                    query = "SELECT MangaName FROM SuMManga WHERE MangaID = @MangaID";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    sqlCmd.Parameters["@MangaID"].Value = i;
                    X = sqlCmd.ExecuteScalar();
                    MangaName = X.ToString();
                    return ContantShow(MangaName, MangaInfo, MangaViews, MangaCoverLink, CExplorerLink, ChaptersNum, i);


                    //return ContantShow(MangaName, MangaInfo, MangaViews, MangaCoverLink, CExplorerLink, ChaptersNum, ID);
                }
                else { return "<h4>Not Found!</h4>"; }
            }
        }
        public bool MatchUPto50Per(string a, string b)
        {
            if (a.Length > 0 && b.Length > 0)
            {
                char[] ca = a.ToCharArray();
                char[] cb = b.ToCharArray();
                int matchednum = 0;
                double devideon = b.Length;
                if (a.Length > b.Length)
                {
                    for (int i = 0; i < b.Length; i++)
                    {
                        if (ca[i] == cb[i]) { matchednum++; }
                    }
                    if ((double)(matchednum / devideon) > 0.3) { return true; }
                    else { return false; }
                }
                else
                {
                    for (int i = 0; i < a.Length; i++)
                    {
                        if (ca[i] == cb[i]) { matchednum++; }
                    }
                    if ((double)(matchednum / devideon) > 0.3) { return true; }
                    else { return false; }
                }
            }
            else { return false; }
        }
        public string ContantShow(string MangaName, string MangaInfo, int MangaViews, string MangaCoverLink, string CExplorerLink, int ChaptersNum, int id)
        {
            string cn = ChaptersNum.ToString();
            CExplorerLink += "&CN=" + cn + "&VC=" + id;
            string figureclass = "imghvr-fade box";//width:160px;
            string figurestyle = "margin-left:2.6px;margin-right:2.6px;margin-top:3px;width:136px;height:204px;border-radius:10px;border-top-left-radius:10px;border-bottom-right-radius:10px;border:-2px solid #6840D9;";
            string astyle = "border-radius:10px;margin:10px;width:142px;";//mw
            //string vstyle = "margin-left:4px;width:24px;height:24px;position:relative;z-index:1;display:block;";
            //string vimage = "/storeitems/view.png";
            string viewes = /*"<img src=" + vimage + " style=" + vstyle + ">" +*/ "<h6 style=" + "color:white;position:relative;display:inline-block;margin-top:-10px" + ">Views:" + MangaViews + " Ch: " + ChaptersNum + "</h6>";
            string divfits = "<div data-bss-hover-animate=" + "pulse" + " style=" + "display:inline-block; height:fit-content;width:142px;" + ">";//mw
            string result = divfits + "<a href=" + CExplorerLink + " ><figure class=" + figureclass + "  style = " + astyle + "  ><img style = " + figurestyle + " src=" + MangaCoverLink + ">" + viewes + "<figcaption><h6 style=" + "font-size:100%;" + " ><b>" + MangaName + "</b></h6><br/><h6 style=" + "font-size:74%;" + " >" + MangaInfo + "</h6></figcaption></figure></a></div>";
            return result;
        }
    }
}