using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BLL;
using System.Web.Services;
using Models;

namespace CustomReports
{
    public partial class Report7 : System.Web.UI.Page
    {
        private static int MyReportID = 107;
        protected string selProjectOptions107 = "";
        public string htmlGlobalReportTable107;
        private ReportManager objReportManager = new ReportManager();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                
                DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                dateTimePicker.Value = startDate.ToShortDateString();
                dateTimePicker2.Value = endDate.ToShortDateString();
                hidOrderBy.Value = listType.Items[0].Value.ToString();


                selProjectOptions107 = objReportManager.BindChoices(); ;
                htmlGlobalReportTable107 = "";
            }
        }


        [WebMethod]
        public static string RefreshGlobalReport7(string startDateStr, string endDateStr, string selectedProjectsStr, string sortTypeStr)
        {
           
            DateTime startDate = Convert.ToDateTime(startDateStr);
            DateTime endDate = Convert.ToDateTime(endDateStr);

            Report7_Params param = new Report7_Params()
            {
                StartDate = Convert.ToDateTime(startDateStr),
                EndDate = Convert.ToDateTime(endDateStr),
                selectProjectStr = selectedProjectsStr,
                OrderBy= sortTypeStr
            };
            return ReportManager.GetReport7_HTML(param);
           
        }

        // 导出报表使用
        public void exportReportToExcel(Object sender, EventArgs e)
        {
            
        }
    }
}