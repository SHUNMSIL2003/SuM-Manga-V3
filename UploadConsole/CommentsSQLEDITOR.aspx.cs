using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace SuM_Manga_V3.UploadConsole
{
    public partial class CommentsSQLEDITOR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*string chxxxx = string.Empty;
            string q = string.Empty;
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                for (int c = 1; c < 1000; c++)
                {
                    string ChapterFixedForm = string.Empty;
                    string chxC = c.ToString();
                    if (c < 10 && c > 0) { ChapterFixedForm = "000" + chxC; }
                    if (c > 9 && c < 100) { ChapterFixedForm = "00" + chxC; }
                    if (c > 99 && c < 1000) { ChapterFixedForm = "0" + chxC; }
                    if (c > 999 && c < 10000) { ChapterFixedForm = chxC; }
                    chxxxx = "ch" + ChapterFixedForm;
                    q = "ALTER TABLE SuMMangaComments ADD " + chxxxx + " NVARCHAR(MAX) NULL";
                    cmd = new SqlCommand(q, sqlCon);
                    cmd.ExecuteNonQuery();
                    res.InnerHtml += "<a style=font-size:100%; > ALTER TABLE SuMMangaComments ADD " + chxxxx + " NVARCHAR(MAX) NULL </a>";
                }
                sqlCon.Close();
            }
            res.InnerHtml = "<a style=font-size:300%; >Done!</a>";*/
        }
    }
}