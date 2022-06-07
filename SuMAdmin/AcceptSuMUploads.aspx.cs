using System;
using System.Web;
using System.Text;

namespace SuM_Manga_V3.SuMAdmin
{
    public partial class AcceptSuMUploads : System.Web.UI.Page
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

            string epath = System.IO.Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            string ActivePath = epath + "\\SuMCreator\\CreatorsDrafts\\";
            string[] filePaths = System.IO.Directory.GetFiles(ActivePath, "*.xml");
            string filename = string.Empty;
            ReqsDiv.InnerHtml = "";
            for (int i = 0; i < (filePaths.Length); i++)
            {
                filename = System.IO.Path.GetFileName(filePaths[i]);
                ReqsDiv.InnerHtml += "<a style="+'"'+ "display:block;height:fit-content;width:fit-content;padding:12px;margin:0 auto;margin-top:12px;background:rgba(255, 255, 255, 0.64);font-size:112%;color:rgb(0,0,0);border-radius:12px;" + '"'+" href=" + '"' + "/SuMAdmin/SuMManualPuplish.aspx?PuplishProfile=" + filename + '"' + " >" + filename + "</a>";
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
    }
}