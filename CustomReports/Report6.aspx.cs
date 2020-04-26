using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Services;
using BLL;

namespace CustomReports
{
    public partial class Report6 : System.Web.UI.Page
    {
        private static int MyReportID = 106;
        protected string selProjectOptions6 = "";
        public string htmlGlobalReportTable6;
        private ReportManager objReportManager = new ReportManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                dateTimePicker.Value = startDate.ToShortDateString();
                dateTimePicker2.Value = endDate.ToShortDateString();
                selProjectOptions6 = objReportManager.BindChoicesWithNone();
                htmlGlobalReportTable6 = "";
            }

        }

        [WebMethod]
        public static string RefreshGlobalReport6(string startDateStr, string endDateStr, string selectedProjectsStr)
        {
            
            DateTime startDate = Convert.ToDateTime(startDateStr);
            DateTime endDate = Convert.ToDateTime(endDateStr);

            return ReportManager.GetReport5_HTML(startDate, endDate, selectedProjectsStr);
        }

        // 导出报表使用
        public void exportReportToExcel(Object sender, EventArgs e)
        {
            
        }
    }
}