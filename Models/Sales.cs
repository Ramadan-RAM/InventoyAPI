using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Collections.Generic;

namespace AngularERPApi.Models
{
    [Table("Sales", Schema = "dbo")]
    public partial class Sales
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "SalesId")]
        public int SalesId { get; set; }

        [DisplayName("Sales Name")]
        public string SalesName { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [DisplayName("CustomerId")]
        public int CustomerId { get; set; }

        [DisplayName("Customer Name")]
        [NotMapped]
        public string CustomerName { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("SalesDate")]
        [DisplayFormat(DataFormatString = "{0:dd-MMMM-yyyy}")]
        [Required(ErrorMessage = "Please Enter Sales Date.")]
        public DateTimeOffset SalesDate { get; set; }


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

        public bool? DelFlage { get; set; } = false;


        public virtual Customer Customer { get; set; }

        public virtual List<SalesDetail> SalesDetail { get; set; } = new List<SalesDetail>();



    }
}
