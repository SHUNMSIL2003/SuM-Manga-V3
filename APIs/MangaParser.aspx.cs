using System;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web;
using System.Data;

namespace SuM_Manga_V3
{
    public partial class MangaParser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool SuMTokenIsValid = false;
            string json = string.Empty;
            if (Request.QueryString["MN"] != null && Request.QueryString["MID"] != null && Request.QueryString["CN"] != null)//  /MangaParser.aspx?MID=0&CN=0&MN=X
            {
                HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
                if (GetUserInfoCookie != null)
                {
                    int UID = Convert.ToInt32(GetUserInfoCookie["ID"].ToString());
                    object SIDObj = GetUserInfoCookie["SID"].ToString();
                    if (SIDObj != null)
                    {
                        if (SID_State(UID, SIDObj.ToString()))
                        {
                            //[VALID_REQ]
                            int MID = Convert.ToInt32(Request.QueryString["MID"].ToString());
                            int CN = Convert.ToInt32(Request.QueryString["CN"].ToString().ToLower().Replace("ch", ""));
                            json = GetMangaString64JSON(MID, Request.QueryString["CN"].ToString(), UID, Request.QueryString["MN"].ToString());
                            if (!json.Contains("[NOT_READY_YET]") && json.Contains("#File;Split&"))
                            {
                                AddOneView();
                                ReasentMarker(UID, MID);
                                UpdateChapterNumInCurr(MID, CN, UID);
                                SuMTokenIsValid = SuMCoinPass(UID, MID);
                            }
                        }
                        else json = "[SESSION_EXPIRED]";https://localhost:44382/APIs/MangaParser.aspx.cs
                    }
                    else json = "[SESSION_EXPIRED]";
                }
                else json = "[LOGIN_PLZ]";
            }
            else json = "[MISSING_A_Q]";
            if (!SuMTokenIsValid) json = "[BUY_COINS]";
            Response.Clear();
            Response.ContentType = "text/plain; charset=utf-8";
            Response.Write(json);
            Response.End();
        }
        protected private bool SID_State(int UID, string SID)
        {
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;
            using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string qwi = "SELECT SIDs FROM SuMUsersAccounts WHERE UserID = @UID";
                MySqlCommand MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                MySqlCmd00.Parameters["@UID"].Value = UID;
                var RawRes = MySqlCmd00.ExecuteScalar();
                if (RawRes != null)
                {
                    string Res = RawRes.ToString().Replace(" ", "");
                    if (Res.Contains(SID)) return true;
                    else return false;
                }
                else return false;
            }
        }
        protected private bool SuMCoinPass(int UID, int MID)
        {
            bool ProssR = false;
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;
            using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                int UCC = 0;//UserCoinsCount
                int RCA = 0;//Req Coins "for chapter"
                string query = "SELECT UserCoins FROM SuMUsersAccounts WHERE UserID = @UID";
                MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
                MySqlCmd.Parameters.AddWithValue("@UID", SqlDbType.Int);
                MySqlCmd.Parameters["@UID"].Value = UID;
                using (MySqlDataReader dr = MySqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (dr[0] != null)
                        {
                            if (dr[0].ToString().Replace(" ", "") != "")
                            {
                                UCC = Convert.ToInt32(dr[0].ToString());
                            }
                        }
                    }
                }
                query = "SELECT ChapterCValue FROM SuMManga WHERE MangaID = @MID";
                MySqlCmd = new MySqlCommand(query, MySqlCon);
                MySqlCmd.Parameters.AddWithValue("@MID", SqlDbType.Int);
                MySqlCmd.Parameters["@MID"].Value = MID;
                using (MySqlDataReader dr = MySqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (dr[0] != null)
                        {
                            if (dr[0].ToString().Replace(" ", "") != "")
                            {
                                RCA = Convert.ToInt32(dr[0].ToString());
                            }
                        }
                    }
                }
                if (UCC >= RCA)
                {
                    query = "UPDATE SuMUsersAccounts SET UserCoins = UserCoins - " + RCA.ToString() + " WHERE UserID = @UID ";
                    MySqlCmd = new MySqlCommand(query, MySqlCon);
                    MySqlCmd.Parameters.AddWithValue("@UID", SqlDbType.Int);
                    MySqlCmd.Parameters["@UID"].Value = UID;
                    MySqlCmd.ExecuteNonQuery();
                    ProssR = true;
                }
                MySqlCon.Close();
            }
            return ProssR;
        }
        protected private string GetMangaString64JSON(int MID, string ChapterX, int UID, string MangaName)
        {
            string JASON = "";
            int ab = Convert.ToInt32(ChapterX.ToLower().Replace("ch", ""));
            string help0136 = "\\";
            string epath = System.IO.Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            string ActivePath = epath + "\\storeitems\\" + MangaName + help0136 + ChapterX + help0136;
            if (System.IO.Directory.Exists(ActivePath) == true)
            {
                string[] filePaths = System.IO.Directory.GetFiles(ActivePath, "*.jpg");//add req!
                string deafultstartitems = "/storeitems/";
                string slash0 = "/";
                if (filePaths.Length > 0)
                {
                    for (int i = 0; i < (filePaths.Length); i++)
                    {
                        string filenamepath = deafultstartitems + MangaName + slash0 + ChapterX + slash0 + System.IO.Path.GetFileName(filePaths[i]);
                        //JASON += GetString64JsonForArray(filenamepath, i);
                        JASON += "#File;Split&" + filenamepath;//BuildRespons(filenamepath, i);
                    }
                }
                else JASON = "[NOT_READY_YET]";
                string NCX = "ch";
                if (ab.ToString().Length == 1) NCX += "000";
                else
                {
                    if (ab.ToString().Length == 2) NCX += "00";
                    else if (ab.ToString().Length == 3) NCX += "0";
                }
                NCX += (ab + 1).ToString();
                ActivePath = ActivePath.Replace(ChapterX, NCX);
                if (System.IO.Directory.Exists(ActivePath) == true && ChapterX != NCX)
                {
                    JASON = "#" + (ab + 1) + "&" + JASON;
                }
                else
                {
                    JASON = "#0&" + JASON;
                }
            }
            else JASON = "[NOT_READY_YET]";
            return JASON;
        }
        public static string NextChapterNum(string cname)
        {
            char[] pross = cname.ToCharArray();
            int num = 0;
            int help0 = 5;
            int md = 0;
            for (int d = 2; d < pross.Length; d++)
            {
                if (pross[d] == '0' && (d + 1) < pross.Length && pross[d + 1] != '9')
                {
                    md++;
                }
                help0--;
                int help1 = 0;
                if (help0 == 4) { help1 = 1000; }
                if (help0 == 3) { help1 = 100; }
                if (help0 == 2) { help1 = 10; }
                if (help0 == 1) { help1 = 1; }
                int sf = pross[d] - '0';
                num += (help1) * sf;
            }
            string zeros = "";
            while (md > 0) { md--; zeros += "0"; }
            int xnum = num + 1;
            string nnum = (xnum).ToString();
            cname = "ch" + zeros + nnum;
            return cname;
        }
        protected void ReasentMarker(int UID,int MID)
        {
            object RawRes;
            string NewSol = string.Empty;
            string Target = "#" + MID + "&";
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString; using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string qwi = "SELECT Resently FROM SuMUsersAccounts WHERE UserID = @UID";
                MySqlCommand MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                MySqlCmd00.Parameters["@UID"].Value = UID;
                RawRes = MySqlCmd00.ExecuteScalar();
                if (RawRes != null)
                {
                    if (RawRes.ToString().Contains(Target) == true)
                    {
                        NewSol = Target + RawRes.ToString().Replace(Target, "");
                    }
                    else
                    {
                        NewSol = Target + RawRes.ToString();
                    }
                }
                else
                {
                    NewSol = Target;
                }
                qwi = "UPDATE SuMUsersAccounts SET Resently = @NEWResently WHERE UserID = @UID";
                MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                MySqlCmd00.Parameters.AddWithValue("@NEWResently", NewSol);
                MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                MySqlCmd00.Parameters["@UID"].Value = UID;
                MySqlCmd00.ExecuteNonQuery();
                MySqlCon.Close();
            }
        }

        protected void AddOneView()
        {
            string x = Request.QueryString["VC"];
            int y = Convert.ToInt32(x);
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString; using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string query = "UPDATE SuMManga SET MangaViews = MangaViews + 1 WHERE MangaID = @MangaID";
                MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
                MySqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                MySqlCmd.Parameters["@MangaID"].Value = y;
                MySqlCmd.ExecuteNonQuery();
                MySqlCon.Close();
            }
        }
        protected string GetString64JsonForArray(string path,int num)// -3PagesN -2NextCH -1CurrCN 0Name
        {
            byte[] imageArray = System.IO.File.ReadAllBytes(Server.MapPath("~" + path));
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);
            string Result = BuildRespons(base64ImageRepresentation,num);
            return Result;
        }
        protected string BuildRespons(string UserBanner_64String,int num)
        {
            return "{ " + '"' + "P" + num.ToString() + '"' + ": " + '"' + UserBanner_64String + '"' + " }";
        }
        protected bool IsItAlraedyInCurr(int MID, int UID)
        {

            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString; using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string qwi = "SELECT Curr FROM SuMUsersAccounts WHERE UserID = @UID";
                MySqlCommand MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                MySqlCmd00.Parameters["@UID"].Value = UID;
                var RawRes = MySqlCmd00.ExecuteScalar();
                if (RawRes != null)
                {
                    string Res = RawRes.ToString().Replace(" ","");
                    if (Res.Contains("#" + MID.ToString() + ";"))
                    {
                        return true;
                    }
                    return false;
                }
                else { return false; }
            }
        }
        protected private void UpdateChapterNumInCurr(int MID, int CurrCN, int UID)
        {
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString; using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string qwi = "SELECT Curr FROM SuMUsersAccounts WHERE UserID = @UID";
                MySqlCommand MySqlCmd00 = new MySqlCommand(qwi, MySqlCon);
                MySqlCmd00.Parameters.AddWithValue("@UID", SqlDbType.Int);
                MySqlCmd00.Parameters["@UID"].Value = UID;
                var RawRes = MySqlCmd00.ExecuteScalar();
                string query = "SELECT MangaName FROM SuMManga WHERE MangaID = @MID";
                MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
                MySqlCmd.Parameters.AddWithValue("@MID", SqlDbType.Int);
                MySqlCmd.Parameters["@MID"].Value = MID;
                var CIME = MySqlCmd.ExecuteScalar();
                bool MDE = false;
                if (CIME != null) { MDE = true; }
                if (RawRes != null && MDE == true)
                {
                    bool ChangeIsPresent = false;
                    string Res = RawRes.ToString().Replace(" ", "");
                    if (Res.Contains("#" + MID.ToString() + ";"))
                    {
                        int SOCIndex = Res.IndexOf("#" + MID.ToString() + ";");
                        for (int i = SOCIndex; i < (SOCIndex + 32); i++)
                        {
                            if (Res[i] == '&')
                            {
                                string ORS = "#" + MID.ToString() + ";";
                                for (int j = SOCIndex; j < (i+1); j++)
                                {
                                    ORS += Res[j].ToString();
                                }
                                ORS = ORS.Replace("#" + MID.ToString() + ";" + "#" + MID.ToString() + ";", "#" + MID.ToString() + ";").Replace(";;", ";").Replace("&&", "&");
                                if (!ORS.Contains("&")) ORS += "&";
                                string NCS = "#" + MID + ";" + CurrCN + "&";
                                if (ORS != NCS)
                                {
                                    Res = Res.Replace(ORS, NCS);//#MID;CN&
                                    ChangeIsPresent = true;
                                }
                                i = SOCIndex + 32;
                            }
                        }
                    }
                    else
                    {
                        Res = "#" + MID.ToString() + ";" + CurrCN.ToString() + "&" + Res;
                        ChangeIsPresent = true;
                    }
                    if (ChangeIsPresent)
                    {
                        string InsertQ = "UPDATE SuMUsersAccounts SET Curr = @NewCurr WHERE UserID = @UID";
                        MySqlCommand MySqlCmdIn = new MySqlCommand(InsertQ, MySqlCon);
                        MySqlCmdIn.Parameters.AddWithValue("@UID", SqlDbType.Int);
                        MySqlCmdIn.Parameters["@UID"].Value = UID;
                        MySqlCmdIn.Parameters.AddWithValue("@NewCurr", Res);
                        MySqlCmdIn.ExecuteNonQuery();
                    }
                }
                MySqlCon.Close();
            }
        }
    }
}