﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report3.aspx.cs" Inherits="CustomReports.Report3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
     <meta http-equiv="content-type" content="text/html;chartset=UTF-8" /> 
        <link rel="stylesheet" href="CSS/ui-lightness/jquery-ui-1.10.3.custom.min.css" type="text/css" />
        <link rel="stylesheet" href="CSS/jquery.multiselect.css" type="text/css" />
        <style type="text/css">
        #projectReport_3
        {
            /*border:1px solid green;*/
            overflow: auto;
        }
        .DivGlobalReportItem3
        {
            width: 100%;
            height: 100%;
            text-align: center;
            border: 1px solid green;
        }
        .globalReportItemHeader3
        {
            background: url("Images/rightBg.gif") repeat-x 0 0;
            height: 30px;
            vertical-align: middle;
            text-align: left;
            font-weight: bold;
            font-size: 14px;
            position: relative;
        }
        .globalHeaderLeft3
        {
            background: url("Images/leftBg.gif") no-repeat 0 0;
            padding: 6px 0 6px 6px;
            color: White;
            position: absolute;
            top: 0;
            left: 0;
            width: 240px;
            height: 17px;
        }
        .globalHeaderMiddle3
        {
            background: url("Images/middleBg.gif") no-repeat 0 0;
            position: absolute;
            top: 0;
            left: 230px;
            width: 40px;
            height: 30px;
        }
        .report_table
        {
            border-collapse: collapse;
            background-color: #ffffff;
            border: 1px solid #2471A2;
            width: 100%;
        }        
        .report_table td, .report_table th
        {
            border: 1px solid #C0C0C0;
            white-space: nowrap;
            text-align: center;
            height: 20px;
        }
        .report_table th
        {
            font-size: 12px;
            background-color: #dee3e7; /*background-color:#1ca2d5;*/
            font-weight: bold;
        }        
        .report_table td
        {
            font-size: 12px;
        }
        .select
        {
        border:solid 1px #000;  
        border-color:Green;
        width:60px;
	    appearance:none;
        -moz-appearance:none;
        -webkit-appearance:none;
        padding-right: 14px;
        background: url("Images/arrow.png") no-repeat scroll right center transparent;
        }  
	    select::-ms-expand { display: none; }          
    </style>
        <script src="JS/jquery-3.2.1.min.js" type="text/javascript"></script>
        <script src="JS/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
        <script src="JS/jquery.multiselect.js" type="text/javascript"></script>
        <script src="JS/Report3.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID="hidprojectIDs" runat="server" />
        </div>
        <div id="projectReport_3">
            <table style="width:100%;height:100%; border-collapse:separate; border-spacing:10px;">
                <tr>
                    <td style="width:100%; vertical-align:middle">
                        <div class="DivGlobalReportItem3">
                            <div class="globalReportItemHeader3">
                                <div class="globalHeaderLeft3">设置</div>
                                <div class="globalHeaderMiddle3">&nbsp;</div>
                            </div>
                            <div>
                                <table style="height:35px";>
                                    <tr>
                                        <td style="font-size:15px;">DevTrack项目：</td>  
                                        <td>
                                            <div style="top:8px;right:160px;width:230px; float:left;">
                                                <select id="Select1" name="selLift" style="width:225px;">
                                                    <%=selProjectOptions3%>
                                                </select>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="width:100%; vertical-align:middle">
                        <div class="DivGlobalReportItem3">
                            <div class="globalReportItemHeader3">
                                <div class="globalHeaderLeft3">测试报表3</div>
                                <div class="globalHeaderMiddle3">&nbsp;</div>
                                <div style="padding-left:275px; padding-top:10px;">
                                    <asp:ImageButton  ImageAlign="Left" ImageUrl="Images/toExcel.gif" ID="btnExport" OnClick="exportReportToExcel" runat="server" ToolTip="导出Excel"  />
                                </div>
                            </div>
                            <div id="divGlobalReportHTML3"><%=htmlGlobalReportTable3%></div>
                        </div>
                    </td>               
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
