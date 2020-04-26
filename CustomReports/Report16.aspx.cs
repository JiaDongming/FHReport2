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
    public partial class Report16 : System.Web.UI.Page
    {
        private static int MyReportID = 116;
        public string htmlGlobalReportTable116;
        protected string selProjectOptions116 = "";
        private ReportManager objReportManager = new ReportManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                selProjectOptions116 = objReportManager.BindChoices();
            }
        }


        [WebMethod]
        public static string RefreshGlobalReport16(string selectedProjectsStr)
        {
            return ReportManager.GetReport16_HTML(selectedProjectsStr);
        }

    }
}