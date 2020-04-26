<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CustomReports.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <frameset cols="220,12,*" name="mainFrame" id="mainframe" frameborder="yes" framespacing="1" border="2">
    <noframes> 
        <body> 
        很抱歉，馈下使用的浏览器不支援框架功能，请转用新的浏览器。 
        </body> 
    </noframes>
     
    <frame src="ReportTree.aspx?" name="leftFrame" id="leftFrame" scrolling="auto" noresize="noresize" />
    <frame src="frameline.html" scrolling="no" noresize="noresize" name="pageline" />
    <frame src="<%=defaultReport4Start %>" name="rightFrame" id="rightFrame" />
</frameset>
</head>

</html>
