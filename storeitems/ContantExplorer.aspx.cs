﻿using System;
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
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Request.Browser.IsMobileDevice)
                MasterPageFile = "~/SuMManga.Mobile.Master";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            if (GetUserInfoCookie == null)
            {
                Response.Redirect("~/AccountETC/LoginETC.aspx");
            }
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
                string ThemeColor = Request.QueryString["TC"].ToString();//RgbConverter(getDominantColor(bMap));
                string abtntheme = "color:" + Request.QueryString["TC"].ToString();//ORgbConverter(getDominantColor(bMap));
                string theme = Request.QueryString["TC"].ToString();//RgbConverter(getDominantColor(bMap));
                infoCover.Attributes["style"] = "overflow:hidden;background-image:linear-gradient(" + theme + ",rgba(0,0,0,0.3)),url(" + CardBG + ");background-size:cover;background-position:center;width:100vw;height:fit-content;";
                string cn = Request.QueryString["CN"].ToString();
                //MangaViewsAndChapters.InnerText = "Chapters: " + cn + "  -   Views:  "+ ShowViews() + "";
                MdiscS.InnerText = ShowDis();
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
                string themecolor = Request.QueryString["TC"].ToString();
                char sc = '"';
                for (int c = 1; c < (cn1 + 1); c++)
                {
                    string chxC = c.ToString();
                    if (c < 10 && c > 0) { ChapterFixedForm = "000" + chxC; }
                    if (c > 9 && c < 100) { ChapterFixedForm = "00" + chxC; }
                    if (c > 99 && c < 1000) { ChapterFixedForm = "0" + chxC; }
                    if (c > 999 && c < 10000) { ChapterFixedForm = chxC; }
                    if (c > 10000) { c = (cn1 + 1); }
                    RLink = pathstartnochx + extraexplore + identifylast + identifynexthelper + "ch" + ChapterFixedForm + "&TC=" + themecolor;
                    TheMangaPhotosF.InnerHtml += "<a style=" + abtntheme + " class=" + "btn btn-primary btn-sm" + " href=" + sc + RLink + sc + " >Chapter " + chxC + "</a>";
                }
                //string coverstyle = "text-align:left;width:226px;height:320px;border-radius:10px;border-top-left-radius:10px;border-bottom-right-radius:10px;";
                //string covercode = "<img style=" + coverstyle + " src=" + MangaPathCover + ">";
                //mangacoverinpage.InnerHtml += covercode;
                //TheMangaPhotos.InnerHtml += "<a><h1> &zwnj; </h1><h1> &zwnj; </1><h1> &zwnj; </h1><h2> &zwnj; </h2><h4> &zwnj; </h4></a>";
                AddOneView();
            }
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
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:shun-sum-projctdb-server.database.windows.net,1433;Initial Catalog=Shun-SuM-Projct_db;User Id=SuMSite2003@shun-sum-projctdb-server;Password=55878833shunpass#SQL"))
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
        protected string ShowViews()
        {
            string V = string.Empty;
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:shun-sum-projctdb-server.database.windows.net,1433;Initial Catalog=Shun-SuM-Projct_db;User Id=SuMSite2003@shun-sum-projctdb-server;Password=55878833shunpass#SQL"))
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
                        V = dr[0].ToString();
                    }
                }
                sqlCon.Close();
            }
            return V;
        }
        protected string ShowCover()
        {
            string V = string.Empty;
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:shun-sum-projctdb-server.database.windows.net,1433;Initial Catalog=Shun-SuM-Projct_db;User Id=SuMSite2003@shun-sum-projctdb-server;Password=55878833shunpass#SQL"))
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
            return V;
        }
        protected string ShowName()
        {
            string V = string.Empty;
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:shun-sum-projctdb-server.database.windows.net,1433;Initial Catalog=Shun-SuM-Projct_db;User Id=SuMSite2003@shun-sum-projctdb-server;Password=55878833shunpass#SQL"))
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
        protected void AddOneView()
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:shun-sum-projctdb-server.database.windows.net,1433;Initial Catalog=Shun-SuM-Projct_db;User Id=SuMSite2003@shun-sum-projctdb-server;Password=55878833shunpass#SQL"))
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