using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BLL;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Models;

namespace CustomReports
{
    public partial class Report1 : System.Web.UI.Page
    {
 
        string ProjectID = "502";
       // public string htmlGlobalReportTable101;
        public StringBuilder htmlGlobalReportTable101 = null;
  
        List<Report1_PR> reportData = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//首次加载
            {
                reportData = ReportManager.GetReport1(ProjectID);
                htmlGlobalReportTable101= ReportManager.GetReportByHTML(reportData);  

            }
        }


    }
}