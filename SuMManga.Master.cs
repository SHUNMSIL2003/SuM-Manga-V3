using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

namespace SuM_Manga_V3
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
            if (GetUserInfoCookie != null)
            {
                string PFPFDB = string.Empty;
                string user = GetUserInfoCookie["UserName"].ToString();
                UserName.InnerText = user;
                using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:shun-sum-projctdb-server.database.windows.net,1433;Initial Catalog=Shun-SuM-Projct_db;User Id=SuMSite2003@shun-sum-projctdb-server;Password=55878833shunpass#SQL"))
                {
                    sqlCon.Open();
                    string query = "SELECT PFP FROM SuMUsersAccounts WHERE UserName = @UserName";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@UserName", user);
                    using (SqlDataReader dr = sqlCmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            PFPFDB = dr[0].ToString();
                        }
                    }
                }
                UserPFP.Attributes["src"] = ResolveUrl(PFPFDB);
                SignOption.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(SignOption, string.Empty));
                if (IsPostBack && Request["__EVENTTARGET"] == SignOption.UniqueID)
                {
                    LogOut(SignOption, EventArgs.Empty);
                }
                //SuMSiteAlert.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(SuMSiteAlert, string.Empty));
                //if (IsPostBack && Request["__EVENTTARGET"] == SuMSiteAlert.UniqueID)
                //{
                //    SuMAppAlertsStartsS(SuMSiteAlert, EventArgs.Empty);
                //}
                //ignOption.Attributes["onclick"] = "LogOut";
                SignOption.InnerText = " Logout";
                SerchBTN0.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(SerchBTN0, string.Empty));
                if (IsPostBack && Request["__EVENTTARGET"] == SerchBTN0.UniqueID)
                {
                    LookUpSQL(SerchBTN0, EventArgs.Empty);
                }
                SerchBTN1.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(SerchBTN1, string.Empty));
                if (IsPostBack && Request["__EVENTTARGET"] == SerchBTN1.UniqueID)
                {
                    LookUpSQL(SerchBTN1, EventArgs.Empty);
                }
                bool once = true;
                if (once == true)
                {
                    once = false;
                    PayNoti();
                }
            }
            else
            {
                Response.Redirect("~/AccountETC/LoginETC.aspx");
                /*SignOption.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(SignOption, string.Empty));
                if (IsPostBack && Request["__EVENTTARGET"] == SignOption.UniqueID)
                {
                    ToSign(SignOption, EventArgs.Empty);
                }
                SignOption.InnerText = " Login";*/
            }
        }
        protected void PayNoti()
        {
            int ID = 0;
            string D = DateTime.UtcNow.ToString("dd");
            string M = DateTime.UtcNow.ToString("MM");
            string Y = DateTime.UtcNow.ToString("yyyy");
            HttpCookie GetUserInfoCookie2 = Request.Cookies["SuMCurrentUser"];
            string UserName = GetUserInfoCookie2["UserName"].ToString();
            int AlS = 0;
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:shun-sum-projctdb-server.database.windows.net,1433;Initial Catalog=Shun-SuM-Projct_db;User Id=SuMSite2003@shun-sum-projctdb-server;Password=55878833shunpass#SQL"))
            {
                sqlCon.Open();
                string query = "SELECT UserID FROM SuMUsersAccounts WHERE UserName = @UserName ";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@UserName", UserName);
                using (SqlDataReader dr = sqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ID = Convert.ToInt32(dr[0]);
                    }
                }
                sqlCon.Close();
            }
            string RawAlert = string.Empty;
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:shun-sum-projctdb-server.database.windows.net,1433;Initial Catalog=Shun-SuM-Projct_db;User Id=SuMSite2003@shun-sum-projctdb-server;Password=55878833shunpass#SQL"))
            {
                sqlCon.Open();
                string query = "SELECT SuMPaymentAlert FROM UsersAccountAlert WHERE UserID = @UserID ";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@UserID", SqlDbType.Int);
                sqlCmd.Parameters["@UserID"].Value = ID;
                using (SqlDataReader dr = sqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        RawAlert = dr[0].ToString();
                    }
                }
                sqlCon.Close();
            }
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:shun-sum-projctdb-server.database.windows.net,1433;Initial Catalog=Shun-SuM-Projct_db;User Id=SuMSite2003@shun-sum-projctdb-server;Password=55878833shunpass#SQL"))
            {
                sqlCon.Open();
                string query = "SELECT AlertsSeen FROM UsersAccountAlert WHERE UserID = @UserID ";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@UserID", SqlDbType.Int);
                sqlCmd.Parameters["@UserID"].Value = ID;
                using (SqlDataReader dr = sqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        AlS = Convert.ToInt32(dr[0]);
                    }
                }
                sqlCon.Close();
            }
            //dataready now
            payalertshow.Attributes["style"] = "height:fit-content;";
            string month = string.Empty;
            string[] months = { "January", "February", "March ", "April", "May ", "June ", "July", "August", "September", "October", "November", "December" };
            //PayDate.InnerText = Month + " " + d.ToString() + Y; wrong
            string SType = "";
            string SD = string.Empty;
            string SM = string.Empty;
            string SY = string.Empty;
            string SNotReadden = "";
            char[] Alert = RawAlert.ToCharArray();
            bool Q = false;
            for (int i = 0; i < Alert.Length; i++)
            {
                if (Alert[i] == '?') { Q = true; }
                if (Alert[i] != '#' && Q == false)
                {
                    SType += Alert[i];
                }
                if (Alert[i] == '?' && Alert[i + 1] == 'Y')
                {
                    SY = "" + Alert[i + 2] + Alert[i + 3] + Alert[i + 4] + Alert[i + 5];
                }
                if (Alert[i] == '?' && Alert[(i + 1)] == 'M')
                {
                    SM = (Alert[i + 2]).ToString() + (Alert[i + 3]).ToString();
                }
                if (Alert[i] == '?' && Alert[i + 1] == 'D')
                {
                    SD = "" + Alert[i + 2] + Alert[i + 3];
                }
                if (Alert[i] == '$') { SNotReadden = (Alert[i + 1]).ToString(); }
            }//Remember to add red to seen in register
            int pm = Convert.ToInt32(SM);
            int fixedday = Convert.ToInt32(SD);
            PayDate.InnerText = months[pm - 1] + " " + fixedday.ToString() + " " + SY;
            bool timepassed = false;
            if ((Convert.ToInt32(SY) - Convert.ToInt32(Y)) <= 0)
            {
                if ((Convert.ToInt32(SM) - Convert.ToInt32(M)) == 0)
                {
                    if ((Convert.ToInt32(SD) <= Convert.ToInt32(D)))
                    {
                        if (SType == "FreeT") { PayDisc.InnerText = "Enjoy your One Month FREE Traial :) "; }
                        if (SType == "Paied") { PayDisc.InnerText = "Payment Confirmed, Enjoy SuM Manga :) "; }
                    }
                    else { timepassed = true; }
                }
                if ((Convert.ToInt32(M) - Convert.ToInt32(SM)) == 1)
                {
                    if ((Convert.ToInt32(SD) > Convert.ToInt32(D)))
                    {
                        if (SType == "FreeT") { PayDisc.InnerText = "Enjoy your One Month FREE Traial :) "; }
                        if (SType == "Paied") { PayDisc.InnerText = "Payment Confirmed, Enjoy SuM Manga :) "; }
                    }
                    else { timepassed = true; }
                }
                if ((Convert.ToInt32(SM) - Convert.ToInt32(M)) != 0 && (Convert.ToInt32(M) - Convert.ToInt32(SM)) != 1) { timepassed = true; }
            }
            else { timepassed = true; }
            if (timepassed == true)
            {
                if (SType == "FreeT") { PayDisc.InnerText = "Your One Month FREE Traial has endded,Create a subscription to contenue. "; }
                if (SType == "Paied") { PayDisc.InnerText = "Your subscription hase expired!, Renew it contenue."; }
                HttpCookie userInfo = new HttpCookie("SuMCurrentUser");  //Request.Cookies["userInfo"].Value;  
                userInfo["UserName"] = UserName;
                userInfo["SubValid"] = "N";
                //userInfo.Expires.Add(new TimeSpan(4, 1, 0));
                userInfo.Expires = DateTime.MaxValue;
                HttpContext.Current.Response.Cookies.Add(userInfo);
            }
            else
            {
                HttpCookie userInfo = new HttpCookie("SuMCurrentUser");  //Request.Cookies["userInfo"].Value;  
                userInfo["UserName"] = UserName;
                userInfo["SubValid"] = "N";
            }
            /*SuMAppAlert.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(SuMAppAlert, string.Empty));
            if (IsPostBack && Request["__EVENTTARGET"] == SuMAppAlert.UniqueID)
            {
                MarkReadDone(ID, RawAlert, SuMAppAlert, EventArgs.Empty);
            }*/
            // if (SType == "FreeT") { PayDisc.InnerText = "Enjoy your One Month FREE Traial :) "; }
            // if (SType == "Paied") { PayDisc.InnerText = "Payment Confirmed, Enjoy SuM Manga :) "; }
        }
        private void SuMAppAlertsStartsS(object sender, EventArgs e) 
        {
            int ID = 0;
            HttpCookie GetUserInfoCookie2 = Request.Cookies["SuMCurrentUser"];
            string UserName = GetUserInfoCookie2["UserName"].ToString();
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:shun-sum-projctdb-server.database.windows.net,1433;Initial Catalog=Shun-SuM-Projct_db;User Id=SuMSite2003@shun-sum-projctdb-server;Password=55878833shunpass#SQL"))
            {
                sqlCon.Open();
                string query = "SELECT UserID FROM SuMUsersAccounts WHERE UserName = @UserName ";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@UserName", UserName);
                using (SqlDataReader dr = sqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ID = Convert.ToInt32(dr[0]);
                    }
                }
                sqlCon.Close();
            }
            string RawAlert = string.Empty;
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:shun-sum-projctdb-server.database.windows.net,1433;Initial Catalog=Shun-SuM-Projct_db;User Id=SuMSite2003@shun-sum-projctdb-server;Password=55878833shunpass#SQL"))
            {
                sqlCon.Open();
                string query = "SELECT SuMPaymentAlert FROM UsersAccountAlert WHERE UserID = @UserID ";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@UserID", SqlDbType.Int);
                sqlCmd.Parameters["@UserID"].Value = ID;
                using (SqlDataReader dr = sqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        RawAlert = dr[0].ToString();
                    }
                }
                sqlCon.Close();
            }
            MarkReadDone(ID, RawAlert);
        }
        protected void ToSign(object sender, EventArgs e) 
        {
            Response.Redirect("~/AccountETC/LoginETC.aspx");
        }
        protected void MarkReadDone(int Colum, string OValue) //name colum but its a row
        {
            string confirmseentag = "";
            string backupoldfornew = "";
            bool dollarfound = false;
            char[] value = OValue.ToCharArray();
            for (int g = 0; g < OValue.Length; g++) 
            {
                if (dollarfound == false) { backupoldfornew += value[g]; } else { confirmseentag = (value[g + 1]).ToString(); g = OValue.Length; }
                if (g == '$'){ dollarfound = true; }//can be optimized ! -Later-> no need now i think...
            }
            string NewSeenTag = string.Empty;
            if (confirmseentag == "N")
            {

                NewSeenTag = backupoldfornew + "Y";
            }
            else { NewSeenTag = OValue; }
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:shun-sum-projctdb-server.database.windows.net,1433;Initial Catalog=Shun-SuM-Projct_db;User Id=SuMSite2003@shun-sum-projctdb-server;Password=55878833shunpass#SQL"))
            {
                sqlCon.Open();
                string query = "UPDATE UsersAccountAlert SET SuMPaymentAlert = @SuMPaymentAlert WHERE UserID = @UserID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                //HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUser"];
                sqlCmd.Parameters.AddWithValue("@UserID", Colum);
                sqlCmd.Parameters.AddWithValue("@SuMPaymentAlert", NewSeenTag);
                sqlCmd.ExecuteNonQuery();
                //sqlCmd.Parameters.AddWithValue("@SuMCustomPFP", SqlDbType.Image).Value = imgarray;
                sqlCon.Close();
            }
        }
        public void empty0() { }
        protected void LogOut(object sender, EventArgs e) 
        {
            HttpCookie GetUserInfoCookie = new HttpCookie("SuMCurrentUser");
            GetUserInfoCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(GetUserInfoCookie);
            //HttpCookie GetUserpinns = Request.Cookies["SuMPinns"];
            //GetUserpinns["Pinns"] = "!";
            //Response.Cookies.Add(GetUserpinns);
            Response.Redirect("~/AccountETC/LogInETC.aspx");
        }
        protected void SuMLookUp(object sender, EventArgs e)
        {

        }
        protected void LookUpSQL(object sender, EventArgs e) 
        {
            string Wanted = string.Empty;
            if (LookUp.Value.ToString() != null) { Wanted = LookUp.Value.ToString(); }
            //if (LookUpMobile.Value.ToString() != null) { Wanted = LookUpMobile.Value.ToString(); }
            if (Wanted != null)
            {
                //Debig202312.InnerHtml = "";
                /*string savecurhelp = string.Empty;
                char[] WanatedRaw = Wanted.ToCharArray();
                for (int c = 0; c < WanatedRaw.Length; c++)
                {
                    if (WanatedRaw[c] != ' ') { savecurhelp += WanatedRaw[c]; }
                    if (WanatedRaw[c] == ' ' || (c + 1) == WanatedRaw.Length)
                    {
                        Debig202312.InnerHtml += GetMangaFromSQL(savecurhelp);
                        savecurhelp = "";
                    }
                }*/
                Debig202312.InnerHtml = GetMangaFromSQL(Wanted);
                mc.InnerHtml = "";
                //GetMangaFromSQL(Wanted);
            }
        }
        /*protected void GetMangaFromSQL(string Wanted)
        {
            string ResultsQ = string.Empty;
            //int i = 0;
            string MangaName = string.Empty;
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:shun-sum-projctdb-server.database.windows.net,1433;Initial Catalog=Shun-SuM-Projct_db;User Id=SuMSite2003@shun-sum-projctdb-server;Password=55878833shunpass#SQL"))
            {
                sqlCon.Open();
                string queryFIND = "SELECT MangaID FROM SuMManga WHERE MangaName LIKE @Wanted ";
                SqlCommand sqlCmdFIND = new SqlCommand(queryFIND, sqlCon);
                sqlCmdFIND.Parameters.AddWithValue("@Wanted", Wanted);

                if (sqlCmdFIND.ExecuteScalar() != null)
                {
                    var X = sqlCmdFIND.ExecuteScalar(); //ExecuteNonQuery();
                    int i = Convert.ToInt32(X);
                    string query = "SELECT CExplorerLink FROM SuMManga WHERE MangaID = @MangaID";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    sqlCmd.Parameters["@MangaID"].Value = i;
                    //X = sqlCmd.ExecuteScalar();
                    var l= sqlCmd.ExecuteScalar(); ;
                    string Link = l.ToString(); // Convert.ToInt32(sqlCmd.ExecuteScalar()); //(Int32)sqlCmd.ExecuteScalar();
                    Response.Redirect(Link);
                }
            }
        }*/
        protected string GetMangaFromSQL(string Wanted)
        {
            string ResultsQ = string.Empty;
            //int i = 0;
            string MangaName = string.Empty;
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=tcp:shun-sum-projctdb-server.database.windows.net,1433;Initial Catalog=Shun-SuM-Projct_db;User Id=SuMSite2003@shun-sum-projctdb-server;Password=55878833shunpass#SQL"))
            {
                sqlCon.Open();
                string queryFIND = "SELECT MangaID FROM SuMManga WHERE MangaName LIKE @Wanted ";
                SqlCommand sqlCmdFIND = new SqlCommand(queryFIND, sqlCon);
                sqlCmdFIND.Parameters.AddWithValue("@Wanted", Wanted);

                if (sqlCmdFIND.ExecuteScalar() != null)
                {
                    var X = sqlCmdFIND.ExecuteScalar(); //ExecuteNonQuery();
                    int i = Convert.ToInt32(X);

                    string query = "SELECT ChaptersNumber FROM SuMManga WHERE MangaID = @MangaID";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
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
                    return ContantShow(MangaName, MangaInfo, MangaViews, MangaCoverLink, CExplorerLink, ChaptersNum, i);


                    //return ContantShow(MangaName, MangaInfo, MangaViews, MangaCoverLink, CExplorerLink, ChaptersNum, ID);
                }
                else { return "<h4>Not Found!</h4>"; }
            }
        }
        public void LookUpImprovedNB(object sender, EventArgs e)
        {
            string figureclass = "imghvr-blur box";
            string figurestyle = "width:196px;height:300px;border-radius:10px;border-top-left-radius:10px;border-bottom-right-radius:10px;";
            string astyle = "border-radius:10px;margin:10px;";
            string lookupfor = string.Empty;
            if (LookUp.Value != null) { lookupfor = LookUp.Value.ToString(); }
            if (LookUpMobile.Value != null) { lookupfor = LookUpMobile.Value.ToString(); }
            string nospacelookup = "";
            int matchednum = 0;
            for (int i = 0; i < lookupfor.Length; i++) { if (lookupfor[i] != ' ') { nospacelookup += lookupfor[i]; } }
            char[] lookupl = lookupfor.ToCharArray();
            string epath = System.IO.Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            string ActivePath = epath + "\\storeitems\\";
            string[] Folders = System.IO.Directory.GetDirectories(ActivePath);
            int timec = 0;
            string codesent = "";
            while (timec < Folders.Length)
            {
                matchednum = 0;
                char[] fname = Folders[timec].ToCharArray();///
                char[] lname = nospacelookup.ToCharArray();
                int slash = 0;
                for (int g = 0; g < Folders[timec].Length; g++)
                {
                    if (fname[g] == '\\') { slash = g; }
                }
                string LNameFixed = "";
                for (int j = slash; j < Folders[timec].Length; j++)
                {
                    LNameFixed += fname[j];
                }
                char[] LNameFixedChar = LNameFixed.ToCharArray();
                for (int s = 0; s < LNameFixedChar.Length; s++)
                {
                    if (s < lname.Length)
                    {
                        if (LNameFixedChar[s] == lname[s]) { matchednum++; }
                    }
                    else { s = Folders[timec].Length; }
                }
                if (matchednum == lname.Length || (double)(matchednum / lname.Length) > 0.5)
                {
                    string MangaIdAKAName = fname.ToString();
                    string covername = MangaIdAKAName + ".jpg"; //FilterToMangaCoverLink(filePathscover);
                    string MangaPathCover = "/storeitems/" + MangaIdAKAName + "/" + covername;
                    string mangaroottitle = epath + "\\storeitems\\" + MangaIdAKAName + "\\Title.txt";
                    string mangarootdisc = epath + "\\storeitems\\" + MangaIdAKAName + "\\Discrip.txt";
                    string MnagaTitle = System.IO.File.ReadAllText(mangaroottitle);////error---------------------------------------------------Need to convert to data base
                    string MnagaDiscription = System.IO.File.ReadAllText(mangarootdisc);////  System.IO.File.ReadAllText
                    string linkToExplorer = "/storeitems/ContantExplorer.aspx?Manga=" + MangaIdAKAName;
                    codesent += "<a href=" + linkToExplorer + " ><figure class=" + figureclass + "  style = " + astyle + "  ><img style = " + figurestyle + " src=" + MangaPathCover + "><figcaption><h3>" + MnagaTitle + "</h3><h4>" + MnagaDiscription + "</h4></figcaption></figure></a>";
                    Debig202312.InnerHtml = codesent;
                }
                timec++;
            }
        }
        public bool MatchUPto50Per(string a, string b)
        {
            if (a.Length > 0 && b.Length > 0)
            {
                char[] ca = a.ToCharArray();
                char[] cb = b.ToCharArray();
                int matchednum = 0;
                double devideon = b.Length;
                if (a.Length > b.Length)
                {
                    for (int i = 0; i < b.Length; i++)
                    {
                        if (ca[i] == cb[i]) { matchednum++; }
                    }
                    if ((double)(matchednum / devideon) > 0.3) { return true; }
                    else { return false; }
                }
                else
                {
                    for (int i = 0; i < a.Length; i++)
                    {
                        if (ca[i] == cb[i]) { matchednum++; }
                    }
                    if ((double)(matchednum / devideon) > 0.3) { return true; }
                    else { return false; }
                }
            }
            else { return false; }
        }
        public string ContantShow(string MangaName, string MangaInfo, int MangaViews, string MangaCoverLink, string CExplorerLink, int ChaptersNum, int id)
        {
            string cn = ChaptersNum.ToString();
            CExplorerLink += "&CN=" + cn + "&VC=" + id;
            string figureclass = "imghvr-fade box";//width:160px;
            string figurestyle = "margin-left:2.6px;margin-right:2.6px;margin-top:3px;width:136px;height:204px;border-radius:10px;border-top-left-radius:10px;border-bottom-right-radius:10px;border:-2px solid #6840D9;";
            string astyle = "border-radius:10px;margin:10px;width:142px;";//mw
            //string vstyle = "margin-left:4px;width:24px;height:24px;position:relative;z-index:1;display:block;";
            //string vimage = "/storeitems/view.png";
            string viewes = /*"<img src=" + vimage + " style=" + vstyle + ">" +*/ "<h6 style=" + "color:white;position:relative;display:inline-block;margin-top:-10px" + ">Views:" + MangaViews + " Ch: " + ChaptersNum + "</h6>";
            string divfits = "<div data-bss-hover-animate=" + "pulse" + " style=" + "display:inline-block; height:fit-content;width:142px;" + ">";//mw
            string result = divfits + "<a href=" + CExplorerLink + " ><figure class=" + figureclass + "  style = " + astyle + "  ><img style = " + figurestyle + " src=" + MangaCoverLink + ">" + viewes + "<figcaption><h6 style=" + "font-size:100%;" + " ><b>" + MangaName + "</b></h6><br/><h6 style=" + "font-size:74%;" + " >" + MangaInfo + "</h6></figcaption></figure></a></div>";
            return result;
        }
    }
}