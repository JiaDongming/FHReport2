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
    public partial class Report18 : System.Web.UI.Page
    {
        private static int MyReportID = 118;
        public string htmlGlobalReportTable118;
        protected string selProjectOptions118 = "";
        private ReportManager objReportManager = new ReportManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                selProjectOptions118 = objReportManager.BindChoices();

            }

        }


        [WebMethod]
        public static string RefreshGlobalReport18(string selectedProjectsStr)
        {
           
            return ReportManager.GetRport18_HTML(selectedProjectsStr);
        }

    }
}