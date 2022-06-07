using System;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Text;

namespace SuM_Manga_V3.SuMAdmin
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie GetUserInfoCookie = Request.Cookies["SuMAdmin"];
            if (GetUserInfoCookie != null)
            {
                if (GetUserInfoCookie.Expires > DateTime.UtcNow.AddHours(8))
                {
                    SuMAdminMSG.InnerText = "Session expired, login plz.";
                    Response.Cookies["SuMAdmin"].Expires = DateTime.Now.AddDays(-1);
                }
                else Response.Redirect("~/SuMAdmin/AcceptSuMUploads.aspx");
            }
            else
            {
                SuMAdminMSG.InnerText = "";
            }
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
        protected void LoginToSuM(object sender, EventArgs e)
        {
            SuMLoginPross();
        }
        protected private void SuMLoginPross()
        {
            SuMAdminMSG.InnerText = "";
            object AID_OBJ = SuMAdminKEY.Text;//Daily Generated Admin-Login-Key (for extra security)
            object ACC_OBJ = SuMAdminCC.Text;//Admin(Worker) Privat Key
            if (AID_OBJ == null || ACC_OBJ == null)
            {
                SuMAdminMSG.InnerText = "enter the administration key and confirmation code";
            }
            string AID = AID_OBJ.ToString();
            string ACC = ACC_OBJ.ToString();
            string DGAID = "DEBUGINGKEY";//(place holder) a key will be givn to workers evryday (shared key)
            if (AID != DGAID)
            {
                SuMAdminMSG.InnerText = "invalid inputs";
                SuMAdminKEY.Text = "";
                SuMAdminCC.Text = "";
            }
            else
            {
                int ACC_SBS = ACCIsValid(ACC);
                if (ACC_SBS > 0)
                {
                    SaveCookie(ACC_SBS, ACC, AID);
                }
                else
                {
                    SuMAdminMSG.InnerText = "invalid inputs";
                    SuMAdminKEY.Text = "";
                    SuMAdminCC.Text = "";
                }
            }
        }
        protected private int ACCIsValid(string ACC)
        {
            if(string.IsNullOrEmpty(ACC)) return 0;
            object Res;
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;
            using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))
            {
                MySqlCon.Open();
                string query = "SELECT ID FROM SuMAdmins WHERE AK = @AK ";
                MySqlCommand MySqlCmd = new MySqlCommand(query, MySqlCon);
                MySqlCmd.Parameters.AddWithValue("@AK", sha256(ACC));
                Res = MySqlCmd.ExecuteScalar();
            }
            if (Res == null) return 0;
            if (Convert.ToInt32(Res.ToString()) > 0) return Convert.ToInt32(Res.ToString());
            else return 0;
        }
        protected private void SaveCookie(int ID, string ACC,string AID)
        {
            HttpCookie userInfo = new HttpCookie("SuMAdmin");
            userInfo["ID"] = ID.ToString();
            userInfo["ACC"] = ACC;
            userInfo["AID256"] = sha256(AID);
            userInfo.Expires = DateTime.UtcNow.AddHours(8);//Working time
            HttpContext.Current.Response.Cookies.Add(userInfo);
            HttpContext.Current.Response.Redirect("~/SuMAdmin/AcceptSuMUploads.aspx");
        }
    }
}