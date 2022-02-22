using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Net.Mail;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace SuM_Manga_V3.SuMAdmin
{
    public partial class SuMManualPuplish : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["PuplishProfile"] == null)
            {
                Response.Redirect("~/404.aspx");
            }
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
                MangaPuplisherName = SuMCreatorPuplishNameTXT.Text.ToString();
                //ES
                MangaPuplisherName = SuMCreatorPuplishNameTXT.Text.ToString();
                int CurrLastUpdateDate = Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd"));
                //Puplish Code Start
                string MangaRoot = MangaName.Replace(" ", "-") + "-" + MangaPuplisherName.Replace(" ", "-") + PuplisherID.ToString().Replace(" ", "") + CurrLastUpdateDate.ToString().Replace(" ", "");
                string CExplorerLink = "/storeitems/ContantExplorer.aspx?Manga=" + MangaRoot;
                string MangaCoverLink = "/storeitems/" + MangaRoot + "/" + MangaName.Replace(" ", "-") + ".png";
                int MangaID = 0;
                using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("INSERT INTO SuMManga(MangaName,CExplorerLink,MangaInfo,SuMThemeColor,MangaCoverLink,ChaptersNumber,MangaViews,MangaCreator,MangaAgeRating,LastUpdateDate) values(@MangaName,@CExplorerLink,@MangaInfo,@SuMThemeColor,@MangaCoverLink,0,0,@MangaCreator,@MangaAgeRating,@LastUpdateDate)", sqlCon);
                    sqlCmd.Parameters.AddWithValue("@MangaName", MangaName);
                    sqlCmd.Parameters.AddWithValue("@CExplorerLink", CExplorerLink);//C
                    sqlCmd.Parameters.AddWithValue("@MangaInfo", MangaDiscription);
                    sqlCmd.Parameters.AddWithValue("@SuMThemeColor", MangaThemeColor);
                    sqlCmd.Parameters.AddWithValue("@MangaCoverLink", MangaCoverLink);
                    sqlCmd.Parameters.AddWithValue("@MangaCreator", MangaPuplisherName);
                    sqlCmd.Parameters.AddWithValue("@MangaAgeRating", MangaAgeID);
                    sqlCmd.Parameters.AddWithValue("@LastUpdateDate", SqlDbType.Int);
                    sqlCmd.Parameters["@LastUpdateDate"].Value = CurrLastUpdateDate;
                    sqlCmd.ExecuteNonQuery();
                    System.Threading.Thread.Sleep(180);
                    sqlCmd = new SqlCommand("SELECT MangaID FROM SuMManga WHERE MangaName = @MangaName AND LastUpdateDate = @LastUpdateDate", sqlCon);
                    sqlCmd.Parameters.AddWithValue("@MangaName", MangaName);
                    sqlCmd.Parameters.AddWithValue("@LastUpdateDate", SqlDbType.Int);
                    sqlCmd.Parameters["@LastUpdateDate"].Value = CurrLastUpdateDate;
                    object RS = sqlCmd.ExecuteScalar();
                    if (RS != null)
                    {
                        MangaID = Convert.ToInt32(RS.ToString());
                    }
                    else 
                    {
                        System.Threading.Thread.Sleep(640);
                        sqlCmd = new SqlCommand("SELECT MangaID FROM SuMManga WHERE MangaName = @MangaName AND LastUpdateDate = @LastUpdateDate", sqlCon);
                        sqlCmd.Parameters.AddWithValue("@MangaName", MangaName);
                        sqlCmd.Parameters.AddWithValue("@LastUpdateDate", SqlDbType.Int);
                        sqlCmd.Parameters["@LastUpdateDate"].Value = CurrLastUpdateDate;
                        RS = sqlCmd.ExecuteScalar();
                        if (RS != null)
                        {
                            MangaID = Convert.ToInt32(RS.ToString());
                        }
                        else
                        {
                            System.Threading.Thread.Sleep(1000);
                            sqlCmd = new SqlCommand("SELECT MangaID FROM SuMManga WHERE MangaName = @MangaName AND LastUpdateDate = @LastUpdateDate", sqlCon);
                            sqlCmd.Parameters.AddWithValue("@MangaName", MangaName);
                            sqlCmd.Parameters.AddWithValue("@LastUpdateDate", SqlDbType.Int);
                            sqlCmd.Parameters["@LastUpdateDate"].Value = CurrLastUpdateDate;
                            RS = sqlCmd.ExecuteScalar();
                            if (RS != null)
                            {
                                MangaID = Convert.ToInt32(RS.ToString());
                            }
                            else
                            {
                                System.Threading.Thread.Sleep(2000);
                                sqlCmd = new SqlCommand("SELECT MangaID FROM SuMManga WHERE MangaName = @MangaName AND LastUpdateDate = @LastUpdateDate", sqlCon);
                                sqlCmd.Parameters.AddWithValue("@MangaName", MangaName);
                                sqlCmd.Parameters.AddWithValue("@LastUpdateDate", SqlDbType.Int);
                                sqlCmd.Parameters["@LastUpdateDate"].Value = CurrLastUpdateDate;
                                RS = sqlCmd.ExecuteScalar();
                                if (RS != null)
                                {
                                    MangaID = Convert.ToInt32(RS.ToString());
                                }
                                else
                                {
                                    System.Threading.Thread.Sleep(6000);
                                    sqlCmd = new SqlCommand("SELECT MangaID FROM SuMManga WHERE MangaName = @MangaName AND LastUpdateDate = @LastUpdateDate", sqlCon);
                                    sqlCmd.Parameters.AddWithValue("@MangaName", MangaName);
                                    sqlCmd.Parameters.AddWithValue("@LastUpdateDate", SqlDbType.Int);
                                    sqlCmd.Parameters["@LastUpdateDate"].Value = CurrLastUpdateDate;
                                    RS = sqlCmd.ExecuteScalar();
                                }
                            }
                        }
                    }
                    sqlCon.Close();
                }
                string epath = System.IO.Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
                string ActivePath = epath + "\\SuMCreator\\CreatorsDrafts\\";
                string NewPath = epath + "\\storeitems\\" + MangaRoot + "\\" + MangaName.Replace(" ", "-") + ".png";
                string NewRoot = epath + "\\storeitems\\" + MangaRoot + "\\";
                Directory.CreateDirectory(NewRoot);
                File.Move(ActivePath+ MangaPicRelativRoot, NewPath);
                File.Delete(ActivePath + ReqProfileFile);
                PuplishGerns(MangaID, ST0String(MangaGerns));
                CreateComentsSpace(MangaID);
                ProssEnding(Convert.ToInt32(PuplisherID), ReqProfileFile, MangaID);
            }
        }
        protected void PuplishGerns(int MID, string[] MGs) 
        {
            //string GernX = string.Empty;
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("", sqlCon);
                for (int i = 0; i < MGs.Length; i++)
                {
                    sqlCmd = new SqlCommand("UPDATE SuMManga SET " + MGs[i] + " = @GernX WHERE MangaID = @MID", sqlCon);
                    sqlCmd.Parameters.AddWithValue("@GernX", SqlDbType.Bit);
                    sqlCmd.Parameters["@GernX"].Value = 1;
                    sqlCmd.Parameters.AddWithValue("@MID", SqlDbType.Int);
                    sqlCmd.Parameters["@MID"].Value = MID;
                    sqlCmd.ExecuteNonQuery();
                }
                sqlCon.Close();
            }
        }
        protected void CreateComentsSpace(int MID) 
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("INSERT INTO SuMMangaComments(MangaID,CreatorComment) values(@MID,@CreatorComment)", sqlCon);
                sqlCmd.Parameters.AddWithValue("@CreatorComment", " ");
                sqlCmd.Parameters.AddWithValue("@MID", SqlDbType.Int);
                sqlCmd.Parameters["@MID"].Value = MID;
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        protected void ProssEnding(int UserID, string ReqFID, int MangaID)
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string NewReqIDs = string.Empty;

                string query = "SELECT UnderProssReq FROM SuMCreators WHERE CreatorID = @UID";
                SqlCommand sqlCmd2 = new SqlCommand(query, sqlCon);
                sqlCmd2.Parameters.AddWithValue("@UID", SqlDbType.Int);
                sqlCmd2.Parameters["@UID"].Value = UserID;
                //var RR = sqlCmd2.ExecuteReader();
                using (var reader = sqlCmd2.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        NewReqIDs = reader[0].ToString().Replace("#" + ReqFID + "&", "");
                    }
                }
                query = "UPDATE SuMCreators SET UnderProssReq = @NewUnderProssReq WHERE CreatorID = @UID";
                sqlCmd2 = new SqlCommand(query, sqlCon);
                sqlCmd2.Parameters.AddWithValue("@UID", SqlDbType.Int);
                sqlCmd2.Parameters["@UID"].Value = UserID;
                sqlCmd2.Parameters.AddWithValue("@NewUnderProssReq", NewReqIDs);
                sqlCmd2.ExecuteNonQuery();

                query = "SELECT MangasIDs FROM SuMCreators WHERE CreatorID = @UID";
                sqlCmd2 = new SqlCommand(query, sqlCon);
                sqlCmd2.Parameters.AddWithValue("@UID", SqlDbType.Int);
                sqlCmd2.Parameters["@UID"].Value = UserID;
                //var RR = sqlCmd2.ExecuteReader();
                using (var reader = sqlCmd2.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        NewReqIDs = "#" + MangaID + "&" + reader[0].ToString();
                    }
                }
                query = "UPDATE SuMCreators SET MangasIDs = @MangasIDs WHERE CreatorID = @UID";
                sqlCmd2 = new SqlCommand(query, sqlCon);
                sqlCmd2.Parameters.AddWithValue("@UID", SqlDbType.Int);
                sqlCmd2.Parameters["@UID"].Value = UserID;
                sqlCmd2.Parameters.AddWithValue("@MangasIDs", NewReqIDs);
                sqlCmd2.ExecuteNonQuery();

                sqlCon.Close();
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