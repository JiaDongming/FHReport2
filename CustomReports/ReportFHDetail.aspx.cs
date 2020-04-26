﻿using System;
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
    public partial class ReportFHDetail : System.Web.UI.Page
    {
        string ProjectID = "502";
        // public string htmlGlobalReportTable101;
        public StringBuilder htmlGlobalReportTable101 = null;
        public string UserName = null;
        List<Models.ReportFHDetail> reportData = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            // reportData = ReportManager.GetReportDetail_Data_FH(Request.Params["UserID"].ToString());
            UserName = ReportManager.GetUserName(Request.Params["UserID"].ToString());
            htmlGlobalReportTable101 = ReportManager.GetReportDetail_HTML_FH(Request.Params["UserID"].ToString());

        }
    }
}