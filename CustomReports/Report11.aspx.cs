using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Models;
using ReportUtility;
using BLL;

namespace CustomReports
{
    public partial class Report11 : System.Web.UI.Page
    {
        private static int MyReportID = 111;
        public string htmlGlobalReportTable111;
        private ReportManager objReportManager = new ReportManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getChartReport(objReportManager.GetReport11_Data());
            }
        }


        public void getChartReport(List<Models.Report11> reportData)
        {
            if (reportData.Count == 0)
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", string.Format("var strCharts='{0}';", ""), true);
            else
            {
                chart pieChart = new chart();
                string strCharts = "[";
                int n = 0;

                foreach (Models.Report11 item in reportData)
                {
                    string color = pieChart.getColor(n++);
                    strCharts += "{ \"category\" : \"" + item.TypeName + "\", \"data\" : " + item.BugNo + ", \"color\" : \"" + color + "\" },";
                }

                strCharts = strCharts.Substring(0, strCharts.Length - 1);
                strCharts += "]";

                Page.ClientScript.RegisterStartupScript(this.GetType(), "", string.Format("var strCharts='{0}';", strCharts), true);
            }
        }
    }
}