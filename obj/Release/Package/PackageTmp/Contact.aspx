<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="SuM_Manga_V3.Contact" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .forcecolor {
            color:#6840D9 !important;
        }
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
    <div class="card shadow ForceMaxW">
                        <div class="card-header py-3">
                            <p class="text-primary m-0 fw-bold forcecolor">SuM - Contact</p>
                        </div>
        <div class="card-body">
<h3>You can reatch to us by what follows.</h3>
    <address>
        Israel<br />
        Kafr Kanna, St 321<br />
        <abbr title="Phone">P:050Z44XY00</abbr>
    </address>
    <h6 style="color:lightgray;">This is a school project! Contact me if there is a problem...</h6>
    <address>
        <strong>Support:</strong>   <a href="mhmd.school.2003.sm@gmail.com">mhmd.school.2003.sm@gmail.com</a><br />
        <strong>Marketing:</strong> <a href="mhmd.school.2003.sm@gmail.com">mhmd.school.2003.sm@gmail.com</a>
    </address>
            </div></div>
</asp:Content>
