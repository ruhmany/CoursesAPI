using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Core.Entities
{
    public class RateReport
    {
        public int ReportedRateID { get; set; }
        public int ReporterUserID { get; set; }
        public string ReportMessage { get; set; }
        public virtual Rating ReportedRate { get; set; }
        public virtual User User { get; set; }
    }
}
