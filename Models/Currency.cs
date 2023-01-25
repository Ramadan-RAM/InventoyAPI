using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularERPApi.Models
{
    [Table("Currency", Schema = "dbo")]
    public class Currency
    {
        public Currency()
        {
            SalesDetail = new HashSet<SalesDetail>();
            PurchasesDetail = new HashSet<PurchasesDetail>();

     
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Currency")]
        public int CurrencyId { get; set; }
        [Required]
        public string CurrencyName { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal CurrencyEqual { get; set; }
        public string Description { get; set; }


        public bool? DelFlage { get; set; } = false;


        public virtual ICollection<SalesDetail> SalesDetail { get; set; }
        public virtual ICollection<PurchasesDetail> PurchasesDetail { get; set; }
    }
}
