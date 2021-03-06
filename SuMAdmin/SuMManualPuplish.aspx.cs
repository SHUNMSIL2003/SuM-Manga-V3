using System;
using System.Collections.Generic;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace SuM_Manga_V3.SuMAdmin
{
    public partial class SuMManualPuplish : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["PuplishProfile"] != null) 
                if (Request.QueryString["PuplishProfile"].ToString().Contains(".sum.chapter"))
                    Response.Redirect("~/SuMAdmin/SuMManualChapterPuplish.aspx?PuplishProfile="+Request.QueryString["PuplishProfile"]);
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMAdmin"];
            if (GetUserInfoCookie != null)
            {
                string DGAID = "DEBUGINGKEY";//(place holder) a key will be givn to workers evryday (shared key)
                if (GetUserInfoCookie["AID256"] != sha256(DGAID))
                    Response.Redirect("~/404.aspx?aspxerrorpath=ACCESS_DENIED");
            }
            else Response.Redirect("~/SuMAdmin/AdminLogin.aspx");

            if (Request.QueryString["PuplishProfile"] != null)
            {
                string PathDeteced = "~/SuMCreator/CreatorsDrafts/" + Request.QueryString["PuplishProfile"];
                if (!File.Exists(Server.MapPath(PathDeteced))) Response.Redirect("~/SuMAdmin/AcceptSuMUploads.aspx");
                XDocument doc = XDocument.Load(HttpContext.Current.Server.MapPath(PathDeteced));
                string MangaPuplisherName = doc.Element("SuMReq").Element("Creator").Value.ToString();
                string MangaName = doc.Element("SuMReq").Element("Name").Value.ToString();
                string MangaPicRelativRoot = doc.Element("SuMReq").Element("Pic").Value.ToString();
                string MangaThemeColor = doc.Element("SuMReq").Element("ThemeColor").Value.ToString();
                string MangaDiscription = doc.Element("SuMReq").Element("Description").Value.ToString();
                string MangaGerns = doc.Element("SuMReq").Element("Genres").Value.ToString();
                string MangaAgeID = doc.Element("SuMReq").Element("AgeID").Value.ToString();
                string UserReqID = doc.Element("SuMReq").Element("ReqID").Value.ToString();
                //string PuplisherID = doc.Element("SuMReq").Element("CreatorID").Value.ToString();

                REQIDELM.InnerText = "REQ:" + UserReqID;
                SuMThemeBox.Attributes["style"] = "background:" + MangaThemeColor + ";padding:12px;";
                SuMCreatorPuplishNameTXT.Text = MangaPuplisherName;
                MangaNamePELM.InnerText = MangaName;
                MangaDiscPELM.InnerText = MangaDiscription;
                MangaGernsPELM.InnerText = MangaGerns;
                MangaAgeRatingPELM.InnerText = MangaAgeID;
                MangaCoverELM.Attributes["src"] = "/SuMCreator/CreatorsDrafts/" + MangaPicRelativRoot;


            }
            else Response.Redirect("~/SuMAdmin/AcceptSuMUploads.aspx");
        }
        protected void RejectStart(object sender, EventArgs e)
        {
            XDocument doc = null;
            //Moving XML
            string PathDeteced = "~/SuMCreator/CreatorsDrafts/" + Request.QueryString["PuplishProfile"];
            if (File.Exists(Server.MapPath(PathDeteced)))
            {
                doc = XDocument.Load(HttpContext.Current.Server.MapPath(PathDeteced));
                File.Move(Server.MapPath(PathDeteced), Server.MapPath(PathDeteced.Replace("CreatorsDrafts", "CreatorRej")));
            }
            if (doc != null)
            {
                //Moving Pic
                PathDeteced = "~/SuMCreator/CreatorsDrafts/" + doc.Element("SuMReq").Element("Pic").Value.ToString();
                if (File.Exists(Server.MapPath(PathDeteced)))
                    File.Move(Server.MapPath(PathDeteced), Server.MapPath(PathDeteced.Replace("CreatorsDrafts", "CreatorRej")));
            }
            Response.Redirect("~/SuMAdmin/AcceptSuMUploads.aspx");
        }
        private static string sha256(string randomString)
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
        protected void PuplishStart(object sender, EventArgs e)
        {
            if (Request.QueryString["PuplishProfile"] != null)
            {
                string ReqProfileFile = Request.QueryString["PuplishProfile"].ToString();
                string MangaName = string.Empty;
                string MangaPicRelativRoot = string.Empty;
                string MangaThemeColor = string.Empty;
                string MangaDiscription = string.Empty;
                string MangaGerns = string.Empty;
                string MangaPuplisherName = string.Empty;
                string MangaAgeID = string.Empty;
                string UserReqID = string.Empty;
                string PathDeteced = string.Empty;
                string PuplisherID = string.Empty;
                PathDeteced = "~/SuMCreator/CreatorsDrafts/" + ReqProfileFile;
                if (!File.Exists(Server.MapPath(PathDeteced))) Response.Redirect("~/SuMAdmin/AcceptSuMUploads.aspx");
                XDocument doc = XDocument.Load(HttpContext.Current.Server.MapPath(PathDeteced));
                MangaName = doc.Element("SuMReq").Element("Name").Value.ToString();
                MangaPicRelativRoot = doc.Element("SuMReq").Element("Pic").Value.ToString();
                MangaThemeColor = doc.Element("SuMReq").Element("ThemeColor").Value.ToString();
                MangaDiscription = doc.Element("SuMReq").Element("Description").Value.ToString();
                MangaGerns = doc.Element("SuMReq").Element("Genres").Value.ToString();
                MangaPuplisherName = doc.Element("SuMReq").Element("Creator").Value.ToString();
                MangaAgeID = doc.Element("SuMReq").Element("AgeID").Value.ToString();
                UserReqID = doc.Element("SuMReq").Element("ReqID").Value.ToString();
                PuplisherID = doc.Element("SuMReq").Element("CreatorID").Value.ToString();
                object SuMCreatorPuplishNameTXT_OBJ = SuMCreatorPuplishNameTXT.Text.ToString();
                if (SuMCreatorPuplishNameTXT_OBJ!= null)
                    if(SuMCreatorPuplishNameTXT_OBJ.ToString()!= MangaPuplisherName)
                        MangaPuplisherName = SuMCreatorPuplishNameTXT.Text.ToString();
                int CurrLastUpdateDate = Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd"));
                //Puplish Code Start
                string MangaRoot = MangaName.Replace(" ", "-") + "-" + MangaPuplisherName.Replace(" ", "-") + PuplisherID.ToString().Replace(" ", "") + CurrLastUpdateDate.ToString().Replace(" ", "");
                string CExplorerLink = "/storeitems/ContantExplorer.aspx?Manga=" + MangaRoot;
                string MangaCoverLink = "/storeitems/" + MangaRoot + "/" + MangaName.Replace(" ", "-") + ".png";
                int MangaID = 0;
                string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
                {
                    MySqlCon.Open();
                    MySqlCommand MySqlCmd = new MySqlCommand("INSERT INTO SuMManga(MangaName,CExplorerLink,MangaInfo,SuMThemeColor,MangaCoverLink,ChaptersNumber,MangaViews,MangaCreator,MangaAgeRating,LastUpdateDate) values(@MangaName,@CExplorerLink,@MangaInfo,@SuMThemeColor,@MangaCoverLink,0,0,@MangaCreator,@MangaAgeRating,@LastUpdateDate)", MySqlCon);
                    MySqlCmd.Parameters.AddWithValue("@MangaName", MangaName);
                    MySqlCmd.Parameters.AddWithValue("@CExplorerLink", CExplorerLink);//C
                    MySqlCmd.Parameters.AddWithValue("@MangaInfo", MangaDiscription);
                    MySqlCmd.Parameters.AddWithValue("@SuMThemeColor", MangaThemeColor);
                    MySqlCmd.Parameters.AddWithValue("@MangaCoverLink", MangaCoverLink);
                    MySqlCmd.Parameters.AddWithValue("@MangaCreator", MangaPuplisherName);
                    MySqlCmd.Parameters.AddWithValue("@MangaAgeRating", MangaAgeID);
                    MySqlCmd.Parameters.AddWithValue("@LastUpdateDate", SqlDbType.Int);
                    MySqlCmd.Parameters["@LastUpdateDate"].Value = CurrLastUpdateDate;
                    MySqlCmd.ExecuteNonQuery();
                    System.Threading.Thread.Sleep(180);
                    MySqlCmd = new MySqlCommand("SELECT MangaID FROM SuMManga WHERE MangaName = @MangaName AND LastUpdateDate = @LastUpdateDate", MySqlCon);
                    MySqlCmd.Parameters.AddWithValue("@MangaName", MangaName);
                    MySqlCmd.Parameters.AddWithValue("@LastUpdateDate", SqlDbType.Int);
                    MySqlCmd.Parameters["@LastUpdateDate"].Value = CurrLastUpdateDate;
                    object RS = MySqlCmd.ExecuteScalar();
                    if (RS != null)
                    {
                        MangaID = Convert.ToInt32(RS.ToString());
                    }
                    else 
                    {
                        System.Threading.Thread.Sleep(640);
                        MySqlCmd = new MySqlCommand("SELECT MangaID FROM SuMManga WHERE MangaName = @MangaName AND LastUpdateDate = @LastUpdateDate", MySqlCon);
                        MySqlCmd.Parameters.AddWithValue("@MangaName", MangaName);
                        MySqlCmd.Parameters.AddWithValue("@LastUpdateDate", SqlDbType.Int);
                        MySqlCmd.Parameters["@LastUpdateDate"].Value = CurrLastUpdateDate;
                        RS = MySqlCmd.ExecuteScalar();
                        if (RS != null)
                        {
                            MangaID = Convert.ToInt32(RS.ToString());
                        }
                        else
                        {
                            System.Threading.Thread.Sleep(1000);
                            MySqlCmd = new MySqlCommand("SELECT MangaID FROM SuMManga WHERE MangaName = @MangaName AND LastUpdateDate = @LastUpdateDate", MySqlCon);
                            MySqlCmd.Parameters.AddWithValue("@MangaName", MangaName);
                            MySqlCmd.Parameters.AddWithValue("@LastUpdateDate", SqlDbType.Int);
                            MySqlCmd.Parameters["@LastUpdateDate"].Value = CurrLastUpdateDate;
                            RS = MySqlCmd.ExecuteScalar();
                            if (RS != null)
                            {
                                MangaID = Convert.ToInt32(RS.ToString());
                            }
                            else
                            {
                                System.Threading.Thread.Sleep(2000);
                                MySqlCmd = new MySqlCommand("SELECT MangaID FROM SuMManga WHERE MangaName = @MangaName AND LastUpdateDate = @LastUpdateDate", MySqlCon);
                                MySqlCmd.Parameters.AddWithValue("@MangaName", MangaName);
                                MySqlCmd.Parameters.AddWithValue("@LastUpdateDate", SqlDbType.Int);
                                MySqlCmd.Parameters["@LastUpdateDate"].Value = CurrLastUpdateDate;
                                RS = MySqlCmd.ExecuteScalar();
                                if (RS != null)
                                {
                                    MangaID = Convert.ToInt32(RS.ToString());
                                }
                                else
                                {
                                    System.Threading.Thread.Sleep(6000);
                                    MySqlCmd = new MySqlCommand("SELECT MangaID FROM SuMManga WHERE MangaName = @MangaName AND LastUpdateDate = @LastUpdateDate", MySqlCon);
                                    MySqlCmd.Parameters.AddWithValue("@MangaName", MangaName);
                                    MySqlCmd.Parameters.AddWithValue("@LastUpdateDate", SqlDbType.Int);
                                    MySqlCmd.Parameters["@LastUpdateDate"].Value = CurrLastUpdateDate;
                                    RS = MySqlCmd.ExecuteScalar();
                                }
                            }
                        }
                    }
                    MySqlCon.Close();
                }
                string epath = System.IO.Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
                string ActivePath = epath + "\\SuMCreator\\CreatorsDrafts\\";
                string NewPath = epath + "\\storeitems\\" + MangaRoot + "\\" + MangaName.Replace(" ", "-") + ".png";
                string NewRoot = epath + "\\storeitems\\" + MangaRoot + "\\";
                Directory.CreateDirectory(NewRoot);
                File.Move(ActivePath+ MangaPicRelativRoot, NewPath);
                File.Delete(ActivePath + ReqProfileFile);
                PuplishGerns(MangaID, ST0String(MangaGerns));
                //CreateComentsSpace(MangaID);
                ProssEnding(Convert.ToInt32(PuplisherID), ReqProfileFile, MangaID);
            }
        }
        protected void PuplishGerns(int MID, string[] MGs) 
        {
            //string GernX = string.Empty;
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                MySqlCommand MySqlCmd = new MySqlCommand("", MySqlCon);
                for (int i = 0; i < MGs.Length; i++)
                {
                    MySqlCmd = new MySqlCommand("UPDATE SuMManga SET " + MGs[i] + " = @GernX WHERE MangaID = @MID", MySqlCon);
                    MySqlCmd.Parameters.AddWithValue("@GernX", SqlDbType.Bit);
                    MySqlCmd.Parameters["@GernX"].Value = 1;
                    MySqlCmd.Parameters.AddWithValue("@MID", SqlDbType.Int);
                    MySqlCmd.Parameters["@MID"].Value = MID;
                    MySqlCmd.ExecuteNonQuery();
                }
                MySqlCon.Close();
            }
        }
        protected void CreateComentsSpace(int MID) 
        {
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                MySqlCommand MySqlCmd = new MySqlCommand("INSERT INTO SuMMangaComments(MangaID,CreatorComment) values(@MID,@CreatorComment)", MySqlCon);
                MySqlCmd.Parameters.AddWithValue("@CreatorComment", " ");
                MySqlCmd.Parameters.AddWithValue("@MID", SqlDbType.Int);
                MySqlCmd.Parameters["@MID"].Value = MID;
                MySqlCmd.ExecuteNonQuery();
                MySqlCon.Close();
            }
        }
        protected void ProssEnding(int UserID, string ReqFID, int MangaID)
        {
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string NewReqIDs = string.Empty;

                string query = "SELECT UnderProssReq FROM SuMCreators WHERE CreatorID = @UID";
                MySqlCommand MySqlCmd2 = new MySqlCommand(query, MySqlCon);
                MySqlCmd2.Parameters.AddWithValue("@UID", SqlDbType.Int);
                MySqlCmd2.Parameters["@UID"].Value = UserID;
                //var RR = MySqlCmd2.ExecuteReader();
                using (var reader = MySqlCmd2.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        NewReqIDs = reader[0].ToString().Replace("#" + ReqFID + "&", "");
                    }
                }
                query = "UPDATE SuMCreators SET UnderProssReq = @NewUnderProssReq WHERE CreatorID = @UID";
                MySqlCmd2 = new MySqlCommand(query, MySqlCon);
                MySqlCmd2.Parameters.AddWithValue("@UID", SqlDbType.Int);
                MySqlCmd2.Parameters["@UID"].Value = UserID;
                MySqlCmd2.Parameters.AddWithValue("@NewUnderProssReq", NewReqIDs);
                MySqlCmd2.ExecuteNonQuery();

                query = "SELECT MangasIDs FROM SuMCreators WHERE CreatorID = @UID";
                MySqlCmd2 = new MySqlCommand(query, MySqlCon);
                MySqlCmd2.Parameters.AddWithValue("@UID", SqlDbType.Int);
                MySqlCmd2.Parameters["@UID"].Value = UserID;
                //var RR = MySqlCmd2.ExecuteReader();
                using (var reader = MySqlCmd2.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        NewReqIDs = "#" + MangaID + "&" + reader[0].ToString();
                    }
                }
                query = "UPDATE SuMCreators SET MangasIDs = @MangasIDs WHERE CreatorID = @UID";
                MySqlCmd2 = new MySqlCommand(query, MySqlCon);
                MySqlCmd2.Parameters.AddWithValue("@UID", SqlDbType.Int);
                MySqlCmd2.Parameters["@UID"].Value = UserID;
                MySqlCmd2.Parameters.AddWithValue("@MangasIDs", NewReqIDs);
                MySqlCmd2.ExecuteNonQuery();

                MySqlCon.Close();
            }
        }
        protected string[] ST0String(string x)
        {
            Queue<string> R1 = new Queue<string>();
            bool fh = false;
            string A1 = "";
            char[] aa = x.ToCharArray();
            for (int i = 0; i < aa.Length; i++)
            {
                if (aa[i] == '&')
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
    }
}