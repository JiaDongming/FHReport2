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
    public partial class Report13 : System.Web.UI.Page
    {
        private static int MyReportID = 113;
        protected string selProjectOptions113 = "";
        private ReportManager objReportManager = new ReportManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//不是回发加载
            {
                selProjectOptions113 = objReportManager.BindChoices();
            }
        }

        [WebMethod]
        public static string RefreshGlobalReport13(string selectedProjectsStr)
        {

            return ReportManager.GetReport13_HTML(selectedProjectsStr);
        }
    }
}