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
                            <div style="text-align:center;" class="text-center mt-5">
                                <div>
                                    <img src="/warning.png" class="animated pulse" style="width:164px;height:164px;margin:0 auto;">
                                </div>
                                <p class="text-dark mb-5 lead animated fadeIn" style="font-size:240%;color:#6840D9 !important;">You are offline!</p>
                                <p class="text-dark mb-5 lead animated fadeIn" style="margin-top:-48px;font-size:80%;"><b>Only previously viewed pages will be avalible.</b></p>
                            </div>
</asp:Content>