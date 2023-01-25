using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularERPApi.Migrations
{
    public partial class InitialSp_Acounts : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // CustomerAccount

            string Sp_CustomerAccountInsert = @"Create Procedure Sp_CustomerAccountInsert

                                @CustomerId int,
                                @PayedValue Decimal(18,2),
                                @DatePayed Datetime,
                                @Notes nvarchar(max)

                                ---- هنابدايه ال ترانزاكشن

                                as begin transaction
                                --- اولا لو حبيت تخصم دين من علي عميل هيتم الاتي
                                ---اولا هنخصم الدين الاساسي بتاع العملا من حقل الدين
                                --- يتم حفظ سجل جديد في حدول حسابات العملاء
                                Update Customer set
                                Debit = Debit - @PayedValue
                                Where CustomerId = @CustomerId

                                -- هنا بتسال هل حصل خطا وقت تنفيذ الجملة 
                                if @@ERROR<>0 goto Err_ --<<< في حاله وجود ايرور المفروض بيروح لسطر ده

                                Declare @RemainValue Decimal(18,2)
                                set @RemainValue=(Select Customer.Debit from Customer where CustomerId = @CustomerId)

                                insert into CustomerAccount
                                (CustomerId,PayedValue,RemainValue,DatePayed,Notes,DelFlage)

                                Values
                                (@CustomerId,@PayedValue,@RemainValue,@DatePayed,@Notes,0)

                                if @@ERROR<>0 goto Err_ --<<< في حاله وجود ايرور بيروح لسطر ده
                                commit transaction -- هنا بيتم تنفيذ الترانزاكشن في حاله معالجة الخطا والتاكد من السلامة 
                                return 0 -- هنا بيتم ارجاع القيمه بصفر دلاله علي ان التران تم بصوره صحيحه
                                Err_: -- هنا السطر المسؤل عن الاخطاء و الرجوع في العمليات 
                                rollback transaction -- الغاء كافة العمليات في البروسيدجر
                                return 1 -- رجوع القيمه بواحد دلاله علي وجود اخطاء

                                                                    ";
            migrationBuilder.Sql(Sp_CustomerAccountInsert);


            string Sp_CustomerAccountRollback = @"Create Procedure Sp_CustomerAccountRollback
                                            @CustomerId int
                                            as
                                            Declare @Max int
                                            set @Max = (select max(CustomerAccuntId) FROM CustomerAccount Where CustomerId = @CustomerId and DelFlage = 0)

                                            Declare @PayedValue decimal(18,2)
                                            set @PayedValue = (select PayedValue from CustomerAccount where CustomerAccuntId = @Max)

                                            Update Customer set 
                                            Debit = Debit + @PayedValue
                                            where CustomerId = @CustomerId

                                            Update CustomerAccount set DelFlage = 1
                                            where CustomerAccuntId = @Max
                                                                                       ";
            migrationBuilder.Sql(Sp_CustomerAccountRollback);


            //  VendorAccount

            string Sp_VendorAccountInsert = @"Create Procedure Sp_VendorAccountInsert

                                @VendorId int,
                                @PayedValue Decimal(18,2),
                                @DatePayed Datetime,
                                @Notes nvarchar(max)

                                ---- هنابدايه ال ترانزاكشن

                                as begin transaction
                                --- اولا لو حبيت تخصم دين من علي عميل هيتم الاتي
                                ---اولا هنخصم الدين الاساسي بتاع العملا من حقل الدين
                                --- يتم حفظ سجل جديد في حدول حسابات العملاء
                                Update Vendor set
                                Debit = Debit - @PayedValue
                                Where VendorId = @VendorId

                                -- هنا بتسال هل حصل خطا وقت تنفيذ الجملة 
                                if @@ERROR<>0 goto Err_ --<<< في حاله وجود ايرور المفروض بيروح لسطر ده

                                Declare @RemainValue Decimal(18,2)
                                set @RemainValue=(Select Vendor.Debit from Vendor where VendorId = @VendorId)

                                insert into VendorAccount
                                (VendorId,PayedValue,RemainValue,DatePayed,Notes,DelFlage)

                                Values
                                (@VendorId,@PayedValue,@RemainValue,@DatePayed,@Notes,0)

                                if @@ERROR<>0 goto Err_ --<<< في حاله وجود ايرور بيروح لسطر ده
                                commit transaction -- هنا بيتم تنفيذ الترانزاكشن في حاله معالجة الخطا والتاكد من السلامة 
                                return 0 -- هنا بيتم ارجاع القيمه بصفر دلاله علي ان التران تم بصوره صحيحه
                                Err_: -- هنا السطر المسؤل عن الاخطاء و الرجوع في العمليات 
                                rollback transaction -- الغاء كافة العمليات في البروسيدجر
                                return 1 -- رجوع القيمه بواحد دلاله علي وجود اخطاء

                                                                    ";
            migrationBuilder.Sql(Sp_VendorAccountInsert);


            string Sp_VendorAccountRollback = @"Create Procedure Sp_VendorAccountRollback
                                            @VendorId int
                                            as
                                            Declare @Max int
                                            set @Max = (select max(VendorAccountId) FROM VendorAccount Where VendorId = @VendorId and DelFlage = 0)

                                            Declare @PayedValue decimal(18,2)
                                            set @PayedValue = (select PayedValue from VendorAccount where VendorAccountId = @Max)

                                            Update Vendor set 
                                            Debit = Debit + @PayedValue
                                            where VendorId = @VendorId

                                            Update VendorAccount set DelFlage = 1
                                            where VendorAccountId = @Max
                                                                                       ";
            migrationBuilder.Sql(Sp_VendorAccountRollback);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //  Drop CustomerAccount

            string Sp_CustomerAccountInsert = @"Drop Procedure Sp_CustomerAccountInsert";
            migrationBuilder.Sql(Sp_CustomerAccountInsert);

            string Sp_CustomerAccountRollback = @"Drop Procedure Sp_CustomerAccountRollback";
            migrationBuilder.Sql(Sp_CustomerAccountRollback);


            // Drop  VendorAccount
            string Sp_VendorAccountInsert = @"Drop Procedure Sp_VendorAccountInsert";
            migrationBuilder.Sql(Sp_VendorAccountInsert);

            string Sp_VendorAccountRollback = @"Drop Procedure Sp_VendorAccountRollback";
            migrationBuilder.Sql(Sp_VendorAccountRollback);



        }
    }
}
