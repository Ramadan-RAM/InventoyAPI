using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace AngularERPApi.Models
{
    [Table("Product", Schema = "dbo")]
    public partial class Product
    {

        public Product()
        {
            PurchasesDetail = new HashSet<PurchasesDetail>();
            SalesDetail = new HashSet<SalesDetail>();
            /*StoreData = new HashSet<StoreData>();*/
            StoreConvert = new HashSet<StoreConvert>();
            StoreQuantity = new HashSet<StoreQuantity>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ProductId")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please Enter Product No.")]
        [Column(TypeName = "nvarchar(20)")]
        [MaxLength(15)]
        [Display(Name = "Product No.")]
        public string ProductCode { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [Required]
        public int CategoryId { get; set; }
        [Display(Name = "CategoryName")]
        [NotMapped]
        public string CategoryName { get; set; }


        [Required(ErrorMessage = "Please Enter Product Name.")]
        [Column(TypeName = "nvarchar(150)")]
        [MaxLength(145)]
        [Display(Name = "ProductName")]
        public string ProductName { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Quantity")]
        public decimal Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Cost { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        [MaxLength(145)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [StringLength(500)]
        public string ImageProduct { get; set; }

        //[Required(ErrorMessage = "Please Choose Product image.")]
        //[Display(Name = "Product Image")]
        //[NotMapped]
        //public IFormFile ProductImage { get; set; }

        [Required]
        [Display(Name = "Available")]
        public bool IsAvailable { get; set; }

        public  bool? DelFlage { get; set; } = false;

        public virtual Category Category { get; set; }



        public virtual ICollection<PurchasesDetail> PurchasesDetail { get; set; }
        public virtual ICollection<SalesDetail> SalesDetail { get; set; }
        /*public virtual ICollection<StoreData> StoreData { get; set; }*/
        public virtual ICollection<StoreConvert> StoreConvert { get; set; }
        public virtual ICollection<StoreQuantity> StoreQuantity { get; set; }


    }
}
