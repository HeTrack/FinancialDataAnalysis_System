using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialDataAnalysis_System.Models
{
    public class Organization
    {
        [Key]
        public int ID { get; set; }
        [DisplayName("Название организации")]
        [Required]
        public string Name { get; set; }
        [DisplayName("ИНН")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "ИНН юридического лица состоит из 10 цифр")]
        [Required]
        public string INN { get; set; }
        [Required]
        [DisplayName("Юридический адрес")]
        public string Adress { get; set; }
        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }
        [ForeignKey("OrganizationID")]
        public ICollection<Finance>? Finances { get; set; }
    }
}
