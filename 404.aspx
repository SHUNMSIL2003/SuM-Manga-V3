<%@ Page Language="C#" MasterPageFile="~/SuMManga.Master" AutoEventWireup="true" CodeBehind="404.aspx.cs" Inherits="SuM_Manga_V3._404" %>

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
                             <p class="text-dark mb-5 lead">Page Not Found</p>
                             <p class="text-black-50 mb-0">The Server might be down or you may have found a glitch in the matrix...</p><a id="A1" href="../Explore.aspx" style="color: rgb(104,64,217);border-color: rgb(104,64,217);" runat="server">← Back to Main Page</a>
                    </div>
</asp:Content>