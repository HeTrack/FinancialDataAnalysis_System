namespace FinancialDataAnalysis_System.Models
{
    public class ParamAnalysis
    {
        public string? Parameter { get; set; }
        public double MediumLiquid { get; set; }
        public double MediumRent { get; set;}
        public double MediumFinStable { get; set; }
        public Dictionary<Organization, double> organizationFinances { get; set; }
    }
}
