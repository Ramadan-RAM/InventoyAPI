using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularERPApi.Models
{
    [Table("Country", Schema = "dbo")]
    public class Country
    {
        public Country()
        {
            Employee = new HashSet<Employee>();

            Customer = new HashSet<Customer>();
            Vendor = new HashSet<Vendor>();
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Country ID")]
        public int CountryId { get; set; }


        [Required]
        [Column(TypeName = "varchar(250)")]
        [Display(Name = "Name Country")]
        public string CountryName { get; set; }


        [Column(TypeName = "varchar(5)")]
        [Display(Name = "Country Abbreviation")]
        public string CountryAbbr { get; set; }


        public bool? DelFlage { get; set; } = false;

        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Vendor> Vendor { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }


    }
}
