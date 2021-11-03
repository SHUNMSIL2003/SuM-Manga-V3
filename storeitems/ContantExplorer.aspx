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
        h5 {
            width:14vw !important;
        }
    </style>
    <div class="card shadow ForceMaxW">
         <div class="card-header py-3">
          <p style="color:#6840D9;" id="MainCardT" runat="server" class="text-primary m-0 fw-bold forcecolor">SuM - About Us</p>
           </div>
<div class="card-body">
                  <br />
    <div style="background-color:#6840D9;border-color:#6840D9;border-radius:8px;padding:12px;width:100%;">
                <h4 style="color:#ffffff;padding-left:8px;width:fit-content;" id="MangaViewsAndChapters" runat="server"></h4><br />
        <div style="width:100%;">
            <div style="height:fit-content;width:20vw;height:20vw; display:inline;">
                <img id="cover" runat="server" style="width:20vw;height:30vw; max-width:174px;max-height:260px;border-radius:8px;" loading="lazy" src="#" />
            </div>
        <div style="display:inline;width:50vw;text-align:center;height:30vw;float:right;">
                <p style="color:rgb(255 255 255 / 0.85);display:inline;" id="MangaDis" runat="server"></p>
                </div>
            </div>
</div>
<br />
        <div style="display:inline;" id="TheMangaPhotos" runat="server"></div>
        <br /><br />
   </div>
        </div>
</asp:Content>