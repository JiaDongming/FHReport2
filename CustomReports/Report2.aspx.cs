using System;
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
    public partial class Report2 : System.Web.UI.Page
    {
        private ReportManager objReportManager = new ReportManager();
        private static int MyReportID = 102;
        public string selProjectOptions2 = "";
        public string htmlGlobalReportTable2;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 绑定下拉框字段值
                selProjectOptions2 = objReportManager.BindChoices();
                htmlGlobalReportTable2 = "";

            }
        }

        [WebMethod]
        public static string RefreshGlobalReport2(string selectedProjectsStr)
        {
            return ReportManager.GetReport2_HTML(selectedProjectsStr);
        }

    }
}