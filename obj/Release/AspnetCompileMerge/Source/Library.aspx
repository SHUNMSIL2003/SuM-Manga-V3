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
                    <div class="card shadow ForceMaxW">
                        <div class="card-header py-3">
                            <p style="color:#6840D9;display:inline;" class="text-primary m-0 fw-bold"><p style="color:#6840D9;display:inline;" id="UserNameforshow" runat="server"></p>'s To Explore</p>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-6 text-nowrap">
                                    <div runat="server" id="dataTable_length1" class="dataTables_length" aria-controls="dataTable"><label class="form-label">Show&nbsp;<select class="d-inline-block form-select form-select-sm">
                                                <option value="10" selected="">12</option>
                                                <option value="25">24</option>
                                                <option value="50">48</option>
                                                <option value="100">96</option>
                                            </select>&nbsp;</label></div>
                                </div>
                                <div class="col-md-6">
                                    <!-- <div class="text-md-end dataTables_filter" id="dataTable_filter"><label class="form-label"><input type="search" class="form-control form-control-sm" aria-controls="dataTable" placeholder="Search"></label></div> -->
                                </div>
                            </div>
                            <div id="MangasAvalibleDiv" runat="server" style="text-align:center;align-items:center; width:auto; margin-left:-18px; margin-right:-18px;">
                               <h3 class="text-dark mb-4">Loading...<br></h3>
                            </div><br />
                            <div class="row">
                                <div class="col-md-6 align-self-center">
                                    <p id="dataTable_info" class="dataTables_info" role="status" aria-live="polite">For better Experience use Wi-Fi !</p>
                                </div>
                                <div class="col-md-6" style="float:right !important;">
                                    <nav style="float:right !important;" class="d-lg-flex justify-content-lg-end dataTables_paginate paging_simple_numbers">
                                        <ul style="float:right !important;" class="pagination">
                                            <li style="float:right !important;" id="PPS" runat="server" class="page-item disabled"><a id="PrePageG" runat="server" class="page-link" href="#" aria-label="Previous"><span aria-hidden="true">« Prev page</span></a></li>
                                            <li style="float:right !important;" class="page-item active"><a id="CurrPageNum" runat="server" class="page-link" style="pointer-events:none;-moz-user-select: none; -webkit-user-select:none; user-select: none;">1</a></li>
                                        <!--    <li class="page-item"><a class="page-link" href="#">2</a></li>
                                            <li class="page-item"><a class="page-link" href="#">3</a></li> -->
                                            <li style="float:right !important;" id="NPS" runat="server" class="page-item"><a id="NextPageG" runat="server" class="page-link" href="#" aria-label="Next"><span aria-hidden="true">Next page »</span></a></li>
                                        </ul>
                                    </nav>
                                </div>
                            </div>
                        </div>
                    </div>
</asp:Content>