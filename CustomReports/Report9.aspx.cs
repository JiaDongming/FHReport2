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
    public partial class Report9 : System.Web.UI.Page
    {
        private static int MyReportID = 109;
        public string htmlGlobalReportTable109;
        private ReportManager objReportManager = new ReportManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)//首次加载
            {
                getChartReport(objReportManager.GetReport9_Data());
            }
        }


        public void getChartReport(List<Models.Report9> reportData)
        {
            if (reportData.Count == 0)
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", string.Format("var strCharts='{0}';", ""), true);
            else
            {
                string strCharts = "[";

                foreach (Models.Report9 item in reportData)
                {
                    strCharts += "{ \"name\" : \"" + item.BugTypeName  + "\", \"data\" : " + item.BugNo + "},";
                }

                strCharts = strCharts.Substring(0, strCharts.Length - 1);
                strCharts += "]";

                Page.ClientScript.RegisterStartupScript(this.GetType(), "", string.Format("var strCharts='{0}';", strCharts), true);
            }
        }
    }
}