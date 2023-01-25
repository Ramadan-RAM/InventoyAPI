using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularERPApi.Models
{
    [Table("StoreConvert", Schema = "dbo")]
    public partial class StoreConvert
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "StoreConvertId")]
        public int StoreConvertId { get; set; }

        [ForeignKey("Product")]
        [DisplayName("Product")]
        public int ProductId { get; set; }

        [DisplayName("ProductName")]
        [NotMapped]
        public string ProductName { get; set; }

        [ForeignKey(nameof(StoreFromId))]
        [DisplayName("StoreFromId")]
        public int StoreFromId { get; set; }
        [DisplayName("StoreNameFrom")]
        [NotMapped]
        public string StoreNameFrom { get; set; }

        [ForeignKey(nameof(StoreToId))]
        [DisplayName("StoreToId")]
        public int StoreToId { get; set; }
        [DisplayName("StoreNameTo")]
        [NotMapped]
        public string StoreNameTo { get; set; }


        [DisplayName("ItemQuantity")]
        [Column(TypeName = "int")]
        [Required(ErrorMessage = "Please Enter Item Quantity.")]
        public int ItemQuantity { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("ConDate")]
        [DisplayFormat(DataFormatString = "{0:dd-MMMM-yyyy}")]
        [Required(ErrorMessage = "Please Enter Purchases Date.")]
        public DateTime? ConDate { get; set; }


        [DisplayName("Notes")]
        [Column(TypeName = "nvarchar(150)")]
        [MaxLength(145)]
        public string Notes { get; set; }

        public  bool? DelFlage { get; set; } = false;

        public virtual Product Product { get; set; }

        public virtual StoreData StoreData { get; set; }


    }
}
