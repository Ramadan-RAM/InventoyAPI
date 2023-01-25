using AngularERPApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace AngularERPApi.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<PublicMessage> PublicMessage { get; set; }
        public DbSet<PrivateMessage> PrivateMessage { get; set; }
        public virtual DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerType> CustomerType { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Purchases> Purchases { get; set; }
        public virtual DbSet<PurchasesDetail> PurchasesDetails { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<SalesDetail> SalesDetails { get; set; }
        public virtual DbSet<StoreConvert> StoreConverts { get; set; }
        public virtual DbSet<StoreData> StoreData { get; set; }
        public virtual DbSet<StoreQuantity> StoreQuantities { get; set; }
        public virtual DbSet<VendorAccount> VendorAccounts { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<VendorType> VendorType { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Ads> Ads { get; set; }
        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<UserProfile> UserProfile { get; set; }
        public virtual DbSet<Vistor> Vistor { get; set; }
        public DbSet<NumberSequence> NumberSequence { get; set; }
        public DbSet<Shipment> Shipment { get; set; }
        public DbSet<ShipmentType> ShipmentType { get; set; }
        public DbSet<Warehouse> Warehouse { get; set; }
        public DbSet<PurchasesInvoice> PurchasesInvoice { get; set; }
        public DbSet<SalesInvoice> SalesInvoice { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {


            builder.Entity<PublicMessage>()
                .HasOne<ApplicationUser>(a => a.Sender)
                .WithMany(d => d.PublicMessage)
                .HasForeignKey(d => d.UserID);


            builder.Entity<PrivateMessage>()
               .HasOne<ApplicationUser>(a => a.Sender)
               .WithMany(d => d.PrivateMessage)
               .HasForeignKey(d => d.UserID);



            builder.Entity<CustomerType>(entity =>
            {
                entity.ToTable("CustomerType");
            });


            builder.Entity<Customer>(entity => {
                entity.ToTable("Customer");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customers_Country");

                entity.HasOne(d => d.CustomerType)
                  .WithMany(p => p.Customer)
                  .HasForeignKey(d => d.CustomerTypeId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_Customers_CustomerType");
            });

            builder.Entity<CustomerAccount>(entity =>
            {
                entity.ToTable("CustomerAccount");

                entity.HasOne(d => d.Customer)
                  .WithMany(p => p.CustomerAccount)
                  .HasForeignKey(d => d.CustomerId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_Customer_Account_Customer");
            });

            builder.Entity<Sales>(entity =>
            {
                entity.ToTable("Sales");

                entity.HasOne(d => d.Customer)
                 .WithMany(p => p.Sales)
                 .HasForeignKey(d => d.CustomerId)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("FK_Sales_Customer");
            });


            builder.Entity<SalesDetail>(entity =>
            {
                entity.ToTable("SalesDetail");

                entity.HasOne(d => d.Product)
                 .WithMany(p => p.SalesDetail)
                 .HasForeignKey(d => d.ProductId)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("FK_SalesDetail_Product");


                entity.HasOne(d => d.Currency)
                 .WithMany(p => p.SalesDetail)
                 .HasForeignKey(d => d.CurrencyId)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("FK_SalesDetail_Currency");


                entity.HasOne(d => d.Category)
                 .WithMany(p => p.SalesDetail)
                 .HasForeignKey(d => d.CategoryId)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("FK_SalesDetail_Category");


                entity.HasOne(d => d.StoreData)
                .WithMany(p => p.SalesDetail)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesDetail_StoreData");
            });



            builder.Entity<VendorType>(entity =>
            {
                entity.ToTable("VendorType");
            });

            builder.Entity<Vendor>(entity => {
                entity.ToTable("Vendor");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Vendor)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vendors_Country");

                entity.HasOne(d => d.VendorType)
                  .WithMany(p => p.Vendor)
                  .HasForeignKey(d => d.VendorTypeId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_Vendors_VendorType");
            });

            builder.Entity<VendorAccount>(entity =>
            {
                entity.ToTable("VendorAccount");

                entity.HasOne(d => d.Vendor)
                  .WithMany(p => p.VendorAccount)
                  .HasForeignKey(d => d.VendorId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_Vendor_Account_Vendor");
            });


            builder.Entity<Purchases>(entity =>
            {
                entity.ToTable("Purchases");

                entity.HasOne(d => d.Vendor)
                 .WithMany(p => p.Purchases)
                 .HasForeignKey(d => d.VendorId)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("FK_Purchases_Vendor");
            });


            builder.Entity<PurchasesDetail>(entity =>
            {
                entity.ToTable("PurchasesDetail");

                entity.HasOne(d => d.Product)
                 .WithMany(p => p.PurchasesDetail)
                 .HasForeignKey(d => d.ProductId)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("FK_PurchasesDetails_Product");


                entity.HasOne(d => d.Currency)
                 .WithMany(p => p.PurchasesDetail)
                 .HasForeignKey(d => d.CurrencyId)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("FK_PurchasesDetails_Currency");


                entity.HasOne(d => d.Category)
                 .WithMany(p => p.PurchasesDetail)
                 .HasForeignKey(d => d.CategoryId)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("FK_PurchasesDetails_Category");


                entity.HasOne(d => d.StoreData)
               .WithMany(p => p.PurchasesDetail)
               .HasForeignKey(d => d.StoreId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_PurchasesDetail_StoreData");
            });



            builder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Department");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Country");
            });


            builder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");
            });

            builder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");
            });


            builder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");
            });

            builder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.HasOne(d => d.Category)
                 .WithMany(p => p.Product)
                 .HasForeignKey(d => d.CategoryId)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("FK_Products_Category");
            });


            builder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");
            });


            builder.Entity<Vistor>(entity =>
            {
                entity.ToTable("Vistor");
            });


            builder.Entity<InvoiceType>(entity =>
            {
                entity.ToTable("InvoiceType");
            });

            builder.Entity<Notification>(entity =>
            {
                entity.ToTable("Notification");
            });

            builder.Entity<Warehouse>(entity =>
            {
                entity.ToTable("Warehouse");
            });

            builder.Entity<ShipmentType>(entity =>
            {
                entity.ToTable("ShipmentType");
            });


            builder.Entity<Shipment>(entity =>
            {
                entity.ToTable("Shipment");


                entity.HasOne(d => d.Warehouse)
                   .WithMany(p => p.Shipment)
                   .HasForeignKey(d => d.WarehouseId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_Shipmen_Warehouse");

                entity.HasOne(d => d.ShipmentType)
                  .WithMany(p => p.Shipment)
                  .HasForeignKey(d => d.ShipmentTypeId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_Shipment_ShipmentType");
            });


            builder.Entity<SalesInvoice>(entity =>
            {
                entity.ToTable("SalesInvoice");

                entity.HasOne(d => d.Customer)
                  .WithMany(p => p.SalesInvoice)
                  .HasForeignKey(d => d.CustomerId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_SalesInvoice_Customer");


                entity.HasOne(d => d.SalesDetail)
                  .WithMany(p => p.SalesInvoice)
                  .HasForeignKey(d => d.SalesDetailId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_SalesInvoice_SalesDetail");

            });


            builder.Entity<PurchasesInvoice>(entity =>
            {
                entity.ToTable("PurchasesInvoice");

                entity.HasOne(d => d.Vendor)
                  .WithMany(p => p.PurchasesInvoice)
                  .HasForeignKey(d => d.VendorId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_PurchasesInvoice_Vendor");


                entity.HasOne(d => d.PurchasesDetail)
                 .WithMany(p => p.PurchasesInvoice)
                 .HasForeignKey(d => d.PurchasesDetailId)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("FK_SalesInvoice_PurchasesDetail");
            });

            builder.Entity<StoreData>(entity =>
            {
                entity.ToTable("StoreData");
            });

            builder.Entity<StoreQuantity>(entity =>
            {
                entity.ToTable("StoreQuantity");

                entity.HasOne(d => d.Product)
                  .WithMany(p => p.StoreQuantity)
                  .HasForeignKey(d => d.ProductId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_StoreQuantity_Product");


                entity.HasOne(d => d.StoreData)
                 .WithMany(p => p.StoreQuantity)
                 .HasForeignKey(d => d.StoreId)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("FK_StoreQuantity_StoreData");
            });

            builder.Entity<StoreConvert>(entity =>
            {
                entity.ToTable("StoreConvert");

                entity.HasOne(d => d.Product)
                  .WithMany(p => p.StoreConvert)
                  .HasForeignKey(d => d.ProductId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_StoreConvert_Product");


                entity.HasOne(d => d.StoreData)
                 .WithMany(p => p.StoreConvert)
                 .HasForeignKey(d => d.StoreFromId)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("FK_StoreConvert_StoreData_FromId");


                entity.HasOne(d => d.StoreData)
                .WithMany(p => p.StoreConvert)
                .HasForeignKey(d => d.StoreToId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StoreConvert_StoreData_ToId");

            });


            base.OnModelCreating(builder);
        }
    }
}
