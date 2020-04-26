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
    public partial class Report4 : System.Web.UI.Page
    {
        
        private static int MyReportID = 104;
        public string htmlGlobalReportTable4;
        protected string selProjectOptions4 = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime startDate = new DateTime(2019, 09, 01);
            DateTime endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            dateTimePicker.Value = startDate.ToShortDateString();
            dateTimePicker2.Value = endDate.ToShortDateString();
            htmlGlobalReportTable4 = RefreshGlobalReport4(dateTimePicker.Value, dateTimePicker2.Value);
        }

        [WebMethod]
        public static string RefreshGlobalReport4(string startDateStr, string endDateStr)
        {
            
            DateTime startDate = Convert.ToDateTime(startDateStr);
            DateTime endDate = Convert.ToDateTime(endDateStr);
            string strFlag = string.Format("{0}_{1}", startDate, endDate);
             return ReportManager.GetReport4_HTML(startDate, endDate);
           // return ReportManager.GetReport_HTML_FH(startDate, endDate);
        }


        public void exportReportToExcel(Object sender, EventArgs e)
        {

        }
    }
}