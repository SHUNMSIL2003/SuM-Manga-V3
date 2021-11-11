using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuM_Manga_V3
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Request.Browser.IsMobileDevice)
                MasterPageFile = "~/SuMManga.Mobile.Master";
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}