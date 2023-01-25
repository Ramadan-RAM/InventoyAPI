using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace AngularERPApi.Models
{
    [Table("Notification", Schema = "dbo")]
    public class Notification
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "NotificationId")]
        public int NotificationId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [DisplayName("Customer")]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerAccuntId))]
        [DisplayName("Customer Accunt")]
        public int CustomerAccuntId { get; set; }

        [ForeignKey(nameof(VendorId))]
        [DisplayName("Vendor")]
        public int VendorId { get; set; }

        [ForeignKey(nameof(VendorAccountId))]
        [DisplayName("Vendor Account")]
        public int VendorAccountId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [DisplayName("Category")]
        public int CategoryId { get; set; }


        [ForeignKey(nameof(ProductId))]
        [DisplayName("Product")]
        public int ProductId { get; set; }

        [ForeignKey(nameof(PublicMessageId))]
        [DisplayName("Public Message")]
        public int PublicMessageId { get; set; }

        [ForeignKey(nameof(PrivateMessage))]
        [DisplayName("Private Message")]
        public int PrivateMessage { get; set; }

        [ForeignKey(nameof(PurchasesId))]
        [DisplayName("Purchases")]
        public int PurchasesId { get; set; }

        [ForeignKey(nameof(SalesId))]
        [DisplayName("Sales")]
        public int SalesId { get; set; }

        [ForeignKey(nameof(StoreId))]
        [DisplayName("Store Data")]
        public int StoreId { get; set; }


        [ForeignKey(nameof(StoreConvertId))]
        [DisplayName("Store Convert")]
        public int StoreConvertId { get; set; }

        [ForeignKey(nameof(QuanId))]
        [DisplayName("Store Quantity")]
        public int QuanId { get; set; }


        public  bool? DelFlage { get; set; } = false;

    }
}
