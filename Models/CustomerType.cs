using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularERPApi.Models
{
    [Table("CustomerType", Schema = "dbo")]
    public class CustomerType
    {
        public CustomerType()
        {

            Customer = new HashSet<Customer>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Customer Type")]
        public int CustomerTypeId { get; set; }
        [Required]
        public string CustomerTypeName { get; set; }
        public string Description { get; set; }

        public  bool? DelFlage { get; set; } = false;

        public virtual ICollection<Customer> Customer { get; set; }
    }
}
