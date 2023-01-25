using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularERPApi.Models
{
    [Table("Department", Schema = "dbo")]
    public class Department
    {
        public Department()
        {
            Employee = new HashSet<Employee>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Department ID")]
        public int DepartmentId { get; set; }

        [Required]
        [Column(TypeName = "varchar(250)")]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }


        [Column(TypeName = "varchar(5)")]
        [Display(Name = "Department Abbreviation")]
        public string DepartmentAbbr { get; set; }

        public  bool? DelFlage { get; set; } = false;

        public virtual ICollection<Employee> Employee { get; set; }



    }
}
