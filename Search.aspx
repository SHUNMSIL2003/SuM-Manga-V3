<%@ Page Language="C#" MasterPageFile="~/SuMManga.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="SuM_Manga_V3.Search" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
                    .FNM5455511 {
                        margin-top:0px !important;
                        margin-bottom:0px !important;
                        height:7vh !important;
                        /*background-color:rgb(240, 235, 255) !important;*/
                    }
        .form-control :focus {
            outline: none !important;
        }
        #SearchText :focus {
            outline: none !important;
        }
                </style>
    <style>
            .STBSUMBAR2 {
                position:fixed !important;
                top:0 !important;
                width:100% !important;
                text-align:center !important;
            }
            .WAHFH021 {
                display:inline !important;
                max-width:7vh !important;
                max-height:7vh !important;
            }
        input:focus {
            outline: none;
        }
        .form-control:focus {
            border-color: #ffffff !important;
            -webkit-box-shadow: none !important;
            box-shadow: none !important;
        }
        </style>
    <div class="STBSUMBAR2 bg-white shadow">
        <nav style="height:7vh;width:100% !important;" class="navbar navbar-light navbar-expand bg-white mb-4 FNM5455511">
                    <div class="container-fluid" style="text-align:center !important;">
                                <div class="" style="display:inline !important;width:100vw !important;height:7vh !important;text-align:center !important;align-items:center;align-content:center;">
                                    <div class="me-auto navbar-search w-100" style="vertical-align:middle !important;">
                                        <div class="input-group" style="vertical-align:middle !important;">
                                            <a style="width:38px;height:7vh;display:inline-block !important;float:right;vertical-align:middle !important;" href="/Explore.aspx"><img src="/svg/arrowback.svg" style="height:5vh;width:5vh;max-height:32px;max-width:32px;display:inline-block !important;margin-top:1vh !important;margin-bottom:1vh !important;" /></a>
                                            <input style="background-color:#ffffff !important;border:solid 0px #ffffff !important;height:7vh !important;width:64vw !important;display:inline !important;float:right;" class="bg-light form-control border-0 small" id="SearchText" runat="server" type="text" placeholder="Search for ...">
                                        </div>
                                    </div>
                                </div>
                    </div>
                </nav>
            </div>
    <div id="Results" style="height:calc(86vh-38px) !important;width:100vw !important" runat="server">
        <p>Loading...</p>
    </div>
</asp:Content>