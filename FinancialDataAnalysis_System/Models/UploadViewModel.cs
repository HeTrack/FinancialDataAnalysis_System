using Microsoft.AspNetCore.Mvc;

namespace FinancialDataAnalysis_System.Models
{
    public class UploadFileViewModel
    {
        public double LiquidActive { get; set; }
        public double Commitments { get; set; }
        public double Passive { get; set; }
        public double FastActive { get; set; }
        public double SlowActive { get; set; }
        public double SalePribl { get; set; }
        public double SaleRevenue { get; set; }
        public double CleanPribl { get; set; }
        public double ActiveSum { get; set; }
        public double PriblWithOut { get; set; }
        public double SredVneoborot { get; set; }
        public double SrednSobstCapital { get; set; }
        public double HardActive { get; set; }
        public double CapitalAndRezerv { get; set; }
        public double MoneySredstv { get; set; }
        public double FinanceInvestment { get; set; }
        public double OborotActive { get; set; }
        public double SobstOborotSredstv { get; set; }
        public double SobstCapital { get; set; }
        public double ZaemCapital { get; set; }
    }
}
