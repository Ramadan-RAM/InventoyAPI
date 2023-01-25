using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Collections.Generic;

namespace AngularERPApi.Models
{
    [Table("CustomerAccount", Schema = "dbo")]
    public partial class CustomerAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "CustomerAccuntId")]
        public int CustomerAccuntId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [DisplayName("CustomerId")]
        [Required(ErrorMessage = "Please Enter  Customer Name.")]
        public int CustomerId { get; set; }

        [DisplayName("CustomerName")]
        [NotMapped]
        public string CustomerName { get; set; }

        [DisplayName("PayedValue")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PayedValue { get; set; }

        [DisplayName("RemainValue")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal RemainValue { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("DatePayed")]
        [DisplayFormat(DataFormatString = "{0:dd-MMMM-yyyy}")]
        [Required(ErrorMessage = "Please Enter Purchases Date.")]
        public DateTime DatePayed { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        [MaxLength(145)]
        [Display(Name = "Notes")]
        public string Notes { get; set; }

        public bool? DelFlage { get; set; } = false;


        public virtual Customer Customer { get; set; }

    }
}
