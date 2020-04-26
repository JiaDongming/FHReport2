using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

using BLL;


namespace CustomReports
{
    public partial class Report3 : System.Web.UI.Page
    {
        private ReportManager objReportManager = new ReportManager();
        private static int MyReportID = 103;
        protected string selProjectOptions3 = "";
        public string htmlGlobalReportTable3;
        protected void Page_Load(object sender, EventArgs e)
        {
            selProjectOptions3=objReportManager.BindChoicesWithNone();
            htmlGlobalReportTable3 = "";
        }

        [WebMethod]
        public static string RefreshGlobalReport3(string selectedProjectsStr)
        {
            return ReportManager.GetReport3_HTML(selectedProjectsStr);
        }

        // 导出报表使用
        public void exportReportToExcel(Object sender, EventArgs e)
        {
            
        }
    }
}