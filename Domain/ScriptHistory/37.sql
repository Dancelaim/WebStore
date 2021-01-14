Begin Try
    SET NOCOUNT ON
    Set XACT_ABORT ON
Begin Tran
exec Check_db_Version 37

ALter table Customers 
Add CarryCoinsValue decimal (18,2)

ALter table Orders 
Add CarryCoinsSpent decimal (18,2)

ALter table Orders 
Add CarryCoinsCollected decimal (18,2)


exec Update_db_Version 37
Commit Tran
End Try
Begin Catch
   RollBack Tran
   Select ERROR_MESSAGE() as Msg, ERROR_NUMBER() as Num
End Catch