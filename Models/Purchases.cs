using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Collections.Generic;

namespace AngularERPApi.Models
{
    [Table("Purchases", Schema = "dbo")]
    public partial class Purchases
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "PurchasesId")]
        public int PurchasesId { get; set; }

        [Display(Name = "Purchases Name")]
        public string PurchasesName { get; set; }

        [ForeignKey("Vendor")]
        [DisplayName("VenId")]
        [Required(ErrorMessage = "Please Enter  Vendor Name.")]
        public int VendorId { get; set; }

        [DisplayName("Vendor Name")]
        [NotMapped]
        public string VendorName { get; set; }


        [DataType(DataType.Date)]
        [DisplayName("PurchasesDate")]
        [DisplayFormat(DataFormatString = "{0:dd-MMMM-yyyy}")]
        [Required(ErrorMessage = "Please Enter Purchases Date.")]
        public DateTimeOffset PurchasesDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("DeliveryDate")]
        [DisplayFormat(DataFormatString = "{0:dd-MMMM-yyyy}")]
        [Required(ErrorMessage = "Please Enter Delivery Date.")]
        public DateTimeOffset DeliveryDate { get; set; }


        [DisplayName("PayedValue")]
        [Column(TypeName = "decimal(18,2)")]
        [Required(ErrorMessage = "Please Enter Payed Value.")]
        public decimal PayedValue { get; set; }

        [DisplayName("RemainValue")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal RemainValue { get; set; }

        public double Amount { get; set; }
        public double SubTotal { get; set; }
        public double Discount { get; set; }
        public double Tax { get; set; }
        public double Freight { get; set; }
        public double Total { get; set; }

        public  bool? DelFlage { get; set; } = false;



        public virtual Vendor Vendor { get; set; }

        public virtual List<PurchasesDetail> PurchasesDetail { get; set; } = new List<PurchasesDetail>();

    }
}
