<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.Master" AutoEventWireup="true" CodeBehind="OfflineBETA.aspx.cs" Inherits="SuM_Manga_V3.OfflineBETA" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body {
            overflow: hidden; /* Hide scrollbars */
        }
        /* Hide scrollbar for Chrome, Safari and Opera */
        ::-webkit-scrollbar {
            display: none;
        }

        /* Hide scrollbar for IE, Edge and Firefox */
        body {
            -ms-overflow-style: none; /* IE and Edge */
            scrollbar-width: none; /* Firefox */
        }
        img {
            pointer-events: none;
        }
    </style>
                    <div class="text-center mt-5">
                             <div class="error mx-auto" data-text="404">
                                 <p class="m-0">404</p>
                             </div>
                             <p class="text-dark mb-5 lead">Our APP can't work offline!, Plz connect to network.</p>
                    </div>
</asp:Content>