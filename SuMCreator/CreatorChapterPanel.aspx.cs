using System;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Xml.Linq;
using System.Collections.Generic;

namespace SuM_Manga_V3.SuMCreator
{
    public partial class CreatorChapterPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["MID"]==null) Response.Redirect("~/404.aspx?aspxerrorpath=MISSING_Q_MID");
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            if (GetUserInfoCookie != null)
            {
                if (GetUserInfoCookie["CreatorName"] == null || GetUserInfoCookie["CreatorName"] == string.Empty) { Response.Redirect("~/404.aspx?aspxerrorpath=ACCESS_DENIED"); }
            }
            else { Response.Redirect("~/404.aspx?aspxerrorpath=LOGIN_PLZ"); }
            int MID = Convert.ToInt32(Request.QueryString["MID"].ToString());
            int UID = Convert.ToInt32(GetUserInfoCookie["ID"].ToString());
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;
            object C_MIDs;
            bool OS_C = false;
            string MN_S = string.Empty;
            int CsN = 0;
            using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string query = "SELECT MangasIDs FROM SuMCreators WHERE CreatorID = @CreatorID";
                MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
                MySqlCmd.Parameters.AddWithValue("@CreatorID", SqlDbType.Int);
                MySqlCmd.Parameters["@CreatorID"].Value = UID;
                C_MIDs = MySqlCmd.ExecuteScalar();
                if (C_MIDs != null)
                {
                    if (C_MIDs.ToString().Contains("#" + MID.ToString() + "&")) {
                        OS_C = true;
                    }
                    query = "SELECT MangaName FROM SuMManga WHERE MangaID = @MangaID";
                    MySqlCmd = new MySqlCommand(query, MySqlCon);
                    MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    MySqlCmd.Parameters["@MangaID"].Value = MID;
                    object MN = MySqlCmd.ExecuteScalar();
                    if (MN == null) Response.Redirect("~/404.aspx?aspxerrorpath=INVALID_MID");
                    MN_S = MN.ToString();

                    query = "SELECT ChaptersNumber FROM SuMManga WHERE MangaID = @MangaID";
                    MySqlCmd = new MySqlCommand(query, MySqlCon);
                    MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    MySqlCmd.Parameters["@MangaID"].Value = MID;
                    MN = MySqlCmd.ExecuteScalar();
                    CsN = Convert.ToInt32(MN);
                }
                MySqlCon.Close();
            }
            if (!OS_C) Response.Redirect("~/404.aspx?aspxerrorpath=ACCESS_DENIED");
            sumchapterinfo.InnerText = MN_S + ": Chapter " + (CsN + 1).ToString();

        }
        public void CreateSUMXMLProfile(object sender, EventArgs e)
        {

            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            int UserID = Convert.ToInt32(GetUserInfoCookie["ID"].ToString());
            //InfoFilled
            //FileReqInfo
            string CurrentCreatorID = UserID.ToString();//AKA USERID D
            string CreationDate = DateTime.Now.ToString("yyyyMMddHHmmss");//UTC Form D
            string UserReqID = CurrentCreatorID + RandomID();//-AutoGen -DubliCheck D
            UserReqID = UserReqID.Replace(" ", "");
            string SUMProfileFileName = CreationDate + "-" + CurrentCreatorID + "-" + UserReqID + ".sum.chapter"; //D
            SUMProfileFileName = SUMProfileFileName.Replace(" ", "");
            string MangaPicRelativRoot = SUMProfileFileName + ".jpg";//D
            int ChapterNumber = 0;
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;
            using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string query = "SELECT ChaptersNumber FROM SuMManga WHERE MangaID = @MangaID";
                MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
                MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                MySqlCmd.Parameters["@MangaID"].Value = Convert.ToInt32(Request.QueryString["MID"].ToString());
                ChapterNumber = Convert.ToInt32(MySqlCmd.ExecuteScalar().ToString()) + 1;
                MySqlCon.Close();
            }
            //ReqBuild
            XDocument doc = new XDocument(
                new XDeclaration("1.0", null, "yes"),
                new XComment("Created with the XDocument class, SuM-Manga."),
                new XElement("SuMReq",
                new XElement("MangaID", Request.QueryString["MID"].ToString()),//D
                new XElement("Pic", MangaPicRelativRoot),//D
                new XElement("CreatorID", GetUserInfoCookie["ID"].ToString()),
                new XElement("CN", ChapterNumber),
                new XElement("ReqID", UserReqID)
                )//A
            );
            //ReqSave
            doc.Save(Server.MapPath(Path.Combine("CreatorsDrafts", SUMProfileFileName + ".xml")));
            MangaPicUP.PostedFile.SaveAs(Server.MapPath(Path.Combine("CreatorsDrafts", SUMProfileFileName + ".jpg")));
            CreateIfMissing("~/SuMCreator/CreatorsDrafts/"+ SUMProfileFileName);//path for pics
            for (int i = 0; i < ChaptersUP.PostedFiles.Count; i++)
            {
                /*string CapterFixUp = "0000";
                if ((i + 1) > 9) CapterFixUp = "000";
                if ((i + 1) > 99) CapterFixUp = "00";
                if ((i + 1) > 999) CapterFixUp = "0";*/
                if ((i + 1) > 9999) i = ChaptersUP.PostedFiles.Count;
                //string ext = new FileInfo(ChaptersUP.PostedFiles[i].FileName).Extension;
                ChaptersUP.PostedFiles[i].SaveAs(Server.MapPath(Path.Combine("CreatorsDrafts/"+ SUMProfileFileName, /*CapterFixUp + (i + 1).ToString()*/ChaptersUP.PostedFiles[i].FileName.ToString() + ".jpg")));
            }
            //Save ReqID to CreatorProssDataBase and UserDataBase
            /*string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;
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
                        NewReqIDs = "#" + SUMProfileFileName + ".xml&" + reader[0].ToString();
                    }
                }
                query = "UPDATE SuMCreators SET UnderProssReq = @NewUnderProssReq WHERE CreatorID = @UID";
                MySqlCmd2 = new MySqlCommand(query, MySqlCon);
                MySqlCmd2.Parameters.AddWithValue("@UID", SqlDbType.Int);
                MySqlCmd2.Parameters["@UID"].Value = UserID;
                MySqlCmd2.Parameters.AddWithValue("@NewUnderProssReq", NewReqIDs);
                MySqlCmd2.ExecuteNonQuery();
                MySqlCon.Close();
            }*/
            Response.Redirect("~/SuMCreator/CreatorPanel.aspx");
        }
        protected private string RandomID()
        {
            int length = 9;
            char[] chArray = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            string str = string.Empty;
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                int index = random.Next(1, chArray.Length);
                if (!str.Contains(chArray.GetValue(index).ToString()))
                {
                    str = str + chArray.GetValue(index);
                }
                else
                {
                    i--;
                }
            }
            Random r = new Random();
            int randNum = r.Next(1000000);
            string sixDigitNumber = randNum.ToString("D6");
            str = sixDigitNumber[0] + sixDigitNumber[1] + sixDigitNumber[2] + str + sixDigitNumber[3] + sixDigitNumber[4] + sixDigitNumber[5];
            return str;
        }
        private void CreateIfMissing(string path)
        {
            bool folderExists = Directory.Exists(Server.MapPath(path));
            if (!folderExists)
                Directory.CreateDirectory(Server.MapPath(path));
        }
    }
}