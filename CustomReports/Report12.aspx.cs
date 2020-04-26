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
    public partial class Report12 : System.Web.UI.Page
    {
        private static int MyReportID = 112;
        protected string selProjectOptions112 = "";
        private ReportManager objReportManager = new ReportManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//首次加载
            {
                selProjectOptions112 = objReportManager.BindChoices();
            }
        }

        [WebMethod]
        public static string RefreshGlobalReport12(string selectedProjectsStr)
        {
              return ReportManager.GetReport12_HTML(selectedProjectsStr);
        }

    }
}