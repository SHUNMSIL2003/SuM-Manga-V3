<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.Master" AutoEventWireup="true" CodeBehind="PuplishManga.aspx.cs" Inherits="SuM_Manga_V3.UploadConsole.PuplishManga" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="fadeIn animated">
    <div style="height:fit-content;width:100vw;overflow:hidden; background-color:#ffffff !important;" id="CategoryX" runat="server">
    <div id="infoCover" runat="server" class="mySlides" style="overflow: hidden; background-image:linear-gradient(rgba(104,64,217,0.84),rgba(0, 0, 0, 0.3)) , url(/SlideShowCards/BlueExorcist.jpg); background-size: cover; background-position: center;width:100vw !important;height:fit-content;max-height:864px !important;position:relative;">
    <!--<h1 id="MTitle" runat="server" style="float:left;margin-top:12px;margin-left:12px;color:#ffffff;font-size:186%;margin-right:14px !important;">Blue Exorcist</h1>-->
        <asp:TextBox style="float:left;margin-top:12px;margin-left:12px;color:#ffffff;font-size:186%;margin-right:14px !important;" Text="Manga Name" BackColor="Transparent" BorderColor="White" BorderStyle="Dotted" ID="MangaNameP" runat="server" Height="36px"></asp:TextBox>
    <!--<p style="height:fit-content;min-height:60vw !important; width:96vw;max-width:96vw;font-size:96%;color:#ffffff;margin:14px !important;" id="MdiscS" runat="server"></p>-->
        <asp:TextBox style="height:fit-content;min-height:60vw !important; width:96vw;max-width:96vw;font-size:96%;color:#ffffff;margin:14px !important;" Text="Manga Description" BackColor="Transparent" BorderColor="White" BorderStyle="Dotted" ID="MangaDescP" runat="server"></asp:TextBox>
        <div id="GernsTags" runat="server" style="border-top-left-radius:12px;border-top-right-radius:12px;bottom:0 !important;width:100%;height:fit-content;background-color:rgba(104,64,217,0.84);align-content:center;justify-content:center;padding:8px;align-content:center;text-align:center !important;">
            <div style="margin-left:6px;display:inline;width:fit-content;height:38px;background-color:rgba(225,225,225,0.36);border-radius:19px;"><a href="/storeitems/TagView.aspx" style="color:white;font-size:112%;">&nbsp;&nbsp;&nbsp;Action&nbsp;&nbsp;&nbsp;</a></div>
        </div>
    </div>
    </div>
    <div style="display:inline-block;height:100vh !important;min-height:100% !important;background-color:rgba(104,64,217,0.84);width:100%;" id="TheMangaPhotosF" runat="server">
        <a style="width:100%;color:rgba(225,225,225,0.96);">Chapters Will Apear Here !</a>
        <a> Accent Color Is Auto Piked from the cover !</a>
        <asp:FileUpload onchange="loadFile(event)" CssClass="hide" accept="image/*" AllowMultiple="false" ID="SuMCustomPic" runat="server" HiddenField="true" />
        <asp:TextBox style="float:left;margin-top:12px;margin-left:12px;color:#ffffff;font-size:186%;margin-right:14px !important;" Text="Manga Author" BackColor="Transparent" BorderColor="White" BorderStyle="Dotted" ID="MangaAuthorP" runat="server" Height="36px"></asp:TextBox>
        <asp:TextBox style="float:left;margin-top:12px;margin-left:12px;color:#ffffff;font-size:186%;margin-right:14px !important;" Text="0" BackColor="Transparent" BorderColor="White" BorderStyle="Dotted" ID="ChaptersNumP" runat="server" Height="36px"></asp:TextBox>
        <asp:TextBox style="float:left;margin-top:12px;margin-left:12px;color:#ffffff;font-size:186%;margin-right:14px !important;" Text="CoverNameAndFormat" BackColor="Transparent" BorderColor="White" BorderStyle="Dotted" ID="CoverLink" runat="server" Height="36px"></asp:TextBox>
        <asp:TextBox style="float:left;margin-top:12px;margin-left:12px;color:#ffffff;font-size:186%;margin-right:14px !important;" Text="MangaID" BackColor="Transparent" BorderColor="White" BorderStyle="Dotted" ID="ID" runat="server" Height="36px"></asp:TextBox>
        <asp:TextBox style="float:left;margin-top:12px;margin-left:12px;color:#ffffff;font-size:186%;margin-right:14px !important;" Text="MangaFolder in storeitems" BackColor="Transparent" BorderColor="White" BorderStyle="Dotted" ID="MangaNameFolder" runat="server" Height="36px"></asp:TextBox>
        <asp:Button runat="server" ID="UploadMangaProfile" OnClick="PuplishStart" Text="Puplish" BackColor="White" BorderColor="White" BorderStyle="Dotted" />
     </div>
    </div>
    
</asp:Content>