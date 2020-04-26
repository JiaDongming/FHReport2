using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportUtility
{
    public static class ReportCustomerInfo
    {
        public static string GetDefaultReport4Start()
        {
            return "null.html";
        }

        public static int GetDefaultReportID4Start()
        {
            return 10000;
        }

        #region 控制显示什么报表
        /// <summary>
        /// 控制显示报表
        /// </summary>
        /// <returns></returns>
        public static List<string> GetShowReportIDs()
        {
            List<string> reportIds = new List<string>();

            reportIds.Add("-1_101");
            reportIds.Add("-1_102");
            reportIds.Add("-1_103");
            reportIds.Add("-1_104");
            reportIds.Add("-1_105");
            reportIds.Add("-1_106");
            reportIds.Add("-1_107");
            reportIds.Add("-1_108");
            reportIds.Add("-1_109");
            reportIds.Add("-1_110");
            reportIds.Add("-1_111");
            reportIds.Add("-1_112");
            reportIds.Add("-1_113");
            reportIds.Add("-1_114");
            reportIds.Add("-1_115");
            reportIds.Add("-1_116");
            reportIds.Add("-1_117");
            reportIds.Add("-1_118");
            reportIds.Add("-1_119");
            reportIds.Add("-1_120");
            reportIds.Add("-1_121");
            reportIds.Add("-1_122");
            reportIds.Add("-1_123");
            return reportIds;
        }

        #endregion

    }
}
