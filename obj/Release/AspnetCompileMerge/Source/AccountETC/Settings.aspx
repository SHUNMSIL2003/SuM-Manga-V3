<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="SuM_Manga_V3.AccountETC.Settings" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        a {
            pointer-events: all;
        }
    </style>
    <div style="height:100%;width:100%; padding:0px !important;padding-top:8px !important;padding-bottom:8px !important; background-color:#f2f2f2 !important;margin:0 auto !important; margin-top:0px !important;">
        <div style="background-color:#ffffff !important;border-radius:0px !important; padding: 4px !important;margin-top:12px !important; margin-bottom:12px !important;">
            <a href="/AccountETC/SuMAccount.aspx" style="height:fit-content !important;width:100vw !important;background-color:transparent !important;display:block !important;margin-top:8px;margin-bottom:8px; margin-left:8px;">
            <img class="flash animated" id="PFP" runat="server" style="width:84px !important;height:84px !important;border-radius:50% !important;float:left;display:inline;margin-bottom:6px;" src="/AccountETC/UsersUploads/DeafultPFP.jpg" />
                <div class="flash animated" style="float:left;display:inline;margin-left:8px;">
                    <h3 id="SuMUserName" runat="server" style="color:#1d1d1d;">Loging to SuM</h3>
                    <h6  id="SignedWith" runat="server" style="color:#919191;font-size:74%;"></h6>
                </div>
            </a>
            <asp:ImageButton ID="LogOutBTN" runat="server" ImageUrl="/svg/logout.svg" Width="28px" Height="28px" BackColor="Transparent" ForeColor="Transparent" OnClick="LogOut" style="float:right !important;margin-right:8px;margin-top:58px !important;" />
        </div>
        <div style="background-color:#ffffff !important;border-radius:0px !important; padding: 12px !important;margin-top:8px !important;">
                                <div style="vertical-align:middle;display:block !important;">
                                    <img src="/AccountETC/DarkMoon.svg" style="width:auto;height:32px;display:inline;float:left;" />
                                    <p style="color:#000000;display:inline;float:left;margin:8px;">Enable Dark Mode</p>
                                    <div class="form-check form-switch" style="display:inline;width:auto;height:32px;float:right;"><input class="form-check-input" style="display:inline;width:38px;height:18px;float:right;" type="checkbox" id="DarkModeS" runat="server"></div>
                                    <p style="font-size:60%;color:#808080;float:left;margin-left:36px;">Change SuM Theme to dark shades of color, This option is not recommended!</p>
                                </div>
            <div  style="vertical-align:middle;display:block !important;margin-top:12px !important;">
        <img src="/AccountETC/Noti.svg" style="width:auto;height:32px;display:inline;float:left;" />
        <p style="color:#1d1d1d;display:inline;float:left;margin:8px;">Get The latest</p>
        <div class="form-check form-switch" style="display:inline;width:auto;height:32px;float:right;"><input class="form-check-input" style="display:inline;width:36px;height:18px;float:right;" type="checkbox" id="Checkbox1" runat="server"></div>
               <p style="font-size:60%;color:#808080;float:left;margin-left:36px;">Get The latest News about mangas in general</p>
            </div>
        <div style="background-color:#ffffff !important;border-radius:0px !important; padding: 4px !important;margin-top:6px !important;margin-top:12px;">
        </div>
    </div>
        </div>
</asp:Content>