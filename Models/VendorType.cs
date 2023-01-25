using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularERPApi.Models
{
    [Table("VendorType", Schema = "dbo")]
    public class VendorType
    {
        public VendorType()
        {

            Vendor = new HashSet<Vendor>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Vendor Type")]
        public int VendorTypeId { get; set; }
        [Required]
        public string VendorTypeName { get; set; }
        public string Description { get; set; }


        public  bool? DelFlage { get; set; } = false;


        public virtual ICollection<Vendor> Vendor { get; set; }
    }
}
