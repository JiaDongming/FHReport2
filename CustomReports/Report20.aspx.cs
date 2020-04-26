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
    public partial class Report20 : System.Web.UI.Page
    {
        private static int MyReportID = 120;
        protected string selProjectOptions120 = "";
        private ReportManager objReportManager = new ReportManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                selProjectOptions120 = objReportManager.BindChoices();
            }

        }


        [WebMethod]
        public static string RefreshGlobalReport20(string selectedProjectsStr)
        {

            return ReportManager.GetReport20_HTML(selectedProjectsStr);
        }

    }
}