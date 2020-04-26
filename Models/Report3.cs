using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 报表3实体类
    /// </summary>
    public class Report3
    {
        public string ProjectID { get; set; }
        public string ProjectName { get; set; }

        public string BugID { get; set; }
        public string BugTitle { get; set; }
        public string StatusName { get; set; }
    }
}
