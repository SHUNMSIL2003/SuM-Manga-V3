<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.card.Master" AutoEventWireup="true" CodeBehind="ContantExplorerCard.aspx.cs" Async="true" Inherits="SuM_Manga_V3.storeitems.ContantExplorerCard" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="display:none !important;visibility:hidden !important;" id="ScriptInjectorB000" runat="server"></div>
    <asp:Button ID="LoadMOreChapters" OnClick="LOADMORECHAPTERS" runat="server" style="display:none;visibility:hidden;" />
            <div id="MangaChAMConta" style="display:block;height:fit-content;min-height:100vh !important;background-color:transparent !important;padding-bottom:164px !important;" runat="server">
            <asp:UpdatePanel ID="LoadChapters" runat="server" UpdateMode="Conditional" >
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="LoadMOreChapters" />
                </Triggers>
                <ContentTemplate>
                    <asp:Panel runat="server">
                        <div id="TheMangaPhotosF" style="width:100%;height:fit-content;background-color:transparent;padding:8px !important;padding-top:14px !important;" runat="server">
                        </div>
                        <a id="ThreIsMoreACard" onclick="document.getElementById('MainContent_LoadMOreChapters').click(); return false;" runat="server" style="width:100%;height:fit-content;text-align:center !important;margin:0 auto !important;display:block;padding-bottom:130px !important;padding-top:60px !important;" >
                            <p style="color:#FFFFFFEB !important;width:100%;text-align:center !important;margin:0 auto !important;font-size:92%;"><b style="color:#FFFFFFEB;">Tap anywhere for more</b></p>
                            <img src="/svg/expandmore.svg" style="width:46px;height:46px;margin:0 auto !important;margin-top:8px !important;margin-top:-12px !important;" />
                        </a>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
            </div>
</asp:Content>