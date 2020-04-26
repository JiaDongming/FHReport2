using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Models;
using BLL;
using System.Web.Services;

namespace CustomReports
{
    public partial class Report21 : System.Web.UI.Page
    {
        private static int MyReportID = 121;
        public string htmlGlobalReportTable108;
        ReportManager objReportManager = new ReportManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            getChartReport(objReportManager.GetReport21());
        }


        public void getChartReport(List<Report21_TaskType> dataList)
        {
            if (dataList.Count == 0)
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", string.Format("var strCharts='{0}';", ""), true);
            else
            {
                string strCharts = "[";
                string legendData = "[";
                foreach (Report21_TaskType item in dataList)
                {
                    strCharts += "{ value: " + Convert.ToInt32(item.BugNo) + ", name: \'" + item.TypeName + "\'},";
                    legendData += "'"+item.TypeName+"',";
                }

                strCharts = strCharts.Substring(0, strCharts.Length - 1);
                legendData = legendData.Substring(0, legendData.Length - 1);
                strCharts += "]";
                legendData += "]";

                Page.ClientScript.RegisterStartupScript(this.GetType(), "", string.Format("var strCharts=\"{0}\";legendData=\"{1}\";", strCharts, legendData), true);
            }
        }

    }
}