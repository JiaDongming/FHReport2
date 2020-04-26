<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportTree.aspx.cs" Inherits="CustomReports.ReportTree" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>报表布局</title>
    <style type="text/css">
        .mainMenu
        {
            width:100%;
            height:40px;
            border-bottom:1px solid #ccc;
            /*position:relative;*/
        }
        .menuReportIcon
        {
            background:url("Images/leftBg1.gif") no-repeat 0 0;
            left:4px;
            width:20px;
            height:40px;
            position:absolute;
        }
        .menuReportText
        {
            position:absolute;
            left:24px;
            right:4px;
            background:url("Images/mainBg.gif") repeat-x 0 0;
            height:28px;
            padding-top:12px;
            cursor:pointer;
            font-weight:bold;
        }
        .ProjectItem,.ProjectItem a
        {
            cursor:pointer;
            margin-bottom:10px;
            font-weight:bold;
            color:#666;
            font-size:14px;
            line-height:1.5em;
        }        
        .ReportItem a
        {
            cursor:pointer;
            margin-bottom:10px;
            font-size:13px;
            line-height:1.8em;
            color:#666;
            font-weight:normal;
        }        
        #globalReportList
        {
            list-style-type:circle;
            padding-left:16px;
        }       
        .highlightItem
        {
            color:#eb8f00 !important;
            font-weight:bold !important;
        }
        ul
        {
            margin-top:4px;
            margin-bottom:4px;
            padding-left:10px;
        }
    </style>
    <script src="JS/jquery-3.2.1.min.js" type="text/javascript"></script>
    <script language="JavaScript" src="JS/ReportLeftTree.js" type="text/javascript"></script>
</head>

<body id="leftBody">
  <div id="accordion">
      <div class="mainMenu"  id="globleReport">
          <div class="menuReportIcon"></div>
          <div class="menuReportText highlightItem" onclick="navReport(-1,<%=defaultReportID4Start %>,this)"><a>全局报表</a></div>
      </div>
      <div id="divGlobalReports">
          <ul id="globalReportList">
                <li itemId="101" <%=IfShowReport(-1, 101) ? "" : "style=\"display:none;\""%>><a>1-列表</a></li>
                <li itemId="102" <%=IfShowReport(-1, 102) ? "" : "style=\"display:none;\""%>><a>2-列表(下拉多选条件)</a></li>
                <li itemId="103" <%=IfShowReport(-1, 103) ? "" : "style=\"display:none;\""%>><a>3-列表(下拉单选)</a></li>
                <li itemId="104" <%=IfShowReport(-1, 104) ? "" : "style=\"display:none;\""%>><a>4-列表(时间选项)</a></li>
                <li itemId="105" <%=IfShowReport(-1, 105) ? "" : "style=\"display:none;\""%>><a>5-列表（下拉多选+时间）</a></li>
                <li itemId="106" <%=IfShowReport(-1, 106) ? "" : "style=\"display:none;\""%>><a>6-列表（下拉单选+时间）</a></li>
                <li itemId="107" <%=IfShowReport(-1, 107) ? "" : "style=\"display:none;\""%>><a>7-列表(下拉多选+时间+排序)</a></li>
                <li itemId="108" <%=IfShowReport(-1, 108) ? "" : "style=\"display:none;\""%>><a>8-柱状图(Bar)</a></li>
                <li itemId="109" <%=IfShowReport(-1, 109) ? "" : "style=\"display:none;\""%>><a>9-Bar报表</a></li>
                <li itemId="110" <%=IfShowReport(-1, 110) ? "" : "style=\"display:none;\""%>><a>10-Line报表</a></li>
                <li itemId="111" <%=IfShowReport(-1, 111) ? "" : "style=\"display:none;\""%>><a>11-Pie报表</a></li>
                <li itemId="112" <%=IfShowReport(-1, 112) ? "" : "style=\"display:none;\""%>><a>12-Column报表</a></li>
                <li itemId="113" <%=IfShowReport(-1, 113) ? "" : "style=\"display:none;\""%>><a>13-Column报表</a></li>
                <li itemId="114" <%=IfShowReport(-1, 114) ? "" : "style=\"display:none;\""%>><a>14-Column报表</a></li>
                <li itemId="115" <%=IfShowReport(-1, 115) ? "" : "style=\"display:none;\""%>><a>15-Bar报表</a></li>
                <li itemId="116" <%=IfShowReport(-1, 116) ? "" : "style=\"display:none;\""%>><a>16-Bar报表</a></li>
                <li itemId="117" <%=IfShowReport(-1, 117) ? "" : "style=\"display:none;\""%>><a>17-Bar报表</a></li>
                <li itemId="118" <%=IfShowReport(-1, 118) ? "" : "style=\"display:none;\""%>><a>18-Line报表</a></li>
                <li itemId="119" <%=IfShowReport(-1, 119) ? "" : "style=\"display:none;\""%>><a>19-Line报表</a></li>
                <li itemId="120" <%=IfShowReport(-1, 120) ? "" : "style=\"display:none;\""%>><a>20-Column_Line报表</a></li>
                <li itemId="121" <%=IfShowReport(-1, 121) ? "" : "style=\"display:none;\""%>><a>21-销售漏斗(Funnel Chart)</a></li>
                <li itemId="122" <%=IfShowReport(-1, 122) ? "" : "style=\"display:none;\""%>><a>烽火工时统计</a></li>
                <li itemId="123" <%=IfShowReport(-1, 123) ? "" : "style=\"display:none;\""%>><a>内部工时统计</a></li>
          </ul>
      </div>
</div>
</body>
</html>
