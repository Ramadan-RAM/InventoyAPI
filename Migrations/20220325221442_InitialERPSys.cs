using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularERPApi.Migrations
{
    public partial class InitialERPSys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Ads",
                schema: "dbo",
                columns: table => new
                {
                    AdsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DelFlage = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ads", x => x.AdsId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    UserImg = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(145)", maxLength: 145, nullable: false),
                    DelFlage = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "varchar(250)", nullable: false),
                    CountryAbbr = table.Column<string>(type: "varchar(5)", nullable: true),
                    DelFlage = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                schema: "dbo",
                columns: table => new
                {
                    CurrencyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrencyEqual = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DelFlage = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.CurrencyId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerType",
                columns: table => new
                {
                    CustomerTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DelFlage = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerType", x => x.CustomerTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "varchar(250)", nullable: false),
                    DepartmentAbbr = table.Column<string>(type: "varchar(5)", nullable: true),
                    DelFlage = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceType",
                columns: table => new
                {
                    InvoiceTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DelFlage = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceType", x => x.InvoiceTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerAccuntId = table.Column<int>(type: "int", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    VendorAccountId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PublicMessageId = table.Column<int>(type: "int", nullable: false),
                    PrivateMessage = table.Column<int>(type: "int", nullable: false),
                    PurchasesId = table.Column<int>(type: "int", nullable: false),
                    SalesId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    StoreConvertId = table.Column<int>(type: "int", nullable: false),
                    QuanId = table.Column<int>(type: "int", nullable: false),
                    DelFlage = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.NotificationId);
                });

            migrationBuilder.CreateTable(
                name: "NumberSequence",
                columns: table => new
                {
                    NumberSequenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberSequenceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Module = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prefix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumberSequence", x => x.NumberSequenceId);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentType",
                columns: table => new
                {
                    ShipmentTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipmentTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DelFlage = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentType", x => x.ShipmentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "UserProfile",
                schema: "dbo",
                columns: table => new
                {
                    UserProfileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DelFlage = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.UserProfileId);
                });

            migrationBuilder.CreateTable(
                name: "VendorType",
                columns: table => new
                {
                    VendorTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DelFlage = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorType", x => x.VendorTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Vistor",
                columns: table => new
                {
                    VistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    DelFlage = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vistor", x => x.VistId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrivateMessage",
                schema: "dbo",
                columns: table => new
                {
                    PrivateMessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    When = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DelFlage = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateMessage", x => x.PrivateMessageId);
                    table.ForeignKey(
                        name: "FK_PrivateMessage_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PublicMessage",
                schema: "dbo",
                columns: table => new
                {
                    PublicMessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    When = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DelFlage = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicMessage", x => x.PublicMessageId);
                    table.ForeignKey(
                        name: "FK_PublicMessage_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(145)", maxLength: 145, nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(145)", maxLength: 145, nullable: true),
                    ImageProduct = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    DelFlage = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Category",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(145)", maxLength: 145, nullable: false),
                    CustomerTypeId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Mobaile = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(145)", maxLength: 145, nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(145)", maxLength: 145, nullable: true),
                    Debit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DelFlage = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_Country",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_CustomerType",
                        column: x => x.CustomerTypeId,
                        principalTable: "CustomerType",
                        principalColumn: "CustomerTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeNumber = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false),
                    EmployeeName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    PersoanalId = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HiringDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GrossSalary = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    NetSalary = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<int>(type: "int", maxLength: 15, nullable: false),
                    Mobaile = table.Column<int>(type: "int", maxLength: 15, nullable: false),
                    EmployeeImage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    EmployeeResum = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: true),
                    DelFlage = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Country",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Department",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    VendorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorName = table.Column<string>(type: "nvarchar(145)", maxLength: 145, nullable: false),
                    VendorTypeId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<int>(type: "int", maxLength: 15, nullable: false),
                    Mobaile = table.Column<int>(type: "int", maxLength: 15, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(145)", maxLength: 145, nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(145)", maxLength: 145, nullable: true),
                    Debit = table.Column<decimal>(type: "decimal(18,2)", maxLength: 145, nullable: true),
                    DelFlage = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.VendorId);
                    table.ForeignKey(
                        name: "FK_Vendors_Country",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vendors_VendorType",
                        column: x => x.VendorTypeId,
                        principalTable: "VendorType",
                        principalColumn: "VendorTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreData",
                columns: table => new
                {
                    StoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(type: "nvarchar(145)", maxLength: 145, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(145)", maxLength: 145, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(145)", maxLength: 145, nullable: true),
                    DelFlage = table.Column<bool>(type: "bit", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreData", x => x.StoreId);
                    table.ForeignKey(
                        name: "FK_StoreData_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAccount",
                columns: table => new
                {
                    CustomerAccuntId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    PayedValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RemainValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DatePayed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(145)", maxLength: 145, nullable: true),
                    DelFlage = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAccount", x => x.CustomerAccuntId);
                    table.ForeignKey(
                        name: "FK_Customer_Account_Customer",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    SalesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesName = table.Column<string>(type: "varchar(250)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    SalesDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeliveryDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    PayedValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RemainValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    SubTotal = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    Tax = table.Column<double>(type: "float", nullable: false),
                    Freight = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    DelFlage = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SalesId);
                    table.ForeignKey(
                        name: "FK_Sales_Customer",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    PurchasesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchasesName = table.Column<string>(type: "varchar(250)", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    PurchasesDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeliveryDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    PayedValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RemainValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    SubTotal = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    Tax = table.Column<double>(type: "float", nullable: false),
                    Freight = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    DelFlage = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.PurchasesId);
                    table.ForeignKey(
                        name: "FK_Purchases_Vendor",
                        column: x => x.VendorId,
                        principalTable: "Vendor",
                        principalColumn: "VendorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VendorAccount",
                columns: table => new
                {
                    VendorAccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    PayedValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RemainValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DatePayed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(145)", maxLength: 145, nullable: true),
                    DelFlage = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorAccount", x => x.VendorAccountId);
                    table.ForeignKey(
                        name: "FK_Vendor_Account_Vendor",
                        column: x => x.VendorId,
                        principalTable: "Vendor",
                        principalColumn: "VendorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreConvert",
                columns: table => new
                {
                    StoreConvertId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    StoreFromId = table.Column<int>(type: "int", nullable: false),
                    StoreToId = table.Column<int>(type: "int", nullable: false),
                    ItemQuantity = table.Column<int>(type: "int", nullable: false),
                    ConDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(145)", maxLength: 145, nullable: true),
                    DelFlage = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreConvert", x => x.StoreConvertId);
                    table.ForeignKey(
                        name: "FK_StoreConvert_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);

                    table.ForeignKey(
                       name: "FK_StoreConvert_StoreData_FromId",
                       column: x => x.StoreFromId,
                       principalTable: "StoreData",
                       principalColumn: "StoreId",
                       onDelete: ReferentialAction.Restrict);

                    table.ForeignKey(
                        name: "FK_StoreConvert_StoreData_ToId",
                        column: x => x.StoreToId,
                        principalTable: "StoreData",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreQuantity",
                columns: table => new
                {
                    QuanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ItemQuantity = table.Column<int>(type: "int", nullable: false),
                    DelFlage = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreQuantity", x => x.QuanId);
                    table.ForeignKey(
                        name: "FK_StoreQuantity_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoreQuantity_StoreData",
                        column: x => x.StoreId,
                        principalTable: "StoreData",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    WarehouseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarehouseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    DelFlage = table.Column<bool>(type: "bit", nullable: true),
                    StoreDataStoreId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.WarehouseId);
                    table.ForeignKey(
                        name: "FK_Warehouse_StoreData_StoreDataStoreId",
                        column: x => x.StoreDataStoreId,
                        principalTable: "StoreData",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesDetail",
                columns: table => new
                {
                    SalesDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    SalesPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ItemQuantity = table.Column<int>(type: "int", nullable: false),
                    ItemValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    DiscountPercentage = table.Column<double>(type: "float", nullable: false),
                    DiscountAmount = table.Column<double>(type: "float", nullable: false),
                    SubTotal = table.Column<double>(type: "float", nullable: false),
                    TaxPercentage = table.Column<double>(type: "float", nullable: false),
                    TaxAmount = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(495)", maxLength: 495, nullable: true),
                    DelFlage = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesDetail", x => x.SalesDetailId);
                    table.ForeignKey(
                        name: "FK_SalesDetail_Category",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesDetail_Currency",
                        column: x => x.CurrencyId,
                        principalSchema: "dbo",
                        principalTable: "Currency",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesDetail_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesDetail_Sales_SalesId",
                        column: x => x.SalesId,
                        principalTable: "Sales",
                        principalColumn: "SalesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesDetail_StoreData",
                        column: x => x.StoreId,
                        principalTable: "StoreData",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchasesDetail",
                columns: table => new
                {
                    PurchasesDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchasesId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    PurchasesPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ItemQuantity = table.Column<int>(type: "int", nullable: false),
                    ItemValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    DiscountPercentage = table.Column<double>(type: "float", nullable: false),
                    DiscountAmount = table.Column<double>(type: "float", nullable: false),
                    SubTotal = table.Column<double>(type: "float", nullable: false),
                    TaxPercentage = table.Column<double>(type: "float", nullable: false),
                    TaxAmount = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(495)", maxLength: 495, nullable: true),
                    DelFlage = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasesDetail", x => x.PurchasesDetailId);
                    table.ForeignKey(
                        name: "FK_PurchasesDetail_Purchases_PurchasesId",
                        column: x => x.PurchasesId,
                        principalTable: "Purchases",
                        principalColumn: "PurchasesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchasesDetail_StoreData",
                        column: x => x.StoreId,
                        principalTable: "StoreData",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchasesDetails_Category",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchasesDetails_Currency",
                        column: x => x.CurrencyId,
                        principalSchema: "dbo",
                        principalTable: "Currency",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchasesDetails_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shipment",
                columns: table => new
                {
                    ShipmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipmentTypeId = table.Column<int>(type: "int", nullable: false),
                    ShipmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesId = table.Column<int>(type: "int", nullable: false),
                    ShipmentDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    IsFullShipment = table.Column<bool>(type: "bit", nullable: false),
                    DelFlage = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipment", x => x.ShipmentId);
                    table.ForeignKey(
                        name: "FK_Shipmen_Warehouse",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shipment_ShipmentType",
                        column: x => x.ShipmentTypeId,
                        principalTable: "ShipmentType",
                        principalColumn: "ShipmentTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesInvoice",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesDetailId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    InvoiceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipmentId = table.Column<int>(type: "int", nullable: false),
                    InvoiceDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    InvoiceDueDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    InvoiceTypeId = table.Column<int>(type: "int", nullable: false),
                    DelFlage = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesInvoice", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_SalesInvoice_Customer",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesInvoice_InvoiceType_InvoiceTypeId",
                        column: x => x.InvoiceTypeId,
                        principalTable: "InvoiceType",
                        principalColumn: "InvoiceTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesInvoice_SalesDetail",
                        column: x => x.SalesDetailId,
                        principalTable: "SalesDetail",
                        principalColumn: "SalesDetailId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchasesInvoice",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchasesDetailId = table.Column<int>(type: "int", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    InvoiceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipmentId = table.Column<int>(type: "int", nullable: false),
                    InvoiceDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    InvoiceDueDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    InvoiceTypeId = table.Column<int>(type: "int", nullable: false),
                    DelFlage = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasesInvoice", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_PurchasesInvoice_InvoiceType_InvoiceTypeId",
                        column: x => x.InvoiceTypeId,
                        principalTable: "InvoiceType",
                        principalColumn: "InvoiceTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchasesInvoice_Vendor",
                        column: x => x.VendorId,
                        principalTable: "Vendor",
                        principalColumn: "VendorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesInvoice_PurchasesDetail",
                        column: x => x.PurchasesDetailId,
                        principalTable: "PurchasesDetail",
                        principalColumn: "PurchasesDetailId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CountryId",
                table: "Customer",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CustomerTypeId",
                table: "Customer",
                column: "CustomerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccount_CustomerId",
                table: "CustomerAccount",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CountryId",
                table: "Employee",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employee",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateMessage_UserID",
                schema: "dbo",
                table: "PrivateMessage",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicMessage_UserID",
                schema: "dbo",
                table: "PublicMessage",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_VendorId",
                table: "Purchases",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasesDetail_CategoryId",
                table: "PurchasesDetail",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasesDetail_CurrencyId",
                table: "PurchasesDetail",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasesDetail_ProductId",
                table: "PurchasesDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasesDetail_PurchasesId",
                table: "PurchasesDetail",
                column: "PurchasesId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasesDetail_StoreId",
                table: "PurchasesDetail",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasesInvoice_InvoiceTypeId",
                table: "PurchasesInvoice",
                column: "InvoiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasesInvoice_PurchasesDetailId",
                table: "PurchasesInvoice",
                column: "PurchasesDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasesInvoice_VendorId",
                table: "PurchasesInvoice",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerId",
                table: "Sales",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetail_CategoryId",
                table: "SalesDetail",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetail_CurrencyId",
                table: "SalesDetail",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetail_ProductId",
                table: "SalesDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetail_SalesId",
                table: "SalesDetail",
                column: "SalesId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetail_StoreId",
                table: "SalesDetail",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoice_CustomerId",
                table: "SalesInvoice",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoice_InvoiceTypeId",
                table: "SalesInvoice",
                column: "InvoiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoice_SalesDetailId",
                table: "SalesInvoice",
                column: "SalesDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipment_ShipmentTypeId",
                table: "Shipment",
                column: "ShipmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipment_WarehouseId",
                table: "Shipment",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreConvert_ProductId",
                table: "StoreConvert",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreConvert_StoreToId",
                table: "StoreConvert",
                column: "StoreToId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreData_ProductId",
                table: "StoreData",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreQuantity_ProductId",
                table: "StoreQuantity",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreQuantity_StoreId",
                table: "StoreQuantity",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendor_CountryId",
                table: "Vendor",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendor_VendorTypeId",
                table: "Vendor",
                column: "VendorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VendorAccount_VendorId",
                table: "VendorAccount",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_StoreDataStoreId",
                table: "Warehouse",
                column: "StoreDataStoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ads",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CustomerAccount");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "NumberSequence");

            migrationBuilder.DropTable(
                name: "PrivateMessage",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PublicMessage",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PurchasesInvoice");

            migrationBuilder.DropTable(
                name: "SalesInvoice");

            migrationBuilder.DropTable(
                name: "Shipment");

            migrationBuilder.DropTable(
                name: "StoreConvert");

            migrationBuilder.DropTable(
                name: "StoreQuantity");

            migrationBuilder.DropTable(
                name: "UserProfile",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "VendorAccount");

            migrationBuilder.DropTable(
                name: "Vistor");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "PurchasesDetail");

            migrationBuilder.DropTable(
                name: "InvoiceType");

            migrationBuilder.DropTable(
                name: "SalesDetail");

            migrationBuilder.DropTable(
                name: "Warehouse");

            migrationBuilder.DropTable(
                name: "ShipmentType");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Currency",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "StoreData");

            migrationBuilder.DropTable(
                name: "Vendor");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "VendorType");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "CustomerType");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
