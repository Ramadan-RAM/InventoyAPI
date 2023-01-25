using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularERPApi.Models
{
    [Table("ShipmentType", Schema = "dbo")]
    public class ShipmentType
    {
        public ShipmentType()
        {
            Shipment = new HashSet<Shipment>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ShipmentTypeId")]
        public int ShipmentTypeId { get; set; }

        [Required]
        public string ShipmentTypeName { get; set; }
        public string Description { get; set; }


        public  bool? DelFlage { get; set; } = false;

        public virtual ICollection<Shipment> Shipment { get; set; }

    }
}
