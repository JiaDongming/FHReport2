using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class Report2_TaskInfo:Report2_Project
    {
   

        public string BugID { get; set; }
        public string BugTitle { get; set; }
        public string StatusName { get; set; }
    }
}
