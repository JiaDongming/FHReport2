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
    public partial class Report17 : System.Web.UI.Page
    {
        private static int MyReportID = 117;
        public string htmlGlobalReportTable117;
        protected string selProjectOptions117 = "";
        private ReportManager objReportManager = new ReportManager();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)//首次加载
            {
                selProjectOptions117 = objReportManager.BindChoices();
            }
        }

        [WebMethod]
        public static string RefreshGlobalReport17(string selectedProjectsStr)
        {
            
            return ReportManager.GetReport17_HTML(selectedProjectsStr);
        }

    }
}