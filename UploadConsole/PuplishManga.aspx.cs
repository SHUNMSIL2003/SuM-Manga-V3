using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace SuM_Manga_V3.UploadConsole
{
    public partial class PuplishManga : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected private void PuplishStart(object sender, EventArgs e)
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
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;
            using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))//Data Source=(LocalDB)\MSMySqlLocalDB;AttachDbFilename=P:\Shun-MuS-Projct\App_Data\SuMAccounts.mdf; Integrated Security=True
            {
                MySqlCon.Open();
                MySqlCommand MySqlCmd = new MySqlCommand("INSERT INTO SuMManga(MangaInfo,MangaCreator,MangaName,MangaViews,SuMThemeColor,MangaCoverLink,ChaptersNumber,CExplorerLink) values(@MangaInfo,@MangaCreator,@MangaName,@MangaViews,@SuMThemeColor,@MangaCoverLink,@ChaptersNumber,@CExplorerLink)", MySqlCon);
                MySqlCmd.Parameters.AddWithValue("@MangaInfo", MangaDisc);
                MySqlCmd.Parameters.AddWithValue("@MangaCreator", MangaAuthor);
                MySqlCmd.Parameters.AddWithValue("@MangaName", MangaName);
                MySqlCmd.Parameters.AddWithValue("@MangaViews", SqlDbType.Int);
                MySqlCmd.Parameters["@MangaViews"].Value = MangaViews;
                MySqlCmd.Parameters.AddWithValue("@SuMThemeColor", ThemeColor);
                MySqlCmd.Parameters.AddWithValue("@MangaCoverLink", MangaCoverLink);
                MySqlCmd.Parameters.AddWithValue("@ChaptersNumber", SqlDbType.Int);
                MySqlCmd.Parameters["@ChaptersNumber"].Value = ChaptersNum;
                MySqlCmd.Parameters.AddWithValue("@CExplorerLink", CExplorerLink);
                MySqlCmd.ExecuteNonQuery();
                MySqlCon.Close();
            }
        }
        protected private static string RgbConverter(Color c)
        {
            return String.Format("rgba({0},{1},{2},0.74)", c.R, c.G, c.B);
        }
        protected private static Color getDominantColor(Bitmap bmp)
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