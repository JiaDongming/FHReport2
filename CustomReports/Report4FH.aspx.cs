using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using BLL;
using Models;

namespace CustomReports
{
    public partial class Report4FH : System.Web.UI.Page
    {

        private static int MyReportID = 122;
        public string htmlGlobalReportTable4;
        protected string selProjectOptions4 = "";
        public  string  summarywork;

        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime startDate = new DateTime(2019, 09, 16);
            DateTime endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            dateTimePicker.Value = startDate.ToShortDateString();
            dateTimePicker2.Value = endDate.ToShortDateString();
            htmlGlobalReportTable4 = RefreshGlobalReport4FH(dateTimePicker.Value, dateTimePicker2.Value);
            summarywork = RefreshSummary(dateTimePicker.Value, dateTimePicker2.Value);
        }

        [WebMethod]
        public static string RefreshGlobalReport4FH(string startDateStr, string endDateStr)
        {

            DateTime startDate = Convert.ToDateTime(startDateStr);
            DateTime endDate = Convert.ToDateTime(endDateStr);
            string strFlag = string.Format("{0}_{1}", startDate, endDate);
           
            // return ReportManager.GetReport4_HTML(startDate, endDate);
            return ReportManager.GetReport_HTML_FH(startDate, endDate);
        }

        [WebMethod]
        public static string RefreshSummary(string startDateStr, string endDateStr)
        {
            DateTime startDate = Convert.ToDateTime(startDateStr);
            DateTime endDate = Convert.ToDateTime(endDateStr);
            ReportSummary reportSummary= ReportManager.GetReport_Summary_FH(startDate, endDate);
            return string.Format("总工作天数：  {0}天； 总工作小时：{1}小时；总完成点数：{2}",reportSummary.TotalWorkDays,reportSummary.TotalWorkHours,reportSummary.TotalPoints);
            
        }

        [WebMethod]
        public static bool RefreshTree(string folderID)
        {
            return ReportManager.FH_Refresh(folderID);
        }
        public void exportReportToExcel(Object sender, EventArgs e)
        {

        }
    }
}