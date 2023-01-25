using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AngularERPApi.Models
{
    [Table("Customer", Schema = "dbo")]
    public partial class Customer
    {
        public Customer()
        {
            CustomerAccount = new HashSet<CustomerAccount>();
            Sales = new HashSet<Sales>();
            SalesInvoice = new HashSet<SalesInvoice>();
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please Enter Customer Name.")]
        [Column(TypeName = "nvarchar(150)")]
        [MaxLength(145)]
        [Display(Name = "CustomerName")]
        public string CustomerName { get; set; }


        [ForeignKey(nameof(CustomerTypeId))]
        [Display(Name = "CustomerTypeId")]
        public int CustomerTypeId { get; set; }
        [Display(Name = "CustomerTypeName")]
        [NotMapped]
        public string CustomerTypeName { get; set; }


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

        public bool? DelFlage { get; set; } = false;


        public virtual Country Country { get; set; }
        public virtual CustomerType CustomerType { get; set; }


        public virtual ICollection<CustomerAccount> CustomerAccount { get; set; }
        public virtual ICollection<Sales> Sales { get; set; }
        public virtual ICollection<SalesInvoice> SalesInvoice { get; set; }

        
    }
}
