using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AngularERPApi.Models
{
    [Table("StoreData", Schema = "dbo")]
    public partial class StoreData
    {
        public StoreData()
        {
            PurchasesDetail = new HashSet<PurchasesDetail>();
            SalesDetail = new HashSet<SalesDetail>();
            StoreConvert = new HashSet<StoreConvert>();
            StoreQuantity = new HashSet<StoreQuantity>();
            Warehouse = new HashSet<Warehouse>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "StoreId")]
        public int StoreId { get; set; }

        /*[ForeignKey("Product")]
        [DisplayName("Product")]
        public int ProductId { get; set; }

        [DisplayName("ProductName")]
        [NotMapped]
        public string ProductName { get; set; }*/

        [Required(ErrorMessage = "Please Enter Store Name.")]
        [Column(TypeName = "nvarchar(150)")]
        [MaxLength(145)]
        [Display(Name = "StoreName")]
        public string StoreName { get; set; }


        [DisplayName("Address")]
        [Column(TypeName = "nvarchar(150)")]
        [MaxLength(145)]
        public string Address { get; set; }

        [DisplayName("Notes")]
        [Column(TypeName = "nvarchar(150)")]
        [MaxLength(145)]
        public string Notes { get; set; }

        public  bool? DelFlage { get; set; } = false;



        public virtual ICollection<PurchasesDetail> PurchasesDetail { get; set; }
        public virtual ICollection<SalesDetail> SalesDetail { get; set; }
        public virtual ICollection<StoreConvert> StoreConvert { get; set; }
        public virtual ICollection<StoreQuantity> StoreQuantity { get; set; }
        public virtual ICollection<Warehouse> Warehouse { get; set; }
    
    }
}
