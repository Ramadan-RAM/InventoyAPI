using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularERPApi.Models
{

    [Table("InvoiceType", Schema = "dbo")]
    public class InvoiceType
    {

        public InvoiceType()
        {
            SalesInvoice = new HashSet<SalesInvoice>();
            PurchasesInvoice = new HashSet<PurchasesInvoice>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Invoice Type")]
        public int InvoiceTypeId { get; set; }
        [Required]
        public string InvoiceTypeName { get; set; }
        public string Description { get; set; }


        public  bool? DelFlage { get; set; } = false;

        public virtual ICollection<SalesInvoice> SalesInvoice { get; set; }
        public virtual ICollection<PurchasesInvoice> PurchasesInvoice { get; set; }

    }
}
