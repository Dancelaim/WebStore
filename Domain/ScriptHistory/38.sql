Begin Try
    SET NOCOUNT ON
    Set XACT_ABORT ON
Begin Tran
exec Check_db_Version 38

ALTER TABLE Product
ALTER COLUMN ProductImage nvarchar(255);

ALTER TABLE Product
ALTER COLUMN ProductImageThumb nvarchar(255);


exec Update_db_Version 38
Commit Tran
End Try
Begin Catch
   RollBack Tran
   Select ERROR_MESSAGE() as Msg, ERROR_NUMBER() as Num
End Catch