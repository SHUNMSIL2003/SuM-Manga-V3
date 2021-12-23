using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;

namespace SuM_Manga_V3.UploadConsole
{
    public partial class PuplishManga : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void PuplishStart(object sender, EventArgs e)
        {
            string MangaName = MangaNameP.Text;
            string MangaDisc = MangaDescP.Text;
            string MangaAuthor = MangaAuthorP.Text;
            int ChaptersNum = Convert.ToInt32(ChaptersNumP.Text.ToString());
            int MangaViews = 0;
            int id = Convert.ToInt32(ID.Text.ToString());
            Bitmap bmpPostedImage = new Bitmap(SuMCustomPic.PostedFile.InputStream);
            string ThemeColor = RgbConverter(getDominantColor(bmpPostedImage));
            string MangaFolderName = MangaNameFolder.Text;
            string CExplorerLink = "/storeitems/ContantExplorer.aspx?Manga=" + MangaFolderName;
            string MangaCoverLink = "/storeitems/" + MangaFolderName + "/" + CoverLink.Text;
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))//Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=P:\Shun-MuS-Projct\App_Data\SuMAccounts.mdf; Integrated Security=True
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("INSERT INTO SuMManga(MangaInfo,MangaCreator,MangaName,MangaViews,SuMThemeColor,MangaCoverLink,ChaptersNumber,CExplorerLink) values(@MangaInfo,@MangaCreator,@MangaName,@MangaViews,@SuMThemeColor,@MangaCoverLink,@ChaptersNumber,@CExplorerLink)", sqlCon);
                sqlCmd.Parameters.AddWithValue("@MangaInfo", MangaDisc);
                sqlCmd.Parameters.AddWithValue("@MangaCreator", MangaAuthor);
                sqlCmd.Parameters.AddWithValue("@MangaName", MangaName);
                sqlCmd.Parameters.AddWithValue("@MangaViews", SqlDbType.Int);
                sqlCmd.Parameters["@MangaViews"].Value = MangaViews;
                sqlCmd.Parameters.AddWithValue("@SuMThemeColor", ThemeColor);
                sqlCmd.Parameters.AddWithValue("@MangaCoverLink", MangaCoverLink);
                sqlCmd.Parameters.AddWithValue("@ChaptersNumber", SqlDbType.Int);
                sqlCmd.Parameters["@ChaptersNumber"].Value = ChaptersNum;
                sqlCmd.Parameters.AddWithValue("@CExplorerLink", CExplorerLink);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        protected static string RgbConverter(Color c)
        {
            return String.Format("rgba({0},{1},{2},0.74)", c.R, c.G, c.B);
        }
        protected static Color getDominantColor(Bitmap bmp)
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
    }
}