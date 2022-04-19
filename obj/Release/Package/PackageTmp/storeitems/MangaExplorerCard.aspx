<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.card.Master" AutoEventWireup="true" Async="true" CodeBehind="MangaExplorerCard.aspx.cs" Inherits="SuM_Manga_V3.storeitems.MangaExplorerCard" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="ScriptInjectorC000" style="display:none !important;visibility:hidden !important;"></div>
    <div style="width:100vw !important;height:100vh !important;display:block !important;overflow-x:hidden !important;overflow-y:scroll !important;">
        <div class="" id="TheMangaPhotos" runat="server" style="width:100% !important;height:fit-content !important;margin:0 auto !important;padding:0px !important;border-radius:0px !important;border:none;margin:0 auto !important;padding:0 !important;">

        </div>
    </div>
    <div class="animated fadeIn" id="NextChapter" style="display:block;position:fixed !important;bottom:0 !important;z-index:996 !important;margin-left:calc(100vw - 174px);margin-bottom:18px !important;-webkit-transition: all 0.5s; -moz-transition: all 0.5s; -ms-transition: all 0.5s; -o-transition: all 0.5s; transition: all 0.5s;" runat="server" >
                <a style="" class="btn btn-primary btn-sm animated shadow-sm fadeInUp" href="#"></a>
    </div>
</asp:Content>