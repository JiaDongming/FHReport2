var currentSelReport;
var needToggleGlobleContainer = false;
var isLoading = false;

function navReport(projectID, reportID, target, typeid) {
    if (typeof (typeid) == "undefined") typeid = -1;
    setProjectSelStatus(projectID, target);
    var url;
    if (projectID == -1) {
        if (target.tagName == "DIV" && needToggleGlobleContainer) {
            toggleSubMenuVisible("#divGlobalReports");
            return;
        }
        if (currentSelReport == projectID + "_" + reportID)
            return;
        if (reportID == 0)
            url = "Default.aspx";

        if (reportID == 10000)
            url = "null.htm";

        //"ProjectReport" + reportID+".aspx"
        if (reportID == 101)
            url = "Report1.aspx";
        if (reportID == 102)
            url = "Report2.aspx";
        if (reportID == 103)
            url = "Report3.aspx";
        if (reportID == 104)
            url = "Report4.aspx";
        if (reportID == 105)
            url = "Report5.aspx";
        if (reportID == 106)
            url = "Report6.aspx";
        if (reportID == 107)
            url = "Report7.aspx";
        if (reportID == 108)
            url = "Report8.aspx";
        if (reportID == 109)
            url = "Report9.aspx";
        if (reportID == 110)
            url = "Report10.aspx";
        if (reportID == 111)
            url = "Report11.aspx";
        if (reportID == 112)
            url = "Report12.aspx";
        if (reportID == 113)
            url = "Report13.aspx";
        if (reportID == 114)
            url = "Report14.aspx";
        if (reportID == 115)
            url = "Report15.aspx";
        if (reportID == 116)
            url = "Report16.aspx";
        if (reportID == 117)
            url = "Report17.aspx";
        if (reportID == 118)
            url = "Report18.aspx";
        if (reportID == 119)
            url = "Report19.aspx";
        if (reportID == 120)
            url = "Report20.aspx";
        if (reportID == 121)
            url = "Report21.aspx";
        if (reportID == 122)
            url = "Report4FH.aspx";
        if (reportID == 123)
            url = "Report4Internal.aspx";

    }

    url += "?reportID=" + reportID;
    url += "&projectID=" + projectID;

    setTimeout(function () {
        parent.rightFrame.location = url;
        isLoading = true;
    }, 400);

    currentSelReport = projectID + "_" + reportID;

    if (currentSelReport == "-1_0")
        needToggleGlobleContainer = true;
    else
        needToggleGlobleContainer = false;
}

function setProjectSelStatus(projectID, target) {

    $(".highlightItem").removeClass("highlightItem");
    setTimeout(function () {
        if (target.tagName == undefined && typeof target.addClass == "function")
            target.addClass("highlightItem");

        if (target.tagName == "A") {
            if (!$(target).hasClass("highlightItem"))
                $(target).addClass("highlightItem");
        }
        else {
            if (!$(target).find("a").hasClass("highlightItem"))
                $(target).find("a").addClass("highlightItem");
        }
    }, 200);
}

function toggleSubMenuVisible(target) {
    if ($(target).css("display") == "block" || $(target).css("display") == "")
        $(target).slideUp();
    else
        $(target).slideDown();
}

$(function () {

    $("#globalReportList li").addClass("ReportItem").each(function (i, e) {
        $(e).bind("click", function () {
            var reportId = $(e).attr("itemId") || i + 1;
            navReport(-1, reportId, e);
        });
    });

});


