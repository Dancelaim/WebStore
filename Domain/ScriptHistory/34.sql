Begin Try
    SET NOCOUNT ON
    Set XACT_ABORT ON
Begin Tran
exec Check_db_Version 34

EXEC sp_rename 'ProductOptions.OptionParamsParentId', 'ProductOptionParentOptionId', 'COLUMN'


ALTER TABLE ProductOptions
ADD FOREIGN KEY (ProductOptionParentOptionId) REFERENCES ProductOptions(ProductOptionId)

exec Update_db_Version 34
Commit Tran
End Try
Begin Catch
   RollBack Tran
   Select ERROR_MESSAGE() as Msg, ERROR_NUMBER() as Num
End Catch