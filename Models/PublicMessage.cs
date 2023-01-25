using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace AngularERPApi.Models
{
    [Table("PublicMessage", Schema = "dbo")]
    public class PublicMessage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Public Message")]
        public int PublicMessageId { get; set; }

        [Required]
        [DisplayName("UserName")]
        public string UserName { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        [DisplayName("Image")]
        public string Image { get; set; }

        [Required]
        [DisplayName("Text")]
        [Column(TypeName = "nvarchar(500)")]
        [MaxLength(450)]
        public string Text { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("When")]
        [DisplayFormat(DataFormatString = "{0:dd-MMMM-yyyy}")]
        public DateTime When { get; set; }

        public string UserID { get; set; }

        public virtual ApplicationUser Sender { get; set; }

        public PublicMessage()
        {
            When = DateTime.Now;
        }

        public  bool? DelFlage { get; set; } = false;

    }
}
