using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Models;
using BLL;

namespace CustomReports
{
    public partial class Report10 : System.Web.UI.Page
    {
        private static int MyReportID = 110;
        public string htmlGlobalReportTable110;
        private ReportManager objReportManager = new ReportManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getChartReport(objReportManager.GetReport10_Data());
            }
        }


        public void getChartReport(List<Models.Report10> reportData)
        {
            if (reportData.Count == 0)
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", string.Format("var strCharts='{0}';", ""), true);
            else
            {
                string strCharts = "[";

                foreach (Models.Report10 item in reportData)
                {
                    strCharts += "{ \"name\" : \"" + item.DateCreated.ToShortDateString() + "\", \"data\" : " + item.BugCounts + "},";
                }

                strCharts = strCharts.Substring(0, strCharts.Length - 1);
                strCharts += "]";

                Page.ClientScript.RegisterStartupScript(this.GetType(), "", string.Format("var strCharts='{0}';", strCharts), true);
            }
        }
    }
}