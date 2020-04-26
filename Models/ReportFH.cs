using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 用于统计烽火任务工时的实体类
    /// </summary>
   public class ReportFH
    {
        public string PersonID { get; set; }
        public string User { get; set; }
        public string WorkDays { get; set; }
        public string WorkHours { get; set; }
        public string TotalPoints { get; set; }

        public ReportFH()
        {
            TotalPoints = "0";
        }
    }

    /// <summary>
    /// 用于统计个人名下相关任务详情信息
    /// </summary>
    public class ReportFHDetail
    {
        public string ProjectID { get; set; }
        public string PersonID { get; set; }
        public string UserName { get; set; }
        public string BugID { get; set; }
        public string BugTitle { get; set; }
        public string TimeSpent { get; set; }
        public string TimeRemaining { get; set; }
        public string Points { get; set; }
        public string Status { get; set; }
        public string Desc { get; set; }

        public ReportFHDetail()
        {
            Points = "0";
        }
    }

    /// <summary>
    /// 总和统计
    /// </summary>
    public class ReportSummary
    {
        public double TotalWorkDays { get; set; }
        public double TotalWorkHours { get; set; }
        public double? TotalPoints { get; set; }

        public ReportSummary()
        {
            TotalPoints = 0;
        }
     
    }
}
