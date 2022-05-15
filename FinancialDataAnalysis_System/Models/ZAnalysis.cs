using System.Collections.Generic;

namespace FinancialDataAnalysis_System.Models
{
    public class ZAnalysis
    {
        public int? Date { get; set; }
        public IEnumerable<Finance> organizationFinances { get; set; }
    }
}
    