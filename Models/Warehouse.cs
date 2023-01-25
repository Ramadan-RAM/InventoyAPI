using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularERPApi.Models
{
    [Table("Warehouse", Schema = "dbo")]
    public class Warehouse
    {
        public Warehouse()
        {
            Shipment = new HashSet<Shipment>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "WarehouseId")]
        public int WarehouseId { get; set; }
        [Required]
        public string WarehouseName { get; set; }
        public string Description { get; set; }


        [ForeignKey(nameof(StoreId))]
        [DisplayName("StoreId")]
        public int StoreId { get; set; }


        public  bool? DelFlage { get; set; } = false;



        public virtual ICollection<Shipment> Shipment { get; set; }
    }
}
