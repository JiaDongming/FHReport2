using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReportUtility;

namespace CustomReports
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string defaultReport4Start
        {
            get { return ReportCustomerInfo.GetDefaultReport4Start(); }
        }
    }
}