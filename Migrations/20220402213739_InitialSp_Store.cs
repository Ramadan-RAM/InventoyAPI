using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularERPApi.Migrations
{
    public partial class InitialSp_Store : Migration
    {
          protected override void Up(MigrationBuilder migrationBuilder)
          {
           
                    string Sp_DistributeProductAuto = @"Create Procedure Sp_DistributeProductAuto
                                 
                                        as 
                                        Declare @StoreId int
                                        Declare @ProductId int 

                                        Declare StoreCursor Cursor for
                                        select StoreID FROM StoreData where DelFlage = 0
                                        open StoreCursor
                                        fetch next from StoreCursor into @StoreId
                                        While @@FETCH_STATUS = 0
                                        begin

                                        Declare ItemCursor cursor for 
                                        Select ProductId from Product where DelFlage = 0
                                        open ItemCursor
                                        fetch next from ItemCursor into @ProductId
                                        While @@FETCH_STATUS = 0 
                                        begin
                                        if (not exists(Select * from StoreQuantity where StoreId = @StoreId and ProductId = @ProductId and DelFlage = 0))

                                        begin
                                        insert into StoreQuantity(StoreId,ProductId,ItemQuantity,DelFlage)
                                        Values (@StoreId,@ProductId,0,0)
                                        end
                                        fetch next from ItemCursor into @ProductId
                                        end
                                        Deallocate ItemCursor

                                        fetch next from StoreCursor into @StoreId
                                        end
                                        Deallocate StoreCursor
                                        ";
                    migrationBuilder.Sql(Sp_DistributeProductAuto);

                    string Sp_StoreQuantityInsert = @"Create Procedure Sp_StoreQuantityInsert

                                        @DistributeProduct as DistributeProduct ReadOnly

                                        as

                                        Declare @StoreId int
                                        Declare @ProductId int
                                        Declare ItemCursor cursor for

                                        Select StoreId,ProductId from @DistributeProduct

                                        Open ItemCursor
                                        fetch next from ItemCursor into @StoreId,@ProductId

                                        while @@FETCH_STATUS = 0 

                                        begin

                                        if (Not Exists(select * from StoreQuantity where StoreId = StoreId and ProductId = ProductId and DelFlage = 0))
                                        begin
                                        insert into StoreQuantity(StoreId,ProductId,ItemQuantity,DelFlage)

                                        Values(@StoreId,@ProductId,0,0)
                                        end

                                        fetch next from ItemCursor into @StoreId,@ProductId
                                        end
                                        deallocate ItemCursor
                                        ";
                    migrationBuilder.Sql(Sp_StoreQuantityInsert);

                    string Sp_StoreConvertInsert = @"Create Procedure Sp_StoreConvertInsert

                                                @StoreFromId int,
                                                @StoreToId int,
                                                @ProductId int,
                                                @ItemQuantity int,
                                                @ConDate Date,
                                                @Notes Nvarchar(Max)

                                                AS begin transaction

                                                insert into StoreConvert(StoreFromId,StoreToId,ProductId,ItemQuantity,ConDate,Notes,DelFlage)

                                                Values (@StoreFromId,@StoreFromId,@ProductId,@ItemQuantity,@ConDate,@Notes,0)

                                                if @@ERROR <> 0 Goto Err

                                                update StoreQuantity Set
                                                ItemQuantity = ItemQuantity - @ItemQuantity
                                                where StoreId = @StoreFromId and ProductId = @ProductId and DelFlage = 0

                                                update StoreQuantity Set
                                                ItemQuantity = ItemQuantity + @ItemQuantity
                                                where StoreId = @StoreToId and ProductId = @ProductId and DelFlage = 0

                                                if @@ERROR <> 0 Goto Err

                                                Commit transaction
                                                return 0 
                                                Err:
                                                rollback Transaction
                                                return 1
                                                 ";
                    migrationBuilder.Sql(Sp_StoreConvertInsert);

          }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

                string Sp_DistributeProductAuto = @"Drop Procedure Sp_DistributeProductAuto";
                migrationBuilder.Sql(Sp_DistributeProductAuto);

  
                string Sp_StoreQuantityInsert = @"Drop Procedure Sp_StoreQuantityInsert";
                migrationBuilder.Sql(Sp_StoreQuantityInsert);

                string Sp_StoreConvertInsert = @"Drop Procedure Sp_StoreConvertInsert";
                migrationBuilder.Sql(Sp_StoreConvertInsert);

        }
    }
}
