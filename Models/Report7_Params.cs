using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   /// <summary>
   /// 报表7需要的参数实体类
   /// </summary>
   public class Report7_Params
    {
        public string selectProjectStr { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string OrderBy { get; set; }
    }
}
