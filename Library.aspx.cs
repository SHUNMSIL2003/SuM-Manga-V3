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
        int loadt = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            if (GetUserInfoCookie == null)
            {
                Response.Redirect("/AccountETC/LogInETC.aspx");
            }
            UserNameforshow.InnerText = GetUserInfoCookie["UserName"].ToString();
            MangasAvalibleDiv.InnerHtml = "";
            ContantLoad(1);
        }
        protected void LoadMore(object sender, EventArgs e)
        {
            this.loadt++;
            int more = this.loadt;
            ContantLoad(more);
        }
        protected void ContantLoad(int lt)
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:shun-sum-projctdb-server.database.windows.net,1433;Initial Catalog=Shun-SuM-Projct_db;User Id=SuMSite2003@shun-sum-projctdb-server;Password=55878833shunpass#SQL"))
            {
                sqlCon.Open();
                for (int i = 0; i < 20; i++)//ph!-----------------------------!important
                {
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
                sqlCon.Close();
            }
        }
        public string ContantShow(string MangaName, string MangaInfo, int MangaViews, string MangaCoverLink, string CExplorerLink, int ChaptersNum, int id)
        {
            string cn = ChaptersNum.ToString();
            CExplorerLink += "&CN=" + cn + "&VC=" + id;
            string figureclass = "imghvr-fade box";//width:160px;
            string figurestyle = "margin-left:2.6px;margin-right:2.6px;margin-top:3px;width:116px;height:175px;border-radius:10px;border-top-left-radius:10px;border-bottom-right-radius:10px;border:-2px solid #6840D9;";
            string astyle = "border-radius:10px;margin:10px;width:120px;";//mw
            //string vstyle = "margin-left:4px;width:24px;height:24px;position:relative;z-index:1;display:block;";
            //string vimage = "/storeitems/view.png";
            string viewes = /*"<img src=" + vimage + " style=" + vstyle + ">" +*/ "<h6 style=" + "color:white;position:relative;display:inline-block;margin-top:-10px" + ">Views:" + MangaViews + " Ch: " + ChaptersNum + "</h6>";
            string divfits = "<div data-bss-hover-animate="+"pulse"+" style=" + "display:inline-block; height:fit-content;width:120px;" + ">";//mw
            string result = divfits + "<a href=" + CExplorerLink + " ><figure class=" + figureclass + "  style = " + astyle + "  ><img style = " + figurestyle + " src=" + MangaCoverLink + ">" + viewes + "<figcaption><h6 style=" + "font-size:90%;" + " ><b>" + MangaName + "</b></h6><br/><h6 style=" + "font-size:60%;" + " >" + MangaInfo + "</h6></figcaption></figure></a></div>";
            return result;
        }
    }
}