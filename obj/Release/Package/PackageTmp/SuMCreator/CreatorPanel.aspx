<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.Master" AutoEventWireup="true" CodeBehind="CreatorPanel.aspx.cs" Inherits="SuM_Manga_V3.SuMCreator.CreatorPanel" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        if ("androidAPIs" in window) {
            androidAPIs.SemiTranStatusBar();
        }
    </script>
    <p style="color:rgba(0,0,0,0.92);font-size:300%;width:100%;text-align:center;margin-top:36vh;">Coming soon!</p>
</asp:Content>