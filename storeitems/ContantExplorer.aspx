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
    <div style="background-color:#6840D9;border-color:#6840D9;border-radius:8px;padding:8px;width:auto;margin-left:-12px;margin-right:-12px;height:fit-content;overflow: hidden;">
                <h6 style="color:#ffffff;padding-left:8px;width:fit-content;" id="MangaViewsAndChapters" runat="server"></h6>
        <div style="width:100%;height:auto;vertical-align:middle;align-items:center;padding:2px;">
             <div style="height:fit-content;width:22vw;height:auto; display:inline-block;max-width:180px;float:left;vertical-align:middle;">
                <img class="lazyload" id="cover" runat="server" style="width:22vw;height:33vw; max-width:186px;max-height:279px;border-radius:8px;vertical-align:middle;align-items:center;display:block;margin-bottom:8px;" loading="lazy" src="#" />
             </div>
        <div style="display:inline-block;width:54vw;text-align:center;height:fit-content;max-width:900px;float:right;">
                <p style="color:rgb(255 255 255 / 0.85);display:block;" id="MangaDis" runat="server"></p>
                </div>
            </div>
</div>
<br />
        <div style="display:inline-block;" id="TheMangaPhotos" runat="server">
        </div>
        <br /><br />
   </div>
        </div>
</asp:Content>