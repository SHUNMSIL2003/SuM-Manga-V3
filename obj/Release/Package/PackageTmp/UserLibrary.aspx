<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.Master" AutoEventWireup="true" CodeBehind="UserLibrary.aspx.cs" Inherits="SuM_Manga_V3.UserLibrary" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="overflow:clip !important;height:100vh;">
    <div class="fadeInDown animated" style="width:100vw;height:36px;background-color:rgb(242,242,242);text-align:center;padding-top:6px;padding-bottom:2px;">
        <a class="" id="cr" style="margin-left:3px;color:#636166;" runat="server" href="/UserLibrary.aspx?RT=Curr"><b style="font-size:90%">Currently   </b></a>
        <a class="" id="mf" runat="server" style="margin-right:3px;margin-left:3px;color:#1d1d1d;" href="/UserLibrary.aspx?RT=Fav"><b style="font-size:90%">  Favorites  </b></a>
        <a class="" id="wr" runat="server" style="margin-right:3px;color:#1d1d1d;" href="/UserLibrary.aspx?RT=Wanna"><b style="font-size:90%">   Want To</b></a>
    </div>
    <div class="animated fadeIn" id="ShowReqContant" style="height:86vh !important;overflow-y:scroll !important;overflow-x:clip;" runat="server">
    </div>
    </div>
</asp:Content>