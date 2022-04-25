using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace SuM_Manga_V3
{
    public partial class _0000PortingDataBase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int[] IDs = new int[18];
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                string query = "SELECT TOP 18 MangaID from SuMManga order by MangaID desc";
                SqlCommand MySqlCmd = new SqlCommand(query, sqlCon);
                Queue<int> RawIDs = new Queue<int>();
                using (var reader = MySqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        RawIDs.Enqueue(Convert.ToInt32(reader[0].ToString()));
                    }
                }
                int IDHELPER = 0;
                while (RawIDs.Count > 0)
                {
                    IDs[IDHELPER] = RawIDs.Dequeue();
                    IDHELPER++;
                }
                sqlCon.Close();
            }
            object[] MangaName = CopyThis(IDs, "MangaName");
            object[] CExplorerLink = CopyThis(IDs, "CExplorerLink");
            object[] MangaAgeRating = CopyThis(IDs, "MangaAgeRating");
            object[] MangaCreator = CopyThis(IDs, "MangaCreator");
            object[] MangaViews = CopyThis(IDs, "MangaViews");
            object[] ChaptersNumber = CopyThis(IDs, "ChaptersNumber");
            object[] MangaCoverLink = CopyThis(IDs, "MangaCoverLink");
            object[] SuMThemeColor = CopyThis(IDs, "SuMThemeColor");
            object[] MangaInfo = CopyThis(IDs, "MangaInfo");
            object[] Fantasy = CopyThis(IDs, "Fantasy");
            object[] Comedy = CopyThis(IDs, "Comedy");
            object[] Supernatural = CopyThis(IDs, "Supernatural");
            object[] SciFi = CopyThis(IDs, "SciFi");
            object[] Drama = CopyThis(IDs, "Drama");
            object[] Mystery = CopyThis(IDs, "Mystery");
            object[] SliceofLife = CopyThis(IDs, "SliceofLife");
            object[] Action = CopyThis(IDs, "Action");
            object[] ChapterCValue = CopyThis(IDs, "ChapterCValue");
            object[] LastUpdateDate = CopyThis(IDs, "LastUpdateDate");
            string SuMMangaExternalDataBase = ConfigurationManager.ConnectionStrings["SuMMangaExternalDataBase"].ConnectionString;
            using (MySqlConnection MySqlCon = new MySqlConnection(SuMMangaExternalDataBase))//Data Source=(LocalDB)\MSMySqlLocalDB;AttachDbFilename=P:\Shun-MuS-Projct\App_Data\SuMAccounts.mdf; Integrated Security=True
            {
                MySqlCon.Open();
                for (int i = 0; i < 18; i++)
                {
                    MySqlCommand MySqlCmd = new MySqlCommand("INSERT INTO SuMManga(MangaName,CExplorerLink,MangaAgeRating,MangaCreator,MangaViews,ChaptersNumber,MangaCoverLink,SuMThemeColor,MangaInfo,Fantasy,Comedy,Supernatural,SciFi,Drama,Mystery,SliceofLife,Action,ChapterCValue,LastUpdateDate) values('" + MangaName[i] + "','" + CExplorerLink[i] + "','" + MangaAgeRating[i] + "','" + MangaCreator[i] + "'," + MangaViews[i] + "," + ChaptersNumber[i] + ",'" + MangaCoverLink[i] + "','" + SuMThemeColor[i] + "',"+ '"' + MangaInfo[i].ToString().Replace('"',' ') +'"'+"," + Fantasy[i] + "," + Comedy[i] + "," + Supernatural[i] + "," + SciFi[i] + "," + Drama[i] + "," + Mystery[i] + "," + SliceofLife[i] + "," + Action[i] + "," + ChapterCValue[i] + "," + LastUpdateDate[i] + ");", MySqlCon);
                    MySqlCmd.ExecuteNonQuery();
                }
                MySqlCon.Close();
            }
            Response.Redirect("~/Tr-Test-SuT.html");
        }
        private object[] CopyThis(int[] IDs, string ThisToCopy)
        {
            object[] This = new object[18];
            using (SqlConnection sqlCon = new SqlConnection(@"Server=tcp:summanga.database.windows.net,1433;Initial Catalog=summangasqldatabase;Persist Security Info=False;User ID=summangasqladmin;Password=55878833sqlpass#S;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                sqlCon.Open();
                for (int i = 0; i < 18; i++)
                {
                    string queryRGB = "SELECT " + ThisToCopy + " FROM SuMManga WHERE MangaID = @MangaID";
                    SqlCommand MySqlCmdRGB = new SqlCommand(queryRGB, sqlCon);
                    MySqlCmdRGB.Parameters.AddWithValue("@MangaID", SqlDbType.Int);
                    MySqlCmdRGB.Parameters["@MangaID"].Value = IDs[i];
                    This[i] = MySqlCmdRGB.ExecuteScalar();
                }
                sqlCon.Close();
            }
            return This;
        }
    }
}