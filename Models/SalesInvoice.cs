using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularERPApi.Models
{
    public class SalesInvoice
    {
        [Key]
        [Display(Name = "Invoice Number")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceId { get; set; }



        [ForeignKey(nameof(SalesDetailId))]
        public int SalesDetailId { get; set; }


        [ForeignKey(nameof(CustomerId))]
        [DisplayName("Customer Name")]
        [Required(ErrorMessage = "Please Enter  Customer Name.")]
        public int CustomerId { get; set; }

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

        public virtual Customer Customer { get; set; }
        public virtual SalesDetail SalesDetail { get; set; }



    }
}
