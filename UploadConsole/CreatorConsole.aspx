<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.Master" AutoEventWireup="true" CodeBehind="CreatorConsole.aspx.cs" Inherits="SuM_Manga_V3.UploadConsole.CreatorConsole" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width:100%;height:84px;text-align:center;background-color:var(--SuMDGray);">
        <a id="upl" runat="server" style="color:var(--SuMThemeColor);margin-left:12px;">Uploads</a>
        <a id="dra" runat="server" style="color:#636166;">Drafs</a>
        <a id="inp" runat="server" style="color:#636166;margin-right:12px;">In Prosses</a>
    </div>
    <div id="CreatorMainContant" runat="server">

    </div>
    <div style="text-align:center;width:100%;height:fit-content;">
        <a id="ADDB" runat="server" href="#" style="background-color:var(--SuMThemeColor);color:var(--SuMDWhite);border-radius:16px;height:fit-content;width:fit-content;font-size:160%;"><b>+</b></a>
    </div>
</asp:Content>