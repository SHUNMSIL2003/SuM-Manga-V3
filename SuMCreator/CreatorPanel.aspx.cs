using System;
using System.Collections.Generic;
using System.Web;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.IO;

namespace SuM_Manga_V3.SuMCreator
{
    public partial class CreatorPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowContantDiv.InnerHtml = "";
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;
            if (GetUserInfoCookie == null)
            {
                //MPB.InnerText = "Explore";
                //MPB.Attributes["href"] = "Library.aspx";
                Response.Redirect("~/AccountETC/LoginETC.aspx");
            }
            else
            {
                if (GetUserInfoCookie["CreatorName"] == null || GetUserInfoCookie["CreatorName"] == string.Empty) { Response.Redirect("~/404.aspx"); }
                else
                {
                    int UserID = Convert.ToInt32(GetUserInfoCookie["ID"].ToString());
                    string CreatorName = GetUserInfoCookie["CreatorName"];
                    if (IsPostBack == false)
                    {
                        string currEmail = string.Empty;
                        string CurrPFP = string.Empty;
                        //string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;
                        using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
                        {
                            MySqlCon.Open();
                            string query = "SELECT PFP FROM SuMUsersAccounts WHERE UserID = @UID";
                            MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
                            MySqlCmd.Parameters.AddWithValue("@UID", SqlDbType.Int);
                            MySqlCmd.Parameters["@UID"].Value = UserID;
                            using (MySqlDataReader dr = MySqlCmd.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    CurrPFP = dr[0].ToString();
                                }
                            }
                            string query4 = "SELECT Email FROM SuMUsersAccounts WHERE UserID = @UID";
                            MySqlCmd = new MySqlCommand(query4, MySqlCon);
                            MySqlCmd.Parameters.AddWithValue("@UID", SqlDbType.Int);
                            MySqlCmd.Parameters["@UID"].Value = UserID;
                            using (MySqlDataReader dr = MySqlCmd.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    currEmail = dr[0].ToString();
                                }
                            }
                            MySqlCon.Close();
                        }
                        CreatorNameElm.InnerText = CreatorName;
                        CreatorEmailElm.InnerText = currEmail;
                        PFPElm.Attributes["src"] = CurrPFP;
                    }
                    //LoadContantStart
                    string UnderProssListXMLs = string.Empty;//Still Under Pross
                    string NewlyAccepetdLitsXMLs = string.Empty;//New Accpted
                    string NewlyRejectedListXMLs = string.Empty;//New Rejected
                    string MyMangasIDs = string.Empty;//Creator Mangas
                    //string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;
                    using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
                    {
                        MySqlCon.Open();
                        string query = "SELECT NewAcReq FROM SuMCreators WHERE CreatorID = @UID";
                        MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
                        MySqlCmd.Parameters.AddWithValue("@UID", SqlDbType.Int);
                        MySqlCmd.Parameters["@UID"].Value = UserID;
                        using (MySqlDataReader dr = MySqlCmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                NewlyAccepetdLitsXMLs = dr[0].ToString();
                            }
                        }
                        query = "SELECT NewReReq FROM SuMCreators WHERE CreatorID = @UID";
                        MySqlCmd = new MySqlCommand(query, MySqlCon);
                        MySqlCmd.Parameters.AddWithValue("@UID", SqlDbType.Int);
                        MySqlCmd.Parameters["@UID"].Value = UserID;
                        using (MySqlDataReader dr = MySqlCmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                NewlyRejectedListXMLs = dr[0].ToString();
                            }
                        }
                        query = "SELECT UnderProssReq FROM SuMCreators WHERE CreatorID = @UID";
                        MySqlCmd = new MySqlCommand(query, MySqlCon);
                        MySqlCmd.Parameters.AddWithValue("@UID", SqlDbType.Int);
                        MySqlCmd.Parameters["@UID"].Value = UserID;
                        using (MySqlDataReader dr = MySqlCmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                UnderProssListXMLs = dr[0].ToString();
                            }
                        }
                        query = "SELECT MangasIDs FROM SuMCreators WHERE CreatorID = @UID";
                        MySqlCmd = new MySqlCommand(query, MySqlCon);
                        MySqlCmd.Parameters.AddWithValue("@UID", SqlDbType.Int);
                        MySqlCmd.Parameters["@UID"].Value = UserID;
                        using (MySqlDataReader dr = MySqlCmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                MyMangasIDs = dr[0].ToString();
                            }
                        }
                        MySqlCon.Close();
                    }
                    bool SomthingIsShown = false;
                    if (string.IsNullOrEmpty(UnderProssListXMLs) == false) 
                    {
                        SomthingIsShown = true;
                        ProssUnderProssReq(UnderProssListXMLs);
                    }
                    if (string.IsNullOrEmpty(NewlyRejectedListXMLs) == false) 
                    {
                        SomthingIsShown = true;
                        ProssReqjqctedReq(NewlyRejectedListXMLs);
                    }
                    if (string.IsNullOrEmpty(NewlyAccepetdLitsXMLs) == false)
                    {
                        SomthingIsShown = true;
                        ProssAcceptedReq(NewlyAccepetdLitsXMLs);
                    }
                    if (string.IsNullOrEmpty(MyMangasIDs) == false) 
                    {
                        SomthingIsShown = true;
                        ProssMyMangas(MyMangasIDs);
                    }
                    if (SomthingIsShown == false) 
                    {
                        ShowContantDiv.InnerHtml = "<p style=width:100%;text-align:center;font-size:118%;color:rgba(255,255,255,0.92);height:fit-content; >Nothing Yet!</p>";
                    }
                }
            }
        }
        protected private void ProssUnderProssReq(string XMLPaths)
        {
            XMLPaths = XMLPaths.Replace("#", "");
            if (!string.IsNullOrEmpty(XMLPaths))
                if (System.Text.RegularExpressions.Regex.Matches(XMLPaths, "&").Count > 1)
                {

                    string[] XMLPathX = XMLPaths.Split('&');
                    string MangaName = string.Empty;
                    string MangaPicRelativRoot = string.Empty;
                    string MangaThemeColor = string.Empty;
                    string MangaPuplisherName = string.Empty;
                    string PathDeteced = string.Empty;
                    for (int i = 0; i < XMLPathX.Length - 1; i++)
                    {
                        PathDeteced = "~/SuMCreator/CreatorsDrafts/" + XMLPathX[i];
                        if (File.Exists(Server.MapPath(PathDeteced)))
                        {
                            XDocument doc = XDocument.Load(HttpContext.Current.Server.MapPath(PathDeteced));
                            MangaName = doc.Element("SuMReq").Element("Name").Value.ToString();
                            MangaPicRelativRoot = doc.Element("SuMReq").Element("Pic").Value.ToString();
                            MangaThemeColor = doc.Element("SuMReq").Element("ThemeColor").Value.ToString();
                            MangaPuplisherName = doc.Element("SuMReq").Element("Creator").Value.ToString();
                            ShowContantDiv.InnerHtml += BuildUnderProssCard(MangaName, MangaThemeColor, "", "/SuMCreator/CreatorsDrafts/" + MangaPicRelativRoot, MangaPuplisherName);
                        }
                        else
                        {
                            if (File.Exists(Server.MapPath(PathDeteced.Replace("CreatorsDrafts", "CreatorRej"))))
                            {
                                XDocument docc = XDocument.Load(HttpContext.Current.Server.MapPath(PathDeteced.Replace("CreatorsDrafts", "CreatorRej")));
                                MangaName = docc.Element("SuMReq").Element("Name").Value.ToString();
                                MangaPicRelativRoot = docc.Element("SuMReq").Element("Pic").Value.ToString();
                                MangaThemeColor = docc.Element("SuMReq").Element("ThemeColor").Value.ToString();
                                MangaPuplisherName = docc.Element("SuMReq").Element("Creator").Value.ToString();
                                ShowContantDiv.InnerHtml += BuildRejectedCard(MangaName, MangaThemeColor, "", "/SuMCreator/CreatorRej/" + MangaPicRelativRoot, MangaPuplisherName);
                            }
                            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
                            int UserID = Convert.ToInt32(GetUserInfoCookie["ID"].ToString());
                            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;
                            using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
                            {
                                MySqlCon.Open();
                                string NewReqIDs = string.Empty;

                                string query = "SELECT UnderProssReq FROM SuMCreators WHERE CreatorID = @UID";
                                MySqlCommand MySqlCmd2 = new MySqlCommand(query, MySqlCon);
                                MySqlCmd2.Parameters.AddWithValue("@UID", SqlDbType.Int);
                                MySqlCmd2.Parameters["@UID"].Value = UserID;
                                using (var reader = MySqlCmd2.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        NewReqIDs = reader[0].ToString().Replace("#" + XMLPathX[i] + "&", "");
                                    }
                                }
                                query = "UPDATE SuMCreators SET UnderProssReq = @NewUnderProssReq WHERE CreatorID = @UID";
                                MySqlCmd2 = new MySqlCommand(query, MySqlCon);
                                MySqlCmd2.Parameters.AddWithValue("@UID", SqlDbType.Int);
                                MySqlCmd2.Parameters["@UID"].Value = UserID;
                                MySqlCmd2.Parameters.AddWithValue("@NewUnderProssReq", NewReqIDs);
                                MySqlCmd2.ExecuteNonQuery();
                            }
                            //Deleting XML
                            XDocument doc = null;
                            PathDeteced = PathDeteced.Replace("CreatorsDrafts", "CreatorRej");
                            if (File.Exists(Server.MapPath(PathDeteced)))
                            {
                                doc = XDocument.Load(HttpContext.Current.Server.MapPath(PathDeteced));
                                File.Delete(Server.MapPath(PathDeteced));
                            }
                            //Deleting Pic
                            if (doc != null)
                            {
                                PathDeteced = "~/SuMCreator/CreatorRej/" + doc.Element("SuMReq").Element("Pic").Value.ToString();
                                if (File.Exists(Server.MapPath(PathDeteced)))
                                    File.Delete(Server.MapPath(PathDeteced));
                            }
                        }
                    }
                }
                else
                {
                    string MangaName = string.Empty;
                    string MangaPicRelativRoot = string.Empty;
                    string MangaThemeColor = string.Empty;
                    string MangaGerns = string.Empty;
                    string MangaPuplisherName = string.Empty;
                    string PathDeteced = "~/SuMCreator/CreatorsDrafts/" + XMLPaths.Replace("&", "");
                    if (File.Exists(Server.MapPath(PathDeteced)))
                    {
                        XDocument doc = XDocument.Load(HttpContext.Current.Server.MapPath(PathDeteced));
                        MangaName = doc.Element("SuMReq").Element("Name").Value.ToString();
                        MangaPicRelativRoot = doc.Element("SuMReq").Element("Pic").Value.ToString();
                        MangaThemeColor = doc.Element("SuMReq").Element("ThemeColor").Value.ToString();
                        MangaPuplisherName = doc.Element("SuMReq").Element("Creator").Value.ToString();
                        ShowContantDiv.InnerHtml += BuildUnderProssCard(MangaName, MangaThemeColor, "", "/SuMCreator/CreatorsDrafts/" + MangaPicRelativRoot, MangaPuplisherName);
                    }
                    else
                    {
                        if (File.Exists(Server.MapPath(PathDeteced.Replace("CreatorsDrafts", "CreatorRej"))))
                        {
                            XDocument docc = XDocument.Load(HttpContext.Current.Server.MapPath(PathDeteced.Replace("CreatorsDrafts", "CreatorRej")));
                            MangaName = docc.Element("SuMReq").Element("Name").Value.ToString();
                            MangaPicRelativRoot = docc.Element("SuMReq").Element("Pic").Value.ToString();
                            MangaThemeColor = docc.Element("SuMReq").Element("ThemeColor").Value.ToString();
                            MangaPuplisherName = docc.Element("SuMReq").Element("Creator").Value.ToString();
                            ShowContantDiv.InnerHtml += BuildRejectedCard(MangaName, MangaThemeColor, "", "/SuMCreator/CreatorsDrafts/" + MangaPicRelativRoot, MangaPuplisherName);
                        }
                        HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
                        int UserID = Convert.ToInt32(GetUserInfoCookie["ID"].ToString());
                        string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;
                        using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
                        {
                            MySqlCon.Open();
                            string NewReqIDs = string.Empty;

                            string query = "SELECT UnderProssReq FROM SuMCreators WHERE CreatorID = @UID";
                            MySqlCommand MySqlCmd2 = new MySqlCommand(query, MySqlCon);
                            MySqlCmd2.Parameters.AddWithValue("@UID", SqlDbType.Int);
                            MySqlCmd2.Parameters["@UID"].Value = UserID;
                            using (var reader = MySqlCmd2.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    NewReqIDs = reader[0].ToString().Replace("#" + XMLPaths.Replace("&", "") + "&", "");
                                }
                            }
                            query = "UPDATE SuMCreators SET UnderProssReq = @NewUnderProssReq WHERE CreatorID = @UID";
                            MySqlCmd2 = new MySqlCommand(query, MySqlCon);
                            MySqlCmd2.Parameters.AddWithValue("@UID", SqlDbType.Int);
                            MySqlCmd2.Parameters["@UID"].Value = UserID;
                            MySqlCmd2.Parameters.AddWithValue("@NewUnderProssReq", NewReqIDs);
                            MySqlCmd2.ExecuteNonQuery();
                        }
                        XDocument doc = null;
                        //Deleting XML
                        PathDeteced = PathDeteced.Replace("CreatorsDrafts", "CreatorRej");
                        if (File.Exists(Server.MapPath(PathDeteced)))
                        {
                            doc = XDocument.Load(HttpContext.Current.Server.MapPath(PathDeteced));
                            File.Delete(Server.MapPath(PathDeteced));
                        }
                        if (doc != null)
                        {
                            //Deleting Pic
                            PathDeteced = "~/SuMCreator/CreatorRej/" + doc.Element("SuMReq").Element("Pic").Value.ToString();
                            if (File.Exists(Server.MapPath(PathDeteced)))
                                File.Delete(Server.MapPath(PathDeteced));
                        }
                    }

                }
        }
        protected private void ProssAcceptedReq(string XMLPath) 
        {
        }
        protected private void ProssReqjqctedReq(string XMLPath) 
        {
        }
        protected private void ProssMyMangas(string IDs)
        {
            int[] MyIDs = ST0(IDs);
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;
            using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();

                for (int i = 0; i < MyIDs.Length; i++)
                {
                    string query = "SELECT MangaName FROM SuMManga WHERE MangaID = @MangaID";
                    MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
                    MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    MySqlCmd.Parameters["@MangaID"].Value = MyIDs[i];
                    var g = MySqlCmd.ExecuteScalar();
                    string MangaName = g.ToString();

                    query = "SELECT SuMThemeColor FROM SuMManga WHERE MangaID = @MangaID";
                    MySqlCmd = new MySqlCommand(query, MySqlCon);
                    MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    MySqlCmd.Parameters["@MangaID"].Value = MyIDs[i];
                    g = MySqlCmd.ExecuteScalar();
                    string MangaTheme = g.ToString();

                    query = "SELECT CExplorerLink FROM SuMManga WHERE MangaID = @MangaID";
                    MySqlCmd = new MySqlCommand(query, MySqlCon);
                    MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    MySqlCmd.Parameters["@MangaID"].Value = MyIDs[i];
                    g = MySqlCmd.ExecuteScalar();
                    string ExplorerLink = g.ToString();
                    query = "SELECT ChaptersNumber FROM SuMManga WHERE MangaID = @MangaID";
                    MySqlCmd = new MySqlCommand(query, MySqlCon);
                    MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    MySqlCmd.Parameters["@MangaID"].Value = MyIDs[i];
                    var un = MySqlCmd.ExecuteScalar();
                    int ChaptersNum = Convert.ToInt32(un);
                    ExplorerLink += "&CN=" + ChaptersNum.ToString() + "&VC=" + MyIDs[i].ToString() + "&TC=" + MangaTheme;

                    query = "SELECT MangaCoverLink FROM SuMManga WHERE MangaID = @MangaID";
                    MySqlCmd = new MySqlCommand(query, MySqlCon);
                    MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    MySqlCmd.Parameters["@MangaID"].Value = MyIDs[i];
                    g = MySqlCmd.ExecuteScalar();
                    string CoverLink = g.ToString();

                    query = "SELECT ChaptersNumber FROM SuMManga WHERE MangaID = @MangaID";
                    MySqlCmd = new MySqlCommand(query, MySqlCon);
                    MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    MySqlCmd.Parameters["@MangaID"].Value = MyIDs[i];
                    g = MySqlCmd.ExecuteScalar();
                    string chaptersnum = g.ToString();

                    query = "SELECT MangaCreator FROM SuMManga WHERE MangaID = @MangaID";
                    MySqlCmd = new MySqlCommand(query, MySqlCon);
                    MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    MySqlCmd.Parameters["@MangaID"].Value = MyIDs[i];
                    g = MySqlCmd.ExecuteScalar();
                    string CreatorName = g.ToString();


                    ShowContantDiv.InnerHtml += BuildMyMangasCard(MangaName, MangaTheme, ExplorerLink, chaptersnum, CoverLink, CreatorName,MyIDs[i]);
                }
                MySqlCon.Close();
            }
        }
        protected private string BuildMyMangasCard(string MangaName, string MangaTheme, string ExplorerLink, string chapter, string CoverLink, string MangaCreator,int MangaID)
        {
            char sc = '"'; string scfu = sc.ToString();
            string divST = "<div style=" + "overflow:clip;width:fit-content;height:fit-content;" + ">";
            string PDivST = "<div style=" + "margin-top:52px;display:block;width:fit-content;padding-left:8px;" + ">";
            string astyle = scfu + "width:calc(100% - 12px);height:100px;position:relative;margin-left:0px;display:block;overflow:hidden;" + scfu;
            string imgstyle = scfu + "height:84px;width:84px;object-fit:cover;display:inline;border-radius:12px;float:left;margin:8px;" + scfu;
            string h4style = scfu + "color:" + MangaTheme + ";margin-top:-42px;float:left;margin-left:6px;margin-top:12px;width:calc(100% - 120px);" + scfu;
            string AuthString = "<p style=" + "color:var(--SuMDBlackOP50);float:left;margin-top:-10px;margin-left:6px;" + ">By <b style=" + "font-size:80%;" + ">" + MangaCreator + "</b></p>";
            string RS = "<div style=" + '"' + "position: relative;width:100%;background-color:rgba(255,255,255,0.96);border-radius:18px;height:fit-content;padding:8px;margin:0 auto;margin-bottom:12px;" + '"' + " class=shadow-sm > " + divST + " <a onclick=" + sc.ToString() + "androidAPIs.SuMCreatorAddAChapter(" + MangaID.ToString() + ");" + sc.ToString() + " style=" + astyle + " ><img src=" + CoverLink + " class=" + sc.ToString() + "animated pulse" + sc.ToString() + " style=" + imgstyle + "><h4 style=" + h4style + ">" + MangaName + "</h4>" + AuthString + "<br style=" + "float:left;" + ">" + PDivST + "<p style=" + "color:rgba(0,0,0,0);font-size:84%;" + ">" + chapter + " Chapters</p></div></a></div>" + "</div>"; // + hr;
            return RS;
        }
        protected private string BuildUnderProssCard(string MangaName, string MangaTheme, string ExplorerLink, string CoverLink, string MangaCreator)
        {
            char sc = '"'; string scfu = sc.ToString();
            string divST = "<div style=" + "overflow:clip;width:fit-content;height:fit-content;" + ">";
            string PDivST = "<div style=" + "margin-top:52px;display:block;width:fit-content;padding-left:8px;" + ">";
            string astyle = scfu + "width:calc(100% - 12px);height:100px;position:relative;margin-left:0px;display:block;overflow:hidden;" + scfu;
            string imgstyle = scfu + "height:84px;width:84px;object-fit:cover;display:inline;border-radius:12px;float:left;margin:8px;" + scfu;
            string h4style = scfu + "color:" + MangaTheme + ";margin-top:-42px;float:left;margin-left:6px;margin-top:12px;width:calc(100% - 120px);" + scfu;
            string AuthString = "<p style=" + "color:var(--SuMDBlackOP50);float:left;margin-top:-10px;margin-left:6px;" + ">By <b style=" + "font-size:80%;" + ">" + MangaCreator + "</b></p>";
            string RS = "<div style=" + '"' + "opacity:0.74;position: relative;width:100%;background-color:rgba(255,255,255,0.96);border-radius:18px;height:fit-content;padding:8px;margin:0 auto;margin-bottom:12px;" + '"' + " class=shadow-sm > " + divST + " <a onclick=" + scfu + "androidAPIs.ShowSuMToastsOverview('" + MangaName.Replace("'", "") + " is still under process!');androidAPIs.VIBRATEPhone();" + scfu + " style=" + astyle + " ><img src=" + CoverLink + " class=" + sc.ToString() + "animated pulse" + sc.ToString() + " style=" + imgstyle + "><h4 style=" + h4style + ">" + MangaName + "</h4>" + AuthString + "<br style=" + "float:left;" + ">" + PDivST + "<p style=color:#6b6b6b;font-size:74%;>processing</p></div></a></div>" + "</div>"; // + hr;
            return RS;
        }
        protected private string BuildRejectedCard(string MangaName, string MangaTheme, string ExplorerLink, string CoverLink, string MangaCreator)
        {
            char sc = '"'; string scfu = sc.ToString();
            string divST = "<div style=" + "overflow:clip;width:fit-content;height:fit-content;" + ">";
            string PDivST = "<div style=" + "margin-top:52px;display:block;width:fit-content;padding-left:8px;" + ">";
            string astyle = scfu + "width:calc(100% - 12px);height:100px;position:relative;margin-left:0px;display:block;overflow:hidden;" + scfu;
            string imgstyle = scfu + "height:84px;width:84px;object-fit:cover;display:inline;border-radius:12px;float:left;margin:8px;" + scfu;
            string h4style = scfu + "color:" + MangaTheme + ";margin-top:-42px;float:left;margin-left:6px;margin-top:12px;width:calc(100% - 120px);" + scfu;
            string AuthString = "<p style=" + "color:var(--SuMDBlackOP50);float:left;margin-top:-10px;margin-left:6px;" + ">By <b style=" + "font-size:80%;" + ">" + MangaCreator + "</b></p>";
            string RS = "<div style=" + '"' + "opacity:0.86;position: relative;width:100%;background-color:rgba(255,255,255,0.96);border-radius:18px;height:fit-content;padding:8px;margin:0 auto;margin-bottom:12px;" + '"' + " class=shadow-sm > " + divST + " <a onclick="+scfu+ "androidAPIs.ShowSuMToastsOverview('"+MangaName.Replace("'","")+ " was rejected!');androidAPIs.VIBRATEPhone();" + scfu+" style=" + astyle + " ><img src=" + "/SuMCreator/CreatorRej" + CoverLink + " class=" + sc.ToString() + "animated pulse" + sc.ToString() + " style=" + imgstyle + "><h4 style=" + h4style + ">" + MangaName + "</h4>" + AuthString + "<br style=" + "float:left;" + ">" + PDivST + "<p style=color:#6b6b6b;font-size:74%;>Rejected!</p></div></a></div>" + "</div>"; // + hr;
            return RS;
        }
        protected private void ReadSUMXMLProfile()
        {
            // Load the document.
            string SUMProfileFileName = "";
            XDocument doc = XDocument.Load(SUMProfileFileName);
            string MangaName = doc.Element("Name").ToString();
            string MangaPicRelativRoot = doc.Element("Pic").ToString();
            string MangaThemeColor = doc.Element("ThemeColor").ToString();
            string MangaDiscription = doc.Element("Description").ToString();
            string MangaGerns = doc.Element("Genres").ToString();//-PreGerns -PosibleCreationOfNewOne
            string MangaPuplisherName = doc.Element("Creator").ToString();
            string MangaAgeID = doc.Element("AgeID").ToString();
            string UserReqID = doc.Element("ReqID").ToString();
            //UseIt
        }
        protected private int[] ST0(string x)
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
    }
}