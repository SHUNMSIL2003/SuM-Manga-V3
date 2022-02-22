using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuM_Manga_V3.SuMAdmin
{
    public partial class AcceptSuMUploads : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string epath = System.IO.Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            string ActivePath = epath + "\\SuMCreator\\CreatorsDrafts\\";
            string[] filePaths = System.IO.Directory.GetFiles(ActivePath, "*.xml");
            string filename = string.Empty;
            for (int i = 0; i < (filePaths.Length); i++)
            {
                filename = System.IO.Path.GetFileName(filePaths[i]);
                ReqsDiv.InnerHtml += "<a href=" + '"' + "/SuMAdmin/SuMManualPuplish.aspx?PuplishProfile=" + filename + '"' + " >" + filename + "</a>";
            }
        }
    }
}