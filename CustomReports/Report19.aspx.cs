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
    public partial class Report19 : System.Web.UI.Page
    {
        private static int MyReportID = 119;
        public string htmlGlobalReportTable119;
        protected string selProjectOptions119 = "";
        private ReportManager objReportManager = new ReportManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                selProjectOptions119 = objReportManager.BindChoices();
            }
        }


        [WebMethod]
        public static string RefreshGlobalReport19(string selectedProjectsStr)
        {

            return ReportManager.GetReport19_HTML(selectedProjectsStr);
        }
    }
}