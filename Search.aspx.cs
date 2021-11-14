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
            /*HttpCookie GetUserInfoCookie = Request.Cookies["SuMCurrentUserSH"];
            if (GetUserInfoCookie != null)
            {

            }
            else
            {
                SStartCookie();
            }*/
            //@SerchTextBox.TextBoxFor(m => m.searchText, new { @class = "searchBox", @id = "azureautosuggest" }) < input value = "" class="searchBoxSubmit" type="submit">

        }/*
        protected static void EditCookie(string NewS)
        {
            HttpCookie userInfo = HttpContext.Current.Request.Cookies["SuMCurrentUserSH"];
            userInfo["SH"] += NewS;
            userInfo.Expires = DateTime.MaxValue;
            HttpContext.Current.Response.Cookies.Add(userInfo);
        }
        protected static string[] GetCookieSHContant(string NewS)
        {
            HttpCookie userInfo = HttpContext.Current.Request.Cookies["SuMCurrentUserSH"];
            string sh = userInfo["SH"].ToString();
            char[] C = sh.ToCharArray();
            for (int i = 0; i < C.Length; i++) 
            {
                if (C[i] == '#' && C[i + 1] == 'K') 
                {

                }
            }
            userInfo.Expires = DateTime.MaxValue;
            HttpContext.Current.Response.Cookies.Add(userInfo);
        }
        protected static void SStartCookie()
        {
            HttpCookie userInfo = new HttpCookie("SuMCurrentUserSH");  //Request.Cookies["userInfo"].Value;  
            //userInfo.Expires.Add(new TimeSpan(4, 1, 0));
            userInfo.Expires = DateTime.MaxValue;
            HttpContext.Current.Response.Cookies.Add(userInfo);
        }*/
    }
}