<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.Creator.Master" AutoEventWireup="true" CodeBehind="SuMManualPuplish.aspx.cs" Inherits="SuM_Manga_V3.SuMAdmin.SuMManualPuplish" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox Text="Creator Name" runat="server" ID="SuMCreatorPuplishNameTXT" />
    <asp:Button Text="Puplish" runat="server" OnClick="PuplishStart" />
</asp:Content>