using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace SuM_Manga_V3.storeitems
{
    public partial class TagView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }/*
        protected void ContantLoad(int lt)
        {
            CurrPageNum.InnerText = lt.ToString();
            if (lt <= 1) { PPS.Attributes["class"] = "page-item disabled"; PrePageG.Attributes["href"] = "#"; }
            else { PPS.Attributes["class"] = "page-item"; PrePageG.Attributes["href"] = "/Library.aspx?P=" + (lt - 1).ToString(); }
            MangasAvalibleDiv.InnerHtml = "";
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
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

                                query = "SELECT SuMThemeColor FROM SuMManga WHERE MangaID = @MangaID";
                                sqlCmd = new SqlCommand(query, sqlCon);
                                sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                                sqlCmd.Parameters["@MangaID"].Value = i;
                                // X = sqlCmd.ExecuteScalar();
                                string MangaTheme = sqlCmd.ExecuteScalar().ToString();

                                MangasAvalibleDiv.InnerHtml += BuildGCard(MangaCoverLink,MangaName, "", CExplorerLink, MangaTheme, i);
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
        protected string BuildGCard(string CardBG, string cardtitle, string G, string Link, string theme, int id)
        {
            //Bitmap bMap = Bitmap.FromFile(Server.MapPath("~/" + CardBG + "")) as Bitmap;
            //string ThemeColor = RgbConverter(getDominantColor(bMap));
            //string cardtitle = string.Empty;
            //string h1style = "float:left;margin-top:8px;margin-left:8px;color:var(--SuMDWhite);font-size:160%;display:block;";
            //string divclass = "mySlides fade";
            //string pstyle = "color:var(--SuMDGray);text-align:center;vertical-align:middle;display:block;";
            //string CardBG = "Link!";
            char b12 = '"';
            string zoominanim = b12.ToString() + "fadeIn animated" + b12.ToString();
            string divs0 = "margin-left:6px;display:inline-block;height:fit-content;min-width:118px;max-width:118px;";
            string as0 = "text-decoration:none;display:inline;margin-left:6px;margin-right:6px;";//backdrop-filter:blur(1px); Down in divs2
            string divs1 = "border-radius:8px;position:relative;overflow:hidden;background-image:url(" + CardBG + ");background-size:cover;background-position:center;width:118px;height:177px";
            string divstyle = "overflow:hidden;background-image:linear-gradient(var(--SuMDBlackOP527),var(--SuMDBlackOP30)),url(" + CardBG + ");background-size:cover;background-position:center;width:100vw;height:74vw;padding:12px;";
            string divs2 = "background-color:" + theme + "!important;width:100%;height:fit-content;position:absolute;bottom:0;border-radius:8px;"; //var(--SuMThemeColorOP64)
            string ps0 = "margin-top:8px;height:fit-content;width:auto;max-width:112px;color:var(--SuMDWhite);margin-left:6px;word-wrap:break-word;white-space:pre-wrap;word-break:break-word;text-align:center;";
            string ps1 = "height:fit-content;width:118px;max-width:118px;font-size:69%;color:var(--SuMDBlackOP64);word-wrap:break-word;white-space:pre-wrap;word-break:break-word;";
            string result = "<div class=" + zoominanim + " style=" + divs0 + "><a href=" + Link + " style=" + as0 + "><div style=" + divs1 + "><div class=" + "GoodBlur" + " style=" + divs2 + "><p style=" + ps0 + ">" + cardtitle + "</p></div></div><p style=" + ps1 + ">" + GetGarnas(id) + "</p></a></div>";//GetGarnas(id)
            return result;
        }*/
    }
}