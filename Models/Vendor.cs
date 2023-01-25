using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularERPApi.Models
{
    [Table("Vendor", Schema = "dbo")]
    public partial class Vendor
    {
        public Vendor()
        {
            VendorAccount = new HashSet<VendorAccount>();
            Purchases = new HashSet<Purchases>();
            PurchasesInvoice = new HashSet<PurchasesInvoice>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Vendor")]
        public int VendorId { get; set; }

        [Required(ErrorMessage = "Please Enter Vendor Name.")]
        [Column(TypeName = "nvarchar(150)")]
        [MaxLength(145)]
        [Display(Name = "Vendor Name")]
        public string VendorName { get; set; }

        [ForeignKey(nameof(VendorTypeId))]
        [Display(Name = "VendorTypeId")]
        public int VendorTypeId { get; set; }
        [Display(Name =  "VendorTypeName")]
        [NotMapped]
        public string VendorTypeName { get; set; }


        [ForeignKey(nameof(CountryId))]
        [Required]
        [Display(Name = "CountryId")]
        public int CountryId { get; set; }
        [Display(Name = "CountryName")]
        [NotMapped]
        public string CountryName { get; set; }


        [Column(TypeName = "int")]
        [Display(Name = "Phone")]
        public int Phone { get; set; }

        [Required(ErrorMessage = "Please Enter Mobaile No.")]
        [Column(TypeName = "int")]
        [Display(Name = "Mobaile")]
        public int Mobaile { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        [MaxLength(145)]
        [Display(Name = "Address")]
        public string Address { get; set; }

      

        public string State { get; set; }
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        public string Email { get; set; }
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        [MaxLength(145)]
        [Display(Name = "Notes")]
        public string Notes { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Debit")]
        public decimal? Debit { get; set; }


        public  bool? DelFlage { get; set; } = false;


        public virtual Country Country { get; set; }
        public virtual VendorType VendorType { get; set; }

        public virtual ICollection<Purchases> Purchases { get; set; }
        public virtual ICollection<PurchasesInvoice> PurchasesInvoice { get; set; }
        public virtual ICollection<VendorAccount> VendorAccount { get; set; }


    }
}
