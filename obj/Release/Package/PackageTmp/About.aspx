<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="SuM_Manga_V3.About" %>

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
    <div class="card shadow ForceMaxW">
    <div class="card-body"><br />
    <h1 style="color:#6840D9">   About Shun Manga "SuM".</h1><br />
    <h3 class="text-dark mb-4">This site provides you with hight qulity contant wihtout violating any copywrite nor your safty.</h3>
    <h3 class="text-dark mb-4">in addetion, we do not annoy our dear customer with ads thus it comes with 14.99USD per-month.</h3> 
    <br/>
    <a class="btn btn-primary btn-sm" style="background-color:#6840D9;" data-bss-hover-animate="pulse" href="Contact.aspx">CONTACT US &raquo;</a>
    </div></div>
</asp:Content>