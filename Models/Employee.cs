using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularERPApi.Models
{
    [Table("Employee", Schema = "dbo")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Employee ID")]
        public int EmployeeId { get; set; }

        [Required]
        [Column(TypeName = "varchar(5)")]
        [MaxLength(5)]
        [Display(Name = "Employee No.")]
        public string EmployeeNumber { get; set; }

        [Required]
        [Column(TypeName = "varchar(150)")]
        [MaxLength(100)]
        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }

        [Required]
        [Column(TypeName = "varchar(16)")]
        [MaxLength(100)]
        [Display(Name = "PersoanalID")]
        public string PersoanalId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Hiring Date")]
        public DateTime HiringDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(12,2)")]
        [Display(Name = "Gross Salary")]
        public decimal? GrossSalary { get; set; }

        [Required]
        [Column(TypeName = "decimal(12,2)")]
        [Display(Name = "Net Salary")]
        public decimal? NetSalary { get; set; }


        [ForeignKey(nameof(DepartmentId))]
        [Required]
        public int DepartmentId { get; set; }
        [Display(Name = "Department Name")]
        [NotMapped]
        public string DepartmentName { get; set; }

        [ForeignKey(nameof(CountryId))]
        [Required]
        public int CountryId { get; set; }
        [Display(Name = "Country Name")]
        [NotMapped]
        public string CountryName { get; set; }


        [Column(TypeName = "int")]
        [Display(Name = "Phone")]
        public int Phone { get; set; }

        [Required(ErrorMessage = "Please Enter Mobaile No.")]
        [Column(TypeName = "int")]
        [Display(Name = "Mobaile")]
        public int Mobaile { get; set; }

        [StringLength(500)]
        public string EmployeeImage { get; set; }

        //[Required(ErrorMessage = "Please Choose image.")]
        //[Display(Name = "Employee Image")]
        //[NotMapped]
        //public IFormFile FrontImage { get; set; }


        [StringLength(900)]
        public string EmployeeResum { get; set; }

        //[Required(ErrorMessage = "Please Choose Resum.")]
        //[Display(Name = "Resum")]
        //[NotMapped]
        //public IFormFile Resum { get; set; }

        public  bool? DelFlage { get; set; } = false;

        public virtual Department Department { get; set; }
        public virtual Country Country { get; set; }



    }
}
