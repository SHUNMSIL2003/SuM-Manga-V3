<%@ Page Language="C#" MasterPageFile="~/SuMManga.Master" AutoEventWireup="true" CodeBehind="ContantExplorer.aspx.cs" Inherits="SuM_Manga_V3.storeitems.ContantExplorer" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .ForceMaxW {
            max-width:1200px !important;
            margin: 0 auto;
        }
        .forcecolor {
            color:#6840D9 !important;
        }
    </style>
    <div style="height:fit-content;width:100vw;overflow:hidden; background-color:#ffffff !important;" id="CategoryX" runat="server">
    <div id="infoCover" runat="server" class="mySlides" style="overflow: hidden; background-image:linear-gradient(rgba(0, 0, 0, 0.527),rgba(0, 0, 0, 0.3)) , url(/SlideShowCards/BlueExorcist.jpg); background-size: cover; background-position: center;width:100vw !important;height:fit-content;">
    <h1 id="MTitle" runat="server" style="float:left;margin-top:12px;margin-left:12px;color:#ffffff;font-size:186%;margin-right:14px !important;">Blue Exorcist</h1>
    <p style="height:fit-content;min-height:96vw !important; width:96vw;max-width:96vw;font-size:96%;color:#ffffff;margin:14px !important;" id="MdiscS" runat="server"></p>
</div>
</div>
    <div style="display:inline-block;" id="TheMangaPhotosF" runat="server">
        </div>
</asp:Content>