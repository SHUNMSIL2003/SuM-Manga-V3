<%@ Page Language="C#" MasterPageFile="~/SuMManga.Mobile.Master" AutoEventWireup="true" CodeBehind="Library.aspx.cs" Inherits="SuM_Manga_V3.Library" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="../imghover/css/imagehover.min.css">
    <style>
        img {
  border-radius: 10px;
}
.box {
	border-top-left-radius: 10px;
	border-bottom-right-radius: 10px;
    border-radius: 10px;
}
.txtmaxw {
  max-width: 175px;
}
img {
            pointer-events: none;
        }
            .floutright {
                float:right !important;
                display:inline !important;
                /*text-align: right !important ;*/
            }
            h3 {
                max-width:160px !important;
            }
            .backgroundforjim {
            background-color:#f0edf7 !important;
            border: 2px solid #6840D9 !important;
            margin: -2px;
        }
        .ForceMaxW {
            max-width:1200px !important;
            margin: 0 auto;
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
    </style>
                    <div class="animated fadeIn card shadow ForceMaxW" style="margin-bottom:82px !important;">
                        <div class="card-header py-3">
                            <p style="color:#6840D9;display:inline;" class="text-primary m-0 fw-bold"><p style="color:#6840D9;display:inline;" id="UserNameforshow" runat="server"></p>'s Library</p>
                        </div>
                        <div class="card-body">
                            <div id="MangasAvalibleDiv" runat="server" style="text-align:center;align-items:center; width:auto; margin-left:-18px; margin-right:-18px;">
                               <h3 class="text-dark mb-4">Loading...<br></h3>
                                <a style="width:100vw;height:74px;background-color:#ffffff;border:#ebebeb 1px solid;position:relative;margin-left:-17px;display:block;" href="#">
                                    <img src="CoverLink" style="height:74px;width:74px;object-fit:cover;display:inline;margin-left:0px;border-radius:0px;float:left;margin-left:0px;">
                                    <h3 style="color:rgba(255, 106, 0, 0.7);margin-top:-42px;float:left;margin-left:6px;margin-top:12px;">MangaName</h3><br style="float:left;">
                                    <p style="margin-top:16px;margin-left:-148px;color:#6b6b6b;float:left;">chapter: X</p>
                                </a>
                            </div><br />
                            <div class="row">
                                <div class="col-md-6 align-self-center">
                                    <p id="dataTable_info" class="dataTables_info" role="status" aria-live="polite">For better Experience use Wi-Fi !</p>
                                </div>
                                <div class="col-md-6" style="float:right !important;">
                                    <nav style="float:right !important;" class="d-lg-flex justify-content-lg-end dataTables_paginate paging_simple_numbers">
                                        <ul style="float:right !important;border-radius:26px !important;" class="pagination">
                                            <li style="float:right !important;" id="PPS" runat="server" class="page-item disabled"><a id="PrePageG" runat="server" class="page-link" href="#" aria-label="Previous"><span aria-hidden="true">« Prev page</span></a></li>
                                            <li style="float:right !important;" class="page-item active"><a id="CurrPageNum" runat="server" class="page-link" style="pointer-events:none;-moz-user-select: none; -webkit-user-select:none; user-select: none;">1</a></li>
                                            <li style="float:right !important;" id="NPS" runat="server" class="page-item"><a id="NextPageG" runat="server" class="page-link" href="#" aria-label="Next"><span aria-hidden="true">Next page »</span></a></li>
                                        </ul>
                                    </nav>
                                </div>
                            </div>
                        </div>
                    </div>
</asp:Content>