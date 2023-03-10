using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularERPApi.Models
{
    [Table("SalesDetail", Schema = "dbo")]
    public partial class SalesDetail
    {
        public SalesDetail()
        {
            SalesInvoice = new HashSet<SalesInvoice>();
           
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "SalesDetailId")]
        public int SalesDetailId { get; set; }

        [ForeignKey(nameof(SalesId))]
        [DisplayName("SalesId")]
        public int SalesId { get; set; }
        [Display(Name = "SalesName")]
        [NotMapped]
        public string SalesName { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [DisplayName("CategoryId")]
        public int CategoryId { get; set; }

        [Display(Name = "CategoryName")]
        [NotMapped]
        public string CategoryName { get; set; }


        [ForeignKey(nameof(ProductId))]
        [DisplayName("ProductId")]
        public int ProductId { get; set; }

        [Display(Name = "Product Name")]
        [NotMapped]
        public string ProductName { get; set; }



        [ForeignKey(nameof(StoreId))]
        [DisplayName("StoreId")]
        public int StoreId { get; set; }
        [Display(Name = "Store Name")]
        [NotMapped]
        public string StoreName { get; set; }


        [Display(Name = "CurrencyId")]
        public int CurrencyId { get; set; }
        [Display(Name = "Currency Name")]
        [NotMapped]
        public string CurrencyName { get; set; }


        [DisplayName("SalesPrice")]
        [Column(TypeName = "decimal(18,2)")]
        [Required(ErrorMessage = "Please Enter Sales Price.")]
        public decimal SalesPrice { get; set; }

        [DisplayName("ItemQuantity")]
        [Column(TypeName = "int")]
        [Required(ErrorMessage = "Please Enter Item Quantity.")]
        public int ItemQuantity { get; set; }

        [DisplayName("ItemValue")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ItemValue { get; set; }
        public double Amount { get; set; }

        [Display(Name = "Disc %")]
        public double DiscountPercentage { get; set; }
        public double DiscountAmount { get; set; }
        public double SubTotal { get; set; }
        [Display(Name = "Tax %")]
        public double TaxPercentage { get; set; }
        public double TaxAmount { get; set; }
        public double Total { get; set; }

        [DisplayName("Description")]
        [Column(TypeName = "nvarchar(500)")]
        [MaxLength(495)]
        public string Description { get; set; }

        public  bool? DelFlage { get; set; } = false;


        public virtual Product Product { get; set; }
        public virtual StoreData StoreData { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual Category Category { get; set; }


        public virtual ICollection<SalesInvoice> SalesInvoice { get; set; }
    }
}
