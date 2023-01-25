using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace AngularERPApi.Models
{
    [Table("VendorAccount", Schema = "dbo")]
    public partial class VendorAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "VendorAccountId")]
        public int VendorAccountId { get; set; }

        [ForeignKey("Vendor")]
        [DisplayName("VendorId")]
        [Required(ErrorMessage = "Please Enter  Vendor Name.")]
        public int VendorId { get; set; }

        [DisplayName("VendorName")]
        [NotMapped]
        public string VendorName { get; set; }


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

        public  bool? DelFlage { get; set; } = false;


        public virtual Vendor Vendor { get; set; }

    }
}
