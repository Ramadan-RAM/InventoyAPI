using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace AngularERPApi.Models
{
    [Table("StoreQuantity", Schema = "dbo")]
    public partial class StoreQuantity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "QuanId")]
        public int QuanId { get; set; }

        [ForeignKey("StoreData")]
        [DisplayName("Store")]
        public int StoreId { get; set; }

        [DisplayName("StoreName")]
        [NotMapped]
        public string StoreName { get; set; }

        [ForeignKey("Product")]
        [DisplayName("Product")]
        public int ProductId { get; set; }

        [DisplayName("ProductName")]
        [NotMapped]
        public string ProductName { get; set; }

        [DisplayName("ItemQuantity")]
        [Column(TypeName = "int")]
        [Required(ErrorMessage = "Please Enter Item Quantity.")]
        public int ItemQuantity { get; set; }

        [Column(TypeName = "bit")]
        public bool DelFlage { get; set; }

        public virtual Product Product { get; set; }
        public virtual StoreData StoreData { get; set; }

        //public virtual List<SalesDetail> SalesDetail { get; set; } = new List<SalesDetail>();

        //public virtual List<PurchasesDetail> PurchasesDetail { get; set; } = new List<PurchasesDetail>();
    }
}
