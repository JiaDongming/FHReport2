
$(function () {
   // $(document).ready(createChart(createChart(strCharts, legendData)));
    // 显示图形报表
    {
        $("#divGlobalReportHTML108").ready(createChart(strCharts,legendData));
        //$("#divGlobalReportHTML108").bind("kendo:skinChange", createChart(strCharts, legendData));
        // 使用刚指定的配置项和数据显示图表。
    }

    // 以图片形式导出报表
    $("#btnSaveAsImage").click(function () {
        var chart = $("#divGlobalReportHTML108").getKendoChart();
        chart.exportImage().done(function (data) {
            kendo.saveAs({
                dataURI: data,
                fileName: "chart.png"
            });
        });
    });


});



function createChart(strCharts,legendData) {
    var myChart = echarts.init(document.getElementById('divGlobalReportHTML108'));
    option = {
        title: {
            text: '销售漏斗图',
            subtext: '纯属虚构'
        },
        tooltip: {
            trigger: 'item',
            formatter: "{a} <br/>{b} : {c}%"
        },
        toolbox: {
            show: true,
            feature: {
                mark: { show: true },
                dataView: { show: true, readOnly: false },
                restore: { show: true },
                saveAsImage: { show: true }
            }
        },
        legend: {
            x: 'center',
            y: '60px',
            data: eval(legendData)
        },
        calculable: true,
        series: [
            {
                name: '销售漏斗图',
                type: 'funnel',
                width: '50%',
                x:'center',
                y: '120px',
                data: eval(strCharts)
            }
        ]
    };

    myChart.setOption(option);
}


