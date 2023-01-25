using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularERPApi.Models
{
    [Table("Shipment", Schema = "dbo")]
    public class Shipment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ShipmentId")]
        public int ShipmentId { get; set; }


        [ForeignKey(nameof(ShipmentTypeId))]
        [Display(Name = "ShipmentTypeId")]
        public int ShipmentTypeId { get; set; }

        [Display(Name = "Shipment Name")]
        public string ShipmentName { get; set; }

        [ForeignKey(nameof(SalesId))]
        [Display(Name = "SalesId")]
        public int SalesId { get; set; }
        public DateTimeOffset ShipmentDate { get; set; }

        [ForeignKey(nameof(WarehouseId))]
        [Display(Name = "WarehouseId")]
        public int WarehouseId { get; set; }

        [Display(Name = "Full Shipment")]
        public bool IsFullShipment { get; set; } = true;


        public  bool? DelFlage { get; set; } = false;

        public virtual ShipmentType ShipmentType { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}
