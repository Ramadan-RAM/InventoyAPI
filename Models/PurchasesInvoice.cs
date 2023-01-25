using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularERPApi.Models
{
    public class PurchasesInvoice
    {
        [Key]
        [Display(Name = "Invoice Number")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceId { get; set; }

        [ForeignKey(nameof(PurchasesDetailId))]
        public int PurchasesDetailId { get; set; }

        [ForeignKey("Vendor")]
        [DisplayName("Vendor Name")]
        [Required(ErrorMessage = "Please Enter  Vendor Name.")]
        public int VendorId { get; set; }

        public string InvoiceName { get; set; }

        [Display(Name = "Shipment")]
        public int ShipmentId { get; set; }

        [Display(Name = "Invoice Date")]
        public DateTimeOffset InvoiceDate { get; set; }

        [Display(Name = "Invoice Due Date")]
        public DateTimeOffset InvoiceDueDate { get; set; }

        [Display(Name = "Invoice Type")]
        public int InvoiceTypeId { get; set; }

        public  bool? DelFlage { get; set; } = false;


        public virtual Vendor Vendor { get; set; }
        public virtual PurchasesDetail PurchasesDetail { get; set; }
    }
}
