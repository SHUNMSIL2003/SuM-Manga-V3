using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient; using MySql.Data.MySqlClient; using System.Configuration;
using System.Data;
using System.Drawing;
using System.Net.Mail;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace SuM_Manga_V3.SuMCreator
{
    public partial class CreatorMangaPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            if (GetUserInfoCookie != null)
            {
                if (GetUserInfoCookie["CreatorName"] == null || GetUserInfoCookie["CreatorName"] == string.Empty) { Response.Redirect("~/404.aspx"); }
            }
            else { Response.Redirect("~/AccountETC/LoginETC.aspx"); }
        }
        protected private void CreateSUMXMLProfile(object sender, EventArgs e)
        {
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            int UserID = Convert.ToInt32(GetUserInfoCookie["ID"].ToString());
            //InfoFilled
            string MangaName = MangaNameTXT.Text.ToString().Replace("<", "").Replace(">", "");//D
            string MangaDiscription = MangaInfoTXT.Text.ToString().Replace("<", "").Replace(">", "");//D
            string MangaGerns = "";//-PreGerns -PosibleCreationOfNewOne D
            if (Action.Checked == true) { MangaGerns += "#Action&"; }
            if (Fantasy.Checked == true) { MangaGerns += "#Fantasy&"; }
            if (SliceofLife.Checked == true) { MangaGerns += "#SliceofLife&"; }
            if (Comedy.Checked == true) { MangaGerns += "#Comedy&"; }
            if (Romance.Checked == true) { MangaGerns += "#Romance&"; }
            if (Drama.Checked == true) { MangaGerns += "#Drama&"; }
            if (Mystery.Checked == true) { MangaGerns += "#Mystery&"; }
            if (Sport.Checked == true) { MangaGerns += "#Sport&"; }
            if (Supernatural.Checked == true) { MangaGerns += "#Supernatural&"; }
            if (SciFi.Checked == true) { MangaGerns += "#SciFi&"; }
            string MangaPuplisherName = GetUserInfoCookie["CreatorName"];//D
            string MangaAgeID = AgeRatingDDL.SelectedItem.Text.ToString();//D
            //FileReqInfo
            string CurrentCreatorID = UserID.ToString();//AKA USERID D
            string CreationDate = DateTime.Now.ToString("yyyyMMddHHmmss");//UTC Form D
            string CreatorNameNID = MangaPuplisherName + UserID.ToString();//CreatorSpace D
            string UserReqID = CurrentCreatorID + RandomID();//-AutoGen -DubliCheck D
            UserReqID = UserReqID.Replace(" ", "");
            string SUMProfileFileName = CreationDate + "-" + CurrentCreatorID + "-" + UserReqID + ".sum"; //D
            SUMProfileFileName = SUMProfileFileName.Replace(" ", "");
            string MangaPicRelativRoot = SUMProfileFileName + ".png";//D
            Bitmap PicBitMap = new Bitmap(MangaPicUP.PostedFile.InputStream);
            string MangaThemeColor = RgbConverter(getDominantColor(PicBitMap));//D
            //ReqBuild
            XDocument doc = new XDocument(
                new XDeclaration("1.0", null, "yes"),
                new XComment("Created with the XDocument class, SuM-Manga."),
                new XElement("SuMReq",
                new XElement("Name", MangaName),//D
                new XElement("Description", MangaDiscription),//D
                new XElement("Genres", MangaGerns),//D
                new XElement("Creator", MangaPuplisherName),//A
                new XElement("AgeID", MangaAgeID),//D
                new XElement("Pic", MangaPicRelativRoot),//D
                new XElement("ThemeColor", MangaThemeColor),//A
                new XElement("CreatorID", GetUserInfoCookie["ID"].ToString()),
                new XElement("ReqID", UserReqID)
                )//A
            );
            //ReqSave
            doc.Save(Server.MapPath(Path.Combine("CreatorsDrafts", SUMProfileFileName + ".xml")));
            MangaPicUP.PostedFile.SaveAs(Server.MapPath(Path.Combine("CreatorsDrafts", SUMProfileFileName + ".png")));
            //Save ReqID to CreatorProssDataBase and UserDataBase
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
                        NewReqIDs = "#" + SUMProfileFileName + ".xml&" + reader[0].ToString();
                    }
                }/*
                if (RR != null)
                {
                    if (string.IsNullOrEmpty(RR.ToString()) == false) 
                    {
                        NewReqIDs = "#" + SUMProfileFileName + ".xml&" + RR.ToString();
                    }
                }*/

                query = "UPDATE SuMCreators SET UnderProssReq = @NewUnderProssReq WHERE CreatorID = @UID";
                MySqlCmd2 = new MySqlCommand(query, MySqlCon);
                MySqlCmd2.Parameters.AddWithValue("@UID", SqlDbType.Int);
                MySqlCmd2.Parameters["@UID"].Value = UserID;
                MySqlCmd2.Parameters.AddWithValue("@NewUnderProssReq", NewReqIDs);
                MySqlCmd2.ExecuteNonQuery();
                MySqlCon.Close();
            }
            Response.Redirect("~/SuMCreator/CreatorPanel.aspx");
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
        protected private Color getDominantColor(Bitmap bmp)
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
        protected private static string RgbConverter(Color c)
        {
            return String.Format("rgba({0},{1},{2},0.74)", c.R, c.G, c.B);
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
    }
}