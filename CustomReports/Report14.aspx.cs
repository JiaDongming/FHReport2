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
    public partial class Report14 : System.Web.UI.Page
    {
        private static int MyReportID = 114;
        protected string selProjectOptions114 = "";
        private ReportManager objReportManager = new ReportManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//首次加载
            {
                selProjectOptions114 = objReportManager.BindChoices();
            }
        }

        [WebMethod]
        public static string RefreshGlobalReport14(string selectedProjectsStr)
        {
           
            return ReportManager.GetReport14_HTML(selectedProjectsStr);
        }

    }
}