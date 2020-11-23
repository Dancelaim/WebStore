Begin Try
    SET NOCOUNT ON
    Set XACT_ABORT ON
Begin Tran
exec Check_db_Version 32

ALTER TABLE ProductOptions
ADD OptionProductId Uniqueidentifier

ALTER TABLE ProductOptions
ADD CONSTRAINT FK_ProductOptions_Product FOREIGN KEY (OptionProductId) REFERENCES Product(ProductId)

drop table ProductToOption

exec Update_db_Version 32
Commit Tran
End Try
Begin Catch
   RollBack Tran
   Select ERROR_MESSAGE() as Msg, ERROR_NUMBER() as Num
End Catch