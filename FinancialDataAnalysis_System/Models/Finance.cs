using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialDataAnalysis_System.Models
{
    public class Finance
    {
        [Key]
        public int? ID { get; set; }
        public int OrganizationID { get; set; }
        [DisplayName("Дата")]
        public int? Date { get; set; }
        [Required]
        [DisplayName("Абсолютная ликвидность")]
        public double AbsoluteLiquid { get; set; }
        [Required]
        [DisplayName("Теущая ликвидность")]
        public double CurrentLiquid { get; set; }
        [Required]
        [DisplayName("Быстрая ликвидность")]
        public double FastLiquid { get; set; }
        [Required]
        [DisplayName("Рентабельность продаж")]
        public double SaleProfit { get; set; }
        [Required]
        [DisplayName("Рентабельность активов")]
        public double ActiveProfit { get; set; }
        [Required]
        [DisplayName("Рентабельность внеоборотных средств")]
        public double VneoborotProfit { get; set; }
        [Required]
        [DisplayName("Рентабельность собственного капитала")]
        public double CapitalProfit { get; set; }
        [Required]
        [DisplayName("Автономия")]
        public double Avtonomia { get; set; }
        [Required]
        [DisplayName("Мобильность оборотных активов")]
        public double MobilActive { get; set; }
        [Required]
        [DisplayName("Манёвренность собственного капитала")]
        public double ManevrCapital { get; set; }
        [Required]
        [DisplayName("Соотношение заём. и собств. капитала")]
        public double ZaemAndCapital { get; set; }
        [Required]
        [DisplayName("Обеспеченность оборотных средств")]
        public double ObespOborotSredstv { get; set; }
        [Required]
        [DisplayName("Z - показатель")]
        public double Zrate { get; set; }
        [Required]
        public Organization? Organization { get; set; }
    }
}
