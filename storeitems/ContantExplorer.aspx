<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.Master" AutoEventWireup="true" CodeBehind="ContantExplorer.aspx.cs" Inherits="SuM_Manga_V3.storeitems.ContantExplorer" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .ForceMaxW {
            max-width:1200px !important;
            margin: 0 auto;
        }
        .forcecolor {
            color:#6840D9 !important;
        }
    </style><div class="bounce animated">
    <div style="height:fit-content;width:100vw;overflow:hidden; background-color:#ffffff !important;" id="CategoryX" runat="server">
    <div id="infoCover" runat="server" class="mySlides" style="overflow: hidden; background-image:linear-gradient(rgba(0, 0, 0, 0.527),rgba(0, 0, 0, 0.3)) , url(/SlideShowCards/BlueExorcist.jpg); background-size: cover; background-position: center;width:100vw !important;height:fit-content;max-height:864px !important;position:relative;">
    <h1 id="MTitle" runat="server" style="float:left;margin-top:12px;margin-left:12px;color:#ffffff;font-size:186%;margin-right:14px !important;">Blue Exorcist</h1>
    <p style="height:fit-content;min-height:60vw !important; width:96vw;max-width:96vw;font-size:96%;color:#ffffff;margin:14px !important;" id="MdiscS" runat="server"></p>
        <div id="GernsTags" runat="server" style="bottom:0 !important;width:100%;height:fit-content;background-color:transparent;align-content:center;justify-content:center;padding:8px;align-content:center;text-align:center !important;">
            <div style="margin-left:6px;display:inline;width:fit-content;height:38px;background-color:rgba(0,0,0,0.36);border-radius:19px;"><a href="/storeitems/TagView.aspx" style="color:white;font-size:112%;">&nbsp;&nbsp;&nbsp;Action&nbsp;&nbsp;&nbsp;</a></div>
        </div>
</div>
</div><!-- aos-init aos-animate" data-aos="zoom-in" -->
    <div style="display:inline-block;height:100vh !important;min-height:100% !important;background-color:rgba(1,65,54,0.544);" id="TheMangaPhotosF" runat="server">
        </div><!--
    <hr style="height:1.6px;border-width:0;color:#ffffff;background-color:#ffffff;width:100vw;opacity:0.76;margin:0px;margin-block:0px;"> -->
    </div>
</asp:Content>
