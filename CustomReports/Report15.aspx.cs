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
    public partial class Report15 : System.Web.UI.Page
    {
        private static int MyReportID = 115;
        public string htmlGlobalReportTable115;
        protected string selProjectOptions115 = "";
        private ReportManager objReportManager = new ReportManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)//首次加载
            {
                selProjectOptions115 = objReportManager.BindChoices();
            }

        }

        [WebMethod]
        public static string RefreshGlobalReport15(string selectedProjectsStr)
        {
          

            return ReportManager.GetReport15_HTML(selectedProjectsStr);
        }

    }
}