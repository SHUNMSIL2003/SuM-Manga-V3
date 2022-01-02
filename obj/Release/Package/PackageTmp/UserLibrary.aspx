<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.Master" AutoEventWireup="true" CodeBehind="UserLibrary.aspx.cs" Inherits="SuM_Manga_V3.UserLibrary" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="overflow:clip !important;height:100vh;">
    <div class="fadeInDown animated" style="width:100vw;height:36px;background-color:rgb(242,242,242);text-align:center;padding-top:6px;padding-bottom:2px;">
        <a class="" id="cr" style="margin-left:3px;color:#636166;" runat="server" onclick="if (!navigator.onLine) { fetch('/UserLibrary.aspx?RT=Curr', { method: 'GET' }).then(res => { location.href = '/UserLibrary.aspx?RT=Curr'; }).catch(err => { document.getElementById('Offline').style.display = 'block'; }); } else { location.href = '/UserLibrary.aspx?RT=Curr'; }" href="#"><b style="font-size:90%">Currently   </b></a>
        <a class="" id="mf" runat="server" style="margin-right:3px;margin-left:3px;color:#1d1d1d;" onclick="if (!navigator.onLine) { fetch('/UserLibrary.aspx?RT=Fav', { method: 'GET' }).then(res => { location.href = '/UserLibrary.aspx?RT=Fav'; }).catch(err => { document.getElementById('Offline').style.display = 'block'; }); } else { location.href = '/UserLibrary.aspx?RT=Fav'; }" href="#"><b style="font-size:90%">  Favorites  </b></a>
        <a class="" id="wr" runat="server" style="margin-right:3px;color:#1d1d1d;" onclick="if (!navigator.onLine) { fetch('/UserLibrary.aspx?RT=Wanna', { method: 'GET' }).then(res => { location.href = '/UserLibrary.aspx?RT=Wanna'; }).catch(err => { document.getElementById('Offline').style.display = 'block'; }); } else { location.href = '/UserLibrary.aspx?RT=Wanna'; }" href="#"><b style="font-size:90%">   Want To</b></a>
    </div>
    <div class="animated fadeIn" id="ShowReqContant" style="height:86vh !important;overflow-y:scroll !important;overflow-x:clip;" runat="server">
    </div>
    </div>
</asp:Content>