var dateTimePickerValue;
var dateTimePicker2Value;

$(function () {

    {
        dateTimePickerValue = $("#dateTimePicker").val();
        dateTimePicker2Value = $("#dateTimePicker2").val();
    }

    $("#dateTimePicker").change(function () {
        var checkResult = checkSearchCondition();
        if (checkResult != "false") {
            doReportCall();
            doSummaryCall();
        }
    });

    $("#dateTimePicker2").change(function () {
        var checkResult = checkSearchCondition();
        if (checkResult != "false") {
            doReportCall();
            doSummaryCall();
        }
    });

});


function checkSearchCondition() {
    var startDateStr = $("#dateTimePicker").val();
    var endDateStr = $("#dateTimePicker2").val();
    var startDate = new Date(startDateStr.replace(/-/g, "/"));
    var endDate = new Date(endDateStr.replace(/-/g, "/"));

    if (startDate > endDate) {
        alert("开始时间不能超过终止时间，请重新选择。");
        $("#dateTimePicker").val(dateTimePickerValue);
        $("#dateTimePicker2").val(dateTimePicker2Value);
        return "false";
    }
    if (startDateStr == '') {
        alert("开始时间需要填写");
        return "false";
    }
    if (endDateStr == '') {
        alert("结束时间需要填写");
        return "false";
    }

    dateTimePickerValue = startDateStr;
    dateTimePicker2Value = endDateStr;

    return "true";
}

function Refreshdata() {
  
    doReportCall();
    doSummaryCall();
  
}

function doReportCall() {

    var startDateStr = $("#dateTimePicker").val();
    var endDateStr = $("#dateTimePicker2").val();

    var params = "{'startDateStr':'" + startDateStr;
    params += "','endDateStr':'" + endDateStr;
    params += "'}";

    $.ajax({
        type: "POST",
        url: "Report4Internal.aspx/RefreshGlobalReport4Internal",
        data: params,
        contentType: "application/json; charset=utf-8",
        beforeSend: function (XMLHttpRequest) {
            $('#divGlobalReportHTML4').html("<h5 style='color:red;'>正在生成报表...</h5>");
        },
        success: function (msg) {
            $('#divGlobalReportHTML4').html("");
            if (msg.d) {
                $('#divGlobalReportHTML4').html(msg.d.toString());
            }
        },
        error: function (xhr, msg, e) {
            alert("error");
        }
    }
    );

  
}


function doSummaryCall() {

    var startDateStr = $("#dateTimePicker").val();
    var endDateStr = $("#dateTimePicker2").val();

    var params = "{'startDateStr':'" + startDateStr;
    params += "','endDateStr':'" + endDateStr;
    params += "'}";

    $.ajax({
        type: "POST",
        url: "Report4Internal.aspx/RefreshSummary",
        data: params,
        contentType: "application/json; charset=utf-8",
        beforeSend: function (XMLHttpRequest) {
            $('#summary').html("正在刷新统计...");
        },
        success: function (msg) {
            $('#summary').html("");
            if (msg.d) {
                $('#summary').html(msg.d.toString());
            }
        },
        error: function (xhr, msg, e) {
            alert("error");
        }
    }
    );


}

