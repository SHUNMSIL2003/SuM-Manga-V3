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
    <div class="card shadow ForceMaxW">
         <div class="card-header py-3">
          <p style="color:#6840D9;" id="MainCardT" runat="server" class="text-primary m-0 fw-bold forcecolor">SuM - About Us</p>
           </div>
<div class="card-body">
                  <br />
                <h4 style="color:#6840D9;padding-left:8px;" id="MangaViewsAndChapters" runat="server"></h4>
            <div style="height:fit-content;width:100%;display:inline;">
                <img id="cover" runat="server" style="width:174px;height:260px;border-radius:16px;border:solid 2px #6840D9;" loading="lazy" src="#" />
                
                <h5 style="color:#1a171c;padding-left:8px;display:inline;width:calc(100%-180px);" id="MangaDis" runat="server"></h5>
                
        
            </div>
</div>
<br />
        <div style="display:inline;" id="TheMangaPhotos" runat="server"></div>
        <br /><br />
   </div>
</asp:Content>