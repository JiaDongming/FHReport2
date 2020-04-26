using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BLL;
using System.Web.Services;

namespace CustomReports
{
    public partial class Report5 : System.Web.UI.Page
    {
        private ReportManager objReportManager = new ReportManager();
        private static int MyReportID = 105;
        protected string selProjectOptions5 = "";
        public string htmlGlobalReportTable5;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//首次加载
            {
                DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                dateTimePicker.Value = startDate.ToShortDateString();
                dateTimePicker2.Value = endDate.ToShortDateString();

                selProjectOptions5 = objReportManager.BindChoices();
                htmlGlobalReportTable5 = "";
            }
        }

        [WebMethod]
        public static string RefreshGlobalReport5(string startDateStr, string endDateStr, string selectedProjectsStr)
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