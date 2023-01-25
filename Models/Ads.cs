using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularERPApi.Models
{
    [Table("Ads", Schema = "dbo")]
    public partial class Ads
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Ads ID")]
        public int AdsId { get; set; }

        [StringLength(500)]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Please Choose Front image.")]
        [Display(Name = "Front Image")]
        [NotMapped]
        public IFormFile FrontImage { get; set; }

        public bool? DelFlage { get; set; } = false;

    }
}
