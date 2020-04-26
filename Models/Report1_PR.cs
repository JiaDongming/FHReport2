using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 第一个报表实体类
    /// </summary>
  public class Report1_PR
    {
        public string BaseProjectName { get; set; } //基础项目名称
        public string BaseProjectID { get; set; } //基础项目编号
        public string ProjectRequestID { get; set; } //项目编号
        public string ProjectRequestName { get; set; } //项目名称
        public string StatusID { get; set; } //状态编号
        public string StatusName { get; set; } //状态名称

        public DateTime DateCreated { get; set; }
    }
}
