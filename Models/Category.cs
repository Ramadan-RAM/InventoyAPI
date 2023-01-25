using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularERPApi.Models
{
    [Table("Category", Schema = "dbo")]
    public partial class Category
    {
        public Category()
        {
            Product = new HashSet<Product>();
            PurchasesDetail = new HashSet<PurchasesDetail>();
            SalesDetail = new HashSet<SalesDetail>();
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "CategoryId")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please Enter Category.")]
        [Column(TypeName = "nvarchar(150)")]
        [MaxLength(145)]
        [Display(Name = "Category")]
        public string CategoryName { get; set; }


        public bool? DelFlage { get; set; } = false;

        public virtual ICollection<Product> Product { get; set; }

        public virtual ICollection<PurchasesDetail> PurchasesDetail { get; set; }

        public virtual ICollection<SalesDetail> SalesDetail { get; set; }


    }
}
