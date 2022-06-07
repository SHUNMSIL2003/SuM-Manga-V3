<%@ Page Language="C#" MasterPageFile="~/SuMManga.Admin.Master" AutoEventWireup="true" CodeBehind="SuMManualChapterPuplish.aspx.cs" Inherits="SuM_Manga_V3.SuMAdmin.SuMManualChapterPuplish" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div runat="server" id="SuMThemeBox" style="background:rgb(0,0,0,0.74);padding:12px;width:100%;text-align:center !important;height:fit-content;min-height:100vh;">
        <p style="width:100%;height:fit-content;color:white;font-size:120%;text-align:center;margin:0 auto;margin-top:12px;" runat="server" id="REQIDELM">REQ:ID</p>
        <div style="margin:0 auto;margin-top:12px;padding:12px;border-radius:12px;background:rgba(255,255,255,0.92);height:fit-content;width:fit-content;text-align:center;">
            <p style="color:black;font-size:92%;">Manga Age Rating:</p>
            <p style="color:black;font-size:118%;" runat="server" id="MangaAgeRatingPELM">Manga Age Rating</p>
        </div>
        <div style="margin:0 auto;margin-top:12px;padding:12px;border-radius:12px;background:rgba(255,255,255,0.92);height:fit-content;width:fit-content;text-align:center;">
            <p style="color:black;font-size:92%;">Chapter Cover:</p>
            <img src="#" onerror="this.style.display='none';return false;" id="MangaCoverELM" runat="server" style="width:calc(100% - 24px);max-width:420px !important;margin:0 auto;height:auto;border-radius:12px;" onclick="UploadHiddenBTNHelpterF6C0.click();" />
        </div>
        <div style="margin:0 auto;margin-top:12px;padding:12px;border-radius:12px;background:rgba(255,255,255,0.92);height:fit-content;width:fit-content;text-align:center;">
            <p style="color:black;font-size:92%;">Chapter pages:</p>
            <div id="ChapterPagesC" runat="server" style="width:fit-content;height:fit-content;margin:0 auto;text-align:center;border-radius:12px;">
                <img src="#" class="" style="width:calc(100% - 24px);max-width:420px !important;margin:0 auto;height:auto;" />
            </div>
        </div>
        <div style="margin:0 auto;margin-top:12px;height:fit-content;padding:24px;text-align:center;text-align:center;">
            <div style="height:fit-content;width:fit-content;margin:0 auto;">
                <asp:Button Text="Publish" style="color:Black;background-color:White;border-color:White;height:fit-content;width:124px;border-radius:12px;text-align:center;border:0;padding:6px;" runat="server" OnClick="PuplishStart" />
                <asp:Button Text="Reject" style="color:Black;background-color:White;border-color:White;height:fit-content;width:118px;border-radius:12px;text-align:center;border:0;padding:6px;" runat="server" OnClick="RejectStart" />
            </div>
        </div>
    </div>
</asp:Content>