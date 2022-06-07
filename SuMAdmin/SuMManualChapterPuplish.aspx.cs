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
    public partial class SuMManualChapterPuplish : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
                ChapterPagesC.InnerHtml = "";
                string PathDeteced = "~/SuMCreator/CreatorsDrafts/" + Request.QueryString["PuplishProfile"];
                if (!File.Exists(Server.MapPath(PathDeteced))) Response.Redirect("~/SuMAdmin/AcceptSuMUploads.aspx");
                XDocument doc = XDocument.Load(HttpContext.Current.Server.MapPath(PathDeteced));
                string MangaPicRelativRoot = doc.Element("SuMReq").Element("Pic").Value.ToString();
                int MangaID = Convert.ToInt32(doc.Element("SuMReq").Element("MangaID").Value.ToString());
                int CreatorID = Convert.ToInt32(doc.Element("SuMReq").Element("CreatorID").Value.ToString());
                string UserReqID = doc.Element("SuMReq").Element("ReqID").Value.ToString();
                string PIC = doc.Element("SuMReq").Element("Pic").Value.ToString();

                REQIDELM.InnerText = "REQ:" + UserReqID;
                string AgeKey = GetAgeID(MangaID);
                if(AgeKey=="NULL") Response.Redirect("~/404.aspx?aspxerrorpath=INVALID_MID");
                MangaAgeRatingPELM.InnerText = AgeKey;
                MangaCoverELM.Attributes["src"] = "/SuMCreator/CreatorsDrafts/" + MangaPicRelativRoot;
                if (Directory.Exists(Server.MapPath("/SuMCreator/CreatorsDrafts/"+ Request.QueryString["PuplishProfile"].ToString().Replace(".xml",""))))
                {
                    string[] filePaths = Directory.GetFiles(Server.MapPath("/SuMCreator/CreatorsDrafts/" + Request.QueryString["PuplishProfile"].ToString().Replace(".xml", "")), "*.jpg");
                    for (int i = 0; i < filePaths.Length; i++)
                    {
                        string filename = Path.GetFileName(filePaths[i]);
                        ChapterPagesC.InnerHtml += "<img  style=" + '"'+ "width:calc(100% - 24px);max-width:420px !important;margin:0 auto;height:auto;" + '"' + " src=" + '"' + "/SuMCreator/CreatorsDrafts/" + Request.QueryString["PuplishProfile"].ToString().Replace(".xml", "") + "/" + filename + '"' + " />";
                    }
                }
            }
            else Response.Redirect("~/SuMAdmin/AcceptSuMUploads.aspx");
        }
        protected private string GetAgeID(int MID)
        {
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;
            using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string qwi = "SELECT MangaAgeRating FROM SuMManga WHERE MangaID = @MangaID";
                MySqlCommand MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                MySqlCmd00.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                MySqlCmd00.Parameters["@MangaID"].Value = MID;
                object RawRes = MySqlCmd00.ExecuteScalar();
                if (RawRes != null)
                {
                    string Res = RawRes.ToString();
                    return Res;
                }
                else return "NULL";
            }
        }
        protected void RejectStart(object sender, EventArgs e)
        {
            XDocument doc = null;
            //Moving XML
            string PathDeteced = "~/SuMCreator/CreatorsDrafts/" + Request.QueryString["PuplishProfile"];
            if (File.Exists(Server.MapPath(PathDeteced)))
            {
                doc = XDocument.Load(HttpContext.Current.Server.MapPath(PathDeteced));
                File.Delete(Server.MapPath(PathDeteced));
            }
            //Moving Pic
            PathDeteced = "~/SuMCreator/CreatorsDrafts/" + Request.QueryString["PuplishProfile"].ToString().Replace(".xml", ".png");
            if (File.Exists(Server.MapPath(PathDeteced)))
                File.Delete(Server.MapPath(PathDeteced));

            if (Directory.Exists(Server.MapPath("/SuMCreator/CreatorsDrafts/" + Request.QueryString["PuplishProfile"].ToString().Replace(".xml", ""))))
                Directory.Delete(Server.MapPath("/SuMCreator/CreatorsDrafts/" + Request.QueryString["PuplishProfile"].ToString().Replace(".xml", "")), true);

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
                string PathDeteced = string.Empty;
                PathDeteced = "~/SuMCreator/CreatorsDrafts/" + ReqProfileFile;
                if (!File.Exists(Server.MapPath(PathDeteced))) Response.Redirect("~/SuMAdmin/AcceptSuMUploads.aspx");
                XDocument doc = XDocument.Load(HttpContext.Current.Server.MapPath(PathDeteced));
                string MangaPicRelativRoot = doc.Element("SuMReq").Element("Pic").Value.ToString();
                int MangaID = Convert.ToInt32(doc.Element("SuMReq").Element("MangaID").Value.ToString());
                int CreatorID = Convert.ToInt32(doc.Element("SuMReq").Element("CreatorID").Value.ToString());
                string UserReqID = doc.Element("SuMReq").Element("ReqID").Value.ToString();
                string PIC = doc.Element("SuMReq").Element("Pic").Value.ToString();
                int ChapterNumber = Convert.ToInt32(doc.Element("SuMReq").Element("CN").Value.ToString());
                int CurrLastUpdateDate = Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd"));
                //Puplish Code Start
                string MangaROOTDir = string.Empty;
                string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
                {
                    MySqlCon.Open();
                    string query = "UPDATE SuMManga SET ChaptersNumber = ChaptersNumber + 1 WHERE MangaID = " + MangaID.ToString();
                    MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
                    MySqlCmd = new MySqlCommand(query, MySqlCon);
                    //MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    //MySqlCmd.Parameters["@MangaID"].Value = MangaID;
                    MySqlCmd.ExecuteNonQuery();
                    query = "SELECT CExplorerLink FROM SuMManga WHERE MangaID = " + MangaID.ToString();
                    MySqlCmd = new MySqlCommand(query, MySqlCon);
                    //MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    //MySqlCmd.Parameters["@MangaID"].Value = MangaID;
                    using (MySqlDataReader dr = MySqlCmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            MangaROOTDir = dr[0].ToString().Split('=')[1].ToString();
                        }
                    }
                    MySqlCon.Close();
                }
                //ChapterNumber;
                string fixercn = "000";
                if (ChapterNumber > 9) fixercn = "00";
                if (ChapterNumber > 99) fixercn = "0";
                if (ChapterNumber > 999) fixercn = "";
                if (ChapterNumber > 9999) Response.Redirect("404.aspx?EM=MAXNUM9999");
                string pathpartx = "~/storeitems/" + MangaROOTDir + "/ch" + fixercn + ChapterNumber + "/";
                CreateIfMissing(pathpartx);
                //Moving XML
                PathDeteced = "~/SuMCreator/CreatorsDrafts/" + Request.QueryString["PuplishProfile"];
                if (File.Exists(Server.MapPath(PathDeteced)))
                {
                    doc = XDocument.Load(HttpContext.Current.Server.MapPath(PathDeteced));
                    File.Delete(Server.MapPath(PathDeteced));
                }
                if (doc != null)
                {
                    //Moving Pic
                    PathDeteced = "~/SuMCreator/CreatorsDrafts/" + doc.Element("SuMReq").Element("Pic").Value.ToString();
                    if (File.Exists(Server.MapPath(PathDeteced)))
                        File.Move(Server.MapPath(PathDeteced), Server.MapPath("~/storeitems/" + MangaROOTDir + "/" + "sumcp" + fixercn + ChapterNumber.ToString() + ".jpg"));
                    //if(Directory.Exists(pathpartx))
                    string[] filePaths = Directory.GetFiles(Server.MapPath("/SuMCreator/CreatorsDrafts/" + Request.QueryString["PuplishProfile"].ToString().Replace(".xml", "")), "*.jpg");
                    for (int i = 0; i < filePaths.Length; i++)
                    {
                        string filename = Path.GetFileName(filePaths[i]);
                        File.Move(Server.MapPath("/SuMCreator/CreatorsDrafts/" + Request.QueryString["PuplishProfile"].ToString().Replace(".xml", "") + "/" + filename), Server.MapPath(pathpartx + filename));
                    }
                }
                //ProssEnding(Convert.ToInt32(PuplisherID), ReqProfileFile, MangaID);
            }
        }
        private void CreateIfMissing(string path)
        {
            bool folderExists = Directory.Exists(Server.MapPath(path));
            if (!folderExists)
                Directory.CreateDirectory(Server.MapPath(path));
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