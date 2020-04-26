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
    public partial class Report8 : System.Web.UI.Page
    {
        private static int MyReportID = 108;
        public string htmlGlobalReportTable108;
        ReportManager objReportManager = new ReportManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            getChartReport(objReportManager.GetReport8());
            
        }


        public void getChartReport(List<Report8_TaskType> dataList)
        {
            if (dataList.Count == 0)
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", string.Format("var strCharts='{0}';", ""), true);
            else
            {
                string strCharts = "[";

                foreach (Report8_TaskType item in dataList)
                {
                    strCharts += "{ \"name\" : \"" + item.TypeName + "\", \"data\" : " + item.BugNo + "},";
                }

                strCharts = strCharts.Substring(0, strCharts.Length - 1);
                strCharts += "]";

                Page.ClientScript.RegisterStartupScript(this.GetType(), "", string.Format("var strCharts='{0}';", strCharts), true);
            }
        }
    }
}